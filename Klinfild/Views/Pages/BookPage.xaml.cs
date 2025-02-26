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
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        private KlinfildDbEntities _context = App.GetContext();
        public BookPage()
        {
            InitializeComponent();
            List<Product> products = _context.Product.ToList();
            ShopLb.ItemsSource = _context.Product.Where(p => p.CategoryId == 2).ToList();
        }

        private void DressesHl_Click(object sender, RoutedEventArgs e)
        {
        }

        private void JewerlyHl_Click(object sender, RoutedEventArgs e)
        {
            ShopLb.ItemsSource = _context.Product.Where(p => p.CategoryId == 2).ToList();
        }

        private void HotelsHl_Click(object sender, RoutedEventArgs e)
        {
            ShopLb.ItemsSource = _context.Product.Where(p => p.CategoryId == 3).ToList();
        }

        private void DateHl_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
