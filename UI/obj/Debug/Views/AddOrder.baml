   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UI.ViewsUI.Views  5          UI.Views.AddOrder   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:UI.Views     5        N� Title$  AddOrder��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��3* �6   �� 5      $
��1.5* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   �� 5      $
��2.2* �6   �� 5      $
��0.8* �6   .+�5   
   �� $��0��6   $��0��6   $��	Add Order��6-   $��6��6A   $��Center=�6U   $��Center=�6r   $
��25px(�6�   $
��Bold"�6�   �� 5   
   $��1��6   $��0��6   $��
Order ID: ��6-   $��Center=�6B   $��Right=�6^   �� 5   
   $��1��6   $��1��6   $��Center=�6P   ��6/   �� *Id+ �� Mode$ OneWay=�6P   �� 5   
   $��2��6   $��0��6   $��Date/Time: ��6-   $��Center=�6C   $��Right=�6_   �� 5    
   $��2��6   $��1��6   $��Center=�6V   ��6/   �� *
DateTime+$ OneWay=�6V   �� 5"   
   $��3��6   $��0��6   $��Number of Items: ��6-   $��Center=�6I   $��Right=�6e   �� 5#   
   $��3��6   $��1��6   $��Center=�6_   ��60   �� *OrderItems.Count+$ OneWay=�6_   �� 5%   
   $��1��6   $��2��6   $��Status: ��6-   $��Center=�6@   $��Right=�6\   �� 5&   
   $��1��6   $��3��6   $��Center=�6Y   ��6/   �� *State.State+$ OneWay=�6Y   �� 5(   
   $��2��6   $��2��6   $��Total: ��6-   $��Center=�6?   $��Right=�6[   �� 5)   
   $��2��6   $��3��6   $��Center=�6S   ��6/   �� *Total+$ OneWay=�6S   &   System.Windows.Controls.DataGrid  5+   
   -   5          Name$ dgOrderDetails��5+         
IsReadOnly .    AutoGenerateColumns .  $��0��6Y   $��4��6i   $��4��6v   $��	10,0,10,0q�6�   ��6�   �� *
OrderItems+$ OneWay=�   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Header$	 SKU��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6R   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 62   �� *StockItemId+6R     5.      $ Item Name and Description��6%   $		 200 6i   
 6H   �� *Description+6i     5/      $ Quantity��6%   $		 100 6U   
 67   �� *
Quantity+6U     50      $ 
Price (AU)��6%   $		 100 6f   
 69   �� *Price+ �� StringFormat$ c��6f     51      $ 
Total (AU)��6%   $		 100 6f   
 69   �� *Total+$ c��6f   4  .System.Windows.Controls.DataGridTemplateColumn  52      $	 * 6)   $  To Delete press the button��63      CellTemplate 53      �� 54      .R�55      �� -   5        $��Delete��55   %   67   56      58      5:      �� 5;   
   -   5        $��5��5;      $��1��6   $��Add Order Item��6/   $��10q�6H   $��40��6T   $��Center=�6a   $��10q�6~   $	��100��6�   6�   �� 5<   
   -   5        $��5��5<      $��2��6   $��Submit��6/   $��10q�6@   $��40��6L   $��Center=�6Y   $��10q�6v   $	��100��6�   6�   �� 5=   
   -   5        $��5��5=      $��3��6   $��Cancel��6/   $��10q�6@   $��40��6L   $��Center=�6Y   $��10q�6v   $	��100��6�   6�   5>      5?      