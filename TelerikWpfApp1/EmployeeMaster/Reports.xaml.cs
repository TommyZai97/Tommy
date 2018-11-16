using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using MahApps.Metro.Controls;
using System.Data;
using MaterialMenu;
using TBike.MessageBox;
using TBike.AppData;

namespace TBike.EmployeeMaster
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : MetroWindow
    {
        public Reports()
        {
            InitializeComponent();

            TBikeDAL MyDAL = new TBikeDAL();
            MyDAL.bindListBox(ListBooking);
            TotalBookBike();
            TotalBikeType();
        }


        private void ListBooking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBBookID.Text = ListBooking.SelectedValue.ToString().Trim();
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectAllBookingDetailsByID(TBBookID.Text);
            TBBike.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]).Trim();
            TBBookStatus.Text = "Successful";
            TBBikeType.Text = Convert.ToString(ResultTable.Rows[0]["BicycleType"]).Trim();
            DateTime date = Convert.ToDateTime(ResultTable.Rows[0]["BookingDate"]);
            TBBookDate.Text = date.ToShortDateString().ToString().Trim();
            TBStartTime.Text = Convert.ToString(ResultTable.Rows[0]["StartTime"]).Trim();
            TBEndTime.Text = Convert.ToString(ResultTable.Rows[0]["EndTime"]).Trim();
            TBDeposit.Text = Convert.ToString(ResultTable.Rows[0]["BookingDeposit"]).Trim();
            TBCustomer.Text = Convert.ToString(ResultTable.Rows[0]["Customer"]).Trim();
            TBTotalPrice.Text = Convert.ToString(ResultTable.Rows[0]["TotalPrice"]).Trim();
            TBRemark.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]).Trim();
            TBCreatedBy.Text = Convert.ToString(ResultTable.Rows[0]["CreatedBy"]).Trim();
            date = Convert.ToDateTime(ResultTable.Rows[0]["CreatedAt"]);
            TBCreatedAt.Text = date.ToShortDateString().ToString().Trim();
            TBLastUpdatedBy.Text = Convert.ToString(ResultTable.Rows[0]["LastUpdatedBy"]).Trim();
            date = Convert.ToDateTime(ResultTable.Rows[0]["LastUpdatedAt"]);
            TBLastUpdatedAt.Text = date.ToShortDateString().ToString().Trim();
            TBShowTitle.Text = "Seleted ID: " + ListBooking.SelectedValue.ToString().Trim();
        }

        private void BTNPayment_Click(object sender, RoutedEventArgs e)
        {
            //monthly earnings
            TBikeDAL MyDAL = new TBikeDAL();
            RentStack.Visibility = Visibility.Hidden;
            MonthStack.Visibility = Visibility.Visible;
            DataTable ResultTable = MyDAL.ShowAllBookingTable();
            string status;
            int i = 0;
            double Price = 0;
            double Total = 0;
            DateTime date;
       
            foreach(DataRow row in ResultTable.Rows)
            {
                status = Convert.ToString(ResultTable.Rows[i]["BookingStatus"]).Trim();
                date = Convert.ToDateTime(ResultTable.Rows[i]["BookingDate"]);

                if (date.Month == DateTime.Now.Month)
                {
                    if (status == "S")
                    {
                        Price = Convert.ToDouble(ResultTable.Rows[i]["TotalPrice"]);
                        Total = Total + Price;

                    }
                }
                i++;
            }

            TBMonthly.Text = "RM " + Total.ToString().Trim();
        }

        private void BTNTotalRent_Click(object sender, RoutedEventArgs e)
        {
            //Monthly Rents
            TBikeDAL MyDAL = new TBikeDAL();
            MonthStack.Visibility = Visibility.Hidden;
            RentStack.Visibility = Visibility.Visible;
            DataTable ResultTable = MyDAL.ShowAllBookingTable();
            int i = 0;
            int count = 0;
            foreach (DataRow row in ResultTable.Rows)
            {
                DateTime date = Convert.ToDateTime(ResultTable.Rows[i]["BookingDate"]);

                if (date.Month == DateTime.Now.Month)
                {


                    count++;


                }
                
                if (ResultTable.Rows.Count <= i)
                {
                    break;
                }
                i++;
            }
            TBMonthlyRents.Text = Convert.ToString(count);

        }

        private void TotalBookBike()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTableBike = MyDAL.ShowAllBikeTable();
            int i = 0;

           
            int TotalCount = 0;
            string MostBookBike = "";
            string BicycleName = "";
            //get total Booking for a type---- WORKING PROCESS
            foreach (DataRow Row in ResultTableBike.Rows)
            {
                string BicycleID = Convert.ToString(ResultTableBike.Rows[i]["BicycleID"]);
                DataTable ResultTable = MyDAL.SelectBookingByMonthBicycle(BicycleID);
                int MaxCounter = 0;
                foreach (DataRow row in ResultTable.Rows)
                {
                    BicycleName = Convert.ToString(ResultTable.Rows[MaxCounter]["BicycleName"]);
                    MaxCounter++;
                    

                }

                if (TotalCount < MaxCounter)
                {
                    TotalCount = MaxCounter;
                    MostBookBike = BicycleName;
                }
                    i++;
            }
            TBMostBook.Text = MostBookBike;


        }

        private void TotalBikeType()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTableBike = MyDAL.ShowAllBikeTable();
            int i = 0;


            int TotalCount = 0;
            string MostBookBike = "";
            string BicycleName = "";
            //get total Booking for a type---- WORKING PROCESS
            foreach (DataRow Row in ResultTableBike.Rows)
            {
                string BicycleType = Convert.ToString(ResultTableBike.Rows[i]["BicycleType"]);
                DataTable ResultTable = MyDAL.SelectBookingByMonthType(BicycleType);
                int MaxCounter = 0;
                foreach (DataRow row in ResultTable.Rows)
                {
                    BicycleName = Convert.ToString(ResultTable.Rows[MaxCounter]["BicycleType"]);
                    MaxCounter++;


                }

                if (TotalCount < MaxCounter)
                {
                    TotalCount = MaxCounter;
                    MostBookBike = BicycleName;
                }
                i++;
            }
            TBBookType.Text = MostBookBike;
        }

        private void BTNAddon_Click(object sender, RoutedEventArgs e)
        {

            if (ListBooking.SelectedIndex >= 0)
            {
                TBikeDAL MyDAl = new TBikeDAL();
                DataTable ResultTable = MyDAl.SelectSnackSalesByBookIDCustomer(TBBookID.Text.Trim() , TBCustomer.Text.Trim());
                if (ResultTable.Rows.Count > 0)
                {
                    PopWindow pop = new PopWindow(ImageType.Information, "Addon Details", "Item :" + Convert.ToString(ResultTable.Rows[0]["SnackName"]).Trim() + " , Quantity :" + Convert.ToInt32(ResultTable.Rows[0]["Quantity"]) + " , Total Price :" + Convert.ToDouble(ResultTable.Rows[0]["TotalPrice"]), "OK");
                    pop.ShowDialog();
                }
                else
                {
                    PopWindow pop = new PopWindow(ImageType.Warning, "No Detail", "No Data Found for this booking", "OK");
                    pop.ShowDialog();
                }
            }
            else
            {
                PopWindow pop = new PopWindow(ImageType.Warning, "No Data..", "Please Select a List", "OK");
                pop.ShowDialog();
            }
        }
    }
    
}
