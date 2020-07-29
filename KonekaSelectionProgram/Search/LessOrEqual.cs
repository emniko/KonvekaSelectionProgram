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
    class LessOrEqual
    {
        //1
        public static void Search1000(DataGridView dataGridView, string Model, double Length)
        {
            //Main.fillDgv(dataGridView, "select top 6  ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from convectors where  model= '" + Model + "'   and length <=" + Length + " order by ID ");
            string query = string.Format(@"select  distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
                    (
                    SELECT *
                    FROM(SELECT Top 3 * FROM Convectors

                    WHERE Model = '{0}'
                    and Length <= {1} Order by HeatOutput Desc
                    )t
                    UNION ALL
                    SELECT * FROM
                    (SELECT Top 3 * FROM Convectors
                    WHERE Model = '{0}'
                    and Length <= {1} Order by HeatOutput Asc
                    )s
                    )a
                     order by id ", Model,Length);
            Main.fillDgv(dataGridView, query);
        }
        //2
        public static void Search0100(DataGridView dataGridView, string Model, double Width)
        {
          //  Main.fillDgv(dataGridView, "select top 6  ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from convectors where  model= '" + Model + "'   and Width <= " + Width + " order by ID ");
            string query = string.Format(@"select distinct  ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
                    (
                    SELECT *
                    FROM(SELECT Top 3 * FROM Convectors

                    WHERE Model = '{0}'
                    and Width <= {1} Order by HeatOutput Desc
                    )t
                    UNION ALL
                    SELECT * FROM
                    (SELECT Top 3 * FROM Convectors
                    WHERE Model = '{0}'
                    and Width <= {1} Order by HeatOutput Asc
                    )s
                    )a
                     order by id ", Model, Width);
            Main.fillDgv(dataGridView, query);
        }
        //3
        public static void Search0010(DataGridView dataGridView, string Model, double Height)
        {
          //  Main.fillDgv(dataGridView, "select top 6  ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from convectors where  model= '" + Model + "'   and Height <=" + Height + " order by ID ");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
                    (
                    SELECT *
                    FROM(SELECT Top 3 * FROM Convectors

                    WHERE Model = '{0}'
                    and Height <= {1} Order by HeatOutput Desc
                    )t
                    UNION ALL
                    SELECT * FROM
                    (SELECT Top 3 * FROM Convectors
                    WHERE Model = '{0}'
                    and Height <= {1} Order by HeatOutput Asc
                    )s
                    )a
                     order by id ", Model, Height);
            Main.fillDgv(dataGridView, query);
        }
        //4
        public static void Search0001(DataGridView dataGridView, string Model, double Heatoutput)
        {
            //Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model ='" + Model + "' and HeatOutput <= " + Heatoutput + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
                    (
                    SELECT *
                    FROM(SELECT Top 3 * FROM Convectors

                    WHERE Model = '{0}'
                    and Heatoutput <= {1} Order by HeatOutput Desc
                    )t
                    UNION ALL
                    SELECT * FROM
                    (SELECT Top 3 * FROM Convectors
                    WHERE Model = '{0}'
                    and Heatoutput <= {1} Order by HeatOutput Asc
                    )s
                    )a
                     order by id ", Model, Heatoutput);
            Main.fillDgv(dataGridView, query);
        }
        //5
        public static void Search1100(DataGridView dataGridView, string Model, double Length, double Width)
        {
          //  Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length <= " + Length + " and Width <= " + Width + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Length <= {1}  and Width <= {2} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length <= {1} and Width <= {2}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model,Length,Width);
           Main.fillDgv(dataGridView, query);

        }
        //6
        public static void Search1010(DataGridView dataGridView, string Model, double Length, double Height)
        {
            // Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length <= " + Length + " and Height <= " + Height + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Length <= {1}  and Height <= {2} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length <= {1} and Height <= {2}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Length, Height);
            Main.fillDgv(dataGridView, query);
        }
        //7
        public static void Search1001(DataGridView dataGridView, string Model, double Length, double HeatOutput)
        {
            //Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length <= " + Length + " and HeatOutput <= " + HeatOutput + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Length <= {1}  and HeatOutput <= {2} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length <= {1} and HeatOutput <= {2}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Length, HeatOutput);
            Main.fillDgv(dataGridView, query);
        }
        //8
        public static void Search0110(DataGridView dataGridView, string Model, double Width, double Height)
        {
           // Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Width <= " + Width + " and Height <= " + Height + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Width <= {1}  and Height <= {2} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Width <= {1} and Height <= {2}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Width, Height);
            Main.fillDgv(dataGridView, query);
        }
        //9
        public static void Search0101(DataGridView dataGridView, string Model, double Width, double HeatOuput)
        {
            //  Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Width <= " + Width + " and HeatOuput <= " + HeatOuput + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Width <= {1}  and HeatOuput <= {2} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Width <= {1} and HeatOuput <= {2}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Width, HeatOuput);
            Main.fillDgv(dataGridView, query);
        }
        //10
        public static void Search0011(DataGridView dataGridView, string Model, double Height, double HeatOuput)
        {
            // Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Height <= " + Height + " and HeatOuput <= " + HeatOuput + "");
            string query = string.Format(@"select distinct ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Height <= {1}  and HeatOuput <= {2} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Height <= {1} and HeatOuput <= {2}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Height, HeatOuput);
            Main.fillDgv(dataGridView, query);
        }
        //11
        public static void Search1110(DataGridView dataGridView, string Model, double Length, double Width, double Height)
        {
           // Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length <= " + Length + " and Width <= " + Width + " and Height <= " + Height + "");
            string query = string.Format(@"select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Length <={1} and  Width <= {2}  and Height <= {3} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length <={1} and Width <= {2} and Height <= {3}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ",Model, Length, Width,Height);
            Main.fillDgv(dataGridView, query);
        }
        //12
        public static void Search1011(DataGridView dataGridView, string Model, double Length, double Height, double HeatOutput)
        {
            //Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length <= " + Length + "  and Height <= " + Height + " and HeatOutput <= " + HeatOutput + "");
            string query = string.Format(@"select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Length <={1} and  Height <= {2}  and HeatOutput <= {3} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length <={1} and Height <= {2} and HeatOutput <= {3}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Length, Height, HeatOutput);
            Main.fillDgv(dataGridView, query);
        }
        //13
        public static void Search0111(DataGridView dataGridView, string Model, double Width, double Height, double HeatOutput)
        {
           // Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Width <= " + Width + "  and Height <= " + Height + " and HeatOutput <= " + HeatOutput + "");
            string query = string.Format(@"select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Width <={1} and  Height <= {2}  and HeatOutput <= {3} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Width <={1} and Height <= {2} and HeatOutput <= {3}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model, Width, Height, HeatOutput);
            Main.fillDgv(dataGridView, query);
        }
        //14
        public static void Search1111(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            // Main.fillDgv(dataGridView, "select Top 6 ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from Convectors where model = '" + Model + "' and Length <= " + Length + " and Width<=" + Width + "  and Height <= " + Height + " and HeatOutput <= " + HeatOutput + "");
            string query = string.Format(@"select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 3 * FROM Convectors 
    	            WHERE Model = '{0}' 
                    and Length <={1} and  Width <= {2}  and Height <= {3}  and HeatOutput <= {4} Order by HeatOutput Desc 
                    )t 
                    UNION ALL 
                    SELECT * FROM  
                    (SELECT Top 3 * FROM Convectors 
                    WHERE Model = '{0}'
                    and Length <={1} and Width <= {2} and Height <= {3} and HeatOutput <= {4}  Order by HeatOutput Asc
                    )s  
                    )a 
                     order by id ", Model,Length,Width,Height,HeatOutput);
            Main.fillDgv(dataGridView, query);

        }

    }
}
