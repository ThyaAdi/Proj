   M S B A M L   `   `   `  ����F  BPieControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:PieControls;assembly=PieControlsPieControls  5       BankApp   BankApp.ShowTransactions   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >pie.clr-namespace:PieControls;assembly=PieControls     5      .��5	      � .+�5
   
    � -   5        $��frame1��5
   B   $��48��6   $
��Left=�6   $��0q�67   $	��Top=�6P   $	��400��6h   $��0,0,0,1q�6t   ���	#FF1F70F26�   �� 5   
   -   5        $��AddTransaction��5   f   $��Add Transaction��6   $��23��6+   $��Right=�67   $��	0,12,91,0q�6S   $	��Top=�6|   $	��105��6�   $
��Bold"�6�   �� 5   
   -   5        $��button2��5   ]   $��Logout��6   $��23��6"   $��Right=�6.   $��	0,12,10,0q�6J   $	��Top=�6l   $��75��6�   $
��Bold"�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��BankDetails��5   �      AlternatingRowBackground  �	#FFCBBBBB �� AlternationCount$ 1��68      AutoGenerateColumns .  $��0q�6i      CanUserAddRows .     CanUserDeleteRows .    CanUserReorderColumns .     CanUserResizeColumns .     CanUserResizeRows .     CanUserSortColumns .  	   HeadersVisibility$	 Column=�65  $
��Auto��6P  $��Center=�6^  {�. 
   
IsReadOnly
 . $��	0,100,0,0q�6�     SelectionMode$ Single=�6�  $	��Top=�6�  $	��Top=�6�  $
��Auto��6   � DataContext 6  ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *id+  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Transaction Type��6I    6%   �� *TransactionType+6I     5      $ Description��6E    6%   �� *Description+6E     5      $ TransactionDate��6I    6%   �� *TransactionDate+6I     5      $ Amount��6@    6%   �� *Amount+6@     5      $ Balance��6G    6%   �� *EndingBalance+6G    � ContextMenu 5      �� 5      5      �� 5   
   -   5        $��button4��5   [   $
��Edit��6   $��23��6    $
��Left=�6,   $��
316,75,0,0q�6G   $	��Top=�6j   $
��Auto��6�   $
��Bold"�6�   �� 5   
   -   5        $��BankAccountId��5   N   $��23��6   $
��Left=�6   $��252,419,0,0q�69   $	��Top=�6c   $	��120��6{   $y�	Collapsed=�6�   �� 5   
   -   5        $��button1��5   Z   $
��Back��6   $��23��6    $
��Left=�6,   $��	12,12,0,0q�6G   $	��Top=�6i   $��75��6�   $
��Bold"�6�   �� 5   
   -   5        $��button6��5   ]   $��Delete��6   $��23��6"   $��Right=�6.   $��	0,75,90,0q�6J   $	��Top=�6l   $
��Auto��6�   $
��Bold"�6�   �� 5   
   -	   5        $��button3��5   c   $��Create Chart��6   $��23��6(   $
��Left=�64   $��
181,75,0,0q�6O   $	��Top=�6r   $��75��6�   $
��Bold"�6�   6�   5      5       