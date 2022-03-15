using System;
using System.Linq;
using System.Reflection;
using ShareTypes.SignalTypes;
using R440O.InternalBlocks;
using R440O.R440OForms.A306;
using R440O.R440OForms.A403_1;
using R440O.R440OForms.N13_1;
using R440O.R440OForms.N13_2;
using R440O.R440OForms.N16;
using R440O.R440OForms.BMA_M_1;
using R440O.R440OForms.BMA_M_2;
using R440O.R440OForms.PU_K1_1;
using R440O.BaseClasses;

namespace R440O.R440OForms.N15
{
    using Parameters;
    using A1;
    using A205M_1;
    using A205M_2;

    using N502B;
    using NKN_1;
    using NKN_2;
    using C300M_1;
    using C300M_2;
    using C300M_3;
    using C300M_4;
    using A304;
    using B1_1;
    using B2_1;
    using B3_1;
    using B1_2;
    using B2_2;
    using B3_2;
    using BMB;
    using Kontur_P3.Параметры;
    using P220_27G_2;
    using P220_27G_3;
    using СостоянияЭлементов.Контур_П;
    using InternalBlocks;
    using global::R440O.JsonAdapter;

    public class N15Parameters
    {
        private static N15Parameters instance;
        public static N15Parameters getInstance()
        {
            if (instance == null)
                instance = new N15Parameters();
            return instance;
        }

        public bool Включен
        {
            get { return N502BParameters.getInstance().Н15Включен && НеполноеВключение; }
        }

        public bool НеполноеВключение
        {
            get
            {
                return N502BParameters.getInstance().ВыпрямительВключен && N502BParameters.getInstance().ЭлектрообуродованиеВключено;
            }
        }

        private double _регуляторУровень = 100;
        /// <summary>
        /// Угол от -120 до 120
        /// </summary>
        public double РегуляторУровень
        {
            get { return _регуляторУровень; }
            set
            {
                if (value > -120 && value < 120 && Math.Abs(value - _регуляторУровень) <= 100) _регуляторУровень = value;
                ResetC300M();
            }
        }

        #region Индикатор

        private float _индикаторМощностьВыхода = N16Parameters.ЗначениеМощностьВыходаRnd;

        public float ИндикаторМощностьВыхода
        {
            get
            {
                return (КнопкаМощностьН16 && !N16Parameters.КнопкаВкл && НеполноеВключение &&
                        (N13_1Parameters.getInstance().Включен || N13_2Parameters.getInstance().Включен))
                    ? _индикаторМощностьВыхода
                    : 0;
            }
            set
            {
                _индикаторМощностьВыхода = value;
                OnIndicatorChanged();
            }
        }

        #endregion

        #region Кнопки
        private bool _кнопкаСтанцияВкл;
        private bool _кнопкаСтанцияВыкл;

        private bool _кнопкаПрмНаведениеЦ300М1;
        private bool _кнопкаПрмНаведениеЦ300М2;
        private bool _кнопкаПрмНаведениеЦ300М3;
        private bool _кнопкаПрмНаведениеЦ300М4;
        private bool _кнопкаМощностьН16;
        private bool _кнопкаМощностьАнт;
        private bool _кнопкаМощностьСброс;

        private int _кнопкаН13;
        private bool _кнопкаСброс;

        public bool КнопкаСтанцияВкл
        {
            get
            {
                return _кнопкаСтанцияВкл;
            }
            set
            {
                _кнопкаСтанцияВкл = value;
                OnParameterChanged();
            }
        }

        public bool КнопкаСтанцияВыкл
        {
            get
            {
                return _кнопкаСтанцияВыкл;
            }
            set
            {
                _кнопкаСтанцияВыкл = value;
                if (value)
                {
                    ResetParameters();
                }
                else
                    OnParameterChanged();
            }
        }

