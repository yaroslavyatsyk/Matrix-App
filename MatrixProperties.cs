using MatrixCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace Matrix_App
{
    public class MatrixProperties : MatrixCalculatorClass
    {
        


        public MatrixProperties(int n, int m) : base(n, m)
        {
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



        public MatrixProperties GetTransposition()
        {
            MatrixProperties transposedMatrix = new MatrixProperties(columns, rows);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }
            return transposedMatrix;
        }
       

        public bool IsIdentityMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j && matrix[i, j] == 1)
                    {

                        return true;
                    }

                }

            }
            return false;
        }

        public bool IsSymmetricMatrix()
        {
            if (rows != columns)
            {
                return false;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int Determinant()
        {
            if (rows != columns)
            {
                throw new Exception("The matrix is not square");
            }
            if (rows == 1)
            {
                return matrix[0, 0];
            }
            if (rows == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            int det = 0;
            for (int i = 0; i < rows; i++)
            {
                det += (int)Math.Pow(-1, i) * matrix[0, i] * GetMinor(0, i).Determinant();
            }
            return det;
        }

        private MatrixProperties GetMinor(int v, int i)
        {
            
            MatrixProperties minor = new MatrixProperties(rows - 1, columns - 1);
            for (int j = 0; j < rows; j++)
            {
                for (int k = 0; k < columns; k++)
                {
                    if (j < v && k < i)
                    {
                        minor[j, k] = matrix[j, k];
                    }
                    if (j < v && k > i)
                    {
                        minor[j, k - 1] = matrix[j, k];
                    }
                    if (j > v && k < i)
                    {
                        minor[j - 1, k] = matrix[j, k];
                    }
                    if (j > v && k > i)
                    {
                        minor[j - 1, k - 1] = matrix[j, k];
                    }
                }
            }
            return minor;
        }
    }
}
