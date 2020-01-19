using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.IO;
using System.Diagnostics;
using BalanceDLL;
using System.Reflection;
using System.Xml.Serialization;
using HeatBalance.Class;
using System.Resources;
using System.Globalization;
using System.Threading;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;

namespace HeatBalance
{
    public partial class Form1 : Form
    {
       private object oMissing = System.Reflection.Missing.Value;

        // Главный объект, который включает в себя все нужные объекты
        public BalanceDLL.Balance HB = new BalanceDLL.Balance();

        #region   Объект для корректировки данных с помощью PropertyGrid
        private Class.DataInput_HB _DataInput;
        private List<HeatBalance.Class.Param> _allParamsInput = new List<HeatBalance.Class.Param>(), _paramsToReportInput = new List<HeatBalance.Class.Param>();
        private List<HeatBalance.Class.Param> _allParamsOutput = new List<HeatBalance.Class.Param>(), _paramsToReportOutput = new List<HeatBalance.Class.Param>();        
        #endregion
      
        // Создать объект для формирования отчета
        public frm_Report frmRpt;
                
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }
        ResourceManager LocRM = new ResourceManager("HeatBalance.WinFormStrings", typeof(Form1).Assembly);

        #region   Метод изменения надписи в строке статуса        

        public void StatusStripChanged(int intStatus)
        {
            
            switch (intStatus)
            {
                case 0:
                    this.toolStripStatusLabel1.Text = LocRM.GetString("case0");
                    break;

                case 1:
                    this.toolStripStatusLabel1.Text = LocRM.GetString("case1");
                    break;

                case 2:
                    this.toolStripStatusLabel1.Text = LocRM.GetString("case2");
                    break;

                case 3:
                    this.toolStripStatusLabel1.Text = LocRM.GetString("case3");
                    break;
                case 4:
                    this.toolStripStatusLabel1.Text = LocRM.GetString("case4");
                    break;
                case 5:
                    this.toolStripStatusLabel1.Text = LocRM.GetString("case5");
                    break;


                default:
                    break;
            }
            this.statusStrip1.Refresh();
            
        }
        #endregion

        #region   Загрузка и настройка формы

        private void Form1_Load(object sender, EventArgs e)
        {

            // Где будем искать .xml-файл с исходными данными 
            FileInfo fileDefaultUserAppDataPath = new FileInfo(Application.UserAppDataPath.ToString() + @"\\default.xml");

             // если файл найден, то десериализовать его
            {
                BalanceDLL.Balance _HB = new BalanceDLL.Balance();
                this.HB = _HB.LoadData(fileDefaultUserAppDataPath.ToString());
            }
            
           
            // Настроить элементы формы
            FormOptionDefault();
            StatusStripChanged(5); 
        }
        #endregion

