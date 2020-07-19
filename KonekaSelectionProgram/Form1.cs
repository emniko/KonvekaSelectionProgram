using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram
{
    public partial class cmb_ConvectorsType : Form
    {
        public cmb_ConvectorsType()
        {
            InitializeComponent();
        }
        private void FillCombox()
        {
        }
        private void cmb_ConvectorsType_Load(object sender, EventArgs e)
        {
            //installation type
            Main.fillComboWithoutCondition(cmb_ConvectorsInstallationType, "InstallationType", "IntallationType", "IntallationTypeID");
            //accessories
            Main.fillComboWithoutCondition(cmb_Accessory, "Accessories", "Name", "ID");
            //Grilles Types
            Main.fillComboWithoutCondition(cmb_GrillsType, "GrillType", "Type", "ID");


        }
        private void cmb_ConvectorsInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Type : Depends upon Installation
            cmb_Type.Text = "";
            Main.fillCombo(cmb_Type, "Type", "TypeName", "TypeID", "IntallationTypeID = " + cmb_ConvectorsInstallationType.SelectedValue + "");
            //disable grilles when value other than trench is selected 
            if (cmb_ConvectorsInstallationType.SelectedValue.ToString()!= "1")
            {

                cmb_GrillsType.SelectedValue = 1;
                cmb_GrillsType.Enabled = false;
                cmb_GrillsMaterialColor.Enabled = false;
            }
            else
            {
                cmb_GrillsType.Enabled = true;
                cmb_GrillsMaterialColor.Enabled = true;
            }
            if (cmb_ConvectorsInstallationType.SelectedValue.ToString() == "2" || cmb_ConvectorsInstallationType.SelectedValue.ToString() == "3")
            {
                txt_Color.Text = "9016";
            }
            else
            {
                txt_Color.Clear();

            }

        }
        private void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Model : Depends Upon Type
            cmb_ConvectorsModel.Text = "";
            Main.fillCombo(cmb_ConvectorsModel, "Model", "ModelName", "ModelID", "TypeID ="+cmb_Type.SelectedValue+"");

        }
        private void cmb_GrillsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Grilles Color : Depends upon Grill
            cmb_GrillsMaterialColor.Text = "";
            Main.fillCombo(cmb_GrillsMaterialColor, "GrillMaterial", "Type", "ID", "GrillID = " + cmb_GrillsType.SelectedValue + "");

        }
        #region OnlyDigits
        private void txt_Length_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);
        }

        private void txt_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Color_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_HeatOutput_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_CoolingCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Incoming_Heating_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Outgoing_Heating_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Room_Heating_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_DeltaT_Heating_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_FanSpeed_Heating_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Incoming_Cooling_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Outgoing_Cooling_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Room_Cooling_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_DeltaT_Cooling_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_FanSpeed_Cooling_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_PriceBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }

        private void txt_PriceCorrection_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);

        }
        #endregion

        private void txt_Incoming_Heating_TextChanged(object sender, EventArgs e)
        {
            changeInTemerature();
        }
        private void txt_Outgoing_Heating_TextChanged(object sender, EventArgs e)
        {
            changeInTemerature();
        }

        private void txt_Room_Heating_TextChanged(object sender, EventArgs e)
        {
            changeInTemerature();
        }
        private bool changeInTemerature()
        {
            double IncommingTemp = 0, OutgoingTemp = 0, RoomTeamperature = 0, ChangeInTemperature = 0;
            bool val = false;
            if (double.TryParse(txt_Incoming_Heating.Text, out IncommingTemp))
            {
                if (double.TryParse(txt_Outgoing_Heating.Text, out OutgoingTemp))
                {
                    if (double.TryParse(txt_Room_Heating.Text, out RoomTeamperature))
                    {
                        ChangeInTemperature = (IncommingTemp + OutgoingTemp) / 2 - RoomTeamperature;
                        txt_DeltaT_Heating.Text = ChangeInTemperature.ToString();
                        val = true;
                    }
                }
            }
            return val;
        }
    }
}
