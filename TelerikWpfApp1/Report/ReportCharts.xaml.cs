using MahApps.Metro.Controls;
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
using TBike.AppData;
using TBike;
using TBike.EmployeeMaster;
using TBike.MessageBox;

namespace TBike.Report
{
    /// <summary>
    /// Interaction logic for ReportCharts.xaml
    /// </summary>
    public partial class ReportCharts : MetroWindow
    {
        public ReportCharts()
        {
            InitializeComponent();
          
     

        }
        public void SortCategory(string Category)
        {
            PopulateBookGrd();
            if (Category == "Bicycle")
            {
                BookPanel.Visibility = Visibility.Visible;
                BookDetailPanel.Visibility = Visibility.Visible;

                SnackPanel.Visibility = Visibility.Hidden;
                SnackDetailPanel.Visibility = Visibility.Hidden;
            }
            else if (Category == "Snack") 
            {
                PopulateSnackGrd();
                BookPanel.Visibility = Visibility.Hidden;
                BookDetailPanel.Visibility = Visibility.Hidden;

                SnackPanel.Visibility = Visibility.Visible;
                SnackDetailPanel.Visibility = Visibility.Visible;
            }
        }

        public void PopulateBookGrd()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllBikeTable();
            dColumn1.Header = "Bicycle ID";
            dColumn1.Binding = new Binding("BicycleID");
            dColumn2.Header = "Bicycle Name";
            dColumn2.Binding = new Binding("BicycleName");
            dColumn3.Header = "Bicycle Type";
            dColumn3.Binding = new Binding("BicycleType");
            dColumn4.Header = "Bicycle Status";
            dColumn4.Binding = new Binding("BicycleStatusInFull");
            dColumn5.Header = "Current Renter";
            dColumn5.Binding = new Binding("CurrentRenter");
            dColumn6.Header = "Total Rents";
            dColumn6.Binding = new Binding("TotalRents");
            dColumn7.Header = "Price";
            dColumn7.Binding = new Binding("Price");
            dColumn8.Header = "Color";
            dColumn8.Binding = new Binding("Color");
            dColumn9.Header = "Condition";
            dColumn9.Binding = new Binding("Condition");
            dColumn10.Header = "Created By";
            dColumn10.Binding = new Binding("CreatedBy");
            dColumn11.Header = "Created At";
            dColumn11.Binding = new Binding("Created At");
            dColumn12.Header = "Last Updated By";
            dColumn12.Binding = new Binding("LastUpdatedBy");
            dColumn13.Header = "Last Updated At";
            dColumn13.Binding = new Binding("Last Updated At");
          
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BicycleStatus" }, ref ResultTable);
            BookGrd.ItemsSource = ResultTable.DefaultView;
            BookGrd.AutoGenerateColumns = false;
            
        }

        private void BTNBookDetail_Click(object sender, RoutedEventArgs e)
        {
            int month;
            TypeWindow type = new TypeWindow(ImageType.Question, "Select Month", "Please Choose Month", "OK", "Cancel");
            type.ShowDialog();
            month = type.Month;
            Reports rep = new Reports();
          
            rep.SortByMonth(month);
            rep.TotalBookBike();
            rep.TotalBikeType();
            rep.ShowDialog();
        }

