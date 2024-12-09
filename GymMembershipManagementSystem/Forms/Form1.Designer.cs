namespace GymMembershipManagementSystem
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.menuStripNavigation = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walkInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walkedinMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripTopNavigation = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minMaxSizeFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelHeaderMenu = new System.Windows.Forms.Label();
            this.labelClock = new System.Windows.Forms.Label();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calendarMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDate = new System.Windows.Forms.Label();
            this.spaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripNavigation.SuspendLayout();
            this.menuStripTopNavigation.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(228, 70);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1696, 928);
            this.panelContainer.TabIndex = 1;
            // 
            // menuStripNavigation
            // 
            this.menuStripNavigation.BackColor = System.Drawing.Color.White;
            this.menuStripNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStripNavigation.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripNavigation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.addMemberToolStripMenuItem,
            this.viewMemberToolStripMenuItem,
            this.regularMembersToolStripMenuItem,
            this.walkedinMemberToolStripMenuItem,
            this.updateMemberToolStripMenuItem,
            this.totalTransactionToolStripMenuItem});
            this.menuStripNavigation.Location = new System.Drawing.Point(0, 70);
            this.menuStripNavigation.Name = "menuStripNavigation";
            this.menuStripNavigation.Size = new System.Drawing.Size(228, 928);
            this.menuStripNavigation.TabIndex = 0;
            this.menuStripNavigation.Text = "menuStripRightNavigation";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardToolStripMenuItem.Image")));
            this.dashboardToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(210, 55);
            this.dashboardToolStripMenuItem.Text = "  Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // addMemberToolStripMenuItem
            // 
            this.addMemberToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addMemberToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthlyToolStripMenuItem,
            this.monthlyStudentToolStripMenuItem,
            this.walkInToolStripMenuItem});
            this.addMemberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addMemberToolStripMenuItem.Image")));
            this.addMemberToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addMemberToolStripMenuItem.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.addMemberToolStripMenuItem.Name = "addMemberToolStripMenuItem";
            this.addMemberToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.addMemberToolStripMenuItem.Size = new System.Drawing.Size(210, 55);
            this.addMemberToolStripMenuItem.Text = "  Add Member";
            // 
            // monthlyToolStripMenuItem
            // 
            this.monthlyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.monthlyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("monthlyToolStripMenuItem.Image")));
            this.monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
            this.monthlyToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.monthlyToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.monthlyToolStripMenuItem.Text = "Monthly (Student)";
            this.monthlyToolStripMenuItem.Click += new System.EventHandler(this.monthlyToolStripMenuItem_Click);
            // 
            // monthlyStudentToolStripMenuItem
            // 
            this.monthlyStudentToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.monthlyStudentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("monthlyStudentToolStripMenuItem.Image")));
            this.monthlyStudentToolStripMenuItem.Name = "monthlyStudentToolStripMenuItem";
            this.monthlyStudentToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.monthlyStudentToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.monthlyStudentToolStripMenuItem.Text = "Monthly (Not Student)";
            this.monthlyStudentToolStripMenuItem.Click += new System.EventHandler(this.monthlyStudentToolStripMenuItem_Click);
            // 
            // walkInToolStripMenuItem
            // 
            this.walkInToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.walkInToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("walkInToolStripMenuItem.Image")));
            this.walkInToolStripMenuItem.Name = "walkInToolStripMenuItem";
            this.walkInToolStripMenuItem.Padding = new System.Windows.Forms.Padding(5);
            this.walkInToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.walkInToolStripMenuItem.Text = "Walk in";
            this.walkInToolStripMenuItem.Click += new System.EventHandler(this.walkInToolStripMenuItem_Click);
            // 
            // viewMemberToolStripMenuItem
            // 
            this.viewMemberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewMemberToolStripMenuItem.Image")));
            this.viewMemberToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewMemberToolStripMenuItem.Name = "viewMemberToolStripMenuItem";
            this.viewMemberToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.viewMemberToolStripMenuItem.Size = new System.Drawing.Size(215, 55);
            this.viewMemberToolStripMenuItem.Text = "  Student Members";
            this.viewMemberToolStripMenuItem.Click += new System.EventHandler(this.viewMemberToolStripMenuItem_Click);
            // 
            // regularMembersToolStripMenuItem
            // 
            this.regularMembersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("regularMembersToolStripMenuItem.Image")));
            this.regularMembersToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.regularMembersToolStripMenuItem.Name = "regularMembersToolStripMenuItem";
            this.regularMembersToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.regularMembersToolStripMenuItem.Size = new System.Drawing.Size(215, 55);
            this.regularMembersToolStripMenuItem.Text = "  Regular Members";
            this.regularMembersToolStripMenuItem.Click += new System.EventHandler(this.regularMembersToolStripMenuItem_Click);
            // 
            // walkedinMemberToolStripMenuItem
            // 
            this.walkedinMemberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("walkedinMemberToolStripMenuItem.Image")));
            this.walkedinMemberToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.walkedinMemberToolStripMenuItem.Name = "walkedinMemberToolStripMenuItem";
            this.walkedinMemberToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.walkedinMemberToolStripMenuItem.Size = new System.Drawing.Size(215, 55);
            this.walkedinMemberToolStripMenuItem.Text = "  View Walked-in";
            this.walkedinMemberToolStripMenuItem.Click += new System.EventHandler(this.walkedinMemberToolStripMenuItem_Click);
            // 
            // updateMemberToolStripMenuItem
            // 
            this.updateMemberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateMemberToolStripMenuItem.Image")));
            this.updateMemberToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateMemberToolStripMenuItem.Name = "updateMemberToolStripMenuItem";
            this.updateMemberToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.updateMemberToolStripMenuItem.Size = new System.Drawing.Size(215, 55);
            this.updateMemberToolStripMenuItem.Text = "  Update Member";
            this.updateMemberToolStripMenuItem.Click += new System.EventHandler(this.updateMemberToolStripMenuItem_Click);
            // 
            // totalTransactionToolStripMenuItem
            // 
            this.totalTransactionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("totalTransactionToolStripMenuItem.Image")));
            this.totalTransactionToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalTransactionToolStripMenuItem.Name = "totalTransactionToolStripMenuItem";
            this.totalTransactionToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.totalTransactionToolStripMenuItem.Size = new System.Drawing.Size(215, 55);
            this.totalTransactionToolStripMenuItem.Text = "  Transaction";
            this.totalTransactionToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.totalTransactionToolStripMenuItem.Click += new System.EventHandler(this.totalTransactionToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 979);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Options";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.backToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backToolStripMenuItem.Image")));
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20);
            this.backToolStripMenuItem.Size = new System.Drawing.Size(64, 66);
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // notificationToolStripMenuItem
            // 
            this.notificationToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.notificationToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notificationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("notificationToolStripMenuItem.Image")));
            this.notificationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(1);
            this.notificationToolStripMenuItem.Name = "notificationToolStripMenuItem";
            this.notificationToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20);
            this.notificationToolStripMenuItem.Size = new System.Drawing.Size(64, 64);
            this.notificationToolStripMenuItem.Click += new System.EventHandler(this.notificationToolStripMenuItem_Click);
            // 
            // menuStripTopNavigation
            // 
            this.menuStripTopNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStripTopNavigation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStripTopNavigation.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStripTopNavigation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripTopNavigation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.minMaxSizeFormToolStripMenuItem,
            this.userToolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.notificationToolStripMenuItem,
            this.backToolStripMenuItem,
            this.archiveToolStripMenuItem});
            this.menuStripTopNavigation.Location = new System.Drawing.Point(0, 0);
            this.menuStripTopNavigation.Name = "menuStripTopNavigation";
            this.menuStripTopNavigation.Size = new System.Drawing.Size(1924, 70);
            this.menuStripTopNavigation.TabIndex = 2;
            this.menuStripTopNavigation.Text = "menuStripTopNavigation";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20);
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(64, 66);
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // minMaxSizeFormToolStripMenuItem
            // 
            this.minMaxSizeFormToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minMaxSizeFormToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("minMaxSizeFormToolStripMenuItem.Image")));
            this.minMaxSizeFormToolStripMenuItem.Name = "minMaxSizeFormToolStripMenuItem";
            this.minMaxSizeFormToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.minMaxSizeFormToolStripMenuItem.Size = new System.Drawing.Size(54, 66);
            this.minMaxSizeFormToolStripMenuItem.Click += new System.EventHandler(this.minMaxSizeFormToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem1
            // 
            this.userToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userToolStripMenuItem1.BackColor = System.Drawing.Color.Transparent;
            this.userToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("userToolStripMenuItem1.Image")));
            this.userToolStripMenuItem1.Name = "userToolStripMenuItem1";
            this.userToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(15);
            this.userToolStripMenuItem1.Size = new System.Drawing.Size(54, 66);
            this.userToolStripMenuItem1.Click += new System.EventHandler(this.userToolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Padding = new System.Windows.Forms.Padding(15);
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(54, 66);
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // labelHeaderMenu
            // 
            this.labelHeaderMenu.AutoSize = true;
            this.labelHeaderMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelHeaderMenu.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeaderMenu.ForeColor = System.Drawing.Color.Black;
            this.labelHeaderMenu.Location = new System.Drawing.Point(277, 19);
            this.labelHeaderMenu.Name = "labelHeaderMenu";
            this.labelHeaderMenu.Size = new System.Drawing.Size(328, 44);
            this.labelHeaderMenu.TabIndex = 4;
            this.labelHeaderMenu.Text = "C.H.C Dashboard";
            // 
            // labelClock
            // 
            this.labelClock.AutoSize = true;
            this.labelClock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.labelClock.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClock.ForeColor = System.Drawing.Color.White;
            this.labelClock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelClock.Location = new System.Drawing.Point(1800, 1012);
            this.labelClock.Name = "labelClock";
            this.labelClock.Size = new System.Drawing.Size(60, 19);
            this.labelClock.TabIndex = 5;
            this.labelClock.Text = "label2";
            // 
            // clockTimer
            // 
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarMenuToolStripMenuItem,
            this.logOutToolStripMenuItem1,
            this.spaceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 998);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15);
            this.menuStrip1.Size = new System.Drawing.Size(1924, 57);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calendarMenuToolStripMenuItem
            // 
            this.calendarMenuToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.calendarMenuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("calendarMenuToolStripMenuItem.Image")));
            this.calendarMenuToolStripMenuItem.Name = "calendarMenuToolStripMenuItem";
            this.calendarMenuToolStripMenuItem.Padding = new System.Windows.Forms.Padding(1);
            this.calendarMenuToolStripMenuItem.Size = new System.Drawing.Size(26, 27);
            this.calendarMenuToolStripMenuItem.Click += new System.EventHandler(this.calendarMenuToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem1
            // 
            this.logOutToolStripMenuItem1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.logOutToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("logOutToolStripMenuItem1.Image")));
            this.logOutToolStripMenuItem1.Name = "logOutToolStripMenuItem1";
            this.logOutToolStripMenuItem1.Padding = new System.Windows.Forms.Padding(1);
            this.logOutToolStripMenuItem1.Size = new System.Drawing.Size(113, 27);
            this.logOutToolStripMenuItem1.Text = "  Log Out";
            this.logOutToolStripMenuItem1.Click += new System.EventHandler(this.logOutToolStripMenuItem1_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.labelDate.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDate.Location = new System.Drawing.Point(1800, 1036);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(60, 19);
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "label2";
            // 
            // spaceToolStripMenuItem
            // 
            this.spaceToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.spaceToolStripMenuItem.Name = "spaceToolStripMenuItem";
            this.spaceToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.spaceToolStripMenuItem.Size = new System.Drawing.Size(98, 27);
            this.spaceToolStripMenuItem.Text = "refresh";
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.archiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archiveToolStripMenuItem.Image")));
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Padding = new System.Windows.Forms.Padding(20);
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(64, 66);
            this.archiveToolStripMenuItem.Click += new System.EventHandler(this.archiveToolStripMenuItem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelClock);
            this.Controls.Add(this.labelHeaderMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStripNavigation);
            this.Controls.Add(this.menuStripTopNavigation);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.menuStripNavigation.ResumeLayout(false);
            this.menuStripNavigation.PerformLayout();
            this.menuStripTopNavigation.ResumeLayout(false);
            this.menuStripTopNavigation.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.MenuStrip menuStripNavigation;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ToolStripMenuItem addMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walkInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStripTopNavigation;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyStudentToolStripMenuItem;
        public System.Windows.Forms.Label labelHeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularMembersToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Label labelClock;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem calendarMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.ToolStripMenuItem totalTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walkedinMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minMaxSizeFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
    }
}

