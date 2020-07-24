using KonekaSelectionProgram.Classes;
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
using KonekaSelectionProgram.Search;

namespace KonekaSelectionProgram
{
    public partial class cmb_ConvectorsType : Form
    {
        bool grillRequire = false;
        string Grilletype = "";
        string GrillMaterail = "";

        //for sugguestions 
        string _InquiryLength = "";
        string _InquiryWidth = "";
        string _InquiryHeight = "";
        string _InquiryModel = "";
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

            cmb_searchingCriteria.SelectedIndex = 0;

        }
        private void cmb_ConvectorsInstallationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Type : Depends upon Installation
            cmb_Type.Text = "";
            Main.fillCombo(cmb_Type, "Type", "TypeName", "TypeID", "IntallationTypeID = " + cmb_ConvectorsInstallationType.SelectedValue + "");
            //disable grilles when value other than trench is selected 
            if (cmb_ConvectorsInstallationType.SelectedValue.ToString() != "1")
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
            Main.fillCombo(cmb_ConvectorsModel, "Model", "ModelName", "ModelID", "TypeID =" + cmb_Type.SelectedValue + "");

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
        //calculating change in temperature 
        private bool changeInTemerature()
        {
            double IncommingTemp = 0, OutgoingTemp = 0, RoomTeamperature = 0, ChangeInTemperature = 0;
            bool val = false;
            if (double.TryParse(txt_HeatingIncommingWater.Text, out IncommingTemp))
            {
                if (double.TryParse(txt_HeatingOutgoingWaterTemperature.Text, out OutgoingTemp))
                {
                    if (double.TryParse(txt_HeatingRoomTemperature.Text, out RoomTeamperature))
                    {
                        ChangeInTemperature = (IncommingTemp + OutgoingTemp) / 2 - RoomTeamperature;
                        txt_HeatingChangeInTemperature.Text = ChangeInTemperature.ToString();
                        val = true;
                    }
                }
            }
            return val;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //GetRecord(string model, double lenght, double width, double height, double changeInTemperature, double fanSpeed)
            double length = 0, width = 0, height = 0, heatOutput = 0, changeInTemperature = 0, fanSpeed = 0;
            double.TryParse(txt_Length.Text, out length);
            double.TryParse(txt_Width.Text, out width);
            double.TryParse(txt_Height.Text, out height);
            double.TryParse(txt_HeatingChangeInTemperature.Text, out changeInTemperature);
            double.TryParse(txt_HeatingFanSpeed.Text, out fanSpeed);
            double.TryParse(txt_HeatOutput.Text, out heatOutput);

            //getting values for suggestion
            _InquiryLength = txt_Length.Text;
            _InquiryWidth = txt_Width.Text;
            _InquiryHeight = txt_Height.Text;
            _InquiryModel = cmb_ConvectorsModel.Text;
            StoreProcedure.UpdateData(changeInTemperature, fanSpeed);
            if (cmb_searchingCriteria.SelectedIndex == 0)
            {
                SearchEqual(dgv_Suggestion, _InquiryModel, length, width, height, heatOutput);
            }
            else if (cmb_searchingCriteria.SelectedIndex == 1)
            {
                SearchLessOrEqual(dgv_Suggestion, _InquiryModel, length, width, height, heatOutput);
            }
            else if (cmb_searchingCriteria.SelectedIndex == 3)
            {
            }


            //getting HeatOutput
            //double heatOutput = Search.GetRecord(cmb_ConvectorsModel.Text, length, width, height, changeInTemperature, fanSpeed);
            //MessageBox.Show(heatOutput.ToString());
            // getConvectors(DataGridView dataGridView, string Model, double width, double height,double heatOutput)
            //Fill DGV WITH SUGGESTIONS
            //                Convectors.getConvectors(dgv_Suggestion, cmb_ConvectorsModel.Text, width, height, heatOutput);

            //Saving Info Related To Data
            if (cmb_GrillsType.SelectedValue.ToString() == "2" || cmb_GrillsType.SelectedValue.ToString() == "3")
            {
                grillRequire = true;
                Grilletype = cmb_GrillsType.SelectedValue.ToString();
                GrillMaterail = getGrillMaterail(cmb_GrillsMaterialColor.Text);
            }
            else
            {
                grillRequire = false;
                Grilletype = "";
                GrillMaterail = "";
            }


        }
        #region SearchForEqualRecord
        public void SearchEqual(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            //1
            if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search1000(dataGridView, Model, Length);
            }
            //2
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search0100(dataGridView, Model, Width);
            }
            //3
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search0010(dataGridView, Model, Height);

            }
            //4
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search0001(dataGridView, Model, HeatOutput);

            }
            //5
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search1100(dataGridView, Model, Length, Width);

            }
            //6
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search1010(dataGridView, Model, Length, Height);
            }
            //7
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search1001(dataGridView, Model, Length, HeatOutput);
            }
            //8
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search0110(dataGridView, Model, Width, Height);
            }
            //9
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search0101(dataGridView, Model, Width, Height);
            }
            //10
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search0011(dataGridView, Model, Height, HeatOutput);
            }
            //11
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                EqualsSearch.Search1110(dataGridView, Model, Length, Width, Height);
            }
            //12
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search1011(dataGridView, Model, Length, Height, HeatOutput);
            }
            //13
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search0111(dataGridView, Model, Width, Height, HeatOutput);
            }
            //14
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                EqualsSearch.Search1111(dataGridView, Model, Length, Width, Height, HeatOutput);
            }
        }
        #endregion

        public void SearchLessOrEqual(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            //1
            if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search1000(dataGridView, Model, Length);
            }
            //2
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search0100(dataGridView, Model, Width);
            }
            //3
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search0010(dataGridView, Model, Height);

            }
            //4
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search0001(dataGridView, Model, HeatOutput);

            }
            //5
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search1100(dataGridView, Model, Length, Width);

            }
            //6
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search1010(dataGridView, Model, Length, Height);
            }
            //7
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search1001(dataGridView, Model, Length, HeatOutput);
            }
            //8
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search0110(dataGridView, Model, Width, Height);
            }
            //9
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search0101(dataGridView, Model, Width, Height);
            }
            //10
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search0011(dataGridView, Model, Height, HeatOutput);
            }
            //11
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                LessOrEqual.Search1110(dataGridView, Model, Length, Width, Height);
            }
            //12
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search1011(dataGridView, Model, Length, Height, HeatOutput);
            }
            //13
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search0111(dataGridView, Model, Width, Height, HeatOutput);
            }
            //14
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                LessOrEqual.Search1111(dataGridView, Model, Length, Width, Height, HeatOutput);
            }
        }




        public string getGrillMaterail(string grille)
        {
            var firstSpaceIndex = grille.IndexOf("\r");
            var firstString = grille.Substring(0, firstSpaceIndex);
            return firstString;
        }
        public void addGrillToDataGridView(DataGridView dataGridView)
        {
            if (dataGridView.RowCount >= 0)
            {
                string ID = dataGridView.Rows[0].Cells["ID1"].Value.ToString();
                string model = dataGridView.Rows[0].Cells["Model1"].Value.ToString();
                string length = dataGridView.Rows[0].Cells["Length1"].Value.ToString();
                string width = dataGridView.Rows[0].Cells["Width1"].Value.ToString();
                string height = dataGridView.Rows[0].Cells["Height1"].Value.ToString();
                string material = dataGridView.Rows[0].Cells["Material1"].Value.ToString();
                double price = 0;//must get from sql table
                dataGridView1.Rows.Add(ID, _InquiryLength, _InquiryWidth, _InquiryHeight, _InquiryModel, length, width, height, "", material, "", "", "0", price, "");
            }
        }
        private void dgv_Suggestion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                var senderGrid = (DataGridView)sender;
                int index = e.RowIndex;
                DataGridViewRow selectedrow = dgv_Suggestion.Rows[index];
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {

                    //getting required values for suggestions grid
                    int ID = int.Parse(selectedrow.Cells["ID"].Value.ToString());
                    string model = selectedrow.Cells["Model"].Value.ToString();
                    double length = double.Parse(selectedrow.Cells["Length"].Value.ToString());
                    double width = double.Parse(selectedrow.Cells["Width"].Value.ToString());
                    string height = selectedrow.Cells["Height"].Value.ToString();
                    string color = ""; // i think we should take this from sql 
                    string grilleMaterial = ""; // for convectors its not necessary 
                    string heatOutput = selectedrow.Cells["Heatoutput"].Value.ToString();
                    string CoolingCapacity = selectedrow.Cells["CoolingCapacity"].Value.ToString();
                    string Quantity = "0"; // selectedrow.Cells["Quantity"].Value.ToString();
                    double price = 0;
                    //adding rows to Offer
                    dataGridView1.Rows.Add(ID, _InquiryLength, _InquiryWidth, _InquiryHeight, _InquiryModel, length, width, height, color, grilleMaterial, heatOutput, CoolingCapacity, Quantity, price, "");

                    //adding grille to offer if needed
                    if (grillRequire == true)
                    {
                        if (Grille.checkGrille(ID))
                        {
                            if (Grilletype == "2")
                            {
                                Grille.getRollUpGrille(dgv_GrilleProducts, length, width, GrillMaterail);
                                addGrillToDataGridView(dgv_GrilleProducts);
                            }
                            else if (Grilletype == "3")
                            {
                                Grille.getLinearGrille(dgv_GrilleProducts, length, width, GrillMaterail);
                                addGrillToDataGridView(dgv_GrilleProducts);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            StoreProcedure.UpdateData(60, 0.6);
        }
    }
}
