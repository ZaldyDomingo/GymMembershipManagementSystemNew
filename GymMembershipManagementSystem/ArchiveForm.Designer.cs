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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonDeletePermanent = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxRegular = new System.Windows.Forms.CheckBox();
            this.checkBoxStudent = new System.Windows.Forms.CheckBox();
            this.buttonRestoreStudentMember = new System.Windows.Forms.Button();
            this.dataGridViewArchived = new System.Windows.Forms.DataGridView();
            this.buttonRestoreRegularMember = new System.Windows.Forms.Button();
            this.buttonRenewRegular = new System.Windows.Forms.Button();
            this.buttonRenewStudent = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchived)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeletePermanent
            // 
            this.buttonDeletePermanent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            this.buttonDeletePermanent.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeletePermanent.Location = new System.Drawing.Point(107, 35);
            this.buttonDeletePermanent.Name = "buttonDeletePermanent";
            this.buttonDeletePermanent.Size = new System.Drawing.Size(238, 63);
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
            this.panel1.Controls.Add(this.buttonRenewStudent);
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
            // checkBoxRegular
            // 
            this.checkBoxRegular.AutoSize = true;
            this.checkBoxRegular.Location = new System.Drawing.Point(186, 561);
            this.checkBoxRegular.Name = "checkBoxRegular";
            this.checkBoxRegular.Size = new System.Drawing.Size(79, 21);
            this.checkBoxRegular.TabIndex = 37;
            this.checkBoxRegular.Text = "Regular";
            this.checkBoxRegular.UseVisualStyleBackColor = true;
            this.checkBoxRegular.CheckedChanged += new System.EventHandler(this.checkBoxRegular_CheckedChanged);
            // 
            // checkBoxStudent
            // 
            this.checkBoxStudent.AutoSize = true;
            this.checkBoxStudent.Location = new System.Drawing.Point(71, 561);
            this.checkBoxStudent.Name = "checkBoxStudent";
            this.checkBoxStudent.Size = new System.Drawing.Size(79, 21);
            this.checkBoxStudent.TabIndex = 36;
            this.checkBoxStudent.Text = "Student";
            this.checkBoxStudent.UseVisualStyleBackColor = true;
            this.checkBoxStudent.CheckedChanged += new System.EventHandler(this.checkBoxStudent_CheckedChanged);
            // 
            // buttonRestoreStudentMember
            // 
            this.buttonRestoreStudentMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            this.buttonRestoreStudentMember.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestoreStudentMember.Location = new System.Drawing.Point(417, 35);
            this.buttonRestoreStudentMember.Name = "buttonRestoreStudentMember";
            this.buttonRestoreStudentMember.Size = new System.Drawing.Size(238, 63);
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
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewArchived.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewArchived.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewArchived.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewArchived.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewArchived.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewArchived.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewArchived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewArchived.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewArchived.EnableHeadersVisualStyles = false;
            this.dataGridViewArchived.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewArchived.Location = new System.Drawing.Point(50, 111);
            this.dataGridViewArchived.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridViewArchived.MultiSelect = false;
            this.dataGridViewArchived.Name = "dataGridViewArchived";
            this.dataGridViewArchived.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewArchived.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewArchived.RowHeadersVisible = false;
            this.dataGridViewArchived.RowHeadersWidth = 51;
            this.dataGridViewArchived.RowTemplate.Height = 80;
            this.dataGridViewArchived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchived.Size = new System.Drawing.Size(1163, 424);
            this.dataGridViewArchived.TabIndex = 18;
            // 
            // buttonRestoreRegularMember
            // 
            this.buttonRestoreRegularMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            this.buttonRestoreRegularMember.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestoreRegularMember.Location = new System.Drawing.Point(690, 35);
            this.buttonRestoreRegularMember.Name = "buttonRestoreRegularMember";
            this.buttonRestoreRegularMember.Size = new System.Drawing.Size(238, 63);
            this.buttonRestoreRegularMember.TabIndex = 34;
            this.buttonRestoreRegularMember.Text = "Restore";
            this.buttonRestoreRegularMember.UseVisualStyleBackColor = false;
            this.buttonRestoreRegularMember.Click += new System.EventHandler(this.buttonRestoreRegularMember_Click);
            // 
            // buttonRenewRegular
            // 
            this.buttonRenewRegular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            this.buttonRenewRegular.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRenewRegular.Location = new System.Drawing.Point(417, 548);
            this.buttonRenewRegular.Name = "buttonRenewRegular";
            this.buttonRenewRegular.Size = new System.Drawing.Size(238, 63);
            this.buttonRenewRegular.TabIndex = 38;
            this.buttonRenewRegular.Text = "Re-new";
            this.buttonRenewRegular.UseVisualStyleBackColor = false;
            this.buttonRenewRegular.Click += new System.EventHandler(this.buttonRenewRegular_Click);
            // 
            // buttonRenewStudent
            // 
            this.buttonRenewStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            this.buttonRenewStudent.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRenewStudent.Location = new System.Drawing.Point(690, 548);
            this.buttonRenewStudent.Name = "buttonRenewStudent";
            this.buttonRenewStudent.Size = new System.Drawing.Size(238, 63);
            this.buttonRenewStudent.TabIndex = 39;
            this.buttonRenewStudent.Text = "Re-new";
            this.buttonRenewStudent.UseVisualStyleBackColor = false;
            this.buttonRenewStudent.Click += new System.EventHandler(this.buttonRenewStudent_Click);
            // 
            // ArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 1008);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.buttonDeletePermanent);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
    }
}