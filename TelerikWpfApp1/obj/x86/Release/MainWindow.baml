   M S B A M L   `   `   `  ���� H  DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  
 T-Bike   TBike.MainWindow   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  
MainWindow��$	��600��$
��1050�� � WindowStartupLocation$ CenterScreen=� � Icon$ Image/download.jpg�� � WindowState$ 	Maximized=�$	��588��$	��823��.��� ����  �� ImageSource$, &/T-Bike;component/Image/background.jpg��.+�&   System.Windows.Controls.DataGrid  -     Name$ 	dataGrid1��$y�Hidden=�$��Stretch=�$	��281��$��223,29,25,72q�$��Stretch=�$	��544�����	#7FA8A8A8���	#FF14568D$��2q�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Employee ID��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
EmployeeID+  $
 Name�� �� *EmployeeName+  $ Username�� �� *
Username+  $
 Rank�� �� *EmployeeRankDesc+  $ Address Location�� �� *	Address+  $ Email Address�� �� *Email+  $ Date Of Birth�� �� *DateOfBirth+  $ Phone Number�� �� *	PhoneNo+  $ 
Last Login�� �� *LastLoginTime+  $ 
Created By�� �� *	CreatedBy+  $ 
Created At�� �� *	CreatedAt+  $ Last Updated By�� �� *LastUpdatedBy+  $ Last Updated At�� �� *LastUpdatedAt+�� ���	#8D2B303B$��0,0,0,0q�$
��Left=�$��Stretch=�$��50��$	��192��.+�]� .+�9� -   	 9�Name$	 ExpanderRent��$��Renting��$��0,15,0,0q�
�������$��16(����	#FF2B303B���	#FF2B303B.��� 
 � ColumnDefinitions
 �� $��3* ��� $	��92* �.+��� ���	#19000000$��2��.+�]� $��10,10q�.+��� -   $��40��$��40�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  ���� $ Image/booking.png���� $
��Book��$��Center=�$��Center=�$��5,0,0,0q�]� $��10,10q�.+��� -   $��40��$��40��$��0q�   ���� $ Image/rent.jpg���� $
��Rent��$��Center=�$��Center=�$��5,0,0,0q�]� $��10,10q�.+��� -   $��40��$��40��   ���� $ Image/return.png���� $��Return��$��Center=�$��Center=�$��5,0,0,0q�]� $��10,10q�.+��� -   $��40��$��40��   ���� $ Image/Service.png���� $��Service��$��Center=�$��Center=�$��5,0,0,0q�]� .+�9� -   $	 ExpanderStore��$��Store��$��0,15,0,0q�$��Stretch=�
�������$��16(����	#FF2B303B���	#FF2B303B.��� .+��� .+�]� $��10,10q�.+��� -	   $��Right=�$��16(�$��Bottom=�$��36��$��36��$
��Left=�
�������
�������$
��Bold"�
 � Tag$ asdasd������ $ Image/box.jpg�� � ToolTip _� .���� .+��� $
��Bold"��� $�Inventory/Store Managing���� �� $&� Add new products/Modify products��   �� $��Store��$��Center=�$��Center=�$��5,0,0,0q�]� .+�9� -
   $	 ExpanderEmployee��$��Employee��$��0,15,0,0q�
�������$��16(����	#FF2B303B���	#FF2B303B.��� .+��� .+�]� $��10,10q�.+��� -    ��Name$ BTNEmployee��$��Right=�$��16(�$��Bottom=�$��36��$��36��$
��Left=�
�������
�������$
��Bold"����� $ Image/add.png�� _� .���� .+��� $
��Bold"��� $�Employee Menu���� �� $4�.Maintain Employee's Ranks/Create New Users/etc��   �� $��
Create New��$��Center=�$��Center=�$��5,0,0,0q�]� $��10,10q�.+��� -   $��Right=�$��16(�$��Bottom=�$��36��$��36��$
��Left=�
�������
�������$
��Bold"����� $ Image/Employeen.jpg�� _� .���� .+��� $
��Bold"��� $�Employee Menu���� �� $4�.Maintain Employee's Ranks/Create New Users/etc��   �� $��Promotion/Modify��$��Center=�$��Center=�$��5,0,0,0q�$��14(�]� .+�9� -   $	 ExpanderReports��$��
Statistics��$��0,15,0,0q�
�������$��16(����	#FF2B303B���	#FF2B303B.���� .+�]� $��10,10q�.+��� -   $�� ��$
��Left=�$��Center=�$��40��$��40��   ���� $ Image/stat.jpg���� $��Search��$��Center=�$��Center=�$��18(�]� $��10,10q�.+��� -   $�� ��$
��Left=�$��0,15,0,0q�$	��Top=�$��40��$��40��   ���� $ Image/stat.jpg���� $��Reports��$��Center=�$��Center=�$��18(��� -    J� Opacity$	 0.7Q�$�� ��$��Right=�$��	0,10,10,0q�$	��Top=�$��39��$��39������ $ Image/logo.jpg���� $
��Left=�$��Bottom=�$��32��$��	207,0,0,0q�$	��302��.+��� $
��Left=�$
��Wrap=�$��	Welcome, ��$��Bottom=�
�������$��0,0,0,17q�$
��Bold"��� -    ��Name$ 
TLRankDesc��$
��Left=�$
��Wrap=�$��
Not Found ��$��Bottom=�
�������$��80,-33,19,18.667q��� -   $ 
TLUsername��$
��Left=�$
��Wrap=�$��ID Not Found ��$��Bottom=�
�������$��178,-35,0,20q� � -     �Name$ 	Framework��$y�Hidden=�$�� ��$��Stretch=�$	��375��$��207,66,32,63q�$��Stretch=�$	��603��  � NavigationUIVisibility$ Hidden=