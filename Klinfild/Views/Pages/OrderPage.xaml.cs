using Klinfild.AppData;
using Klinfild.Model;
using RoyT.TimePicker;
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
        private Product _selectedProduct;
        private DateTime _selectedDate;
        private TimePickerSlider _selectedTime;
        public OrderPage(Product selectedProduct, DateTime selectedDate, TimePickerSlider selectedTime)
        {
            InitializeComponent();
            CategoryCmb.ItemsSource = _context.Category.ToList();
            CategoryCmb.DisplayMemberPath = "Name";
            ProductCmb.DisplayMemberPath = "Name";
            ProductCmb.ItemsSource = _context.Product.ToList();
            _selectedProduct = selectedProduct;
            _selectedDate = selectedDate;
            _selectedTime = selectedTime;
            ProductCmb.SelectedItem = _selectedProduct;
            AmountTbl.Text = _selectedProduct.Price.ToString();
        }

        private void CategoryCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductCmb.ItemsSource = _context.Product
                .Where(p => p.CategoryId == ((Category)CategoryCmb.SelectedItem).Id)
                .ToList();      
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                if (_selectedProduct == null)
                {
                    MessageBox.Show("Продукт не выбран.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Можно добавить проверку на корректность времени, если требуется
                DateTime dateTime = _selectedDate.Date.AddHours(_selectedTime.Time.Hour).AddMinutes(_selectedTime.Time.Minute);
                var newOrder = new Order
                {
                    // Объединяем выбранную дату и время
                    DateTime = dateTime,
                    UserId = AuthorisationHelper.selectedUser.Id,
                    Amount = 0
                };
                _context.Order.Add(newOrder);
                _context.SaveChanges();

                // Количество можно запросить у пользователя, если нужно
                int quantity = 1; // По умолчанию 1, либо добавить поле для ввода

                var orderProduct = new OrderProduct
                {
                    OrderId = newOrder.Id,
                    ProductId = _selectedProduct.Id,
                    Quantity = quantity
                };
                _context.OrderProduct.Add(orderProduct);

                newOrder.Amount = (int)_selectedProduct.Price;
                _context.SaveChanges();

                MessageBox.Show("Заказ успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

    }
