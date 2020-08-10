using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram.Classes
{
    class Grille
    {
        public static bool checkGrille(int ID)
        {
            string result = SQL.ScalarQuery("Select IsNull(Grille,0) from convectors where ID  = " + ID + " ");
            if (result == "0")
            {
                return false;
            }
            else return true;
        }
        public static void getRollUpGrille(DataGridView dataGridView, double lenght, double width, string materal)
        {
            Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,Material,Name from GrilleProducts where Model = 'GR' and Length = " + lenght + " and width = " + width + " and material  =  '" + materal + "' ");
        }
        public static void getLinearGrille(DataGridView dataGridView, double lenght, double width, string materal)
        {
            Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,Material,Name from GrilleProducts where Model = 'GR-L' and Length = " + lenght + " and width = " + width + " and material  =  '" + materal + "' ");
        }
    }
}
