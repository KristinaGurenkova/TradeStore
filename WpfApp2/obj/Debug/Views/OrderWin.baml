   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp2.ViewsWpfApp2.Views  5   	       WpfApp2.Views.OrderWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp2.Views     5   	     � Title$  Продукты��5      $
��1080��6   $
��1920��6*    � WindowState$ 	Maximized=�67    � 
ResizeMode$ NoResize=�6O   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��CartDataGrid��5
   =      AutoGenerateColumns .  $��20(�6/   $��
0,89,264,0q�6Q   $��Comic Sans MS)�6e      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��6%      
FontFamily$ Comic Sans MS)�6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *ProductArticleNumber+6_     5      $ Код заказа��6%   $ Comic Sans MS)�6W    69   �� *	OrderCode+6W     5      $ Количество��6%   $ Comic Sans MS)�6S    69   �� *Count+6S   5      �� 5   
   $
��Left=�6   $��74��6+   $��	10,10,0,0q�67   $	��Top=�6J   $��80��6b   $��/Images/logo.png��6m   �� 5   
   $��Comic Sans MS)�6   $��
TradeStore��6/   $��30(�6A   $��89,22,1643,982q�6O   �� 5   
   -   5         ��Name$ UserFio��5   /   $��Comic Sans MS)�6   $��896,0,0,980q�6@   $	��fio��6U   $��35(�6`   	 �� TextAlignment$	 Right=�6n   $
��Wrap=�6�   �� 5   
   $��1661,89,0,0q�6   .+�5      �� -   5        $
��Exit��5   �   $��Comic Sans MS)�6   $��	0 760 0 0q�60   $��
Назад��6C   $��Center=�6S   $	��Top=�6p   $��44��6�   $	��168��6�   $��20(�6�   6�   5      5      5      