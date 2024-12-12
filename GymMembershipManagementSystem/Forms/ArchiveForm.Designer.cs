namespace GymMembershipManagementSystem
{
    partial class ArchiveForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonDeletePermanent = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRenewStudent = new System.Windows.Forms.Button();
            this.buttonRenewRegular = new System.Windows.Forms.Button();
            this.checkBoxRegular = new System.Windows.Forms.CheckBox();
            this.checkBoxStudent = new System.Windows.Forms.CheckBox();
            this.buttonRestoreStudentMember = new System.Windows.Forms.Button();
            this.dataGridViewArchived = new System.Windows.Forms.DataGridView();
            this.buttonRestoreRegularMember = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchived)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeletePermanent
            // 
            this.buttonDeletePermanent.BackColor = System.Drawing.Color.White;
            this.buttonDeletePermanent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeletePermanent.Location = new System.Drawing.Point(171, 41);
            this.buttonDeletePermanent.Name = "buttonDeletePermanent";
            this.buttonDeletePermanent.Size = new System.Drawing.Size(138, 63);
            this.buttonDeletePermanent.TabIndex = 27;
            this.buttonDeletePermanent.Text = "Delete";
            this.buttonDeletePermanent.UseVisualStyleBackColor = false;
            this.buttonDeletePermanent.Click += new System.EventHandler(this.buttonDeletePermanent_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(3, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 1071);
            this.panel3.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonRenewStudent);
            this.panel1.Controls.Add(this.buttonDeletePermanent);
            this.panel1.Controls.Add(this.buttonRenewRegular);
            this.panel1.Controls.Add(this.checkBoxRegular);
            this.panel1.Controls.Add(this.checkBoxStudent);
            this.panel1.Controls.Add(this.buttonRestoreStudentMember);
            this.panel1.Controls.Add(this.dataGridViewArchived);
            this.panel1.Controls.Add(this.buttonRestoreRegularMember);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1810, 1008);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 39);
            this.label1.TabIndex = 40;
            this.label1.Text = "Archive";
            // 
            // buttonRenewStudent
            // 
            this.buttonRenewStudent.BackColor = System.Drawing.Color.White;
            this.buttonRenewStudent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRenewStudent.Location = new System.Drawing.Point(459, 41);
            this.buttonRenewStudent.Name = "buttonRenewStudent";
            this.buttonRenewStudent.Size = new System.Drawing.Size(138, 63);
            this.buttonRenewStudent.TabIndex = 39;
            this.buttonRenewStudent.Text = "Re-new";
            this.buttonRenewStudent.UseVisualStyleBackColor = false;
            this.buttonRenewStudent.Click += new System.EventHandler(this.buttonRenewStudent_Click);
            // 
            // buttonRenewRegular
            // 
            this.buttonRenewRegular.BackColor = System.Drawing.Color.White;
            this.buttonRenewRegular.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRenewRegular.Location = new System.Drawing.Point(459, 41);
            this.buttonRenewRegular.Name = "buttonRenewRegular";
            this.buttonRenewRegular.Size = new System.Drawing.Size(138, 63);
            this.buttonRenewRegular.TabIndex = 38;
            this.buttonRenewRegular.Text = "Re-new";
            this.buttonRenewRegular.UseVisualStyleBackColor = false;
            this.buttonRenewRegular.Click += new System.EventHandler(this.buttonRenewRegular_Click);
            // 
            // checkBoxRegular
            // 
            this.checkBoxRegular.AutoSize = true;
            this.checkBoxRegular.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRegular.Location = new System.Drawing.Point(21, 141);
            this.checkBoxRegular.Name = "checkBoxRegular";
            this.checkBoxRegular.Size = new System.Drawing.Size(87, 24);
            this.checkBoxRegular.TabIndex = 37;
            this.checkBoxRegular.Text = "Regular";
            this.checkBoxRegular.UseVisualStyleBackColor = true;
            this.checkBoxRegular.CheckedChanged += new System.EventHandler(this.checkBoxRegular_CheckedChanged);
            // 
            // checkBoxStudent
            // 
            this.checkBoxStudent.AutoSize = true;
            this.checkBoxStudent.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStudent.Location = new System.Drawing.Point(22, 184);
            this.checkBoxStudent.Name = "checkBoxStudent";
            this.checkBoxStudent.Size = new System.Drawing.Size(86, 24);
            this.checkBoxStudent.TabIndex = 36;
            this.checkBoxStudent.Text = "Student";
            this.checkBoxStudent.UseVisualStyleBackColor = true;
            this.checkBoxStudent.CheckedChanged += new System.EventHandler(this.checkBoxStudent_CheckedChanged);
            // 
            // buttonRestoreStudentMember
            // 
            this.buttonRestoreStudentMember.BackColor = System.Drawing.Color.White;
            this.buttonRestoreStudentMember.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestoreStudentMember.Location = new System.Drawing.Point(315, 41);
            this.buttonRestoreStudentMember.Name = "buttonRestoreStudentMember";
            this.buttonRestoreStudentMember.Size = new System.Drawing.Size(138, 63);
            this.buttonRestoreStudentMember.TabIndex = 35;
            this.buttonRestoreStudentMember.Text = "Restore";
            this.buttonRestoreStudentMember.UseVisualStyleBackColor = false;
            this.buttonRestoreStudentMember.Click += new System.EventHandler(this.buttonRestoreStudentMember_Click);
            // 
            // dataGridViewArchived
            // 
            this.dataGridViewArchived.AllowUserToAddRows = false;
            this.dataGridViewArchived.AllowUserToDeleteRows = false;
            this.dataGridViewArchived.AllowUserToResizeColumns = false;
            this.dataGridViewArchived.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewArchived.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewArchived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewArchived.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewArchived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewArchived.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewArchived.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewArchived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewArchived.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewArchived.EnableHeadersVisualStyles = false;
            this.dataGridViewArchived.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArchived.Location = new System.Drawing.Point(121, 128);
            this.dataGridViewArchived.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewArchived.MultiSelect = false;
            this.dataGridViewArchived.Name = "dataGridViewArchived";
            this.dataGridViewArchived.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewArchived.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewArchived.RowHeadersVisible = false;
            this.dataGridViewArchived.RowHeadersWidth = 51;
            this.dataGridViewArchived.RowTemplate.Height = 80;
            this.dataGridViewArchived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchived.Size = new System.Drawing.Size(1191, 375);
            this.dataGridViewArchived.TabIndex = 18;
            // 
            // buttonRestoreRegularMember
            // 
            this.buttonRestoreRegularMember.BackColor = System.Drawing.Color.White;
            this.buttonRestoreRegularMember.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestoreRegularMember.Location = new System.Drawing.Point(315, 41);
            this.buttonRestoreRegularMember.Name = "buttonRestoreRegularMember";
            this.buttonRestoreRegularMember.Size = new System.Drawing.Size(138, 63);
            this.buttonRestoreRegularMember.TabIndex = 34;
            this.buttonRestoreRegularMember.Text = "Restore";
            this.buttonRestoreRegularMember.UseVisualStyleBackColor = false;
            this.buttonRestoreRegularMember.Click += new System.EventHandler(this.buttonRestoreRegularMember_Click);
            // 
            // ArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 1008);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ArchiveForm";
            this.Text = "ArchiveForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchived)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDeletePermanent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRestoreStudentMember;
        private System.Windows.Forms.Button buttonRestoreRegularMember;
        private System.Windows.Forms.CheckBox checkBoxRegular;
        private System.Windows.Forms.CheckBox checkBoxStudent;
        private System.Windows.Forms.DataGridView dataGridViewArchived;
        private System.Windows.Forms.Button buttonRenewRegular;
        private System.Windows.Forms.Button buttonRenewStudent;
        private System.Windows.Forms.Label label1;
    }
}