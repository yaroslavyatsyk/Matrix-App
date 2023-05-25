using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class MatrixCalculatorClass
    {
        private double[,] matrix;
        private int rows, columns;

        public MatrixCalculatorClass(int n, int m)
        {
            this.rows = n;
            this.columns = m;

            matrix = new double[rows, columns];
        }

        public int Rows
        {
            get { return rows; }
        }

        public int Columns
        {
            get { return columns; }
        }

        public void FullMatrixWithValues()
        {
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = Math.Round(random.NextDouble() * (101 - 1) + 1,2);
                }
            }
        }
        public double[,] GetMatrix()
        {
            return matrix;
        }
        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public static MatrixCalculatorClass operator +(MatrixCalculatorClass a, MatrixCalculatorClass b)
        {
           MatrixCalculatorClass c = new MatrixCalculatorClass(a.rows, a.columns);

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = Math.Round(a[i, j] + b[i, j],2);
                }
            }

            return c;

        }
        public static MatrixCalculatorClass operator -(MatrixCalculatorClass a, MatrixCalculatorClass b)
        {
            MatrixCalculatorClass c = new MatrixCalculatorClass(a.rows, a.columns);

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = Math.Round(a[i, j] - b[i, j], 2);
                }
            }

            return c;

        }

        public static MatrixCalculatorClass operator *(MatrixCalculatorClass a, MatrixCalculatorClass b)
        {
            MatrixCalculatorClass c = new MatrixCalculatorClass(a.rows, b.columns);
            int l = a.rows;

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    double res = 0d;
                    for (int x = 0; x < l; x++)
                    {
                        res += (a[i, x] * b[x, j]);
                    }

                    c[i, j] = Math.Round(res,2);
                   
                }
            }

            return c;
        }
        public static MatrixCalculatorClass TransposeMatrix(MatrixCalculatorClass a)
        {

            MatrixCalculatorClass c = new MatrixCalculatorClass(a.columns, a.rows);
            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[j, i];
                }
            }
            return c;

        }

        public static MatrixCalculatorClass ScalarMultiply(MatrixCalculatorClass a, int k)
        {
            MatrixCalculatorClass c = new MatrixCalculatorClass(a.rows, a.columns);
            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[i, j] * k;
                }
            }
            return c;
        }

        public static double Determinant(MatrixCalculatorClass a)
        {
            double det = 0;
            if (a.rows == 1)
            {
                det = a[0, 0];
            }
            else if (a.rows == 2)
            {
                det = a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0];
            }
            else
            {
                for (int i = 0; i < a.rows; i++)
                {
                    MatrixCalculatorClass temp = new MatrixCalculatorClass(a.rows - 1, a.columns - 1);
                    for (int j = 1; j < a.rows; j++)
                    {
                        for (int k = 0; k < a.rows; k++)
                        {
                            if (k < i)
                            {
                                temp[j - 1, k] = a[j, k];
                            }
                            else if (k > i)
                            {
                                temp[j - 1, k - 1] = a[j, k];
                            }
                        }
                    }
                    det += a[0, i] * (int)Math.Pow(-1, i) * Determinant(temp);
                }
            }
            return Math.Round(det,2);
        }

        public bool IsIdentityMatrix()
        {
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if(i == j && matrix[i, j] == 1)
                    {

                        return true;
                    }

                }
                   
            }
            return false;
        }



    }
}
