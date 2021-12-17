using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    class ParalelniMnozac :MnozacMatrica
    {
        public override Matrix Pomnozi(Matrix A, Matrix B)
        {
            int rA = A.BrRedova;
            int cA = A.BrKolona;
            int rB = B.BrRedova;
            int cB = B.BrKolona;
           
            Matrix kHasil = new Matrix(rA, cB);

            if (cA != rB)
            {
                return null;
            }
            else
            {
                stopwatch.Restart();
                 
                Parallel.For(0, rA,i =>
                {
                    Parallel.For(0, cB, j =>
                    {
                        double temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    });
                });

                stopwatch.Stop();
                return kHasil;
            }
        }
    }
}
