namespace KonekaSelectionProgram
{
    partial class frm_ProjectData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_OrderNo = new System.Windows.Forms.TextBox();
            this.txt_Project = new System.Windows.Forms.TextBox();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.txt_ContactPerson = new System.Windows.Forms.TextBox();
            this.dtp_Date = new System.Windows.Forms.DateTimePicker();
            this.btn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order No.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Customer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Contact person";
            // 
            // txt_OrderNo
            // 
            this.txt_OrderNo.Location = new System.Drawing.Point(209, 68);
            this.txt_OrderNo.Name = "txt_OrderNo";
            this.txt_OrderNo.Size = new System.Drawing.Size(443, 30);
            this.txt_OrderNo.TabIndex = 1;
            // 
            // txt_Project
            // 
            this.txt_Project.Location = new System.Drawing.Point(209, 108);
            this.txt_Project.Name = "txt_Project";
            this.txt_Project.Size = new System.Drawing.Size(443, 30);
            this.txt_Project.TabIndex = 2;
            // 
            // txt_Customer
            // 
            this.txt_Customer.Location = new System.Drawing.Point(209, 148);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.Size = new System.Drawing.Size(443, 30);
            this.txt_Customer.TabIndex = 3;
            // 
            // txt_ContactPerson
            // 
            this.txt_ContactPerson.Location = new System.Drawing.Point(209, 189);
            this.txt_ContactPerson.Name = "txt_ContactPerson";
            this.txt_ContactPerson.Size = new System.Drawing.Size(443, 30);
            this.txt_ContactPerson.TabIndex = 4;
            // 
            // dtp_Date
            // 
            this.dtp_Date.Location = new System.Drawing.Point(209, 23);
            this.dtp_Date.Name = "dtp_Date";
            this.dtp_Date.Size = new System.Drawing.Size(443, 30);
            this.dtp_Date.TabIndex = 6;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(209, 239);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(216, 39);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frm_ProjectData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 308);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.dtp_Date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ContactPerson);
            this.Controls.Add(this.txt_Customer);
            this.Controls.Add(this.txt_Project);
            this.Controls.Add(this.txt_OrderNo);
            this.Font = new System.Drawing.Font("Century Gothic", 11.26957F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_ProjectData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Data";
            this.Load += new System.EventHandler(this.frm_ProjectData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_OrderNo;
        private System.Windows.Forms.TextBox txt_Project;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.TextBox txt_ContactPerson;
        private System.Windows.Forms.DateTimePicker dtp_Date;
        private System.Windows.Forms.Button btn_Save;
    }
}