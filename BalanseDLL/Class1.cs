using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace BalanceDLL
{
    [Serializable]
    public class Balance
    {
        #region -- исходные данные
        /// <summary>
        /// Начальная влажность материала,%
        /// </summary> 
        private double _Wn;    // закрытая переменная класса 
        public double Wn
        {
            get { return _Wn; }
            set { _Wn = value; }
        }
        /// <summary>
        /// Конечная влажность материала,%
        /// </summary> 
        private double _Wk;    // закрытая переменная класса 
        public double Wk
        {
            get { return _Wk; }
            set { _Wk = value; }
        }
        /// <summary>
        /// Содержание углерода в топливе, %
        /// </summary> 
        private double _Cp;    // закрытая переменная класса 
        public double Cp
        {
            get { return _Cp; }
            set { _Cp = value; }
        }
        /// <summary>
        /// Содержание водорода в топливе, %
        /// </summary> 
        private double _Hp;    // закрытая переменная класса 
        public double Hp
        {
            get { return _Hp; }
            set { _Hp = value; }
        }
        /// <summary>
        /// Содержание серы в топливе, %
        /// </summary> 
        private double _Sp;    // закрытая переменная класса 
        public double Sp
        {
            get { return _Sp; }
            set { _Sp = value; }
        }
        /// <summary>
        /// Содержание кислорода в топливе, %
        /// </summary> 
        private double _Op;    // закрытая переменная класса 
        public double Op
        {
            get { return _Op; }
            set { _Op = value; }
        }
        /// <summary>
        /// Содержание азота в топливе, %
        /// </summary> 
        private double _Np;    // закрытая переменная класса 
        public double Np
        {
            get { return _Np; }
            set { _Np = value; }
        }
        /// <summary>
        /// Содержание золы в топливе, %
        /// </summary> 
        private double _Ap;    // закрытая переменная класса 
        public double Ap
        {
            get { return _Ap; }
            set { _Ap = value; }
        }
        /// <summary>
        /// Содержание влаги в топливе, %
        /// </summary> 
        private double _Wp;    // закрытая переменная класса 
        public double Wp
        {
            get { return _Wp; }
            set { _Wp = value; }
        }
        /// <summary>
        /// Максимальная температура газов, °С
        /// </summary> 
        private double _T1;    // закрытая переменная класса 
        public double T1
        {
            get { return _T1; }
            set { _T1 = value; }
        }
        /// <summary>
        /// Минимальная температура газов, °С
        /// </summary> 
        private double _T2;    // закрытая переменная класса 
        public double T2
        {
            get { return _T2; }
            set { _T2 = value; }
        }
        /// <summary>
        /// Коэффициент расхода воздуха
        /// </summary> 
        private double _A;    // закрытая переменная класса 
        public double A
        {
            get { return _A; }
            set { _A = value; }
        }
        /// <summary>
        /// Коэффициент сохранения тепла
        /// </summary> 
        private double _N;    // закрытая переменная класса 
        public double N
        {
            get { return _N; }
            set { _N = value; }
        }
        /// <summary>
        /// Температура воздуха, °С
        /// </summary> 
        private double _Tv;    // закрытая переменная класса 
        public double Tv
        {
            get { return _Tv; }
            set { _Tv = value; }
        }
        /// <summary>
        /// Температура газов, °С
        /// </summary> 
        private double _Tg;    // закрытая переменная класса 
        public double Tg
        {
            get { return _Tg; }
            set { _Tg = value; }
        }
        /// <summary>
        /// Средняя по массе начальная температура материала, °С
        /// </summary> 
        private double _Tm1;    // закрытая переменная класса 
        public double Tm1
        {
            get { return _Tm1; }
            set { _Tm1 = value; }
        }
        /// <summary>
        /// Требуемая производительность, кг/ч
        /// </summary> 
        private double _Gt;    // закрытая переменная класса 
        public double Gt
        {
            get { return _Gt; }
            set { _Gt = value; }
        }
        /// <summary>
        /// Процент химического недожога, %
        /// </summary> 
        private double _Him;    // закрытая переменная класса 
        public double Him
        {
            get { return _Him; }
            set { _Him = value; }
        }
        /// <summary>
        /// Объемное отношение кислорода к азоту в воздухе
        /// </summary> 
        private double _K;    // закрытая переменная класса 
        public double K
        {
            get { return _K; }
            set { _K = value; }
        }
        /// <summary>
        /// Удельная теплоемкость газов, кДж/(кг*к)
        /// </summary> 
        private double _Sg;    // закрытая переменная класса 
        public double Sg
        {
            get { return _Sg; }
            set { _Sg = value; }
        }
        /// <summary>
        /// Удельная теплоемкость сухого материала, кДж/(кг*к)
        /// </summary> 
        private double _Sm;    // закрытая переменная класса 
        public double Sm
        {
            get { return _Sm; }
            set { _Sm = value; }
        }
        /// <summary>
        /// Удельная теплоемкость влаги, кДж/(кг*к)
        /// </summary> 
        private double _Svl;    // закрытая переменная класса 
        public double Svl
        {
            get { return _Svl; }
            set { _Svl = value; }
        }
        /// <summary>
        /// Энтальпия водяного пара при 100 °С, кДж/кг
        /// </summary> 
        private double _In100;    // закрытая переменная класса 
        public double In100
        {
            get { return _In100; }
            set { _In100 = value; }
        }
        /// <summary>
        /// Диаметр барабана, м
        /// </summary> 
        private double _D;    // закрытая переменная класса 
        public double D
        {
            get { return _D; }
            set { _D = value; }
        }
        /// <summary>
        /// Длина барабана, м
        /// </summary> 
        private double _L;    // закрытая переменная класса 
        public double L
        {
            get { return _L; }
            set { _L = value; }
        }
        #endregion -- исходные данные

        #region -- расчетные параметры
        /// <summary>
        /// Удельная теплоёмкость воздуха, кДж/(кг*К)
        /// </summary> 
        private double _Sv;    // закрытая переменная класса 
        public double Sv
        {
            get { return _Sv; }
            set { _Sv = value; }
        }

        /// <summary>
        /// Начальная энтальпия воды , кДж/кг
        /// </summary> 
        private double _i1vl;    // закрытая переменная класса 
        public double i1vl
        {
            get { return _i1vl; }
            set { _i1vl = value; }
        }
        /// <summary>
        /// Удельная теплоёмкость пара  , кДж/(кг*К)
        /// </summary> 
        private double _Spr;    // закрытая переменная класса 
        public double Spr
        {
            get { return _Spr; }
            set { _Spr = value; }
        }
        /// <summary>
        /// Выход CO2 в продуктах горения  , м3/кг
        /// </summary> 
        private double _V0CO2;    // закрытая переменная класса 
        public double V0CO2
        {
            get { return _V0CO2; }
            set { _V0CO2 = value; }
        }
        /// <summary>
        /// Выход SO2 в продуктах горения  , м3/кг
        /// </summary> 
        private double _V0SO2;    // закрытая переменная класса 
        public double V0SO2
        {
            get { return _V0SO2; }
            set { _V0SO2 = value; }
        }
        /// <summary>
        /// Выход H2O в продуктах горения  , м3/кг
        /// </summary> 
        private double _V0H2O;    // закрытая переменная класса 
        public double V0H2O
        {
            get { return _V0H2O; }
            set { _V0H2O = value; }
        }
        /// <summary>
        /// Выход N2 в продуктах горения  , м3/кг
        /// </summary> 
        private double _V0N2;    // закрытая переменная класса 
        public double V0N2
        {
            get { return _V0N2; }
            set { _V0N2 = value; }
        }
        /// <summary>
        /// Расход кислорода на горение  , м3/кг
        /// </summary> 
        private double _V02;    // закрытая переменная класса 
        public double V02
        {
            get { return _V02; }
            set { _V02 = value; }
        }
        /// <summary>
        /// Действительный выход N2 в продуктах горения   , м3/кг
        /// </summary> 
        private double _VaN2;    // закрытая переменная класса 
        public double VaN2
        {
            get { return _VaN2; }
            set { _VaN2 = value; }
        }
        /// <summary>
        /// Избыточный объём кислорода  , м3/кг
        /// </summary> 
        private double _VO2izb;    // закрытая переменная класса 
        public double VO2izb
        {
            get { return _VO2izb; }
            set { _VO2izb = value; }
        }
        /// <summary>
        /// Теоретический расход воздуха   , м3/кг
        /// </summary> 
        private double _L0;    // закрытая переменная класса 
        public double L0
        {
            get { return _L0; }
            set { _L0 = value; }
        }
        /// <summary>
        /// Действительный расход сухого воздуха    , м3/кг
        /// </summary> 
        private double _La;    // закрытая переменная класса 
        public double La
        {
            get { return _La; }
            set { _La = value; }
        }
        /// <summary>
        /// Выход продуктов горения, м3/кг
        /// </summary> 
        private double _Va1;    // закрытая переменная класса 
        public double Va1
        {
            get { return _Va1; }
            set { _Va1 = value; }
        }
        /// <summary>
        /// Теплота сгорания мазута,кДж/кг
        /// </summary> 
        private double _Qhp;    // закрытая переменная класса 
        public double Qhp
        {
            get { return _Qhp; }
            set { _Qhp = value; }
        }
        /// <summary>
        /// Содержание воздуха в продуктах сгорания, %
        /// </summary> 
        private double _VL;    // закрытая переменная класса 
        public double VL
        {
            get { return _VL; }
            set { _VL = value; }
        }
        /// <summary>
        /// Балансовая энтальпия продуктов горения, кДж/м3
        /// </summary> 
        private double _ibob;    // закрытая переменная класса 
        public double ibob
        {
            get { return _ibob; }
            set { _ibob = value; }
        }
        /// <summary>
        /// Балансовая температура продуктов горения,°C
        /// </summary> 
        private double _tab;    // закрытая переменная класса 
        public double tab
        {
            get { return _tab; }
            set { _tab = value; }
        }
        /// <summary>
        /// Энтальпия факела, кДж/м3
        /// </summary> 
        private double _ifa;    // закрытая переменная класса 
        public double ifa
        {
            get { return _ifa; }
            set { _ifa = value; }
        }
        /// <summary>
        /// Энтальпия воздуха , кДж/м3
        /// </summary> 
        private double _iv;    // закрытая переменная класса 
        public double iv
        {
            get { return _iv; }
            set { _iv = value; }
        }
        /// <summary>
        /// Энтальпия продуктов сгорания, кДж/м3
        /// </summary> 
        private double _i1;    // закрытая переменная класса 
        public double i1
        {
            get { return _i1; }
            set { _i1 = value; }
        }
        /// <summary>
        /// Энтальпия дымовых газов, кДж/м3
        /// </summary> 
        private double _i2;    // закрытая переменная класса 
        public double i2
        {
            get { return _i2; }
            set { _i2 = value; }
        }
        /// <summary>
        /// Количество воздуха, м3/м3
        /// </summary> 
        private double _xv;    // закрытая переменная класса 
        public double xv
        {
            get { return _xv; }
            set { _xv = value; }
        }
        /// <summary>
        /// Энтальпия воздуха при t2 и VL=100%, кДж/м3
        /// </summary> 
        private double _i2v;    // закрытая переменная класса 
        public double i2v
        {
            get { return _i2v; }
            set { _i2v = value; }
        }
        /// <summary>
        /// Средняя по массе температура материала в конце сушки, °C
        /// </summary> 
        private double _tm2;    // закрытая переменная класса 
        public double tm2
        {
            get { return _tm2; }
            set { _tm2 = value; }
        }
        /// <summary>
        /// Температура стенки в начале барабана, °C
        /// </summary> 
        private double _tstnach;    // закрытая переменная класса 
        public double tstnach
        {
            get { return _tstnach; }
            set { _tstnach = value; }
        }
        /// <summary>
        /// Температура стенки в конце барабана , °C
        /// </summary> 
        private double _tstkon;    // закрытая переменная класса 
        public double tstkon
        {
            get { return _tstkon; }
            set { _tstkon = value; }
        }
        /// <summary>
        /// Средняя температура металлической стенки барабана  , °C
        /// </summary> 
        private double _tst;    // закрытая переменная класса 
        public double tst
        {
            get { return _tst; }
            set { _tst = value; }
        }
        /// <summary>
        /// Коэффициент теплоотдачи от поверхности стенки к окрущающей среде, Вт/(м2*К)
        /// </summary> 
        private double _av;    // закрытая переменная класса 
        public double av
        {
            get { return _av; }
            set { _av = value; }
        }
        /// <summary>
        /// Влажность в % от неизменяющейся сухой массы материала в начале сушки, %
        /// </summary> 
        private double _W1c;    // закрытая переменная класса 
        public double W1c
        {
            get { return _W1c; }
            set { _W1c = value; }
        }
        /// <summary>
        /// Влажность в % от неизменяющейся сухой массы материала в конце сушки, %
        /// </summary> 
        private double _W2c;    // закрытая переменная класса 
        public double W2c
        {
            get { return _W2c; }
            set { _W2c = value; }
        }
        /// <summary>
        ///Производительность по испарённой влаге, кг/ч
        /// </summary> 
        private double _Gvl;    // закрытая переменная класса 
        public double Gvl
        {
            get { return _Gvl; }
            set { _Gvl = value; }
        }
        /// <summary>
        ///Расход теплоты на прогревание просушиваемых материалов и испарение влаги, кВт
        /// </summary> 
        private double _Q1;    // закрытая переменная класса 
        public double Q1
        {
            get { return _Q1; }
            set { _Q1 = value; }
        }
        /// <summary>
        ///Потери теплоты вследствие теплопроводности стенок рабочего пространства , кВт
        /// </summary> 
        private double _Q5t;    // закрытая переменная класса 
        public double Q5t
        {
            get { return _Q5t; }
            set { _Q5t = value; }
        }
        /// <summary>
        ///Q2*B, кВт * кг/ч
        /// </summary> 
        private double _Q2v;    // закрытая переменная класса 
        public double Q2v
        {
            get { return _Q2v; }
            set { _Q2v = value; }
        }
        /// <summary>
        ///Q3*B, кВт * кг/ч
        /// </summary> 
        private double _Q3v;    // закрытая переменная класса 
        public double Q3v
        {
            get { return _Q3v; }
            set { _Q3v = value; }
        }
        /// <summary>
        ///Q5топ*B, кВт * кг/ч
        /// </summary> 
        private double _Q5topB;    // закрытая переменная класса 
        public double Q5topB
        {
            get { return _Q5topB; }
            set { _Q5topB = value; }
        }
        /// <summary>
        ///Расход мазута, кг/ч
        /// </summary> 
        private double _B;    // закрытая переменная класса 
        public double B
        {
            get { return _B; }
            set { _B = value; }
        }
        /// <summary>
        ///Тепловая мощность печи 	кВт
        /// </summary> 
        private double _Qx;    // закрытая переменная класса 
        public double Qx
        {
            get { return _Qx; }
            set { _Qx = value; }
        }
        /// <summary>
        ///Расход теплоты на 1 кг испаренной влаги, кДж/кг
        /// </summary> 
        private double _qisp;    // закрытая переменная класса 
        public double qisp
        {
            get { return _qisp; }
            set { _qisp = value; }
        }
        /// <summary>
        ///Потери теплоты с отходящими газами, кВт 
        /// </summary> 
        private double _Q2;    // закрытая переменная класса 
        public double Q2
        {
            get { return _Q2; }
            set { _Q2 = value; }
        }
        /// <summary>
        ///Потери теплоты с химическим недожогом, кВт 
        /// </summary> 
        private double _Q3;    // закрытая переменная класса 
        public double Q3
        {
            get { return _Q3; }
            set { _Q3 = value; }
        }
        /// <summary>
        ///Потери теплоты топкой, кВт 
        /// </summary> 
        private double _Q5top;    // закрытая переменная класса 
        public double Q5top
        {
            get { return _Q5top; }
            set { _Q5top = value; }
        }
        /// <summary>
        ///Коэффициент полезного действия печи, %
        /// </summary> 
        private double _Q1pr;    // закрытая переменная класса 
        public double Q1pr
        {
            get { return _Q1pr; }
            set { _Q1pr = value; }
        }
        /// <summary>
        ///%Q2, %
        /// </summary> 
        private double _Q2pr;    // закрытая переменная класса 
        public double Q2pr
        {
            get { return _Q2pr; }
            set { _Q2pr = value; }
        }
        /// <summary>
        ///%Q3, %
        /// </summary> 
        private double _Q3pr;    // закрытая переменная класса 
        public double Q3pr
        {
            get { return _Q3pr; }
            set { _Q3pr = value; }
        }
        /// <summary>
        ///%Q5топ, %
        /// </summary> 
        private double _Q5toppr;    // закрытая переменная класса 
        public double Q5toppr
        {
            get { return _Q5toppr; }
            set { _Q5toppr = value; }
        }
        /// <summary>
        ///%Q5т, %
        /// </summary> 
        private double _Q5tpr;    // закрытая переменная класса 
        public double Q5tpr
        {
            get { return _Q5tpr; }
            set { _Q5tpr = value; }
        }
        /// <summary>
        ///Результат 1
        /// </summary> 
        private double _Q1prRez;    // закрытая переменная класса 
        public double Q1prRez
        {
            get { return _Q1prRez; }
            set { _Q1prRez = value; }
        }
        ///Результат 2
        /// </summary> 
        private double _Q2prRez;    // закрытая переменная класса 
        public double Q2prRez
        {
            get { return _Q2prRez; }
            set { _Q2prRez = value; }
        }
        ///Результат 3
        /// </summary> 
        private double _Q3prRez;    // закрытая переменная класса 
        public double Q3prRez
        {
            get { return _Q3prRez; }
            set { _Q3prRez = value; }
        }
        ///Результат 4
        /// </summary> 
        private double _Q4prRez;    // закрытая переменная класса 
        public double Q4prRez
        {
            get { return _Q4prRez; }
            set { _Q4prRez = value; }
        }
        ///Результат 5
        /// </summary> 
        private double _Q5topprRez;    // закрытая переменная класса 
        public double Q5topprRez
        {
            get { return _Q5topprRez; }
            set { _Q5topprRez = value; }
        }
        #endregion -- расчетные параметры

        #region -- Расчет

        /// <summary>
        /// Удельная теплоёмкость воздуха, кДж/(кг*К)
        /// </summary>
        private double sv()
        {
            return 1.3107 * Math.Exp(9 * Math.Pow( 10 ,- 5 )* _Tv);
        }
        /// <summary>
        /// Начальная энтальпия воды, кДж/кг
        /// </summary>
        private double f_i1vl()
        { return _Tv * _Svl; }
        /// <summary>
        /// Удельная теплоемкость пара, кДж/(кг*К)
        /// </summary>
        private double f_Sp()
        {
            return 8 * Math.Pow(10, -5) * Math.Exp(0.035 * (_T2 - 100));
        }
        /// <summary>
        /// Выход СО2 в продуктах горения, м3/кг 
        /// </summary>
        private double f_V0CO2()
        { return 0.01 * 1.867 * _Cp; }
        /// <summary>
        /// Выход SO2 в продуктах горения, м3/кг
        /// </summary>
        private double f_V0SO2()
        { return 0.01 * 0.7 * _Sp; }
        /// <summary>
        /// Выход Н2О в продуктах горения, м3/кг
        /// </summary>
        private double f_V0H2O()
        { return 0.01 * (11.2 * _Hp + 1.244 * _Wp); }
        /// <summary>
        /// Выход N2 в продуктах горения, м3/кг
        /// </summary>
        private double f_V0N2()
        { return 0.01 * 0.8 * _Np + _K * f_VO2(); }
        /// <summary>
        /// Расход кислорода на горение, м3/кг
        /// </summary>
        private double f_VO2()
        { return 0.01 * (1.867 * _Cp + 5.6 * _Hp + 0.7 * (_Sp - _Op)); }
        /// <summary>
        /// Действительный выход N2 в продуктах горения, м3/кг
        /// </summary>
        private double f_VaN2()
        { return f_V0N2() + _K * (_A-1) * f_VO2(); }
        /// <summary>
        /// Избыточный объем кислорода, м3/кг
        /// </summary>
        private double f_VO2izb()
        { return (_A - 1) * f_VO2(); }
        /// <summary>
        /// Теоретический расход воздуха, м3/кг 
        /// </summary>
        private double f_L0()
        { return (1 + _K) * f_VO2(); }
        /// <summary>
        /// Действительный расход сухого воздуха, м3/кг
        /// </summary>
        private double f_La()
        { return _A * f_L0(); }
        /// <summary>
        /// Выход продуктов горения, м3/кг
        /// </summary>
        private double f_Va1()
        { return f_V0CO2() + f_V0SO2() + f_V0H2O() + f_VaN2() + f_VO2izb(); }
        /// <summary>
        /// Теплота сгорания мазута, кДж/кг
        /// </summary>
        private double f_Qhp()
        { return 340 * _Cp + 1030 * _Hp - 109 * (_Op - _Sp) - 25 * _Wp; }
        /// <summary>
        /// Содержание воздуха в продуктах сгорания, %
        /// </summary>
        private double f_VL()
        { return 100 * (f_La() - f_L0()) / f_Va1(); }
        /// <summary>
        /// Балансовая энтальпия продуктов горения, кДж/м3 
        /// </summary>
        private double f_ibob()
        { return (0.98 * f_Qhp() + f_La() * _Tv * sv() + _Tg * _Sg) / f_Va1(); }
        /// <summary>
        /// Балансовая температура продуктов горения, °С 
        /// </summary>
        private double f_tab()
        { return 1392.3 * Math.Log(f_ibob()) - 9321.8; }
        /// <summary>
        /// Энтальпия факела, кДж/м3
        /// </summary>
        private double f_ifa()
        { return f_ibob() * _N; }
        /// <summary>
        /// Энтальпия воздуха, кДж/м3
        /// </summary>
        private double f_iv()
        { return _Tv * sv(); }
        /// <summary>
        /// Энтальпия продуктов сгорания, кДж/м3
        /// </summary>
        private double f_i1()
        { return 1.614 * _T1 - 73.81; }
        /// <summary>
        /// Энтальпия дымовых газов, кДж/м3
        /// </summary>
        private double f_i2()
        { return 1.614 * _T2 - 73.81; }
        /// <summary>
        /// Количество воздуха, м3/м3
        /// </summary>
        private double f_xv()
        { return (f_ifa() - f_i1()) / (f_i1() - f_iv()); }
        /// <summary>
        /// Энтальпия воздуха при t2 и VL=100%, кДж/м3
        /// </summary>
        private double f_i2v()
        { return _T2 * sv(); }
        /// <summary>
        /// Средняя по массе температура материала в конце сушки, °С
        /// </summary>
        private double f_tm2()
        { return _T2 - 150; }
        /// <summary>
        /// Температура стенки в начале барабана, °С
        /// </summary>
        private double f_tstnach()
        { return (_T1 + _Tm1) / 2; }
        /// <summary>
        /// Температура стенки в конце барабана, °С
        /// </summary>
        private double f_tstkon()
        { return (_T2 + f_tm2()) / 2; }
        /// <summary>
        /// Средняя температура металлической стенки барабана, °С
        /// </summary>
        private double f_tst()
        { return (f_tstnach() + f_tstkon()) / 2; }
        /// <summary>
        /// Коэффициент теплоотдачи от поверхности стенки к окружающей среде, Вт/(м2*К)
        /// </summary>
        private double f_av()
        { return 8 + 0.06 * f_tst(); }
        /// <summary>
        /// Влажность в % от неизменяющейся сухой массы материала в начале сушки, %
        /// </summary>
        private double f_W1c()
        { return _Wn / (1 - 0.01 * _Wn); }
        /// <summary>
        /// Влажность в % от неизменяющейся сухой массы материала в конце сушки, %
        /// </summary>
        private double f_W2c()
        { return _Wk / (1 - 0.01 * _Wk); }
        /// <summary>
        /// Производительность по испаренной влаге, кг/ч
        /// </summary>
        private double f_Gvl()
        { return _Gt * (f_W1c() - f_W2c()) * 0.01; }
        /// <summary>
        /// Расход теплоты на прогревание просушиваемых материалов и испарение влаги, кВт
        /// </summary>
        public double f_Q1()
        { return (_Sm + 0.01 * f_W2c() * _Svl) * (f_tm2() - _Tm1) + 0.01 * (f_W1c() - f_W2c()) * (_In100 - f_i1vl() + f_Sp() * (_T2 - 100) * _Gt); }
        /// <summary>
        /// Потери теплоты вследствие теплопроводности стенок рабочего пространства, кВт
        /// </summary>
        public double f_Q5t()
        { return (0.001 * f_av() * (f_tst() - _Tv) * _D * _L * 3.14); }
        /// <summary>
        /// Q2*B, кВт*кг/ч
        /// </summary>
        private double f_Q2B()
        { return (f_i2() + f_xv() * (f_i2v() - f_iv())) * f_Va1(); }
        /// <summary>
        /// Q3*B, кВт*кг/ч
        /// </summary>
        private double f_Q3B()
        { return f_Qhp() * _Him; }
        /// <summary>
        /// Q5топ*B, кВт*кг/ч
        /// </summary>
        private double f_Q5topB()
        { return (1 - _N) * f_Qhp(); }
        /// <summary>
        /// Расход мазута, кг/c
        /// </summary>
        public double f_B()
        { return (f_Q1() + f_Q5t()) / (f_Qhp() - f_Q2B() - f_Q3B() - f_Q5topB()); }
        /// <summary>
        /// Расход мазута, кг/ч
        /// </summary>
        public double f_B1()
        { return f_B() * 3600; }
        /// <summary>
        /// Тепловая мощность печи, кВт
        /// </summary>
        public double f_Qx()
        { return f_Qhp() * f_B(); }
        /// <summary>
        /// Расход теплоты на 1 кг испаренной влаги, кДж/кг
        /// </summary>
        public double f_qisp()
        { return f_Qx() / f_Gvl(); }
        /// <summary>
        /// Потери теплоты с отходящими газами, кВт
        /// </summary>
        public double f_Q2()
        { return f_Q2B() * f_B(); }
        /// <summary>
        /// Потери теплоты с химическим недожогом, кВт
        /// </summary>
        public double f_Q3()
        { return f_Q3B() * f_B(); }
        /// <summary>
        /// Потери теплоты топкой, кВт
        /// </summary>
        public double f_Q5top()
        { return f_Q5topB() * f_B(); }
        /// <summary>
        /// КПД печи, %
        /// </summary>
        public double f_Q1pr()
        { return (100 * f_Q1()) / f_Qx(); }
        /// <summary>
        /// %Q2, %
        /// </summary>
        public double f_Q2pr()
        { return (100 * f_Q2()) / f_Qx(); }
        /// <summary>
        /// %Q3, %
        /// </summary>
        public double f_Q3pr()
        { return (100 * f_Q3()) / f_Qx(); }
        /// <summary>
        /// %Q5топ, %
        /// </summary>
        public double f_Q5toppr()
        { return (100 * f_Q5top()) / f_Qx(); }
        /// <summary>
        /// %Q5т, %
        /// </summary>
        public double f_Q5tpr()
        { return (100 * f_Q5t()) / f_Qx(); }
        /// <summary>
        /// Тепловой баланс1
        /// </summary>
        public double f_TB1()
        { return (f_Qhp() - f_Q5topB() - f_Q3B() - f_Q2B()) * f_B(); }
        /// <summary>
        /// Тепловой баланс2
        /// </summary>
        public double f_TB2()
        { return f_Q5t() + f_Q1(); }
        /// <summary>
        /// Тепловой баланс
        /// </summary>
        public double f_TB()
        { return f_TB1() - f_TB2(); }

        #endregion -- Расчет

        #region -- методы сериализации
        /// <summary>
        /// Загрузить исходные данные в экземпляр объекта расчета 
        /// </summary>  
        /// <param name="NameFile">Имя файла для извлечения данных</param>
        public Balance LoadData(string FileName)
        {
            // Восстановить данные путем десериализации из XML-файла
            SoapFormatter myXMLFormat = new SoapFormatter();
            FileStream myStreamB = File.OpenRead(FileName);
            Balance _s = (Balance)myXMLFormat.Deserialize(myStreamB);
            myStreamB.Close();
            return _s;
        }

        /// <summary>
        /// Сохранение исходных данных объекта на диск
        /// </summary>  
        /// <param name="hc">Объект  для сохранения на диск</param>
        /// <param name="NameFile">Имя файла для сохранения</param>
        public void SaveData(Balance s, string NameFile)
        {
            FileStream myStream = File.Create(NameFile);
            SoapFormatter myXMLFormat = new SoapFormatter();
            myXMLFormat.Serialize(myStream, s);
            myStream.Close();
        }

        /// <summary>
        /// Свойство для хранения имени файла данных
        /// </summary>    
        private string _sFileName;    // закрытая переменная класса для хранения имени файла исходных данных
        public string FileName
        {
            get { return _sFileName; }
            set
            {
                if (value == null || value.Length == 0)
                    throw new ArgumentException("Не определен объект FileName");
                else
                    _sFileName = value;
            }
        }
        #endregion
    }
}
