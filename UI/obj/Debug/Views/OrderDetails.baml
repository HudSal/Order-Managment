   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UI.ViewsUI.Views  5          UI.Views.OrderDetails   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:UI.Views     5        N� Title$  OrderDetails��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��3* �6   �� 5      $
��1.5* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��2.2* �6   �� 5      $
��0.8* �6   .+�5   
   �� $��0��6   $��0��6   $��Order Details View��6-   $��6��6J   $��Center=�6^   $��Center=�6{   $
��25px(�6�   $
��Bold"�6�   �� 5   
   $��1��6   $��0��6   $��
Order ID: ��6-   $��Center=�6B   $��Right=�6^   �� 5   
   $��1��6   $��1��6   $��Center=�6P   ��6/   �� *Id+ �� Mode$ OneWay=�6P   �� 5   
   $��2��6   $��0��6   $��Date/Time: ��6-   $��Center=�6C   $��Right=�6_   �� 5   
   $��2��6   $��1��6   $��Center=�6V   ��6/   �� *
DateTime+$ OneWay=�6V   �� 5!   
   $��3��6   $��0��6   $��Number of Items: ��6-   $��Center=�6I   $��Right=�6e   �� 5"   
   $��3��6   $��1��6   $��Center=�6_   ��60   �� *OrderItems.Count+$ OneWay=�6_   �� 5$   
   $��1��6   $��2��6   $��Status: ��6-   $��Center=�6@   $��Right=�6\   �� 5%   
   $��1��6   $��3��6   $��Center=�6Y   ��6/   �� *State.State+$ OneWay=�6Y   �� 5'   
   $��2��6   $��2��6   $��Total: ��6-   $��Center=�6?   $��Right=�6[   �� 5(   
   $��2��6   $��3��6   $��Center=�6S   ��6/   �� *Total+$ OneWay=�6S   &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ dgOrderDetails��5*         AutoGenerateColumns .  $��0��6G   $��4��6W   $��4��6d      
IsReadOnly . ��6x   �� *
OrderItems+$ OneWay=�   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$	 SKU��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6R   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   �� *StockItemId+6R     5-      $ Item Name and Description��6%   $		 250 6i   
 6H   �� *Description+6i     5.      $ Quantity��6%   $		 150 6U   
 67   �� *
Quantity+6U     5/      $ 
Price (AU)��6%   $		 150 6f   
 69   �� *Price+ �� StringFormat$ c��6f     50      $ 
Total (AU)��6%   $
	 150* 6f   
 69   �� *Total+$ c��6f   52      �� 53   
   -   5        $��5��53      $��1��6   $��Orders��6/   $��10q�6@   $��40��6L   $��Center=�6Y   $��10q�6v   $	��100��6�   6�   �� 54   
   -   5         ��Name$ Process��54      $��5��6"   $��2��6/   $��10q�6?   $��40��6K   $��Center=�6X   $��10q�6u   $	��100��6�   ��55      �� 56       �� 
TargetType" ��6   .�57      ��  �� Property � y� �� Value$ Hidden=�63    �� Triggers 58      �� 59       �� Binding 6&   �� *State.State+ �� Value Pending6F   .a�5:      ��  � y�$ Visible=�6;   �� 5;       � ��$ Process��68   5<      �� 5=       6&   �� *State+ New6@   .a�5>      ��  � y�$ Visible=�6;   �� 5?       � ��$ Submit��68   5@      5B      5D      5E      5F      