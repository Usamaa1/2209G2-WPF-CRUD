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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _220G2_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Connectivity
        {
            public static SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pos;Integrated Security=True;Connect Timeout=30;");
        }


        private void prodName_GotFocus(object sender, RoutedEventArgs e)
        {
            if(prodName.Text == "Enter Product Name")
            {
                prodName.Text = "";
                prodName.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void prodName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prodName.Text == "")
            {
                prodName.Text = "Enter Product Name";
                prodName.Foreground = new SolidColorBrush(Color.FromRgb(127, 140, 141));
            }
        }

        private void prodPrice_GotFocus(object sender, RoutedEventArgs e)
        {
            if (prodPrice.Text == "Enter Price")
            {
                prodPrice.Text = "";
                prodPrice.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void prodPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prodPrice.Text == "")
            {
                prodPrice.Text = "Enter Price";
                prodPrice.Foreground = new SolidColorBrush(Color.FromRgb(127, 140, 141));
            }

        }

        private void prodBarcode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (prodBarcode.Text == "Enter Barcode")
            {
                prodBarcode.Text = "";
                prodBarcode.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }

        }

        private void prodBarcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (prodBarcode.Text == "")
            {
                prodBarcode.Text = "Enter Barcode";
                prodBarcode.Foreground = new SolidColorBrush(Color.FromRgb(127, 140, 141));
            }
        }
/*
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Product Name: {prodName.Text}\n Product Price: {prodPrice.Text}\n Product Barcode: {prodBarcode.Text}");
        }*/

        private void addBtn_Click_1(object sender, RoutedEventArgs e)
        {
           
            Connectivity.connect.Open();
            SqlCommand insertQuery = new SqlCommand("INSERT INTO pos VALUES (@prodName, @prodPrice, @prodBarcode)", Connectivity.connect);

            insertQuery.Parameters.AddWithValue("@prodName", prodName.Text);
            insertQuery.Parameters.AddWithValue("@prodPrice", prodPrice.Text);
            insertQuery.Parameters.AddWithValue("@prodBarcode",prodBarcode.Text);

            int row = insertQuery.ExecuteNonQuery();

            if(row > 0)
            {
                MessageBox.Show("Your Data Inserted Successfully");
            }
            else
            {
                MessageBox.Show("Data Insertion Failed");
            }    


            Connectivity.connect.Close();

        }

        private void viewData_Click(object sender, RoutedEventArgs e)
        {

            DataForm dataForm = new DataForm();
            dataForm.Show();

            SqlCommand viewQuery = new SqlCommand("SELECT * FROM pos",Connectivity.connect);
            SqlDataAdapter dt = new SqlDataAdapter(viewQuery);
            DataTable dataTable = new DataTable();
            dt.Fill(dataTable);

            dataForm.dG.ItemsSource = dataTable.DefaultView;

            Close();


            




        }
    }
}
