   M S B A M L   `   `   `  ����A  =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TBikeTBike  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5   	       TBike.Booking   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:TBike     5   	   4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
      HwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit  5   	   k gTelerik.Windows.Documents.Core, Version=2018.3.904.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.RibbonView, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2018.3.911.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.ImageEditor, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Charting, Version=2018.3.911.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7s oTelerik.Windows.Controls.RichTextBoxUI, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p lTelerik.Windows.Controls.Navigation, Version=2018.3.911.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Qtelerik1http://schemas.telerik.com/2008/xaml/presentation
   	 
       5   	     � Title$  Create Booking Date��5   	   $	��500��6%   $	��800��65    � WindowStartupLocation$ CenterScreen=�6E    � Icon$&  /T-Bike;component/Image/logo.jpg��6j   $	��414��6�   $	��407��6�   .��5      � $��0,0,-8,0q�6    � ColumnDefinitions 5   
   �� 5      $
��139* �6   �� 5      $	��21* �6   ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   �� $��Stretch=�6   $	��210��63   $��
25,27,45,0q�6@   $��3��6T   
�������$	��Top=�6w   $	��500��6�    �� RadiusY$ 12.117��6�    �� RadiusX$ 12.117��6�   $��2��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dataGrid1��5   ;   
�������$��2q�6'   $��Stretch=�6O   $	��100��6m   $	��600��6}   $��Stretch=�6�   $	��500��6�   $��45,280,63,84q�6�   ���	#7FA8A8A8
���   �$��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        Column1��5   %     5       -   5        Column2��5    %     5!      -   5        Column3��5!   %     5"      -   5        Column4��5"   %     5#      -   5        Column5��5#   %     5$      -   5        Column6��5$   %     5%      -   5        Column7��5%   %     5&      -	   5        Column8��5&   %     5'      -
   5        Column9��5'   %     5(      -   5        Column10��5(   %   5,      +  %MahApps.Metro.Controls.DateTimePicker  5.   
   -   5        	  Name$	 	StartDate��5.   "   $��49��66   $	��282��6B   $	��400��6Q   $
��Left=�6`   $	��Top=�6{   
�������$��	45,38,0,0q�6�   �� 5/   
   -   5        
 ��Name$
 
TBCustomer��5/      $
��Left=�6'   $��32��6B    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��282��6z   $	��400��6�   $��
45,105,0,0q�6�   $��14(�6�   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Customer Name...��50      �� 52   
   -   5         ��Name$ CBBike��52       �� 
IsEditable .  �� SelectedValue$ 	BicycleID��6M    �� DisplayMemberPath$ BicycleName��6g   $��Right=�6�   $��	0,47,79,0q�6�   $	��Top=�6�   $	��215��6�   $ Selec Bicycle...��6�   $��40��6  $��14(�6  /  )MahApps.Metro.Controls.ScrollViewerHelper%   IsHorizontalScrollWheelEnabled . $��2��6�  ��65   �� 54      �� 56   
   -   5        $
 	TBRemarks��56      $
��Left=�6%   $��67��6@   $��
45,156,0,0q�6L   $
 Wrap=�6`   $	��Top=�6u   $	��200��57      %   IsSpellCheckContextMenuEnabled .    UseFloatingWatermark . $ 
Remarks...��6�      WatermarkAlignment$ Center=�6�      WatermarkTrimming$ CharacterEllipsis=�6�   $	��506��6/  �� 58   
   -   5        $
��Book��58      $��Right=�6    $��
0,198,79,0q�6<   $	��Top=�6P   $	��123��6h   $��25��6t   $��10(�6�   $��2��6�   �� 5:   
   $y�Hidden=�6   $
��Left=�6*   $��Bottom=�6E   $��32��6`   $��68,0,0,0q�6l   $	��302��6~   .+�5;      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5<      -   5         ��Name$ 
TLRankDesc��5<      $
��Left=�6.   $
��Wrap=�6I   $��
Not Found ��6]   $��Bottom=�6o   
�������$��80,-33,19,18.667q�6�   �� 5=      -   5        $ 
TLUsername��5=      $
��Left=�6/   $
��Wrap=�6J   $��ID Not Found ��6^   $��Bottom=�6s   
�������$��178,-35,0,20q�6�   5>      5C      5F      