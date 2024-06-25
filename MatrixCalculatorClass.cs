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
        protected int[,] matrix;
        protected int rows, columns;

        public MatrixCalculatorClass(int n, int m)
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

        public void FullMatrixWithValues(int min, int max)
        {
            Random random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(min, max + 1);
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

        public static MatrixCalculatorClass operator +(MatrixCalculatorClass a, MatrixCalculatorClass b)
        {
           MatrixCalculatorClass c = new MatrixCalculatorClass(a.rows, a.columns);

            for (int i = 0; i < c.Rows; i++)
            {
                for (int j = 0; j < c.Columns; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
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
                    c[i, j] = a[i, j] - b[i, j];
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
                    var res = 0;
                    for (int x = 0; x < l; x++)
                    {
                        res += (a[i, x] * b[x, j]);
                    }

                    c[i, j] = res;
                   
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

       



    }
}
