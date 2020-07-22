using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonekaSelectionProgram.Classes
{
    class StoreProcedure
    {

        public static void UpdateData(double delta, double fanspeed)
        {
            SQL.NonScalarQuery(@"EXEC UpdateData @delta = "+ delta + " ,@fanspeed = "+ fanspeed + "");
        }
    }
}
