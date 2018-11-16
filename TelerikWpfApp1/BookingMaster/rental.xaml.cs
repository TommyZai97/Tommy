using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TBike.AppData;
using TBike.MessageBox;

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
            TBikeDAL MyDAL = new TBikeDAL();
            MyDAL.BindSnackCombo(CBSnack);
        }

        private void BTNRent_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            try
            {
               
               
                TimeSpan duration = TPEnd.SelectedTime.Value - TPStart.SelectedTime.Value;
                if (CBBike.SelectedIndex != -1)
                {
                    DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(LBCustomer.Text.Trim(),"A");
                    string Bike = Convert.ToString(ResultTable.Rows[0]["BicycleID"]);
                    string BikeName = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
                    string customer = Convert.ToString(ResultTable.Rows[0]["CurrentRenter"]);
                    DateTime bookTime = Convert.ToDateTime(ResultTable.Rows[0]["BookingDate"]);
                    string BookingID = Convert.ToString(ResultTable.Rows[0]["BookingID"]).Trim();
                    //double Deposit = Convert.ToDouble(ResultTable.Rows[0]["BookingDeposit"]);
                    double Price = Convert.ToDouble(ResultTable.Rows[0]["Price"]);

                    //This is for booked rents
                    if (TPStart.SelectedTime < bookTime.TimeOfDay)
                    {
                       PopWindow pop = new PopWindow(ImageType.Error,"Sorry", "Can't rent time that is before booking time", "Okay");
                        pop.ShowDialog();
                    }
                    else
                    {
                        TimeSpan CheckTime = new TimeSpan(08, 00, 00);
                        TimeSpan endTime = new TimeSpan(20, 00, 00);

                        if (TPEnd.SelectedTime < CheckTime || TPEnd.SelectedTime > endTime)
                        {
                            PopWindow pop = new PopWindow(ImageType.Error,"Error", "Please rent in working hours about 8am to 8pm", "Okay");
                            pop.ShowDialog();
                        }
                        else
                        {
                            if (TPEnd.SelectedTime - TPStart.SelectedTime <= new TimeSpan(0, 30, 0))
                            {
                                PopWindow pop = new PopWindow(ImageType.Warning, "Too less time", "Please rent At least 30mins","Okay");
                                pop.ShowDialog();
                            }
                            else
                            {
                                //if bicycle status is Renting, dont rent bike
                                if (Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]) == "R")
                                {
                                    PopWindow pop = new PopWindow(ImageType.Warning,"Sorry", "This Bike has been rented By, " + customer.Trim(), "Okay");
                                    pop.ShowDialog();
                                }
                                //if able to rent start process add
                                else
                                {
                                    double TotalPrice = (((double)duration.TotalHours) * Price);
                                    TotalPrice = System.Math.Round(TotalPrice, 2);

                                    ConfirmWindow confirm = new ConfirmWindow(ImageType.Question, "Confirm?", "Bicycle " + BikeName + ", for Renter " + LBCustomer.Text + ", Duration is " + duration + " Hours, " + " Total Price: RM" + TotalPrice, "Yes, Rent Out", "No, Don't Rent");
                                    confirm.ShowDialog();
                                    //MessageBox.Show("Rented For " + LBCustomer.Text + " Duration is " + Convert.ToString(duration.Hours).Trim() + " Hours","Question",MessageBoxButton.YesNo,MessageBoxImage.Information);
                                    if (confirm.Confirmed)
                                    {
                                        if (SnackPanel.Visibility == Visibility.Visible)
                                        {
                                            MyDAL.AddSnackSales(CBSnack.SelectedValue.ToString().Trim(), Convert.ToInt32(TBQuantity.Text), LBCustomer.Text.Trim(),TLUsername.Text.Trim(),BookingID);

                                        }

                                        MyDAL.UpdateBikeStatus(Bike, LBCustomer.Text.Trim(), "R", "", null, null, TLUsername.Text);
                                        MyDAL.UpdateBookingDate(Convert.ToDateTime(LBBookingDate.Text), Bike, LBCustomer.Text.Trim(), TotalPrice, "R", TLUsername.Text.Trim(), TPStart.SelectedTime, TPEnd.SelectedTime, TBRemarks.Text);
                                        PopWindow pop = new PopWindow(ImageType.Information, "Success rent","Bicycle " + BikeName + ", for Renter " + LBCustomer.Text + ", Duration is " + duration + " Hours, " + " Total Price: RM" + TotalPrice +" ,has been Rented","OK");
                                        CBBike.SelectedIndex = 0;
                                        stack1.Visibility = Visibility.Hidden;
                                        TPStart.Visibility = Visibility.Hidden;
                                        TPEnd.Visibility = Visibility.Hidden;
                                    }
                                    else
                                    {
                                        PopWindow pop = new PopWindow(ImageType.Warning, "Cancel", "Rented Canceled by " + TLUsername.Text, "Okay");
                                        pop.ShowDialog();
                                    }
                                }
                            }
                        }

                    }


                }
                // This is for adding new rent
                else if (TPStart.SelectedTime < DateTime.Now.TimeOfDay)
                {
                    PopWindow pop = new PopWindow(ImageType.Warning,"Sorry", "Can't rent time that is before the current time","Okay");
                    pop.ShowDialog();
                }
                else if (CBBicycle.SelectedIndex != -1)
                {
                    TimeSpan CheckTime = new TimeSpan(08, 00, 00);
                    TimeSpan endTime = new TimeSpan(20, 00, 00);
                    

                    if (TPEnd.SelectedTime < CheckTime || TPEnd.SelectedTime > endTime)
                    {
                        PopWindow pop = new PopWindow(ImageType.Warning, "Error", "Please rent in working hours about 8am to 8pm","Okay");
                        pop.ShowDialog();
                    }
                    else
                    {
                        if (TPEnd.SelectedTime - TPStart.SelectedTime <= new TimeSpan(0, 30, 0))
                        {
                            PopWindow pop = new PopWindow(ImageType.Warning,"Error", "Please rent At least 30mins","Okay");
                            pop.ShowDialog();
                        }
                        else
                        {
                            DataTable ResultTable = MyDAL.SelectBicycleByID(CBBicycle.SelectedValue.ToString().Trim());
                            string Bike = Convert.ToString(ResultTable.Rows[0]["BicycleID"]);
                            string BikeName = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
                            string customer = TBCustomer.Text;

                            //double Deposit = Convert.ToDouble(ResultTable.Rows[0]["BookingDeposit"]);
                            double Price = Convert.ToDouble(ResultTable.Rows[0]["Price"]);

                            if (Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]) == "R")
                            {
                                PopWindow pop = new PopWindow(ImageType.Warning, "Sorry", "This Bike has been rented By, " + customer.Trim(),"Okay");
                                pop.ShowDialog();
                            }
                            //if able to rent start process add
                            else
                            {
                                double TotalPrice = (((double)duration.TotalHours) * Price);
                                TotalPrice = System.Math.Round(TotalPrice, 2);

                              ConfirmWindow con = new ConfirmWindow(ImageType.Question, "Confirm", "Bicycle " + BikeName + ", for Renter " + LBCustomer.Text + ", Duration is " + duration + " Hours, " + " Total Price: RM" + TotalPrice,"Yes, Rent","No, Don't");
                                con.ShowDialog();
                                //MessageBox.Show("Rented For " + LBCustomer.Text + " Duration is " + Convert.ToString(duration.Hours).Trim() + " Hours","Question",MessageBoxButton.YesNo,MessageBoxImage.Information);
                                if (con.Confirmed)
                                {
                                   

                                    MyDAL.AddBookingTime(DateTime.Now.Date, Bike, "R", LBCustomer.Text.Trim(), TotalPrice, TLUsername.Text.Trim(), TPStart.SelectedTime, TPEnd.SelectedTime, TBRemarks.Text);
                                    if (SnackPanel.Visibility == Visibility.Visible)
                                    {
                                        MyDAL.AddSnackSales(CBSnack.SelectedValue.ToString().Trim(), Convert.ToInt32(TBQuantity.Text), LBCustomer.Text.Trim(), TLUsername.Text.Trim(),"");
                                    }
                                    PopWindow pop = new PopWindow(ImageType.Information,"Complete", "Rented Out by " + TLUsername.Text,"Okay");
                                    pop.ShowDialog();
                                    TBCustomer.Text = "";
                                    CBBicycle.SelectedIndex = 0;
                                    stack1.Visibility = Visibility.Hidden;
                                    TPStart.Visibility = Visibility.Hidden;
                                    TPEnd.Visibility = Visibility.Hidden;
                                }
                                else
                                {
                                    PopWindow pop = new PopWindow(ImageType.Warning,"Cancel", "Rented Canceled by " + TLUsername.Text,"Okay");
                                    pop.ShowDialog();
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Information, "Error", ex.Message, "I will Fix this");
                pop.ShowDialog();
            }

        }

       

      
        public void PopulateDataFromLogin(string Values)
        {
            // to populate the ranks and usernames
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

        public void PopulateID(string Customer, string Status)
        {
            //Populate items from the booking datatable
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(Customer,"A");

            if (ResultTable.Rows.Count != 0)
            {
                BindComboBox(CBBike);
                CBBike.SelectedIndex = CBBike.Items.Count - 1;
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
                stack1.Visibility = Visibility.Visible;
                TBCustomer.Visibility = Visibility.Hidden;
                BTNNext.Visibility = Visibility.Hidden;
                CBBicycle.Visibility = Visibility.Hidden;
                LBNewTitle.Visibility = Visibility.Hidden;

            }
            else
            {
                PopWindow pop = new PopWindow(ImageType.Error,"Error", "No data Found!!!","OK");
                pop.ShowDialog();
            }
                
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            LBCustomer.Text = CBBike.SelectedValue.ToString().Trim();
            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(CBBike.SelectedValue.ToString().Trim(),"A");
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
            stack1.Visibility = Visibility.Visible;
            
            //New Rentals
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //the next button
            if (TBCustomer.Text != null && CBBicycle.SelectedValue != null)
            {
                stack1.Visibility = Visibility.Visible;
                LBCustomer.Text = TBCustomer.Text;
                LBBike.Text = CBBicycle.Text;
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
                PopWindow pop = new PopWindow(ImageType.Error,"Error","Please Fill in all blanks","OK");
                pop.ShowDialog();
            }
        }

        private void TBQuantity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CheckSnacks_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckSnacks.IsChecked ?? true)
            {
                SnackPanel.Visibility = Visibility.Visible;
            }
            else 
            {
                SnackPanel.Visibility = Visibility.Hidden;
            }
        }
    }
}
