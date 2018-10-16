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

namespace TBike
{
    /// <summary>
    /// Interaction logic for CreateNewUser.xaml
    /// </summary>
    public partial class CreateNewUser : MetroWindow
    {
        string username;
        int RankID;
        public CreateNewUser()
        {
            InitializeComponent();


        }
        public string stringBuilder(string Address)
        {

            StringBuilder striBuild = new StringBuilder();
            striBuild.AppendLine(TBAddress1.Text);
            striBuild.AppendLine(TBAddress2.Text);
            striBuild.AppendLine(TBAddress3.Text);
            striBuild.Append(TBCity.Text);
            striBuild.Append(" , " + TBZipCode.Text);

            Address = striBuild.ToString().Trim();

            return Address;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //button for creating new employee
               

                TBikeDAL MyDal = new TBikeDAL();


                string Address = "";
                stringBuilder(Address); 


                MyDal.AddNewEmployeeDetails(TBEmpName.Text, DOBText.SelectedDate.Value.Date, TBEmail.Text, TBPhoneNo.Text, Address, "Tommy");

                CreateNewUser emp = new CreateNewUser();
                this.Close();
                emp.PopulateDataFromLogin(username);
                emp.Show();
                MessageBox.Show("Create New User Success!!!");
            }
            catch(Exception ex)
            {
                var res = await this.ShowMessageAsync("Error", ex.Message);
            }
          
        }

     

        public void populateEmployeeID()
        {
            

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
        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeeManagement emp = new EmployeeManagement();
            emp.PopulateDataFromLogin(username);
            emp.Show();
            this.Close();
        }
    }
}
