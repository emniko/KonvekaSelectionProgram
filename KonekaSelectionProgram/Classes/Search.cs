using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram
{
    //class Search
    //{
    //    //static public  string HeatOutputFormula = "";
    //    //static public string Nvalue = "";
    //    public static double GetRecord(string model, double lenght, double width, double height, double changeInTemperature, double fanSpeed)
    //    {
    //        string result = "";
    //        double heatOutput=0;
    //        result = SQLSearch("SELECT ID FROM Convectors where Model ='" + model + "' AND width  = " + width + " AND height  = " + height + "");
    //        if (result != "")
    //        {
    //            int intID = 0;
    //            int.TryParse(result, out intID);
    //            string Formula, nValue;
    //            if (intID > 0 && intID <= 972)
    //            {
    //                Formula = getHeatOutputFormula(result);
    //                nValue = getNvalue(result);
    //                heatOutput=Formula1(Formula,lenght, nValue, changeInTemperature);
    //            }
    //            else if (intID >= 973 && intID <= 1002)
    //            {
    //                Formula = getHeatOutputFormula(result);
    //                nValue = getNvalue(result);
    //                heatOutput = Formula2(Formula, nValue, fanSpeed, changeInTemperature);
    //            }
    //            else if (intID >= 1003 && intID <= 1008)
    //            {
    //                Formula = getHeatOutputFormula(result);
    //                nValue = getNvalue(result);
    //                heatOutput = Formula3(Formula, nValue, fanSpeed, changeInTemperature);
    //            }
    //        }
    //        return heatOutput;
    //    }
    //    // from 0 to 972
    //    public static double Formula1(string formula, double length, string nValue, double changeInTemperature) // (C1 x [Length, cm] - C2) x ([∆T, °C]/50)nValue
    //    {
    //        formula = formula.Replace("[Length, cm]", length.ToString());
    //        formula = formula.Replace("[∆T, °C]", changeInTemperature.ToString());
    //        formula = formula.Replace(',', '.');
    //        formula = formula.Replace('x', '*');
    //        formula = formula.Substring(0, formula.LastIndexOf(')') + 1);
    //        formula += "^" + nValue;
    //        Expression expression = new Expression(formula);
    //        double result = expression.calculate();
    //        return result;
    //    }
    //    // from 973 to 1002
    //    public static double Formula2(string formula, string nValue, double FanSpeed, double changeInTemperature)//(-7,0706 x ([Fan speed] x 10)2+256,4837 x ([Fan speed] x 10)-352,815) x ([∆T, °C]/50)0,9437 x n
    //    {
    //        formula = formula.Replace("[Fan speed]", FanSpeed.ToString());
    //        formula = formula.Replace("[∆T, °C]", changeInTemperature.ToString());
    //        formula = formula.Replace(',', '.');
    //        formula = formula.Replace('x', '*');
    //        formula = formula.Replace("n", nValue);
    //        formula = formula.Insert(formula.IndexOf(')') + 1, "^");
    //        formula = formula.Insert(formula.LastIndexOf(')') + 1, "^");
    //        Expression expression = new Expression(formula);
    //        double result = expression.calculate();
    //        return result;

    //    }
    //    //form 1003 to 1008
    //    public static double Formula3(string formula, string nValue, double FanSpeed, double changeInTemperature) // 7,6725 x ([∆T, °C])0,9856 x ([Fan speed] x 10)0,8185 x n
    //    {
    //        formula = formula.Replace("[Fan speed]", FanSpeed.ToString());
    //        formula = formula.Replace("[∆T, °C]", changeInTemperature.ToString());
    //        formula = formula.Replace(',', '.');
    //        formula = formula.Replace('x', '*');
    //        formula = formula.Replace("n", nValue);
    //        formula = formula.Insert(formula.IndexOf(')') + 1, "^");
    //        formula = formula.Insert(formula.LastIndexOf(')') + 1, "^");
    //        Expression expression = new Expression(formula);
    //        double result = expression.calculate();
    //        return result;

    //    }
    //    public static string getHeatOutputFormula(string ID)
    //    {
    //        string HeatOutputFormula = SQLSearch("Select Formula From Convectors where ID  = " + ID + "");
    //        return HeatOutputFormula;
    //    }
    //    public static string getNvalue(string ID)
    //    {
    //        string Nvalue = SQLSearch("Select n From Convectors where ID  = " + ID + "");
    //        return Nvalue;
    //    }
    //    public static String SQLSearch(String Query)
    //    {
    //        String Result = string.Empty;
    //        try
    //        {

    //            if (SQL.Con.State == System.Data.ConnectionState.Open)
    //            {
    //                SQL.Con.Close();
    //            }
    //            SQL.Con.Open();
    //            SqlCommand cmd = new SqlCommand(Query, SQL.Con);
    //            Result = cmd.ExecuteScalar().ToString();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("SQL Scalar Query" + ex.Message);
    //        }
    //        finally
    //        {
    //            SQL.Con.Close();
    //        }
    //        return Result;
    //    }
    //}
}
