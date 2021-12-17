using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatrixPRS.PRS
{
    class ParalelniInvertor : InvertorMatrica
    { 
        public override Matrix Invertuj(Matrix m)
        {
            int MaxOrder = m.BrKolona;
            Matrix b = new Matrix(m.BrRedova, m.BrKolona);

            stopwatch.Restart();
            double det = CalcDet(m);
            Parallel.For(0, MaxOrder, (x) =>
           {
               Parallel.For(0, MaxOrder, (y) =>
               {
                   Matrix mm = new Matrix(MaxOrder - 1, MaxOrder - 1); 
                   Parallel.For(0, MaxOrder - 1, (j) => 
                   {

                       for (int k = 0; k < MaxOrder - 1; k++) 
                        {
                           
                           try
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
                           }catch(Exception e)
                           {
                               MessageBox.Show("");
                           }
                       }
                   });
                   b[x, y] = Math.Pow(-1, x) * Math.Pow(-1, y) * CalcDet(mm) / det;
               }
               ); 

            });
            stopwatch.Stop();
            return b;

        }

        
        static double CalcDet(Matrix input)
        {
            int order = input.BrKolona;
            if (order > 2)
            {
                double value = 0;
                for (int j = 0; j < order; j++)
                {
                    Matrix Temp = CreateSmallerMatrix(input, 0, j);
                    value = value + input[0, j] * (SignOfElement(0, j) * CalcDet(Temp));
                }
                return value;
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
     
        static Matrix CreateSmallerMatrix(Matrix input, int i, int j)
        {
            int order = input.BrKolona;
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
