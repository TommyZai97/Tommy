   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TelerikWpfApp1TelerikWpfApp1 5   	      TBike.CreateNewUser   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TelerikWpfApp1     5   	     � Title$  CreateNewUser��5
   	   $	��300��6   $	��800��6/    � WindowStartupLocation$ CenterScreen=�6?    � Icon$&  /T-Bike;component/Image/logo.jpg��6d   $	��949��6�   $	��482��6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   �� ���	#A1FFFFFF$��Stretch=�6%   
���   �$��Center=�6R   $	��350��6m   $
��1100��6z    �� RadiusY$
 29.5��6�    �� RadiusX$
 29.5��6�   $��35,16,10,10q�6�   $��2��6�   �� 5   
   $y�Hidden=�6   $
��Left=�6)   $��Bottom=�6D   $��32��6_   $��67,0,0,0q�6k   $	��302��6}   $��2��6�   .+�5      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5      -   5         ��Name$ 
TLRankDesc��5      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��64,-33,19,18.667q�6�   �� 5      -   5        $ 
TLUsername��5      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��136,-42,0,20q�6�   5      �� 5   
   $��Stretch=�6   $��Center=�64   $	��150��6O   $	��500��6_   $	��250��6p   $
��1000��6   $��2��6�   $��52,39,36,19q�6�   .+�5      �� $��Stretch=�6   $
��14px(�67   $
��Wrap=�6G   $��Create New User��6[   $��Center=�6r   $
��Bold"�6�   $��	Underline{�6�   $��28��6�   $��0,0,0,10q�6�   ]� 5      ��. $��	0,0,10,10q�6.   $��Stretch=�6A   $��Stretch=�6_   .+�5      �� -   5         ��Name$ 	TBEmpName��5      	 �� TextWrapping$
	 Wrap=�6-   $	��550��6A   $��Stretch=�6P   *   $MahApps.Metro.Controls.TextBoxHelper
   	Watermark$
 Employee name��6n   $��0,0,5,0q�6�   (  "System.Windows.Controls.DatePicker  5       -   5          Name$ DOBText��5       $	��150��6/   $	��700��6>      DisplayDate$ 
01/01/2000��6M   $
 Date Of Birth��6g   5"      ]� 5#      ��. $��	0,0,10,10q�6/   $��Stretch=�6C   $��Stretch=�6a   .+�5$      �� -   5        $ TBEmail��5$      $
	 Wrap=�6,   $	��550��6@   $	��700��6O   $��Stretch=�6^   $
 Email Address��6|   $��0,0,5,0q�6�   �� 5%      -   5        $ 	TBPhoneNo��5%      $
	 Wrap=�6.   $	��350��6B   $	��700��6Q   $
 Phone Number��6a   5'      ]� 5*      ��. $��	0,0,10,10q�6.   $��Stretch=�6B   $��Stretch=�6`   .+�5+      �� -   5        $ TBCity��5+      $
	 Wrap=�6*   $	��350��6>   $	��700��6M   $��Stretch=�6\   $

 City��6z   $��0,0,5,0q�6�   �� 5-      -   5        $ 	TBZipCode��5-      $
	 Wrap=�6-   $	��250��6A   $	��700��6P   $��Stretch=�6_   $
 Zip Code��6}   5/      ]� 52      ��. $��0,0,0,10q�6.   $��Stretch=�6A   $��Stretch=�6_   .+�53      �� -	   5        $ 
TBAddress1��53      $
	 Wrap=�6.   $	��300��6C   $
 Address Line 1��6R   54      ]� 56      ��. $��0,0,0,10q�6.   $��Stretch=�6A   $��Stretch=�6_   .+�58      �� -
   5        $ 
TBAddress2��58      $
	 Wrap=�6.   $	��605��6C   $
 Address Line 2��6R   5:      ]� 5<      ��. $��0,0,0,10q�6.   $��Stretch=�6A   $��Stretch=�6_   .+�5=      �� -   5        $ 
TBAddress3��5=      $
	 Wrap=�6.   $	��605��6C   $
 Address Line 3��6R   5?      �� 5@      -   5        $��Add New��5@      $��70��6'   $��Right=�62   $��DemiBold"�6N   $��Bottom=�6d   $��1��6�   
�������6�   5B      5D      5E      