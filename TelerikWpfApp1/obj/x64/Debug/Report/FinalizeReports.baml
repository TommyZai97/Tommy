   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TBike.EmployeeMasterTBike.EmployeeMaster 5   	   *   $TBike.EmployeeMaster.FinalizeReports   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TBike.EmployeeMaster     5   	     � Title$  Search Function��5	   	   $	��500��6!   $	��900��61    � Icon$&  /T-Bike;component/Image/logo.jpg��6@   $��822.864��6�   .��5      �  J� Opacity$	 0.9Q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5         
IsReadOnly . $��Stretch=�66   $	��244��6T   $��10,215,10,61q�6d   $��Stretch=�6z   $	��772��6�   ���	#7F838383   AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Column1��5   %     5      -   5        Column2��5   %     5      -   5        Column3��5   %     5      -   5        Column4��5   %     5      -   5        Column5��5   %     5      -   5        Column6��5   %     5      -   5        Column7��5   %     5      -	   5        Column8��5   %     5      -
   5        Column9��5   %     5      -   5        Column10��5   %   5      �� 5   
   -   5        $��	BTNsearch��5       �� 	IsDefault . $��Search��63   $��Right=�6D   $	��Top=�6`   $	��100��6x   $��
0,177,10,0q�6�   $��33��6�   $��Calibri)�6�   $��14(�6�   �� 5   
   -   5         ��Name$ CBMode��5       �� SelectedValuePath$ Content��6$   $
��Left=�6@   $	��Top=�6[   $	��250��6s   $��	10,10,0,0q�6   *   $MahApps.Metro.Controls.TextBoxHelper	   	Watermark$
	 Mode��6�   .@�5      �� $��Employee��6   �� 5      $��Service��6   �� 5       $��Bicycle��6   �� 5!      $��Booking��6   �� 5"      $��Snacks��6   5$      �� 5%   
   -   5        $��	StackBike��5%      $y�Hidden=�6&   $
��Left=�6:   $	��Top=�6U   $��10,46,269,0q�6m   $	��613��6�   .+�5)      �� 
 �� Orientation$
 
Horizontal=�6   .+�5*      �� $
��Left=�6   $
��Wrap=�67   $��ID��6K   $	��Top=�6U    J� RenderTransformOrigin$ -0.172,0.463&�6m   
�������$
��Bold"�6�   �� 5+      -   5         ��Name$ TBBicycleID��5+      $
��Left=�6/   $��23��6J    �� TextWrapping$
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��195��6�   $��88,0,0,0q�6�   $	 ID��6�   �� 5,      $��Right=�6   $
��Wrap=�68   $��Bicycle Name��6L   $��Center=�6`   $ -0.172,0.463&�6{   
�������$
��Bold"�6�   $��15,0,0,0q�6�   �� 5-      -   5        $ TBBikeName2��5-      $
��Left=�60   $��23��6K    �� Text$  ��6Y   $	��Top=�6a   $	��195��6y   $��10,0,0,0q�6�   $	 Booking Name��6�   5/      �� 50      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�51      �� $
��Left=�6   $
��Wrap=�68   $��Current Renter��6L   $	��Top=�6b   $ -0.172,0.463&�6z   
�������$
��Bold"�6�   �� 52      -   5        $ TBCurrentRenter��52      $
��Left=�63   $��23��6N   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��194��6�   $	 Current Renter��6�   $��19,0,0,0q�6�   �� 54      $��Right=�6   $
��Wrap=�68   $��Bicycle Color��6L   $��Center=�6a   $ -0.172,0.463&�6|   
�������$
��Bold"�6�   $��16,0,0,0q�6�   �� 55      -   5        $ TBBikeColor��55      $
��Left=�6/   $��23��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��195��6�   $��12,0,0,0q�6�   $	 Bicycle Color��6�   56      �� 57      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�58      �� $
��Left=�6   $
��Wrap=�68   $��Bicycle Status��6L   $	��Top=�6b   $ -0.172,0.463&�6z   
�������$
��Bold"�6�   �� 59      -   5        $ TBBikeStatus��59      $
��Left=�61   $��23��6L   $  ��6Y   $	��Top=�6a   $	��194��6y   $	 Bicycle Status��6�   $��24,0,0,0q�6�   .@�5:      �� $��Active��6#   �� 5;      $��Expired��6#   �� 5<      $��Not Returned��6#   �� 5=      $��	Succesful��6#   �� 5>      $��Renting��6#   �� 5?      $��Inactive��6#   �� 5@      $��Maintainence��6#   5A      5C      �� 5D      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5E      �� $
��Left=�6   $
��Wrap=�68   $��Bicycle Type��6L   $	��Top=�6`   $ -0.172,0.463&�6x   
�������$
��Bold"�6�   �� 5F      -   5        $ TBBikeType2��5F      $
��Left=�6/   $��23��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��194��6�   $	 Bicycle Type��6�   $��34,0,0,0q�6�   5H      5I      �� 5K   
   -   5        $��StackEmp��5K      $y�Hidden=�6%   $
��Left=�69   $	��Top=�6T   $��10,46,269,0q�6l   $	��613��6�   .+�5N      �� $
 
Horizontal=�6   .+�5O      �� $
��Left=�6   $
��Wrap=�67   $��ID��6K   $	��Top=�6U   $ -0.172,0.463&�6m   
�������$
��Bold"�6�   �� 5P      -   5        $
 TBID��5P      $
��Left=�6(   $��23��6C   $
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��195��6�   $��50,0,0,0q�6�   $	 ID��6�   �� 5Q      $��Right=�6   $
��Wrap=�68   $��Rank Description��6L   $��Center=�6d   $ -0.172,0.463&�6   
�������$
��Bold"�6�   $��11,0,0,0q�6�   �� 5R      -   5        $ 
TBRankDesc��5R      $
��Left=�6.   $��23��6I   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��195��6�   $��10,0,0,0q�6�   $	 Rank Description��6�   5T      �� 5U      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5V      �� $
��Left=�6   $
��Wrap=�68   $
��Name��6L   $	��Top=�6X   $ -0.172,0.463&�6p   
�������$
��Bold"�6�   �� 5W      -   5        $ TBName��5W      $
��Left=�6*   $��23��6E   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��194��6�   $
	 Name��6�   $��30,0,0,0q�6�   �� 5Y      $��Right=�6   $
��Wrap=�68   $��
Created By��6L   $��Center=�6^   $ -0.172,0.463&�6y   
�������$
��Bold"�6�   $��11,0,0,0q�6�   �� 5Z      -   5        $ TBCreatedBy��5Z      $
��Left=�6/   $��23��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��195��6�   $��46,0,0,0q�6�   $	 
Created By��6�   5[      �� 5\      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5]      �� $
��Left=�6   $
��Wrap=�68   $��Address��6L   $	��Top=�6[   $ -0.172,0.463&�6s   
�������$
��Bold"�6�   �� 5^      -   5        $ 	TBAddress��5^      $
��Left=�6-   $��23��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��194��6�   $	 Address��6�   $��18,0,0,0q�6�   �� 5_      $��Right=�6   $
��Wrap=�68   $��Email��6L   $��Center=�6Y   $ -0.172,0.463&�6t   
�������$
��Bold"�6�   $��11,0,0,0q�6�   �� 5`      -   5        $ TBEmail��5`      $
��Left=�6+   $��23��6F   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��195��6�   $��78,0,0,0q�6�   $	 Email Address��6�   5b      5d      �� 5e   
   -   5        $��	StackBook��5e      $y�Hidden=�6&   $
��Left=�6:   $	��Top=�6U   $��10,46,269,0q�6m   $	��613��6�   .+�5i      �� $
 
Horizontal=�6   .+�5j      �� $
��Left=�6    $
��Wrap=�6;   $��ID��6O   $	��Top=�6Y   $ -0.172,0.463&�6q   
�������$
��Bold"�6�   �� 5k      -   5        $ TBBookID��5k      $
��Left=�60   $��23��6K   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��195��6�   $��88,0,0,0q�6�   $	 ID��6�   �� 5l      $
��Left=�6   $
��Wrap=�68   $��Customer��6L   $	��Top=�6\   $ -0.172,0.463&�6t   
�������$
��Bold"�6�   $��10,0,0,0q�6�   �� 5m      -   5        $ 
TBCustomer��5m      $
��Left=�6.   $��23��6I   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��194��6�   $	 Customer��6�   $��48,0,0,0q�6�   5o      �� 5p      $
 
Horizontal=�6   $��0,11,0,0q�66   .+�5r      �� $��Right=�6    $
��Wrap=�6<   $��Bicycle��6P   $��Center=�6_   $ -0.172,0.463&�6z   
�������$
��Bold"�6�   �� 5s      -   5        $ 
TBBikeName��5s      $
��Left=�63   $��23��6N   $  ��6[   $	��Top=�6c   $	��195��6{   $��64,0,0,0q�6�   $	 Bicycle��6�   �� 5t      $
��Left=�6   $
��Wrap=�68   $��Booking Status��6L   $	��Top=�6b   $ -0.172,0.463&�6z   
�������$
��Bold"�6�   $��10,0,0,0q�6�   �� 5u      -    5        $ TBBookingStatus��5u      $
��Left=�64   $��23��6O   $  ��6\   $	��Top=�6d   $	��194��6|   $	 Booking Status��6�   $��16,0,0,0q�6�   .@�5v      �� $��Active��6#   �� 5w      $��Expired��6#   �� 5x      $��Not Returned��6#   �� 5y      $��	Succesful��6#   �� 5z      $��Renting��6#   5|      5~      �� 5      $
 
Horizontal=�6   $��0,11,0,0q�66   .+�5�      �� $
��Left=�6    $
��Wrap=�6<   $��Remark��6P   $	��Top=�6^   $ -0.172,0.463&�6v   
�������$
��Bold"�6�   �� 5�      -!   5        $ 	TBRemarks��5�      $
��Left=�61   $��23��6L   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��194��6�   $	 Remark��6�   $��60,0,0,0q�6�   �� 5�      $
��Left=�6   $
��Wrap=�68   $��Booking Date��6L   $	��Top=�6`   
�������$
��Bold"�6�   $��10,0,0,0q�6�   (  "System.Windows.Controls.DatePicker  5�      -"   5          Name$ DPBook��5�      $��Stretch=�6-   $��26,0,0,0q�6K   $	��194��6]   5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�66   .+�5�      �� $
��Left=�6    $
��Wrap=�6<   $��Bicycle Type��6P   $	��Top=�6d   $ -0.172,0.463&�6|   
�������$
��Bold"�6�   �� 5�      -#   5        $ 
TBBikeType��5�      $
��Left=�62   $��23��6M   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��194��6�   $	 Bicycle Type��6�   $��34,0,0,0q�6�   5�      5�      �� 5�   
   -$   5        $��
StackSnack��5�      $y�Hidden=�6'   $
��Left=�6;   $	��Top=�6V   $��10,46,269,0q�6n   $	��613��6�   .+�5�      �� $
 
Horizontal=�6   .+�5�      �� $
��Left=�6   $
��Wrap=�67   $��ID��6K   $	��Top=�6U   $ -0.172,0.463&�6m   
�������$
��Bold"�6�   �� 5�      -%   5        $ 	TBSnackID��5�      $
��Left=�6-   $��23��6H   $
 Wrap=�6U   $�� ��6i   $	��Top=�5�      $	��195��62   $��78,0,0,0q�6>   $	 Snack ID��6P   5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5�      �� $
��Left=�6   $
��Wrap=�67   $��
Snack Name��6K   $��Center=�6]   
�������$
��Bold"�6�   $��0,0,0,0q�6�   �� 5�      -&   5        $ TBSnackName��5�      $
��Left=�6/   $��23��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�5�      $	��195��62   $��21,0,0,0q�6>   $	 
Snack Name��6P   5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5�      �� $
��Left=�6   $
��Wrap=�68   $��
Snack Type��6L   $	��Top=�6^   $ -0.172,0.463&�6v   
�������$
��Bold"�6�   �� 5�      -'   5        $ TBSnackType��5�      $
��Left=�6/   $��23��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�5�      $	��194��62   $	 
Snack Type��6>   $��28,0,0,0q�6l   5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5�      �� $
��Left=�6   $
��Wrap=�68   $��Snack Status��6L   $	��Top=�6`   $ -0.172,0.463&�6x   
�������$
��Bold"�6�   $��0,0,0,0q�6�   �� 5�      -(   5        $ TBSnackStatus��5�      $
��Left=�62   $��23��6M   $	��Top=�6Z   $	��194��6r   $	 Snack Status��6~   $��20,0,0,0q�6�   .@�5�      �� $��Active��6#   �� 5�      $��InActive��6#   �� 5�      $��Out Of Stock��6#   5�      5�      5�      �� 5�   
   -)   5        $��StackService��5�      $y�Hidden=�6)   $
��Left=�6=   $	��Top=�6X   $��10,46,269,0q�6p   $	��613��6�   .+�5�      �� $
 
Horizontal=�6   .+�5�      �� $
��Left=�6   $
��Wrap=�67   $��ID��6K   $	��Top=�6U   $ -0.172,0.463&�6m   
�������$
��Bold"�6�   �� 5�      -*   5        $ TBServiceId��5�      $
��Left=�6/   $��23��6J   $
 Wrap=�6W   $�� ��6k   $	��Top=�6s   $	��195��6�   $��86,0,0,0q�6�   $	 Snack ID��6�   5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5�      �� $
��Left=�6   $
��Wrap=�67   $��Bicycle��6K   $��Center=�6Z   
�������$
��Bold"�5�   .   $��0,0,0,0q�6@   �� 5�      -+   5        $ 	TBBicycle��5�      $
��Left=�6.   $��23��6I   $	��Top=�6V   $	��195��6n   $��60,0,0,0q�6z   $	 
Snack Name��6�   5�      5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5�      �� $
��Left=�6   $
��Wrap=�68   $��Remark��6L   $	��Top=�6Z   $ -0.172,0.463&�6r   
�������$
��Bold"�6�   �� 5�      -,   5        $ TBServiceRemark��5�      $
��Left=�63   $��23��6N   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��194��6�   $	 
Snack Type��6�   $��56,0,0,0q�6�   5�      �� 5�      $
 
Horizontal=�6   $��0,11,0,0q�62   .+�5�      �� $
��Left=�6   $
��Wrap=�68   $��Service Status��6L   $	��Top=�6b   
�������$
��Bold"�6�   $��0,0,0,0q�6�   �� 5�      --   5        $ TBServiceStatus��5�      $
��Left=�64   $��23��6O   $	��Top=�6\   $	��194��6t   $	 Snack Status��6�   $��20,0,0,0q�6�   .@�5�      �� $��	Succesful��6#   �� 5�      $��InActive��6#   �� 5�      $��Maintenance��6#   5�      5�      5�      �� 5�   
   $
��Left=�6   $	��Top=�60   $��
-52,46,0,0q�6H   �� 5�   
   $y�Hidden=�6   $
��Left=�6)   $��Bottom=�6D   $��32��6_   $��66,0,0,0q�6k   $	��302��6}   .+�5�      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5�      -.   5         ��Name$ 
TLRankDesc��5�      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��64,-33,19,18.667q�6�   �� 5�      -/   5        $ 
TLUsername��5�      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��136,-42,0,20q�6�   5�      �� 5�   
   -0   5         ��Name$ ProgressPanel��5�      $y�Hidden=�6,   $��Center=�6@   $��Center=�6]   ���	#B2000000.+�5�   
   � -1   5         �Name$ PBsearch��5�      $��Center=�6)   $��Center=�6F   $	��400��6a   $��30��6m   $��10q�6y   �� 5�      -2   5        $ TBProgressText��5�      
�������$��Center=�6C   $��Center=�6`   $��
0,10,10,10q�6{   $	��150��6�   $��14(�6�   5�      5�      5�      