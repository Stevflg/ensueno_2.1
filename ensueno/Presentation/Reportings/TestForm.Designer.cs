namespace ensueno.Presentation.Reportings
{
    partial class TestForm
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
            reportViewerEmployees = new Microsoft.Reporting.WinForms.ReportViewer();
            SuspendLayout();
            // 
            // reportViewerEmployees
            // 
            reportViewerEmployees.Location = new System.Drawing.Point(0, 0);
            reportViewerEmployees.Name = "ReportViewer";
            reportViewerEmployees.ServerReport.BearerToken = null;
            reportViewerEmployees.Size = new System.Drawing.Size(687, 421);
            reportViewerEmployees.TabIndex = 0;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(687, 421);
            this.Controls.Add(this.reportViewerEmployees);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "TestForm";
            Text = "TestForm";
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerEmployees;
    }
}