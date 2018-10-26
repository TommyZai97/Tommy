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
using MahApps.Metro.Controls.Dialogs;


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

     

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Verify Login Data
            TBikeDAL MyDal = new TBikeDAL();
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                if (TBUsername.Text == "" && TBPassword.Password.ToString().Trim() == "")
                {
                    var res = await this.ShowMessageAsync("Error","Please Fill in all text");
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
                        
                        await this.ShowMessageAsync("Error","Incorrect Username or password");

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

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F11 && this.ShowTitleBar == true)
            {

                WindowState = WindowState.Maximized;
                ResizeMode = ResizeMode.NoResize;
                this.ShowTitleBar = false;
                this.ShowMaxRestoreButton = false;
                this.ShowCloseButton = false;
                this.ShowMinButton = false;
                this.ShowInTaskbar = false;
                this.IgnoreTaskbarOnMaximize = true;
            }
            else if (e.Key == Key.F11 && this.ShowTitleBar == false)
            {
                WindowState = WindowState.Normal;
                ResizeMode = ResizeMode.CanResize;
                this.ShowTitleBar = true;
                this.ShowMaxRestoreButton = true;
                this.ShowCloseButton = true;
                this.ShowMinButton = true;
                this.ShowInTaskbar = true;
                this.IgnoreTaskbarOnMaximize = false;
            }


        }


    }
}
