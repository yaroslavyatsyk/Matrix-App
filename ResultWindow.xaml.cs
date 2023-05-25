
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MatrixCalculator
{
    /// <summary>
    /// Interaction logic for ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : Window
    {

        private MatrixCalculatorClass matrixCalculator1;
        public ResultWindow(MatrixCalculatorClass matrix)
        {
            InitializeComponent();
            matrixCalculator1 = matrix;

            var m = matrixCalculator1.GetMatrix();

            DataTable dataTable = new DataTable();

            

            for (int c = 0; c < m.GetLength(1); c++)
            {
                dataTable.Columns.Add(new DataColumn("", typeof(double)));
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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
