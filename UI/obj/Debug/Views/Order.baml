   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UI.ViewsUI.Views  5          UI.Views.Order   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:UI.Views     5        N� Title$  Orders��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��97* �6   �� 5      $	��97* �6   �� 5      $	��97* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��2.5* �6   �� 5      $
��0.5* �6   .+�5   
   �� $��0��6   $��0��6   $��
Order View��6-   $��3��6B   $��Center=�6V   $��Center=�6s   $
��25px(�6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgOrder��5         AutoGenerateColumns .  $��0��6@   $��1��6P   $��3��6]      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6H   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *Id+6H     5      $ Date / Time��6%   $	 250 6X   	 6:   �� *
DateTime+6X     5      $ number of line Items��6%   $	 150 6i   	 6C   �� *OrderItems.Count+6i     5      $ 
Total (AU)��6%   $ 80 6f   	 69   �� *Total+
 �� StringFormat$
 c��6f     5      $ Current State��6%   $	 120 6]   	 6<   �� *State.State+6]   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ * 6)   $ Details��63      CellTemplate 5      �� 5      .R�5       �� -   5        $��Details��5    %   68   5!      5#      5%      �� 5&   
   -   5         ��Name$ button��5&      $��	Add Order��6!   $��1��65   $��2��6E   $��Center=�6T   $	��100��6r   $��40��6�   6�   5'      5(      