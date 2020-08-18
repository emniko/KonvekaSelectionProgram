using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonekaSelectionProgram.Classes
{
    class StoreProcedure
    {
        public static void UpdateData(double deltaT, double fanSpeed)
        {
            SQL.NonScalarQuery(@"EXEC UpdateData @delta = "+ deltaT + " ,@fanspeed = "+ fanSpeed + "");
            try
            {
                double FCH2_1009 = 600.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCH2_1010 = 1080.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCH2_1011 = 1200.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCH2_1012 = 1680.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCH2_1013 = 2160.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCHV2_1019 = 600.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCHV2_1020 = 1080.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCHV2_1021 = 1200.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCHV2_1022 = 1680.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                double FCHV2_1023 = 2160.0 / 1000.0 * (-74.1223 * Math.Pow(fanSpeed, 2) + 199.3697 * fanSpeed - 1.7704) * Math.Pow(deltaT, 0.9794);
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCH2_1009 + " WHERE ID = 1009");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCH2_1010 + " WHERE ID = 1010");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCH2_1011 + " WHERE ID = 1011");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCH2_1012 + " WHERE ID = 1012");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCH2_1013 + " WHERE ID = 1013");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCHV2_1019 + " WHERE ID = 1019");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCHV2_1020 + " WHERE ID = 1020");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCHV2_1021 + " WHERE ID = 1021");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCHV2_1022 + " WHERE ID = 1022");
                SQL.NonScalarQuery(@"UPDATE Convectors SET HeatOutput = " + FCHV2_1023 + " WHERE ID = 1023");
            }
            catch (Exception)
            {
                //Ignore
            }

        }
    }
}
