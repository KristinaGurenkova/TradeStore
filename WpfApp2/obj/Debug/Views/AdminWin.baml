   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp2.ViewsWpfApp2.Views  5   	       WpfApp2.Views.AdminWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp2.Views     5   	     � Title$  Окно админа��5   	   $
��1080��6   $
��1920��6+    � 
ResizeMode$ NoResize=�68    � WindowState$ 	Maximized=�6N   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��ProductDataGrid��5
   =      AutoGenerateColumns .  $��20(�6/   $��
0,89,221,0q�6T   $��Comic Sans MS)�6h    � ContextMenu 5      �� 5      .@�5      m� -   5        $!��Добавить товар��5      $��Comic Sans MS)�6I   m� 5      -   5        $
��Edit��5   <   $+��%Редактировать товар��6   $��Comic Sans MS)�6[   m� 5      -   5        $��Delete��5   6   $��Удалить товар��6   $��Comic Sans MS)�6Z   5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      �� $	��100��6D   $	��100��6T   ��6$   �� *ProductPhoto+6T   5      5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      
FontFamily$ Comic Sans MS)�6\   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� 
 �� Path$
 ProductName�6\     5      $ Описание��6%   $ Comic Sans MS)�6c   	 67   �� $
 ProductDescription�6c     5      $  Производитель��6%   $ Comic Sans MS)�6l   	 6<   �� $
 Providers.ProviderName�6l     5      $ Цена��6%   $ Comic Sans MS)�6X   	 63   �� $
 ProductCost�6X     5      $# Кол-во на складе��6%   $ Comic Sans MS)�6o   	 6?   �� $
 ProductQuantityInStock�6o   5       �� 5!   
   $
��Left=�6   $��74��6+   $��	10,10,0,0q�67   $	��Top=�6J   $��80��6b   $��/Images/logo.png��6m   �� 5"   
   $��
TradeStore��6   $��30(�6&   $��89,22,1649,982q�64   $��Comic Sans MS)�6L   �� 5#   
   -   5         ��Name$ UserFio��5#      $��896,0,0,980q�6%   $	��fio��6:   $��35(�6E    �� TextAlignment$ Right=�6S   $
��Wrap=�6i   $��Comic Sans MS)�6}   �� 5$   
   -   5        $
��Exit��5$   �   $��1722,1010,0,0q�6   $��
Назад��6(   $
��Left=�68   $	��Top=�6S   $��44��6k   $	��168��6w   $��20(�6�   $��Comic Sans MS)�6�   5%      5&      