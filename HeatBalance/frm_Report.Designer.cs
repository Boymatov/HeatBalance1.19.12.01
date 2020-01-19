namespace HeatBalance
{
    partial class frm_Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.cReportInputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cReportOutputBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.cReportInputBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cReportOutputBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cReportInputBindingSource
            // 
            this.cReportInputBindingSource.DataSource = typeof(HeatBalance.Class.cReportInput);
            // 
            // cReportOutputBindingSource
            // 
            this.cReportOutputBindingSource.DataSource = typeof(HeatBalance.Class.cReportOutput);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DS_report_Input";
            reportDataSource1.Value = this.cReportInputBindingSource;
            reportDataSource2.Name = "DS_Report_Output";
            reportDataSource2.Value = this.cReportOutputBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HeatBalance.Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(475, 417);
            this.reportViewer1.TabIndex = 0;
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 417);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_Report";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.frm_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cReportInputBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cReportOutputBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.BindingSource cReportInputBindingSource;
        public System.Windows.Forms.BindingSource cReportOutputBindingSource;
    }
}