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

namespace _220G2_wpf
{
    /// <summary>
    /// Interaction logic for DeleteConfirmation.xaml
    /// </summary>
    public partial class DeleteConfirmation : Window
    {
        public DeleteConfirmation()
        {
            InitializeComponent();
        }

        public class Connectivity
        {
            public static SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pos;Integrated Security=True;Connect Timeout=30;");
        }
        private void yes_Click(object sender, RoutedEventArgs e)
        {
            Connectivity.connect.Open();
            SqlCommand deleteQuery = new SqlCommand("DELETE from pos WHERE ID = @id", Connectivity.connect);
            deleteQuery.Parameters.AddWithValue("@id", deleteId.Content);
            int row = deleteQuery.ExecuteNonQuery();
            
            if(row > 0)
            {
                MessageBox.Show("Item Deleted Successfully");


                DataForm dataForm = new DataForm();
                dataForm.Show();

                SqlCommand viewQuery = new SqlCommand("SELECT * FROM pos", Connectivity.connect);
                SqlDataAdapter dt = new SqlDataAdapter(viewQuery);
                DataTable dataTable = new DataTable();
                dt.Fill(dataTable);

                dataForm.dG.ItemsSource = dataTable.DefaultView;


            }
            else
            {
                MessageBox.Show("Item Deletion Failed");
            }
            Connectivity.connect.Close(); 

    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
