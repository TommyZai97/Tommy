   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TelerikWpfApp1TelerikWpfApp1 5   	      TBike.rental   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   .localclr-namespace:TelerikWpfApp1     5   	     � Title$  Rent Processing��5
   	   $	��450��6!   $	��800��61    � WindowStartupLocation$ CenterScreen=�6@    � Icon$&  /T-Bike;component/Image/logo.jpg��6e   $	��589��6�   $	��197��6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��50* �6   �� 5      $	��49* �6   ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   �� -   5         ��Name$
 rect��5      $��Right=�6"   $��Stretch=�6?   $	��317��6[   $	��600��6j   ���	#7F000000$y�Hidden=�6�   $	��369��6�   $��2��6�   $��1��6�   �� 5   
   -   5         ��Name$ CBBike��5       �� IsTextSearchEnabled .  �� 
IsEditable . $
��Left=�6P   $��	29,41,0,0q�6k   $	��Top=�6~   $	��206��6�   $��23��6�   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$	 Reserved Customers...��6�   ]� 5   
   $
��Left=�6   $	��Top=�6/   $��	30,80,0,0q�6G   $��34��6Z   $	��315��6f   .+�5      '   !MahApps.Metro.Controls.TimePicker  -   5        
  Name$
 TPStart��5   "   $��34��63   $	��150��6?   $
��Left=�6K   $	��Top=�6g   $	 Select starting time��6     5      -   5        $
 TPEnd��5   "   $��34��61   $	��150��6=   $
��Left=�6I   $��15,0,0,0q�6d   $	��Top=�6v   $	 Select ending time��6�   5      �� 5   
   -   5         ��Name$ 
TBCustomer��5      $
��Left=�6&   $��23��6A   $��
29,185,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��158��6�   $	 New Customer...��6�   �� 5   
   -   5        $ 	CBBicycle��5      $
��Left=�6&   $��
29,224,0,0q�6A   $	��Top=�6U   $	��158��6m   $��23��6y   $	 Bicycle��6�    J� RenderTransformOrigin$ 0.539,-0.561&�6�   �� 5   
   -   5         ��Name$ BTNNext��5      $
��Next��6"   $
��Left=�61   $��	30,0,0,26q�6L   $��Bottom=�6_   $	��110��6z   $��14(�6�   $��Calibri)�6�   $��33��6�   �� 5   
   $
��Left=�6   $��	29,20,0,0q�6/   $
��Wrap=�6B   $-��'Select Customer if there is any booking��6V   $	��Top=�6�   
�������$��Italic$�6�   $��	Underline{�6�   $��16��6�   $	��201��6�   �� 5    
   -   5         ��Name$ 
LBNewTitle��5       $
��Left=�6(   $��
29,149,0,0q�6C   $
��Wrap=�6W   $��New Customer��6k   $	��Top=�6   
�������$��	Underline{�6�   $
��Bold"�6�   $��18(�6�   $��24��6�   $	��125��6�   �� 5!   
   $y�Hidden=�6   $
��Left=�6*   $��Bottom=�6E   $��32��6`   $��94,0,0,0q�6l   $	��302��6~   $��1��6�   .+�5"      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5#      -	   5        $ 
TLRankDesc��5#      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��80,-33,19,18.667q�6�   �� 5$      -
   5        $ 
TLUsername��5$      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��178,-35,0,20q�6�   5%      �� 5(   
   -   5        $ BTNRent��5(      $
��Rent��6"   $��Right=�61   $��Bottom=�6N   $��89��6i   $��	0,0,29,25q�6t   $��33��6�   $��12(�6�   $��1��6�   $��1��6�   �� 5*   
   -   5        $��stack1��5*      $y�Hidden=�6#   $��Right=�67   $��Stretch=�6S   $	��369��6o   $��2��6{   $��1��6�   .+�5,      ��  �� Orientation$ 
Horizontal=�6   .+�5.      �� -   5        $	 LB1��5.      $��Right=�6)   $
��Wrap=�6E   $��Customer Name :��6Y   $	��Top=�6p   
�������$��16(�6�   $
��Bold"�6�   $y�Visible=�6�   $��
10,50,0,50q�6�   ��6�   Z� 6�   �� 5/      -   5        $ 
LBCustomer��5/      $��Right=�60   $��	15,50,0,0q�6L   $
��Wrap=�6_   $��	TextBlock��6s   $	��Top=�6�   
�������$��16(�6�   $y�Visible=�6�   ��6�   Z� 6�   50      �� 51      $ 
Horizontal=�6   .+�52      �� -   5        $	 LB2��52      $��Right=�6)   $
��Wrap=�6E   $��Booking Date :��6Y   $	��Top=�6o   
�������$��16(�6�   $
��Bold"�6�   $y�Visible=�6�   $��	10,0,0,50q�6�   ��6�   Z� 6�   �� 53      -   5        $ LBBookingDate��53      $��Right=�63   $
��Wrap=�6O   $��	TextBlock��6c   $	��Top=�6t   
�������$��16(�6�   $y�Visible=�6�   $��34,0,0,0q�6�   54      �� 55      $ 
Horizontal=�6   .+�56      �� -   5        $	 LB3��56      $��Right=�6*   $
��Wrap=�6G   $��	Bicycle :��6[   $	��Top=�6l   
�������$��16(�6�   $
��Bold"�6�   $y�Visible=�6�   $��	10,0,0,30q�6�   ��6�   Z� 6�   �� 57      -   5        $ LBBike��57      $��Right=�6,   $
��Wrap=�6I   $��	TextBlock��6]   $	��Top=�6n   
�������$��16(�6�   $y�Visible=�6�   $��85,0,0,0q�6�   58      �� 59      -   5        $ 	TBRemarks��59      $��Stretch=�6)   $��86��6G   $
 Wrap=�6T   $	��Top=�6i   $	��277��6�   $	��500��6�   $ 0.434,0.043&�6�   %   IsSpellCheckContextMenuEnabled .    UseFloatingWatermark . $	 
Remarks...��5:   @      WatermarkAlignment$ Center=�6n      WatermarkTrimming$ CharacterEllipsis=�6�   $y�Visible=�6�   $��	20,0,17,0q�6�   .��6  z�5;      V� 5<      .~�5=      �� �� 5>       �� AngleY$ -0.307Q�6(   �� 5?      T� 5@       T� Y$ -0.542Q�6-   5A      .��5B   +   5C      5E      �� 5F   
   -   5         ��Name$ CheckSnacks��5F      $��AddOn Snacks��6(   
�������$
��Left=�6R   $��
240,44,0,0q�6m   $	��Top=�6�   $��15��6�   $��97��6�   �� 5G   
   -   5         ��Name$ 
SnackPanel��5G   )   $y�Hidden=�6   $��1��6=   $��0��6N   $
��Left=�6^   $	��Top=�6y   $��54��6�   $	��250��6�   $��
-1,252,0,0q�6�   .+�5H      �� $��Add On Snacks��6   
�������$��30,0,0,0q�6@   $
��14px(�6R   $��DemiBold"�6b   $��	Underline{�6x   �� 5I      $ 
Horizontal=�6   .+�5J      �� -   5        $ CBSnack��5J      $��150px��6,   $��30,5,0,0q�6:   $��30��6M   $	 Snacks��6Y   �� 5K      -   5        $ 
TBQuantity��5K      $��60��6.   $��25��6<   $��10,0,0,0q�6H   $	 Amount��6�   5L      5N      5O      5Q      