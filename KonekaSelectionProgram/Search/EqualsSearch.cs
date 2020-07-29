using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram.Search
{
    //binary format used 
    //|Lenght|Width|Height|Heatoutput|
    class EqualsSearch
    {
        //1
        public static void Search1000(DataGridView dataGridView, string Model, double Length)
        {
          //  Main.fillDgv(dataGridView, "select top 6  ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from convectors where  model= '" + Model + "'   and length =" + Length + " order by ID ");
            string query =String.Format(@" select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}'
                    and Length = {1} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length = {1} Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Length.ToString());
            Main.fillDgv(dataGridView, query);
          
        }
        //2
        public static void Search0100(DataGridView dataGridView, string Model, double Width)
        {
            Main.fillDgv(dataGridView, "select top 6  ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from convectors where  model= '" + Model + "'   and Width = " + Width + " order by HeatOutput ");
            
        }
        //3
        public static void Search0010(DataGridView dataGridView, string Model, double Height)
        {
            Main.fillDgv(dataGridView, "select top 6  ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from convectors where  model= '" + Model + "'   and Height =" + Height + " order by HeatOutput ");
        }
        //4
        public static void Search0001(DataGridView dataGridView, string Model, double Heatoutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model ='" + Model + "' and HeatOutput = " + Heatoutput + " order by HeatOutput");
        }
        //5
        public static void Search1100(DataGridView dataGridView, string Model, double Length, double Width)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length = " + Length + " and Width = " + Width + " order by HeatOutput");
        }
        //6
        public static void Search1010(DataGridView dataGridView, string Model, double Length, double Height)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length = " + Length + " and Height = " + Height + " order by HeatOutput ");
        }
        //7
        public static void Search1001(DataGridView dataGridView, string Model, double Length, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length = " + Length + " and HeatOutput = " + HeatOutput + " order by HeatOutput");
        }
        //8
        public static void Search0110(DataGridView dataGridView, string Model, double Width, double Height)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Width = " + Width + " and Height = " + Height + " order by HeatOutput");
        }
        //9
        public static void Search0101(DataGridView dataGridView, string Model, double Width, double HeatOuput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Width = " + Width + " and HeatOuput = " + HeatOuput + " order by HeatOutput");
        }
        //10
        public static void Search0011(DataGridView dataGridView, string Model, double Height, double HeatOuput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Height = " + Height + " and HeatOuput = " + HeatOuput + " order by HeatOutput");
        }
        //11
        public static void Search1110(DataGridView dataGridView, string Model, double Length, double Width, double Height)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length = " + Length + " and Width = " + Width + " and Height = " + Height + "order by HeatOutput");
        }
        //12
        public static void Search1011(DataGridView dataGridView, string Model, double Length, double Height, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length = " + Length + "  and Height = " + Height + " and HeatOutput = " + HeatOutput + "order by HeatOutput");
        }
        //13
        public static void Search0111(DataGridView dataGridView, string Model, double Width, double Height, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Width = " + Width + "  and Height = " + Height + " and HeatOutput = " + HeatOutput + " order by HeatOutput");
        }
        //14
        public static void Search1111(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length = " + Length + " and Width=" + Width + "  and Height = " + Height + " and HeatOutput = " + HeatOutput + " order by HeatOutput");
        }

    }
}
