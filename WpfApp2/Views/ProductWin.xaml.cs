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
using WpfApp2.DB;

namespace WpfApp2.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductWin.xaml
    /// </summary>
    public partial class ProductWin : Window
    {
        TradeEntities tradeEntities = new TradeEntities();
        public int IdUser { get; set; }
        public ProductWin(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
            ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
            if (idUser == 0)
            {
                UserFio.Text = "Гость";
            }
            else
            {
                UserFio.Text = tradeEntities.Users.Where(p => p.UserID == idUser).Select(p => p.UserFullName).Single();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox sortComboBox = sender as ComboBox;
            ComboBoxItem selectedItem = sortComboBox.SelectedItem as ComboBoxItem;
            var k = sortComboBox.SelectedIndex.ToString();
            switch (k)
            {
                case "0":
                    ProductDataGrid.ItemsSource = tradeEntities.Products.OrderByDescending(p => p.ProductCost).ToList();
                    break;
                case "1":
                    ProductDataGrid.ItemsSource = tradeEntities.Products.OrderBy(p => p.ProductCost).ToList();
                    break;
                case "2":
                    ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
                    break;
            }
        }

        private void ComboBoxSortProvider_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ComboBox sortComboBox = sender as ComboBox;
            ComboBoxItem selectedItem = sortComboBox.SelectedItem as ComboBoxItem;
            var k = sortComboBox.SelectedIndex.ToString();
            switch (k)
            {
                case "0":
                    ProductDataGrid.ItemsSource = tradeEntities.Products.Where(p => p.Manufacturers.ManufacturerName == selectedItem.Content).ToList();
                    break;
                case "1":
                    ProductDataGrid.ItemsSource = tradeEntities.Products.Where(p => p.Manufacturers.ManufacturerName == selectedItem.Content).ToList();
                    break;
                case "2":
                    ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
                    break;
            }
        }

		private void Basket_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                OrderWin orderWin = new OrderWin(IdUser);
                orderWin.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Необходим вход в аккаунт");
            }
		}
	}
}


