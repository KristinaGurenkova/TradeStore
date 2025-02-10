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
    /// Логика взаимодействия для ManagerWin.xaml
    /// </summary>
    public partial class ManagerWin : Window
    {
        TradeEntities tradeEntities = new TradeEntities();
        public int IdUser { get; set; }
        public ManagerWin(int idUser)
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
    }
}
