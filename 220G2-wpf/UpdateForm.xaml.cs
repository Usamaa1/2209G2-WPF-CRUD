using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using static _220G2_wpf.MainWindow;

namespace _220G2_wpf
{
    /// <summary>
    /// Interaction logic for UpdateForm.xaml
    /// </summary>
    public partial class UpdateForm : Window
    {
        public UpdateForm()
        {
            InitializeComponent();
        }
        public class Connectivity
        {
            public static SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pos;Integrated Security=True;Connect Timeout=30;");
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Connectivity.connect.Open();
            SqlCommand updateQuery = new SqlCommand("UPDATE pos SET prodName = @prodName, prodPrice = @prodPrice, prodBarcode = @prodBarcode WHERE id = @id", Connectivity.connect);

            updateQuery.Parameters.AddWithValue("@id", uIdLbl.Content);
            updateQuery.Parameters.AddWithValue("@prodName", uProdName.Text);
            updateQuery.Parameters.AddWithValue("@prodPrice", uProdPrice.Text);
            updateQuery.Parameters.AddWithValue("@prodBarcode", uBarcode.Text);

            int row = updateQuery.ExecuteNonQuery();

            if (row > 0)
            {
                MessageBox.Show("Your Data Updated Successfully");
                DataForm dataForm = new DataForm();
                dataForm.Show();

                SqlCommand viewQuery = new SqlCommand("SELECT * FROM pos", Connectivity.connect);
                SqlDataAdapter dt = new SqlDataAdapter(viewQuery);
                DataTable dataTable = new DataTable();
                dt.Fill(dataTable);

                dataForm.dG.ItemsSource = dataTable.DefaultView;

                Close();
            }
            else
            {
                MessageBox.Show("Data Updation Failed");
            }


            Connectivity.connect.Close();
        }
    }
}