        #region  Перевод текстов
        private void Russian()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            // Declare a Resource Manager instance.            
            btn_Diagramma.Text = LocRM.GetString("btn_DiagrammaText");
            btn_Exit.Text = LocRM.GetString("btn_ExitText");
            btn_Raschet.Text = LocRM.GetString("btn_RaschetText");
            btn_report.Text = LocRM.GetString("btn_reportText");            
            label48.Text = LocRM.GetString("label48Text");
            label51.Text = LocRM.GetString("label51Text");
            label53.Text = LocRM.GetString("label53Text");
            label57.Text = LocRM.GetString("label57Text");
            label59.Text = LocRM.GetString("label59Text");
            label60.Text = LocRM.GetString("label60Text");
            label61.Text = LocRM.GetString("label61Text");
            label62.Text = LocRM.GetString("label62Text");
            label63.Text = LocRM.GetString("label63Text");
            label64.Text = LocRM.GetString("label64Text");
            label67.Text = LocRM.GetString("label67Text");
            label68.Text = LocRM.GetString("label68Text");           
            tabPage2.Text = LocRM.GetString("tabPage2Text");
            tabPage3.Text = LocRM.GetString("tabPage3Text");                 
        }

        private void English()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            // Declare a Resource Manager instance.            
            btn_Diagramma.Text = LocRM.GetString("btn_DiagrammaText");
            btn_Exit.Text = LocRM.GetString("btn_ExitText");
            btn_Raschet.Text = LocRM.GetString("btn_RaschetText");
            btn_report.Text = LocRM.GetString("btn_reportText");            
            label48.Text = LocRM.GetString("label48Text");
            label51.Text = LocRM.GetString("label51Text");
            label53.Text = LocRM.GetString("label53Text");
            label57.Text = LocRM.GetString("label57Text");
            label59.Text = LocRM.GetString("label59Text");
            label60.Text = LocRM.GetString("label60Text");
            label61.Text = LocRM.GetString("label61Text");
            label62.Text = LocRM.GetString("label62Text");
            label63.Text = LocRM.GetString("label63Text");
            label64.Text = LocRM.GetString("label64Text");
            label67.Text = LocRM.GetString("label67Text");
            label68.Text = LocRM.GetString("label68Text");           
            tabPage2.Text = LocRM.GetString("tabPage2Text");
            tabPage3.Text = LocRM.GetString("tabPage3Text");               
        }
        #endregion

        #region  Настройка изначального вида формы
        private void FormOptionDefault()
        {
            btn_Diagramma.Enabled = false;
            btn_report.Enabled = false;   
            // Показать в заголовке главного окна номер текущей версии и пользвателя
            this.Text = this.Text + " [" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "]";
            // Установить редактируемый объект в PropertyGrid
            _DataInput = new DataInput_HB(HB);
            propertyGrid1.SelectedObject = _DataInput;
            //btn_OpenGR.Enabled = false;
            //btn_OpenReport.Enabled = false;

            string path = Application.UserAppDataPath.ToString() + @"\";

            #region -- Заполнить перечень показателей в отчет: исходные данные          
            if (File.Exists(path + "cfgInputToRep.xml"))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<HeatBalance.Class.Param>));
                FileStream fs = null;
                try
                {
                    // Исходные данные
                    fs = new FileStream(path + "cfgInputToRepDP1.xml", FileMode.Open);
                    _allParamsInput = (List<HeatBalance.Class.Param>)xmls.Deserialize(fs);

                }
                catch
                {
                }
                finally
                {
                    if (fs != null) fs.Close();
                }
            }
            else
            {
                DataInput_HB _dataIn = new DataInput_HB(HB);
                PropertyInfo[] pArrIn = _dataIn.GetType().GetProperties();
                if (pArrIn != null)
                    foreach (PropertyInfo p in pArrIn)
                    {
                        string descrIn = "";
                        object[] attrIn = p.GetCustomAttributes(false);
                        if (attrIn != null)
                            foreach (object a in attrIn)
                            {
                                if (a is DisplayNameAttribute) descrIn += (a as DisplayNameAttribute).DisplayName;
                                if (a is CategoryAttribute) descrIn = descrIn.Insert(0, (a as CategoryAttribute).Category + ", ");
                            }
                        HeatBalance.Class.Param parIn = new HeatBalance.Class.Param(0);
                        parIn.Description = descrIn;
                        parIn.IsReport = true;
                        parIn.PropertyName = p.Name;
                        _allParamsInput.Add(parIn);
                    }
            }           
            #endregion

            #region -- Заполнить перечень показателей в отчет: результаты расчета
            if (File.Exists(path + "cfgOutputToRep.xml"))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(List<HeatBalance.Class.Param>));
                FileStream fsOut = null;
                try
                {
                    fsOut = new FileStream(path + "cfgOutputToRep.xml", FileMode.Open);
                    _allParamsOutput = (List<HeatBalance.Class.Param>)xmls.Deserialize(fsOut);
                }
                catch
                {
                }
                finally
                {
                    if (fsOut != null) fsOut.Close();
                }
            }
            else
            {
                DataOutput _dataOut = new DataOutput(HB);
                PropertyInfo[] pArrOut = _dataOut.GetType().GetProperties();
                if (pArrOut != null)
                    foreach (PropertyInfo p in pArrOut)
                    {
                        string descrOut = "";
                        object[] attrOut = p.GetCustomAttributes(false);
                        if (attrOut != null)
                            foreach (object a in attrOut)
                            {
                                if (a is DisplayNameAttribute) descrOut += (a as DisplayNameAttribute).DisplayName;
                                if (a is CategoryAttribute) descrOut = descrOut.Insert(0, (a as CategoryAttribute).Category + ", ");
                            }
                        HeatBalance.Class.Param parOut = new HeatBalance.Class.Param(0);
                        parOut.Description = descrOut;
                        parOut.IsReport = true;
                        parOut.PropertyName = p.Name;
                        _allParamsOutput.Add(parOut);
                    }
            }
            #endregion
            
        }
        #endregion

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Raschet_Click(object sender, EventArgs e)
        {
            #region Статус(3) и устанавливание значений
            StatusStripChanged(3);
            var resultQ1 = HB.f_Q1();
            txt_Q1.Text = resultQ1.ToString("0.000");

            var resultQ2 = HB.f_Q2();
            txt_Q2.Text = resultQ2.ToString("0.000");

            var resultQ3 = HB.f_Q3();
            txt_Q3.Text = resultQ3.ToString("0.000");

            var resultQ5top = HB.f_Q5top();
            txt_Q5top.Text = resultQ5top.ToString("0.000");

            var resultQ5t = HB.f_Q5t();
            txt_Q5t.Text = resultQ5t.ToString("0.000");

            var resultQx = HB.f_Qx();
            txt_Qx.Text = resultQx.ToString("0.000");

            var resultQisp = HB.f_qisp();
            txt_Qisp.Text = resultQisp.ToString("0.000");

            var resultKPD = HB.f_Q1pr();
            txt_KPD.Text = resultKPD.ToString("0.000");

            var resultB = HB.f_B();
            txt_B.Text = resultB.ToString("0.000");

            var resultB1 = HB.f_B1();
            txt_B1.Text = resultB1.ToString("0.000");

            HB.Q1prRez = HB.f_Q1pr();
            txt_Q1pr.Text = HB.Q1prRez.ToString("0.000");

            HB.Q2prRez = HB.f_Q2pr();
            txt_Q2pr.Text = HB.Q2prRez.ToString("0.000");

            HB.Q3prRez = HB.f_Q3pr();
            txt_Q3pr.Text = HB.Q3prRez.ToString("0.000");

            HB.Q5topprRez = HB.f_Q5toppr();
            txt_Q5toppr.Text = HB.Q5topprRez.ToString("0.000");

            HB.Q4prRez = HB.f_Q5tpr();
            txt_Q5tpr.Text = HB.Q4prRez.ToString("0.000");

            var resultTB1 = HB.f_TB1();
            txt_TB1.Text = resultTB1.ToString("0.000");

            var resultTB2 = HB.f_TB2();
            txt_TB2.Text = resultTB2.ToString("0.000");
            #endregion

            tabControl1.SelectedIndex = 1;
            StatusStripChanged(2);
            btn_Diagramma.Enabled = true;
            btn_report.Enabled = true;
            
        }

        private void btn_Diagramma_Click(object sender, EventArgs e)
        {
            frmDiagramma D = new frmDiagramma(HB);
            D.ShowDialog();  
        }

        #region Метод чистки результата и изменение статуса(1)
        public void ClearRezult(object sender, EventArgs e)
        {
            btn_Diagramma.Enabled = false;
            btn_report.Enabled = false;
            txt_Q1.Text = "";
            txt_Q1pr.Text = "";
            txt_Q2.Text = "";
            txt_Q2pr.Text = "";
            txt_Q3.Text = "";
            txt_Q3pr.Text = "";
            txt_Q5t.Text = "";
            txt_Q5top.Text = "";
            txt_Q5toppr.Text = "";
            txt_Q5tpr.Text = "";
            txt_Qx.Text = "";
            txt_Qisp.Text = "";
            //txt_razn.Text = "";
            txt_TB1.Text = "";
            txt_TB2.Text = "";
            txt_KPD.Text = "";
            txt_B1.Text = "";
            txt_B.Text = "";
            StatusStripChanged(1);
        }
        #endregion

        private void btn_English_Click_1(object sender, EventArgs e)
        {
            English();
            StatusStripChanged(0);

        }

        private void btn_Russia_Click_1(object sender, EventArgs e)
        {
            Russian();
            StatusStripChanged(0);
        }
        
        private void btn_report_Click(object sender, EventArgs e)
        {

            CreateReportViewer();
        }
        private void CreateReportViewer()
        {
            frmRpt = new frm_Report();

            #region Подготовить данные для вывода в отчет

            // Исходные данные в отчет 
            DataInput_HB _DataInput_HB = new DataInput_HB(HB);
            List<cReportList> RepListInputHB = new List<cReportList>();
            foreach (HeatBalance.Class.Param par in _allParamsInput)
            {
                if (par.IsReport)
                {
                    if (_DataInput_HB.GetType().GetProperty(par.PropertyName).GetValue(_DataInput_HB, null) != null)
                    {
                        double d = Math.Round(Convert.ToDouble(
                            _DataInput_HB.GetType().GetProperty(par.PropertyName).GetValue(
                            _DataInput_HB, null)), 3);
                        RepListInputHB.Add(new HeatBalance.Class.cReportList(par.Description, d.ToString()));
                    }
                }
            }
            frmRpt.cReportInputBindingSource.DataSource = RepListInputHB;
            // Результаты расчета в отчет 
            DataOutput _dataOutput = new DataOutput(HB);
            List<cReportList> RepListOutput = new List<cReportList>();
            foreach (HeatBalance.Class.Param par in _allParamsOutput)
            {
                if (par.IsReport)
                {
                    double d = Math.Round(Convert.ToDouble(
                        _dataOutput.GetType().GetProperty(par.PropertyName).GetValue(_dataOutput, null)), 3);
                    RepListOutput.Add(new HeatBalance.Class.cReportList(par.Description, d.ToString()));
                }
            }
            #endregion

            #region Указать отчету источники данных                
            frmRpt.cReportInputBindingSource.DataSource = RepListInputHB;
            frmRpt.cReportOutputBindingSource.DataSource = RepListOutput;
            #endregion

            #region Показать окно отчета на весь экран
            frmRpt.WindowState = FormWindowState.Maximized;
            frmRpt.ShowDialog(this);
            #endregion
        }
    }
}
