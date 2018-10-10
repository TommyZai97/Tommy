using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikWpfApp1
{
    class TBIkeUtility
    {
        public static void TranslateRecordStatusDescription(List<string> ColumnNameList, ref DataTable IncomingDataTable)
        {
            //flag to see if all column required is in
            //assuming it is ok
            bool ColumnNameFound = true;
            foreach (string ColumnName in ColumnNameList)
            {
                if (!IncomingDataTable.Columns.Contains(ColumnName.Trim() + "InFull"))
                {
                    //add in the display name column if not found
                    IncomingDataTable.Columns.Add(ColumnName.Trim() + "InFull");
                }
                if (!IncomingDataTable.Columns.Contains(ColumnName))
                {
                    ColumnNameFound = false;
                }
            }
            if (ColumnNameFound)
            {
                //loop through all the record
                foreach (DataRow MyRow in IncomingDataTable.Rows)
                {
                    foreach (string ColumnName in ColumnNameList)
                    {
                        //loop through all the column
                        if (MyRow[ColumnName] != DBNull.Value)
                        {
                            string RecordStatus = Convert.ToString(MyRow[ColumnName]).Trim().ToUpper();
                            if (RecordStatus.Equals("A"))
                            {
                                MyRow[ColumnName + "InFull"] = "Active";
                            }
                            else if (RecordStatus.Equals("R"))
                            {
                                MyRow[ColumnName + "InFull"] = "Renting";
                            }
                            else if (RecordStatus.Equals("U"))
                            {
                                MyRow[ColumnName + "InFull"] = "UnActive";
                            }
                            else if (RecordStatus.Equals("E"))
                            {
                                MyRow[ColumnName + "InFull"] = "Expired";
                            }
                            else if (RecordStatus.Equals("S"))
                            {
                                MyRow[ColumnName + "InFull"] = "Successful";
                            }
                            else if (RecordStatus.Equals("N"))
                            {
                                MyRow[ColumnName + "InFull"] = "Not Returned";
                            }
                            else
                            {
                                MyRow[ColumnName + "InFull"] = "Unknown";
                            }
                        }
                        else
                        {
                            MyRow[ColumnName + "InFull"] = "Unknown";
                        }
                    }
                }
            }
        }
    }
}
