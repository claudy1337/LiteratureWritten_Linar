using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace LiteratureWritten.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewEditionPage.xaml
    /// </summary>
    public partial class NewEditionPage : Page
    {
        public NewEditionPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void price(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnWindraw_Click(object sender, RoutedEventArgs e)
        {
            var select = ListEdition.SelectedItem as Model.Editions;
            select.Status = true;
            Model.BDConnection.bd.SaveChanges();
            MessageBox.Show("active");
            Refresh();
        }

        private void ListEdition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void Refresh()
        {
            ListEdition.ItemsSource = Model.BDConnection.bd.Editions.Where(s => s.Status == false).ToList();
        }

        private void BtnAddEdition_Click(object sender, RoutedEventArgs e)
        {
            Model.Editions editions = new Model.Editions();
        }
    }
}
