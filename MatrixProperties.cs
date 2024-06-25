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

    }
}
