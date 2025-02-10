using System;
using System.Linq;
using System.Windows;
using WpfApp2.DB;

namespace WpfApp2.Views
{
	public partial class EditProductWin : Window
	{
		Products Product;
		TradeEntities _tradeEntities = new TradeEntities();

		public EditProductWin(Products product)
		{
			InitializeComponent();
			Product = product;
			LoadProductData();
		}

		private void LoadProductData()
		{
			ArticleProd.Text = Product.ProductArticleNumber;
			NameProd.Text = Product.ProductName;
			PriceProd.Text = Product.ProductCost.ToString();
			CountProd.Text = Product.ProductQuantityInStock.ToString();
			Disc.Text = Product.ProductDiscountAmount.ToString();
			MaxDisc.Text = Product.ProductMaxDiscount.ToString();
			Provider.Text = Product.Providers.ProviderName;
			Manufact.Text = Product.Manufacturers.ManufacturerName;
			Category.Text = Product.Categories.CategoryName;
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Товар обновлён");
			this.Close();
		}
	}
}
