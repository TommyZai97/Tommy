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

namespace TelerikWpfApp1
{
    /// <summary>
    /// Interaction logic for RentalProcessing.xaml
    /// </summary>
    public partial class RentalProcessing : MetroWindow
    {
        string username;
        int RankID;
        public RentalProcessing()
        {
            InitializeComponent();
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            Booking book = new Booking();
            book.PopulateDataFromLogin(username);
            book.Show();
            this.Close();
        }

        private void Rental_Click_2(object sender, RoutedEventArgs e)
        {
            rental rent = new rental();
            rent.PopulateDataFromLogin(username);
            rent.Show();
            this.Close();
        }

        private void Return_Click_1(object sender, RoutedEventArgs e)
        {
            Return retun = new Return();
            retun.PopulateDataFromLogin(username);
            retun.Show();
            this.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            win.PopulateDataFromLogin(username);
            win.Show();
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
    }


}
