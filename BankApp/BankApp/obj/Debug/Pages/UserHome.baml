   M S B A M L   `   `   `  ����  BankApp    BankApp.UserHome   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $	��800��5   	   $	��400��6   .��5      � .+�5   
    � -   5        $��frame1��5   B   $��48��6   $
��Left=�6   $��0q�67   $	��Top=�6P   $	��400��6h   $��0,0,0,1q�6t   ���	#FF1F70F26�   &   System.Windows.Controls.DataGrid  5	   
   -   5        $��BankDetails��5	   m       AutoGenerateColumns  .  $
��Auto��6/   $��Center=�6=   $��	0,100,0,0q�6Z   $	��Top=�6�   $
��Auto��6�   $��0q�6�      CanUserSortColumns .     CanUserResizeColumns .     CanUserReorderColumns .  $	��Top=�6     CanUserDeleteRows .    CanUserResizeRows .     SelectionMode$ Single=�6y     AlternatingRowBackground �	#FFCBBBBB �� AlternationCount$ 1��6�  	   CanUserAddRows	 .  
   HeadersVisibility$
 Column=�6�  {�.    
IsReadOnly . $��Normal"�6H   � DataContext 6.  ��  � ContextMenu 5
      �� 5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *id+6B     5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Bank Name��6)    6<   �� *
BankName+6[     5      $ Account Type��6)    6?   �� *AccountType+6a     5      $ Balance��6)    6:   �� *	Balance+6X   5      �� 5      -   5        $��button4��5   0   $
��Edit��6   $��23��6$   $
��Auto��6?   $��
0,78,135,0q�6L   $��Right=�6v   $	��Top=�6�   $
��Bold"�6�   �� 5      -   5        $��button3��5   0   $
��View��6   $��23��6$   $
��Auto��6?   $��	0,78,96,0q�6L   $��0q�6u   $��Right=�6�   $	��Top=�6�   $
��Bold"�6�   �� 5      -   5        $��button5��5   2   $��Delete��6   $��23��6&   $
��Auto��6A   $��
191,78,0,0q�6N    �� IsCancel .  $
��Left=�6�   $	��Top=�6�   $��0q�6�   $
��Bold"�6�   �� 5   
   -   5        $��button1��5   b   $��Add Account��6   $��23��6'   $��Right=�63   $��	0,12,88,0q�6O   $	��Top=�6q   $��80��6�   $
��Bold"�6�   �� 5   
   -   5        $��button2��5   \   $��Logout��6   $��23��6"   $��Right=�6.   $��0,11,6,0q�6J   $	��Top=�6k   $��75��6�   $
��Bold"�6�   6�   5      5      