        public bool КнопкаПРМНаведениеЦ300М1
        {
            get { return _кнопкаПрмНаведениеЦ300М1; }
            set
            {
                _кнопкаПрмНаведениеЦ300М1 = value;
            }
        }


        public bool КнопкаПРМНаведениеЦ300М2
        {
            get { return _кнопкаПрмНаведениеЦ300М2; }
            set
            {
                _кнопкаПрмНаведениеЦ300М2 = value;
            }
        }

        public bool КнопкаПРМНаведениеЦ300М3
        {
            get { return _кнопкаПрмНаведениеЦ300М3; }
            set
            {
                _кнопкаПрмНаведениеЦ300М3 = value;
            }
        }

        public bool КнопкаПРМНаведениеЦ300М4
        {
            get { return _кнопкаПрмНаведениеЦ300М4; }
            set
            {
                _кнопкаПрмНаведениеЦ300М4 = value;
            }
        }

        public bool КнопкаМощностьН16
        {
            get { return _кнопкаМощностьН16; }
            set
            {
                _кнопкаМощностьН16 = value;
            }
        }

        public bool КнопкаМощностьАнт
        {
            get { return _кнопкаМощностьАнт; }
            set
            {
                _кнопкаМощностьАнт = value;
                OnParameterChanged();
            }
        }

