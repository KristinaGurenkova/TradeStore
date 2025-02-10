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
			try
			{
				Product.ProductArticleNumber = ArticleProd.Text;
				Product.ProductName = NameProd.Text;
				Product.ProductCost = double.Parse(PriceProd.Text);
				Product.ProductQuantityInStock = int.Parse(CountProd.Text);
				Product.ProductDiscountAmount = double.Parse(Disc.Text);
				Product.ProductMaxDiscount = double.Parse(MaxDisc.Text);

				var provider = _tradeEntities.Providers.SingleOrDefault(p => p.ProviderName == Provider.Text);
				if (provider != null) Product.ProviderID = provider.ProviderID;

				var manufact = _tradeEntities.Manufacturers.SingleOrDefault(m => m.ManufacturerName == Manufact.Text);
				if (manufact != null) Product.ManufacturerID = manufact.ManufacturerID;

				var category = _tradeEntities.Categories.SingleOrDefault(c => c.CategoryName == Category.Text);
				if (category != null) Product.CategoryID = category.CategoryID;

				_tradeEntities.SaveChanges();
				MessageBox.Show("Товар обновлён");
			}
			catch
			{
				MessageBox.Show("Ошибка при обновлении товара");
			}
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
