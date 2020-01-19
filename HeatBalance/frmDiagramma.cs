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
using ZedGraph;

namespace HeatBalance
{
    public partial class frmDiagramma : Form
    {
        // Создать главный объект, который включает в себя все нужные объекты
        public BalanceDLL.Balance _HB = new BalanceDLL.Balance();

        public frmDiagramma() { }

        public frmDiagramma(BalanceDLL.Balance HB)
        {
            _HB = HB;
            InitializeComponent();
            CenterToScreen();
        }
        
        private void DrawGraph()
        {
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;
                        
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            //Количество параметров
            int itemscount = 5;
            
            // Подписи параметров
            string[] names = new string[itemscount];

            // Размер 
            double[] values = new double[itemscount];
            
            // Заполним данные
            for (int i = 0; i < itemscount; i++)
            {
                names[0] = string.Format("Q1");
                names[1] = string.Format("Q2");
                names[2] = string.Format("Q3");
                names[3] = string.Format("Q5т");
                names[4] = string.Format("Q5топ");
                values[0] = _HB.Q1prRez;
                values[1] = _HB.Q2prRez;
                values[2] = _HB.Q3prRez;
                values[3] = _HB.Q4prRez;
                values[4] = _HB.Q5topprRez;
            }
            // Круговая диаграмма с выбором цвета
            pane.AddPieSlice(values[0], Color.Tan, 0F, names[0]);
            pane.AddPieSlice(values[1], Color.PeachPuff, 0F, names[1]);
            pane.AddPieSlice(values[2], Color.Peru, 0F, names[2]);
            pane.AddPieSlice(values[3], Color.NavajoWhite, 0F, names[3]);
            pane.AddPieSlice(values[4], Color.SandyBrown, 0F, names[4]);

            //pane.AddPieSlices(values, names); // цвет устанавливается автоматически
            pane.Legend.IsVisible = false;
            foreach (var x in pane.CurveList.OfType<PieItem>())
                x.LabelType = PieLabelType.Name_Percent;

            // Изменим текст заголовка графика
            pane.Title.Text = "Результат расчета теплового баланса сушильного барабана";

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }
        
        private void btn_Graf_Click_1(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
