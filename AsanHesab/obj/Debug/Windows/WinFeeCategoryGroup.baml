   M S B A M L   `   `   `  ����  	AsanHesab+    %AsanHesab.Windows.WinFeeCategoryGroup   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��437��5   	   $	��590��6     � WindowStartupLocation$  CenterScreen=�6"    � WindowStyle$
 None=�6G   
������ $��20(�6s    � 
ResizeMode$ NoResize=�6�   $��	B Nazanin)�6�   ���	#FF192D6E$��2q�6�    � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:.5D�6Z   	 g� FillBehavior$	 HoldEnd=�6l   5      5      5      .��5      � $��RightToLeft=�6   ���	#FFEEEEF2.+�5   
   �� -   5        ���	#FF192D6E$��0��5   '   ���	#FFEEEEF2$��30��6a   $	��Top=�6m   �� 5   
   -   5        
 ��Name$
 LblTitle��5      $)��#گروه بندی هزینه‌ها��6"   $��22(�6?   $
��Bold"�6M   $��0q�6_   $	��Top=�6j      LabelStyle1#���   6�   $��30��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ BtnClose��5      $��×��6#   $��35��6/   $��30��6:   $��22(�6F   $��Arial)�6T   $
��Left=�6u   $	��Top=�6�     ButtonStyle2#���  6�   �� 5   
   -   5        $ BtnMinimize��5      $��-��6&   $��35,0,0,0q�62   $��35��6D   $��30��6O   $��27(�6[   $��Arial)�6i   $
��Left=�6�   $	��Top=�6�     ButtonStyle3#���  6�   �� 5   
   ���	#FF192D6E$��2q�6)   $��10,35,10,10q�6=    �� CornerRadius$ 10��6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgdCategoryGroup��5      $��
20,0,20,56q�6-     DataGridStyle1#���  6A   ���	#FF192D6E$��2q�6�      AreRowDetailsFrozen .    
IsReadOnly .    GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FF192D6E   AlternatingRowBackground �	#FFF1F4F7 �� AlternationCount$ 2��6e     SelectionMode$ Single=�6z     AutoGenerateColumns .     CanUserSortColumns .  -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 Once=�6�  $	��250��6�  $��Bottom=�6�  ��6j   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ گروه��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 500 63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *CategoryGroup+5      �� 5   
   -   5        $ BtnAdd��5      $��ثبت��6!   $��	45,0,0,21q�6/     ButtonStyle1#���  6B   $��2��6i    �� 	IsDefault . $
��Left=�6�   $	��120��6�   $��30��6�   $��Bottom=�6�   6�   �� 5   
   -   5        $ BtnEdit��5      $��ویرایش��6"   $��
170,0,0,21q�63   #���  6G   $��3��6n   $
��Left=�6{   $	��120��6�   $��30��6�   $��Bottom=�6�   6�   �� 5    
   -	   5        $ 	BtnDelete��5       $��حذف��6$   $��
295,0,0,21q�62   #���  6F   $��4��6m   $
��Left=�6z   $	��120��6�   $��30��6�   $��Bottom=�6�   6�   �� 5!   
   -
   5        $ BtnNew��5!      $��جدید��6!   $��420,0,46,21q�60   #���  6E   $��5��6l   $��30��6y   $��Bottom=�6�   6�   �� 5"   
   $��هزینه‌ها��6   $
��Bold"�6%   $��
20,50,20,0q�67   $��RightToLeft=�6K   ���	#FF192D6E$��72��6   $	��Top=�6�   �� 5#   
   $��نام گروه:��6   $
��Left=�6$   $��	30,80,0,0q�6?   $	��Top=�6R   $��30��6j   #���   6v   �� 5$   
   -   5         ��Name$ TxtGroup��5$      $��30��6$   $��
97,80,30,0q�60    �� TextWrapping$
 Wrap=�6D   $	��Top=�6Y     TextBoxStyle1#���  6q   $��1��6�    �� 	MaxLength$ 20��6�   $��Center=�6�   $��Stretch=�6�   5'      5(      