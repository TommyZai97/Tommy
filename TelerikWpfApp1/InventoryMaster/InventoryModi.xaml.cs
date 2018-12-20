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
using TBike.AppData;
using TBike.MessageBox;

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
        string ItemStatus;
        int ComboIndex;
        public InventoryModi()
        {
            InitializeComponent();
            
        }

        public void DetermineItemStatus() 
        {
            if (CBStatus.Visibility != Visibility.Hidden || CBSnackStatus.Visibility != Visibility.Hidden)
            {
                if (CBStatus.Text == "Active")
                {
                    ItemStatus = "A";
                }
                else if (CBStatus.Text == "Expired")
                {
                    ItemStatus = "E";
                }
                else if (CBStatus.Text == "Not Returned")
                {
                    ItemStatus = "N";
                }
                else if (CBStatus.Text == "Succesful")
                {
                    ItemStatus = "S";
                }
                else if (CBStatus.Text == "Renting")
                {
                    ItemStatus = "R";
                }
                else if (CBStatus.Text == "Inactive")
                {
                    ItemStatus = "I";
                }
                else if (CBStatus.Text == "Maintenance")
                {
                    ItemStatus = "M";
                }

                if (CBSnackStatus.Text == "Active")
                {
                    ItemStatus = "A";
                    ComboIndex = 0;
                }
                else if (CBSnackStatus.Text == "InActive")
                {
                    ItemStatus = "I";
                    ComboIndex = 1;
                }
                else if (CBSnackStatus.Text == "Out Of Stock")
                {
                    ItemStatus = "O";
                    ComboIndex = 2;

                }
            }

        }
        
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //InventoryManage inv = new InventoryManage();
            //inv.Show();
            //inv.PopulateDataFromLogin(username);
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
            dataGrid1.CanUserAddRows = false;



        }

        public void PopulateSnackDataTable()
        {
            TBikeDAL MyDAL = new TBikeDAL();
       
            DataTable ResultTable = MyDAL.ShowAllSnackTable();

            Column1.Header = "Snack ID";
            Column1.Binding = new Binding("SnackID");
            Column2.Header = "Snack Name";
            Column2.Binding = new Binding("SnackName");
            Column3.Header = "Snack Type";
            Column3.Binding = new Binding("SnackType");
            Column4.Header = "Snack Status";
            Column4.Binding = new Binding("SnackStatusInFull");
            Column5.Header = "Quantity";
            Column5.Binding = new Binding("Quantity");
            Column6.Header = "Price";
            Column6.Binding = new Binding("Price");
            Column7.Header = "CreatedBy";
            Column7.Binding = new Binding("CreatedBy");
            TBIkeUtility.TranslateRecordStatusDescription(new List<string> { "SnackStatus" }, ref ResultTable);
     
            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;
        }



        public void PopulateID(string ID,string Category,string Status)
        {
            MainStatus = Status;
            TBikeDAL MyDAL = new TBikeDAL();
            if (Status == "Modification")
            {
                BTNPro.Content = "Update";
                BtnDelete.Visibility = Visibility.Visible;
                if (Category == "Bicycle")
                {
                    LBTitle.Text = "Bicycle";
                    DataTable ResultTable = MyDAL.SelectBicycleByID(ID);
                    if (ResultTable.Rows.Count != 0)
                    {
                        if (RankID > 3)
                        {

                            CBStatus.Visibility = Visibility.Visible;
                            LBStatus.Visibility = Visibility.Visible;
                        }
                     
                        LBID.Text = ID;
                        TBName.Text = Convert.ToString(ResultTable.Rows[0]["BicycleName"]).Trim();
                        TBType.Text = Convert.ToString(ResultTable.Rows[0]["BicycleType"]).Trim();
                        TBPrice.Text = Convert.ToString(ResultTable.Rows[0]["Price"]).Trim();
                        TBColor.Text = Convert.ToString(ResultTable.Rows[0]["Color"]).Trim();
                        string BikeStatus = Convert.ToString(ResultTable.Rows[0]["BicycleStatus"]).Trim();
                        TBQuantity.Text = Convert.ToString(ResultTable.Rows[0]["Quantity"]).Trim();
                        
                        if (BikeStatus  == "A")
                        {
                            CBStatus.SelectedIndex = 0;
                            ItemStatus = "A";
                        }
                        else if (BikeStatus  == "E")
                        {
                            CBStatus.SelectedIndex = 1;
                            ItemStatus = "E";
                        }
                        else if (BikeStatus == "N")
                        {
                            CBStatus.SelectedIndex = 2;
                            ItemStatus = "N";
                        }
                        else if (BikeStatus == "S")
                        {
                            CBStatus.SelectedIndex = 3;
                            ItemStatus = "S";
                        }
                        else if (BikeStatus == "R")
                        {
                            CBStatus.SelectedIndex = 4;
                            ItemStatus = "R";
                        }
                        else if (BikeStatus == "I")
                        {
                            CBStatus.SelectedIndex = 5;
                            ItemStatus = "I";
                        }
                        else if (BikeStatus == "M")
                        {
                            CBStatus.SelectedIndex = 6;
                            ItemStatus = "M";
                        }
                        PopulateBikeDataTable();
                    }
                    else
                    {
                        PopWindow pop = new PopWindow(ImageType.Information,"Error","No data Found!!!", "OK");
                        pop.ShowDialog();
                    }
                }
                else if (Category == "Snacks")
                {
                    if (RankID > 3)
                    {

                        CBSnackStatus.Visibility = Visibility.Visible;
                        LBStatus.Visibility = Visibility.Visible;
                    }
                    LBTitle.Text = "Snacks";
                    LBColor.Text = "Quantity";
                    DataTable ResultTable = MyDAL.SelectSnackByID(ID);
                    if (ResultTable.Rows.Count != 0)
                        LBID.Text = ID;
                    TBName.Text = Convert.ToString(ResultTable.Rows[0]["SnackName"]).Trim();
                    TBType.Text = Convert.ToString(ResultTable.Rows[0]["SnackType"]).Trim();
                    TBPrice.Text = Convert.ToString(ResultTable.Rows[0]["Price"]).Trim();
                    TBColor.Text = Convert.ToString(ResultTable.Rows[0]["Quantity"]).Trim();

                    CBSnackStatus.SelectedIndex = ComboIndex;
                    PopulateSnackDataTable();
                }
                else
                {
                    PopWindow pop = new PopWindow(ImageType.Information, "Error","Incorrect Category", "OK");
                    pop.ShowDialog();
                }
            }

            else if(Status == "Add"){
                LBTitle.Text = Category;
                LBID.Text = "** New **";
                BTNPro.Content = "Add";
                BtnDelete.Visibility = Visibility.Hidden;
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
            DetermineItemStatus();
            if (MainStatus == "Modification")
            {
                UpdateAllItems();
                
            }
            else if (MainStatus == "Add") 
            {
                AddNewItems();
                
            }
        }
        public void AddNewItems()
        {
            DetermineItemStatus();
            try
            {
                if (LBName.Text != "")
                {
                    if (LBTitle.Text == "Bicycle")
                    {
                        PopulateBikeDataTable();
                        if (LBID.Text != null)
                        {
                            TBikeDAL MyDAL = new TBikeDAL();
                            ConfirmWindow con = new ConfirmWindow(ImageType.Question, "Are you sure to add new data?", "Confirmation", "Yes", "No");
                            con.ShowDialog();
                            if (con.Confirmed)
                            {
                                MyDAL.AddBicycleTable(TBName.Text, TBType.Text, Convert.ToInt32(TBQuantity.Text),Convert.ToDouble(TBPrice.Text), TBColor.Text, TLUsername.Text);
                                PopulateBikeDataTable();
                            }
                        }
                    }
                    else if (LBTitle.Text == "Snacks")
                    {
                        PopulateSnackDataTable();
                        TBikeDAL MyDAL = new TBikeDAL();
                        ConfirmWindow con = new ConfirmWindow(ImageType.Question, "Confirmation", "Are you sure to add new data?", "Add Please", "No, don't add please");
                        con.ShowDialog();
                        if (con.Confirmed)
                        {
                            MyDAL.AddSnackTable(TBName.Text, TBType.Text, Convert.ToDouble(TBPrice.Text), Convert.ToInt32(TBColor.Text), TLUsername.Text);
                            PopulateSnackDataTable();
                        }
                    }
                }
                else
                {
                    PopWindow con = new PopWindow(ImageType.Error, "No field", "Please fill in all", "OK");
                    con.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Information, "Error", ex.Message, "I will Fix this");
                pop.ShowDialog();
                pop.Dispose();
            }
            
        }
    

        public void UpdateAllItems()
        {
            try
            {
                DetermineItemStatus();

                if (LBTitle.Text == "Bicycle")
                {
                    if (LBID.Text != null)
                    {
                        TBikeDAL MyDAL = new TBikeDAL();
                        ConfirmWindow con = new ConfirmWindow(ImageType.Question, "Confirmation" ,"Are you sure to make these changes?","Yes, Change This", "No, Don't Change");
                        con.ShowDialog();
                        if (con.Confirmed)
                        {
                            MyDAL.UpdateBicycleTable(LBID.Text, TBName.Text, TBType.Text, Convert.ToInt32(TBQuantity.Text),ItemStatus,Convert.ToDouble(TBPrice.Text), TBColor.Text, TLUsername.Text);
                            PopulateBikeDataTable();
                            PopWindow pop = new PopWindow(ImageType.Information, "Success!", "Changes Made, Successfully!", "Ok");
                            pop.ShowDialog();
                        }
                    }
                }
                else if (LBTitle.Text == "Snacks")
                {

                    TBikeDAL MyDAL = new TBikeDAL();
                    ConfirmWindow con = new ConfirmWindow(ImageType.Question, "Confirmation","Are you sure to make these changes?","Yes, Change This","No, Don't Change");
                    con.ShowDialog();
                    if (con.Confirmed)
                    {
                        MyDAL.UpdateSnackTable(LBID.Text, TBName.Text, TBType.Text, Convert.ToDouble(TBPrice.Text), Convert.ToInt32(TBColor.Text), ItemStatus, TLUsername.Text);
                        PopulateSnackDataTable();
                        PopWindow pop = new PopWindow(ImageType.Information, "Success!", "Changes Made, Successfully!", "Ok");
                        pop.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Error, "Error", ex.Message, "I will Fix this");
                pop.ShowDialog();
            }
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            if (index >= 0)
            {

                TBikeDAL MyDAL = new TBikeDAL();
                if (LBTitle.Text == "Bicycle")
                {
                    DataTable ResultTable = MyDAL.ShowAllBikeTable();
                    string BicycleID = Convert.ToString(ResultTable.Rows[index]["BicycleID"]);

                    if (BicycleID != null)
                    {


                        PopulateID(BicycleID, LBTitle.Text, "Modification");

                    }
                }
                else if (LBTitle.Text == "Snacks")
                {
                    DataTable ResultTable = MyDAL.ShowAllSnackTable();
                    string SnackID = Convert.ToString(ResultTable.Rows[index]["SnackID"]);
                    if (SnackID != null)
                    {
                        
                        PopulateID(SnackID, LBTitle.Text, "Modification");
                    }
                }
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LBTitle.Text == "Bicycle")
            {
                TBikeDAL MyDAL = new TBikeDAL();


                ConfirmWindow confirm = new ConfirmWindow(ImageType.Question, "Delete?", "Are you sure to delete this bicycle?", "Yes", "No! Turn Back!");
                if (confirm.Confirmed)
                {
                    MyDAL.DeleteBicycleByID(LBID.Text);
                    PopulateBikeDataTable();
                    PopWindow pop = new PopWindow(ImageType.Information, "Bicycle Deleted", "Bicycle: " + LBName.Text + " Has been Deleted By " + TLUsername.Text, "Okay");
                    pop.ShowDialog();
                }
            }
            else if (LBTitle.Text == "Snacks")
            {
                TBikeDAL MyDAL = new TBikeDAL();
               
                ConfirmWindow confirm = new ConfirmWindow(ImageType.Question, "Delete?", "Are you sure to delete this Snack?", "Yes", "No! Turn Back!");
                if (confirm.Confirmed)
                {
                    MyDAL.DeleteSnackByID(LBID.Text);
                    PopulateBikeDataTable();
                    PopWindow pop = new PopWindow(ImageType.Information, "Snack Deleted", "Snack: " + LBName.Text + " Has been Deleted By " + TLUsername.Text, "Okay");
                    pop.ShowDialog();
                }
            }
        }
    }
}
