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

namespace TBike
{
  
    /// <summary>
    /// Interaction logic for InventoryManage.xaml
    /// </summary>
    public partial class InventoryManage : MetroWindow
    {
        string username;
        int RankID;
        string Category;
        public InventoryManage()
        {
           
            InitializeComponent();
            


        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.PopulateDataFromLogin(username);
            win.Show();
            this.Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Populate Bike Button
            PopulateBikeDataTable();
            Category = "Bicycle";
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

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
        

            TBikeDAL MyDAL = new TBikeDAL();
            if (Category == "Bicycle")
            {
                DataTable ResultTable = MyDAL.ShowAllBikeTable();
                string BicycleID = Convert.ToString(ResultTable.Rows[index]["BicycleID"]);

                if (BicycleID != null)
                {
                    InventoryModi mod = new InventoryModi();
                    mod.Show();
                    mod.PopulateDataFromLogin(username);
                    mod.PopulateID(BicycleID, Category, "Modification");
                    this.Close();
                }
            }
            else if (Category == "Snacks")
            {
                DataTable ResultTable = MyDAL.ShowAllSnackTable();
                string SnackID = Convert.ToString(ResultTable.Rows[index]["SnackID"]);
                if (SnackID != null)
                {
                    InventoryModi mod = new InventoryModi();
                    mod.Show();
                    mod.PopulateDataFromLogin(username);
                    mod.PopulateID(SnackID, Category, "Modification");
                    this.Close();
                }
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //ADD NEW INVENTORY
            TBikeDAL MyDAL = new TBikeDAL();
            if (Category == "Bicycle")
            {
                

                    InventoryModi mod = new InventoryModi();
                    mod.Show();
                    mod.PopulateDataFromLogin(username);
                    mod.PopulateID("", Category, "Add");
                this.Close();

            }
            else if (Category == "Snacks")
            {
                
            
                    InventoryModi mod = new InventoryModi();
                    mod.Show();
                    mod.PopulateDataFromLogin(username);
                    mod.PopulateID("", Category, "Add");
                this.Close();
                
            }

        }

        private void Snack_Click(object sender, RoutedEventArgs e)
        {
            PopulateSnackDataTable();
            Category = "Snacks";
        }
    }
}
