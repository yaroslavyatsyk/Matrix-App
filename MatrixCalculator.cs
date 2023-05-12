using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Calculator
{
    public class MatrixCalculator
    {
        private int[,] matrix;
        private int rows, columns;

        public MatrixCalculator(int n, int m)
        {
            this.rows = n;
            this.columns = m;

            matrix = new int[rows, columns];
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
                    matrix[i, j] = random.Next(1, 1001);
                }
            }
        }
        public int[,] GetMatrix()
        {
            return matrix;
        }
        public int this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

        public static MatrixCalculator operator +(MatrixCalculator a, MatrixCalculator b)
        {
           MatrixCalculator c = new MatrixCalculator(a.rows, a.columns);

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }

            return c;

        }
        public static MatrixCalculator operator -(MatrixCalculator a, MatrixCalculator b)
        {
            MatrixCalculator c = new MatrixCalculator(a.rows, a.columns);

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }

            return c;

        }

        public static MatrixCalculator operator *(MatrixCalculator a, MatrixCalculator b)
        {
            MatrixCalculator c = new MatrixCalculator(a.rows, b.columns);
            int l = a.rows;

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    int res = 0;
                    for (int x = 0; x < l; x++)
                    {
                        res += a[i, x] * b[x, j];
                    }

                    c[i, j] = res;
                   
                }
            }

            return c;
        }
        public static MatrixCalculator TransposeMatrix(MatrixCalculator a)
        {

            MatrixCalculator c = new MatrixCalculator(a.columns, a.rows);
            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[j, i];
                }
            }
            return c;

        }

        public static MatrixCalculator ScalarMultiply(MatrixCalculator a, int k)
        {
            MatrixCalculator c = new MatrixCalculator(a.rows, a.columns);
            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[i, j] * k;
                }
            }
            return c;
        }

        public static long Determinant(MatrixCalculator a)
        {
            long det = 0;
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
                    MatrixCalculator temp = new MatrixCalculator(a.rows - 1, a.columns - 1);
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
            return det;
        }

    }
}
