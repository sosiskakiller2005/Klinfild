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
    /// Логика взаимодействия для SelectDatePage.xaml
    /// </summary>
    public partial class SelectDatePage : Page
    {
        Product _selectedProduct;
        public SelectDatePage(Product selectedProduct)
        {
            InitializeComponent();
            _selectedProduct = selectedProduct;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AppCalendar.SelectedDate.HasValue)
            {
                MessageBoxHelper.Information("Дата и время успешно выбранны!");
                FrameHelper.selectedFrame.Navigate(new OrderPage(_selectedProduct, AppCalendar.SelectedDate.Value, OrderTp));
            }
            else
            {
                MessageBox.Show("Выберите дату.");
            }
        }
    }
}
