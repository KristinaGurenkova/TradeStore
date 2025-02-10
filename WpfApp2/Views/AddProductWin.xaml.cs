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
    /// Логика взаимодействия для AddProductWin.xaml
    /// </summary>
    public partial class AddProductWin : Window
    {
        public int IdUser {  get; set; }
        TradeEntities tradeEntities = new TradeEntities();
        public AddProductWin(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var idM = 0;
            var idP = 0;
            var idC = 0;

			try
			{
                try
                {
                    idM = tradeEntities.Manufacturers.Where(p => p.ManufacturerName == Manufact.Text).Select(p => p.ManufacturerID).Single();
                }
                catch
                {
					Manufacturers manufacturers = new Manufacturers()
					{
						ManufacturerName = Manufact.Text,
					};
					tradeEntities.Manufacturers.Add(manufacturers);
					tradeEntities.SaveChanges();
					idM = tradeEntities.Manufacturers.Where(p => p.ManufacturerName == Manufact.Text).Select(p => p.ManufacturerID).Single();
				}
                try
                {
                    idP = tradeEntities.Providers.Where(p => p.ProviderName == Provider.Text).Select(p => p.ProviderID).Single();
                }
                catch
                {
					Providers providers = new Providers()
					{
						ProviderName = Provider.Text,
					};
					tradeEntities.Providers.Add(providers);
					tradeEntities.SaveChanges();
					idP = tradeEntities.Providers.Where(p => p.ProviderName == Provider.Text).Select(p => p.ProviderID).Single();
				}
                try
                {
				    idC = tradeEntities.Categories.Where(p => p.CategoryName == Category.Text).Select(p => p.CategoryID).Single();
                }
                catch
                {
					Categories categories = new Categories()
					{
						CategoryName = Category.Text,
					};
					tradeEntities.Categories.Add(categories);
					tradeEntities.SaveChanges();
					idC = tradeEntities.Categories.Where(p => p.CategoryName == Category.Text).Select(p => p.CategoryID).Single();
				}
                Products products = new Products()
                {
                    ProductArticleNumber = ArticleProd.Text,
                    ProductName = NameProd.Text,
                    ProductDescription = DescriptionProd.Text,
                    ProductUnit = "шт.",
                    ProductCost = double.Parse(PriceProd.Text),
                    ProductMaxDiscount = double.Parse(MaxDisc.Text),
                    ProductQuantityInStock = int.Parse(CountProd.Text),
                    ProductDiscountAmount = double.Parse(Disc.Text),
                    ProductPhoto = "/Images/picture.png",
                        ManufacturerID = idM,
                    ProviderID = idP,
                    CategoryID = idC,
                };
                    tradeEntities.Products.Add(products);
                    tradeEntities.SaveChanges ();
                MessageBox.Show("Товар добавлен");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так.");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
