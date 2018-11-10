using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using MahApps.Metro.Controls;
using System.Data.SqlClient;
using TBike.AppData;
using TBike.MessageBox;

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

   

        public void PopulateID(string BicycleID,string Status)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectServiceByBike(BicycleID);
            DataTable ResultBikeTable = MyDAL.SelectBicycleByID(BicycleID);
            LBBicycleName.Text = Convert.ToString(ResultBikeTable.Rows[0]["BicycleName"]);
            LBStatus.Text = Convert.ToString(ResultBikeTable.Rows[0]["BicycleStatus"]);

            BindComboBoxBicycle(CBBicycle);
            CBBicycle.SelectedIndex = CBBicycle.Items.Count - 1;
            if (LBStatus.Text == "M")
            {
                LBStatus.Text = "Maintenance";
                TBCondition.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]);
                PickStart.SelectedDate = Convert.ToDateTime(ResultTable.Rows[0]["ServiceStart"]);
                PickEnd.SelectedDate = Convert.ToDateTime(ResultTable.Rows[0]["ServiceEnd"]);
                LBDuration.Text = Convert.ToString(PickEnd.SelectedDate.Value - PickStart.SelectedDate.Value) + "Days";
            }
            else if (LBStatus.Text == "I")
            {
                LBStatus.Text = "InActive";
                TBCondition.Text = Convert.ToString(ResultTable.Rows[0]["Remark"]);
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
                LBStatus.Text = "Maintenance";
                PickStart.SelectedDate = Convert.ToDateTime(ResultTable2.Rows[0]["ServiceStart"]);
                PickEnd.SelectedDate = Convert.ToDateTime(ResultTable2.Rows[0]["ServiceEnd"]);
            }
            TBCondition.Text = Convert.ToString(ResultTable.Rows[0]["Condition"]);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (LBStatus.Text == "Invalid")
                {
                    //send to repair button
                    string repairCondition = ("Servicing, Reason: " + TBCondition.Text);
                    TBikeDAL MyDAL = new TBikeDAL();
                    ConfirmWindow confirm = new ConfirmWindow(ImageType.Question ,"Confirmation", "Are you sure to send this to Service? ", "Yes","No");
                    confirm.ShowDialog();
                    if (confirm.Confirmed) 
                    {
                        MyDAL.UpdateBikeStatus(CBBicycle.SelectedValue.ToString().Trim(), "", "M", repairCondition.Trim(), PickStart.SelectedDate, PickEnd.SelectedDate, TLUsername.Text);
                        PopWindow pop = new PopWindow(ImageType.Information , "Done", "Bicycle Send for Service", "OK");
                        pop.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Error ,"Error", ex.Message,"OK");
                pop.ShowDialog();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //return from repair btn
            try
            {
                if (LBStatus.Text == "Maintenance")
                {
                    string repairCondition = "";
                    TBikeDAL MyDAL = new TBikeDAL();
                    string BicycleID = CBBicycle.SelectedValue.ToString().Trim();
                    MyDAL.UpdateBikeStatus(BicycleID, "", "A", repairCondition.Trim(), PickStart.SelectedDate, PickEnd.SelectedDate, TLUsername.Text);
                    PopWindow pop = new PopWindow(ImageType.Information ,"Done","Bicycle Has been Returned", "OK");
                    pop.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Information ,"Error" , ex.Message, "OK");
                pop.ShowDialog();
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
