namespace GymMembershipManagementSystem
{
    partial class MembershipTransactionFees
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.chartMembershipFees = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelTotalMembershipFee = new System.Windows.Forms.Label();
            this.dataGridStudentFeeTotal = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.button7Months = new System.Windows.Forms.Button();
            this.button1year = new System.Windows.Forms.Button();
            this.button4Months = new System.Windows.Forms.Button();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMembershipFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentFeeTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.button7Months);
            this.panelContainer.Controls.Add(this.button1year);
            this.panelContainer.Controls.Add(this.button4Months);
            this.panelContainer.Controls.Add(this.chartMembershipFees);
            this.panelContainer.Controls.Add(this.labelTotalMembershipFee);
            this.panelContainer.Controls.Add(this.dataGridStudentFeeTotal);
            this.panelContainer.Controls.Add(this.label2);
            this.panelContainer.Controls.Add(this.panel2);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1428, 1055);
            this.panelContainer.TabIndex = 0;
            // 
            // chartMembershipFees
            // 
            this.chartMembershipFees.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartMembershipFees.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMembershipFees.Legends.Add(legend2);
            this.chartMembershipFees.Location = new System.Drawing.Point(21, 427);
            this.chartMembershipFees.Name = "chartMembershipFees";
            this.chartMembershipFees.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMembershipFees.Series.Add(series2);
            this.chartMembershipFees.Size = new System.Drawing.Size(1290, 300);
            this.chartMembershipFees.TabIndex = 17;
            this.chartMembershipFees.Text = "chart1";
            // 
            // labelTotalMembershipFee
            // 
            this.labelTotalMembershipFee.AutoSize = true;
            this.labelTotalMembershipFee.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalMembershipFee.Location = new System.Drawing.Point(16, 75);
            this.labelTotalMembershipFee.Name = "labelTotalMembershipFee";
            this.labelTotalMembershipFee.Size = new System.Drawing.Size(122, 27);
            this.labelTotalMembershipFee.TabIndex = 16;
            this.labelTotalMembershipFee.Text = "labelTotal";
            // 
            // dataGridStudentFeeTotal
            // 
            this.dataGridStudentFeeTotal.AllowUserToAddRows = false;
            this.dataGridStudentFeeTotal.AllowUserToDeleteRows = false;
            this.dataGridStudentFeeTotal.AllowUserToResizeColumns = false;
            this.dataGridStudentFeeTotal.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.dataGridStudentFeeTotal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridStudentFeeTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridStudentFeeTotal.BackgroundColor = System.Drawing.Color.White;
            this.dataGridStudentFeeTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridStudentFeeTotal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridStudentFeeTotal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridStudentFeeTotal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridStudentFeeTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridStudentFeeTotal.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridStudentFeeTotal.EnableHeadersVisualStyles = false;
            this.dataGridStudentFeeTotal.Location = new System.Drawing.Point(19, 126);
            this.dataGridStudentFeeTotal.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridStudentFeeTotal.MultiSelect = false;
            this.dataGridStudentFeeTotal.Name = "dataGridStudentFeeTotal";
            this.dataGridStudentFeeTotal.ReadOnly = true;
            this.dataGridStudentFeeTotal.RowHeadersVisible = false;
            this.dataGridStudentFeeTotal.RowHeadersWidth = 51;
            this.dataGridStudentFeeTotal.RowTemplate.Height = 80;
            this.dataGridStudentFeeTotal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridStudentFeeTotal.Size = new System.Drawing.Size(1292, 288);
            this.dataGridStudentFeeTotal.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 39);
            this.label2.TabIndex = 14;
            this.label2.Text = "Transaction History";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(3, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 901);
            this.panel2.TabIndex = 13;
            // 
            // button7Months
            // 
            this.button7Months.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            this.button7Months.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7Months.Location = new System.Drawing.Point(949, 433);
            this.button7Months.Name = "button7Months";
            this.button7Months.Size = new System.Drawing.Size(75, 23);
            this.button7Months.TabIndex = 29;
            this.button7Months.Text = "7 months";
            this.button7Months.UseVisualStyleBackColor = false;
            this.button7Months.Click += new System.EventHandler(this.button7Months_Click);
            // 
            // button1year
            // 
            this.button1year.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(215)))), ((int)(((byte)(195)))));
            this.button1year.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1year.Location = new System.Drawing.Point(1030, 433);
            this.button1year.Name = "button1year";
            this.button1year.Size = new System.Drawing.Size(75, 23);
            this.button1year.TabIndex = 28;
            this.button1year.Text = "1 year";
            this.button1year.UseVisualStyleBackColor = false;
            this.button1year.Click += new System.EventHandler(this.button1year_Click);
            // 
            // button4Months
            // 
            this.button4Months.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(217)))));
            this.button4Months.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4Months.Location = new System.Drawing.Point(868, 433);
            this.button4Months.Name = "button4Months";
            this.button4Months.Size = new System.Drawing.Size(75, 23);
            this.button4Months.TabIndex = 27;
            this.button4Months.Text = "4 months";
            this.button4Months.UseVisualStyleBackColor = false;
            this.button4Months.Click += new System.EventHandler(this.button4Months_Click);
            // 
            // MembershipTransactionFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1428, 1055);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MembershipTransactionFees";
            this.Text = "MembershipTransactionFees";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMembershipFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStudentFeeTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridStudentFeeTotal;
        private System.Windows.Forms.Label labelTotalMembershipFee;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMembershipFees;
        private System.Windows.Forms.Button button7Months;
        private System.Windows.Forms.Button button1year;
        private System.Windows.Forms.Button button4Months;
    }
}