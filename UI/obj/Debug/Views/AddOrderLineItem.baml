   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UI.ViewsUI.Views  5          UI.Views.AddOrderLineItem   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:UI.Views     5        N� Title$  AddOrderLineItem��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��97* �6   �� 5      $	��97* �6   �� 5      $	��97* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��2.5* �6   �� 5      $
��0.5* �6   .+�5   
   �� $��0��6   $��0��6   $��Add Order Item��6-   $��3��6F   $��Center=�6Z   $��Center=�6w   $
��25px(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgStockItem��5         AutoGenerateColumns .  $��0��6E   $��1��6U   $��3��6b      
IsReadOnly . ��6v   �� *
StockItems+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 SKU��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6I   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 62   �� *Id+6I     5      $ Item Name or Description��6%   $ * 6a   	 6G   �� *Name+6a     5      $ 
Price (AU)��6%   $	 150 6T   	 69   �� *Price+6T     5      $ In Stock��6%   $	 150 6T   	 67   �� *	InStock+6T   5      �� 5   
   -   5        
 ��Name$
 AddOrder_bt��5      $��	Add Order��6&   $��1��6:   $��2��6J   $��Center=�6Y   $��10q�6w   $	��100��6�   $��40��6�   $��10q�6�   6�   �� 5   
   -   5         ��Name$ txtQuantity��5   9   $��2��6O   $��2��6_   $��Right=�6n   $��94��6�   $��0,10,29.667,10q�6�   ��6   �� *
Quantity+ �� Mode$ TwoWay=�6�   �� 5    
   $��	Quantity:��6   $��2��6$   $
��Left=�64   $��	30,12,0,0q�6O   $��2��6b   $	��Top=�6o    J� RenderTransformOrigin$ 1.767,0.462&�6�   $��35��6�   $��94��6�   $
��20px(�6�   $��SemiBold"�6�   5"      5#      