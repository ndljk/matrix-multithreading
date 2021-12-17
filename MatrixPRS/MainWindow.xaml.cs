using MatrixPRS.PRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input; 
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace MatrixPRS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        SeriesCollection SeriesCollection = new SeriesCollection();
        LineSeries linijaMnozenjaParalelno = new LineSeries();
        LineSeries linijaMnozenjaSerijski = new LineSeries();

        LineSeries linijaSabiranjeSerijski = new LineSeries();
        LineSeries linijaSabiranjeParalelno = new LineSeries();

        LineSeries linijaInvertovanjaSerijski = new LineSeries();
        LineSeries linijaInvertovanjaParalelno = new LineSeries();


        DispatcherTimer timer;

        double panelWidth;
        bool hidden;

        public MainWindow()
        {
            InitializeComponent();


            linijaMnozenjaSerijski.Title = "Serijsko mnozenje";
            linijaMnozenjaParalelno.Title = "Paralelno mnozenje";

            linijaSabiranjeSerijski.Title = "Serijsko sabiranje";
            linijaSabiranjeParalelno.Title = "Paralelno sabiranje";

            linijaInvertovanjaSerijski.Title = "Serijsko invertovanje";
            linijaInvertovanjaParalelno.Title = "Paralelno invertovanje";
           /*

            linijaMnozenjaSerijski.Values = new ChartValues<ObservablePoint>();
            linijaMnozenjaParalelno.Values = new ChartValues<ObservablePoint>();
            linijaSabiranjeSerijski.Values = new ChartValues<ObservablePoint>();
            linijaSabiranjeParalelno.Values = new ChartValues<ObservablePoint>();
            linijaInvertovanjaSerijski.Values = new ChartValues<ObservablePoint>();
            linijaInvertovanjaParalelno.Values = new ChartValues<ObservablePoint>();
           */


            chart.Series = SeriesCollection;

            //Timer koji se koristi za menu (otvaranje/zatvaranje)
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;
            panelWidth = sidePanel.Width;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 1;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 1;
                if (sidePanel.Width <= 35)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Otvori_Zatvori_Menu(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int from = numericDonji.Value ?? 0;
            int to = numericGornji.Value ?? 1;

            Test testMnozenja = new Test(from, to, Test.TipTesta.MNOZENJE);
            testMnozenja.Testiraj(); 
             
            int spektarTestova = Math.Abs(from - to);
            int brojTestova = 50;
            if (spektarTestova < brojTestova)
            {
                brojTestova = spektarTestova;
            } 
            int donjaGranica = Math.Min(from, to);
            int gornjaGranica = Math.Max(from, to);
            double korak = (Math.Abs(from - to) / (double)brojTestova);


            ChartValues<ObservablePoint> serijskeVrijednosti = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> paralelneVrijednosti = new ChartValues<ObservablePoint>();
            for (int k = 0; k < brojTestova; k++)
               { 
                int xPosition = (int)Math.Ceiling((double)(donjaGranica + k * korak));
                serijskeVrijednosti.Add(new ObservablePoint(xPosition, testMnozenja.serijskaVremena[k]));
                paralelneVrijednosti.Add(new ObservablePoint(xPosition, testMnozenja.paralelnaVremena[k]));
            }
            linijaMnozenjaParalelno.Values = paralelneVrijednosti;
            linijaMnozenjaSerijski.Values = serijskeVrijednosti;



            SeriesCollection.Remove(linijaMnozenjaSerijski);
            SeriesCollection.Remove(linijaMnozenjaParalelno);
            SeriesCollection.Add(linijaMnozenjaSerijski);
            SeriesCollection.Add(linijaMnozenjaParalelno);

            chart.Series = SeriesCollection; 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int from = numericDonji.Value ?? 0;
            int to = numericGornji.Value ?? 1;

            Test testInvertovanja = new Test(from, to, Test.TipTesta.INVERTOVANJE);
            testInvertovanja.Testiraj();

            int spektarTestova = Math.Abs(from - to);
            int brojTestova = 50;
            if (spektarTestova < brojTestova)
            {
                brojTestova = spektarTestova;
            }
            int donjaGranica = Math.Min(from, to);
            int gornjaGranica = Math.Max(from, to);
            double korak = (Math.Abs(from - to) / (double)brojTestova);

            ChartValues<ObservablePoint> serijskeVrijednosti = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> paralelneVrijednosti = new ChartValues<ObservablePoint>();
            for (int k = 0; k < brojTestova; k++)
            {
                // Labels[k] = Math.Ceiling((double)(donjaGranica + k * korak)).ToString();
                int xPosition = (int)Math.Ceiling((double)(donjaGranica + k * korak));
                serijskeVrijednosti.Add(new ObservablePoint(xPosition, testInvertovanja.serijskaVremena[k]));
                paralelneVrijednosti.Add(new ObservablePoint(xPosition, testInvertovanja.paralelnaVremena[k]));
            }
            linijaInvertovanjaParalelno.Values = paralelneVrijednosti;
            linijaInvertovanjaSerijski.Values = serijskeVrijednosti;


            SeriesCollection.Remove(linijaInvertovanjaSerijski);
            SeriesCollection.Remove(linijaInvertovanjaParalelno);

            SeriesCollection.Add(linijaInvertovanjaSerijski);
            SeriesCollection.Add(linijaInvertovanjaParalelno);

            chart.Series = SeriesCollection;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int from = numericDonji.Value ?? 0;
            int to = numericGornji.Value ?? 1; 

            Test testSabiranja = new Test(from, to, Test.TipTesta.SABIRANJE);
            testSabiranja.Testiraj();

            int spektarTestova = Math.Abs(from - to);
            int brojTestova = 50;
            if (spektarTestova < brojTestova)
            {
                brojTestova = spektarTestova;
            }
            int donjaGranica = Math.Min(from, to);
            int gornjaGranica = Math.Max(from, to);
            double korak = (Math.Abs(from - to) / (double)brojTestova);

            ChartValues<ObservablePoint> serijskeVrijednosti = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> paralelneVrijednosti = new ChartValues<ObservablePoint>();
            for (int k = 0; k < brojTestova; k++)
            {
                // Labels[k] = Math.Ceiling((double)(donjaGranica + k * korak)).ToString();
                int xPosition = (int)Math.Ceiling((double)(donjaGranica + k * korak));
                serijskeVrijednosti.Add(new ObservablePoint(xPosition, testSabiranja.serijskaVremena[k]));
                paralelneVrijednosti.Add(new ObservablePoint(xPosition, testSabiranja.paralelnaVremena[k]));
            }
            linijaSabiranjeParalelno.Values = paralelneVrijednosti;
            linijaSabiranjeSerijski.Values = serijskeVrijednosti;


            SeriesCollection.Remove(linijaSabiranjeSerijski);
            SeriesCollection.Remove(linijaSabiranjeParalelno);
            SeriesCollection.Add(linijaSabiranjeSerijski);
            SeriesCollection.Add(linijaSabiranjeParalelno);
            chart.Series = SeriesCollection; 
        }
        

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SeriesCollection.Remove(linijaInvertovanjaSerijski);
            SeriesCollection.Remove(linijaInvertovanjaParalelno);

            SeriesCollection.Remove(linijaSabiranjeSerijski);
            SeriesCollection.Remove(linijaSabiranjeParalelno);
            SeriesCollection.Remove(linijaMnozenjaSerijski);
            SeriesCollection.Remove(linijaMnozenjaParalelno);
        }
    }
}
