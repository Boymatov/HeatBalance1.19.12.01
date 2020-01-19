using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BalanceDLL;

namespace HeatBalance.Class
{
    [Serializable]
    public class DataOutput
    {
        #region ---Результат расчета теплового баланса сушильного барабана
        /// <summary>
        /// Расход теплоты на прогревание просушиваемых материалов и испарение влаги
        /// </summary>
        [Description("Расход теплоты на прогревание просушиваемых материалов и испарение влаги, Q1, кВт")]
        [DisplayName("Расход теплоты на прогревание просушиваемых материалов и испарение влаги, Q1, кВт")]
        public double Get_Q1
        {
            get { return _HB.f_Q1(); }
        }
        /// <summary>
        /// Потери теплоты с отходящими газами
        /// </summary>
        [Description("Потери теплоты с отходящими газами, Q2, кВт")]
        [DisplayName("Потери теплоты с отходящими газами, Q2, кВт")]
        public double Get_Q2
        {
            get { return _HB.f_Q2(); }
        }
        /// <summary>
        /// Потери теплоты с химическим недожогом
        /// </summary>
        [Description("Потери теплоты с химическим недожогом, Q3, кВт")]
        [DisplayName("Потери теплоты с химическим недожогом, Q3, кВт")]
        public double Get_Q3
        {
            get { return _HB.f_Q3(); ; }
        }
        /// <summary>
        /// Потери телпоты вследствие теплопроводности стенок рабочего пространства
        /// </summary>
        [Description("Потери телпоты вследствие теплопроводности стенок рабочего пространства, Q5т, кВт")]
        [DisplayName("Потери телпоты вследствие теплопроводности стенок рабочего пространства, Q5т, кВт")]
        public double Get_Q5t
        {
            get { return _HB.f_Q5t(); }
        }
        /// <summary>
        /// Потери теплоты топкой
        /// </summary>
        [Description("Потери теплоты топкой, Q5топ, кВт")]
        [DisplayName("Потери теплоты топкой, Q5топ, кВт")]
        public double Get_Q5top
        {
            get { return _HB.f_Q5top(); }
        }
        /// <summary>
        /// Тепловая мощность печи
        /// </summary>
        [Description("Тепловая мощность печи, кВт")]
        [DisplayName("Тепловая мощность печи, кВт")]
        public double Get_Qx
        {
            get { return _HB.f_Qx(); }
        }
        /// <summary>
        /// Расход теплоты на 1 кг испаренной влаги
        /// </summary>
        [Description("Расход теплоты на 1 кг испаренной влаги, кДж/кг")]
        [DisplayName("Расход теплоты на 1 кг испаренной влаги, кДж/кг")]
        public double Get_qisp
        {
            get { return _HB.f_qisp(); }
        }
        /// <summary>
        /// КПД печи
        /// </summary>
        [Description("Коэффициент полезного действия печи, %")]
        [DisplayName("Коэффициент полезного действия печи, %")]
        public double Get_Q1pr
        {
            get { return _HB.f_Q1pr(); }
        }
        /// <summary>
        /// Расход мазута
        /// </summary>
        [Description("Расход мазута, кг/c")]
        [DisplayName("Расход мазута, кг/c")]
        public double Get_B
        {
            get { return _HB.f_B(); }
        }
        /// <summary>
        /// Расход мазута
        /// </summary>
        [Description("Расход мазута, кг/ч")]
        [DisplayName("Расход мазута, кг/ч")]
        public double Get_B1
        {
            get { return _HB.f_B1(); }
        }
        private Balance _HB = new Balance();


        public DataOutput(Balance HB)
        {
            _HB = HB;
        }
        #endregion
    }
}
