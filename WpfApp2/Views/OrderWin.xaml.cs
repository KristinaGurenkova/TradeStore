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
	/// Логика взаимодействия для OrderWin.xaml
	/// </summary>

	public partial class OrderWin : Window
	{
		TradeEntities tradeEntities = new TradeEntities();
		public int IdUser { get; set; }
		public OrderWin(int idUser)
		{
			InitializeComponent();
			CartDataGrid.ItemsSource = tradeEntities.OrderProduct.Where(x => x.Orders.UserID == idUser).Select(p => new { p.Orders.OrderCode, p.Products.ProductArticleNumber, p.Count }).ToList();
			IdUser = idUser;
			UserFio.Text = tradeEntities.Users.Where(p => p.UserID == idUser).Select(p => p.UserFullName).Single();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			ProductWin productWin = new ProductWin(IdUser);
			productWin.Show();
			this.Close();
		}
	}
}
