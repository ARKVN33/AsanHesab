   M S B A M L   `   `   `  ����  	AsanHesab(    "AsanHesab.Windows.WinSelectAccount   5   	   U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=3.5.41019.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5        $	��535��5   	   $	��960��6     � WindowStartupLocation$  CenterScreen=�6"    � WindowStyle$
 None=�6G   $��20(�6Z    � 
ResizeMode$ NoResize=�6h   $��	B Nazanin)�6~   ���	#FF192D6E$��2q�6�    � Triggers 5	      :� 5
   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From$ 0X�6J   	 W� To$ 1X�6S    g� Duration$ 0:0:.5D�6Z   	 g� FillBehavior$	 HoldEnd=�6l   5      5      5      .��5      � $��RightToLeft=�6   ���	#FFEEEEF2.+�5   
   �� -   5        ���	#FF192D6E$��0��5   '   ���	#FFEEEEF2$��30��6a   $	��Top=�6m   �� 5   
   -   5        
 ��Name$
 LblTitle��5      $��انتخاب حساب��6"   $��22(�68   $
��Bold"�6F   $��0q�6X   $	��Top=�6c      LabelStyle1#���   6�   $��30��6�   $��Center=�6�   �� 5   
   -   5         ��Name$ BtnClose��5      $��×��6#   $��35��6/   $��30��6:   $��22(�6F   $��Arial)�6T   $
��Left=�6u   $	��Top=�6�     ButtonStyle2#���  6�   �� 5   
   -   5        $ BtnMinimize��5      $��-��6&   $��35,0,0,0q�62   $��35��6D   $��30��6O   $��27(�6[   $��Arial)�6i   $
��Left=�6�   $	��Top=�6�     ButtonStyle3#���  6�   �� 5   
   ���	#FF192D6E$��2q�6)   $��10,35,10,10q�6=    �� CornerRadius$ 10��6R   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DgdBankAccount��5      $��	20,80,0,0q�6+     DataGridStyle1#���  6>   ���	#FF192D6E$��2q�6�      AreRowDetailsFrozen .    
IsReadOnly .    GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FF192D6E   AlternatingRowBackground �	#FFF1F4F7 �� AlternationCount$ 2��6b     SelectionMode$ Single=�6w     AutoGenerateColumns .  -  'System.Windows.Input.KeyboardNavigation   TabNavigation$
 Once=�6�     CanUserSortColumns .  $
��Left=�6�  $	��916��6  $	��396��6  $	��Top=�6!  ��6g   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ نام حساب��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *
BankName+  5      $ نام بانک��6%   $	 150 67    6C   �� *
BranchName+  5      $ شماره حساب��6%   $	 150 69    6E   �� *
AccountNum+  5      $ شماره کارت��6%   $	 150 69    6E   �� *	CardNum+  5      $ موجودی اولیه��6%   $	 150 6;    6G   �� *InitialBalance+ �� StringFormat$ {0:N0}��  5       $ توضیحات��6%   $	 150 66    6B   �� *BankDescription+5"      �� 5#   
   -   5        $ 	BtnSelect��5#      $��انتخاب��6$   $��
355,0,0,20q�65   $��1��6I    �� 	IsDefault . $
��Left=�6g   $	��120��6�     ButtonStyle1#���  6�   $��30��6�   $��Bottom=�6�   6�   �� 5$   
   -   5        $ BtnNew��5$      $��جدید��6!   $��480,0,356,20q�60   $��2��6F   #���  6S   $��30��6�   $��Bottom=�6�   �� 5%   
   $��30��6   $��	20,45,0,0q�6    ���	#FF192D6E$	��Top=�6F    �� RadiusY$ 7��6^    �� RadiusX$ 7��6j   $
��Left=�6v   $	��916��6�   �� 5&   
   $��نام حساب:��6   $��	20,45,0,0q�6$   $��30��67   $	��Top=�6C   $
��Left=�6[   #���   6v   �� 5'   
   -	   5        $
 LblBankName��5'      $��	94,45,0,0q�6%   $��30��68   $	��Top=�6D   
��� � �$
��Bold"�6o   $
��Left=�6�   $	��130��6�   #���   6�   �� 5(   
   $��نام بانک:��6   $��
224,45,0,0q�6$   $��30��68   $	��Top=�6D   $
��Left=�6\   #���   6w   �� 5)   
   -
   5        $
 LblBranchName��5)      $��
286,45,0,0q�6'   $��30��6;   $	��Top=�6G   $
��Left=�6_   
����  �$
��Bold"�6�   $	��130��6�   #���   6�   �� 5*   
   $��شماره حساب:��6   $��
416,45,0,0q�6&   $	��Top=�6:   $��30��6R   $
��Left=�6^   #���   6y   �� 5+   
   -   5        $
 	LblAccNum��5+      $��
510,45,0,0q�6#   $��30��67   $	��Top=�6C   $
��Left=�6[   
����  �$
��Bold"�6�   $	��170��6�   #���   6�   �� 5,   
   $��شماره کارت:��6   $��
680,45,0,0q�6&   $	��Top=�6:   $��30��6R   $
��Left=�6^   #���   6y   �� 5-   
   -   5        $
 
LblCardNum��5-      $��
767,45,0,0q�6$   $��30��68   $	��Top=�6D   
����  �$
��Bold"�6r   #���   6�   $
��Left=�6�   $	��169��6�   5/      50      