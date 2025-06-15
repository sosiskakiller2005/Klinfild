using Klinfild.AppData;
using Klinfild.Model;
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

namespace Klinfild.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private KlinfildDbEntities _context = App.GetContext();
        public ProfilePage()
        {
            InitializeComponent();
            ProfileGrid.DataContext = AuthorisationHelper.selectedUser;
            PasswordTb.Password = AuthorisationHelper.selectedUser.Password;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.selectedFrame.Navigate(new StartPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(LastNameTb.Text) && !string.IsNullOrEmpty(NameTb.Text) && !string.IsNullOrEmpty(SurnameTb.Text) && !string.IsNullOrEmpty(LoginTb.Text) && !string.IsNullOrEmpty(PasswordTb.Password))
            {
                AuthorisationHelper.selectedUser.Lastname = LastNameTb.Text;
                AuthorisationHelper.selectedUser.Name = NameTb.Text;
                AuthorisationHelper.selectedUser.Surname = SurnameTb.Text;
                AuthorisationHelper.selectedUser.Login = LoginTb.Text;
                AuthorisationHelper.selectedUser.Password = PasswordTb.Password;
                _context.SaveChanges();
                MessageBoxHelper.Information("Данные успешно изменены.");
            }
        }
    }
}
