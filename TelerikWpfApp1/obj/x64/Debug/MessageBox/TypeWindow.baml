   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TBike.MessageBoxTBike.MessageBox 5   	   !   TBike.MessageBox.TypeWindow   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   @d2http://schemas.microsoft.com/expression/blend/2008     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TBike.MessageBox     5   	   -   5        (   "MahApps.Metro.Controls.MetroWindow    ShowIconOnTitleBar  .     ShowMaxRestoreButton .     ShowMinButton .   � 
ResizeMode$ NoResize=�5   	    � Title$ Confirm��5   	   $	��200��6   $	��488��6&   ���	#E5FFFFFF � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6c   .��5      �  � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        	 ��Name$	 imgIcon��5      $��0��6#   $��0��60   $��40��6@   $��40��6L   $��16,10,18,14q�6W   $��Center=�6m   $��Center=�6�   $*��$/T-Bike;component/Image/Question.png��6�   5      �� 5   
   -   5        
 ��Name$
 	tbMessage��5      ���	#FF4A4B57$��qweqwe��6>   $��0��6M   $��1��6Z   $��3��6j   $
��Left=�6~   $��15,31,15,15q�6�   $
��Wrap=�6�   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   �� 5   
   -   5         ��Name$ tbType��5      ���	#FF4A4B57$��2��6;   $��1��6L   $
��Left=�6\   $��	15,65,0,0q�6w   $	��Top=�6�   $
��Bold"�6�   $��14(�6�   .@�5      �� $��January��6   �� 5       $��February��6   �� 5!      $��March��6   �� 5"      $��April��6   �� 5#      $	��May��6   �� 5$      $
��June��6   �� 5%      $
��July��6   �� 5&      $��August��6   �� 5'      $��	September��6   �� 5(      $��October��6   �� 5)      $��November��6   �� 5*      $��December��6   5,      �� 5-   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��Bottom=�6>   $��Right=�6Y   $��0,0,0,10q�6u   $��1��6�   $��3��6�   .+�5.      �� -   5        $��BTNYes��5.      $��2��6#   $	��Yes��67   $��Bottom=�6E   $��Stretch=�6`   $��0,0,0,0q�6~   $��1��6�   $��60��6�   $��Regular"�5/      $��12(�6*   $��Normal$�68    K� Capitals$ Normal=�6K   6h   �� 50      -   5        $��BTNNo��50      $��2��6"   $��No��66   $��Stretch=�6C   $��1��6a   $
��10,0q�6n   $��Bottom=�6|   $��60��6�   $��Regular"�51      $��12(�6(   $��Normal$�66   $ Normal=�6I   6h   52      54      55      