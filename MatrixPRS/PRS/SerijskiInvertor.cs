using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPRS.PRS
{
    class SerijskiInvertor : InvertorMatrica

    {
        public override Matrix Invertuj(Matrix m)
        {
            int MaxOrder = m.BrKolona;
            Matrix b = new Matrix(m.BrRedova, m.BrKolona);
            int j, k, x, y;
            double signy = 1, signx=1 ;
            stopwatch.Restart();
            double det = CalcDet(m );
            Matrix mm = new Matrix(MaxOrder - 1, MaxOrder - 1); // privremena matrica
            for (x = 0; x < MaxOrder; x++)
            {
                signy = 1.0;
                for (y = 0; y < MaxOrder; y++) // indeks za elemente koji se nalaze u prvom redu
                {
                    for (j = 0; j < MaxOrder - 1; j++) // indeks koji se kreće redom od drugog reda pa do n
                    {
                        for (k = 0; k < MaxOrder - 1; k++) // indeks za kopiranje elemenata iz matrice u submatricu
                        {
                            if (j < y)
                            {
                                if (k < x)
                                    mm[j, k] = m[j, k];
                                else
                                    mm[j, k] = m[j, k + 1];
                            }
                            else
                            {
                                if (k < x)
                                    mm[j, k] = m[j + 1, k];
                                else
                                    mm[j, k] = m[j + 1, k + 1];
                            }
                        }
                    }
                    b[x, y] = signy * signx * CalcDet(mm ) / det;
                    signy = -signy;
                }
                signx = -signx;
            }
            stopwatch.Stop();
            return b;

        }
         
        //metoda za računanje determinante matrice formirana rekurzivno
        static double CalcDet(Matrix input)
        {
            int order = input.BrKolona ;
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    Matrix Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * CalcDet(Temp));
                }
                if (value != 0)
                    return value;
                else
                    return 1;
            }
            else if (order == 2)
            {
                return ((input[0, 0] * input[1, 1]) - (input[1, 0] * input[0, 1]));
            }
            else
            {
                return (input[0, 0]);
            }
        }
        static int SignOfElement(int i, int j)
        {
            if ((i + j) % 2 == 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        //metoda za kreiranje submatrice za odgovarajući element
        static Matrix CreateSmallerMatrix(Matrix input, int i, int j)
        {
            int order =  input.BrKolona;
           Matrix output = new Matrix(order - 1, order - 1);
            int x = 0, y = 0;
            for (int m = 0; m < order; m++, x++)
            {
                if (m != i)
                {
                    y = 0;
                    for (int n = 0; n < order; n++)
                    {
                        if (n != j)
                        {
                            output[x, y] = input[m, n];
                            y++;
                        }
                    }
                }
                else
                {
                    x--;
                }
            }
            return output;
        }
    }
}
