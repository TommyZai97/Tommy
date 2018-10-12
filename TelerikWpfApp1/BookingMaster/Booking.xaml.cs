using System;
using System.Data;
using System.Windows;
using Xceed.Wpf.Toolkit;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls.Dialogs;

namespace TBike
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : MetroWindow
    {
        string username;
        int RankID;
        int A = 0;
        static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["123"].ConnectionString;

        public Booking()
        {
            InitializeComponent();

            BindComboBox(CBBike);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CBBike.SelectedValue != null)
            {
                //search button
                TBikeDAL MyDAL = new TBikeDAL();
                DataTable ResultTable = MyDAL.ShowBookingTableByBike(CBBike.SelectedValue.ToString().Trim(),"");
                TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BookingStatus" }, ref ResultTable);
                dataGrid1.ItemsSource = ResultTable.DefaultView;
                dataGrid1.AutoGenerateColumns = false;
                dataGrid1.CanUserAddRows = false;
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Please Choose a Bicycle");
              
            }

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            RentalProcessing rent = new RentalProcessing();
            rent.PopulateDataFromLogin(username);
            rent.Show();
            this.Close();
        }

   
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //book button
            try
            {
               
                string BikeID = Convert.ToString(CBBike.SelectedValue);
                TBikeDAL MyDAL = new TBikeDAL();
                DateTime Start = Convert.ToDateTime(StartDate.Value);

                TimeSpan CheckTime = new TimeSpan(08, 00, 00);
                TimeSpan endTime = new TimeSpan(16, 00, 00);


                DataTable ResultAllTable = new DataTable();
                DataTable ResultTable = new DataTable();
                ResultAllTable = MyDAL.ShowAllBookingTable();

                ResultTable = MyDAL.ShowBookingTableByBike(CBBike.SelectedValue.ToString().Trim(),"");
                int count = 0;
                var dates = new List<DateTime>();
                if (ResultTable.Rows.Count == 0)
                {
                    MyDAL.AddBookingTime(Start, CBBike.SelectedValue.ToString().Trim(), "A",TBCustomer.Text, null,TLUsername.Text,null,null,TBRemarks.Text);
                    Xceed.Wpf.Toolkit.MessageBox.Show("Booking made at :" + Start);
                }
                for (int i = 0; i < ResultTable.Rows.Count; i++)
                {
                              
                    if (Start.Date > DateTime.Now && Convert.ToDateTime(ResultTable.Rows[A]["BookingDate"]).Date < Start.Date && Start.TimeOfDay > CheckTime && Start.TimeOfDay < endTime)
                    {
                        MyDAL.AddBookingTime(Start, CBBike.SelectedValue.ToString().Trim(), "A",TBCustomer.Text, null,TLUsername.Text,null,null, TBRemarks.Text);
                        Xceed.Wpf.Toolkit.MessageBox.Show("Booking made at :" + Start);
                        A++;
                        break;
                    }
                    else if (Start.Date < DateTime.Now)
                    {
                        var res = await this.ShowMessageAsync("Error","Date must be booked 1 day ahead from today");
                        break;
                    }
                    else if (Start.TimeOfDay < CheckTime || Start.TimeOfDay > endTime)
                    {
                        var res = await this.ShowMessageAsync("Error", "Booking must be booked at 8am-4pm");
                        break;
                    }

                    else
                    {
                       
                        count = count + 1;
                    
                    }
                    A++;
                    if (ResultTable.Rows.Count <= A)
                    {
                        A = 0;
                        break;
                    }




                    
                }
                if (count >= 1)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Time has been booked");
                    count = 0;
                }
              

            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("Error: " + ex);
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
            }

        }


        public void PopulateBicycleData(ComboBox CBBike)
        {
            //string Bicycle = "BCE1000001";
            TBikeDAL MyDal = new TBikeDAL();
            DataTable ResultTable = MyDal.ShowAllBikeTable();
            string BikeID = Convert.ToString(ResultTable.Rows[0]["BicycleID"]).Trim();
            string BikeName = Convert.ToString(ResultTable.Rows[0]["BicycleName"]).Trim();

            CBBike.DataContext = ResultTable;
            CBBike.ItemsSource = ResultTable.Rows;
            CBBike.DisplayMemberPath = BikeName;
            CBBike.SelectedValuePath = BikeID; 


        }

        public void BindComboBox(ComboBox CBBike)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BicycleID,BicycleName From BicycleMaster", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BicycleMaster");
            CBBike.ItemsSource = ds.Tables[0].DefaultView;
            CBBike.DisplayMemberPath = ds.Tables[0].Columns["BicycleName"].ToString();
            CBBike.SelectedValuePath = ds.Tables[0].Columns["BicycleID"].ToString();
        }

        private void CBBike_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
  
}
