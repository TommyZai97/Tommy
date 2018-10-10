using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Configuration;
using System.Windows.Controls;

namespace TelerikWpfApp1
{
    public class TBikeDAL
    {
        static string constring = ConfigurationManager.ConnectionStrings["123"].ConnectionString;
     

        #region BikeMaster

        public DataTable ShowAllBikeTable()
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelAllBikeDetails", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowAllBikeTable : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public DataTable SelBicycleDetailsByBikeID(string BicycleID)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBicycleDetailsByID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();
                MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowAllBikeTable : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;

        }
        #endregion

        #region EmployeeMaster
        public DataTable ShowAllEmployeeDetails()
        {


            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelAllEmpDetails", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowAllEmployeeDetails : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;

        }
        public DataTable ShowEmployeeRankByID(string RankID)
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelEmployeeRankByID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@EmployeeRankID", RankID);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowEmployeeRankByID : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }
        public string AddNewEmployeeDetails(string EmployeeName, DateTime DateOfBirth, string Email, string PhoneNo, string AddressLine1, string AddressLine2, string AddressLine3, string City, int ZipCode, string CreatedBy)
        {
            string EmployeeID="";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("AddNewEmployeeDetails", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
              
                MyCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                MyCmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                MyCmd.Parameters.AddWithValue("@Email", Email);
                MyCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                MyCmd.Parameters.AddWithValue("@AddressLine1", AddressLine1);
                MyCmd.Parameters.AddWithValue("@AddressLine2", AddressLine2);
                MyCmd.Parameters.AddWithValue("@AddressLine3", AddressLine3);
                MyCmd.Parameters.AddWithValue("@City", City);
                MyCmd.Parameters.AddWithValue("@ZipCode", ZipCode);
                MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At AddNewEmployeeDetails : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return EmployeeID;
        }
        public string AddNewEmployeeLoginInfo(string Email,string Username, string Password)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdNewLoginInfo", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                MyCmd.Parameters.AddWithValue("@Email", Email);
                MyCmd.Parameters.AddWithValue("@Username", Username);
                MyCmd.Parameters.AddWithValue("@Password", Password);

                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At AddNewEmployeeLoginInfo : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return Username;



        }
        public string UpdateEmployeePromotion(string EmployeeID,  int Rank, string LastUpdatedBy)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdEmployeePromotion", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                MyCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                MyCmd.Parameters.AddWithValue("@EmployeeRank", Rank);
                MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);

                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateEmployeeRank : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return EmployeeID;

        }

        public string AddNewEmployeeRank(string RankDesc, int Rank, string CreatedBy)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("AddNewEmployeeRank", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                MyCmd.Parameters.AddWithValue("@EmployeeRankDesc", RankDesc);
                MyCmd.Parameters.AddWithValue("@EmployeeRank", Rank);
                MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);

                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At AddNewEmployeeRank : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return RankDesc;

        }

        public string UpdateEmployeeRank(string RankID,string RankDesc, int Rank, string LastUpdatedBy)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdEmployeeRank", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                MyCmd.Parameters.AddWithValue("@EmployeeRankID", RankID);
                MyCmd.Parameters.AddWithValue("@EmployeeRankDesc", RankDesc);
                MyCmd.Parameters.AddWithValue("@EmployeeRank", Rank);
                MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);

                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateEmployeeRank : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return RankDesc;

        }
        public DataTable SelectEmployeeByEmployeeID(string EmployeeID)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelAllEmpDetailsByID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
          
            //we will use SQLAdaptor due to huge amount of column
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();
                //string SQLStatement = (string)MyCmd.ExecuteScalar();
                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectEmployeeByEmployeeID : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }
        
        public DataTable SelectEmployeeID(string EmployeeName, string Username)
        {
          
                SqlConnection MyCon = new SqlConnection(constring);
                SqlCommand MyCmd = new SqlCommand("SelEmployeeIDByUsername", MyCon);
                MyCmd.CommandTimeout = 600;
                MyCmd.CommandType = CommandType.StoredProcedure;
                MyCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                MyCmd.Parameters.AddWithValue("@Username", Username);
                //we will use SQLAdaptor due to huge amount of column
                SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
                DataTable ResultDataTable = new DataTable("ResultDataTable");

                try
                {
                    MyCon.Open();
                    //string SQLStatement = (string)MyCmd.ExecuteScalar();
                    MyDA.Fill(ResultDataTable);
                }
                catch (Exception e)
                {
                    throw new Exception("DB Operation Error At SelectEmployeeID : " + e.Message);
                }
                finally
                {
                    MyCon.Close();
                    MyCon.Dispose();
                    MyCmd.Dispose();
                }
                return ResultDataTable;

            
        }
        #endregion

        #region BookingMaster
        public DataTable ShowAllBookingTable()
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBikeBookingMaster", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowAllBookingTable : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public DataTable ShowBookingTableByBike(string BicycleID, string BookingStatus)
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBikeBookingMasterByBike", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
            MyCmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
         
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowAllBookingTable : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }
        public string UpdateBookingStatus(string BookingStatus,string BicycleID,  string Customer, string LastUpdatedBy)
        {
            string BookingID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdBookingStatus", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
              
                MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
             
                MyCmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                MyCmd.Parameters.AddWithValue("@Customer", Customer);
             
                MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateBookingStatus : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return BookingID;
        }

        public string UpdateBikeStatus(string BicycleID,string Customer)
        {
            string BookingID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdBikeStatus", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {


                MyCmd.Parameters.AddWithValue("@BicycleStatus", "A");
                MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                MyCmd.Parameters.AddWithValue("@Customer", Customer);
                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateBikeStatus : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return BookingID;
        }

        public string AddBookingTime(DateTime BookingDate, string BicycleID,string BicycleStatus,string customer, double? TotalPrice,string CreatedBy,TimeSpan? StartTime, TimeSpan? Endtime,string Remarks)
        {
            string BookingID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("AddNewBookTime", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                if (BicycleStatus == "A")
                {
                    MyCmd.Parameters.AddWithValue("@BookingDate", BookingDate);

                    MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                    MyCmd.Parameters.AddWithValue("@Customer", customer);
                    MyCmd.Parameters.AddWithValue("@Remarks", Remarks);
                    MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();
                }
                if (BicycleStatus == "R")
                {
                    MyCmd.CommandText = "UpdBikeStatus";
                    MyCmd.Parameters.AddWithValue("@BicycleStatus", "R");
                    MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                    MyCmd.Parameters.AddWithValue("@Customer", customer);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();

                    MyCmd.CommandText = "UpdBookingTable";
                    MyCmd.Parameters.AddWithValue("@BookingDate", BookingDate);
                    MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                    MyCmd.Parameters.AddWithValue("@StartTime", StartTime);
                    MyCmd.Parameters.AddWithValue("@Endtime", Endtime);
                    MyCmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                    MyCmd.Parameters.AddWithValue("@BookingStatus", "R");
                    MyCmd.Parameters.AddWithValue("@Customer", customer);
                    MyCmd.Parameters.AddWithValue("@Remarks", Remarks);
                    MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                
                
                    MyCmd.ExecuteNonQuery();
                }



            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At AddBookingTime : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return BookingID;
        }
        public DateTime UpdateBookingDate(DateTime date, string BookingStatus,string ID)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdBookingDate", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
        
            try
            {
                MyCmd.Parameters.AddWithValue("@BookingDate", date);
                MyCmd.Parameters.AddWithValue("@BookingID", ID);
                MyCmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                MyCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At UpdateBookingDate : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return date;
        }

        public DataTable ShowBookingTableByCustomer(string Customer)
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBikeBookingMasterByCustomer", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@Customer", Customer);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At ShowBookingTableByCustomer : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        #endregion

    }
}
