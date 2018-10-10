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
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for EmployeeManagement.xaml
    /// </summary>
    public partial class EmployeeManagement : Window
    {
        int RankID;
        string username;
        public EmployeeManagement()
        {
            InitializeComponent();
            dataGrid1.Visibility = Visibility.Hidden;
            PopulateDataFromLogin("");


        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //back button
            MainWindow main = new MainWindow();
            main.PopulateDataFromLogin(username);
            main.Show();
            this.Close();
        }

        public void PopulateEmployeeDetails()
        {
            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowAllEmployeeDetails();


            dataGrid1.ItemsSource = ResultTable.DefaultView;
            dataGrid1.AutoGenerateColumns = true;
            dataGrid1.CanUserAddRows = false;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            PopulateEmployeeDetails();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (RankID >= 3)
            {
                CreateNewUser newer = new CreateNewUser();
                newer.PopulateDataFromLogin(username);
                newer.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You are not authorised to use this process");
                
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

        private void BTNSetRank_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
