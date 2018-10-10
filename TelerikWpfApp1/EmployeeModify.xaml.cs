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

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for EmployeeModify.xaml
    /// </summary>
    public partial class EmployeeModify : MetroWindow
    {
        string username;
        int RankID;
        //rank is for demoting and promoting
        int Rank;
        public EmployeeModify()
        {
            InitializeComponent();
        }

        public async void populateEmployee(string EmployeeID)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectEmployeeByEmployeeID(EmployeeID);
            if (ResultTable.Rows.Count != 0)
            {
                LBEmployeeID.Text = EmployeeID;
                LBEmployeeName.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeName"]).Trim();
                LBEmployeeRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]).Trim();
                LBUsername.Text = Convert.ToString(ResultTable.Rows[0]["Username"]).Trim();
                LBEmail.Text = Convert.ToString(ResultTable.Rows[0]["Email"]).Trim();
                LBDob.Text = Convert.ToString(ResultTable.Rows[0]["DateOfBirth"]).Trim();
                LBPhoneNo.Text = Convert.ToString(ResultTable.Rows[0]["PhoneNo"]).Trim();
                LBCity.Text = Convert.ToString(ResultTable.Rows[0]["City"]).Trim();
                LBLastLogin.Text = Convert.ToString(ResultTable.Rows[0]["LastLoginTime"]).Trim();
            }
            else
            {
                var res = await this.ShowMessageAsync("Error", "No data Found!!!");
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeManagement emp = new EmployeeManagement();
            emp.PopulateDataFromLogin(username);
            emp.Show();
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

        private async void BTNPromote_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
            Rank = Convert.ToInt32(ResultTable.Rows[0]["EmployeeRank"]);
            try
            {
                if (RankID > Rank)
                {
                    
                    var res = await this.ShowMessageAsync("Confirm", "Are you sure to Promote " + LBEmployeeName.Text + " ?", MessageDialogStyle.AffirmativeAndNegative);
                    if (res == MessageDialogResult.Affirmative)
                    {
                        MyDAL.UpdateEmployeePromotion(LBEmployeeID.Text, Rank + 1, TLUsername.Text);
                        ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
                        LBEmployeeRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]);
                    }
                }
                else
                {
                    var res = await this.ShowMessageAsync("Error", "Cant Promote Rank Higher than self");
                }

            }
            catch (Exception ex)
            {
                var res = await this.ShowMessageAsync("Error", Convert.ToString(ex).Trim());
            }
        }

        private async void BTNDemote_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
            Rank = Convert.ToInt32(ResultTable.Rows[0]["EmployeeRank"]);
            try
            {
                if (RankID > Rank)
                {
                    if (Rank > 0)
                    {
                        var res = await this.ShowMessageAsync("Confirm", "Are you sure to Demote " + LBEmployeeName.Text + " ?", MessageDialogStyle.AffirmativeAndNegative);
                        if (res == MessageDialogResult.Affirmative)
                        {
                            MyDAL.UpdateEmployeePromotion(LBEmployeeID.Text, Rank + -1, TLUsername.Text);
                            ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
                            LBEmployeeRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]);

                        }
                    }
                    else
                    {
                        var res = await this.ShowMessageAsync("Error", "Rank Already is lowest");
                    }
                }
                else
                {
                    var res = await this.ShowMessageAsync("Error", "Cant Demote Rank Lower than self");
                }

            }
            catch (Exception ex)
            {
                var res = await this.ShowMessageAsync("Error", Convert.ToString(ex).Trim());
            }
        }
    }
}
