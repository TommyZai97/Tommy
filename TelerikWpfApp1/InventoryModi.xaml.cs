using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for InventoryModi.xaml
    /// </summary>
    public partial class InventoryModi : MetroWindow
    {
        string username;
        int RankID;
        string MainStatus;
        public InventoryModi()
        {
            InitializeComponent();
         
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            InventoryManage inv = new InventoryManage();
            inv.Show();
            inv.PopulateDataFromLogin(username);
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

        public void PopulateBikeDataTable()
        {

            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowAllBikeTable();


            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.CanUserAddRows = false;



        }

        public void PopulateSnackDataTable()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowAllSnackTable();


            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.CanUserAddRows = false;
        }



        public async void PopulateID(string ID,string Category,string Status)
        {
            MainStatus = Status;
            TBikeDAL MyDAL = new TBikeDAL();
            if (Status == "Modification")
            {
                if (Category == "Bicycle")
                {
                    LBTitle.Text = "Bicycle";
                    DataTable ResultTable = MyDAL.SelectBicycleByID(ID);
                    if (ResultTable.Rows.Count != 0)
                    {
                        LBID.Text = ID;
                        TBName.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]).Trim();
                        TBType.Text = Convert.ToString(ResultTable.Rows[0]["BicycleType"]).Trim();
                        TBPrice.Text = Convert.ToString(ResultTable.Rows[0]["Price"]).Trim();
                        TBColor.Text = Convert.ToString(ResultTable.Rows[0]["Color"]).Trim();
                        PopulateBikeDataTable();
                    }
                    else
                    {
                        var res = await this.ShowMessageAsync("Error", "No data Found!!!");
                    }
                }
                else if (Category == "Snacks")
                {
                    LBTitle.Text = "Snacks";
                    LBColor.Text = "Quantity";
                    DataTable ResultTable = MyDAL.SelectSnackByID(ID);
                    if (ResultTable.Rows.Count != 0)
                        LBID.Text = ID;
                    TBName.Text = Convert.ToString(ResultTable.Rows[0]["SnackName"]).Trim();
                    TBType.Text = Convert.ToString(ResultTable.Rows[0]["SnackType"]).Trim();
                    TBPrice.Text = Convert.ToString(ResultTable.Rows[0]["Price"]).Trim();
                    TBColor.Text = Convert.ToString(ResultTable.Rows[0]["Quantity"]).Trim();
                    PopulateSnackDataTable();
                }
                else
                {
                    var res = await this.ShowMessageAsync("Error", "Incorrect Category");
                }
            }

            else if(Status == "Add"){
                LBTitle.Text = Category;
                LBID.Text = "** New **";
                BTNPro.Content = "Add";
                if (Category == "Snacks")
                {
                    LBColor.Text = "Quantity";
                    PopulateSnackDataTable();
                }
                else if (Category == "Bicycle")
                {
                    PopulateBikeDataTable();
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Update Button
            if (MainStatus == "Modification")
            {

                UpdateAllItems();
            }
            else if (MainStatus == "Add") 
            {
                AddNewItems();
            }
        }
        public async void AddNewItems()
        {
            try
            {


                if (LBTitle.Text == "Bicycle")
                {
                    PopulateBikeDataTable();
                    if (LBID.Text != null)
                    {
                        TBikeDAL MyDAL = new TBikeDAL();
                        var res = await this.ShowMessageAsync("Confirmation", "Are you sure to add new data?", MessageDialogStyle.AffirmativeAndNegative);
                        if (res == MessageDialogResult.Affirmative)
                        {
                            MyDAL.AddBicycleTable(TBName.Text, TBType.Text, Convert.ToDouble(TBPrice.Text), TBColor.Text, username);
                        }
                    }
                }
                else if (LBTitle.Text == "Snacks")
                {
                    PopulateSnackDataTable();
                    TBikeDAL MyDAL = new TBikeDAL();
                    var res = await this.ShowMessageAsync("Confirmation", "Are you sure to add new data?", MessageDialogStyle.AffirmativeAndNegative);
                    if (res == MessageDialogResult.Affirmative)
                    {
                        MyDAL.AddSnackTable( TBName.Text, TBType.Text, Convert.ToDouble(TBPrice.Text), Convert.ToInt32(TBColor.Text), username);
                    }
                }
            }
            catch (Exception ex)
            {
                var res = await this.ShowMessageAsync("Error", ex.Message);
            }
        }
    

        public async void UpdateAllItems()
        {
            try
            {


                if (LBTitle.Text == "Bicycle")
                {
                    if (LBID.Text != null)
                    {
                        TBikeDAL MyDAL = new TBikeDAL();
                        var res = await this.ShowMessageAsync("Confirmation", "Are you sure to make these changes?", MessageDialogStyle.AffirmativeAndNegative);
                        if (res == MessageDialogResult.Affirmative)
                        {
                            MyDAL.UpdateBicycleTable(LBID.Text, TBName.Text, TBType.Text, Convert.ToDouble(TBPrice.Text), TBColor.Text, username);
                        }
                    }
                }
                else if (LBTitle.Text == "Snacks")
                {

                    TBikeDAL MyDAL = new TBikeDAL();
                    var res = await this.ShowMessageAsync("Confirmation", "Are you sure to make these changes?", MessageDialogStyle.AffirmativeAndNegative);
                    if (res == MessageDialogResult.Affirmative)
                    {
                        MyDAL.UpdateSnackTable(LBID.Text, TBName.Text, TBType.Text, Convert.ToDouble(TBPrice.Text), Convert.ToInt32(TBColor.Text), username);
                    }
                }
            }
            catch (Exception ex)
            {
                var res = await this.ShowMessageAsync("Error", ex.Message);
            }
        }
    }
}
