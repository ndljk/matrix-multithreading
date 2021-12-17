using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    class SerijskiMnozac: MnozacMatrica
    {
        public override Matrix Pomnozi(Matrix A, Matrix B)
        {
            int rA = A.BrRedova;
            int cA = A.BrKolona;
            int rB = B.BrRedova;
            int cB = B.BrKolona;
            double temp = 0;
            Matrix kHasil = new Matrix(rA, cB);

            if (cA != rB)
            { 
                return null;
            }
            else
            {
                stopwatch.Restart();
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    }
                }
                stopwatch.Stop();
                return kHasil;
            }
        }

         
    }
}
