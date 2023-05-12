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
using Matrix_Calculator;

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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rows2 = int.Parse(Rows2.Text);
                columns2 = int.Parse(Columns2.Text);
                matrixCalculator2 = new MatrixCalculatorClass(rows2, columns2);
                matrixCalculator2.FullMatrixWithValues();
                int[,] m = matrixCalculator2.GetMatrix();

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
                MessageBox.Show(ex.Message);
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
                        MessageBox.Show("The matrices must have the same number of rows and columns");
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
                        MessageBox.Show("The matrices must have the same number of rows and columns");
                    }
                   
                }

                else if (operation.Equals("*") && operation != null)
                {
                    if(matrixCalculator1.Columns == matrixCalculator2.Rows)
                    {
                        matrixCalculator3 = matrixCalculator1 * matrixCalculator2;
                        ResultWindow resultWindow = new ResultWindow(matrixCalculator3);
                        resultWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("The number of columns of the first matrix must be equal to the number of rows of the second matrix");
                    }
                    
                }
            }
                        catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                matrixCalculator1 = new MatrixCalculatorClass(rows1, columns1);
                matrixCalculator1.FullMatrixWithValues();

                int[,] m = matrixCalculator1.GetMatrix();

               
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
