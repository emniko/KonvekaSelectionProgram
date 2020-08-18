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
using SpreadsheetLight;
using GemBox.Spreadsheet;
using System.IO;

namespace KonekaSelectionProgram
{
    public partial class Form1 : Form
    {
        bool grillRequire = false;
        string Grilletype = "";
        string GrillMaterail = "";

        //for sugguestions 
        string _InquiryLength = "";
        string _InquiryWidth = "";
        string _InquiryHeight = "";
        string _InquiryModel = "";
        string _InquiryHeatOutput = "";
        string _InquiryCooling = "";


        int productCount = 1;

        public Form1()
        {
            InitializeComponent();
        }
        private string getPriceBase()
        {
            string pricebase = "";
            if (cmb_Pricebase.SelectedIndex == 0)
            {
                pricebase = "Min";
            }
            else if (cmb_Pricebase.SelectedIndex == 1)
            {
                pricebase = "Project";
            }
            else if (cmb_Pricebase.SelectedIndex == 2)
            {
                pricebase = "Neto";
            }
            return pricebase;
        }
        public double getFanSpeedValue()
        {
            if (cmb_HeatingFanSpeed.SelectedIndex == 0)
                return 5;//100
            else if (cmb_HeatingFanSpeed.SelectedIndex == 1)
                return 4;//80
            else if (cmb_HeatingFanSpeed.SelectedIndex == 2)
                return 3;//60
            else if (cmb_HeatingFanSpeed.SelectedIndex == 3)
                return 2;//4
            else if (cmb_HeatingFanSpeed.SelectedIndex == 4)
                return 1; //20
            else return 0;
        }
        private void AlignSuggestionGrid()
        {
            dgv_Suggestion.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["Model"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["Length"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["Width"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["Height"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["HeatOutput"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["HeatingDifferenceW"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["HeatingDifferencePercent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["CoolingCapacity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["CoolingDifferenceW"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["CoolingDifferencePercent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Suggestion.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Suggestion.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void AlignOfferGrid()
        {
            dgv_OfferTable.Columns["ID2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["InLength"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["InWidth"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["Height3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["InHeatOutput"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["CoolingCapacityI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["SuModel"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_OfferTable.Columns["Name"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_OfferTable.Columns["SuLength"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["Width2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["Height2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["Color"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["GrilleMaterial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["SuHeatOutput"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["SuCoolingCapacity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["Qualntity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_OfferTable.Columns["Price1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_OfferTable.Columns["TotalEuro1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }
        private void calculateHeatingDifference()
        {
            if (txt_HeatOutput.Text != "")
            {
                double heatOutput = -1;
                double givenHeatOutput = 0;
                double difference = 0;
                double percentage = 0;
                double.TryParse(txt_HeatOutput.Text, out givenHeatOutput);
                for (int i = 0; i < dgv_Suggestion.RowCount; i++)
                {
                    //calculate difference 
                    string heatOUTPUT = dgv_Suggestion.Rows[i].Cells["HeatOutput"].Value.ToString();
                    double.TryParse(heatOUTPUT, out heatOutput);
                    difference = givenHeatOutput - heatOutput;
                    difference = Math.Abs(difference);
                    dgv_Suggestion.Rows[i].Cells["HeatingDifferenceW"].Value = difference;

                    //calculate percentage
                    double average = givenHeatOutput + heatOutput;
                    average = average / 2;
                    average = difference / average;
                    percentage = average * 100;
                    percentage = Math.Round(percentage, 0);
                    dgv_Suggestion.Rows[i].Cells["HeatingDifferencePercent"].Value = percentage;
                }
            }
        }
        private void calculateCoolingDifference()
        {
            if (txt_CoolingCapacity.Text != "")
            {
                double heatOutput = -1;
                double givenHeatOutput = 0;
                double difference = 0;
                double percentage = 0;
                double.TryParse(txt_CoolingCapacity.Text, out givenHeatOutput);
                for (int i = 0; i < dgv_Suggestion.RowCount; i++)
                {
                    //calculate difference 
                    string heatOUTPUT = dgv_Suggestion.Rows[i].Cells["CoolingCapacity"].Value.ToString();
                    double.TryParse(heatOUTPUT, out heatOutput);
                    difference = givenHeatOutput - heatOutput;
                    difference = Math.Abs(difference);
                    dgv_Suggestion.Rows[i].Cells["CoolingDifferenceW"].Value = difference;
                    //calculate percentage
                    double average = givenHeatOutput + heatOutput;
                    average = average / 2;
                    average = difference / average;
                    percentage = average * 100;
                    percentage = Math.Round(percentage, 0);
                    dgv_Suggestion.Rows[i].Cells["CoolingDifferencePercent"].Value = percentage;
                }
            }
        }
        private void CalculateDifference()
        {
            if (rd_Heating.Checked == true)
            {
                calculateHeatingDifference();
            }
            else
            {
                calculateCoolingDifference();
            }
        }
        private void UpdatePriceInOfferTable()
        {
            string pricebase = getPriceBase();
            double price = 0;
            for (int i = 0; i < dgv_OfferTable.RowCount; i++)
            {
                string SearchType = dgv_OfferTable.Rows[i].Cells["SearchType"].Value.ToString();
                string ID = dgv_OfferTable.Rows[i].Cells["SearchID"].Value.ToString();
                if (SearchType == "C")
                {
                    price = double.Parse(SQL.ScalarQuery("select " + pricebase + " from Convectors where ID = " + ID + ""));

                }
                else if (SearchType == "G")
                {
                    price = double.Parse(SQL.ScalarQuery("select " + pricebase + " from GrilleProducts where ID  = " + ID + ""));

                }
                else if (SearchType == "A")
                {
                    price = double.Parse(SQL.ScalarQuery("select " + pricebase + " from Accessories where ID = " + ID + ""));

                }
                price = Math.Round(price, 2);
                dgv_OfferTable.Rows[i].Cells["Price1"].Value = price;
            }

        }
        private double getGrandTotal()
        {
            double grandTotal = 0;

            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    double total = 0;
                    double.TryParse(dgv_OfferTable.Rows[i].Cells["TotalEuro1"].Value.ToString(), out total);
                    grandTotal += total;
                }
            }
            catch (Exception)
            {
            }
            return grandTotal;

        }
        private void GenerateDiscount(double value)
        {
            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    double total = 0;
                    double discount = 0;
                    if (double.TryParse(dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString(), out total))
                    {
                        discount = total * (value / 100);
                        total = total - discount;
                        total = Math.Round(total, 2);
                        dgv_OfferTable.Rows[i].Cells["Price1"].Value = total.ToString("#.00");
                    }

                }
            }
            catch (Exception)
            {
            }
        }
        private void GenerateCorrection(double value)
        {
            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    double total = 0;
                    double correction = 0;
                    if (double.TryParse(dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString(), out total))
                    {
                        correction = total * (value / 100);
                        total = total + correction;
                        total = Math.Round(total, 2);
                        dgv_OfferTable.Rows[i].Cells["Price1"].Value = total.ToString("#.00");
                    }

                }
            }
            catch (Exception)
            {
            }
        }
        private double Get9016Quantity()
        {
            double TotalQuantity = 0;

            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    double quantity = 0;
                    double.TryParse(dgv_OfferTable.Rows[i].Cells["Qualntity"].Value.ToString(), out quantity);

                    if (dgv_OfferTable.Rows[i].Cells["Color"].Value.ToString() != "9016")
                    {
                        TotalQuantity += quantity;
                    }
                }
                return TotalQuantity;
            }
            catch (Exception)
            {
                return TotalQuantity;
            }
            finally
            {
            }
        }
        private void AddtionalPriceBasedOnColor()
        {
            try
            {
                if (Get9016Quantity() < 30)
                {

                    for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                    {
                        double total = 0;
                        double correction = 0;
                        double value = 30; // increase percentage value
                        double quantity = 0;
                        double.TryParse(dgv_OfferTable.Rows[i].Cells["Qualntity"].Value.ToString(), out quantity);

                        if (dgv_OfferTable.Rows[i].Cells["Color"].Value.ToString() != "9016")
                        {
                            if (double.TryParse(dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString(), out total))
                            {
                                correction = total * (value / 100);
                                total = total + correction;
                                total = Math.Round(total, 2);
                                dgv_OfferTable.Rows[i].Cells["Price1"].Value = total.ToString("#.00");
                            }
                        }
                    }
                }
                calculateTotal();
            }
            catch (Exception)
            {
            }
        }
        private void generateNumber()
        {

            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    dgv_OfferTable.Rows[i].Cells["ID2"].Value = i + 1;
                }
            }
            catch (Exception)
            {
            }
        }

        private void calculateTotal()
        {
            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    double quantity = double.Parse(dgv_OfferTable.Rows[i].Cells["Qualntity"].Value.ToString());
                    double price = double.Parse(dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString());
                    double total = quantity * price;
                    total = Math.Round(total, 2);
                    dgv_OfferTable.Rows[i].Cells["TotalEuro1"].Value = total.ToString("#.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void getName()
        {
            try
            {
                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    string SearchType = dgv_OfferTable.Rows[i].Cells["SearchType"].Value.ToString();
                    if (SearchType == "C")
                    {
                        string ID = dgv_OfferTable.Rows[i].Cells["SearchID"].Value.ToString();
                        string name = SQL.ScalarQuery("select Name from convectors where ID  = " + ID + "");
                        dgv_OfferTable.Rows[i].Cells["Name"].Value = name;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updatePricesInSuggestionGrid()
        {
            try
            {
                string pricebase = getPriceBase();
                for (int i = 0; i < dgv_Suggestion.RowCount; i++)
                {
                    string ID = dgv_Suggestion.Rows[i].Cells["ID"].Value.ToString();
                    double price = double.Parse(SQL.ScalarQuery("select " + pricebase + " from Convectors	where ID = " + ID + ""));
                    dgv_Suggestion.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                }
            }
            catch (Exception)
            {

            }

        }
        private void enable_disableFanSpeed(string text)
        {
            if (text.Contains("with fans"))
            {
                cmb_HeatingFanSpeed.Enabled = true;
            }
            else cmb_HeatingFanSpeed.Enabled = false;
        }
        private void enable_disableCooling(string text)
        {
            if (text.Contains("FCH"))
            {
                txt_CoolingCapacity.Enabled = true;
            }
            else txt_CoolingCapacity.Enabled = false;
        }
        private void lockApplication()
        {
            DateTime StartDate = new DateTime(2020, 08, 10);
            DateTime EndDate = DateTime.Now;
            
            int days = (EndDate.Date - StartDate.Date).Days;
            // MessageBox.Show(days.ToString());
            if (days > 30)
            {
                MessageBox.Show("Software has encountered an unexpected error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        private void cmb_ConvectorsType_Load(object sender, EventArgs e)
        {
            lockApplication();
            cmb_Pricebase.SelectedIndex = 0;
            cmb_HeatingFanSpeed.SelectedIndex = 0;
            cmb_HeatingFanSpeed.SelectedIndex = 2;
            this.WindowState = FormWindowState.Maximized;

            //installation type
            Main.fillComboWithoutCondition(cmb_ConvectorsInstallationType, "InstallationType", "IntallationType", "IntallationTypeID");
            //accessories
            Main.fillComboWithoutCondition(cmb_Accessory, "Accessories", "Name", "ID");
            //Grilles Types
            Main.fillComboWithoutCondition(cmb_GrillsType, "GrillType", "Type", "ID");

            dgv_Suggestion.AllowUserToOrderColumns = false;

            changeInTemeratureForHeating();
            changeInTemeratureForCooling();
            AlignSuggestionGrid();
            AlignOfferGrid();

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
                txt_Color.Enabled = true;

            }
            else
            {
                txt_Color.Clear();
                txt_Color.Enabled = false;
            }
            //enable / disable fanspeed
            enable_disableFanSpeed(cmb_Type.Text);
            enable_disableCooling(cmb_ConvectorsModel.Text);

        }
        private void cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Model : Depends Upon Type
            cmb_ConvectorsModel.Text = "";
            Main.fillCombo(cmb_ConvectorsModel, "Model", "ModelName", "ModelID", "TypeID =" + cmb_Type.SelectedValue + "");
            enable_disableFanSpeed(cmb_Type.Text);
            enable_disableCooling(cmb_ConvectorsModel.Text);

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
            changeInTemeratureForHeating();

        }
        private void txt_Outgoing_Heating_TextChanged(object sender, EventArgs e)
        {
            changeInTemeratureForHeating();

        }

        private void txt_Room_Heating_TextChanged(object sender, EventArgs e)
        {
            changeInTemeratureForHeating();

        }
        //calculating change in temperature 
        private bool changeInTemeratureForHeating()
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
        private bool changeInTemeratureForCooling()
        {
            double IncommingTemp = 0, OutgoingTemp = 0, RoomTeamperature = 0, ChangeInTemperature = 0;
            bool val = false;
            if (double.TryParse(txt_Incoming_Cooling.Text, out IncommingTemp))
            {
                if (double.TryParse(txt_Outgoing_Cooling.Text, out OutgoingTemp))
                {
                    if (double.TryParse(txt_Room_Cooling.Text, out RoomTeamperature))
                    {
                        ChangeInTemperature = (IncommingTemp + OutgoingTemp) / 2 - RoomTeamperature;
                        ChangeInTemperature = Math.Abs(ChangeInTemperature);
                        txt_DeltaT_Cooling.Text = ChangeInTemperature.ToString();
                        val = true;
                    }
                }
            }
            return val;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (cmb_Pricebase.SelectedIndex < 0)
            {
                MessageBox.Show("Select Price Base First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //GetRecord(string model, double lenght, double width, double height, double changeInTemperature, double fanSpeed)
                double length = 0, width = 0, height = 0, heatOutput = 0, CoolingCapacity = 0, changeInTemperature = 0, changeInTemperatureCooling = 0, fanSpeed = 0;
                double.TryParse(txt_Length.Text, out length);
                double.TryParse(txt_Width.Text, out width);
                double.TryParse(txt_Height.Text, out height);
                double.TryParse(txt_HeatingChangeInTemperature.Text, out changeInTemperature);
                double.TryParse(txt_DeltaT_Cooling.Text, out changeInTemperatureCooling);

                // double.TryParse(cmb_HeatingFanSpeed.Text, out fanSpeed);
                fanSpeed = getFanSpeedValue();
                double.TryParse(txt_HeatOutput.Text, out heatOutput);
                double.TryParse(txt_CoolingCapacity.Text, out CoolingCapacity);

                //getting values for suggestion
                _InquiryLength = txt_Length.Text;
                _InquiryWidth = txt_Width.Text;
                _InquiryHeight = txt_Height.Text;
                _InquiryModel = cmb_ConvectorsModel.Text;
                _InquiryHeatOutput = txt_HeatOutput.Text;
                _InquiryCooling = txt_CoolingCapacity.Text;

                if (rd_Heating.Checked == true)
                {
                    StoreProcedure.UpdateData(changeInTemperature, fanSpeed);
                    SearchHeating(dgv_Suggestion, _InquiryModel, length, width, height, heatOutput);


                }
                else
                {
                    StoreProcedure.UpdateData(changeInTemperatureCooling, fanSpeed);
                    SearchCooling(dgv_Suggestion, _InquiryModel, length, width, height, CoolingCapacity);

                }
                CalculateDifference();
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

                //add prices to the grid 
                updatePricesInSuggestionGrid();
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
        public void SearchHeating(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            SQL.NonScalarQuery("update Convectors set CoolingCapacity = NULL");

            //1
            if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " order by HeatOutput asc");
            }
            //2
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Width <= " + Width + " order by HeatOutput asc");

            }
            //3
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Height <= " + Height + " order by HeatOutput asc");

            }
            //4
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and HeatOutput >= " + HeatOutput + " order by HeatOutput asc");
            }
            //5
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Width <= " + Width + "  order by HeatOutput asc");
            }
            //6
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Height <= " + Height + "  order by HeatOutput asc");
            }
            //7
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <= " + Length + " and HeatOutput >= " + HeatOutput + "  order by HeatOutput asc");
            }
            //8
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Width <= " + Width + " and Height <= " + Height + "  order by HeatOutput asc");
            }
            //9
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Width <= " + Width + " and HeatOutput >= " + HeatOutput + "  order by HeatOutput asc");
            }
            //10
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Height <= " + Height + " and HeatOutput >= " + HeatOutput + "  order by HeatOutput asc");
            }
            //11
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Width <= " + Width + "  and Height <=" + Height + " order by HeatOutput asc");

            }
            //12
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Height <= " + Height + "  and HeatOutput >=" + HeatOutput + " order by HeatOutput asc");
            }
            //13
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Width <= " + Width + " and Height <= " + Height + "  and HeatOutput >=" + HeatOutput + " order by HeatOutput asc");

            }
            //14
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <=" + Length + " and Width <= " + Width + " and Height <= " + Height + " and HeatOutput >=" + HeatOutput + " order by HeatOutput asc");
            }
            //15 Length,Width,HEatoutput
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_HeatOutput.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,ABS(round(HeatOutput,0)) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity  from Convectors where model  = '" + Model + "' and Length <=" + Length + " and Width <= " + Width + "  and HeatOutput >=" + HeatOutput + " order by HeatOutput asc");
            }
        }


