using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for rental.xaml
    /// </summary>
    public partial class rental : MetroWindow
    {
        static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["123"].ConnectionString;

        string username;
        int RankID;
        public rental()
        {
            InitializeComponent();
            BindComboBox(CBBike);
        }

        private async void BTNRent_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(CBBike.SelectedValue.ToString().Trim());

            TimeSpan duration = TPEnd.SelectedTime.Value - TPStart.SelectedTime.Value;
           
            
            string Bike = Convert.ToString(ResultTable.Rows[0]["BicycleID"]);
            string BikeName = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
            //double Deposit = Convert.ToDouble(ResultTable.Rows[0]["BookingDeposit"]);
            double Price = Convert.ToDouble(ResultTable.Rows[0]["Price"]);
            try
            {
                //if bicycle status is Renting, dont rent bike
                if (Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]) == "R")
                {
                    MessageBox.Show("This Bike Has been rented, Please wait for it to return");
                }
                //if able to rent start process add
                else
                {
                    double TotalPrice =( ((int)duration.Hours) * Price);
                    var res = await this.ShowMessageAsync("Confirm","Bicycle "+ BikeName + ", for Renter " + LBCustomer.Text + ", Duration is " + duration.Hours +" Hours, "+ " Total Price: RM"+ TotalPrice , MessageDialogStyle.AffirmativeAndNegative);
                    Console.WriteLine(res);
                    //MessageBox.Show("Rented For " + LBCustomer.Text + " Duration is " + Convert.ToString(duration.Hours).Trim() + " Hours","Question",MessageBoxButton.YesNo,MessageBoxImage.Information);
                    if (res == MessageDialogResult.Affirmative)
                    {

                        MyDAL.AddBookingTime(Convert.ToDateTime(LBBookingDate.Text), Bike, "R", CBBike.SelectedValue.ToString().Trim(), TotalPrice, TLUsername.Text.Trim(), TPStart.SelectedTime, TPEnd.SelectedTime, TBRemarks.Text);
                        res = await this.ShowMessageAsync("Complete", "Rented Out by " + TLUsername.Text );
                    }
                    else
                    {
                        res = await this.ShowMessageAsync("Cancel", "Rented Canceled by " + TLUsername.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

       

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            RentalProcessing rent = new RentalProcessing();
            rent.PopulateDataFromLogin(username);
            rent.Show();
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            LBCustomer.Text = CBBike.SelectedValue.ToString().Trim();
            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(CBBike.SelectedValue.ToString().Trim());
            LBBookingDate.Text = Convert.ToString(ResultTable.Rows[0]["BookingDate"]);
            LBBike.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
            TBRemarks.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]);
        }

        public void BindComboBox(ComboBox CBBike)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Customer From BikeBookingMaster WHERE BookingStatus = 'A'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BikeBookingMaster");
            CBBike.ItemsSource = ds.Tables[0].DefaultView;
            CBBike.DisplayMemberPath = ds.Tables[0].Columns["Customer"].ToString();
            CBBike.SelectedValuePath = ds.Tables[0].Columns["Customer"].ToString();
        }

    
    }
}
