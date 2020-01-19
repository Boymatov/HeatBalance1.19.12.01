using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BalanceDLL;

namespace HeatBalance.Class
{
    [Serializable]
    class DataInput_HB
    {
        private Balance _HB = new Balance();
        public DataInput_HB(Balance HB)
        {
            _HB = HB;
        }
        #region ---Исходные данные

        [Description("Начальная влажность материала,%")]
        [DisplayName("Начальная влажность материала,%")]
        [Category("Влажность")]
        public double Get_Wn
        {
            get { return _HB.Wn; }
            set { _HB.Wn = value; }
        }
        [Description("Конечная влажность материала,%")]
        [DisplayName("Конечная влажность материала,%")]
        [Category("Влажность")]
        public double Get_Wk
        {
            get { return _HB.Wk; }
            set { _HB.Wk = value; }
        }
        [Description("Содержание углерода в топливе, %")]
        [DisplayName("Содержание углерода в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Cp
        {
            get { return _HB.Cp; }
            set { _HB.Cp = value; }
        }
        [Description("Содержание водорода в топливе, %")]
        [DisplayName("Содержание водорода в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Hp
        {
            get { return _HB.Hp; }
            set { _HB.Hp = value; }
        }
        [Description("Содержание серы в топливе, %")]
        [DisplayName("Содержание серы в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Sp
        {
            get { return _HB.Sp; }
            set { _HB.Sp = value; }
        }
        [Description("Содержание кислорода в топливе, %")]
        [DisplayName("Содержание кислорода в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Op
        {
            get { return _HB.Op; }
            set { _HB.Op = value; }
        }
        [Description("Содержание азота в топливе, %")]
        [DisplayName("Содержание азота в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Np
        {
            get { return _HB.Np; }
            set { _HB.Np = value; }
        }
        [Description("Содержание золы в топливе, %")]
        [DisplayName("Содержание золы в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Ap
        {
            get { return _HB.Ap; }
            set { _HB.Ap = value; }
        }
        [Description("Содержание влаги в топливе, %")]
        [DisplayName("Содержание влаги в топливе, %")]
        [Category("Состав топлива")]
        public double Get_Wp
        {
            get { return _HB.Wp; }
            set { _HB.Wp = value; }
        }
        [Description("Максимальная температура газов, °С")]
        [DisplayName("Максимальная температура газов, °С")]
        [Category("Температура")]
        public double Get_T1
        {
            get { return _HB.T1; }
            set { _HB.T1 = value; }
        }
        [Description("Минимальная температура газов, °С")]
        [DisplayName("Минимальная температура газов, °С")]
        [Category("Температура")]
        public double Get_T2
        {
            get { return _HB.T2; }
            set { _HB.T2 = value; }
        }
        [Description("Коэффициент расхода воздуха")]
        [DisplayName("Коэффициент расхода воздуха")]
        [Category("Другие параметры")]
        public double Get_A
        {
            get { return _HB.A; }
            set { _HB.A = value; }
        }
        [Description("Коэффициент сохранения тепла")]
        [DisplayName("Коэффициент сохранения тепла")]
        [Category("Другие параметры")]
        public double Get_N
        {
            get { return _HB.N; }
            set { _HB.N = value; }
        }
        [Description("Температура воздуха, °С")]
        [DisplayName("Температура воздуха, °С")]
        [Category("Температура")]
        public double Get_Tv
        {
            get { return _HB.Tv; }
            set { _HB.Tv = value; }
        }
        [Description("Температура газов, °С")]
        [DisplayName("Температура газов, °С")]
        [Category("Температура")]
        public double Get_Tg
        {
            get { return _HB.Tg; }
            set { _HB.Tg = value; }
        }
        [Description("Средняя по массе начальная температура материала, °С")]
        [DisplayName("Средняя по массе начальная температура материала, °С")]
        [Category("Температура")]
        public double Get_Tm1
        {
            get { return _HB.Tm1; }
            set { _HB.Tm1 = value; }
        }
        [Description("Требуемая производительность, кг/ч")]
        [DisplayName("Требуемая производительность, кг/ч")]
        [Category("Другие параметры")]
        public double Get_Gt
        {
            get { return _HB.Gt; }
            set { _HB.Gt = value; }
        }
        [Description("Процент химического недожога, %")]
        [DisplayName("Процент химического недожога, %")]
        [Category("Другие параметры")]
        public double Get_Him
        {
            get { return _HB.Him; }
            set { _HB.Him = value; }
        }
        [Description("Объемное отношение кислорода к азоту в воздухе")]
        [DisplayName("Объемное отношение кислорода к азоту в воздухе")]
        [Category("Другие параметры")]
        public double Get_K
        {
            get { return _HB.K; }
            set { _HB.K = value; }
        }
        [Description("Удельная теплоемкость газов, кДж/(кг*к)")]
        [DisplayName("Удельная теплоемкость газов, кДж/(кг*к)")]
        [Category("Другие параметры")]
        public double Get_Sg
        {
            get { return _HB.Sg; }
            set { _HB.Sg = value; }
        }
        [Description("Удельная теплоемкость сухого материала, кДж/(кг*к)")]
        [DisplayName("Удельная теплоемкость сухого материала, кДж/(кг*к)")]
        [Category("Другие параметры")]
        public double Get_Sm
        {
            get { return _HB.Sm; }
            set { _HB.Sm = value; }
        }
        [Description("Удельная теплоемкость влаги, кДж/(кг*к)")]
        [DisplayName("Удельная теплоемкость влаги, кДж/(кг*к)")]
        [Category("Другие параметры")]
        public double Get_Svl
        {
            get { return _HB.Svl; }
            set { _HB.Svl = value; }
        }
        [Description("Энтальпия водяного пара при 100 °С, кДж/кг")]
        [DisplayName("Энтальпия водяного пара при 100 °С, кДж/кг")]
        [Category("Другие параметры")]
        public double Get_In100
        {
            get { return _HB.In100; }
            set { _HB.In100 = value; }
        }
        [Description("Диаметр барабана, м")]
        [DisplayName("Диаметр барабана, м")]
        [Category("Размеры")]
        public double Get_D
        {
            get { return _HB.D; }
            set { _HB.D = value; }
        }
        [Description("Длина барабана, м")]
        [DisplayName("Длина барабана, м")]
        [Category("Размеры")]
        public double Get_L
        {
            get { return _HB.L; }
            set { _HB.L = value; }
        }

        #endregion
    }

    
}

