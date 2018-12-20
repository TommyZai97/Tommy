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
using System.Windows.Data;

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
        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int insertCounter = 0;
            int count = 0;
            //book button
            try
            {


                string BikeID = Convert.ToString(CBBike.SelectedValue).Trim();
                TBikeDAL MyDAL = new TBikeDAL();
                DateTime Start = Convert.ToDateTime(StartDate.SelectedDate.Value);

                TimeSpan CheckTime = new TimeSpan(08, 00, 00);
                TimeSpan endTime = new TimeSpan(16, 00, 00);



                DataTable ResultTable = new DataTable();
                DataTable ResultBikeTable = MyDAL.SelectBicycleByID(CBBike.SelectedValue.ToString().Trim());
                int bikeQuantity = Convert.ToInt32(ResultBikeTable.Rows[0]["Quantity"]);
                ResultTable = MyDAL.ShowBookingTableByBike(CBBike.SelectedValue.ToString().Trim(), "");
                if (bikeQuantity != 0) {

                    var dates = new List<DateTime>();
                    if (ResultTable.Rows.Count == 0)
                    {
                        MyDAL.AddBookingTime(Start, CBBike.SelectedValue.ToString().Trim(), "A", TBCustomer.Text, null, TLUsername.Text, null, null, TBRemarks.Text);
                        MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Information, "Success", "Booking made at :" + Start, "OK");
                        pop.ShowDialog();
                    }
                    for (int i = 0; i < ResultTable.Rows.Count; i++)
                    {
                        if (Convert.ToString(ResultTable.Rows[A]["BookingStatus"]).Trim() != "S")
                        {


                            DateTime GetDate = Convert.ToDateTime(ResultTable.Rows[A]["BookingDate"]);
                            if (Start.Date == GetDate && CBBike.SelectedValue.ToString().Trim() == Convert.ToString(ResultTable.Rows[A]["BicycleID"]).ToString().Trim())
                            {
                                count++;
                                break;
                            }

                            else if (Start.Date > DateTime.Now && Convert.ToDateTime(ResultTable.Rows[A]["BookingDate"]).Date < Start.Date && Start.TimeOfDay > CheckTime && Start.TimeOfDay < endTime)
                            {
                                insertCounter++;
                                A++;

                            }
                            else if (Start.Date < DateTime.Now)
                            {
                                MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Warning, "Sorry", "Date must be booked 1 day ahead from today", "OK");
                                pop.ShowDialog();
                                insertCounter = 0;
                                break;

                            }
                            else if (Start.TimeOfDay < CheckTime || Start.TimeOfDay > endTime)
                            {
                                MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Warning, "Sorry", "Booking must be booked at 8am-4pm", "OK");
                                pop.ShowDialog();
                                insertCounter = 0;
                                break;

                            }

                            else
                            {

                                count = count + 1;
                                A++;
                            }

                            if (ResultTable.Rows.Count <= A)
                            {
                                A = 0;
                                insertCounter++;
                                break;
                            }

                        }
                        else
                        {
                            A++;
                            insertCounter++;
                        }

                    }

                    if (count >= 1)
                    {
                        MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Warning, "Sorry", "Sorry Booking not made, This bike has been booked on " + Start.ToLongDateString(), "OK");
                        count = 0;
                        pop.ShowDialog();
                    }
                    else if (insertCounter >= 1)
                    {
                        MyDAL.AddBookingTime(Start, CBBike.SelectedValue.ToString().Trim(), "A", TBCustomer.Text, null, TLUsername.Text, null, null, TBRemarks.Text);
                        MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Information, "Success", "Bicycle: " + Convert.ToString(ResultTable.Rows[0]["BicycleName"]).Trim() + ", Booking made at :" + Start.ToLongDateString(), "OK");
                        insertCounter = 0;
                        pop.ShowDialog();
                    }



                }
                else
                {
                    MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Warning, "Sorry", "This bike has ran out of stock", "Sad :(");
                    pop.ShowDialog();
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.PopWindow pop = new MessageBox.PopWindow(AppData.ImageType.Error, "Error", ex.Message, "Sad :(");
                pop.ShowDialog();
            }
            finally
            {
                //dispose all counters
                A = 0;
                count = 0;
                insertCounter = 0;
                MainWindow main = new MainWindow();
                main.Notification();
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
            TBikeDAL MyDAL = new TBikeDAL();
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;

            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            if (index == -1)
            {
                index = 0;

            }
            //string cellValue = dataRow.Row.ItemArray[index].ToString();
            DataTable ResultTable = MyDAL.SelectBicycleByID(CBBike.SelectedValue.ToString().Trim());
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
            Column6.Header = "Quantity";
            Column6.Binding = new Binding("Quantity");
            Column7.Header = "Total Rents";
            Column7.Binding = new Binding("TotalRents");
            Column8.Header = "Price";
            Column8.Binding = new Binding("Price");
            Column9.Header = "Bicycle Color";
            Column9.Binding = new Binding("Color");
            Column9.Header = "Last Date Booked";
            Column9.Binding = new Binding("LastUpdatedAt");
            Column10.Header = "Created By";
            Column10.Binding = new Binding("CreatedBy");

            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BicycleStatus" }, ref ResultTable);
            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.IsReadOnly = true;
        }
        
    }
  
}
