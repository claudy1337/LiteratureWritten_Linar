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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LiteratureWritten.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditionsPage.xaml
    /// </summary>
    public partial class AddEditionsPage : Page
    {
        public static Classes.User User;
        public AddEditionsPage(Classes.User user)
        {
            User = user;
            InitializeComponent();
            Model.SubscribedEditions SearchEditions = Model.BDConnection.bd.SubscribedEditions.FirstOrDefault(e=>e.UserID == User.Id);
            ListEdition.ItemsSource = Model.BDConnection.bd.Editions.Where(u=> u.Status == true && u.ID != SearchEditions.Editions.ID).ToList();
            CBDeliveryMethod.ItemsSource = Model.BDConnection.bd.DeliveryMethod.ToList();
            CBTerm.ItemsSource = Model.BDConnection.bd.SubscriptionTerm.ToList();
        }

        private void ListEdition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = ListEdition.SelectedItem as Model.Editions;
            txtName.Text = select.Name;
            txtType.Text = select.EditionType1.Name;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CBDeliveryMethod.Text) && string.IsNullOrWhiteSpace(CBTerm.Text))
                {
                    return;
                }
                else
                {
                    var selectEdition = ListEdition.SelectedItem as Model.Editions;
                    var selectDelivery = CBDeliveryMethod.SelectedItem as Model.DeliveryMethod;
                    var selectTerm = CBTerm.SelectedItem as Model.SubscriptionTerm;
                    
                    Model.SubscribedEditions subscribed = new Model.SubscribedEditions
                    {
                        Date = DateTime.Now,
                        Edition = selectEdition.ID,
                        SubscriptionTerm = selectTerm.ID,
                        DeliveryMethod = selectDelivery.ID,
                        UserID = User.Id,
                    };
                    Model.BDConnection.bd.SubscribedEditions.Add(subscribed);
                    Model.BDConnection.bd.SaveChanges();
                    MessageBox.Show("add");
                }
                
            }
            catch(Exception)
            {
                return;
            }
            
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Pages.SubscribedPage(User));
        }
    }
}
