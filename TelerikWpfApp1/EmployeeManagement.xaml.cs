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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for EmployeeManagement.xaml
    /// </summary>
    public partial class EmployeeManagement : MetroWindow
    {
        int RankID;
        string username;
        string id;
        string self;
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
            EmployeeRank Rank = new EmployeeRank();
            Rank.PopulateDataFromLogin(username);
            Rank.Show();
            this.Close();
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dataGrid1.SelectedItem;
            int index = dataGrid1.Items.IndexOf(dataGrid1.CurrentItem);
            //string cellValue = dataRow.Row.ItemArray[index].ToString();

            TBikeDAL MyDAL = new TBikeDAL();

            DataTable ResultTable = MyDAL.ShowAllEmployeeDetails();
            id = Convert.ToString(ResultTable.Rows[index]["EmployeeID"]);
            self = Convert.ToString(ResultTable.Rows[index]["username"]);
            if (RankID >= 4)
            {
                BTNPromote.Visibility = Visibility.Visible;
            }
        }

        private async void BTNPromote_Click(object sender, RoutedEventArgs e)
        {
            if (id != null)
            {
                TBikeDAL MyDAL = new TBikeDAL();
                DataTable ResultTable = MyDAL.SelectEmployeeByEmployeeID(id);
                int Rank = Convert.ToInt32(ResultTable.Rows[0]["EmployeeRank"]);
                if (RankID >= 4)
                {
                    if (self == username || RankID > Rank)
                        if (id != null)
                        {
                            EmployeeModify mod = new EmployeeModify();
                            mod.populateEmployee(id);
                            mod.PopulateDataFromLogin(username);
                            mod.Show();
                            this.Close();
                        }
                }
            }
            else
            {
                var res = await this.ShowMessageAsync("Error", "Please Select Employee");

            }
        }

      
    }
}
