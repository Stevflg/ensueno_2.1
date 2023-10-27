namespace ensueno.Presentation.Main
{
    partial class Form_invoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_invoice));
            this.Button_delete = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Button_update = new Guna.UI2.WinForms.Guna2GradientButton();
            this.DataGridView_invoices = new Guna.UI2.WinForms.Guna2DataGridView();
            this.TextBox_client_id = new Guna.UI2.WinForms.Guna2TextBox();
            this.Button_report = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Button_Create = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TextBox_invoice_id = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Button_history = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Button_clear = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Button_detail = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TextBox_search_by_id = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_invoices)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_delete
            // 
            this.Button_delete.Animated = true;
            this.Button_delete.AutoRoundedCorners = true;
            this.Button_delete.BorderRadius = 16;
            this.Button_delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_delete.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_delete.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_delete.ForeColor = System.Drawing.Color.White;
            this.Button_delete.IndicateFocus = true;
            this.Button_delete.Location = new System.Drawing.Point(643, 396);
            this.Button_delete.Name = "Button_delete";
            this.Button_delete.Size = new System.Drawing.Size(185, 35);
            this.Button_delete.TabIndex = 43;
            this.Button_delete.Text = "ELIMINAR";
            this.Button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // Button_update
            // 
            this.Button_update.Animated = true;
            this.Button_update.AutoRoundedCorners = true;
            this.Button_update.BorderRadius = 16;
            this.Button_update.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_update.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_update.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_update.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_update.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_update.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_update.ForeColor = System.Drawing.Color.White;
            this.Button_update.IndicateFocus = true;
            this.Button_update.Location = new System.Drawing.Point(643, 355);
            this.Button_update.Name = "Button_update";
            this.Button_update.Size = new System.Drawing.Size(185, 35);
            this.Button_update.TabIndex = 42;
            this.Button_update.Text = "ACTUALIZAR";
            this.Button_update.Click += new System.EventHandler(this.Button_update_Click);
            // 
            // DataGridView_invoices
            // 
            this.DataGridView_invoices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_invoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView_invoices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_invoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView_invoices.ColumnHeadersHeight = 22;
            this.DataGridView_invoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(129)))), ((int)(((byte)(121)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView_invoices.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView_invoices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(189)))), ((int)(((byte)(184)))));
            this.DataGridView_invoices.Location = new System.Drawing.Point(7, 108);
            this.DataGridView_invoices.Name = "DataGridView_invoices";
            this.DataGridView_invoices.ReadOnly = true;
            this.DataGridView_invoices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView_invoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView_invoices.RowHeadersVisible = false;
            this.DataGridView_invoices.Size = new System.Drawing.Size(630, 380);
            this.DataGridView_invoices.TabIndex = 45;
            this.DataGridView_invoices.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Red;
            this.DataGridView_invoices.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(199)))), ((int)(((byte)(195)))));
            this.DataGridView_invoices.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_invoices.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridView_invoices.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridView_invoices.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridView_invoices.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridView_invoices.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(189)))), ((int)(((byte)(184)))));
            this.DataGridView_invoices.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.DataGridView_invoices.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridView_invoices.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_invoices.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridView_invoices.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridView_invoices.ThemeStyle.HeaderStyle.Height = 22;
            this.DataGridView_invoices.ThemeStyle.ReadOnly = true;
            this.DataGridView_invoices.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(217)))), ((int)(((byte)(215)))));
            this.DataGridView_invoices.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridView_invoices.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridView_invoices.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataGridView_invoices.ThemeStyle.RowsStyle.Height = 22;
            this.DataGridView_invoices.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(129)))), ((int)(((byte)(121)))));
            this.DataGridView_invoices.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridView_invoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_invoices_CellClick);
            // 
            // TextBox_client_id
            // 
            this.TextBox_client_id.Animated = true;
            this.TextBox_client_id.BorderColor = System.Drawing.Color.Crimson;
            this.TextBox_client_id.BorderRadius = 11;
            this.TextBox_client_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_client_id.DefaultText = "";
            this.TextBox_client_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_client_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_client_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_client_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_client_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_client_id.Font = new System.Drawing.Font("Britannic Bold", 11.25F);
            this.TextBox_client_id.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_client_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_client_id.Location = new System.Drawing.Point(643, 149);
            this.TextBox_client_id.MaxLength = 50;
            this.TextBox_client_id.Name = "TextBox_client_id";
            this.TextBox_client_id.PasswordChar = '\0';
            this.TextBox_client_id.PlaceholderForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_client_id.PlaceholderText = "Id Cliente";
            this.TextBox_client_id.SelectedText = "";
            this.TextBox_client_id.Size = new System.Drawing.Size(185, 35);
            this.TextBox_client_id.TabIndex = 50;
            this.TextBox_client_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_client_id_KeyPress);
            // 
            // Button_report
            // 
            this.Button_report.Animated = true;
            this.Button_report.AutoRoundedCorners = true;
            this.Button_report.BorderRadius = 16;
            this.Button_report.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_report.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_report.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_report.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_report.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_report.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_report.ForeColor = System.Drawing.Color.White;
            this.Button_report.IndicateFocus = true;
            this.Button_report.Location = new System.Drawing.Point(643, 314);
            this.Button_report.Name = "Button_report";
            this.Button_report.Size = new System.Drawing.Size(185, 35);
            this.Button_report.TabIndex = 53;
            this.Button_report.Text = "REPORTE";
            this.Button_report.Click += new System.EventHandler(this.Button_report_Click);
            // 
            // Button_Create
            // 
            this.Button_Create.Animated = true;
            this.Button_Create.AutoRoundedCorners = true;
            this.Button_Create.BorderRadius = 16;
            this.Button_Create.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_Create.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_Create.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_Create.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_Create.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_Create.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_Create.ForeColor = System.Drawing.Color.White;
            this.Button_Create.IndicateFocus = true;
            this.Button_Create.Location = new System.Drawing.Point(643, 217);
            this.Button_Create.Name = "Button_Create";
            this.Button_Create.Size = new System.Drawing.Size(185, 35);
            this.Button_Create.TabIndex = 59;
            this.Button_Create.Text = "CREAR";
            this.Button_Create.Click += new System.EventHandler(this.Button_Create_Click);
            // 
            // TextBox_invoice_id
            // 
            this.TextBox_invoice_id.Animated = true;
            this.TextBox_invoice_id.BorderColor = System.Drawing.Color.Crimson;
            this.TextBox_invoice_id.BorderRadius = 11;
            this.TextBox_invoice_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_invoice_id.DefaultText = "";
            this.TextBox_invoice_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_invoice_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_invoice_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_invoice_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_invoice_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_invoice_id.Font = new System.Drawing.Font("Britannic Bold", 11.25F);
            this.TextBox_invoice_id.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_invoice_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_invoice_id.Location = new System.Drawing.Point(643, 108);
            this.TextBox_invoice_id.MaxLength = 50;
            this.TextBox_invoice_id.Name = "TextBox_invoice_id";
            this.TextBox_invoice_id.PasswordChar = '\0';
            this.TextBox_invoice_id.PlaceholderForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_invoice_id.PlaceholderText = "Id Factura";
            this.TextBox_invoice_id.SelectedText = "";
            this.TextBox_invoice_id.Size = new System.Drawing.Size(185, 35);
            this.TextBox_invoice_id.TabIndex = 60;
            this.TextBox_invoice_id.TextChanged += new System.EventHandler(this.TextBox_invoice_id_TextChanged);
            this.TextBox_invoice_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_invoice_id_KeyPress);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.HasFormShadow = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ComboBox1
            // 
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Location = new System.Drawing.Point(643, 190);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(185, 21);
            this.ComboBox1.TabIndex = 61;
            this.ComboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // Button_history
            // 
            this.Button_history.Animated = true;
            this.Button_history.AutoRoundedCorners = true;
            this.Button_history.BorderRadius = 16;
            this.Button_history.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_history.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_history.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_history.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_history.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_history.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_history.ForeColor = System.Drawing.Color.White;
            this.Button_history.IndicateFocus = true;
            this.Button_history.Location = new System.Drawing.Point(643, 437);
            this.Button_history.Name = "Button_history";
            this.Button_history.Size = new System.Drawing.Size(185, 35);
            this.Button_history.TabIndex = 62;
            this.Button_history.Text = "HISTORIAL";
            this.Button_history.Click += new System.EventHandler(this.Button_history_Click);
            // 
            // Button_clear
            // 
            this.Button_clear.Animated = true;
            this.Button_clear.BackColor = System.Drawing.Color.Transparent;
            this.Button_clear.BorderColor = System.Drawing.Color.Crimson;
            this.Button_clear.BorderThickness = 2;
            this.Button_clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_clear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Button_clear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Button_clear.ForeColor = System.Drawing.Color.White;
            this.Button_clear.Image = global::ensueno.Properties.Resources.clean;
            this.Button_clear.ImageSize = new System.Drawing.Size(32, 32);
            this.Button_clear.Location = new System.Drawing.Point(557, 33);
            this.Button_clear.Name = "Button_clear";
            this.Button_clear.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Button_clear.Size = new System.Drawing.Size(50, 50);
            this.Button_clear.TabIndex = 63;
            this.Button_clear.UseTransparentBackground = true;
            this.Button_clear.Click += new System.EventHandler(this.Button_clear_Click);
            // 
            // Button_detail
            // 
            this.Button_detail.Animated = true;
            this.Button_detail.AutoRoundedCorners = true;
            this.Button_detail.BorderRadius = 24;
            this.Button_detail.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Button_detail.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Button_detail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_detail.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Button_detail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Button_detail.Font = new System.Drawing.Font("Britannic Bold", 14.25F);
            this.Button_detail.ForeColor = System.Drawing.Color.White;
            this.Button_detail.IndicateFocus = true;
            this.Button_detail.Location = new System.Drawing.Point(643, 258);
            this.Button_detail.Name = "Button_detail";
            this.Button_detail.Size = new System.Drawing.Size(185, 50);
            this.Button_detail.TabIndex = 64;
            this.Button_detail.Text = "VER DETALLE DE FACTURA";
            this.Button_detail.Click += new System.EventHandler(this.Button_detail_Click);
            // 
            // TextBox_search_by_id
            // 
            this.TextBox_search_by_id.Animated = true;
            this.TextBox_search_by_id.BorderColor = System.Drawing.Color.Crimson;
            this.TextBox_search_by_id.BorderRadius = 11;
            this.TextBox_search_by_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox_search_by_id.DefaultText = "";
            this.TextBox_search_by_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBox_search_by_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBox_search_by_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_search_by_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBox_search_by_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_search_by_id.Font = new System.Drawing.Font("Britannic Bold", 11.25F);
            this.TextBox_search_by_id.ForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_search_by_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBox_search_by_id.Location = new System.Drawing.Point(88, 67);
            this.TextBox_search_by_id.MaxLength = 50;
            this.TextBox_search_by_id.Name = "TextBox_search_by_id";
            this.TextBox_search_by_id.PasswordChar = '\0';
            this.TextBox_search_by_id.PlaceholderForeColor = System.Drawing.SystemColors.GrayText;
            this.TextBox_search_by_id.PlaceholderText = "Buscar Factura por Id";
            this.TextBox_search_by_id.SelectedText = "";
            this.TextBox_search_by_id.Size = new System.Drawing.Size(185, 35);
            this.TextBox_search_by_id.TabIndex = 65;
            this.TextBox_search_by_id.TextChanged += new System.EventHandler(this.TextBox_search_by_id_TextChanged);
            this.TextBox_search_by_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_search_by_id_KeyPress);
            // 
            // Form_invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Controls.Add(this.TextBox_search_by_id);
            this.Controls.Add(this.Button_detail);
            this.Controls.Add(this.Button_clear);
            this.Controls.Add(this.Button_history);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.TextBox_invoice_id);
            this.Controls.Add(this.Button_Create);
            this.Controls.Add(this.Button_report);
            this.Controls.Add(this.TextBox_client_id);
            this.Controls.Add(this.DataGridView_invoices);
            this.Controls.Add(this.Button_delete);
            this.Controls.Add(this.Button_update);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_invoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Form_invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_invoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton Button_delete;
        private Guna.UI2.WinForms.Guna2GradientButton Button_update;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridView_invoices;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_client_id;
        private Guna.UI2.WinForms.Guna2GradientButton Button_report;
        private Guna.UI2.WinForms.Guna2GradientButton Button_Create;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_invoice_id;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.ComboBox ComboBox1;
        private Guna.UI2.WinForms.Guna2GradientButton Button_history;
        private Guna.UI2.WinForms.Guna2CircleButton Button_clear;
        private Guna.UI2.WinForms.Guna2GradientButton Button_detail;
        private Guna.UI2.WinForms.Guna2TextBox TextBox_search_by_id;
    }
}