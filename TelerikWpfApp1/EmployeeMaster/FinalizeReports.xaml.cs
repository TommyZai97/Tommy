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

namespace TBike.EmployeeMaster
{
    /// <summary>
    /// Interaction logic for FinalizeReports.xaml
    /// </summary>
    public partial class FinalizeReports : MetroWindow
    {
        string username;
        int RankID;
        
        public FinalizeReports()
        {
            InitializeComponent();
        }

        private void BTNsearch_Click(object sender, RoutedEventArgs e)
        {
            PopulateBikeDataTable();
        }
        public void SearchModule()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeManagement win = new EmployeeManagement();
            win.PopulateDataFromLogin(username);
            win.Show();
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
            Column4.Binding = new Binding("BicycleStatus");
            Column5.Header = "Current Renter";
            Column5.Binding = new Binding("CurrentRenter");
            Column6.Header = "Total Rents";
            Column6.Binding = new Binding("TotalRents");
            Column7.Header = "Price";
            Column7.Binding = new Binding("Price");
            Column8.Header = "Color";
            Column8.Binding = new Binding("Color");
            Column9.Header = "Last Date Booked";
            Column9.Binding = new Binding("LastBookedDate");
            Column9.Header = "Created By";
            Column9.Binding = new Binding("CreatedBy");



            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = false;
            dataGrid1.CanUserAddRows = false;



        }
    }
}
