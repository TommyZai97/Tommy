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

        public ComboBox BindAllBikeComboBox(ComboBox CBBike)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BicycleID,BicycleName From BicycleMaster", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BicycleMaster");
            CBBike.ItemsSource = ds.Tables[0].DefaultView;
            CBBike.DisplayMemberPath = ds.Tables[0].Columns["BicycleName"].ToString();
            CBBike.SelectedValuePath = ds.Tables[0].Columns["BicycleID"].ToString();

            return CBBike;
        }

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

        public DataTable ShowAllServiceDetails()
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelAllServiceDetail", MyCon);
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
                throw new Exception("DB Operation Error At ShowAllServiceDetails : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
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
        public DataTable SelectAllBookingByDynamic(string BookingID, string Bicycle, string BookingStatus, string Customer, string Remark, string BicycleType)
        {


            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBookingByDynamic", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@BookingID", BookingID);
            MyCmd.Parameters.AddWithValue("@BicycleName", Bicycle);
      
            MyCmd.Parameters.AddWithValue("@BookingStatus", BookingStatus);
            MyCmd.Parameters.AddWithValue("@Customer", Customer);
            MyCmd.Parameters.AddWithValue("@Remark", Remark);

            MyCmd.Parameters.AddWithValue("@BicycleType", BicycleType);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectAllBookingByDynamic : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;

        }

        public DataTable SelectAllBicycleByDynamic(string BicycleID, string BicycleName, string CurrentRenter, string BicycleColor, string BicycleStatus, string BicycleType)
        {


            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBicycleByDynamic", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
            MyCmd.Parameters.AddWithValue("@BicycleName", BicycleName);
            MyCmd.Parameters.AddWithValue("@CurrentRenter", CurrentRenter);
            MyCmd.Parameters.AddWithValue("@BicycleColor", BicycleColor);
            MyCmd.Parameters.AddWithValue("@BicycleStatus", BicycleStatus);
            MyCmd.Parameters.AddWithValue("@BicycleType", BicycleType);
            
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectAllBicycleByDynamic : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;

        }
        
        public ListBox bindListBoxCustomer(ListBox ListCustomers)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT Customer From BikeBookingMaster WHERE BookingStatus='A'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BikeBookingMaster");
            ListCustomers.ItemsSource = ds.Tables[0].DefaultView;
            ListCustomers.DisplayMemberPath = ds.Tables[0].Columns["Customer"].ToString();
            ListCustomers.SelectedValuePath = ds.Tables[0].Columns["Customer"].ToString();

            return ListCustomers;
        }

        public ListBox bindListBox(ListBox ListBooking , int month)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT BookingID,BicycleType From BikeBookingMaster WHERE BookingStatus='S' AND (MONTH(BookingDate) = '" + month + "')", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "BikeBookingMaster");
            ListBooking.ItemsSource = ds.Tables[0].DefaultView;
            ListBooking.DisplayMemberPath = ds.Tables[0].Columns["BicycleType"].ToString();
            ListBooking.SelectedValuePath = ds.Tables[0].Columns["BookingID"].ToString();

            return ListBooking;
        }

        public DataTable SelectAllBookingDetailsByID(string BookingID)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelAllBookingDetailsByID", conn);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("BookingID", BookingID);
            

            try
            {
                conn.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception ex)
            {
                throw new Exception("DB Operation Error At SelectAllBookingDetailsByID : " + ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                MyCmd.Dispose();

            }
            return ResultDataTable;
        }

        public DataTable SelectBookingByMonthBicycle(string BicycleID, int month)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBookingByMonthBicycle", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

           
            MyCmd.Parameters.AddWithValue("@month", month);
            MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectBookingByMonthBicycle : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public DataTable SelectBookingByMonthType(string BicycleType , int month)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBookingByMonthType", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

           
            MyCmd.Parameters.AddWithValue("@month", month);
            MyCmd.Parameters.AddWithValue("@BicycleType", BicycleType);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectBookingByMonthType : " + e.Message);
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
        public DataTable SelectAllEmployeeByDynamic(string EmployeeID, string EmployeeName, string RankDesc, string Address, string CreatedBy)
        {


            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelEmployeeByDynamic", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            MyCmd.Parameters.AddWithValue("@EmployeeName", EmployeeName);
            MyCmd.Parameters.AddWithValue("@RankDesc", RankDesc);
            MyCmd.Parameters.AddWithValue("@Address", Address);

            MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectAllEmployeeByDynamic : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;

        }

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
        public DataTable SelectEmployeeDetailsByRankLevel(int RankID)
        {


            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelEmployeeDetailsByRanklvl", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@RankID", RankID);
            try
            {
                MyCon.Open();

                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectEmployeeDetailsByRankLevelTwo : " + e.Message);
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

        public DataTable ShowBookingTableByCustomer(string Customer, string Status)
        {

            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelBikeBookingMasterByCustomer", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            MyCmd.Parameters.AddWithValue("@Customer", Customer);
            MyCmd.Parameters.AddWithValue("@Status", Status);
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
        public DataTable SelectAllSnackByDynamic(string SnackID, string SnackName,string SnackStatus, string SnackType)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelSnackByDynamic", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@SnackID", SnackID);
            MyCmd.Parameters.AddWithValue("@SnackName", SnackName);
            MyCmd.Parameters.AddWithValue("@SnackType", SnackType);
            MyCmd.Parameters.AddWithValue("@SnackStatus", SnackStatus);
      
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
                throw new Exception("DB Operation Error At SelectAllSnackByDynamic : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public ComboBox BindSnackCombo(ComboBox ComboBox)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlDataAdapter da = new SqlDataAdapter("SELECT SnackID,SnackName From SnackTableMaster Where SnackStatus = 'A'", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SnackTableMaster");
            ComboBox.ItemsSource = ds.Tables[0].DefaultView;
            ComboBox.DisplayMemberPath = ds.Tables[0].Columns["SnackName"].ToString();
            ComboBox.SelectedValuePath = ds.Tables[0].Columns["SnackID"].ToString();

            return ComboBox;
        }

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

        public string AddSnackSales(string SnackID, int Quantity, string Customer, double price,string CreatedBy,string BookingID)
        {
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("AddSnackSalesMaster", conn);
            MyCmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            try
            {
                if (BookingID == "")
                {
                    MyCmd.Parameters.AddWithValue("@SnackID", SnackID);
                    MyCmd.Parameters.AddWithValue("@Quantity", Quantity);
                    MyCmd.Parameters.AddWithValue("@price", price);
                    MyCmd.Parameters.AddWithValue("@Customer", Customer);
                    MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();
            
                    MyCmd.CommandText = "UpdSnackQuantity";
                    MyCmd.Parameters.AddWithValue("@Quantity", Quantity);
                    MyCmd.Parameters.AddWithValue("@SnackID", SnackID);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();
                }
                else
                {
                    MyCmd.CommandText = "AddExistBookSnackSalesMaster";
                    MyCmd.Parameters.AddWithValue("@SnackID", SnackID);
                    MyCmd.Parameters.AddWithValue("@BookingID", BookingID);
                    MyCmd.Parameters.AddWithValue("@price", price);
                    MyCmd.Parameters.AddWithValue("@Quantity", Quantity);
                    MyCmd.Parameters.AddWithValue("@Customer", Customer);
                    MyCmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();

                    MyCmd.CommandText = "UpdSnackQuantity";
                    MyCmd.Parameters.AddWithValue("@Quantity", Quantity);
                    MyCmd.Parameters.AddWithValue("@SnackID", SnackID);
                    MyCmd.ExecuteNonQuery();
                    MyCmd.Parameters.Clear();
                }
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

        public DataTable SelectSnackSalesByBookIDCustomer(string BookingID, string Customer) {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelSnackSalesByBookIDCustomer ", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@BookingID", BookingID);
            MyCmd.Parameters.AddWithValue("@Customer", Customer);
          

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
                throw new Exception("DB Operation Error At SelectSnackSalesByBookIDCustomer : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }
        public DataTable SelectSnackBySnackID(string SnackID)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelSnackBySnackID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@SnackID", SnackID);


            //we will use SQLAdaptor due to huge amount of column
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();
                MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelectSnackBySnackID : " + e.Message);
            }
            finally
            {
                MyCon.Close();
                MyCon.Dispose();
                MyCmd.Dispose();
            }
            return ResultDataTable;
        }

        public DataTable SelectSnackSalesBySnackID(string SnackID)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelSnackSalesbySnackID", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@SnackID", SnackID);
           

            //we will use SQLAdaptor due to huge amount of column
            SqlDataAdapter MyDA = new SqlDataAdapter(MyCmd);
            DataTable ResultDataTable = new DataTable("ResultDataTable");

            try
            {
                MyCon.Open();
                   MyDA.Fill(ResultDataTable);
            }
            catch (Exception e)
            {
                throw new Exception("DB Operation Error At SelSnackSalesBySnackID : " + e.Message);
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

        #region Service
        public DataTable SelAllServiceByDynamic(string SnackID, string BicycleID, string Remark, string Status)
        {
            SqlConnection MyCon = new SqlConnection(constring);
            SqlCommand MyCmd = new SqlCommand("SelServiceByDynamic", MyCon);
            MyCmd.CommandTimeout = 600;
            MyCmd.CommandType = CommandType.StoredProcedure;
            MyCmd.Parameters.AddWithValue("@ServiceID", SnackID);
            MyCmd.Parameters.AddWithValue("@BicycleID", BicycleID);
            MyCmd.Parameters.AddWithValue("@Remark", Remark);
            MyCmd.Parameters.AddWithValue("@Status", Status);

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
                throw new Exception("DB Operation Error At SelAllServiceByDynamic : " + e.Message);
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
