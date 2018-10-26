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

        public void populateEmployee(string EmployeeID)
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
                LBCity.Text = Convert.ToString(ResultTable.Rows[0]["Address"]).Trim();
                LBLastLogin.Text = Convert.ToString(ResultTable.Rows[0]["LastLoginTime"]).Trim();
            }
            else
            {
                PopWindow pop = new PopWindow(ImageType.Error, "Error", "No data Found!!!","Ok");
                pop.ShowDialog();
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

        private void BTNPromote_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
            DataTable ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
            Rank = Convert.ToInt32(ResultTable.Rows[0]["EmployeeRank"]);
            try
            {
                if (RankID > Rank)
                {

                    ConfirmWindow com = new ConfirmWindow(ImageType.Question, "Confirm?","Are you sure to Promote " + LBEmployeeName.Text + " ?", "Yes","No");
                    com.ShowDialog();
                    if (com.Confirmed)
                    {
                        MyDAL.UpdateEmployeePromotion(LBEmployeeID.Text, Rank + 1, TLUsername.Text);
                        ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
                        LBEmployeeRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]);
                    }
                }
                else
                {
                    ConfirmWindow com = new ConfirmWindow(ImageType.Error, "Error","Cant Promote Rank Higher than self","Ok","Cancel");
                    com.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Error, "Error", Convert.ToString(ex).Trim(),"OK");
                pop.ShowDialog();
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
                        PopWindow pop = new PopWindow(ImageType.Warning, "Error", "Rank Already is lowest", "OK");
                        pop.ShowDialog();
                    }
                }
                else
                {
                    PopWindow pop = new PopWindow(ImageType.Error, "Error", "Cant Demote Rank Lower than self", "OK");
                    pop.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Error, "Error",ex.Message,"OK");
                pop.ShowDialog();
            }
        }

        private  void BTNUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TBikeDAL MyDAL = new TBikeDAL();
                username = LBUsername.Text;
                ConfirmWindow com = new ConfirmWindow(ImageType.Error, "Update", "Are you sure to modify these changes?", "Yes","No");
                if (com.Confirmed)
                {
                    MyDAL.UpdateEmployee(LBEmployeeID.Text, LBEmployeeName.Text, Convert.ToDateTime(LBDob.Text), LBUsername.Text, LBEmployeeRankDesc.Text, LBEmail.Text, LBPhoneNo.Text, LBCity.Text, TLUsername.Text);
                    DataTable ResultTable = MyDAL.SelectEmployeeByEmployeeID(LBEmployeeID.Text);
                    
                        
                        LBEmployeeName.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeName"]).Trim();
                        LBEmployeeRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]).Trim();
                        LBUsername.Text = Convert.ToString(ResultTable.Rows[0]["Username"]).Trim();
                        LBEmail.Text = Convert.ToString(ResultTable.Rows[0]["Email"]).Trim();
                        LBDob.Text = Convert.ToString(ResultTable.Rows[0]["DateOfBirth"]).Trim();
                        LBPhoneNo.Text = Convert.ToString(ResultTable.Rows[0]["PhoneNo"]).Trim();
                        LBCity.Text = Convert.ToString(ResultTable.Rows[0]["Address"]).Trim();
                        LBLastLogin.Text = Convert.ToString(ResultTable.Rows[0]["LastLoginTime"]).Trim();

                    PopulateDataFromLogin(username);
                    
                }
            }
            catch (Exception ex)
            {
                PopWindow pop = new PopWindow(ImageType.Error, "Error", ex.Message, "OK");
                pop.ShowDialog();
            }
        }
    }
}
