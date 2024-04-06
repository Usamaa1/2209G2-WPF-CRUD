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

namespace _220G2_wpf
{
    /// <summary>
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class DataForm : Window
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void dG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowView = dG.SelectedValue as DataRowView;





            OptionForm optionForm = new OptionForm();
            optionForm.Show();
            optionForm.idLabel.Content = rowView["id"];
            optionForm.nameLabel.Content = rowView["prodName"];
            optionForm.priceLabel.Content = rowView["prodPrice"];
            optionForm.barcodeLabel.Content = rowView["prodBarcode"];

            Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
