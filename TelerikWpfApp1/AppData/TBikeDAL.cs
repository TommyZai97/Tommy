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

namespace TBike
{
    public class TBikeDAL
    {
        static string constring = ConfigurationManager.ConnectionStrings["123"].ConnectionString;


        #region BikeMaster
        public DataTable SelectBicycleByID(string BicycleID)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBicycleMasterByID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);

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
                throw new Exception("DB Operation Error At SelectBicycleByID : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public DataTable SelectBicycleByStatus(string BicycleStatus)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBicycleMasterByStatus", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@BicycleStatus", BicycleStatus);

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
                throw new Exception("DB Operation Error At SelectBicycleByStatus : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

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

       
        public string AddBicycleTable(string BicycleName,string BicycleType, double Price, string Color, string CreatedBy)
        {
            string BicycleID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("AddBicycleMaster", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                
      

                MyCmd.Parameters.AddWithValue("@BicycleName", BicycleName);
                MyCmd.Parameters.AddWithValue("@BicycleType", BicycleType);

                MyCmd.Parameters.AddWithValue("@Price", Price);
                MyCmd.Parameters.AddWithValue("@Color", Color);
                MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
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
            return BicycleID;
        }
        public DataTable SelectServiceByBike(string BicycleID)
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBicycleServiceMasterByBike", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");
            MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectServiceByBike : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public string UpdateBikeStatus(string BicycleID, string Customer, string BicycleStatus, string Condition, DateTime? ServiceStart, DateTime? ServiceEnd, string LastUpdatedBy)
        {
            string BookingID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdBikeStatus", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {


                MyCmd.Parameters.AddWithValue("@BicycleStatus", BicycleStatus);
                MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                MyCmd.Parameters.AddWithValue("@Customer", Customer);
                MyCmd.Parameters.AddWithValue("@Condition", Condition);
                MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
                MyCmd.ExecuteNonQuery();
                MyCmd.Parameters.Clear();
                if (BicycleStatus == "M")
                {
                    MyCmd.CommandText = "AddBikeService";
                    MyCmd.Parameters.AddWithValue("@Status", BicycleStatus);
                    MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                    MyCmd.Parameters.AddWithValue("@ServiceEnd", ServiceEnd);
                    MyCmd.Parameters.AddWithValue("@Remark", Condition);
                    MyCmd.Parameters.AddWithValue("@ServiceStart", ServiceStart);
                    MyCmd.Parameters.AddWithValue("@CreatedBy", LastUpdatedBy);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();
                }
            
                 if (BicycleStatus == "A" && ServiceStart != null )
                {
                    MyCmd.CommandText = "UpdBikeService";
                    MyCmd.Parameters.AddWithValue("@Status", "S");
                    MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                    MyCmd.Parameters.AddWithValue("@ServiceEnd", ServiceEnd);
                    MyCmd.Parameters.AddWithValue("@Remark", Condition);
                    MyCmd.Parameters.AddWithValue("@ServiceStart", ServiceStart);
                    MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
                    MyCmd.ExecuteNonQuery();
                }

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

        public string UpdateBicycleTable(string BicycleID, string BicycleName,string BicycleType, string ItemStatus,double Price, string Color, string LastUpdatedBy)
        {
        
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdBicycleMaster", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {

                MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);

                MyCmd.Parameters.AddWithValue("@BicycleName", BicycleName);
                MyCmd.Parameters.AddWithValue("@BicycleType", BicycleType);
                MyCmd.Parameters.AddWithValue("@BicycleStatus", ItemStatus);

                MyCmd.Parameters.AddWithValue("@Price", Price);
                MyCmd.Parameters.AddWithValue("@Color", Color);
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
            return BicycleID;
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
        public string AddNewEmployeeDetails(string EmployeeName, DateTime DateOfBirth, string Email, string PhoneNo, string Address, string CreatedBy)
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
                MyCmd.Parameters.AddWithValue("@Address", Address);
              
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

        public string UpdateEmployee(string EmployeeID,string EmployeeName, DateTime DateOfBirth, string Username,string RankDesc,string Email, string PhoneNo, string Address, string LastUpdatedBy)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdEmpMaster", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {

                MyCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                MyCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
                MyCmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
                MyCmd.Parameters.AddWithValue("@Email", Email);
                MyCmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                MyCmd.Parameters.AddWithValue("@Address", Address);
                MyCmd.Parameters.AddWithValue("@Username", Username);
                MyCmd.Parameters.AddWithValue("@RankDesc", RankDesc);
                MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
       
                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateEmployee : " + e.Message);
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

     
        public string UpdateBookingDate(DateTime BookingDate, string BicycleID, string customer, double? TotalPrice, string BookingStatus,string CreatedBy, TimeSpan? StartTime, TimeSpan? Endtime, string Remarks)
        {
            string BookingID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdBookingTable", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
           
                MyCmd.Parameters.AddWithValue("@BookingDate", BookingDate);
                MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
                MyCmd.Parameters.AddWithValue("@StartTime", StartTime);
                MyCmd.Parameters.AddWithValue("@Endtime", Endtime);
                MyCmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                MyCmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
                MyCmd.Parameters.AddWithValue("@Customer", customer);
                MyCmd.Parameters.AddWithValue("@Remarks", Remarks);
                MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                MyCmd.ExecuteNonQuery();
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

        public string AddBookingTime(DateTime BookingDate, string BicycleID, string BicycleStatus, string customer, double? TotalPrice, string CreatedBy, TimeSpan? StartTime, TimeSpan? Endtime, string Remarks)
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
                    MyCmd.Parameters.AddWithValue("@StartTime", DBNull.Value);
                    MyCmd.Parameters.AddWithValue("@Endtime", DBNull.Value);
                    MyCmd.Parameters.AddWithValue("@TotalPrice", DBNull.Value);
                    MyCmd.Parameters.AddWithValue("@BookingStatus", "A");
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
                    MyCmd.Parameters.AddWithValue("@Condition", "");
                    MyCmd.Parameters.AddWithValue("@LastUpdatedBy", CreatedBy);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();

                    MyCmd.CommandText = "AddNewBookTime";
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

        #region Snack
        public DataTable SelectSnackByID(string SnackID)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelSnackMasterByID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@SnackID", SnackID);

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

        public DataTable ShowAllSnackTable()
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelAllSnackMaster", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
           

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
                throw new Exception("DB Operation Error At ShowAllSnackTable : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }
        public string AddSnackTable(string SnackName, string SnackType, double Price, int Quantity, string CreatedBy)
        {
            string SnackID = "";
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("AddSnackMaster", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {

              

                MyCmd.Parameters.AddWithValue("@SnackName", SnackName);
                MyCmd.Parameters.AddWithValue("@SnackType", SnackType);

                MyCmd.Parameters.AddWithValue("@Price", Price);
                MyCmd.Parameters.AddWithValue("@Quantity", Quantity);
                MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateSnackTable : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return SnackID;
        }

        public string UpdateSnackTable(string SnackID, string SnackName, string SnackType, double Price, int Quantity, string Status, string LastUpdatedBy)
        {

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("UpdSnackMaster", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {

                MyCmd.Parameters.AddWithValue("@SnackID", SnackID);

                MyCmd.Parameters.AddWithValue("@SnackName", SnackName);
                MyCmd.Parameters.AddWithValue("@SnackType", SnackType);
                MyCmd.Parameters.AddWithValue("@SnackStatus", Status);

                MyCmd.Parameters.AddWithValue("@Price", Price);
                MyCmd.Parameters.AddWithValue("@Quantity", Quantity);
                MyCmd.Parameters.AddWithValue("@LastUpdatedBy", LastUpdatedBy);
                MyCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw new Exception("DB Operation Error At UpdateSnackTable : " + e.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();
            }
            return SnackID;
        }
        #endregion
    }
}
