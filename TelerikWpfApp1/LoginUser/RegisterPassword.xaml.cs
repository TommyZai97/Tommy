using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
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
    /// Interaction logic for RegisterPassword.xaml
    /// </summary>
    public partial class RegisterPassword : MetroWindow
    {
        public RegisterPassword()
        {
            InitializeComponent();

        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TBikeDAL MyDal = new TBikeDAL();
           
            try {
                if (TBEmail.Text == "" && TBPassword.Password.ToString().Trim() == "" && TBUsername.Text == "")
                {
                    MessageBox.Show("Please Fill in all text");


                }

                else { 
                VerifyRequirements();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to register Reason: " + ex);
            }


        }

        public async void VerifyRequirements()
        {
            TBikeDAL MyDal = new TBikeDAL();
            DataTable ResultTable = MyDal.SelectEmployeeID("", TBUsername.Text);
            DataTable ResultTableEmployee = MyDal.ShowAllEmployeeDetails();
            int i = 0;
            int a = 0;
            string Email;
            foreach (DataRow row in ResultTableEmployee.Rows)
            {
                Email = Convert.ToString(ResultTableEmployee.Rows[i]["Email"]);
                if ( Email == TBEmail.Text){
                    
                    a = a + 1;
                }
                
                
                i++;
            }
            

            if (ResultTable.Rows.Count > 0)
            {

                
                
                if (TBUsername.Text == Convert.ToString(ResultTable.Rows[0]["Username"]).Trim())
                {
                    MessageBox.Show("This username has been used");
                }

                
              
                else if (TBConfirmPassword != TBPassword)
                {
                    var res = await this.ShowMessageAsync("Password Not Match","Password not match with confirm pasword");

                }

                //TLRankDesc.Text = Convert.ToString(ResultTable.Rows[0]["EmployeeRankDesc"]).Trim();
                //username = Convert.ToString(ResultTable.Rows[0]["Username"]).Trim();
                //RankID = Convert.ToInt32(ResultTable.Rows[0]["EmployeeRank"]);



            }
            else
            {
                if ((TBConfirmPassword.Password.ToString().Trim()) != (TBPassword.Password.ToString().Trim()))
                {
                    var res = await this.ShowMessageAsync("Password Not Match", "Password not match with confirm pasword");

                }
                else if (a == 0)
                {
                    var res = await this.ShowMessageAsync("Sorry", "This Email has no record");
                }
                else
                {
                    //var res = await this.ShowMessageAsync("No Record", "No Email address record found ");
                    MyDal.AddNewEmployeeLoginInfo(TBEmail.Text, TBUsername.Text, TBPassword.Password.ToString().Trim());
                    var res = await this.ShowMessageAsync("Registration Completed", " Please go back and Login");
                    this.Close();
                }
            }

        }

     

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }


    }
}
