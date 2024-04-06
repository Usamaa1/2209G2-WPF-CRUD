using System;
using System.Collections.Generic;
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
    /// Interaction logic for OptionForm.xaml
    /// </summary>
    public partial class OptionForm : Window
    {
        public OptionForm()
        {
            InitializeComponent();
        }

        private void opUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateForm updateForm = new UpdateForm();
            updateForm.Show();
            updateForm.uIdLbl.Content =  idLabel.Content.ToString();
            updateForm.uProdName.Text = nameLabel.Content.ToString();
            updateForm.uProdPrice.Text =  priceLabel.Content.ToString();
            updateForm.uBarcode.Text =  barcodeLabel.Content.ToString();

            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteConfirmation deleteConfirmation = new DeleteConfirmation();
            deleteConfirmation.Show();
            deleteConfirmation.deleteId.Content = idLabel.Content;
            Close();
        }
    }
}
