   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TelerikWpfApp1TelerikWpfApp1 5   	      TBike.InventoryManage   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TelerikWpfApp1     5   	     � Title$  InventoryManage��5   	   $	��450��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:    � Icon$&  /T-Bike;component/Image/logo.jpg��6_    � WindowState$ 	Maximized=�6�   .��5      � ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   �� -   5         ��Name$ button��5      $�� ��6   $
��Left=�6,   $��	10,0,0,10q�6G   $��Bottom=�6Z   $��38��6u   $��38��6�   ��5      �� 5      $% /T-Bike;component/Image/bck.png��6    � ToolTip 5      _� 5      .��5      �� .+�5      �� $
��Bold"�6$   Back to Main Menu6I   5      5      5      &   System.Windows.Controls.DataGrid  5    
   -   5        $��	dataGrid1��5    r      AutoGenerateColumns .  $	��276��6/   $��Stretch=�6?   $��22,80,10,61q�6]   $��Stretch=�6�   $	��745��6�   ���	#7F9E9E9E$��2q�5!   )   ���	#FF4AA0A8   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      -   5        Column1��5#   %     5$      -   5        Column2��5$   %     5%      -   5        Column3��5%   %     5&      -   5        Column4��5&   %     5'      -   5        Column5��5'   %     5(      -   5        Column6��5(   %     5)      -	   5        Column7��5)   %     5*      -
   5        Column8��5*   %     5+      -   5        Column9��5+   %     5,      -   5        Column10��5,   %     5-      -   5        Column11��5-   %     5.      -   5        Column12��5.   %   51      ]� 52   
   $��58��6   $	��Top=�6    $��Stretch=�68   $��	22,10,0,0q�6V   $	��745��6i   .+�53      �� 	 �� CornerRadius$	 6��6   ���	#FF4AA0A8���	#7F205480$��2q�6U   $	��Top=�6i   $��0,0,10,0q�6~   ._�55      �� 
 �� Orientation$
 
Horizontal=�6   .+�56      �� -   5        $
��Left=�56      $	��Top=�68   $��40��6P   $��40��6[   $��30,6,0,0q�6|    J� Effect 57      3  -System.Windows.Media.Effects.DropShadowEffect  58       5:      _� 5;      .��5<   "   �� .+�5=   &   �� $
��Bold"�60   Bicycle Mode6P   �� 5>   &   Modify or Add6@   5?   #   5@      ��5B      �� 5C      $&  /T-Bike;component/Image/bike.png��6)   5E      �� 5G      -   5        $�� ��5G      $
��Left=�6(   $	��Top=�6D   $��40��6\   $��40��6g   $��39,6,0,0q�6�    5H        5I      ��5K      �� 5L      $' !/T-Bike;component/Image/snack.png��6)    5N      _� 5O      .��5P   "   �� .+�5Q   &   �� $
��Bold"�60   
Snack Mode6N   �� 5R   &   Modify or Add6@   5S   #   5T      5V      5W      5X      5Y      �� 5Z   
   $
��Left=�6   $��Bottom=�60   $��32��6K   $��66,0,0,0q�6W   $	��302��6i   .+�5[      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5\      -   5         ��Name$ 
TLRankDesc��5\      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��64,-33,19,18.667q�6�   �� 5]      -   5        $ 
TLUsername��5]      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��136,-42,0,20q�6�   5^      �� 5_   
   -   5        $�� ��5_      $��Right=�6   $��	0,0,10,10q�68   $��Bottom=�6K   $��32��6f   $��32��6r    J� RenderTransformOrigin$ -0.505,0.231&�6�   
���������6�   Z� ��5`      �� 5a      $% /T-Bike;component/Image/add.png��6    5c      _� 5d      .��5e      �� .+�5f      �� $
��Bold"�6$   	Add New6?   5h      5i      5k      5o      5p      