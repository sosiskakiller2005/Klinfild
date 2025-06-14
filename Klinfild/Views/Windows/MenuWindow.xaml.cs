using Klinfild.AppData;
using Klinfild.Views.Pages;
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
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            FrameHelper.selectedFrame = MainFrm;
            MainFrm.Navigate(new Pages.StartPage());
        }

        private void RequestsHl_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BoksHl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClientsHl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuestsBlocksHl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompilersHl_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProfileHl_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ProfilePage());
        }
    }
}
