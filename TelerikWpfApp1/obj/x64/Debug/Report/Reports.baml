   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TBike.EmployeeMasterTBike.EmployeeMaster 5   	   "   TBike.EmployeeMaster.Reports   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TBike.EmployeeMaster     5   	   k gTelerik.Windows.Documents.Core, Version=2018.3.904.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.RibbonView, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2018.3.911.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.ImageEditor, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2018.3.911.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s oTelerik.Windows.Controls.RichTextBoxUI, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
    	 
      5	   	     � Title$  Detail Reports��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5   
   �  � ColumnDefinitions 5   
   �� 5      $
��148* �6   �� 5      $
��207* �6   �� 5      $
��270* �6   �� 5      $
��167* �6    � RowDefinitions 5   
   �� 5      $
��235* �6   �� 5      $
��184* �6   ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   �� -   5         ��Name$ TBShowTitle��5      
�������$��2��6<   $
��11px(�6P   $��Italic$�6`   �� 6t   $.�(Please Select a Bicycle type for results��6x   �� 6�   .F�5      �� -   5        $ TBMonth��5      $
��Wrap=�6-   $��	TextBlock��6A   $��20,0,0,0q�6R   $��DemiBold"�6d   5      6#   �� 5    
   -   5         ��Name$ ListBooking��5       $��2��6W   $��1��6h   ���	#A5FFFFFF$��0,20,0,0q�6�   �� 5!   
   $��1��6   $
��Left=�6%   $��	10,30,0,0q�6A   $	��Top=�6T   $	��195��6l   $	��181��6y   .+�5"      ��  �� Orientation$ 
Horizontal=�6   .+�5#      �� 
�������$��	BookingID��6/   $��14(�6@   $��DemiBold"�6N   $��0,0,23,0q�6d   �� 5$      -   5        $ TBBookID��5$      
�������$��No ID Found��6A   $��14(�6T   $��0,0,10,0q�6b   5%      �� 5&      $ 
Horizontal=�6   .+�5'      �� 
�������$��Bicycle��6/   $��14(�6>   $��DemiBold"�6L   $��0,5,48,0q�6b   �� 5(      -   5        $ TBBike��5(      
�������$��No ID Found��6?   $��14(�6R   $��0,5,10,0q�6`   5)      �� 5*      $ 
Horizontal=�6   .+�5+      �� 
�������$��Status��6/   $��14(�6=   $��DemiBold"�6K   $��0,5,52,0q�6a   �� 5,      -   5        $ TBBookStatus��5,      
�������$��No ID Found��6E   $��14(�6X   $��0,5,10,0q�6f   5-      �� 5.      $ 
Horizontal=�6   .+�5/      �� 
�������$��Bicycle Type��6/   $��14(�6C   $��DemiBold"�6Q   $��0,5,14,0q�6g   �� 50      -   5        $ 
TBBikeType��50      
�������$��No ID Found��6C   $��14(�6V   $��0,5,10,0q�6d   51      �� 52      $ 
Horizontal=�6   .+�53      �� 
�������$��Booked Date��6/   $��14(�6B   $��DemiBold"�6P   $��0,5,10,0q�6f   �� 54      -   5        $ 
TBBookDate��54      
�������$��No ID Found��6C   $��14(�6V   $��0,5,10,0q�6d   55      �� 56      $ 
Horizontal=�6   .+�57      �� 
�������$��
Start-Time��6/   $��14(�6A   $��DemiBold"�6O   $��0,5,25,0q�6e   �� 58      -	   5        $ TBStartTime��58      
�������$��No ID Found��6D   $��14(�6W   $��0,5,10,0q�6e   59      �� 5:      $ 
Horizontal=�6   .+�5;      �� 
�������$��End-Time��6/   $��14(�6?   $��DemiBold"�6M   $��0,5,31,0q�6c   �� 5<      -
   5        $ 	TBEndTime��5<      
�������$��No ID Found��6B   $��14(�6U   $��0,5,10,0q�6c   5=      �� 5>      $ 
Horizontal=�6   .+�5?      �� 
�������$��Add-On��6/   $��14(�6=   $��DemiBold"�6K   $��0,8,41,0q�6a   �� 5@      -   5         ��Name$ BTNAddon��5@      $��Check��6+   $��0,5,10,0q�6<   
���   �
�������$��45��6�   5B      5C      �� 5E   
   $��2��6   $
��Left=�6%   $��	10,30,0,0q�6A   $	��Top=�6T   $	��190��6l   $	��202��6y   .+�5F      �� $ 
Horizontal=�6   .+�5G      �� 
�������$��Deposit��6/   $��14(�6>   $��DemiBold"�6L   $��0,0,60,0q�6b   �� 5H      -   5        $ 	TBDeposit��5H      
�������$��No ID Found��6B   $��14(�6U   $��0,0,10,0q�6c   5I      �� 5J      $ 
Horizontal=�6   .+�5K      �� 
�������$��Customer��6/   $��14(�6?   $��DemiBold"�6M   $��0,5,49,0q�6c   �� 5L      -   5        $ 
TBCustomer��5L      
�������$��No ID Found��6C   $��14(�6V   $��0,5,10,0q�6d   5M      �� 5N      $ 
Horizontal=�6   .+�5O      �� 
�������$��Total Price��6/   $��14(�6B   $��DemiBold"�6P   $��0,5,45,0q�6f   �� 5P      -   5        $ TBTotalPrice��5P      
�������$��No ID Found��6E   $��14(�6X   $��0,5,10,0q�6f   5Q      �� 5R      $ 
Horizontal=�6   .+�5S      �� 
�������$��Remarks��6/   $��14(�6>   $��DemiBold"�6L   $��0,5,57,0q�6b   �� 5T      -   5        $ TBRemark��5T      
�������$��No ID Found��6A   $��14(�6T   $��0,5,10,0q�6b   5U      �� 5V      $ 
Horizontal=�6   .+�5W      �� 
�������$��
Created By��6/   $��14(�6A   $��DemiBold"�6O   $��0,5,43,0q�6e   �� 5X      -   5        $ TBCreatedBy��5X      
�������$��No ID Found��6D   $��14(�6W   $��0,5,10,0q�6e   5Y      �� 5Z      $ 
Horizontal=�6   .+�5[      �� 
�������$��
Created At��6/   $��14(�6A   $��DemiBold"�6O   $��0,5,45,0q�6e   �� 5\      -   5        $ TBCreatedAt��5\      
�������$��No ID Found��6D   $��14(�6W   $��0,5,10,0q�6e   5]      �� 5^      $ 
Horizontal=�6   .+�5_      �� 
�������$��Last Updated By��6/   $��14(�6F   $��DemiBold"�6T   $��0,5,10,0q�6j   �� 5`      -   5        $ TBLastUpdatedBy��5`      
�������$��No ID Found��6H   $��14(�6[   $��0,5,10,0q�6i   5a      �� 5b      $ 
Horizontal=�6   .+�5c      �� 
�������$��Last Updated At��6/   $��14(�6F   $��DemiBold"�6T   $��0,5,10,0q�6j   �� 5d      -   5        $ TBLastUpdatedAt��5d      
�������$��No ID Found��6H   $��14(�6[   $��0,5,10,0q�6i   5e      5f      �� 5g   
   $��1��6   $��1��6%   $	��Top=�62   $
��Left=�6J   $��90��6e   $	��160��6q   .+�5i      �� -   5        $ 
BTNPayment��5i      $��Monthly Earnings��6)   $	��150��6D   $��35��6P   $��	10,10,0,0q�6\   $��DemiBold"�6o   6�   �� 5j      -   5        $ BTNTotalRent��5j      $��Total Rents This Month��6+   $	��150��6L   $��35��6X   $��	10,10,0,0q�6d   $��DemiBold"�6w   6�   5k      �� 5l   
   -   5        $��
MonthStack��5l      $y�Hidden=�6'   $��2��6;   $��1��6L   .+�5m      �� $ 
Horizontal=�6   .+�5n      �� $��DemiBold"�6   $��14(�62   $
��Left=�6A   $��	10,10,0,0q�6\   $
��Wrap=�6o   $��Monthly Earnings��6�   $	��Top=�6�   
�������$��19��6�   $	��112��6�   �� 5o      -   5        $��	TBMonthly��5o      $��14(�6-   $
��Left=�6<   $��	10,10,0,0q�6W   $
��Wrap=�6j   $��Rm 0.00��6~   $	��Top=�6�   
�������$��19��6�   $	��112��6�   5q      5r      �� 5s   
   -   5        $��	RentStack��5s      $y�Hidden=�6&   $��2��6:   $��1��6K   .+�5t      �� $ 
Horizontal=�6   .+�5u      �� $��DemiBold"�6   $��14(�62   $
��Left=�6A   $��	10,10,0,0q�6\   $
��Wrap=�6o   $��Monthly Rent��6�   $	��Top=�6�   
�������$��19��6�   $	��112��6�   �� 5v      -   5        $��TBMonthlyRents��5v      $��14(�62   $
��Left=�6A   $��	10,10,0,0q�6\   $
��Wrap=�6o   $��ERROR:!@#!@#��6�   $	��Top=�6�   
�������$��19��6�   $	��112��6�   5x      5y      �� 5z   
   $��3��6   $��0,20,0,0q�6%   .+�5{      �� $��DemiBold"�6   $��14(�6.   $
��Left=�6=   $��	10,10,0,0q�6X   $
��Wrap=�6k   $	��Top=�6   
�������$	��137��6�   Most Rented Bike:5}      �� 5~      -   5        $��
TBMostBook��5~      $��14(�6*   $
��Left=�69   $��10,0,0,0q�6T   $
��Wrap=�6f   $��ERROR:!@#!@#��6z   $	��Top=�6�   
�������$��19��6�   $	��112��6�   �� 5      $��DemiBold"�6   $��14(�6.   $
��Left=�6=   $��	10,10,0,0q�6X   $
��Wrap=�6k   $	��Top=�6   
�������$	��147��6�   Most Rented Type:5�      �� 5�      -   5        $��
TBBookType��5�      $��14(�6*   $
��Left=�69   $��10,0,0,0q�6T   $
��Wrap=�6f   $��ERROR:!@#!@#��6z   $	��Top=�6�   
�������$��19��6�   $	��112��6�   5�      5�      5�      