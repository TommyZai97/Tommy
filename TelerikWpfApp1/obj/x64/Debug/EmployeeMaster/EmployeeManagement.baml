   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   
   A =T-Bike, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TelerikWpfApp1TelerikWpfApp1 5   	      TBike.EmployeeManagement   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   
   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TelerikWpfApp1     5   	     � Title$  EmployeeManagement��5
   	   $	��450��6$   $	��800��64    � WindowStartupLocation$ CenterScreen=�6C    � Icon$&  /T-Bike;component/Image/logo.jpg��6h   $��342.415��6�   $��582.627��6�   .��5      � ��5   
   �� 5       �� ImageSource$, &/T-Bike;component/Image/background.jpg��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5      $��Stretch=�6%   $	��281��6C   $��223,29,25,72q�6S   $��Stretch=�6i   $	��544��6�   ���	#7FA8A8A8���	#FF14568D$��2q�5   .      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
EmployeeID+  5      $
 Name��6%    63   �� *EmployeeName+  5      $ Username��6%    67   �� *
Username+  5      $
 Rank��6%    63   �� *EmployeeRankDesc+  5      $ Address Location��6%    6?   �� *	Address+  5      $ Email Address��6%    6<   �� *Email+  5      $ Date Of Birth��6%    6<   �� *DateOfBirth+  5      $ Phone Number��6%    6;   �� *	PhoneNo+  5      $ 
Last Login��6%    69   �� *LastLoginTime+  5      $ 
Created By��6%    69   �� *	CreatedBy+  5      $ 
Created At��6%    69   �� *	CreatedAt+  5      $ Last Updated By��6%    6>   �� *LastUpdatedBy+  5      $ Last Updated At��6%    6>   �� *LastUpdatedAt+5!      �� 5#   
   -   5        $
��View��5#      $
��12px(�6    $
��Left=�60   $��	22,29,0,0q�6K   $	��Top=�6^   $	��109��6v   $��34��6�   $��Calibri)�6�   $��Normal"�6�   �� 5$   
   -   5        $��BTNnew��5$      $
��12px(�6   $��	New Users��6/   $
��Left=�6C   $��
22,108,0,0q�6^   $	��Top=�6r   $	��109��6�   $��34��6�   $��Calibri)�6�   $��Normal"�6�   �� 5&   
   -   5         ��Name$ 
BTNSetRank��5&      $
��12px(�6%   $��
User Ranks��65   $
��Left=�6J   $��
22,186,0,0q�6e   $	��Top=�6y   $	��109��6�   $��34��6�   $��Calibri)�6�   $��Normal"�6�   �� 5'   
   -   5        $��
BTNPromote��5'      $y�Hidden=�6#   $��Modify/Promotion��67   $��Right=�6R   $��	0,0,10,10q�6n   $��Bottom=�6�   $	��143��6�    J� RenderTransformOrigin$ 1.009,0.562&�6�   6�   �� 5(   
   $y�Hidden=�6   $
��Left=�6*   $��Bottom=�6E   $��32��6`   $��94,0,0,0q�6l   $	��302��6~   .+�5)      �� $
��Left=�6   $
��Wrap=�63   $��	Welcome, ��6G   $��Bottom=�6X   
�������$��0,0,0,17q�6�   $
��Bold"�6�   �� 5*      -   5        $��
TLRankDesc��5*      $
��Left=�6,   $
��Wrap=�6G   $��
Not Found ��6[   $��Bottom=�6m   
�������$��80,-33,19,18.667q�6�   �� 5+      -   5        $��
TLUsername��5+      $
��Left=�6-   $
��Wrap=�6H   $��ID Not Found ��6\   $��Bottom=�6q   
�������$��178,-35,0,20q�6�   5,      5-      5.      