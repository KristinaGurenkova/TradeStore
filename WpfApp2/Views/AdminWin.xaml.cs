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
				try
				{
					selectedProduct.ProductArticleNumber = editProductWin.ArticleProd.Text;
					selectedProduct.ProductName = editProductWin.NameProd.Text;
					selectedProduct.ProductCost = double.Parse(editProductWin.PriceProd.Text);
					selectedProduct.ProductQuantityInStock = int.Parse(editProductWin.CountProd.Text);
					selectedProduct.ProductDiscountAmount = double.Parse(editProductWin.Disc.Text);
					selectedProduct.ProductMaxDiscount = double.Parse(editProductWin.MaxDisc.Text);

					var provider = tradeEntities.Providers.SingleOrDefault(p => p.ProviderName == editProductWin.Provider.Text);
					if (provider != null) selectedProduct.ProviderID = provider.ProviderID;

					var manufact = tradeEntities.Manufacturers.SingleOrDefault(m => m.ManufacturerName == editProductWin.Manufact.Text);
					if (manufact != null) selectedProduct.ManufacturerID = manufact.ManufacturerID;

					var category = tradeEntities.Categories.SingleOrDefault(c => c.CategoryName == editProductWin.Category.Text);
					if (category != null) selectedProduct.CategoryID = category.CategoryID;

					tradeEntities.SaveChanges();
				}
				catch
				{
					MessageBox.Show("Ошибка при обновлении товара");
				}
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
