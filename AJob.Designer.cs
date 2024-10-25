namespace ThiCuoiKy
{
    partial class AJob
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNote = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDeleted = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmToMinute = new System.Windows.Forms.NumericUpDown();
            this.nmToHour = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nmFromMinute = new System.Windows.Forms.NumericUpDown();
            this.nmFromHour = new System.Windows.Forms.NumericUpDown();
            this.txbJob = new System.Windows.Forms.TextBox();
            this.ckbDone = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmToMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromHour)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbNote);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.btnDeleted);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txbJob);
            this.panel1.Controls.Add(this.ckbDone);
            this.panel1.Location = new System.Drawing.Point(17, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(895, 70);
            this.panel1.TabIndex = 0;
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Location = new System.Drawing.Point(12, 47);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(53, 16);
            this.lbNote.TabIndex = 7;
            this.lbNote.Text = "Ghi Chú";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(80, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(311, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnDeleted
            // 
            this.btnDeleted.Location = new System.Drawing.Point(827, 6);
            this.btnDeleted.Name = "btnDeleted";
            this.btnDeleted.Size = new System.Drawing.Size(65, 32);
            this.btnDeleted.TabIndex = 5;
            this.btnDeleted.Text = "Xoá";
            this.btnDeleted.UseVisualStyleBackColor = true;
            this.btnDeleted.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(757, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 34);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(638, 9);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(113, 24);
            this.cbStatus.TabIndex = 3;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nmToMinute);
            this.panel2.Controls.Add(this.nmToHour);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nmFromMinute);
            this.panel2.Controls.Add(this.nmFromHour);
            this.panel2.Location = new System.Drawing.Point(397, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 35);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // nmToMinute
            // 
            this.nmToMinute.Location = new System.Drawing.Point(184, 4);
            this.nmToMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmToMinute.Name = "nmToMinute";
            this.nmToMinute.Size = new System.Drawing.Size(42, 22);
            this.nmToMinute.TabIndex = 4;
            this.nmToMinute.ValueChanged += new System.EventHandler(this.nmToMinute_ValueChanged);
            // 
            // nmToHour
            // 
            this.nmToHour.Location = new System.Drawing.Point(136, 4);
            this.nmToHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmToHour.Name = "nmToHour";
            this.nmToHour.Size = new System.Drawing.Size(42, 22);
            this.nmToHour.TabIndex = 3;
            this.nmToHour.ValueChanged += new System.EventHandler(this.nmToHour_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đến";
            // 
            // nmFromMinute
            // 
            this.nmFromMinute.Location = new System.Drawing.Point(51, 3);
            this.nmFromMinute.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmFromMinute.Name = "nmFromMinute";
            this.nmFromMinute.Size = new System.Drawing.Size(42, 22);
            this.nmFromMinute.TabIndex = 1;
            this.nmFromMinute.ValueChanged += new System.EventHandler(this.nmFromMinute_ValueChanged);
            // 
            // nmFromHour
            // 
            this.nmFromHour.Location = new System.Drawing.Point(3, 3);
            this.nmFromHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nmFromHour.Name = "nmFromHour";
            this.nmFromHour.Size = new System.Drawing.Size(42, 22);
            this.nmFromHour.TabIndex = 0;
            this.nmFromHour.ValueChanged += new System.EventHandler(this.nmFromHour_ValueChanged);
            // 
            // txbJob
            // 
            this.txbJob.Location = new System.Drawing.Point(27, 3);
            this.txbJob.Name = "txbJob";
            this.txbJob.Size = new System.Drawing.Size(364, 22);
            this.txbJob.TabIndex = 1;
            this.txbJob.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ckbDone
            // 
            this.ckbDone.AutoSize = true;
            this.ckbDone.Location = new System.Drawing.Point(3, 8);
            this.ckbDone.Name = "ckbDone";
            this.ckbDone.Size = new System.Drawing.Size(18, 17);
            this.ckbDone.TabIndex = 0;
            this.ckbDone.UseVisualStyleBackColor = true;
            this.ckbDone.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AJob";
            this.Size = new System.Drawing.Size(1364, 532);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmToMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbDone;
        private System.Windows.Forms.TextBox txbJob;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nmFromMinute;
        private System.Windows.Forms.NumericUpDown nmFromHour;
        private System.Windows.Forms.NumericUpDown nmToMinute;
        private System.Windows.Forms.NumericUpDown nmToHour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Button btnDeleted;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbNote;
    }
}