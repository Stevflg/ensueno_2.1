using Aplicacion.Reporting;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace ensueno.Presentation.Reports
{
    public partial class Form_Employee_Report : Form
    {
        private readonly EmployeeReport Ereport= new EmployeeReport();
        public Form_Employee_Report()
        {
            InitializeComponent();
        }

        private void Form_Employee_Report_Load(object sender, EventArgs e)
        {
            var datasource = Ereport.ListEmployee();
            ReportDataSource source = new ReportDataSource("EmployeeReport", datasource);
            this.ReportViewerEmployee.LocalReport.DataSources.Clear();
            this.ReportViewerEmployee.LocalReport.DataSources.Add(source);
            this.ReportViewerEmployee.Refresh();
            this.ReportViewerEmployee.RefreshReport();
        }
    }
}
