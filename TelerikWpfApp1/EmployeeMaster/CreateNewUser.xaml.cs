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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //button for creating new employee
            int ZipCode = Convert.ToInt32(TBZipCode.Text);
                
            TBikeDAL MyDal = new TBikeDAL();
            MyDal.AddNewEmployeeDetails(TBEmpName.Text, DOBText.SelectedDate.Value.Date, TBEmail.Text, TBPhoneNo.Text, TBAddress1.Text, TBAddress2.Text, TBAddress3.Text, TBCity.Text, ZipCode, "Tommy");

            CreateNewUser emp = new CreateNewUser();
            this.Close();
            emp.PopulateDataFromLogin(username);
            emp.Show();
            MessageBox.Show("Create New User Success!!!");
            
          
        }

        void LoopVisualTree(DependencyObject obj)

        {

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)

            {

                if (obj is TextBox)

                    ((TextBox)obj).Text = null;

                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));

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
