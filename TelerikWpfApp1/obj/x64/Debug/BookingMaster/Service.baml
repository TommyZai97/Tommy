   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TBike.BookingMasterTBike.BookingMaster 5   	   !   TBike.BookingMaster.Service   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TBike.BookingMaster     5   	     � Title$  Bicycle Service��5
   	   $	��650��6!   $	��950��61    � Icon$&  /T-Bike;component/Image/logo.jpg��6@    � WindowStartupLocation$ CenterScreen=�6h   $	��350��6�   $	��550��6�   $	��477��6�   ��5      �� 5   
    �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .��5      � .+�5   
   �� $y�Visible=�6   $	��468��6)   $	��388��65   ���	#7F000000$��Center=�6S   $��Center=�6p    �� RadiusY$ 18.919��6�    �� RadiusX$ 18.919��6�   $��106,6,77,52q�6�   �� 5   
   -   5         ��Name$ 	CBBicycle��5       �� 
IsEditable .  �� IsTextSearchEnabled . $��Center=�6S   $��Center=�6p   $	��200��6�   $	��215��6�   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 
Bicycle...��5      
   UseFloatingWatermark
 . $��40��6�   $��142,20,296,393q�6�   $	��213��6�   �� 5   
   $��Center=�6   $��Center=�62   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��1��63   .+�5      �� $��Bicycle Name : ��6   
�������$��0,0,8,0q�6F   $
��Bold"�6W   $��14(�6i   �� 5      -   5         ��Name$ LBBicycleName��5      $�� ��63   
�������$��14(�6N   5      �� 5      $ 
Horizontal=�6   $��0,20,0,0q�63   $��1��6E   .+�5      �� $��Bicycle Status : ��6   
�������$��0,0,8,0q�6H   $
��Bold"�6Y   $��14(�6k   �� 5      -   5        $ LBStatus��5      $�� ��6.   
�������$��14(�6I   5      �� 5      $ 
Horizontal=�6   $��	0,20,0,10q�62   $��1��6E   .+�5      �� $��Condition : ��6   
�������$��0,0,46,0q�6C   $
��Bold"�6U   $��14(�6g   �� 5      -   5         ��Name$ TBCondition��5       �� TextWrapping$
 Wrap=�6/   $�� ��6C   $��200px��6K   $��300px��6\   $��57��6m   
���   �$��14(�6�    � Cursor$
 None��6�   $	��246��6�   5      �� 5      $ 
Horizontal=�6   $��0,20,0,0q�62   $��1��6D   .+�5       �� $��Service Start : ��6   
�������$��0,0,27,0q�6G   $
��Bold"�6Y   $��14(�6k   +   %MahApps.Metro.Controls.DateTimePicker  5!      -   5          Name$ 	PickStart��5!   *   $��200px��6=   $��20��6N   
���   �$��14(�6m   6{   5"      �� 5#      $ 
Horizontal=�6   $��0,20,0,0q�62   $��1��6D   .+�5$      �� $��Service End : ��6   
�������$��0,0,35,0q�6E   $
��Bold"�6W   $��14(�6i     5%      -   5        $ PickEnd��5%   *   $��200px��6;   $��20��6L   
���   �$��14(�6k   6y   5&      �� 5'      $ 
Horizontal=�6   $��0,20,0,0q�62   $��1��6D   $��69��6Q   .+�5(      �� $��Service Duration : ��6   
�������$��0,0,35,0q�6J   $
��Bold"�6\   $��14(�6n   �� 5)      -   5        $ 
LBDuration��5)      
�������$��0,0,35,0q�6C   $
��Bold"�6U   $��14(�6g   5+      5,      �� 5.   
   $y�Hidden=�6   $
��Left=�6)   $��Bottom=�6D   $��32��6_   $��67,0,0,0q�6k   $	��302��6}   $��1��6�   .+�5/      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 50      -   5        $ 
TLRankDesc��50      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��64,-33,19,18.667q�6�   �� 51      -	   5        $ 
TLUsername��51      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��136,-42,0,20q�6�   52      �� 53   
   -
   5        $��Send to Repair��53      $��Right=�6*   $��	0,0,10,10q�6F   $��Bottom=�6Y   $	��117��6t    J� RenderTransformOrigin$ 1.105,0.104&�6�   6�   �� 54   
   -   5        $��Return Service��54      $��Right=�6*   $��
0,0,145,10q�6F   $��Bottom=�6Z   $	��109��6u   $ 1.105,0.104&�6�   6�   57      58      