        private void detailGrd_Selected(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            int index = BookGrd.Items.IndexOf(BookGrd.CurrentItem);
            DataTable BicycleTable = MyDAL.ShowAllBikeTable();
            if (index == -1)
            {
                index = 0;

            }
            else
            {
                string BicycleName =Convert.ToString(BicycleTable.Rows[index]["BicycleName"]).Trim();
                DataTable ResultTable = MyDAL.SelectAllBookingByDynamic("",  BicycleName, "", "", "", "");

                TBBicycleID.Text = "Booking Details By: " + Convert.ToString(BicycleTable.Rows[index]["BicycleName"]).Trim();

                Column1.Header = "Booking ID";
                Column1.Binding = new Binding("BookingID");
                Column2.Header = "Bicycle";
                Column2.Binding = new Binding("BicycleName");
                Column3.Header = "Bicycle Type";
                Column3.Binding = new Binding("BicycleType");
                Column4.Header = "Booking Date";
                Column4.Binding = new Binding("BookingDate");
                Column5.Header = "Booking Status";
                Column5.Binding = new Binding("BookingStatusInFull");
                Column6.Header = "Booking Start-Time";
                Column6.Binding = new Binding("StartTime");
                Column7.Header = "Booking End-Time";
                Column7.Binding = new Binding("EndTime");
                Column8.Header = "Deposit";
                Column8.Binding = new Binding("BookingDeposit");
                Column9.Header = "Customer Name";
                Column9.Binding = new Binding("Customer");
                Column10.Header = "Total Price";
                Column10.Binding = new Binding("TotalPrice");
                Column11.Header = "Remarks";
                Column11.Binding = new Binding("Remark");
                Column12.Header = "Created By";
                Column12.Binding = new Binding("CreatedBy");
                Column13.Header = "Created At";
                Column13.Binding = new Binding("CreatedAt");
                Column14.Header = "Last Updated By";
                Column14.Binding = new Binding("LastUpdatedBy");
                Column15.Header = "Last Updated At";
                Column15.Binding = new Binding("LastUpdatedAt");
                TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BookingStatus" }, ref ResultTable);

                detailGrd.ItemsSource = ResultTable.DefaultView;
                detailGrd.AutoGenerateColumns = false;
            }

        }

        public void PopulateSnackGrd()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllSnackTable();
            SdColumn1.Header = "Snack ID";
            SdColumn1.Binding = new Binding("SnackID");
            SdColumn2.Header = "Snack Name";
            SdColumn2.Binding = new Binding("SnackName");
            SdColumn3.Header = "Type";
            SdColumn3.Binding = new Binding("SnackType");
            SdColumn4.Header = "Status";
            SdColumn4.Binding = new Binding("SnackStatusInFull");
            SdColumn5.Header = "Quantity";
            SdColumn5.Binding = new Binding("Quantity");
            SdColumn6.Header = "Price";
            SdColumn6.Binding = new Binding("Price");
            SdColumn7.Header = "Created By";
            SdColumn7.Binding = new Binding("CreatedBy");
            SdColumn8.Header = "Created At";
            SdColumn8.Binding = new Binding("CreatedAt");
            SdColumn9.Header = "Last Updated By";
            SdColumn9.Binding = new Binding("LastUpdatedBy");
            SdColumn10.Header = "Last Updated At";
            SdColumn10.Binding = new Binding("LastUpdatedAt");
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "SnackStatus" }, ref ResultTable);

            SnackGrd.ItemsSource = ResultTable.DefaultView;
            SnackGrd.AutoGenerateColumns = false;
        }

        private void SnackGrd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            int index = SnackGrd.Items.IndexOf(SnackGrd.CurrentItem);
            DataTable SnackTable = MyDAL.ShowAllSnackTable();
            if (index == -1)
            {
                index = 0;

            }
            else
            {
                string SnackID = Convert.ToString(SnackTable.Rows[index]["SnackID"]).Trim();
                DataTable ResultTable = MyDAL.SelectSnackSalesBySnackID(SnackID);

                TBSnackID.Text = "Sales Details for: " + Convert.ToString(SnackTable.Rows[index]["SnackName"]).Trim();

                SColumn1.Header = "Sales ID";
                SColumn1.Binding = new Binding("SalesID");
                SColumn2.Header = "Booking ID";
                SColumn2.Binding = new Binding("BookingID");
                SColumn3.Header = "Snack ID";
                SColumn3.Binding = new Binding("SnackID");
                SColumn4.Header = "Quantity";
                SColumn4.Binding = new Binding("Quantity");
                SColumn5.Header = "Customer";
                SColumn5.Binding = new Binding("Customer");
                SColumn6.Header = "Total Price";
                SColumn6.Binding = new Binding("TotalPrice");
                SColumn7.Header = "Created By";
                SColumn7.Binding = new Binding("CreatedBy");
                SColumn8.Header = "Created At";
                SColumn8.Binding = new Binding("CreatedAt");
                detailSnackGrd.ItemsSource = ResultTable.DefaultView;
                detailSnackGrd.AutoGenerateColumns = false;
            }
        }
    }
}
