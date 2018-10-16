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

namespace TBike
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
            BindComboBoxBicycle(CBBicycle);
            BindComboBox(CBBike);
        }

        private async void BTNRent_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            try
            {
                TimeSpan duration = TPEnd.SelectedTime.Value - TPStart.SelectedTime.Value;
                if (CBBike.SelectedIndex != -1)
                {
                    DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(LBCustomer.Text.Trim());
                    string Bike = Convert.ToString(ResultTable.Rows[0]["BicycleID"]);
                    string BikeName = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
                    string customer = Convert.ToString(ResultTable.Rows[0]["CurrentRenter"]);
                    DateTime bookTime = Convert.ToDateTime(ResultTable.Rows[0]["BookingDate"]);
                    //double Deposit = Convert.ToDouble(ResultTable.Rows[0]["BookingDeposit"]);
                    double Price = Convert.ToDouble(ResultTable.Rows[0]["Price"]);
                    if (TPStart.SelectedTime < bookTime.TimeOfDay)
                    {
                        var res = await this.ShowMessageAsync("Sorry", "Can't rent time that is before booking time");

                    }
                    else
                    {

                        if (TPStart.SelectedTime < DateTime.Now.TimeOfDay)
                        {
                            var res = await this.ShowMessageAsync("Sorry", "Can't rent time that is before the current time");

                        }
                        else
                        {
                            //if bicycle status is Renting, dont rent bike
                            if (Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]) == "R")
                            {
                                var res = await this.ShowMessageAsync("Sorry", "This Bike has been rented By, " + customer.Trim());
                            }
                            //if able to rent start process add
                            else
                            {
                                double TotalPrice = (((double)duration.TotalHours) * Price);
                                TotalPrice = System.Math.Round(TotalPrice, 2);

                                var res = await this.ShowMessageAsync("Confirm", "Bicycle " + BikeName + ", for Renter " + LBCustomer.Text + ", Duration is " + duration + " Hours, " + " Total Price: RM" + TotalPrice, MessageDialogStyle.AffirmativeAndNegative);
                                Console.WriteLine(res);
                                //MessageBox.Show("Rented For " + LBCustomer.Text + " Duration is " + Convert.ToString(duration.Hours).Trim() + " Hours","Question",MessageBoxButton.YesNo,MessageBoxImage.Information);
                                if (res == MessageDialogResult.Affirmative)
                                {

                                    MyDAL.UpdateBikeStatus( Bike,  LBCustomer.Text.Trim(), "R", "",null,null,TLUsername.Text);
                                    MyDAL.UpdateBookingDate(Convert.ToDateTime(LBBookingDate.Text), Bike, LBCustomer.Text.Trim(), TotalPrice, "R",TLUsername.Text.Trim(), TPStart.SelectedTime, TPEnd.SelectedTime, TBRemarks.Text);
                                    res = await this.ShowMessageAsync("Complete", "Rented Out by " + TLUsername.Text);
                                }
                                else
                                {
                                    res = await this.ShowMessageAsync("Cancel", "Rented Canceled by " + TLUsername.Text);
                                }
                            }
                        }
                    }


                }
                // This is for adding new rent
                if (TPStart.SelectedTime < DateTime.Now.TimeOfDay)
                {
                    var res = await this.ShowMessageAsync("Sorry", "Can't rent time that is before the current time");

                }
                else if (CBBicycle.SelectedIndex != -1)
                {
                    DataTable ResultTable = MyDAL.SelectBicycleByID(CBBicycle.SelectedValue.ToString().Trim());
                    string Bike = Convert.ToString(ResultTable.Rows[0]["BicycleID"]);
                    string BikeName = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
                    string customer = TBCustomer.Text;
                    
                    //double Deposit = Convert.ToDouble(ResultTable.Rows[0]["BookingDeposit"]);
                    double Price = Convert.ToDouble(ResultTable.Rows[0]["Price"]);

                    if (Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]) == "R")
                    {
                        var res = await this.ShowMessageAsync("Sorry", "This Bike has been rented By, " + customer.Trim());
                    }
                    //if able to rent start process add
                    else
                    {
                        double TotalPrice = (((double)duration.TotalHours) * Price);
                        TotalPrice = System.Math.Round(TotalPrice, 2);

                        var res = await this.ShowMessageAsync("Confirm", "Bicycle " + BikeName + ", for Renter " + LBCustomer.Text + ", Duration is " + duration + " Hours, " + " Total Price: RM" + TotalPrice, MessageDialogStyle.AffirmativeAndNegative);
                        Console.WriteLine(res);
                        //MessageBox.Show("Rented For " + LBCustomer.Text + " Duration is " + Convert.ToString(duration.Hours).Trim() + " Hours","Question",MessageBoxButton.YesNo,MessageBoxImage.Information);
                        if (res == MessageDialogResult.Affirmative)
                        {

                            MyDAL.AddBookingTime(Convert.ToDateTime(LBBookingDate.Text), Bike, "R", LBCustomer.Text.Trim(), TotalPrice, TLUsername.Text.Trim(), TPStart.SelectedTime, TPEnd.SelectedTime, TBRemarks.Text);
                            res = await this.ShowMessageAsync("Complete", "Rented Out by " + TLUsername.Text);
                        }
                        else
                        {
                            res = await this.ShowMessageAsync("Cancel", "Rented Canceled by " + TLUsername.Text);
                        }
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

        public async void PopulateID(string Customer, string Status)
        {
            
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(Customer);

            if (ResultTable.Rows.Count != 0)
            {

                LBCustomer.Text = Customer;
                
                LBBookingDate.Text = Convert.ToString(ResultTable.Rows[0]["BookingDate"]);
                LBBike.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
                TBRemarks.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]);
                LBCustomer.Visibility = Visibility.Visible;
                LBBike.Visibility = Visibility.Visible;
                LBBookingDate.Visibility = Visibility.Visible;
                rect.Visibility = Visibility.Visible;
                TBRemarks.Visibility = Visibility.Visible;
                LB1.Visibility = Visibility.Visible;
                LB2.Visibility = Visibility.Visible;
                LB3.Visibility = Visibility.Visible;

                TBCustomer.Visibility = Visibility.Hidden;
                BTNNext.Visibility = Visibility.Hidden;
                CBBicycle.Visibility = Visibility.Hidden;
                LBNewTitle.Visibility = Visibility.Hidden;
            }
            else
            {
                var res = await this.ShowMessageAsync("Error", "No data Found!!!");
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
            LBCustomer.Visibility = Visibility.Visible;
            LBBike.Visibility = Visibility.Visible;
            LBBookingDate.Visibility = Visibility.Visible;
            rect.Visibility = Visibility.Visible;
            TBRemarks.Visibility = Visibility.Visible;
            LB1.Visibility = Visibility.Visible;
            LB2.Visibility = Visibility.Visible;
            LB3.Visibility = Visibility.Visible;

            TBCustomer.Visibility = Visibility.Hidden;
            CBBicycle.Visibility = Visibility.Hidden;
            BTNNext.Visibility = Visibility.Hidden;
            LBNewTitle.Visibility = Visibility.Hidden;
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

        public void BindComboBoxBicycle(ComboBox CBBicycle)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BicycleID,BicycleName From BicycleMaster WHERE BicycleStatus = 'A'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BicycleMaster");
            CBBicycle.ItemsSource = ds.Tables[0].DefaultView;
            CBBicycle.DisplayMemberPath = ds.Tables[0].Columns["BicycleName"].ToString();
            CBBicycle.SelectedValuePath = ds.Tables[0].Columns["BicycleID"].ToString();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TBCustomer.Text != null && CBBicycle.SelectedValue != null)
            {

                LBCustomer.Text = TBCustomer.Text;
                LBBike.Text = CBBicycle.SelectedValue.ToString().Trim() ;
                LBBookingDate.Text = Convert.ToString(DateTime.Now);

                LBCustomer.Visibility = Visibility.Visible;
                LBBike.Visibility = Visibility.Visible;
                LBBookingDate.Visibility = Visibility.Visible;
                rect.Visibility = Visibility.Visible;
                TBRemarks.Visibility = Visibility.Visible;
                LB1.Visibility = Visibility.Visible;
                LB2.Visibility = Visibility.Visible;
                LB3.Visibility = Visibility.Visible;
            }

            else
            {
                var res = await this.ShowMessageAsync("Error","Please Fill in all blanks");
            }
        }


    }
}
