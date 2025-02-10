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
using WpfApp2.DB;
using WpfApp2.Views;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private int failedAttempts = 0;
		private const int maxFailedAttempts = 3;
		TradeEntities tradeEntities = new TradeEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginIn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var x = tradeEntities.Users.Where(p=>p.UserLogin == loginTextBox.Text && p.UserPassword == passBox.Password).Select(p => new { p.UserID, p.UserRole }).Single();
				failedAttempts = 0;
				if (x.UserRole == 1)
                {
                    AdminWin adminWin = new AdminWin(x.UserID);
                    adminWin.Show();
                    this.Close();
                }
                else if (x.UserRole == 2)
                {
                    ManagerWin managerWin = new ManagerWin(x.UserID);
                    managerWin.Show();
                    this.Close();
                }
                else if (x.UserRole == 3)
                {
                    ProductWin productWin = new ProductWin(x.UserID);
                    productWin.Show();
                    this.Close();
                }
            }
            catch
            {
				failedAttempts++;
				MessageBox.Show("Неверный логин или пароль");
				if (failedAttempts >= maxFailedAttempts)
				{
					CaptchaWindow captchaWindow = new CaptchaWindow();
					captchaWindow.ShowDialog();
					failedAttempts = 0; 
				}
			}
        }

        private void loginInGuest_Click(object sender, RoutedEventArgs e)
        {
            ProductWin productWin = new ProductWin(0);
            productWin.Show();
            this.Close();
        }
    }
}
