using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    class Test
    {
        public enum TipTesta { MNOZENJE, SABIRANJE, INVERTOVANJE };
        public TipTesta Tip { get; internal set; }
        public long[] paralelnaVremena { get; internal set;  }
        public long[] serijskaVremena { get; internal set; }
        private int from, to;
        int spektarTestiranja;
        int brojTestiranja = 50;

        MnozacMatrica serijskiMnozac = new SerijskiMnozac();
        MnozacMatrica paralelniMnozac = new ParalelniMnozac();

        SabiracMatrica serijskiSabirac = new SerijskiSabirac();
        SabiracMatrica paralelniSabirac = new ParalelniSabirac();

        InvertorMatrica serijskiInvertor = new SerijskiInvertor();
        InvertorMatrica paralelniInvertor = new ParalelniInvertor();
        public Test(int from, int to, TipTesta tipTesta)
        {
            spektarTestiranja =  Math.Abs(to - from) ;
            if (spektarTestiranja < brojTestiranja)
            {
                brojTestiranja = spektarTestiranja;
            }

            paralelnaVremena = new long[brojTestiranja];
            serijskaVremena = new long[brojTestiranja];
            this.from = from;
            this.to = to;
            this.Tip = tipTesta;
        }

        public void Testiraj()
        {
            int donjaGranica = Math.Min(from, to);
            int gornjaGranica = Math.Max(from, to);
            double korak = (gornjaGranica - donjaGranica) / (double)brojTestiranja;

            for (int k = 0;k < brojTestiranja ;k++ )
            {
                Matrix A, B;
                int size = (int)Math.Ceiling((double)(donjaGranica + k*korak));
                A = new Matrix(size, size);
                B = new Matrix(size, size);

                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        A[i, j] = random.Next(0, 100);
                        B[i, j] = random.Next(0, 100);
                    }
                }

                switch (Tip)
                {
                    case TipTesta.MNOZENJE:
                        serijskiMnozac.Pomnozi(A, B);
                        serijskaVremena[k] = serijskiMnozac.Time;

                        paralelniMnozac.Pomnozi(A, B);
                        paralelnaVremena[k] = paralelniMnozac.Time;
                        break;
                    case TipTesta.SABIRANJE:
                        serijskiSabirac.Saberi(A, B);
                        serijskaVremena[k] = serijskiSabirac.Time;

                        paralelniSabirac.Saberi(A, B);
                        paralelnaVremena[k] = paralelniSabirac.Time;
                        break;
                    case TipTesta.INVERTOVANJE:
                        serijskiInvertor.Invertuj(A );
                        serijskaVremena[k] = serijskiInvertor.Time;

                        paralelniInvertor.Invertuj(A );
                        paralelnaVremena[k] = paralelniInvertor.Time;
                        break;
                }
                 
            }
           
        }
    }
}
