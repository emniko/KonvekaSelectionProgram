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
        public void Search1000(DataGridView dataGridView, string Model, double Length)
        {
            Main.fillDgv(dataGridView, "select top 6  * from convectors where  model<= '" + Model + "'   and length <=" + Length + " order by ID ");
        }
        //2
        public void Search0100(DataGridView dataGridView, string Model, double Width)
        {
            Main.fillDgv(dataGridView, "select top 6  * from convectors where  model<= '" + Model + "'   and Width <= " + Width + " order by ID ");
        }
        //3
        public void Search0010(DataGridView dataGridView, string Model, double Height)
        {
            Main.fillDgv(dataGridView, "select top 6  * from convectors where  model<= '" + Model + "'   and Height <=" + Height + " order by ID ");
        }
        //4
        public void Search0001(DataGridView dataGridView, string Model, double Heatoutput)
        {
            Main.fillDgv(dataGridView, "select Top 6* from Convectors where model <='" + Model + "' and HeatOutput <= " + Heatoutput + "");
        }
        //5
        public void Search1100(DataGridView dataGridView, string Model, double Length, double Width)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Length <= " + Length + " and Width <= " + Width + "");
        }
        //6
        public void Search1000(DataGridView dataGridView, string Model, double Length, double Height)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Length <= " + Length + " and Height <= " + Height + "");
        }
        //7
        public void Search1001(DataGridView dataGridView, string Model, double Length, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Length <= " + Length + " and HeatOutput <= " + HeatOutput + "");
        }
        //8
        public void Search0110(DataGridView dataGridView, string Model, double Width, double Height)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Width <= " + Width + " and Height <= " + Height + "");
        }
        //9
        public void Search0101(DataGridView dataGridView, string Model, double Width, double HeatOuput)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Width <= " + Width + " and HeatOuput <= " + HeatOuput + "");
        }
        //10
        public void Search0011(DataGridView dataGridView, string Model, double Height, double HeatOuput)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Height <= " + Height + " and HeatOuput <= " + HeatOuput + "");
        }
        //11
        public void Search1110(DataGridView dataGridView, string Model, double Length, double Width, double Height)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Length <= " + Length + " and Width <= " + Width + " and Height <= " + Height + "");
        }
        //12
        public void Search1011(DataGridView dataGridView, string Model, double Length, double Height, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Length <= " + Length + "  and Height <= " + Height + " and HeatOutput <= " + HeatOutput + "");
        }
        //13
        public void Search0111(DataGridView dataGridView, string Model, double Width, double Height, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Width <= " + Width + "  and Height <= " + Height + " and HeatOutput <= " + HeatOutput + "");
        }
        //14
        public void Search1111(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            Main.fillDgv(dataGridView, "select Top 6 * from Convectors where model <= '" + Model + "' and Length <= " + Length + " and Width<=" + Width + "  and Height <= " + Height + " and HeatOutput <= " + HeatOutput + "");
        }

    }
}