        public bool КнопкаМощностьСброс
        {
            get { return _кнопкаМощностьСброс; }
            set
            {
                _кнопкаМощностьСброс = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Значение, хранимое в памяти блока для комплектов Н13
        /// 0 - Комплекты не включены (Последняя нажатая клавиша - Сброс)
        /// 1 - КнопкаН13_1 (Последняя нажатая клавиша - Н13_1)
        /// 2 - КнопкаН13_2 (Последняя нажатая клавиша - Н13_2)
        /// 3 - КнопкаН13_12 (Последняя нажатая клавиша - Н13_12)
        /// </summary>
        public int КнопкаН13
        {
            get { return _кнопкаН13; }
            set
            {
                _кнопкаН13 = value;
            }
        }

        private bool _Н13_1;
        private bool _Н13_2;

        /// <summary>
        /// Параметр для включения блока Н13_1
        /// </summary>
        public bool Н13_1
        {
            get { return _Н13_1; }
            set
            {
                _Н13_1 = value;
                N13_1Parameters.getInstance().ResetParameters();
            }
        }

        /// <summary>
        /// Параметр для включения блока Н13_2
        /// </summary>
        public bool Н13_2
        {
            get { return _Н13_2; }
            set
            {
                _Н13_2 = value;
                N13_2Parameters.getInstance().ResetParameters();
            }
        }

        public bool КнопкаСброс
        {
            get { return _кнопкаСброс; }
            set
            {
                _кнопкаСброс = value;
            }
        }
        #endregion

        #region Тумблеры левая часть
        private bool _тумблерЦ300М1;
        private bool _тумблерЦ300М2;
        private bool _тумблерЦ300М3;
        private bool _тумблерЦ300М4;
        private bool _тумблерН12С;
        private bool _тумблерМшу;
        private bool _тумблерБма1;
        private bool _тумблерБма2;
        private bool _тумблерА205Base;
        private bool _тумблерА20512;
        private bool _тумблерА30412;
        private bool _тумблерАфсс;
        private bool _тумблерА1;
        private bool _тумблерА403;
        private bool _тумблерК11;
        private bool _тумблерК12;
        private bool _тумблерБ11;
        private bool _тумблерБ12;
        private bool _тумблерБ21;
        private bool _тумблерБ22;
        private bool _тумблерБ31;
        private bool _тумблерБ32;
        private bool _тумблерДаб5;
        private bool _тумблерРН;

        public bool ТумблерЦ300М1
        {
            get { return _тумблерЦ300М1; }
            set
            {
                _тумблерЦ300М1 = value;
                C300M_1Parameters.getInstance().ResetParameters();
            }
        }

        public bool ТумблерЦ300М2
        {
            get { return _тумблерЦ300М2; }
            set
            {
                _тумблерЦ300М2 = value;
            }
        }

        public bool ТумблерЦ300М3
        {
            get { return _тумблерЦ300М3; }
            set
            {
                _тумблерЦ300М3 = value;
                C300M_3Parameters.getInstance().ResetParameters();
            }
        }

        public bool ТумблерЦ300М4
        {
            get { return _тумблерЦ300М4; }
            set
            {
                _тумблерЦ300М4 = value;
                C300M_4Parameters.getInstance().ResetParameters();
            }
        }

        public bool ТумблерН12С
        {
            get { return _тумблерН12С; }
            set
            {
                _тумблерН12С = value;
            }
        }

        public bool ТумблерМШУ
        {
            get { return _тумблерМшу; }
            set
            {
                _тумблерМшу = value;
            }
        }

        public bool ТумблерБМА_1
        {
            get { return _тумблерБма1; }
            set
            {
                _тумблерБма1 = value;
            }
        }

        public bool ТумблерБМА_2
        {
            get { return _тумблерБма2; }
            set
            {
                _тумблерБма2 = value;
            }
        }

        public bool ТумблерА205Base
        {
            get { return _тумблерА205Base; }
            set
            {
                _тумблерА205Base = value;
            }
        }

        public bool ТумблерА20512
        {
            get { return _тумблерА20512; }
            set
            {
                _тумблерА20512 = value;
                NKN_1Parameters.getInstance().ДистанционноеВключение = ТумблерА205Base && value;
                NKN_1Parameters.getInstance().Питание220Включено = NKN_1Parameters.getInstance().ДистанционноеВключение;
                NKN_1Parameters.getInstance().ResetParameters();
                A205M_1Parameters.getInstance().ResetParameters();

                NKN_2Parameters.getInstance().ДистанционноеВключение = ТумблерА205Base && !value;
                NKN_2Parameters.getInstance().Питание220Включено = NKN_2Parameters.getInstance().ДистанционноеВключение;
                NKN_2Parameters.getInstance().ResetParameters();
                A205M_2Parameters.ResetParameters();
            }
        }

        public bool ТумблерА30412
        {
            get { return _тумблерА30412; }
            set
            {
                _тумблерА30412 = value;
                OnParameterChanged();
                A304Parameters.getInstance().ResetParameters();
            }
        }

        public bool ТумблерАФСС
        {
            get { return _тумблерАфсс; }
            set
            {
                _тумблерАфсс = value;
            }
        }

        public bool ТумблерА1
        {
            get { return _тумблерА1; }
            set
            {
                _тумблерА1 = value;
            }
        }

        public bool ТумблерА403
        {
            get { return _тумблерА403; }
            set
            {
                _тумблерА403 = value;
                //A403_1Parameters.getInstance().ResetParameters();
            }
        }

        public bool ТумблерК1_1
        {
            get { return _тумблерК11; }
            set
            {
                _тумблерК11 = value;
                PU_K1_1Parameters.getInstance().ResetParameters();
            }
        }

        public bool ТумблерК1_2
        {
            get { return _тумблерК12; }
            set
            {
                _тумблерК12 = value;
            }
        }

        public bool ТумблерБ1_1
        {
            get { return _тумблерБ11; }
            set
            {
                _тумблерБ11 = value;
            }
        }

        public bool ТумблерБ1_2
        {
            get { return _тумблерБ12; }
            set
            {
                _тумблерБ12 = value;
            }
        }

        public bool ТумблерБ2_1
        {
            get { return _тумблерБ21; }
            set
            {
                _тумблерБ21 = value;
            }
        }

        public bool ТумблерБ2_2
        {
            get { return _тумблерБ22; }
            set
            {
                _тумблерБ22 = value;
            }
        }

        public bool ТумблерБ3_1
        {
            get { return _тумблерБ31; }
            set
            {
                _тумблерБ31 = value;
            }
        }

        public bool ТумблерБ3_2
        {
            get { return _тумблерБ32; }
            set
            {
                _тумблерБ32 = value;
            }
        }

        public bool ТумблерДАБ_5
        {
            get { return _тумблерДаб5; }
            set
            {
                _тумблерДаб5 = value;
            }
        }

        public bool ТумблерР_Н
        {
            get { return _тумблерРН; }
            set
            {
                _тумблерРН = value;
            }
        }

        #endregion

        #region Тумблеры правая часть

        private bool _тумблерА503Б;
        private int _тумблерФаза = 0;
        private int _тумблерУров1 = 0;
        private int _тумблерУров2 = 0;
        private int _тумблер5Мгц = 0;
        private bool _тумблерАнтЭкв;
        private bool _тумблерТлфТлгПрм;
        private bool _тумблерТлфТлгПрд;


        public bool ТумблерА503Б
        {
            get { return _тумблерА503Б; }
            set
            {
                _тумблерА503Б = value;
                ResetParameters();
                OnParameterChanged();

            }
        }

        /// <summary>
        /// Тумблер Фаза
        /// -1 - Верхнее положение
        /// 0 - Среднее положение
        /// 1 - Нижнее положение
        /// </summary>
        public int ТумблерФаза
        {
            get { return _тумблерФаза; }
            set
            {
                _тумблерФаза = value;
                N16Parameters.ТумблерФаза = value;
            }
        }

        /// <summary>
        /// Тумблер уровень 1
        /// -1 - Верхнее положение
        /// 0 - Среднее положение
        /// 1 - Нижнее положение
        /// </summary>
        public int ТумблерУров1
        {
            get { return _тумблерУров1; }
            set
            {
                _тумблерУров1 = value;
                N16Parameters.ТумблерУровень1 = value;
            }
        }

        /// <summary>
        /// Тумблер уровень 2
        /// -1 - Верхнее положение
        /// 0 - Среднее положение
        /// 1 - Нижнее положение
        /// </summary>
        public int ТумблерУров2
        {
            get { return _тумблерУров2; }
            set
            {
                _тумблерУров2 = value;
                N16Parameters.ТумблерУровень2 = value;
            }
        }

        /// <summary>
        /// Тумблер 5МГЦ
        /// -1 - Верхнее положение
        /// 0 - Среднее положение
        /// 1 - Нижнее положение
        /// </summary>
        public int Тумблер5Мгц
        {
            get { return _тумблер5Мгц; }
            set
            {
                _тумблер5Мгц = value;
                if (НеполноеВключение)
                    switch (value)
                    {
                        case -1:
                            N15LocalParameters.getInstance().локТумблер5Мгц = true;
                            break;
                        case 1:
                            N15LocalParameters.getInstance().локТумблер5Мгц = false;
                            break;
                    }
                //OnParameterChanged();
            }
        }

        public bool ТумблерАнтЭкв
        {
            get { return _тумблерАнтЭкв; }
            set
            {
                _тумблерАнтЭкв = value;
                N16Parameters.ResetParameters();
            }
        }

        public bool ТумблерТлфТлгПрм
        {
            get { return _тумблерТлфТлгПрм; }
            set
            {
                _тумблерТлфТлгПрм = value;
                OnParameterChanged();
            }
        }

        public bool ТумблерТлфТлгПрд
        {
            get { return _тумблерТлфТлгПрд; }
            set
            {
                _тумблерТлфТлгПрд = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region Лампочки верхняя часть

        public bool ЛампочкаЦ300МВкл1 { get { return C300M_1Parameters.getInstance().Включен; } }
        public bool ЛампочкаЦ300МВкл2 { get { return C300M_2Parameters.getInstance().Включен; } }
        public bool ЛампочкаЦ300МВкл3 { get { return Лампочка27В && ЛампочкаН15БП && ТумблерЦ300М3; } }
        public bool ЛампочкаЦ300МВкл4 { get { return Лампочка27В && ЛампочкаН15БП && ТумблерЦ300М4; } }
        public bool ЛампочкаЦ300МСигнал1 { get { return C300M_1Parameters.getInstance().ЛампочкаСигнал; } }
        public bool ЛампочкаЦ300МСигнал2 { get { return C300M_2Parameters.getInstance().ЛампочкаСигнал; } }
        public bool ЛампочкаЦ300МСигнал3 { get { return C300M_3Parameters.getInstance().ЛампочкаСигнал; } }
        public bool ЛампочкаЦ300МСигнал4 { get { return C300M_4Parameters.getInstance().ЛампочкаСигнал; } }
        public bool ЛампочкаЦ300МНеиспр1 { get; set; }
        public bool ЛампочкаЦ300МНеиспр2 { get; set; }
        public bool ЛампочкаЦ300МНеиспр3 { get; set; }
        public bool ЛампочкаЦ300МНеиспр4 { get; set; }
        public bool ЛампочкаППВВкл1 { get { return NKN_1Parameters.getInstance().ПолноеВключение || (NKN_1Parameters.getInstance().НеполноеВключение && NKN_1Parameters.getInstance().Питание220Включено); } }
        public bool ЛампочкаППВВкл2 { get { return NKN_2Parameters.getInstance().ПолноеВключение || (NKN_2Parameters.getInstance().НеполноеВключение && NKN_2Parameters.getInstance().Питание220Включено); } }
        public bool ЛампочкаППВРабота1 { get { return A205M_1Parameters.getInstance().Работа; } }
        public bool ЛампочкаППВРабота2 { get { return A205M_2Parameters.Работа; } }

        public bool ЛампочкаА205Неиспр1
        {
            get { return A205M_1Parameters.getInstance().Включен && !A205M_1Parameters.getInstance().Работа; }
        }

        public bool ЛампочкаА205Неиспр2
        {
            get
            {
                return A205M_2Parameters.Включен && !A205M_2Parameters.Работа;
            }
        }

        public bool ЛампочкаУМ1Работа1
        {
            get { return NKN_1Parameters.getInstance().ПолноеВключение && NKN_1Parameters.getInstance().ДистанционноеВключение; }
        }

        public bool ЛампочкаУМ1Работа2
        {
            get { return NKN_2Parameters.getInstance().ПолноеВключение && NKN_2Parameters.getInstance().ДистанционноеВключение; }
        }
        #endregion

        #region Лампочки левая часть


        public bool ЛампочкаН12С
        {
            get { return Включен && N12SParameters.getInstance().Включен; }
        }

        public bool ЛампочкаМШУ
        {
            get { return Включен && MSHUParameters.getInstance().Включен; }
        }

        public bool ЛампочкаБМА_1
        {
            //Добавить для 1 и 2 БМА параметры включения и завязать здесь
            get { return Включен && ТумблерБМА_1; }
        }

        public bool ЛампочкаБМА_2
        {
            get { return Включен && ТумблерБМА_2; }
        }

        public bool Лампочка27В
        {
            get { return НеполноеВключение; }
        }

        public bool ЛампочкаН15БП
        {
            get { return НеполноеВключение; }
        }

        public bool ЛампочкаАФСС
        {
            get { return Включен && ЛампочкаН15БП && ТумблерАФСС && Kontur_P3Parameters.getInstance().ТумблерСеть == EТумблерСеть.ВКЛ; }
        }

        public bool ЛампочкаА1
        {
            get { return A1Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаА403Вкл
        {
            get { return Включен && A403_1Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаА403Неиспр
        {
            get { return false; }
        }

        public bool ЛампочкаП220272
        {
            get { return Включен && P220_27G_2Parameters.getInstance().ЛампочкаСеть; }
        }

        public bool ЛампочкаП220273
        {
            get { return НеполноеВключение; }
        }

        public bool ЛампочкаА306
        {
            get { return ЛампочкаМШУ; }
        }

        public bool ЛампочкаА3041
        {
            get { return A304Parameters.getInstance().Лампочка1К; }
        }

        public bool ЛампочкаА3042
        {
            get { return A304Parameters.getInstance().Лампочка2К; }
        }

        public bool ЛампочкаБ1_1
        {
            get { return B1_1Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаБ1_2
        {
            get { return B1_2Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаБ2_1
        {
            get { return B2_1Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаБ2_2
        {
            get { return B2_2Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаБ3_1
        {
            get { return B3_1Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаБ3_2
        {
            get { return B3_2Parameters.getInstance().Включен; }
        }

        public bool ЛампочкаДАБ_5
        {
            get { return Лампочка27В && ЛампочкаН15БП && ТумблерДАБ_5 && DAB_5Parameters.getInstance().ТумблерПитание; }
        }

        public bool ЛампочкаР_Н
        {
            get { return false; }
        }

        #endregion

        #region Лампочки правая часть

        public bool ЛампочкаН16Н13_1
        {
            get { return N16Parameters.ЛампочкаН13_1; }
        }

        public bool ЛампочкаН16Н13_2
        {
            get { return N16Parameters.ЛампочкаН13_2; }
        }

        public bool ЛампочкаН16Н13_12
        {
            get { return N16Parameters.ЛампочкаН13_12; }
        }
        public bool ЛампочкаН13_11Ступень { get { return N13_1Parameters.getInstance().ЛампочкаАнодВключен; } }
        public bool ЛампочкаН13_21Ступень { get { return N13_2Parameters.getInstance().ЛампочкаАнодВключен; } }
        public bool ЛампочкаН13_1ПолноеВкл { get { return N13_1Parameters.getInstance().ЛампочкаАнодВключен; } }
        public bool ЛампочкаН13_2ПолноеВкл { get { return N13_2Parameters.getInstance().ЛампочкаАнодВключен; } }
        public bool ЛампочкаН13_1Неисправность { get { return N13_1Parameters.getInstance().Неисправен; } }
        public bool ЛампочкаН13_2Неисправность { get { return N13_2Parameters.getInstance().Неисправен; } }
        public bool Лампочка5мГц2 { get { return НеполноеВключение && N15LocalParameters.getInstance().локТумблер5Мгц; } }
        public bool Лампочка5мГц3 { get { return НеполноеВключение && !N15LocalParameters.getInstance().локТумблер5Мгц; } }

        public bool ЛампочкаА503Б
        {
            get { return A503BParameters.Включен; }
        }

        public bool ЛампочкаАнт { get { return N16Parameters.ЛампочкаАнтенна; } }
        public bool ЛампочкаЭкв { get { return N16Parameters.ЛампочкаЭквивалент; } }

        #endregion

        #region Обновление формы

        /// <summary>
        /// Сброс параметров для блоков без дублирующих лампочек
        /// </summary>
        public void ResetParameters()
        {
            N16Parameters.ResetParameters();
            #region БМА


            BMBParameters.getInstance().ResetParameters();
            BMA_M_1Parameters.getInstance().DisposeAllTimers();
            BMA_M_1Parameters.getInstance().ResetLampsValue();
            BMA_M_1Parameters.getInstance().ResetParameters();
            BMA_M_2Parameters.getInstance().DisposeAllTimers();
            BMA_M_2Parameters.getInstance().ResetLampsValue();
            BMA_M_2Parameters.getInstance().ResetParameters();

            #endregion

            #region МШУ и АФСС

            A306Parameters.getInstance().ResetParameters();
            Kontur_P3Parameters.getInstance().ResetToDefaultsWhenTurnOnOff();
            Kontur_P3Parameters.getInstance().Refresh();

            #endregion

            #region Дискрет и Генераторы

            ResetDiscret();
            P220_27G_2Parameters.getInstance().ResetParameters();
            P220_27G_3Parameters.getInstance().ResetParameters();

            #endregion

            #region ДАБ_5
            DAB_5Parameters.getInstance().SetDefaultParameters();
            DAB_5Parameters.getInstance().ResetParameters();
            #endregion

            N12SParameters.getInstance().ResetParameters();
            A304Parameters.getInstance().ResetParameters();
            A403_1Parameters.getInstance().ResetParameters();

            NKN_1Parameters.getInstance().ResetParameters();
            NKN_2Parameters.getInstance().ResetParameters();
            A205M_1Parameters.getInstance().ResetParameters();
            A205M_2Parameters.ResetParameters();

            //A503BParameters.ResetParameters();

            ResetC300M();
            OnParameterChanged();
        }

        public void ResetC300M()
        {
            C300M_1Parameters.getInstance().ResetParameters();
            C300M_2Parameters.getInstance().ResetParameters();
            C300M_3Parameters.getInstance().ResetParameters();
            C300M_4Parameters.getInstance().ResetParameters();
        }

        /// <summary>
        /// Сброс параметров для блоков с дублирующими лампочками
        /// </summary>
        public void ResetParametersAlternative()
        {
            OnParameterChanged();
        }

        /// <summary>
        /// Отдельная перезагрузка аппаратуры Дискрет.
        /// </summary>
        public void ResetDiscret()
        {
            A1Parameters.getInstance().ResetParameters();
            B1_1Parameters.getInstance().ResetParameters();
            B1_2Parameters.getInstance().ResetParameters();
            B2_1Parameters.getInstance().ResetParameters();
            B2_2Parameters.getInstance().ResetParameters();
            B3_1Parameters.getInstance().ResetParameters();
            B3_2Parameters.getInstance().ResetParameters();
        }

        public delegate void TestModuleHandler(ActionStation action);
        public event TestModuleHandler Action;
        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }

        private void OnAction(string name, int value)
        {
            var action = new ActionStation(name, value);
            Action?.Invoke(action);
        }

        public event ParameterChangedHandler IndicatorChanged;

        private void OnIndicatorChanged()
        {
            IndicatorChanged?.Invoke();
        }
        #endregion

        #region

        /// <summary>
        /// Уставнавливает настоящие настройки станции в соответствии с включенными тумблерами
        /// </summary>
        public void SetCurrentParameters()
        {
            var parametersList = typeof(N15Parameters).GetProperties();
            var localParametersList = typeof(N15LocalParameters).GetProperties();

            foreach (var localProperty in localParametersList)
            {
                foreach (
                    var property in
                        parametersList.Where(
                            property =>
                                localProperty.Name.Contains(property.Name) && localProperty.Name != "локТумблер5Мгц"
                                && localProperty.Name != "локКнопкаН13_1" && localProperty.Name != "локКнопкаН13_2" &&
                                localProperty.Name != "локКнопкаН13_12" && localProperty.Name != "локТумблерАнтЭкв"))
                {
                    property.SetValue(N15Parameters.getInstance(), localProperty.GetValue(N15LocalParameters.getInstance()));
                }
            }

            Н13_1 = (N15LocalParameters.getInstance().локКнопкаН13_1 || N15LocalParameters.getInstance().локКнопкаН13_12);
            Н13_2 = (N15LocalParameters.getInstance().локКнопкаН13_2 || N15LocalParameters.getInstance().локКнопкаН13_12);
        }

        /// <summary>
        /// Сбрасывает настоящие настройки станции
        /// </summary>
        public void ResetCurrentParameters()
        {
            var parametersList = typeof(N15Parameters).GetProperties();

            foreach (var property in parametersList.Where(property => property.Name.Contains("Тумблер")
                                                                      && !property.Name.Contains("А503Б") &&
                                                                      !property.Name.Contains("Фаза")
                                                                      && !property.Name.Contains("Уров") &&
                                                                      !property.Name.Contains("5Мгц")
                                                                      && !property.Name.Contains("АнтЭкв") &&
                                                                      !property.Name.Contains("ТлфТлг")
                                                                      && !property.Name.Contains("А30412")))
            {
                property.SetValue(this, false);
            }

            Н13_1 = false;
            Н13_2 = false;
        }

        #endregion
        public bool isFullDeactive()
        {
            return !(N15LocalParameters.getInstance().isFullDeactive() &&
                _кнопкаСтанцияВкл && _кнопкаСтанцияВыкл
            || _кнопкаПрмНаведениеЦ300М1
            || _кнопкаПрмНаведениеЦ300М2
            || _кнопкаПрмНаведениеЦ300М3
            || _кнопкаПрмНаведениеЦ300М4
            || _кнопкаМощностьН16
            || _кнопкаМощностьАнт
            || _кнопкаМощностьСброс
            || _кнопкаН13 != 0
            || _кнопкаСброс
            || _тумблерЦ300М1
            || _тумблерЦ300М2
            || _тумблерЦ300М3
            || _тумблерЦ300М4
            || _тумблерН12С
            || _тумблерМшу
            || _тумблерБма1
            || _тумблерБма2
            || _тумблерА205Base
            || _тумблерА20512
            || _тумблерА30412
            || _тумблерАфсс
            || _тумблерА1
            || _тумблерА403
            || _тумблерК11
            || _тумблерК12
            || _тумблерБ11
            || _тумблерБ12
            || _тумблерБ21
            || _тумблерБ22
            || _тумблерБ31
            || _тумблерБ32
            || _тумблерДаб5
            || _тумблерРН
            || _тумблерА503Б
            || _тумблерФаза != 0
            || _тумблерУров1 != 0
            || _тумблерУров2 != 0
            || _тумблер5Мгц != 0
            || _тумблерАнтЭкв
            || _тумблерТлфТлгПрм
            || _тумблерТлфТлгПрд);
        }
        public void SetDefaultParameters()
        {
            РегуляторУровень = 0;
            _кнопкаСтанцияВкл = false;
            _кнопкаСтанцияВыкл = false;

            _кнопкаПрмНаведениеЦ300М1 = false;
            _кнопкаПрмНаведениеЦ300М2 = false;
            _кнопкаПрмНаведениеЦ300М3 = false;
            _кнопкаПрмНаведениеЦ300М4 = false;
            _кнопкаМощностьН16 = false;
            _кнопкаМощностьАнт = false;
            _кнопкаМощностьСброс = false;

            _кнопкаН13 = 0;
            _кнопкаСброс = false;


            _тумблерЦ300М1 = false;
            _тумблерЦ300М2 = false;
            _тумблерЦ300М3 = false;
            _тумблерЦ300М4 = false;
            _тумблерН12С = false;
            _тумблерМшу = false;
            _тумблерБма1 = false;
            _тумблерБма2 = false;
            _тумблерА205Base = false;
            _тумблерА20512 = false;
            _тумблерА30412 = false;
            _тумблерАфсс = false;
            _тумблерА1 = false;
            _тумблерА403 = false;
            _тумблерК11 = false;
            _тумблерК12 = false;
            _тумблерБ11 = false;
            _тумблерБ12 = false;
            _тумблерБ21 = false;
            _тумблерБ22 = false;
            _тумблерБ31 = false;
            _тумблерБ32 = false;
            _тумблерДаб5 = false;
            _тумблерРН = false;

            _тумблерА503Б = false;
            _тумблерФаза = 0;
            _тумблерУров1 = 0;
            _тумблерУров2 = 0;
            _тумблер5Мгц = 0;
            _тумблерАнтЭкв = false;
            _тумблерТлфТлгПрм = false;
            _тумблерТлфТлгПрд = false;
            OnParameterChanged();
            N15LocalParameters.getInstance().SetDefaultParameters();
        }
    }
}
