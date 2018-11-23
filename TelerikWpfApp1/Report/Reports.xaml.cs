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
using TBike.MessageBox;
using TBike.AppData;

namespace TBike.EmployeeMaster
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : MetroWindow
    {
        int datebymonth;
        public Reports()
        {
            InitializeComponent();
          
         
          
            TotalBookBike();
            TotalBikeType();
        }
     
        public void SortByMonth(int month)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            if (month == 1)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :January";
            }
            else if (month == 2)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :February";
            }
            else if (month == 3)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :March";
            }
            else if (month == 4)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :April";
            }
            else if (month == 5)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :May";
            }
            else if (month == 6)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :June";
            }
            else if (month == 7)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :July";
            }
            else if (month == 8)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :August";
            }
            else if (month == 9)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :September";
            }
            else if (month == 10)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :October";
            }
            else if (month == 11)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :November";
            }
            else if (month == 12)
            {
                MyDAL.bindListBox(ListBooking, month);
                TBMonth.Text = "Date :December";
            }

            datebymonth = month;
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

            DataTable ResultFatTable = MyDAL.SelectSnackSalesByBookIDCustomer(TBBookID.Text.Trim(), TBCustomer.Text.Trim());
            if (ResultFatTable.Rows.Count == 0)
            {
                BTNAddon.IsEnabled = false;
            }
            else
            {
                BTNAddon.IsEnabled = true;
            }
           
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

                if (date.Month == datebymonth)
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
                if (date.Month == datebymonth)
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

        public void TotalBookBike()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTableBike = MyDAL.ShowAllBikeTable();
            int i = 0;
            int TotalCount = 0;
            string MostBookBike = "";
            string BicycleName = "";
            
            foreach (DataRow Row in ResultTableBike.Rows)
            {
                string BicycleID = Convert.ToString(ResultTableBike.Rows[i]["BicycleID"]);
                DataTable ResultTable = MyDAL.SelectBookingByMonthBicycle(BicycleID, datebymonth);
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

        public void TotalBikeType()
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
                DataTable ResultTable = MyDAL.SelectBookingByMonthType(BicycleType , datebymonth);
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
            try
            {
                if (ListBooking.SelectedIndex >= 0)
                {
                    TBikeDAL MyDAl = new TBikeDAL();
                    DataTable ResultTable = MyDAl.SelectSnackSalesByBookIDCustomer(TBBookID.Text.Trim(), TBCustomer.Text.Trim());
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
            catch (Exception ex) {
                PopWindow pop = new PopWindow(ImageType.Error, "Error", "Error: " + ex.Message, "OK");
                pop.ShowDialog();
            }
        }

        
    }
    
}
