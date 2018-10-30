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
        }


        private void ListBooking_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBBookID.Text = ListBooking.SelectedValue.ToString().Trim();
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectAllBookingDetailsByID(TBBookID.Text);
            TBBike.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]).Trim();
            TBBookStatus.Text = "Successful";
            TBBookDate.Text = Convert.ToString(ResultTable.Rows[0]["BookingDate"]).Trim();
            TBStartTime.Text = Convert.ToString(ResultTable.Rows[0]["StartTime"]).Trim();
            TBEndTime.Text = Convert.ToString(ResultTable.Rows[0]["EndTime"]).Trim();
            TBDeposit.Text = Convert.ToString(ResultTable.Rows[0]["BookingDeposit"]).Trim();
            TBCustomer.Text = Convert.ToString(ResultTable.Rows[0]["Customer"]).Trim();
            TBTotalPrice.Text = Convert.ToString(ResultTable.Rows[0]["TotalPrice"]).Trim();
            TBRemark.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]).Trim();
            TBCreatedBy.Text = Convert.ToString(ResultTable.Rows[0]["CreatedBy"]).Trim();
            TBCreatedAt.Text = Convert.ToString(ResultTable.Rows[0]["CreatedAt"]).Trim();
            TBLastUpdatedBy.Text = Convert.ToString(ResultTable.Rows[0]["LastUpdatedBy"]).Trim();
            TBLastUpdatedAt.Text = Convert.ToString(ResultTable.Rows[0]["LastUpdatedAt"]).Trim();

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
            foreach (DataRow row in ResultTable.Rows)
            {
                DateTime date = Convert.ToDateTime(ResultTable.Rows[i]["BookingDate"]);

                if (date.Month == DateTime.Now.Month)
                {


                    i++;


                }
            }
            TBMonthlyRents.Text = Convert.ToString(i);

        }
    }
    
}
