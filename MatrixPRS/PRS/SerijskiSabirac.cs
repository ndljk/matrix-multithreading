using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    class SerijskiSabirac : SabiracMatrica
    {
        public override Matrix Saberi(Matrix A, Matrix B)
        {
            int rA = A.BrRedova;
            int cA = A.BrKolona;
            int rB = B.BrRedova;
            int cB = B.BrKolona;

            Matrix result = new Matrix(rA, cB);

            if (cA != cB || rA != rB)
            {
                return null;
            }
            else
            {
                stopwatch.Restart();

                for (int i = 0; i < rA; i++)
                { 
                    for (int j = 0; j < cA; j++)
                    {
                        result[i, j] = A[i, j] + B[i, j];
                    }

                }

                stopwatch.Stop();
                return result;
            }
        }
    }
}
