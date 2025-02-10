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

namespace WpfApp2.Views
{
	/// <summary>
	/// Логика взаимодействия для CaptchaWindow.xaml
	/// </summary>
	public partial class CaptchaWindow : Window
	{
		public CaptchaWindow()
		{
			InitializeComponent();
			Random random = new Random();
			capcha.Text =  random.Next(1 , 10000).ToString();
		}


		private void Captcha_Click(object sender, RoutedEventArgs e)
		{
			if (captchaTextBox.Text == capcha.Text)
			{
				MessageBox.Show("Капча пройдена!");
				this.DialogResult = true; 
				this.Close();
			}
			else
			{
				MessageBox.Show("Неверная капча. Попробуйте снова.");
			}
		}
	}
}
