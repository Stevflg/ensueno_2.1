namespace ensueno.Presentation.Login
{
    partial class Form_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_login));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Switch_dark_mode = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.Button_dark_mode = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.Button_login = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Button_database = new Guna.UI2.WinForms.Guna2CircleButton();
            this.TextBox_password = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextBox_user = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Label_about = new System.Windows.Forms.LinkLabel();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.Switch_dark_mode);
            this.guna2Panel1.Controls.Add(this.Button_dark_mode);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel1.Controls.Add(this.guna2ControlBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(550, 50);
            this.guna2Panel1.TabIndex = 8;
            // 
            // Switch_dark_mode
            // 
            this.Switch_dark_mode.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Switch_dark_mode.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Switch_dark_mode.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.Switch_dark_mode.CheckedState.InnerColor = System.Drawing.Color.White;
            this.Switch_dark_mode.Location = new System.Drawing.Point(59, 12);
            this.Switch_dark_mode.Name = "Switch_dark_mode";
            this.Switch_dark_mode.Size = new System.Drawing.Size(35, 20);
            this.Switch_dark_mode.TabIndex = 3;
            this.Switch_dark_mode.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Switch_dark_mode.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Switch_dark_mode.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.Switch_dark_mode.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.Switch_dark_mode.CheckedChanged += new System.EventHandler(this.Switch_dark_mode_CheckedChanged);
            // 
            // Button_dark_mode
            // 
            this.Button_dark_mode.Animated = true;
            this.Button_dark_mode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_dark_mode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_dark_mode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_dark_mode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_dark_mode.FillColor = System.Drawing.Color.Transparent;
            this.Button_dark_mode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button_dark_mode.ForeColor = System.Drawing.Color.White;
            this.Button_dark_mode.Image = global::ensueno.Properties.Resources.day_and_night;
            this.Button_dark_mode.ImageSize = new System.Drawing.Size(48, 48);
            this.Button_dark_mode.IndicateFocus = true;
            this.Button_dark_mode.Location = new System.Drawing.Point(3, 0);
            this.Button_dark_mode.Name = "Button_dark_mode";
            this.Button_dark_mode.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Button_dark_mode.Size = new System.Drawing.Size(50, 50);
            this.Button_dark_mode.TabIndex = 4;
            this.Button_dark_mode.Click += new System.EventHandler(this.Button_dark_mode_Click);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(442, 3);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 6;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(493, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 7;
            // 
            // Button_login
            // 
            this.Button_login.Animated = true;
            this.Button_login.AutoRoundedCorners = true;
            this.Button_login.BorderRadius = 21;
            this.Button_login.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_login.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_login.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_login.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_login.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_login.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_login.ForeColor = System.Drawing.Color.White;
            this.Button_login.IndicateFocus = true;
            this.Button_login.Location = new System.Drawing.Point(308, 190);
            this.Button_login.Name = "Button_login";
            this.Button_login.Size = new System.Drawing.Size(230, 45);
            this.Button_login.TabIndex = 2;
            this.Button_login.Text = "LOGIN";
            this.Button_login.Click += new System.EventHandler(this.Button_login_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.guna2Panel1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // Button_database
            // 
            this.Button_database.Animated = true;
            this.Button_database.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_database.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_database.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_database.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_database.FillColor = System.Drawing.Color.Transparent;
            this.Button_database.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button_database.ForeColor = System.Drawing.Color.White;
            this.Button_database.Image = global::ensueno.Properties.Resources.database;
            this.Button_database.ImageSize = new System.Drawing.Size(48, 48);
            this.Button_database.IndicateFocus = true;
            this.Button_database.Location = new System.Drawing.Point(3, 217);
            this.Button_database.Name = "Button_database";
            this.Button_database.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Button_database.Size = new System.Drawing.Size(50, 50);
            this.Button_database.TabIndex = 5;
            this.Button_database.Click += new System.EventHandler(this.Button_database_Click);
            // 
            // TextBox_password
            // 
            this.TextBox_password.Animated = true;
            this.TextBox_password.BorderColor = System.Drawing.Color.Crimson;
            this.TextBox_password.BorderRadius = 11;
            this.TextBox_password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_password.DefaultText = "";
            this.TextBox_password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_password.Font = new System.Drawing.Font("Britannic Bold", 11.25F);
            this.TextBox_password.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_password.IconLeft = global::ensueno.Properties.Resources.password;
            this.TextBox_password.Location = new System.Drawing.Point(308, 126);
            this.TextBox_password.Name = "TextBox_password";
            this.TextBox_password.PasswordChar = '●';
            this.TextBox_password.PlaceholderForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_password.PlaceholderText = "Contraseña";
            this.TextBox_password.SelectedText = "";
            this.TextBox_password.Size = new System.Drawing.Size(230, 45);
            this.TextBox_password.TabIndex = 1;
            this.TextBox_password.UseSystemPasswordChar = true;
            this.TextBox_password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_password_KeyDown);
            // 
            // TextBox_user
            // 
            this.TextBox_user.Animated = true;
            this.TextBox_user.BorderColor = System.Drawing.Color.Crimson;
            this.TextBox_user.BorderRadius = 11;
            this.TextBox_user.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_user.DefaultText = "";
            this.TextBox_user.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_user.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_user.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_user.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_user.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_user.Font = new System.Drawing.Font("Britannic Bold", 11.25F);
            this.TextBox_user.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_user.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_user.IconLeft = global::ensueno.Properties.Resources.user;
            this.TextBox_user.Location = new System.Drawing.Point(308, 75);
            this.TextBox_user.Name = "TextBox_user";
            this.TextBox_user.PasswordChar = '\0';
            this.TextBox_user.PlaceholderForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_user.PlaceholderText = "Usuario";
            this.TextBox_user.SelectedText = "";
            this.TextBox_user.Size = new System.Drawing.Size(230, 45);
            this.TextBox_user.TabIndex = 0;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::ensueno.Properties.Resources.logo_with_letters;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(59, 56);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(192, 192);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Label_about
            // 
            this.Label_about.AutoSize = true;
            this.Label_about.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_about.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Label_about.Location = new System.Drawing.Point(374, 240);
            this.Label_about.Name = "Label_about";
            this.Label_about.Size = new System.Drawing.Size(102, 21);
            this.Label_about.TabIndex = 9;
            this.Label_about.TabStop = true;
            this.Label_about.Text = "ACERCA DE";
            this.Label_about.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.Label_about.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Label_about_LinkClicked);
            // 
            // Form_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 270);
            this.Controls.Add(this.Label_about);
            this.Controls.Add(this.Button_database);
            this.Controls.Add(this.Button_login);
            this.Controls.Add(this.TextBox_password);
            this.Controls.Add(this.TextBox_user);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_login_FormClosed);
            this.BackColorChanged += new System.EventHandler(this.Form_login_BackColorChanged);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2GradientButton Button_login;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_password;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_user;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2CircleButton Button_dark_mode;
        private Guna.UI2.WinForms.Guna2ToggleSwitch Switch_dark_mode;
        private Guna.UI2.WinForms.Guna2CircleButton Button_database;
        private System.Windows.Forms.LinkLabel Label_about;
    }
}