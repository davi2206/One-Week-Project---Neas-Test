   M S B A M L   `   `   `  ����N  JBusiness Manager UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Business_Manager_UIBusiness_Manager_UI  5   	   $    Business_Manager_UI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Business_Manager_UI     5   	     � Title$  Neas Business Management��5   	   $	��600��6*   $	��280��6:   .��5	      � .+�5
   
   �� -   5         ��Name$ Menubar��5
       �� Orientation$ 
Horizontal=�6&   $��35��6?   $	��Top=�6K   $��5q�6c   .+�5      �� -   5         ��Name$ Btn_Opdater��5      $��Opdater��6*   $	��250��6<   6H   5      �� 5   
   -   5        $ DistrictList��5      $ Vertical=�6+   $	��Top=�6B   $��5, 45, 5, 5q�6Z   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid_Districts��5      $
��Left=�5      $	��Top=�62   $	��150��5      $	��250��6$   ��. $
��Auto=�5      $
��Auto=�5         
IsReadOnly .    AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Nr��6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 65   �� *Nr+  5      $ Distrikt��6)   	 6;   �� *Name+  5      $ Ansvarlig sælger��6)   	 6C   �� *Manager.Name+5      5      �� 5    
   -   5        $ DistrictDetails��5       $ Vertical=�6.   $	��Top=�6E   $��5, 200, 5, 5q�6]   .+�5!        -   5        $ dataGrid_DistrictStores��5!      $
��Left=�5"      $	��Top=�62   $	��150��5#      $	��250��6$    .  .   5&        5'      $ Id��6)   	 65   �� *Id+  5(      $ 
Butik Navn��6)   	 6=   �� *Name+5*        5,      -   5        $ dataGrid_DistrictSalesmen��5,      $
��Left=�5-      $	��Top=�62   $	��150��5.      $	��250��6$   $
��0, 5q�5/       .  .   52        53      $ Id��6)   	 65   �� *Id+  54      $
 Navn��6)   	 67   �� *Name+56      �� 58      $ 
Horizontal=�6   .+�59      �� -   5        $ AddSalesman��59      $��Tilføj sælger��5:      $	��120��5;      $��
0, 5, 5, 5q�5<      $
��Left=�5=      {�.  5?      �� 5@      -	   5        $ RemoveSalesman��5@      $��Fjern sælger��5A      $	��120��5B      $��
5, 5, 5, 5q�5C      $
��Left=�5D      {�.  5F      5G      5H      5I      5J      