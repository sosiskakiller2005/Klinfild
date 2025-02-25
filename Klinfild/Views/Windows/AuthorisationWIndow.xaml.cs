using Klinfild.AppData;
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

namespace Klinfild.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWIndow.xaml
    /// </summary>
    public partial class AuthorisationWIndow : Window
    {
        public AuthorisationWIndow()
        {
            InitializeComponent();
        }

        private void EntryHl_Click(object sender, RoutedEventArgs e)
        {
            if (AuthorisationHelper.Authorise(IdTb.Text, PasswordTb.Password))
            {
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                Close();
            }
        }

        private void SignUpHl_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            Close();
        }

        private void IdTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text == "КОД СОТРУДНИКА")
            {
                IdTb.Text = string.Empty;
            }
        }

        private void PasswordTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Password == "ПАРОЛЬ")
            {
                PasswordTb.Password = string.Empty;
            }
        }

        private void IdTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text == string.Empty)
            {
                IdTb.Text = "КОД СОТРУДНИКА";
            }
        }

        private void PasswordTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Password == string.Empty)
            {
                PasswordTb.Password = "ПАРОЛЬ";
            }
        }
    }
}
