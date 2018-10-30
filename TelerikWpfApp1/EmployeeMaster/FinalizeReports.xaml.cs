using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using TBike.BookingMaster;
using TBike.MessageBox;
using TBike.AppData;
using System.ComponentModel;

namespace TBike.EmployeeMaster
{
    /// <summary>
    /// Interaction logic for FinalizeReports.xaml
    /// </summary>
    public partial class FinalizeReports : MetroWindow
    {
        string username;
        int RankID;
        BackgroundWorker MyStartupBackgroundWorker;
        public FinalizeReports()
        {
            InitializeComponent();
            TBikeDAL MyDAL = new TBikeDAL();
            MyDAL.BindAllBikeComboBox(CBBike);

        }

        private void BTNsearch_Click(object sender, RoutedEventArgs e)
        {
            initializeWorker();
           
        }

        public void SearchModule()
        {
            TBikeDAL MyDAL = new TBikeDAL();

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.PopulateDataFromLogin(username);
            win.Show();
            this.Close();
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



            }

        }

        public void ServiceMode()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelAllServiceByDynamic(TBServiceId.Text, TBServiceStatus.Text, TBServiceRemark.Text, TBServiceStatus.Text);
            Column1.Header = "Service ID";
            Column1.Binding = new Binding("ServiceID");
            Column2.Header = "Employee Name";
            Column2.Binding = new Binding("BicycleID");
            Column3.Header = "Service Start-Time";
            Column3.Binding = new Binding("ServiceStart");
            Column4.Header = "Service End-Time";
            Column4.Binding = new Binding("ServiceEnd");
            Column5.Header = "Service Status";
            Column5.Binding = new Binding("StatusInFull");
            Column6.Header = "Service Remark";
            Column6.Binding = new Binding("Remark");
            Column7.Header = "";
            Column8.Header = "";
            Column9.Header = "";
   

            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "Status" }, ref ResultTable);
            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.IsReadOnly = true;
            dataGrid1.AutoGenerateColumns = false;
        }
        public void SnackMode()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelectAllSnackByDynamic(TBSnackID.Text, TBSnackName.Text, TBSnackStatus.Text, TBSnackType.Text);
            Column1.Header = "Snack ID";
            Column1.Binding = new Binding("SnackID");
            Column2.Header = "Snack Name";
            Column2.Binding = new Binding("SnackName");
            Column3.Header = "Snack Type";
            Column3.Binding = new Binding("SnackType");
            Column4.Header = "Snack Status";
            Column4.Binding = new Binding("SnackStatusInFull");
            Column5.Header = "Snack Quantity";
            Column5.Binding = new Binding("Quantity");
            Column6.Header = "Snack Price";
            Column6.Binding = new Binding("Price");
            Column7.Header = "";
            Column8.Header = "";
            Column9.Header = "";
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "SnackStatus" }, ref ResultTable);
            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.IsReadOnly = true;
            dataGrid1.AutoGenerateColumns = false;
        }

        public void BicycleMode()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelectAllBicycleByDynamic(TBBicycleID.Text, TBBikeName2.Text, TBCurrentRenter.Text, TBBikeColor.Text,TBBikeStatus.Text, TBBikeType2.Text);
            Column1.Header = "Bicycle ID";
            Column1.Binding = new Binding("BicycleID");
            Column2.Header = "Bicycle Name";
            Column2.Binding = new Binding("BicycleName");
            Column3.Header = "Bicycle Type";
            Column3.Binding = new Binding("BicycleType");
            Column4.Header = "Bicycle Status";
            Column4.Binding = new Binding("BicycleStatusInFull");
            Column5.Header = "Current Renter";
            Column5.Binding = new Binding("CurrentRenter");
            Column6.Header = "Color";
            Column6.Binding = new Binding("Color");
            Column7.Header = "";
            Column8.Header = "";
            Column9.Header = "";
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BicycleStatus" }, ref ResultTable);


            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.IsReadOnly = true;
            dataGrid1.AutoGenerateColumns = false;
        }

        public void BookingMode()
        {

            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelectAllBookingByDynamic(TBBookID.Text, TBBookName.Text, TBBikeName.Text, TBBookingStatus.Text, TBCustomer.Text, TBRemarks.Text, TBBikeType.Text);


            Column1.Header = "Booking ID";
            Column1.Binding = new Binding("BookingID");
            Column2.Header = "Bicycle";
            Column2.Binding = new Binding("BicycleName");
            Column3.Header = "Booking Date";
            Column3.Binding = new Binding("BookingDate");
            Column4.Header = "Booking Status";
            Column4.Binding = new Binding("BookingStatusInFull");
            Column5.Header = "Booking Start-Time";
            Column5.Binding = new Binding("StartTime");
            Column6.Header = "Booking End-Time";
            Column6.Binding = new Binding("EndTime");
            Column7.Header = "Deposit";
            Column7.Binding = new Binding("BookingDeposit");
            Column8.Header = "Customer Name";
            Column8.Binding = new Binding("Customer");
            Column9.Header = "Total Price";
            Column9.Binding = new Binding("TotalPrice");
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BookingStatus" }, ref ResultTable);



            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;
            dataGrid1.IsReadOnly = true;



        }

        public void EmployeeMode()
        {
      
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelectAllEmployeeByDynamic(TBID.Text, TBName.Text, TBRankDesc.Text, TBAddress.Text, TBCreatedBy.Text);
            Column1.Header = "Employee ID";
            Column1.Binding = new Binding("EmployeeID");
            Column2.Header = "Employee Name";
            Column2.Binding = new Binding("EmployeeName");
            Column3.Header = "Username";
            Column3.Binding = new Binding("Username");
            Column4.Header = "Rank Description";
            Column4.Binding = new Binding("EmployeeRankDesc");
            Column5.Header = "Email Address";
            Column5.Binding = new Binding("Email");
            Column6.Header = "Date Of Birth";
            Column6.Binding = new Binding("DateOfBirth");
            Column7.Header = "Home Address";
            Column7.Binding = new Binding("[Address]");
            Column8.Header = "Last Login-Time";
            Column8.Binding = new Binding("LastLoginTime");  
            Column9.Header = "";
            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            initializeWorker();
            //mode selector
            //if (CBMode.SelectedValue.ToString().Trim() == "Employee")
            //{
               
            //    StackService.Visibility = Visibility.Hidden;
            //    StackSnack.Visibility = Visibility.Hidden;
            //    StackBike.Visibility = Visibility.Hidden;
            //    StackBook.Visibility = Visibility.Hidden;
            //    StackEmp.Visibility = Visibility.Visible;
            //    EmployeeMode();

            //}
            //else if (CBMode.SelectedValue.ToString().Trim() == "Booking")
            //{
            //    StackService.Visibility = Visibility.Hidden;
            //    StackSnack.Visibility = Visibility.Hidden;
            //    StackBike.Visibility = Visibility.Hidden;
            //    StackEmp.Visibility = Visibility.Hidden;
            //    StackBook.Visibility = Visibility.Visible;
            //    BookingMode();
            //}
            //else if (CBMode.SelectedValue.ToString().Trim() == "Service")
            //{
            //    StackSnack.Visibility = Visibility.Hidden;
            //    StackBike.Visibility = Visibility.Hidden;
            //    StackEmp.Visibility = Visibility.Hidden;
            //    StackBook.Visibility = Visibility.Hidden;
            //    StackService.Visibility = Visibility.Visible;
            //    ServiceMode();
            //}
            //else if (CBMode.SelectedValue.ToString().Trim() == "Bicycle")
            //{
            //    StackService.Visibility = Visibility.Hidden;
            //    StackSnack.Visibility = Visibility.Hidden;
            //    StackEmp.Visibility = Visibility.Hidden;
            //    StackBook.Visibility = Visibility.Hidden;
            //    StackBike.Visibility = Visibility.Visible;
            //    BicycleMode();
            //}
            //else if (CBMode.SelectedValue.ToString().Trim() == "Snacks")
            //{
            //    StackService.Visibility = Visibility.Hidden;
            //    StackBook.Visibility = Visibility.Hidden;
            //    StackEmp.Visibility = Visibility.Hidden;
            //    StackBike.Visibility = Visibility.Hidden;
            //    StackSnack.Visibility = Visibility.Visible;
            //    SnackMode();
            //}
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBMode.SelectedValue.ToString().Trim() == "Booking")
            {
                LinkToBookingWindow();
            }
            else if (CBMode.SelectedValue.ToString().Trim() == "Employee")
            {
                LinkToEmployee();
            }
            else if (CBMode.SelectedValue.ToString().Trim() == "Service")
            {
                LinkToServiceWindow();
            }
            else if (CBMode.SelectedValue.ToString().Trim() == "Bicycle")
            {
                LinkToBicycleWindow();
            }
            else if (CBMode.SelectedValue.ToString().Trim() == "Snacks")
            {
                LinkToSnackWindow();
            }
        }
        public void LinkToSnackWindow()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            DataTable ResultTable = MyDAL.ShowAllSnackTable();

            if (index == -1)
            {
                index = 0;

            }
            else
            {
                string SnackID = Convert.ToString(ResultTable.Rows[index]["SnackID"]);
                string Status = Convert.ToString(ResultTable.Rows[index]["SnackStatus"]);
                InventoryModi modi = new InventoryModi();
                modi.PopulateDataFromLogin(username);
                modi.PopulateID(SnackID, "Snacks", "Modification");
                modi.ShowDialog();
            
            }
        }

        public void LinkToBicycleWindow()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            DataTable ResultTable = MyDAL.ShowAllBikeTable();

            if (index == -1)
            {
                index = 0;
                
            }
            else
            {
                string BicycleID = Convert.ToString(ResultTable.Rows[index]["BicycleID"]);
                string Status = Convert.ToString(ResultTable.Rows[index]["BicycleStatus"]);
                if (Status == "M")
                {
                    Service ret = new Service();
                
                    ret.PopulateDataFromLogin(username);
                    ret.PopulateID(BicycleID, Status);
                    ret.ShowDialog();
                }
                else if (Status == "I")
                {
                    Service ret = new Service();
            
                    ret.PopulateDataFromLogin(username);
                    ret.PopulateID(BicycleID, Status);
                    ret.ShowDialog();
                }
                else
                {
                    InventoryModi mod = new InventoryModi();
                   
                    mod.PopulateDataFromLogin(username);
                    mod.PopulateID(BicycleID, "Bicycle", "Modification");
                    mod.ShowDialog();
                }
            }
        
          
        }

        public void LinkToServiceWindow()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllServiceDetails();

            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
        
            if (index == -1)
            {
                index = 0;

            }
            else
            {

                string BicycleID = Convert.ToString(ResultTable.Rows[index]["BicycleID"]);
                string Status = Convert.ToString(ResultTable.Rows[index]["Status"]);
                if (Status == "M")
                {
                    Service ret = new Service();
                   
                    ret.PopulateDataFromLogin(username);
                    ret.PopulateID(BicycleID, Status);
                    ret.ShowDialog();
                }
                else if (Status == "I")
                {
                    Service ret = new Service();
                 
                    ret.PopulateDataFromLogin(username);
                    ret.PopulateID(BicycleID, Status);
                    ret.ShowDialog();
                }
            }
        }

        public void LinkToBookingWindow()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllBookingTable();
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            if (index == -1)
            {
                index = 0;

            }
            else
            {
                string Customer = Convert.ToString(ResultTable.Rows[index]["Customer"]);
                string Status = Convert.ToString(ResultTable.Rows[index]["BookingStatus"]);
                if (Customer != null)
                {
                    if (Status == "A")
                    {
                        rental rent = new rental();
                  
                        rent.PopulateDataFromLogin(username);
                        rent.PopulateID(Customer, Status);
                        rent.ShowDialog();
                    }
                    else if (Status == "R")
                    {
                        Return ret = new Return();
                    
                        ret.PopulateDataFromLogin(username);
                        ret.PopulateID(Customer, Status);
                        ret.ShowDialog();
                    }

                    else if (Status == "N")
                    {
                        Return ret = new Return();
                  
                        ret.PopulateDataFromLogin(username);
                        ret.PopulateID(Customer, Status);
                        ret.ShowDialog();
                    }


                }
            }
        }
        public void LinkToEmployee()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            DataTable ResultTable = MyDAL.ShowAllEmployeeDetails();
           

            if (index == -1)
            {
                index = 0;

            }
            else
            {
                string id = Convert.ToString(ResultTable.Rows[index]["EmployeeID"]);
                string self = Convert.ToString(ResultTable.Rows[index]["Username"]);
                if (id != null)
                {
                    if (RankID >= 4 || self == username)
                    {

                        EmployeeModify emp = new EmployeeModify();
                  
                        emp.PopulateDataFromLogin(username);
                        emp.populateEmployee(id);
                        emp.ShowDialog();
                    }
                    else
                    {
                        PopWindow pop = new PopWindow(ImageType.Warning, "Error", "Rank too low to access this service", "Alright");
                        pop.ShowDialog();
                    }
                }
            }

            
        }

        public void initializeWorker()
        {
            BTNsearch.IsEnabled = false;
            CBMode.IsEnabled = false;
            ProgressPanel.Visibility = Visibility.Visible;
            MyStartupBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            MyStartupBackgroundWorker.DoWork += MyStartupBackgroundWorker_DoWork;
            MyStartupBackgroundWorker.RunWorkerCompleted += MyStartupBackgroundWorker_RunWorkerCompleted;
            MyStartupBackgroundWorker.ProgressChanged += MyStartupBackgroundWorker_ProgressChanged;
            MyStartupBackgroundWorker.WorkerReportsProgress = true;
            MyStartupBackgroundWorker.RunWorkerAsync();
        }

        private void MyStartupBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            PBsearch.Value = e.ProgressPercentage;
            TBProgressText.Text = Convert.ToString(e.UserState).Trim();
        }

        private void MyStartupBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BTNsearch.IsEnabled = true;
            CBMode.IsEnabled = true;
            ProgressPanel.Visibility = Visibility.Hidden;
            if (CBMode.SelectedIndex != -1)
            {
                if (CBMode.SelectedValue.ToString().Trim() == "Employee")
                {
                    StackService.Visibility = Visibility.Hidden;
                    StackSnack.Visibility = Visibility.Hidden;
                    StackBook.Visibility = Visibility.Hidden;
                    StackEmp.Visibility = Visibility.Visible;
                    EmployeeMode();
                }
                else if (CBMode.SelectedValue.ToString().Trim() == "Booking")
                {
                    StackBike.Visibility = Visibility.Hidden;
                    StackService.Visibility = Visibility.Hidden;
                    StackSnack.Visibility = Visibility.Hidden;
                    StackEmp.Visibility = Visibility.Hidden;
                    StackBook.Visibility = Visibility.Visible;
                    BookingMode();
                }
                else if (CBMode.SelectedValue.ToString().Trim() == "Bicycle")
                {
                    StackService.Visibility = Visibility.Hidden;
                    StackSnack.Visibility = Visibility.Hidden;
                    StackBook.Visibility = Visibility.Hidden;
                    StackEmp.Visibility = Visibility.Hidden;
                    StackBike.Visibility = Visibility.Visible;
                    BicycleMode();
                }
                else if (CBMode.SelectedValue.ToString().Trim() == "Snacks")
                {
                    StackService.Visibility = Visibility.Hidden;
                    StackBook.Visibility = Visibility.Hidden;
                    StackEmp.Visibility = Visibility.Hidden;
                    StackBike.Visibility = Visibility.Hidden;
                    StackSnack.Visibility = Visibility.Visible;
                    SnackMode();
                }
                else if (CBMode.SelectedValue.ToString().Trim() == "Service")
                {
                    StackSnack.Visibility = Visibility.Hidden;
                    StackBike.Visibility = Visibility.Hidden;
                    StackEmp.Visibility = Visibility.Hidden;
                    StackBook.Visibility = Visibility.Hidden;
                    StackService.Visibility = Visibility.Visible;
                    ServiceMode();
                }
            }
            else
            {

                PopWindow pop = new PopWindow(ImageType.Error, "Error", "Please Choose a mode", "OK");
                pop.ShowDialog();

            }
        }

        private void MyStartupBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            MyStartupBackgroundWorker.ReportProgress(5, "Checking SQL server ....");
            System.Threading.Thread.Sleep(50);
            MyStartupBackgroundWorker.ReportProgress(15, "Checking Table Mode ....");
            System.Threading.Thread.Sleep(50);
            MyStartupBackgroundWorker.ReportProgress(20, "Checking SQL for table ....");
            try
            {
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(30, "Service started ....");
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(40, "Service Running ....");
                System.Threading.Thread.Sleep(150);
                MyStartupBackgroundWorker.ReportProgress(50, "Service Done");
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(60, "Found Data !!!!");
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(70, "Input Data to Grid ....");
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(80, "DataGrid Sorting ....");
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(90, "Showing DataGrid ....");
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(100, "Completed !!!!");
            }
            catch (Exception ex){
                System.Threading.Thread.Sleep(50);
                MyStartupBackgroundWorker.ReportProgress(100, "Unhandled Exception Occured: " + ex.Message);
                PopWindow pop = new PopWindow(ImageType.Error, "Error SQL", ex.Message, "OK");
                pop.ShowDialog();
            }
        }
    }  
  
}
