namespace GymMembershipManagementSystem
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelLoginFormConatainer = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelClock = new System.Windows.Forms.Label();
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.roundedPanel2 = new GymMembershipManagementSystem.Classes.roundedPanel();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundedPanel1 = new GymMembershipManagementSystem.Classes.roundedPanel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBoxKey = new System.Windows.Forms.PictureBox();
            this.clockTimer = new System.Windows.Forms.Timer(this.components);
            this.panelContainer.SuspendLayout();
            this.panelLoginFormConatainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKey)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContainer.Controls.Add(this.panelLoginFormConatainer);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(990, 571);
            this.panelContainer.TabIndex = 1;
            // 
            // panelLoginFormConatainer
            // 
            this.panelLoginFormConatainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelLoginFormConatainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLoginFormConatainer.Controls.Add(this.pictureBox3);
            this.panelLoginFormConatainer.Controls.Add(this.label1);
            this.panelLoginFormConatainer.Controls.Add(this.buttonLogin);
            this.panelLoginFormConatainer.Controls.Add(this.labelClock);
            this.panelLoginFormConatainer.Controls.Add(this.checkBoxPassword);
            this.panelLoginFormConatainer.Controls.Add(this.roundedPanel2);
            this.panelLoginFormConatainer.Controls.Add(this.roundedPanel1);
            this.panelLoginFormConatainer.Location = new System.Drawing.Point(254, 75);
            this.panelLoginFormConatainer.Name = "panelLoginFormConatainer";
            this.panelLoginFormConatainer.Size = new System.Drawing.Size(465, 417);
            this.panelLoginFormConatainer.TabIndex = 18;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(440, 3);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(20, 20);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(20, 20);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(146, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Login";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLogin.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonLogin.Location = new System.Drawing.Point(37, 296);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(121, 51);
            this.buttonLogin.TabIndex = 8;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // labelClock
            // 
            this.labelClock.AutoSize = true;
            this.labelClock.BackColor = System.Drawing.Color.Transparent;
            this.labelClock.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClock.ForeColor = System.Drawing.Color.White;
            this.labelClock.Location = new System.Drawing.Point(44, 269);
            this.labelClock.Name = "labelClock";
            this.labelClock.Size = new System.Drawing.Size(52, 20);
            this.labelClock.TabIndex = 17;
            this.labelClock.Text = "Clock";
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPassword.ForeColor = System.Drawing.Color.White;
            this.checkBoxPassword.Location = new System.Drawing.Point(278, 269);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(145, 24);
            this.checkBoxPassword.TabIndex = 10;
            this.checkBoxPassword.Text = "Show Password";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            this.checkBoxPassword.CheckedChanged += new System.EventHandler(this.checkBoxPassword_CheckedChanged);
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.Controls.Add(this.textBoxUserName);
            this.roundedPanel2.Controls.Add(this.pictureBox1);
            this.roundedPanel2.CornerRadius = 30;
            this.roundedPanel2.Location = new System.Drawing.Point(37, 118);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Padding = new System.Windows.Forms.Padding(10);
            this.roundedPanel2.Size = new System.Drawing.Size(386, 50);
            this.roundedPanel2.TabIndex = 22;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.BackColor = System.Drawing.Color.White;
            this.textBoxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUserName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(14, 13);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(322, 23);
            this.textBoxUserName.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(340, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Controls.Add(this.textBoxPassword);
            this.roundedPanel1.Controls.Add(this.pictureBoxKey);
            this.roundedPanel1.CornerRadius = 30;
            this.roundedPanel1.Location = new System.Drawing.Point(37, 208);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.roundedPanel1.Size = new System.Drawing.Size(386, 50);
            this.roundedPanel1.TabIndex = 21;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.Location = new System.Drawing.Point(14, 13);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(322, 23);
            this.textBoxPassword.TabIndex = 7;
            // 
            // pictureBoxKey
            // 
            this.pictureBoxKey.BackColor = System.Drawing.Color.White;
            this.pictureBoxKey.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxKey.Image")));
            this.pictureBoxKey.Location = new System.Drawing.Point(340, 9);
            this.pictureBoxKey.Name = "pictureBoxKey";
            this.pictureBoxKey.Size = new System.Drawing.Size(34, 30);
            this.pictureBoxKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxKey.TabIndex = 7;
            this.pictureBoxKey.TabStop = false;
            // 
            // clockTimer
            // 
            this.clockTimer.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(990, 571);
            this.Controls.Add(this.panelContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.panelContainer.ResumeLayout(false);
            this.panelLoginFormConatainer.ResumeLayout(false);
            this.panelLoginFormConatainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox pictureBoxKey;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.CheckBox checkBoxPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer clockTimer;
        private System.Windows.Forms.Label labelClock;
        private System.Windows.Forms.Panel panelLoginFormConatainer;
        private System.Windows.Forms.Label label1;
        private Classes.roundedPanel roundedPanel1;
        private Classes.roundedPanel roundedPanel2;
    }
}