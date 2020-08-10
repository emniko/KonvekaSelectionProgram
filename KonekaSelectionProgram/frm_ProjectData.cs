using KonekaSelectionProgram.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonekaSelectionProgram
{
    public partial class frm_ProjectData : Form
    {
        public frm_ProjectData()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ProjectData.Date = dtp_Date.Value.ToShortDateString();
            ProjectData.OrderNo = txt_OrderNo.Text;
            ProjectData.Project = txt_Project.Text;
            ProjectData.Customer = txt_Customer.Text;
            ProjectData.ContactPerson = txt_ContactPerson.Text;
            MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frm_ProjectData_Load(object sender, EventArgs e)
        {
            txt_OrderNo.Text = ProjectData.OrderNo;
            txt_Project.Text = ProjectData.Project;
            txt_Customer.Text = ProjectData.Customer;
            txt_ContactPerson.Text = ProjectData.ContactPerson;
        }
    }
}
