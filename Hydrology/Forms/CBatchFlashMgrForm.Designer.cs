namespace Hydrology.Forms
{
    partial class CBatchFlashMgrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CBatchFlashMgrForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioBoard = new System.Windows.Forms.RadioButton();
            this.radioFlash = new System.Windows.Forms.RadioButton();
            this.radioDayHour = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioSD = new System.Windows.Forms.RadioButton();
            this.radioWater = new System.Windows.Forms.RadioButton();
            this.radioRain = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dtp_StartTime = new System.Windows.Forms.DateTimePicker();
            this.radioDay = new System.Windows.Forms.RadioButton();
            this.radioHour = new System.Windows.Forms.RadioButton();
            this.lbl_EndTime = new System.Windows.Forms.Label();
            this.lbl_StartTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioSaveDB = new System.Windows.Forms.RadioButton();
            this.radioSaveTxt = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStartTrans = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 562);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(531, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(525, 261);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "返回信息";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Info;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(519, 241);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.radioDayHour);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.dtp_EndTime);
            this.groupBox2.Controls.Add(this.dtp_StartTime);
            this.groupBox2.Controls.Add(this.radioDay);
            this.groupBox2.Controls.Add(this.radioHour);
            this.groupBox2.Controls.Add(this.cmbStation);
            this.groupBox2.Controls.Add(this.lbl_EndTime);
            this.groupBox2.Controls.Add(this.lbl_StartTime);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(525, 233);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "配置";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.radioBoard);
            this.panel4.Controls.Add(this.radioFlash);
            this.panel4.Location = new System.Drawing.Point(49, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(332, 29);
            this.panel4.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "传输方式：";
            // 
            // radioBoard
            // 
            this.radioBoard.AutoSize = true;
            this.radioBoard.Location = new System.Drawing.Point(244, 5);
            this.radioBoard.Name = "radioBoard";
            this.radioBoard.Size = new System.Drawing.Size(71, 16);
            this.radioBoard.TabIndex = 14;
            this.radioBoard.Text = "主板传输";
            this.radioBoard.UseVisualStyleBackColor = true;
            this.radioBoard.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioFlash
            // 
            this.radioFlash.AutoSize = true;
            this.radioFlash.Location = new System.Drawing.Point(125, 5);
            this.radioFlash.Name = "radioFlash";
            this.radioFlash.Size = new System.Drawing.Size(77, 16);
            this.radioFlash.TabIndex = 16;
            this.radioFlash.Text = "Flash传输";
            this.radioFlash.UseVisualStyleBackColor = true;
            // 
            // radioDayHour
            // 
            this.radioDayHour.AutoSize = true;
            this.radioDayHour.Location = new System.Drawing.Point(334, 127);
            this.radioDayHour.Name = "radioDayHour";
            this.radioDayHour.Size = new System.Drawing.Size(83, 16);
            this.radioDayHour.TabIndex = 13;
            this.radioDayHour.Text = "日整点传输";
            this.radioDayHour.UseVisualStyleBackColor = true;
            this.radioDayHour.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioSD);
            this.panel3.Controls.Add(this.radioWater);
            this.panel3.Controls.Add(this.radioRain);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(49, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 29);
            this.panel3.TabIndex = 12;
            // 
            // radioSD
            // 
            this.radioSD.AutoSize = true;
            this.radioSD.Location = new System.Drawing.Point(244, 8);
            this.radioSD.Name = "radioSD";
            this.radioSD.Size = new System.Drawing.Size(47, 16);
            this.radioSD.TabIndex = 13;
            this.radioSD.Text = "SD卡";
            this.radioSD.UseVisualStyleBackColor = true;
            // 
            // radioWater
            // 
            this.radioWater.AutoSize = true;
            this.radioWater.Checked = true;
            this.radioWater.Location = new System.Drawing.Point(123, 8);
            this.radioWater.Name = "radioWater";
            this.radioWater.Size = new System.Drawing.Size(47, 16);
            this.radioWater.TabIndex = 10;
            this.radioWater.TabStop = true;
            this.radioWater.Text = "水位";
            this.radioWater.UseVisualStyleBackColor = true;
            this.radioWater.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioRain
            // 
            this.radioRain.AutoSize = true;
            this.radioRain.Location = new System.Drawing.Point(186, 8);
            this.radioRain.Name = "radioRain";
            this.radioRain.Size = new System.Drawing.Size(47, 16);
            this.radioRain.TabIndex = 11;
            this.radioRain.Text = "雨量";
            this.radioRain.UseVisualStyleBackColor = true;
            this.radioRain.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "报类：";
            // 
            // dtp_EndTime
            // 
            this.dtp_EndTime.Location = new System.Drawing.Point(174, 198);
            this.dtp_EndTime.Name = "dtp_EndTime";
            this.dtp_EndTime.Size = new System.Drawing.Size(167, 21);
            this.dtp_EndTime.TabIndex = 8;
            // 
            // dtp_StartTime
            // 
            this.dtp_StartTime.CustomFormat = "\"\"";
            this.dtp_StartTime.Location = new System.Drawing.Point(176, 159);
            this.dtp_StartTime.Name = "dtp_StartTime";
            this.dtp_StartTime.Size = new System.Drawing.Size(167, 21);
            this.dtp_StartTime.TabIndex = 7;
            // 
            // radioDay
            // 
            this.radioDay.AutoSize = true;
            this.radioDay.Location = new System.Drawing.Point(260, 127);
            this.radioDay.Name = "radioDay";
            this.radioDay.Size = new System.Drawing.Size(59, 16);
            this.radioDay.TabIndex = 6;
            this.radioDay.Text = "日传输";
            this.radioDay.UseVisualStyleBackColor = true;
            this.radioDay.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioHour
            // 
            this.radioHour.AutoSize = true;
            this.radioHour.Checked = true;
            this.radioHour.Location = new System.Drawing.Point(172, 127);
            this.radioHour.Name = "radioHour";
            this.radioHour.Size = new System.Drawing.Size(71, 16);
            this.radioHour.TabIndex = 5;
            this.radioHour.TabStop = true;
            this.radioHour.Text = "小时传输";
            this.radioHour.UseVisualStyleBackColor = true;
            this.radioHour.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // lbl_EndTime
            // 
            this.lbl_EndTime.AutoSize = true;
            this.lbl_EndTime.Location = new System.Drawing.Point(75, 202);
            this.lbl_EndTime.Name = "lbl_EndTime";
            this.lbl_EndTime.Size = new System.Drawing.Size(65, 12);
            this.lbl_EndTime.TabIndex = 3;
            this.lbl_EndTime.Text = "结束时间：";
            // 
            // lbl_StartTime
            // 
            this.lbl_StartTime.AutoSize = true;
            this.lbl_StartTime.Location = new System.Drawing.Point(74, 165);
            this.lbl_StartTime.Name = "lbl_StartTime";
            this.lbl_StartTime.Size = new System.Drawing.Size(65, 12);
            this.lbl_StartTime.TabIndex = 2;
            this.lbl_StartTime.Text = "起始时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "时间选择：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "测站：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioSaveDB);
            this.panel2.Controls.Add(this.radioSaveTxt);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnStartTrans);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(525, 50);
            this.panel2.TabIndex = 7;
            // 
            // radioSaveDB
            // 
            this.radioSaveDB.AutoSize = true;
            this.radioSaveDB.Location = new System.Drawing.Point(414, 19);
            this.radioSaveDB.Name = "radioSaveDB";
            this.radioSaveDB.Size = new System.Drawing.Size(47, 16);
            this.radioSaveDB.TabIndex = 12;
            this.radioSaveDB.TabStop = true;
            this.radioSaveDB.Text = "存库";
            this.radioSaveDB.UseVisualStyleBackColor = true;
            // 
            // radioSaveTxt
            // 
            this.radioSaveTxt.AutoSize = true;
            this.radioSaveTxt.Location = new System.Drawing.Point(305, 19);
            this.radioSaveTxt.Name = "radioSaveTxt";
            this.radioSaveTxt.Size = new System.Drawing.Size(59, 16);
            this.radioSaveTxt.TabIndex = 11;
            this.radioSaveTxt.TabStop = true;
            this.radioSaveTxt.Text = "存文本";
            this.radioSaveTxt.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(26, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空返回信息";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStartTrans
            // 
            this.btnStartTrans.Location = new System.Drawing.Point(107, 16);
            this.btnStartTrans.Name = "btnStartTrans";
            this.btnStartTrans.Size = new System.Drawing.Size(75, 23);
            this.btnStartTrans.TabIndex = 8;
            this.btnStartTrans.Text = "开始传输";
            this.btnStartTrans.UseVisualStyleBackColor = true;
            this.btnStartTrans.Click += new System.EventHandler(this.btnStartTrans_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(188, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbStation
            // 
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Location = new System.Drawing.Point(349, 149);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(167, 20);
            this.cmbStation.TabIndex = 4;
            // 
            // CBatchFlashMgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 562);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CBatchFlashMgrForm";
            this.Text = "批量传输";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_EndTime;
        private System.Windows.Forms.DateTimePicker dtp_StartTime;
        private System.Windows.Forms.RadioButton radioDay;
        private System.Windows.Forms.RadioButton radioHour;
        private System.Windows.Forms.Label lbl_EndTime;
        private System.Windows.Forms.Label lbl_StartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStartTrans;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton radioRain;
        private System.Windows.Forms.RadioButton radioWater;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioSaveDB;
        private System.Windows.Forms.RadioButton radioSaveTxt;
        private System.Windows.Forms.RadioButton radioSD;
        private System.Windows.Forms.RadioButton radioDayHour;
        private System.Windows.Forms.RadioButton radioBoard;
        private System.Windows.Forms.RadioButton radioFlash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmbStation;
    }
}