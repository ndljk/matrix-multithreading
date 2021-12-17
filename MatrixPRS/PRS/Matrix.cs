using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    public class Matrix
    {
        public double[][] Podaci { get; internal set;  }
        public int BrRedova { get; internal set; }
        public int BrKolona { get; internal set; }
        public Matrix(int brRedova, int brKolona)
        {
            BrRedova = brRedova;
            BrKolona = brKolona;
            Podaci =  new double[brRedova][];
            for (int i = 0; i < brRedova; ++i)
                Podaci[i] = new double[brKolona];
        }
        public double this[int i, int j]
        {
            get
            {
                return Podaci[i][j];
            }
            set
            {
                Podaci[i][ j] = value;
            }
        }


       
 

    }
}
