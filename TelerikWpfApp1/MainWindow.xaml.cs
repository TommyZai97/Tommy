using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;


namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        string username;
        int RankID;
        public int MyValue { get; set; } 
        public MainWindow()
        {

            InitializeComponent();
            PopulateDataFromLogin("");
            CalculateDoneRentedTime();
        


        }

      
        public void CalculateDoneRentedTime()
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.ShowAllBookingTable();
            DateTime date = DateTime.Now;
            int i = 0;
            foreach (DataRow row in ResultTable.Rows)
            {
            
                DateTime D = Convert.ToDateTime(ResultTable.Rows[i]["BookingDate"]);
                string ID = Convert.ToString(ResultTable.Rows[i]["BookingID"]);
                string Status = Convert.ToString(ResultTable.Rows[i]["BookingStatus"]);
                string Bike = Convert.ToString(ResultTable.Rows[i]["BicycleID"]);
                string Customer = Convert.ToString(ResultTable.Rows[i]["Customer"]);
                
                if (date.Date > D.Date && Status == "A")
                {
                    MyDAL.UpdateBookingDate(D, "E", ID);
                    MyDAL.UpdateBikeStatus(Bike, "");
                }
                else if (date.Date > D && Status == "R")
                {
                    MyDAL.UpdateBookingDate(D, "N",ID);
                }
                 i = i + 1;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //button for store
            InventoryManage newWin = new InventoryManage();
            newWin.PopulateDataFromLogin(username);
            newWin.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //button for rent
            RentalProcessing RentProcessing = new RentalProcessing();
            RentProcessing.PopulateDataFromLogin(username);
            RentProcessing.Show();
            this.Close();
        }

        private void employee_Click(object sender, RoutedEventArgs e)
        {
            if (RankID == 1)
            {
                MessageBox.Show("You have no access to this current Service");

            }
            else
            {
                EmployeeManagement emp = new EmployeeManagement();
                emp.PopulateDataFromLogin(username);
                emp.Show();
                
                this.Close();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoginMenu log = new LoginMenu();
            log.Show();
            this.Close();
        }
    }
}
