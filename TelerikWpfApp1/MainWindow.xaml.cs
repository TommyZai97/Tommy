﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using TBike.EmployeeMaster;
using TBike.BookingMaster;
using TBike.Report;
using System.Windows.Threading;
using TBike.MessageBox;
namespace TBike
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {


        public int RankID { get; set; }
        string username;
        string id;
        string self;

        public int MyValue { get; set; }
        public MainWindow()
        {
           
            InitializeComponent();
          

            PopulateDataFromLogin("");
            CalculateDoneRentedTime();
            PopulateDataGrid();
            Notification();

          
        }

        public void Notification()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            MyDAL.bindListBoxCustomer(LBRent);
            button.Content = "Current Bookings" + " (" + LBRent.Items.Count.ToString() + ")";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F11 && this.ShowTitleBar == true)
            {

                WindowState = WindowState.Maximized;
                ResizeMode = ResizeMode.NoResize;
                this.ShowTitleBar = false;
                this.ShowMaxRestoreButton = false;
                this.ShowCloseButton = false;
                this.ShowMinButton = false;
                this.ShowInTaskbar = false;
                this.IgnoreTaskbarOnMaximize = true;
            }
            else if (e.Key == Key.F11 && this.ShowTitleBar == false)
            {
                WindowState = WindowState.Normal;
                ResizeMode = ResizeMode.CanResize;
                this.ShowTitleBar = true;
                this.ShowMaxRestoreButton = true;
                this.ShowCloseButton = true;
                this.ShowMinButton = true;
                this.ShowInTaskbar = true;
                this.IgnoreTaskbarOnMaximize = false;
            }
        }


        public void CalculateDoneRentedTime()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllBookingTable();
            DateTime date = DateTime.Now;
            int i = 0;
            foreach (DataRow row in ResultTable.Rows)
            {

                DateTime D = Convert.ToDateTime(ResultTable.Rows[i]["BookingDate"]);
                string ID = Convert.ToString(ResultTable.Rows[i]["BookingID"]);
                string Status = Convert.ToString(ResultTable.Rows[i]["BookingStatus"]);
                string Bike = Convert.ToString(ResultTable.Rows[i]["BicycleID"]);
                string Customer = Convert.ToString(ResultTable.Rows[i]["Customer"]);

                if (date.Date > D.Date && Status == "A")
                {
                    MyDAL.UpdateBookingDate(D, "E", ID);
                    MyDAL.UpdateBikeStatus(Bike, "", "A", "", null, null, TLUsername.Text);
                }
                else if (date.Date > D && Status == "R")
                {
                    MyDAL.UpdateBookingDate(D, "N", ID);
                    MyDAL.UpdateBikeStatus(Bike, Customer, "N", "", null, null, TLUsername.Text);
                }
                i = i + 1;
            }
        }
        private void Store_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            //button for store
            InventoryManage newWin = new InventoryManage();
            newWin.PopulateDataFromLogin(username);
            Framework.Content = newWin.Content;



        }



        private async void create_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            if (RankID <= 2)
            {
                var res = await this.ShowMessageAsync("Error", "You have no access to this current Service");

            }
            else
            {
                Framework.Visibility = Visibility.Visible;
                CreateNewUser emp = new CreateNewUser();
                emp.PopulateDataFromLogin(username);
                Framework.Content = emp.Content;


            }
        }

        public void PopulateDataFromLogin(string Values)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectEmployeeID("", Values);


            if (ResultTable.Rows.Count > 0)
            {

                TLUsername.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeName"]).Trim();
                TLRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]).Trim();
                username = Convert.ToString(ResultTable.Rows[0]["Username"]).Trim();
                RankID = Convert.ToInt32(ResultTable.Rows[0]["EmployeeRank"]);
                if (RankID < 2)
                {
                    ExpanderEmployee.AllowDrop = false;
                    ExpanderEmployee.IsEnabled = false;

                    ExpanderReports.IsEnabled = false;
                    ExpanderStore.IsEnabled = false;
                }
                Framework.Visibility = Visibility.Visible;
                FinalizeReports search = new FinalizeReports();
                search.RankID = RankID;
                search.username = username;
                Framework.Content = search.Content;

            }

        }

        public void PopulateDataGrid()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllBookingTable();
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BookingStatus" }, ref ResultTable);
            //dataGrid1.ItemsSource = ResultTable.DefaultView;
            //dataGrid1.AutoGenerateColumns = false;
            //dataGrid1.CanUserAddRows = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //login menu
            LoginMenu log = new LoginMenu();
            log.Show();
            this.Close();
        }

        //private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    TBikeDAL MyDAL = new TBikeDAL();
        //    int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);

        //    DataTable ResultTable = MyDAL.ShowAllBookingTable();
        //    string Customer = Convert.ToString(ResultTable.Rows[index]["Customer"]);
        //    string Status = Convert.ToString(ResultTable.Rows[index]["BookingStatus"]);


        //    if (Customer != null)
        //    {
        //        if (Status == "A")
        //        {
        //            rental rent = new rental();
        //            rent.Show();
        //            rent.PopulateDataFromLogin(username);
        //            rent.PopulateID(Customer, Status);
        //            this.Close();
        //        }
        //        else if(Status == "R")
        //        {
        //            Return ret = new Return();
        //            ret.Show();
        //            ret.PopulateDataFromLogin(username);
        //            ret.PopulateID(Customer, Status);
        //            this.Close();
        //        }

        //        else if (Status == "N")
        //        {
        //            Return ret = new Return();
        //            ret.Show();
        //            ret.PopulateDataFromLogin(username);
        //            ret.PopulateID(Customer, Status);
        //            this.Close();
        //        }


        //    }
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    Notification();
        //    //Search button
        //    dataGrid1.Visibility = Visibility.Collapsed;
        //    Framework.Visibility = Visibility.Visible;
        //    FinalizeReports search = new FinalizeReports();
        //    Framework.Content = search.Content;
        //    search.PopulateDataFromLogin(username);

        //}

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            //Report button
            ConfirmWindow pop = new ConfirmWindow(AppData.ImageType.Question,"Choose", "Please select report type","Booking","Snacks");
            pop.ShowDialog();  
            if (pop.Confirmed)
            {
                ReportCharts ala = new ReportCharts();
                ala.SortCategory("Bicycle");
                Framework.Content = ala.Content;
            }
            else if (pop.Confirmed == false)
            {
                ReportCharts ala = new ReportCharts();
                ala.SortCategory("Snack");
                Framework.Content = ala.Content;
            }
            
          
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            Booking book = new Booking();
            book.PopulateDataFromLogin(username);
            Framework.Content = book.Content;
        }

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            rental rent = new rental();
            rent.PopulateDataFromLogin(username);
            Framework.Content = rent.Content;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            Return retun = new Return();
            retun.PopulateDataFromLogin(username);
            Framework.Content = retun.Content;
        }
        private void Service_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            Service service = new Service();
            service.PopulateDataFromLogin(username);
            Framework.Content = service.Content;
        }

        private void EmpModify_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;
            //employee modification
            Framework.Visibility = Visibility.Hidden;
            dataGrid1.Visibility = Visibility.Visible;

            //because test user is for testing therefore there will be no limitations for test user
            if (username == "user")
            {
                PopulateEmployeeDetails();
            }
            else
            {
                //this will sort out by the rank level of each employee
                PopulateEmployeeDetailsByRankLevel();
            }
        }

        private void Framework_Navigated(object sender, NavigationEventArgs e)
        {

        }

        public void PopulateEmployeeDetails()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowAllEmployeeDetails();


            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;


        }

        public void PopulateEmployeeDetailsByRankLevel()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelectEmployeeDetailsByRankLevel(RankID);


            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;


        }

        private async void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;

            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            if (index == -1)
            {
                index = 0;
                
            }
            //string cellValue = dataRow.Row.ItemArray[index].ToString();
            DataTable ResultTable = MyDAL.SelectEmployeeDetailsByRankLevel(RankID);
            id = Convert.ToString(ResultTable.Rows[index]["EmployeeID"]);
            self = Convert.ToString(ResultTable.Rows[index]["username"]);

            int Rank = Convert.ToInt32(ResultTable.Rows[index]["EmployeeRank"]);

            if (id != null)
            {
                if (RankID >= 4 || self == username)
                {
                    Framework.Visibility = Visibility.Visible;
                    dataGrid1.Visibility = Visibility.Collapsed;

                    EmployeeModify mod = new EmployeeModify();
                    mod.populateEmployee(id);
                    mod.PopulateDataFromLogin(username);
                    Framework.Content = mod.Content;

                }

            }
            else
            {
                var res = await this.ShowMessageAsync("Error", "Please Select Employee");

            }
        }

        private void Framework_LoadCompleted(object sender, NavigationEventArgs e)
        {

        }

        private async void ExpanderEmployee_Expanded(object sender, RoutedEventArgs e)
        {
            if (RankID < 2)
            {


                var res = await this.ShowMessageAsync("Error", "Rank not high enough to access");
                ExpanderEmployee.IsExpanded = false;
            }
        }

        private async void BtnRank_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            dataGrid1.Visibility = Visibility.Collapsed;

            if (RankID >= 4)
            {
                Framework.Visibility = Visibility.Visible;
                EmployeeRank mod = new EmployeeRank();
                mod.PopulateDataFromLogin(username);
                mod.ShowDialog();

            }

            else
            {
                var res = await this.ShowMessageAsync("Error", "Rank not high enough");

            }


        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Notification();
            TBikeDAL MyDAL = new TBikeDAL();
            dataGrid1.Visibility = Visibility.Collapsed;
            Framework.Visibility = Visibility.Visible;
            FinalizeReports search = new FinalizeReports();
            search.PopulateDataFromLogin(username);
            Framework.Content = search.Content ;
        }

        private void LBRent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBRent.SelectedIndex != -1)
            {
                string customer = LBRent.SelectedValue.ToString().Trim();


                if (customer != "")
                {
                    rental rent = new rental();
                    rent.PopulateDataFromLogin(username);
                    rent.PopulateID(customer, "A");
                    rent.ShowDialog();
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //popup button to refresh the listbox
            TBikeDAL MyDAL = new TBikeDAL();
            MyDAL.bindListBoxCustomer(LBRent);

            if (button.IsChecked == true)
            {
                button.Background = Brushes.White;
                LBRent.Visibility = Visibility.Visible;
                button.Foreground = Brushes.Black;
            }
            else if (button.IsChecked == false)
            {
             
                LBRent.Visibility = Visibility.Hidden;
                button.Background = Brushes.Black;
                button.Foreground = Brushes.White;

            }
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            button.Background = Brushes.Gray;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (button.IsChecked == true)
            {
                button.Background = Brushes.White;
                button.Foreground = Brushes.Black;
            }
            else if (button.IsChecked == false)
            {
                button.Background = Brushes.Black;
                button.Foreground = Brushes.White;

            }
            
        }
    }
}