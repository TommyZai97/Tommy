using System;
using System.Collections.Generic;
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
using System.Data;
using MahApps.Metro.Controls;
using System.Data.SqlClient;
using MahApps.Metro.Controls.Dialogs;

namespace TBike.BookingMaster
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Service : MetroWindow
    {
        string username;
        int RankID;
        static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["123"].ConnectionString;


        public Service()
        {
            InitializeComponent();
            BindComboBoxBicycle(CBBicycle);
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

        public void BindComboBoxBicycle(ComboBox CBBicycle)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BicycleID,BicycleName From BicycleMaster WHERE BicycleStatus = 'I' OR BicycleStatus = 'M'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BicycleMaster");
            CBBicycle.ItemsSource = ds.Tables[0].DefaultView;
            CBBicycle.DisplayMemberPath = ds.Tables[0].Columns["BicycleName"].ToString();
            CBBicycle.SelectedValuePath = ds.Tables[0].Columns["BicycleID"].ToString();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.SelectBicycleByID(CBBicycle.SelectedValue.ToString().Trim());
            DataTable ResultTable2 = MyDAL.SelectServiceByBike(CBBicycle.SelectedValue.ToString().Trim());
            LBBicycleName.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]);
            LBStatus.Text = Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]);

         


            if (LBStatus.Text == "I")
            {
                LBStatus.Text = "Invalid";
            }

          
            if (LBStatus.Text == "M")
            {
                LBStatus.Text = "Maintainance";
                PickStart.SelectedDate = Convert.ToDateTime(ResultTable2.Rows[0]["ServiceStart"]);
                PickEnd.SelectedDate = Convert.ToDateTime(ResultTable2.Rows[0]["ServiceEnd"]);
            }
            TBCondition.Text = Convert.ToString(ResultTable.Rows[0]["Condition"]);
          
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LBStatus.Text == "Invalid")
            {
                //send to repair button
                string repairCondition = ("Servicing, Reason: " + TBCondition.Text);
                TBikeDAL MyDAL = new TBikeDAL();
                var res = await this.ShowMessageAsync("Confirmation", "Are you sure to send this to Service? ", MessageDialogStyle.AffirmativeAndNegative);
                if (res == MessageDialogResult.Affirmative)
                {
                    MyDAL.UpdateBikeStatus(CBBicycle.SelectedValue.ToString().Trim(), "", "M", repairCondition.Trim(),PickStart.SelectedDate, PickEnd.SelectedDate, TLUsername.Text);
                    res = await this.ShowMessageAsync("Done", "Bicycle Send for Service");

                }
            }

        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //return from repair btn
            if (LBStatus.Text == "Maintainance")
            {
                string repairCondition = "";
                TBikeDAL MyDAL = new TBikeDAL();

                MyDAL.UpdateBikeStatus(CBBicycle.SelectedValue.ToString().Trim(), "", "A", repairCondition.Trim(),PickStart.SelectedDate,PickEnd.SelectedDate,TLUsername.Text);
                var res = await this.ShowMessageAsync("Done", "Bicycle Has been Returned");
            }
            
        }

        private void PickStart_SelectedDateChanged(object sender, TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
        {
            if (PickEnd.SelectedDate != null)
            LBDuration.Text = Convert.ToString(PickEnd.SelectedDate.Value - PickStart.SelectedDate.Value) ;
        }

        private void PickEnd_SelectedDateChanged(object sender, TimePickerBaseSelectionChangedEventArgs<DateTime?> e)
        {
            if (PickStart.SelectedDate != null)
                LBDuration.Text = Convert.ToString(PickEnd.SelectedDate.Value - PickStart.SelectedDate.Value) + "Days";
        }
    }
}
