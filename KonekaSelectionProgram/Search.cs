using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram
{
    class Search
    {
        static string HeatOutputFormula = "";
        static string Nvalue = "";
        public static void GetRecord(string model, double lenght, double width, double heigh)
        {
            string result = "";
            result = SQLSearch("SELECT ID FROM Convectors where Model ='" + model + "' AND Length = " + lenght + " AND width  = " + width + " AND height  = " + heigh + "");
            if (result != "")
            {
                checkID(result);
            }
        }
        public static void checkID(string ID)
        {
            int intID = 0;
            bool executed = false;
            int.TryParse(ID, out intID);
            if (intID > 0 && intID < 976)
            {
                getHeatOutputFormula(ID);
                getNvalue(ID);
            }
        }
        public static void getHeatOutputFormula(string ID)
        {
            HeatOutputFormula = SQLSearch("Select Formula From Convectors where ID  = " + ID + "");
        }
        public static void getNvalue(string ID)
        {
            Nvalue = SQLSearch("Select n From Convectors where ID  = " + ID + "");

        }
        public static String SQLSearch(String Query)
        {
            String Result = string.Empty;
            try
            {

                if (SQL.Con.State == System.Data.ConnectionState.Open)
                {
                    SQL.Con.Close();
                }
                SQL.Con.Open();
                SqlCommand cmd = new SqlCommand(Query, SQL.Con);
                Result = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                 MessageBox.Show("SQL Scalar Query" + ex.Message);
            }
            finally
            {
                SQL.Con.Close();
            }
            return Result;
        }
    }
}
