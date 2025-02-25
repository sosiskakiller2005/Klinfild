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
using System.Windows.Shapes;

namespace Klinfild.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private KlinfildDbEntities _context = App.GetContext();
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void SignUpHl_Click(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text != string.Empty || PasswordTb.Password != string.Empty || RepeatPasswordTb.Password != string.Empty)
            {
                if (PasswordTb.Password == RepeatPasswordTb.Password)
                {
                    User newUser = new User()
                    {
                        Name = IdTb.Text,
                        Lastname = IdTb.Text,
                        Surname = IdTb.Text,
                        Login = IdTb.Text,
                        Password = PasswordTb.Password
                    };

                    _context.User.Add(newUser);
                    _context.SaveChanges();
                    User lastUser = _context.User.ToList().Last();
                    MessageBoxHelper.Information($"Регистрация прошла успешно. Ваш код сотруднка: {lastUser.Id}.");
                    AuthorisationWIndow authorisationWIndow = new AuthorisationWIndow();
                    authorisationWIndow.Show();
                    Close();
                }
                else
                {
                    MessageBoxHelper.Error("Пароли не совпадают");
                }
            }
            else
            {
                MessageBoxHelper.Error("Заполните все поля");
            }
        }

        private void EntryHl_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWIndow authorisationWIndow = new AuthorisationWIndow();
            authorisationWIndow.Show();
            Close();
        }

        private void IdTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text == "ИМЯ СОТРУДНИКА")
            {
                IdTb.Text = string.Empty;
            }
        }

        private void IdTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text == string.Empty)
            {
                IdTb.Text = "ИМЯ СОТРУДНИКА";
            }
        }

        private void PasswordTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Password == "ПАРОЛЬ")
            {
                PasswordTb.Password = string.Empty;
            }
        }

        private void PasswordTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordTb.Password == string.Empty)
            {
                PasswordTb.Password = "ПАРОЛЬ";
            }
        }

        private void RepeatPasswordTb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordTb.Password == "ЗАПОМНИТЕ ПАРОЛЬ")
            {
                RepeatPasswordTb.Password = string.Empty;
            }
        }

        private void RepeatPasswordTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (RepeatPasswordTb.Password == string.Empty)
            {
                RepeatPasswordTb.Password = "ЗАПОМНИТЕ ПАРОЛЬ";
            }
        }
    }
}
