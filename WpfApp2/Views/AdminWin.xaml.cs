using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AdminWin.xaml
    /// </summary>
    public partial class AdminWin : Window
    {
        public int IdUser { get; set; }
        TradeEntities tradeEntities = new TradeEntities();
        public AdminWin(int idUser)
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
            IdUser = idUser;
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

		private void Add_Click(object sender, RoutedEventArgs e)
		{
            AddProductWin addProductWin = new AddProductWin(IdUser);
			addProductWin.ShowDialog();
			ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
		}

		private void Edit_Click(object sender, RoutedEventArgs e)
		{
			if (ProductDataGrid.SelectedItem is Products selectedProduct)
			{
				EditProductWin editProductWin = new EditProductWin(selectedProduct);
				editProductWin.ShowDialog();
				ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
			}
			else
			{
				MessageBox.Show("Выберите товар для редактирования.");
			}
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			if (ProductDataGrid.SelectedItem is Products selectedProduct)
			{
				tradeEntities.Products.Remove(selectedProduct);
				tradeEntities.SaveChanges();
				ProductDataGrid.ItemsSource = tradeEntities.Products.ToList();
			}
			else
			{
				MessageBox.Show("Выберите товар для удаления.");
			}
		}
	}
}
