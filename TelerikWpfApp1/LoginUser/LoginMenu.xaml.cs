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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MahApps.Metro.Controls;


namespace TBike
{
    /// <summary>
    /// Interaction logic for LoginMenu.xaml
    /// </summary>
    public partial class LoginMenu : MetroWindow
    {
        static string constring = ConfigurationManager.ConnectionStrings["123"].ConnectionString;

        public LoginMenu()
        {
            InitializeComponent();
            
        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Verify Login Data
            TBikeDAL MyDal = new TBikeDAL();
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                if (TBUsername.Text == "" && TBPassword.Password.ToString().Trim() == "")
                {
                    MessageBox.Show("Please Fill in all text");
                }
                else
                {

                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    SqlCommand MyCmd = new SqlCommand("SelVerifyLoginInfo", conn);
                    MyCmd.CommandType = CommandType.StoredProcedure;
                    MyCmd.Parameters.AddWithValue("@Username", TBUsername.Text);
                    MyCmd.Parameters.AddWithValue("@Password", TBPassword.Password.ToString().Trim());

                    int count = Convert.ToInt32(MyCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        MainWindow main = new MainWindow();
                        main.PopulateDataFromLogin(TBUsername.Text);

                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or password");

                    }
                }


                conn.Close();
            }

            catch (Exception ex)
            {

                throw new Exception("DB Operation Error At VerfiyLoginD : " + ex.Message);

            }
           
          
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //go to register page
            RegisterPassword reg = new RegisterPassword();
            reg.ShowDialog();
           
        }
    }
}
