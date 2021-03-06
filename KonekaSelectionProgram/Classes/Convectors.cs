﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram
{
    class Convectors
    {
        public static void getConvectors(DataGridView dataGridView, string Model, double width, double height,double heatOutput)
        {
            Main.fillDgv(dataGridView, @"
	                select ID,Model,Length,Width,Height,HeatOutput,CoolingCapacity from 
	                (
	                SELECT *            
            	    FROM   (SELECT Top 2 * FROM Convectors 
    	            WHERE Model = '" + Model + "' and width = " + width + " and height = " + height + " " +
                    "and HeatOutput <= " + heatOutput + " Order by HeatOutput Desc" +
                    ")t " +
                    "UNION ALL " +
                    "SELECT * FROM  " +
                    "(SELECT Top 2  * FROM Convectors " +
                    "WHERE Model = '" + Model + "' and width = " + width + " and height = " + height + " " +
                    "and HeatOutput > " + heatOutput + " Order by HeatOutput Asc" +
                    ")s " +
                    ")a" +
                    " order by id"
                    );
        }
    }
}
