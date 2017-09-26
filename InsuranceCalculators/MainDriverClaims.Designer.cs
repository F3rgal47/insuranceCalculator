namespace InsuranceCalculators
{
    partial class MainDriverClaims
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel12 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClaimId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainDriverID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondaryDriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClaimRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfIncident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncidentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Damage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearsSinceIncident = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.button1);
            this.panel12.Controls.Add(this.textBox2);
            this.panel12.Controls.Add(this.dataGridView1);
            this.panel12.Controls.Add(this.label3);
            this.panel12.Controls.Add(this.button3);
            this.panel12.Controls.Add(this.button2);
            this.panel12.Controls.Add(this.checkBox2);
            this.panel12.Controls.Add(this.checkBox1);
            this.panel12.Controls.Add(this.label10);
            this.panel12.Controls.Add(this.label9);
            this.panel12.Controls.Add(this.label8);
            this.panel12.Controls.Add(this.comboBox8);
            this.panel12.Controls.Add(this.comboBox6);
            this.panel12.Controls.Add(this.comboBox7);
            this.panel12.Controls.Add(this.comboBox5);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Controls.Add(this.panel10);
            this.panel12.Location = new System.Drawing.Point(12, 21);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(793, 529);
            this.panel12.TabIndex = 50;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(578, 217);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 38);
            this.textBox2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClaimId,
            this.MainDriverID1,
            this.SecondaryDriverID,
            this.ClaimRank,
            this.TypeOfIncident,
            this.IncidentDate,
            this.Damage,
            this.YearsSinceIncident});
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(53, 377);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(702, 113);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 88;
            // 
            // ClaimId
            // 
            this.ClaimId.HeaderText = "Claim Id";
            this.ClaimId.Name = "ClaimId";
            this.ClaimId.Visible = false;
            // 
            // MainDriverID1
            // 
            this.MainDriverID1.HeaderText = "MainDriverID";
            this.MainDriverID1.Name = "MainDriverID1";
            this.MainDriverID1.ReadOnly = true;
            this.MainDriverID1.Visible = false;
            // 
            // SecondaryDriverID
            // 
            this.SecondaryDriverID.HeaderText = "SecondaryDriverID";
            this.SecondaryDriverID.Name = "SecondaryDriverID";
            this.SecondaryDriverID.Visible = false;
            // 
            // ClaimRank
            // 
            this.ClaimRank.HeaderText = "ClaimRank";
            this.ClaimRank.Name = "ClaimRank";
            this.ClaimRank.Visible = false;
            // 
            // TypeOfIncident
            // 
            this.TypeOfIncident.HeaderText = "Type of Incident";
            this.TypeOfIncident.Name = "TypeOfIncident";
            // 
            // IncidentDate
            // 
            this.IncidentDate.HeaderText = "Date";
            this.IncidentDate.Name = "IncidentDate";
            // 
            // Damage
            // 
            this.Damage.HeaderText = "Damage Suffered";
            this.Damage.Name = "Damage";
            // 
            // YearsSinceIncident
            // 
            this.YearsSinceIncident.HeaderText = "Years Since Incident";
            this.YearsSinceIncident.Name = "YearsSinceIncident";
            this.YearsSinceIncident.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(49, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 89;
            this.label3.Text = "Years Since";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(629, 332);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(122, 29);
            this.button3.TabIndex = 69;
            this.button3.Text = "Edit Claim";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(53, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 29);
            this.button2.TabIndex = 68;
            this.button2.Text = "Add Claim";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox2.Location = new System.Drawing.Point(695, 58);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 28);
            this.checkBox2.TabIndex = 67;
            this.checkBox2.Text = "No";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox1.Location = new System.Drawing.Point(578, 58);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(64, 28);
            this.checkBox1.TabIndex = 66;
            this.checkBox1.Text = "Yes";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(49, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(151, 20);
            this.label10.TabIndex = 63;
            this.label10.Text = "Damage Suffered";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(49, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 62;
            this.label9.Text = "Date of Incident";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(49, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "Type of Incident";
            // 
            // comboBox8
            // 
            this.comboBox8.Enabled = false;
            this.comboBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Items.AddRange(new object[] {
            "Minor Damage",
            "Major Damage",
            "Write-Off"});
            this.comboBox8.Location = new System.Drawing.Point(550, 277);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(201, 39);
            this.comboBox8.TabIndex = 5;
            // 
            // comboBox6
            // 
            this.comboBox6.Enabled = false;
            this.comboBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(657, 172);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(94, 39);
            this.comboBox6.TabIndex = 3;
            this.comboBox6.SelectedIndexChanged += new System.EventHandler(this.comboBox6_SelectedIndexChanged_1);
            // 
            // comboBox7
            // 
            this.comboBox7.Enabled = false;
            this.comboBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.comboBox7.Location = new System.Drawing.Point(550, 172);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(88, 39);
            this.comboBox7.TabIndex = 2;
            // 
            // comboBox5
            // 
            this.comboBox5.AutoCompleteCustomSource.AddRange(new string[] {
            "Accident",
            "Theft",
            "Other"});
            this.comboBox5.Enabled = false;
            this.comboBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Items.AddRange(new object[] {
            "Accident",
            "Theft",
            "Other"});
            this.comboBox5.Location = new System.Drawing.Point(550, 107);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(201, 39);
            this.comboBox5.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(49, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(387, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Have you had any claims in the past five years?";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel10.Controls.Add(this.label7);
            this.panel10.Location = new System.Drawing.Point(3, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(787, 46);
            this.panel10.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(3, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 24);
            this.label7.TabIndex = 2;
            this.label7.Text = "Main Drivers Claims";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(633, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 29);
            this.button1.TabIndex = 70;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainDriverClaims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 591);
            this.Controls.Add(this.panel12);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainDriverClaims";
            this.Text = "MainClaims";
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimId;
        private System.Windows.Forms.DataGridViewTextBoxColumn MainDriverID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondaryDriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClaimRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfIncident;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncidentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Damage;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearsSinceIncident;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}