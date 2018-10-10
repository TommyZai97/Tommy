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


namespace TelerikWpfApp1
{
  
    /// <summary>
    /// Interaction logic for InventoryManage.xaml
    /// </summary>
    public partial class InventoryManage : Window
    {
        string username;
        int RankID;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Populate Bike Button
            PopulateBikeDataTable();
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
    }
}
