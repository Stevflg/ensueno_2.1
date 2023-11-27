namespace ensueno.Presentation.Reports
{
    partial class Form_Employee_Report
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            ReportViewerEmployee = new Microsoft.Reporting.WinForms.ReportViewer();
            labelTitle = new System.Windows.Forms.Label();
            PanelHead = new Guna.UI2.WinForms.Guna2Panel();
            PanelHead.SuspendLayout();
            SuspendLayout();
            // 
            // ReportViewerEmployee
            // 
            ReportViewerEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            ReportViewerEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            ReportViewerEmployee.Location = new System.Drawing.Point(0, 36);
            ReportViewerEmployee.Name = "ReportViewer";
            ReportViewerEmployee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            ReportViewerEmployee.ServerReport.BearerToken = null;
            ReportViewerEmployee.ServerReport.ReportPath = "EmployeeReport.rdlc";
            ReportViewerEmployee.Size = new System.Drawing.Size(635, 414);
            ReportViewerEmployee.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelTitle.ForeColor = System.Drawing.Color.White;
            labelTitle.Location = new System.Drawing.Point(258, 8);
            labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(99, 21);
            labelTitle.TabIndex = 9;
            labelTitle.Text = "Empleados";
            // 
            // PanelHead
            // 
            PanelHead.BackColor = System.Drawing.Color.Gray;
            PanelHead.Controls.Add(labelTitle);
            PanelHead.CustomizableEdges = customizableEdges1;
            PanelHead.Dock = System.Windows.Forms.DockStyle.Top;
            PanelHead.Location = new System.Drawing.Point(0, 0);
            PanelHead.Name = "PanelHead";
            PanelHead.ShadowDecoration.CustomizableEdges = customizableEdges2;
            PanelHead.Size = new System.Drawing.Size(635, 36);
            PanelHead.TabIndex = 0;
            // 
            // Form_Employee_Report
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(635, 450);
            Controls.Add(ReportViewerEmployee);
            Controls.Add(PanelHead);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Form_Employee_Report";
            Text = "Form_Employee_Report";
            Load += Form_Employee_Report_Load;
            PanelHead.ResumeLayout(false);
            PanelHead.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewerEmployee;
        private System.Windows.Forms.Label labelTitle;
        private Guna.UI2.WinForms.Guna2Panel PanelHead;
    }
}