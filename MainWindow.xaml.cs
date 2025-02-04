﻿using Matrix_App;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MatrixCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MatrixCalculatorClass matrixCalculator1;
        private MatrixCalculatorClass matrixCalculator2;

        private MatrixCalculatorClass matrixCalculator3;

        int rows1, columns1;
        int rows2, columns2;
        int lowerLimit1, upperLimit1;
        int lowerLimit2, upperLimit2;
        int rows3, columns3;
        int lowerLimit3, upperLimit3;

        MatrixProperties matrixProperties;

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rows3 = int.Parse(RowBox.Text);
                columns3 = int.Parse(ColumnBox.Text);
                lowerLimit3 = int.Parse(Lower.Text);
                upperLimit3 = int.Parse(Upper.Text);

                matrixProperties = new MatrixProperties(rows3, columns3);

                matrixProperties.FullMatrixWithValues(lowerLimit3, upperLimit3);

                var m = matrixProperties.GetMatrix();

                DataTable dataTable = new DataTable();

                for (int c = 0; c < m.GetLength(1); c++)
                {
                    dataTable.Columns.Add(new DataColumn("", typeof(int)));
                }

                

                for (int r = 0; r < m.GetLength(0); r++)
                {
                    DataRow dataRow = dataTable.Rows.Add();
                    for (int c = 0; c < m.GetLength(1); c++)
                    {
                        dataRow[c] = m[r, c];
                    }
                }

                dataGrid.ItemsSource = dataTable.DefaultView;

                var transposedMatrix = matrixProperties.GetTransposition();

                var transposedMatrixValues = transposedMatrix.GetMatrix();

                DataTable dataTable2 = new DataTable();

                for(int c = 0; c < transposedMatrixValues.GetLength(0); c++)
                {
                    dataTable2.Columns.Add(new DataColumn("", typeof(int)));
                }

                for(int r = 0; r < transposedMatrixValues.GetLength(0); r++)
                {
                    DataRow dataRow = dataTable2.Rows.Add();

                    for(int c = 0; c < transposedMatrixValues.GetLength(1); c++)
                    {
                        dataRow[c] = transposedMatrixValues[r, c];
                    }
                }

                transGrid.ItemsSource = dataTable2.DefaultView;

                determinant.Text = matrixProperties.Determinant().ToString();

                symmetric.Text = matrixProperties.IsSymmetricMatrix().ToString();

                identity.Text = matrixProperties.IsIdentityMatrix().ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rows2 = int.Parse(Rows2.Text);
                columns2 = int.Parse(Columns2.Text);
                lowerLimit2 = int.Parse(LowerLimit2.Text);
                upperLimit2 = int.Parse(UpperLimit2.Text);
                matrixCalculator2 = new MatrixCalculatorClass(rows2, columns2);
                matrixCalculator2.FullMatrixWithValues(lowerLimit2,upperLimit2);
                var m = matrixCalculator2.GetMatrix();

                DataTable dataTable = new DataTable();


                for (int c = 0; c < m.GetLength(1); c++)
                {
                    dataTable.Columns.Add(new DataColumn("", typeof(int)));
                }


                for (int r = 0; r < m.GetLength(0); r++)
                {
                    DataRow dataRow = dataTable.Rows.Add();
                    for (int c = 0; c < m.GetLength(1); c++)
                    {
                        dataRow[c] = m[r, c];
                    }
                }

                matrix2.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Incorrect input(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ComboBoxItem comboBoxItem2 =  (ComboBoxItem)comboBox.SelectedItem;
                string operation = comboBoxItem2.Content.ToString();

                if (operation.Equals("+") && operation != null)
                {
                    if (matrixCalculator1.Rows == matrixCalculator1.Rows && matrixCalculator1.Columns == matrixCalculator2.Columns)
                    {
                        matrixCalculator3 = matrixCalculator1 + matrixCalculator2;

                        ResultWindow resultWindow = new ResultWindow(matrixCalculator3);
                        resultWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("The matrices must have the same number of rows and columns", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }

                else if (operation.Equals("-") && operation != null)
                {
                    if(matrixCalculator1.Rows == matrixCalculator1.Rows && matrixCalculator1.Columns == matrixCalculator2.Columns)
                    {
                        matrixCalculator3 = matrixCalculator1 - matrixCalculator2;
                        ResultWindow resultWindow = new ResultWindow(matrixCalculator3);
                        resultWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("The matrices must have the same number of rows and columns","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                   
                }

                else if (operation.Equals("x") && operation != null)
                {
                    if(matrixCalculator1.Columns == matrixCalculator2.Rows)
                    {
                        matrixCalculator3 = matrixCalculator1 * matrixCalculator2;
                        ResultWindow resultWindow = new ResultWindow(matrixCalculator3);
                        resultWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("The number of columns of the first matrix must be equal to the number of rows of the second matrix","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                    
                }
            }
                        catch (Exception ex)
            {
                MessageBox.Show("An error has occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rows1 = int.Parse(Rows1.Text);
                columns1 = int.Parse(Columns1.Text);
                lowerLimit1 = int.Parse(LowerLimit1.Text);
                upperLimit1 = int.Parse(UpperLimit1.Text);
                matrixCalculator1 = new MatrixCalculatorClass(rows1, columns1);
                matrixCalculator1.FullMatrixWithValues(lowerLimit1,upperLimit1);

                var m = matrixCalculator1.GetMatrix();

               
                DataTable dataTable = new DataTable();

                for (int c = 0; c < m.GetLength(1); c++)
                {
                    dataTable.Columns.Add(new DataColumn("",typeof(int)));
                }


                for (int r = 0; r < m.GetLength(0); r++)
                {
                    DataRow dataRow = dataTable.Rows.Add();
                    for (int c = 0; c < m.GetLength(1); c++)
                    {
                        dataRow[c] = m[r, c];
                    }
                }

                matrix1.ItemsSource = dataTable.DefaultView;



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Incorrect input(s)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
