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
using System.Windows.Navigation;
using MahApps.Metro.Controls.Dialogs;

namespace TBike
{
    /// <summary>
    /// Interaction logic for Return.xaml
    /// </summary>
    public partial class Return : MetroWindow
    {
        string username;
        int RankID;
        string Customer;

        static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["123"].ConnectionString;


        public Return()
        {
            InitializeComponent();
            BindComboBox(CBBike);
            BindComboBoxCustomer(CBCustomer);
            

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

        public void BindComboBoxCustomer(ComboBox CBCustomer)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Customer From BikeBookingMaster WHERE BookingStatus = 'N'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BikeBookingMaster");
            CBCustomer.ItemsSource = ds.Tables[0].DefaultView;
            CBCustomer.DisplayMemberPath = ds.Tables[0].Columns["Customer"].ToString();
            CBCustomer.SelectedValuePath = ds.Tables[0].Columns["Customer"].ToString();
        }
    
    public void BindComboBox(ComboBox CBBike)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BicycleID,BicycleName From BicycleMaster WHERE BicycleStatus = 'R'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BicycleMaster");
            CBBike.ItemsSource = ds.Tables[0].DefaultView;
            CBBike.DisplayMemberPath = ds.Tables[0].Columns["BicycleName"].ToString();
            CBBike.SelectedValuePath = ds.Tables[0].Columns["BicycleID"].ToString();
            
        }

        public void BindCBExpired(ComboBox ListBicycle)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BicycleID,BicycleName From BicycleMaster WHERE BicycleStatus = 'N' and CurrentRenter='"+ CBCustomer.SelectedValue.ToString().Trim()+"'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BicycleMaster");
            ListBicycle.ItemsSource = ds.Tables[0].DefaultView;
            ListBicycle.DisplayMemberPath = ds.Tables[0].Columns["BicycleName"].ToString();
            ListBicycle.SelectedValuePath = ds.Tables[0].Columns["BicycleID"].ToString();

        }

        public async void PopulateID(string Customer, string Status)
        {

            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(Customer);

            if (ResultTable.Rows.Count != 0)
            {

                LBCustomer.Text = Customer;

                LBBookingDate.Text = Convert.ToString(ResultTable.Rows[0]["BookingDate"]);
                LBBicycle.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
                LBRemarks.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]);
           
            }
            else
            {
                var res = await this.ShowMessageAsync("Error", "No data Found!!!");
            }


        }

        private async void BTNReturn_Click(object sender, RoutedEventArgs e)
        {
            string DamageStatus = "A";
            if ((CBStatus.IsChecked ?? true) || (CBStatus_Copy.IsChecked ?? true))
            {
                DamageStatus = "I";
            }
            TBikeDAL MyDAL = new TBikeDAL();
            if (ExpiredStack.Visibility == Visibility.Hidden)
            {
                if (CBBike.SelectedValue != null)
                {

                    MyDAL.UpdateBookingStatus("S", CBBike.SelectedValue.ToString().Trim(), Customer, TLUsername.Text);
                    MyDAL.UpdateBikeStatus(CBBike.SelectedValue.ToString().Trim(),"", DamageStatus, TBCondition.Text, null, Convert.ToDateTime(null), TLUsername.Text);
                    Return ret = new Return();
                    this.Close();
                    ret.PopulateDataFromLogin(username);
                    ret.Show();
                   var res = await this.ShowMessageAsync("Bicycle: " , CBBike.SelectedValue.ToString().Trim() + " Returned");
                }

                else
                {
                    MessageBox.Show("No Bicycle Available for return");
                }
            }
            else
            {
                if (CBCustomer.SelectedValue != null)
                {
                    MyDAL.UpdateBookingStatus("S", ListBicycle.SelectedValue.ToString().Trim(), CBCustomer.SelectedValue.ToString().Trim(), TLUsername.Text);
                    MyDAL.UpdateBikeStatus(ListBicycle.SelectedValue.ToString().Trim(),"", DamageStatus,TBCondition.Text,null, Convert.ToDateTime(null), TLUsername.Text);
                    Return ret = new Return();
                    this.Close();
                    ret.PopulateDataFromLogin(username);
                    ret.Show();
                    var res = await this.ShowMessageAsync("Late Returned Bicycle: " , ListBicycle.SelectedValue.ToString().Trim() + " Returned");
                }
                else
                {

                    MessageBox.Show("No Bicycle Available for return");
                }
            }
            

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            RentalProcessing rent = new RentalProcessing();
            rent.PopulateDataFromLogin(username);
            rent.Show();
            this.Close();
        }

        private void CBBike_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowBookingTableByBike(CBBike.SelectedValue.ToString().Trim(),"R");
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "BookingStatus" }, ref ResultTable);
            LBCustomer.Text = Convert.ToString(ResultTable.Rows[0]["Customer"]);
            Customer = LBCustomer.Text;
            LBBookingDate.Text = Convert.ToString(ResultTable.Rows[0]["BookingDate"]);
            LBBicycle.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
            LBRemarks.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]);
        }

        private void BTNExpired_Click(object sender, RoutedEventArgs e)
        {
            
            if (ExpiredStack.Visibility == Visibility.Visible)
            {
                StackHelo.Visibility = Visibility.Visible;
                Rect1.Visibility = Visibility.Visible;
                CBBike.Visibility = Visibility.Visible;
                LBCustomer.Visibility = Visibility.Visible;
                LBBookingDate.Visibility = Visibility.Visible;
                LBBicycle.Visibility = Visibility.Visible;
                LBRemarks.Visibility = Visibility.Visible;
                //if stack is visible set stack as hidden
                ExpiredStack.Visibility = Visibility.Hidden;
                BTNExpired.Foreground = Brushes.Black;
            }
            else
            {
                StackHelo.Visibility = Visibility.Hidden;
                Rect1.Visibility = Visibility.Hidden;
                LBBookingDate.Visibility = Visibility.Hidden;
                LBBicycle.Visibility = Visibility.Hidden;
                LBRemarks.Visibility = Visibility.Hidden;
                BTNExpired.Foreground = Brushes.Red;
                CBBike.Visibility = Visibility.Hidden;
                LBCustomer.Visibility = Visibility.Hidden;
                //if stack is hidden set stack as visible
                ExpiredStack.Visibility = Visibility.Visible;
            }
        }

        private void CBCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            
            DataTable ResultTable = MyDAL.ShowBookingTableByCustomer(CBCustomer.SelectedValue.ToString().Trim());
            LBName.Text = Convert.ToString(ResultTable.Rows[0]["Customer"]);
            LBDate.Text = Convert.ToString(ResultTable.Rows[0]["BookingDate"]);
            BindCBExpired(ListBicycle);


        }

        private void CBStatus_Checked(object sender, RoutedEventArgs e)
        {
            if ((CBStatus.IsChecked ?? true) || (CBStatus_Copy.IsChecked ?? true))
            {
                TBCondition.Visibility = Visibility.Visible;
            }
            else
            {
                TBCondition.Visibility = Visibility.Hidden;
            }
        }
    }
}
