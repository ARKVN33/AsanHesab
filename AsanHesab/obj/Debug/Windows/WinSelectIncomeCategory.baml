   M S B A M L   `   `   `  ����  	AsanHesab/    )AsanHesab.Windows.WinSelectIncomeCategory   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��370��5   	   $	��590��6     � WindowStartupLocation$  CenterScreen=�6"    � WindowStyle$
 None=�6G   
������ $��20(�6s    � 
ResizeMode$ NoResize=�6�   $��	B Nazanin)�6�   ���	#FF192D6E$��2q�6�    � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:.5D�6Z   	 g� FillBehavior$	 HoldEnd=�6l   5      5      5      .��5      � $��RightToLeft=�6   ���	#FFEEEEF2.+�5   
   �� -   5        ���	#FF192D6E$��0��5   '   ���	#FFEEEEF2$��30��6a   $	��Top=�6m   �� 5   
   -   5        
 ��Name$
 LblTitle��5      $��انتخاب دسته��6"   $��22(�68   $
��Bold"�6F   $��0q�6X   $	��Top=�6c      LabelStyle1#���   6�   $��30��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ BtnClose��5      $��×��6#   $��35��6/   $��30��6:   $��22(�6F   $��Arial)�6T   $
��Left=�6u   $	��Top=�6�     ButtonStyle2#���  6�   �� 5   
   -   5        $ BtnMinimize��5      $��-��6&   $��35,0,0,0q�62   $��35��6D   $��30��6O   $��27(�6[   $��Arial)�6i   $
��Left=�6�   $	��Top=�6�     ButtonStyle3#���  6�   �� 5   
   ���	#FF192D6E$��2q�6)   $��10,35,10,10q�6=    �� CornerRadius$ 10��6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgdCategoryGroup��5      $��
20,85,20,0q�6-     DataGridStyle1#���  6A   ���	#FF192D6E$��2,2,0,2q�6�      AreRowDetailsFrozen .    
IsReadOnly .    GridLinesVisibility$ 
Horizontal=�6      HorizontalGridLinesBrush �	#FF192D6E   AlternatingRowBackground �	#FFF1F4F7 �� AlternationCount$ 2��6k     SelectionMode$ Single=�6�     AutoGenerateColumns .     CanUserSortColumns .  -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 Once=�6�  $	��225��6�  $	��Top=�6  ��6j   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ گروه��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *CategoryGroup+5        5   
   -   5        $ DgdCategory��5      $��272,85,20,0q�6(   #���  6=   ���	#FFEEEEF2���	#FF192D6E$��0,2,2,2q�6�    .  . $ 
Horizontal=�6�    �	#FF192D6E �	#FFF1F4F7$ 2��6h  $ Single=�6}   .   .  $
 Once=�6�  $	��225��6�  $	��Top=�6    5        5       $ دسته بندی��6%   $	 250 68    6D   �� *
Category+5"      �� 5#   
   -   5        $ 	BtnSelect��5#      $��انتخاب��6$   $��
170,0,0,21q�65     ButtonStyle1#���  6I   $��1��6p    �� 	IsDefault . $
��Left=�6�   $	��120��6�   $��30��6�   $��Bottom=�6�   �� 5$   
   -	   5        $ BtnNew��5$      $��جدید��6!   $��295,0,171,21q�60   #���  6F   $��2��6m   $��30��6�   $��Bottom=�6�   �� 5%   
   $
��Left=�6   $��30��6/   $��	20,50,0,0q�6;   ���	#FF192D6E$	��Top=�6a   $	��546��6y    �� RadiusY$ 7��6�    �� RadiusX$ 7��6�   �� 5&   
   $��	گروه:��6   $��	20,50,0,0q�6    $��30��63   $	��Top=�6?   $
��Left=�6W   #���   6r   �� 5'   
   -
   5        $
 LblGroup��5'      $��	66,50,0,0q�6"   $��30��65   $	��Top=�6A   
��� � �$
��Bold"�6l   $
��Left=�6~   $	��206��6�   #���   6�   �� 5(   
   $��دسته بندی:��6   $��
272,50,0,0q�6%   $��30��69   $	��Top=�6E   $
��Left=�6]   $��84��6x   #���   6�   �� 5)   
   -   5        $
 LblCategory��5)      $��
356,50,0,0q�6%   $��30��69   $	��Top=�6E   $
��Left=�6]   
����  �$
��Bold"�6�   $	��210��6�   #���   6�    J� RenderTransformOrigin$ 0.667,0.467&�6�   5,      5-      