        public void SearchCooling(DataGridView dataGridView, string Model, double Length, double Width, double Height, double HeatOutput)
        {
            SQL.NonScalarQuery("update Convectors set HeatOutput = NULL");


            //1
            if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " and ID between 1009 and 1028  order by CoolingCapacity asc");

            }
            //2
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Width <= " + Width + " and ID between 1009 and 1028  order by CoolingCapacity asc");

            }
            //3
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Height <= " + Height + " and ID between 1009 and 1028  order by CoolingCapacity asc");

            }
            //4
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and CoolingCapacity >= " + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //5
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Width <= " + Width + "and ID between 1009 and 1028   order by CoolingCapacity asc");
            }
            //6
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Height <= " + Height + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //7
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text == "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " and CoolingCapacity >= " + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //8
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Width <= " + Width + " and Height <= " + Height + " and ID between 1009 and 1028   order by CoolingCapacity asc");
            }
            //9
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Width <= " + Width + " and CoolingCapacity >= " + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //10
            else if (txt_Length.Text == "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Height <= " + Height + " and CoolingCapacity >= " + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //11
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_CoolingCapacity.Text == "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Width <= " + Width + "  and Height <=" + Height + " and ID between 1009 and 1028  order by CoolingCapacity asc");

            }
            //12
            else if (txt_Length.Text != "" && txt_Width.Text == "" && txt_Height.Text != "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <= " + Length + " and Height <= " + Height + "  and CoolingCapacity >=" + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //13
            else if (txt_Length.Text == "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Width <= " + Width + " and Height <= " + Height + "  and CoolingCapacity >=" + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");

            }
            //14
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text != "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <=" + Length + " and Width <= " + Width + " and Height <= " + Height + " and CoolingCapacity >=" + HeatOutput + " and ID between 1009 and 1028  order by CoolingCapacity asc");
            }
            //15 Length,Width,HEatoutput
            else if (txt_Length.Text != "" && txt_Width.Text != "" && txt_Height.Text == "" && txt_CoolingCapacity.Text != "")
            {
                Main.fillDgv(dataGridView, "select ID,Model,Length,Width,Height,round(HeatOutput,0) as HeatOutput,round(CoolingCapacity,0) as CoolingCapacity from Convectors where model  = '" + Model + "' and Length <=" + Length + " and Width <= " + Width + "  and HeatOutput >=" + HeatOutput + " and ID between 1009 and 1028   order by CoolingCapacity asc");
            }
        }

        public string getGrillMaterail(string grille)
        {
            var firstSpaceIndex = grille.IndexOf("\r");
            var firstString = grille.Substring(0, firstSpaceIndex);
            return firstString;
        }
        public void addGrillToDataGridView(DataGridView dataGridView, string Model, string Quantity)
        {
            if (dataGridView.RowCount >= 0)
            {
                string ID = dataGridView.Rows[0].Cells["ID1"].Value.ToString();
                string model = dataGridView.Rows[0].Cells["Model1"].Value.ToString();
                string name = dataGridView.Rows[0].Cells["Name1"].Value.ToString();
                string length = dataGridView.Rows[0].Cells["Length1"].Value.ToString();
                string width = dataGridView.Rows[0].Cells["Width1"].Value.ToString();
                string height = dataGridView.Rows[0].Cells["Height1"].Value.ToString();
                string material = dataGridView.Rows[0].Cells["Material1"].Value.ToString();
                double price = double.Parse(SQL.ScalarQuery("select " + getPriceBase() + " from GrilleProducts where ID  = " + ID + ""));
                dgv_OfferTable.Rows.Add(productCount, _InquiryLength, _InquiryWidth, _InquiryHeight, _InquiryHeatOutput, _InquiryCooling, name, Model, length, width, height, "", material, "", "", Quantity, price, "", ID, "G");
                productCount++;
            }
        }
        private void dgv_Suggestion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CalculateDifference();

                var senderGrid = (DataGridView)sender;
                int index = e.RowIndex;
                DataGridViewRow selectedrow = dgv_Suggestion.Rows[index];
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    double heatOutput = 0, coolingCapacity = 0;
                    //getting required values for suggestions grid
                    int ID = int.Parse(selectedrow.Cells["ID"].Value.ToString());
                    string model = selectedrow.Cells["Model"].Value.ToString();
                    double length = double.Parse(selectedrow.Cells["Length"].Value.ToString());
                    double width = double.Parse(selectedrow.Cells["Width"].Value.ToString());
                    string height = selectedrow.Cells["Height"].Value.ToString();
                    string color = txt_Color.Text;// ""; // i think we should take this from sql 
                    string grilleMaterial = ""; // for convectors its not necessary 
                    double.TryParse(selectedrow.Cells["Heatoutput"].Value.ToString(), out heatOutput);
                    double.TryParse(selectedrow.Cells["CoolingCapacity"].Value.ToString(), out coolingCapacity);

                    string Quantity = selectedrow.Cells["Quantity"].Value.ToString();
                    double price = double.Parse(selectedrow.Cells["Price"].Value.ToString());
                    //adding rows to Offer
                    dgv_OfferTable.Rows.Add(productCount, _InquiryLength, _InquiryWidth, _InquiryHeight, _InquiryHeatOutput, _InquiryCooling, "", model, length, width, height, color, grilleMaterial, heatOutput, coolingCapacity, Quantity, price, "", ID, "C");
                    productCount++;
                    //checking grille requirement agian 
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
                    //adding grille to offer if needed
                    if (grillRequire == true)
                    {
                        if (Grille.checkGrille(ID))
                        {
                            if (Grilletype == "2")
                            {
                                Grille.getRollUpGrille(dgv_GrilleProducts, length, width, GrillMaterail);
                                addGrillToDataGridView(dgv_GrilleProducts, "GR", Quantity);
                            }
                            else if (Grilletype == "3")
                            {
                                Grille.getLinearGrille(dgv_GrilleProducts, length, width, GrillMaterail);
                                addGrillToDataGridView(dgv_GrilleProducts, "GR-L", Quantity);
                            }
                        }
                    }
                    CalculateDifference();
                    calculateTotal();
                    getName();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Please Enter Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CalculateDifference();
                calculateTotal();
                updatePricesInSuggestionGrid();
                getName();
                generateNumber();
                CheckCorrectionAndDiscount();
                AddtionalPriceBasedOnColor();
                txt_GrandTotal.Text = getGrandTotal().ToString("#.00");

            }
        }

        private void btn_AddAccessory_Click(object sender, EventArgs e)
        {
            //check pricebase 
            string pricebase = getPriceBase();
            if (pricebase == "")
            {
                MessageBox.Show("Select Price Base First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            else if (cmb_Accessory.SelectedIndex < 0)
            {
                MessageBox.Show("Select Accessory First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txt_AccessoryQuantity.Text == "")
            {
                MessageBox.Show("Enter Accessory Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string accessory = cmb_Accessory.Text;
                string price = SQL.ScalarQuery("select " + pricebase + " from Accessories where ID = " + cmb_Accessory.SelectedValue + "");
                string ID = cmb_Accessory.SelectedValue.ToString();
                string weight = SQL.ScalarQuery("select weight from Accessories where ID = " + cmb_Accessory.SelectedValue + "");
                string quantity = txt_AccessoryQuantity.Text;
                //adding rows to Offer
                dgv_OfferTable.Rows.Add("", "", "", "", "", "", accessory, "", "", "", "", "", "", "", "", quantity, price, "", ID, "A");
                calculateTotal();
                generateNumber();
            }

        }

        private void cmb_Pricebase_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePricesInSuggestionGrid();
            UpdatePriceInOfferTable();
            calculateTotal();
            CheckCorrectionAndDiscount();
            AddtionalPriceBasedOnColor();
            txt_GrandTotal.Text = getGrandTotal().ToString("#.00");

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {

        }

        private void btn_ProgramData_Click(object sender, EventArgs e)
        {
            var frm = new frm_ProjectData();
            frm.ShowDialog();
        }

        private void dgv_OfferTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.ColumnIndex == dgv_OfferTable.Columns["Delete"].Index && index >= 0)
            {
                int count = dgv_OfferTable.RowCount;
                if (index < count)
                {
                    dgv_OfferTable.Rows.RemoveAt(index);
                    generateNumber();
                    updatePricesInSuggestionGrid();
                    UpdatePriceInOfferTable();
                    calculateTotal();
                    CheckCorrectionAndDiscount();
                    AddtionalPriceBasedOnColor();
                    txt_GrandTotal.Text = getGrandTotal().ToString("#.00");

                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            int count = 20;
            int no = 1;
            using (SLDocument sl = new SLDocument(Application.StartupPath + "\\template.xlsx"))
            {
                //basic information 
                //  sl.SetCellValue("O9", "Date: " + DateTime.Now.ToShortDateString());
                sl.SetCellValue("O9", "Date: " + ProjectData.Date);
                double grandTotal = getGrandTotal();
                sl.SetCellValue("AD14", grandTotal);
                sl.SetCellValue("P8", ProjectData.OrderNo);
                sl.SetCellValue("C12", ProjectData.Customer);
                sl.SetCellValue("C13", ProjectData.ContactPerson);
                sl.SetCellValue("C14", ProjectData.Project);


                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    //Inquiry
                    double lnLength = (dgv_OfferTable.Rows[i].Cells["InLength"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["InLength"].Value) : 0;
                    double lnWidth = (dgv_OfferTable.Rows[i].Cells["InWidth"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["InWidth"].Value) : 0;
                    double lnHeight = (dgv_OfferTable.Rows[i].Cells["Height3"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["Height3"].Value) : 0;
                    double lnHeatOutput = (dgv_OfferTable.Rows[i].Cells["InHeatOutput"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["InHeatOutput"].Value) : 0;
                    double lnCooling = (dgv_OfferTable.Rows[i].Cells["CoolingCapacityI"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["CoolingCapacityI"].Value) : 0;
                    if (lnLength != 0)
                    {
                        sl.SetCellValue("B" + count, lnLength);
                    }
                    if (lnWidth != 0)
                    {
                        sl.SetCellValue("C" + count, lnWidth);
                    }
                    if (lnHeight != 0)
                    {
                        sl.SetCellValue("D" + count, lnHeight);
                    }
                    if (lnHeatOutput != 0)
                    {
                        sl.SetCellValue("E" + count, lnHeatOutput);
                    }
                    if (lnCooling != 0)
                    {
                        sl.SetCellValue("I" + count, lnCooling);
                    }

                    //suggestions

                    string SuName = dgv_OfferTable.Rows[i].Cells["Name"].Value.ToString();
                    string SuModel = dgv_OfferTable.Rows[i].Cells["SuModel"].Value.ToString();
                    double SuLength = (dgv_OfferTable.Rows[i].Cells["SuLength"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["SuLength"].Value) : 0;
                    double SuWidth = (dgv_OfferTable.Rows[i].Cells["Width2"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["Width2"].Value) : 0;
                    //double SuHeight = (dgv_OfferTable.Rows[i].Cells["Height2"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["Height2"].Value) : 0;
                    string SuHeight = dgv_OfferTable.Rows[i].Cells["Height2"].Value.ToString();
                    string SuColor = dgv_OfferTable.Rows[i].Cells["Color"].Value.ToString();
                    double SuHeatoutput = (dgv_OfferTable.Rows[i].Cells["SuHeatOutput"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["SuHeatOutput"].Value) : 0;
                    double SuCooling = (dgv_OfferTable.Rows[i].Cells["SuCoolingCapacity"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["SuCoolingCapacity"].Value) : 0;
                    double SuQuantity = (dgv_OfferTable.Rows[i].Cells["Qualntity"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["Qualntity"].Value) : 0;
                    double SuPrice = (dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["Price1"].Value) : 0;
                    double SuTotal = (dgv_OfferTable.Rows[i].Cells["TotalEuro1"].Value.ToString() != "") ? Convert.ToDouble(dgv_OfferTable.Rows[i].Cells["TotalEuro1"].Value) : 0;


                    sl.SetCellValue("M" + count, no);
                    sl.SetCellValue("N" + count, SuName);
                    sl.SetCellValue("O" + count, SuModel);

                    if (SuLength != 0)
                    {
                        sl.SetCellValue("P" + count, SuLength);
                    }
                    if (SuWidth != 0)
                    {
                        sl.SetCellValue("Q" + count, SuWidth);
                    }
                    //   if (SuHeight != 0)
                    // {
                    sl.SetCellValue("R" + count, SuHeight);
                    // }
                    if (IsAllDigits(SuColor) && SuColor != "")
                    {
                        sl.SetCellValue("S" + count, Convert.ToDouble(SuColor));
                    }
                    else
                    {
                        sl.SetCellValue("S" + count, SuColor);
                    }
                    if (SuHeatoutput != 0)
                    {
                        sl.SetCellValue("T" + count, SuHeatoutput);
                    }
                    if (SuCooling != 0)
                    {
                        sl.SetCellValue("X" + count, SuCooling);
                    }
                    if (SuQuantity != 0)
                    {
                        sl.SetCellValue("AB" + count, SuQuantity);
                    }
                    if (SuPrice != 0)
                    {
                        sl.SetCellValue("AC" + count, SuPrice);
                    }
                    if (SuTotal != 0)
                    {
                        sl.SetCellValue("AD" + count, SuTotal);
                    }

                    count++;
                    no++;
                }

                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel files (.xlsx)|.xlsx";
                saveDlg.FilterIndex = 0;
                saveDlg.RestoreDirectory = true;
                saveDlg.Title = "Export Excel File To";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        string path = saveDlg.FileName;
                        sl.SaveAs(path);
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        File.Delete("temp.xlsx");
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        bool IsAllDigits(string s) => s.All(char.IsDigit);

        private void btn_Print_Click(object sender, EventArgs e)
        {
            int count = 20;
            int no = 1;
            using (SLDocument sl = new SLDocument(Application.StartupPath + "\\template.xlsx"))
            {
                sl.SetCellValue("O9", "Date: " + ProjectData.Date);
                string grandTotal = getGrandTotal().ToString();
                sl.SetCellValue("AD14", grandTotal);
                sl.SetCellValue("P8", ProjectData.OrderNo);
                sl.SetCellValue("C12", ProjectData.Customer);
                sl.SetCellValue("C13", ProjectData.ContactPerson);
                sl.SetCellValue("C14", ProjectData.Project);


                for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                {
                    //Inquiry
                    string lnLength = dgv_OfferTable.Rows[i].Cells["InLength"].Value.ToString();
                    string lnWidth = dgv_OfferTable.Rows[i].Cells["InWidth"].Value.ToString();
                    string lnHeight = dgv_OfferTable.Rows[i].Cells["Height3"].Value.ToString();
                    string lnHeatOutput = dgv_OfferTable.Rows[i].Cells["InHeatOutput"].Value.ToString();
                    string lnCooling = dgv_OfferTable.Rows[i].Cells["CoolingCapacityI"].Value.ToString();
                    sl.SetCellValue("B" + count, lnLength);
                    sl.SetCellValue("C" + count, lnWidth);
                    sl.SetCellValue("D" + count, lnHeight);
                    sl.SetCellValue("E" + count, lnHeatOutput);
                    sl.SetCellValue("I" + count, lnCooling);

                    //suggestions

                    string SuName = dgv_OfferTable.Rows[i].Cells["Name"].Value.ToString();
                    string SuModel = dgv_OfferTable.Rows[i].Cells["SuModel"].Value.ToString();
                    string SuLength = dgv_OfferTable.Rows[i].Cells["SuLength"].Value.ToString();
                    string SuWidth = dgv_OfferTable.Rows[i].Cells["Width2"].Value.ToString();
                    string SuHeight = dgv_OfferTable.Rows[i].Cells["Height2"].Value.ToString();
                    string SuColor = dgv_OfferTable.Rows[i].Cells["Color"].Value.ToString();
                    string SuHeatoutput = dgv_OfferTable.Rows[i].Cells["SuHeatOutput"].Value.ToString();
                    string SuCooling = dgv_OfferTable.Rows[i].Cells["SuCoolingCapacity"].Value.ToString();
                    string SuQuantity = dgv_OfferTable.Rows[i].Cells["Qualntity"].Value.ToString();
                    string SuPrice = dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString();
                    string SuTotal = dgv_OfferTable.Rows[i].Cells["TotalEuro1"].Value.ToString();

                    sl.SetCellValue("M" + count, no);
                    sl.SetCellValue("N" + count, SuName);
                    sl.SetCellValue("O" + count, SuModel);
                    sl.SetCellValue("P" + count, SuLength);
                    sl.SetCellValue("Q" + count, SuWidth);
                    sl.SetCellValue("R" + count, SuHeight);
                    sl.SetCellValue("S" + count, SuColor);
                    sl.SetCellValue("T" + count, SuHeatoutput);
                    sl.SetCellValue("X" + count, SuCooling);
                    sl.SetCellValue("AB" + count, SuQuantity);
                    sl.SetCellValue("AC" + count, SuPrice);
                    sl.SetCellValue("AD" + count, SuTotal);

                    count++;
                    no++;
                }

                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "PDF(*.pdf)|*.pdf";
                saveDlg.FilterIndex = 0;
                saveDlg.RestoreDirectory = true;
                saveDlg.Title = "Export as PDF";

                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        string path = saveDlg.FileName;
                        sl.SaveAs("temp.xlsx");
                        SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
                        var workbook = ExcelFile.Load("temp.xlsx");

                        foreach (var worksheet in workbook.Worksheets)
                        {
                            var printOptions = worksheet.PrintOptions;
                            printOptions.Portrait = false;
                            printOptions.PaperType = PaperType.A4;
                            worksheet.PrintOptions.FitWorksheetWidthToPages = 1;
                            worksheet.PrintOptions.FitWorksheetHeightToPages = 1;
                            worksheet.ViewOptions.Zoom = 200;
                        }

                        var saveOptions = new PdfSaveOptions();
                        saveOptions.SelectionType = SelectionType.EntireFile;
                        workbook.Save(path, saveOptions);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    finally
                    {
                        File.Delete("temp.xlsx");
                        Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void txt_AccessoryQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            Main.OnlyDigits(e);
        }

        private void btn_SaveAs_Click(object sender, EventArgs e)
        {
        }
        private void label13_Click(object sender, EventArgs e)
        {
        }
        private void txt_Incoming_Cooling_TextChanged(object sender, EventArgs e)
        {
            changeInTemeratureForCooling();
        }
        private void txt_Outgoing_Cooling_TextChanged(object sender, EventArgs e)
        {
            changeInTemeratureForCooling();
        }
        private void txt_Room_Cooling_TextChanged(object sender, EventArgs e)
        {
            changeInTemeratureForCooling();
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Konveka(*.konveka)|*.konveka";
            openFile.FilterIndex = 0;
            openFile.RestoreDirectory = true;
            openFile.Title = "OPNE FILE";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;

                string[] csv_data = File.ReadAllLines(path);
                dgv_OfferTable.Rows.Clear();
                for (int i = 0; i < csv_data.Length; i++)
                {
                    string[] line = csv_data[i].Split(',');
                    dgv_OfferTable.Rows.Add(line[0], line[1], line[2], line[3], line[4], line[5], line[6], line[7], line[8], line[9], line[10], line[11], line[12], line[13], line[14], line[15], line[16], line[17]);
                }
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Konveka(*.konveka)|*.konveka";
            saveDlg.FilterIndex = 0;
            saveDlg.RestoreDirectory = true;
            saveDlg.Title = "SAVE FILE";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    string path = saveDlg.FileName;
                    //saving data to file 
                    File.WriteAllBytes(path, new byte[] { 0 });
                    using (StreamWriter sw = File.AppendText(path))
                    {

                        for (int i = 0; i < dgv_OfferTable.RowCount; i++)
                        {
                            //Inquiry
                            string lnLength = dgv_OfferTable.Rows[i].Cells["InLength"].Value.ToString();
                            string lnWidth = dgv_OfferTable.Rows[i].Cells["InWidth"].Value.ToString();
                            string lnHeight = dgv_OfferTable.Rows[i].Cells["Height3"].Value.ToString();
                            string lnHeatOutput = dgv_OfferTable.Rows[i].Cells["InHeatOutput"].Value.ToString();
                            string lnCooling = dgv_OfferTable.Rows[i].Cells["CoolingCapacityI"].Value.ToString();

                            //suggestions

                            string SuName = dgv_OfferTable.Rows[i].Cells["Name"].Value.ToString();
                            string SuModel = dgv_OfferTable.Rows[i].Cells["SuModel"].Value.ToString();
                            string SuLength = dgv_OfferTable.Rows[i].Cells["SuLength"].Value.ToString();
                            string SuWidth = dgv_OfferTable.Rows[i].Cells["Width2"].Value.ToString();
                            string SuHeight = dgv_OfferTable.Rows[i].Cells["Height2"].Value.ToString();
                            string SuColor = dgv_OfferTable.Rows[i].Cells["Color"].Value.ToString();
                            string SuMaterail = dgv_OfferTable.Rows[i].Cells["GrilleMaterial"].Value.ToString();
                            string SuHeatoutput = dgv_OfferTable.Rows[i].Cells["SuHeatOutput"].Value.ToString();
                            string SuCooling = dgv_OfferTable.Rows[i].Cells["SuCoolingCapacity"].Value.ToString();
                            string SuQuantity = dgv_OfferTable.Rows[i].Cells["Qualntity"].Value.ToString();
                            string SuPrice = dgv_OfferTable.Rows[i].Cells["Price1"].Value.ToString();
                            string SuTotal = dgv_OfferTable.Rows[i].Cells["TotalEuro1"].Value.ToString();

                            int count = i + 1;
                            sw.WriteLine(count + "," + lnLength + "," + lnWidth + "," + lnHeight + "," + lnHeatOutput + "," + lnCooling + "," + SuName + "," + SuModel + "," + SuLength + "," + SuWidth + "," + SuHeight + "," + SuColor + "," + SuMaterail + "," + SuHeatoutput + "," + SuCooling + "," + SuQuantity + "," + SuPrice + "," + SuTotal);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    Cursor = Cursors.Default;
                }
            }

        }
        private void clearForm()
        {
            //intail data 
            txt_HeatOutput.Clear();
            txt_CoolingCapacity.Clear();
            txt_Length.Clear();
            txt_Width.Clear();
            txt_Height.Clear();
            // suggestions 
            dgv_Suggestion.DataSource = null;
            //offer table 
            dgv_OfferTable.Rows.Clear();
        }
        private void btn_New_Click(object sender, EventArgs e)
        {
            clearForm();
        }
        private void CheckCorrectionAndDiscount()
        {
            double discountValue = 0;
            double correctionValue = 0;
            UpdatePriceInOfferTable();
            if (double.TryParse(txt_PriceCorrection.Text, out correctionValue))
            {
                GenerateCorrection(correctionValue);
            }
            if (double.TryParse(txt_Discount.Text, out discountValue))
            {
                GenerateDiscount(discountValue);
            }
            //if (discountValue == correctionValue)
            //{
            //    UpdatePriceInOfferTable();
            //}
            calculateTotal();

        }
        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            CheckCorrectionAndDiscount();
            AddtionalPriceBasedOnColor();
            txt_GrandTotal.Text = getGrandTotal().ToString("#.00");

        }
        private void txt_PriceCorrection_TextChanged(object sender, EventArgs e)
        {
            CheckCorrectionAndDiscount();
            AddtionalPriceBasedOnColor();
            txt_GrandTotal.Text = getGrandTotal().ToString("#.00");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // dgv_Suggestion.DataSource = null;
            DataTable DT = (DataTable)dgv_Suggestion.DataSource;
            if (DT != null)
                DT.Clear();
        }

        private void dgv_GrilleProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txt_HeatOutput_MouseMove(object sender, MouseEventArgs e)
        {
            //(sender as TextBox).SelectionLength = 0;
        }

        private void cmb_Pricebase_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as ComboBox).SelectionLength = 0;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cmb_Pricebase.SelectionLength = 0;
            cmb_ConvectorsInstallationType.SelectionLength = 0;
            cmb_Type.SelectionLength = 0;
            cmb_ConvectorsModel.SelectionLength = 0;
            cmb_GrillsType.SelectionLength = 0;
            cmb_GrillsType.SelectionLength = 0;
            cmb_GrillsMaterialColor.SelectionLength = 0;
            cmb_Accessory.SelectionLength = 0;
            cmb_HeatingFanSpeed.SelectionLength = 0;
            cmb_Pricebase.SelectionLength = 0;


        }

        private void cmb_ConvectorsModel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
