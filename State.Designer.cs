namespace WindowsFormsApp1
{
    partial class State
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_AddData = new System.Windows.Forms.Button();
            this.btn_NewData = new System.Windows.Forms.Button();
            this.com_CountryCode = new System.Windows.Forms.ComboBox();
            this.com_Active = new System.Windows.Forms.ComboBox();
            this.txt_TimeZone = new System.Windows.Forms.TextBox();
            this.com_StateCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btn_AddData);
            this.groupBox1.Controls.Add(this.btn_NewData);
            this.groupBox1.Controls.Add(this.com_CountryCode);
            this.groupBox1.Controls.Add(this.com_Active);
            this.groupBox1.Controls.Add(this.txt_TimeZone);
            this.groupBox1.Controls.Add(this.com_StateCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(195, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 318);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "State Details Entry";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(152, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 26);
            this.comboBox1.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(340, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // btn_AddData
            // 
            this.btn_AddData.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btn_AddData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddData.ForeColor = System.Drawing.Color.Black;
            this.btn_AddData.Location = new System.Drawing.Point(204, 264);
            this.btn_AddData.Name = "btn_AddData";
            this.btn_AddData.Size = new System.Drawing.Size(127, 32);
            this.btn_AddData.TabIndex = 18;
            this.btn_AddData.Text = "ADD DATA";
            this.btn_AddData.UseVisualStyleBackColor = true;
            // 
            // btn_NewData
            // 
            this.btn_NewData.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btn_NewData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewData.ForeColor = System.Drawing.Color.Black;
            this.btn_NewData.Location = new System.Drawing.Point(65, 264);
            this.btn_NewData.Name = "btn_NewData";
            this.btn_NewData.Size = new System.Drawing.Size(127, 32);
            this.btn_NewData.TabIndex = 17;
            this.btn_NewData.Text = "NEW DATA";
            this.btn_NewData.UseVisualStyleBackColor = true;
            // 
            // com_CountryCode
            // 
            this.com_CountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_CountryCode.FormattingEnabled = true;
            this.com_CountryCode.Location = new System.Drawing.Point(152, 201);
            this.com_CountryCode.Name = "com_CountryCode";
            this.com_CountryCode.Size = new System.Drawing.Size(179, 26);
            this.com_CountryCode.TabIndex = 16;
            // 
            // com_Active
            // 
            this.com_Active.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Active.FormattingEnabled = true;
            this.com_Active.Location = new System.Drawing.Point(152, 163);
            this.com_Active.Name = "com_Active";
            this.com_Active.Size = new System.Drawing.Size(179, 26);
            this.com_Active.TabIndex = 15;
            // 
            // txt_TimeZone
            // 
            this.txt_TimeZone.Location = new System.Drawing.Point(152, 125);
            this.txt_TimeZone.Name = "txt_TimeZone";
            this.txt_TimeZone.Size = new System.Drawing.Size(283, 26);
            this.txt_TimeZone.TabIndex = 14;
            // 
            // com_StateCode
            // 
            this.com_StateCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_StateCode.FormattingEnabled = true;
            this.com_StateCode.Location = new System.Drawing.Point(152, 48);
            this.com_StateCode.Name = "com_StateCode";
            this.com_StateCode.Size = new System.Drawing.Size(179, 26);
            this.com_StateCode.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Country Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(53, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "IsActive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(33, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Time Zone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "State Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "State Code";
            // 
            // State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(839, 614);
            this.Controls.Add(this.groupBox1);
            this.Name = "State";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "State";
            this.Load += new System.EventHandler(this.State_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_AddData;
        private System.Windows.Forms.Button btn_NewData;
        private System.Windows.Forms.ComboBox com_CountryCode;
        private System.Windows.Forms.ComboBox com_Active;
        private System.Windows.Forms.TextBox txt_TimeZone;
        private System.Windows.Forms.ComboBox com_StateCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}