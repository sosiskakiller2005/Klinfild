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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        private KlinfildDbEntities _context = App.GetContext();
        public OrderPage()
        {
            InitializeComponent();
            CategoryCmb.ItemsSource = _context.Category.ToList();
            CategoryCmb.DisplayMemberPath = "Name";
            ProductCmb.DisplayMemberPath = "Name";
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductCmb.ItemsSource = _context.Product
                .Where(p => p.CategoryId == ((Category)CategoryCmb.SelectedItem).Id)
                .ToList();      
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductCmb.SelectedItem == null || string.IsNullOrWhiteSpace(QuantityTb.Text))
                {
                    MessageBox.Show("Выберите продукт и укажите количество.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!int.TryParse(QuantityTb.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("Количество должно быть положительным числом.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var newOrder = new Order
                {
                    DateTime = DateTime.Now,
                    UserId = AuthorisationHelper.selectedUser.Id,  
                    Amount = 0 
                };
                _context.Order.Add(newOrder);
                _context.SaveChanges();

                var selectedProduct = (Product)ProductCmb.SelectedItem;
                var orderProduct = new OrderProduct
                {
                    OrderId = newOrder.Id,
                    ProductId = selectedProduct.Id,
                    Quantity = quantity
                };
                _context.OrderProduct.Add(orderProduct);

                newOrder.Amount = (int)(_context.OrderProduct
                    .Where(op => op.OrderId == newOrder.Id)
                    .Sum(op => op.Quantity * op.Product.Price));
                _context.SaveChanges();

                MessageBox.Show("Заказ успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
