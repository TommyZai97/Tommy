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
using MahApps.Metro.Controls;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using MahApps.Metro.Controls.Dialogs;

namespace TBike
{
    /// <summary>
    /// Interaction logic for EmployeeRank.xaml
    /// </summary>
    public partial class EmployeeRank : MetroWindow
    {
        string username;
        int RankID;
        static string constring = System.Configuration.ConfigurationManager.ConnectionStrings["123"].ConnectionString;

        public EmployeeRank()
        {
            InitializeComponent();
            BindComboBox(CBRankDesc);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (CBRankDesc.Visibility == Visibility.Hidden)
            {
                //switch modify mode
                LBModify.Text = "Modify Mode";
                BTNModify.Content = "Add Mode";
                CBRankDesc.Visibility = Visibility.Visible;
                TBRankDesc.Visibility = Visibility.Hidden;
                TBRankDescModify.Visibility = Visibility.Visible;
                Rect.Visibility = Visibility.Visible;
               
            }
            else
            {
                //switch add mode
                LBModify.Text = "Add Mode";
                BTNModify.Content = "Modify Mode";
                Rect.Visibility = Visibility.Hidden;
                TBRankDesc.Visibility = Visibility.Visible;
                TBRankDescModify.Visibility = Visibility.Hidden;
                CBRankDesc.Visibility = Visibility.Hidden;
            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(TBRankNo.Text) <= RankID)
                {
                    if (TBRankDesc.Text != null && TBRankNo.Text != null)
                    {
                        //Apply Data To EmployeeRank
                        if (CBRankDesc.Visibility == Visibility.Hidden)
                        {
                            //set new rank
                            TBikeDAL MyDAL = new TBikeDAL();
                            MyDAL.AddNewEmployeeRank(TBRankDesc.Text, Convert.ToInt32(TBRankNo.Text), username);
                            var res = await this.ShowMessageAsync("ADD NEW", "Employee Rank " + TBRankDesc.Text + " Has Been Added.", MessageDialogStyle.AffirmativeAndNegative);

                        }
                        else
                        {
                            TBikeDAL MyDAL = new TBikeDAL();
                            MyDAL.UpdateEmployeeRank(CBRankDesc.SelectedValue.ToString().Trim(), TBRankDescModify.Text, Convert.ToInt32(TBRankNo.Text), username);
                            var res = await this.ShowMessageAsync("MODIFY", "Employee Rank " + TBRankDesc.Text + " Has Been Modified.", MessageDialogStyle.AffirmativeAndNegative);

                        }
                    }
                    else
                    {
                        var res = await this.ShowMessageAsync("Error", "Please Fill in all texts");

                    }
                }
                else
                {
                    var res = await this.ShowMessageAsync("Error", "Rank same or higher than self cannot be created!!");

                }

                //EmployeeRank ret = new EmployeeRank();
                //this.Close();
                //ret.PopulateDataFromLogin(username);
                //ret.Show();
            }
            catch(Exception ex)
            {
                var res = await this.ShowMessageAsync("Error",  Convert.ToString(ex) , MessageDialogStyle.AffirmativeAndNegative);

            }
        }

        private void TBRankNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void BindComboBox(ComboBox CBRankDesc)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeRankDesc,EmployeeRankID From EmployeeRankMaster", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "EmployeeRankMaster");
            CBRankDesc.ItemsSource = ds.Tables[0].DefaultView;
            CBRankDesc.DisplayMemberPath = ds.Tables[0].Columns["EmployeeRankDesc"].ToString();
            CBRankDesc.SelectedValuePath = ds.Tables[0].Columns["EmployeeRankID"].ToString();
        }

        private void CBRankDesc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBikeDAL MyDAL = new TBikeDAL();
           
            DataTable ResultTable = MyDAL.ShowEmployeeRankByID(CBRankDesc.SelectedValue.ToString().Trim());
            TBRankNo.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRank"]);
            TBRankDescModify.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]);
       
        }
    }
}
