   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TelerikWpfApp1TelerikWpfApp1 5   	      TBike.EmployeeRank   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TelerikWpfApp1     5   	     � Title$  Ranks Settings��5
   	   $	��450��6    $��412.924��6-    � WindowStartupLocation$ CenterScreen=�6=    � 
ResizeMode$ NoResize=�6b    � Icon$&  /T-Bike;component/Image/logo.jpg��6x   .��5      � ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   �� -   5        $
��Rect��5      $y�Hidden=�6    ���	#7FAA1D1D$��Center=�6E   $	��225��6b   $��
10,47,32,0q�6o   
���   �$	��Top=�6�   $	��296��6�   �� 5   
   -   5         ��Name$ 
TBRankDesc��5      $
��Left=�6&   $��22��6A   $��63,76,150,323q�6M    �� TextWrapping$
 Wrap=�6d   $��Center=�6y   $	��194��6�   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Rank Description��6�      WatermarkTrimming$ CharacterEllipsis=�6�   	 J� RenderTransformOrigin$	 0.575,-0.902&�6  �� 5   
   -   5        $ TBRankNo��5      $
��Left=�6Q   $��23��6l   $��63,138,150,257q�6x   $
 Wrap=�5      $��Center=�6'   $	��194��6B   $ Rank Level (1-10)��6N   $ CharacterEllipsis=�6�   $	 0.575,-0.902&�6�   �� 5   
   -   5        $��Apply��5      $
��Left=�6!   $��	60,0,0,91q�6<   $��Bottom=�6O   $��92��6j   6u   �� 5   
   -   5        
 ��Name$
 
CBRankDesc��5      $y�Hidden=�6'   $
��Left=�6;   $��63,75,150,323q�6V   $��Center=�6m   $	��194��6�      UseFloatingWatermark .  $ Rank Description��6�   �� 5   
   -   5        $��	BTNModify��5      $��Modify Existing��6"   $
��Left=�6<   $��
217,0,0,91q�6W   $��Bottom=�6k   $	��113��6�   6�   �� 5   
   -   5        $��LBModify��5      $
��Left=�6$   $��	10,10,0,0q�6?   $
��Wrap=�6R   $��Add Mode��6f   $	��Top=�6v   $
��Bold"�6�   $��Calibri)�6�   $��20(�6�   
�������$��	Underline{�6�   �� 5   
   -   5        $ TBRankDescModify��5      $y�Hidden=�6,   $��Center=�6@   $��23��6]   $
 Wrap=�6j   $��Center=�6   $	��194��6�   $ Rank Description��6�   $ CharacterEllipsis=�6�   $	 0.575,-0.902&�6  $��63,203,150,192q�6<  �� 5   
   $y�Hidden=�6   $
��Left=�6*   $��Bottom=�6E   $��32��6`   $��4,0,0,-1q�6l   $	��302��6~   .+�5      �� $
��Left=�6   $
��Wrap=�64   $��	Welcome, ��6H   $��Bottom=�6Y   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5      -	   5         ��Name$ 
TLRankDesc��5      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��64,-33,19,18.667q�6�   �� 5      -
   5        $ 
TLUsername��5      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��136,-42,0,20q�6�   5       5#      5$      