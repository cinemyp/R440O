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

    public static class N15Parameters
    {
        public static bool Включен
        {
            get { return N502BParameters.Н15Включен && НеполноеВключение; }
        }

        public static bool НеполноеВключение
        {
            get
            {
                return N502BParameters.ВыпрямительВключен && N502BParameters.ЭлектрообуродованиеВключено;
            }
        }

        private static double _регуляторУровень = 100;
        /// <summary>
        /// Угол от -120 до 120
        /// </summary>
        public static double РегуляторУровень
        {
            get { return _регуляторУровень; }
            set
            {
                if (value > -120 && value < 120 && Math.Abs(value - _регуляторУровень) <= 100) _регуляторУровень = value;
                ResetC300M();
            }
        }

        #region Индикатор

        private static float _индикаторМощностьВыхода = N16Parameters.ЗначениеМощностьВыходаRnd;

        public static float ИндикаторМощностьВыхода
        {
            get
            {
                return (КнопкаМощностьН16 && !N16Parameters.КнопкаВкл && НеполноеВключение &&
                        (N13_1Parameters.Включен || N13_2Parameters.Включен))
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
        private static bool _кнопкаСтанцияВкл;
        private static bool _кнопкаСтанцияВыкл;

        private static bool _кнопкаПрмНаведениеЦ300М1;
        private static bool _кнопкаПрмНаведениеЦ300М2;
        private static bool _кнопкаПрмНаведениеЦ300М3;
        private static bool _кнопкаПрмНаведениеЦ300М4;
        private static bool _кнопкаМощностьН16;
        private static bool _кнопкаМощностьАнт;
        private static bool _кнопкаМощностьСброс;

        private static int _кнопкаН13;
        private static bool _кнопкаСброс;

        public static bool КнопкаСтанцияВкл
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

        public static bool КнопкаСтанцияВыкл
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

        public static bool КнопкаПРМНаведениеЦ300М1
        {
            get { return _кнопкаПрмНаведениеЦ300М1; }
            set
            {
                _кнопкаПрмНаведениеЦ300М1 = value;
            }
        }


        public static bool КнопкаПРМНаведениеЦ300М2
        {
            get { return _кнопкаПрмНаведениеЦ300М2; }
            set
            {
                _кнопкаПрмНаведениеЦ300М2 = value;
            }
        }

        public static bool КнопкаПРМНаведениеЦ300М3
        {
            get { return _кнопкаПрмНаведениеЦ300М3; }
            set
            {
                _кнопкаПрмНаведениеЦ300М3 = value;
            }
        }

        public static bool КнопкаПРМНаведениеЦ300М4
        {
            get { return _кнопкаПрмНаведениеЦ300М4; }
            set
            {
                _кнопкаПрмНаведениеЦ300М4 = value;
            }
        }

        public static bool КнопкаМощностьН16
        {
            get { return _кнопкаМощностьН16; }
            set
            {
                _кнопкаМощностьН16 = value;
            }
        }

        public static bool КнопкаМощностьАнт
        {
            get { return _кнопкаМощностьАнт; }
            set
            {
                _кнопкаМощностьАнт = value;
                OnParameterChanged();
            }
        }

        public static bool КнопкаМощностьСброс
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
        public static int КнопкаН13
        {
            get { return _кнопкаН13; }
            set
            {
                _кнопкаН13 = value;
            }
        }

        private static bool _Н13_1;
        private static bool _Н13_2;

        /// <summary>
        /// Параметр для включения блока Н13_1
        /// </summary>
        public static bool Н13_1
        {
            get { return _Н13_1; }
            set
            {
                _Н13_1 = value;
                N13_1Parameters.ResetParameters();
            }
        }

        /// <summary>
        /// Параметр для включения блока Н13_2
        /// </summary>
        public static bool Н13_2
        {
            get { return _Н13_2; }
            set
            {
                _Н13_2 = value;
                N13_2Parameters.ResetParameters();
            }
        }

        public static bool КнопкаСброс
        {
            get { return _кнопкаСброс; }
            set
            {
                _кнопкаСброс = value;
            }
        }
        #endregion

        #region Тумблеры левая часть
        private static bool _тумблерЦ300М1;
        private static bool _тумблерЦ300М2;
        private static bool _тумблерЦ300М3;
        private static bool _тумблерЦ300М4;
        private static bool _тумблерН12С;
        private static bool _тумблерМшу;
        private static bool _тумблерБма1;
        private static bool _тумблерБма2;
        private static bool _тумблерА205Base;
        private static bool _тумблерА20512;
        private static bool _тумблерА30412;
        private static bool _тумблерАфсс;
        private static bool _тумблерА1;
        private static bool _тумблерА403;
        private static bool _тумблерК11;
        private static bool _тумблерК12;
        private static bool _тумблерБ11;
        private static bool _тумблерБ12;
        private static bool _тумблерБ21;
        private static bool _тумблерБ22;
        private static bool _тумблерБ31;
        private static bool _тумблерБ32;
        private static bool _тумблерДаб5;
        private static bool _тумблерРН;

        public static bool ТумблерЦ300М1
        {
            get { return _тумблерЦ300М1; }
            set
            {
                _тумблерЦ300М1 = value;
                C300M_1Parameters.ResetParameters();
            }
        }

        public static bool ТумблерЦ300М2
        {
            get { return _тумблерЦ300М2; }
            set
            {
                _тумблерЦ300М2 = value;
            }
        }

        public static bool ТумблерЦ300М3
        {
            get { return _тумблерЦ300М3; }
            set
            {
                _тумблерЦ300М3 = value;
                C300M_3Parameters.ResetParameters();
            }
        }

        public static bool ТумблерЦ300М4
        {
            get { return _тумблерЦ300М4; }
            set
            {
                _тумблерЦ300М4 = value;
                C300M_4Parameters.ResetParameters();
            }
        }

        public static bool ТумблерН12С
        {
            get { return _тумблерН12С; }
            set
            {
                _тумблерН12С = value;
            }
        }

        public static bool ТумблерМШУ
        {
            get { return _тумблерМшу; }
            set
            {
                _тумблерМшу = value;
            }
        }

        public static bool ТумблерБМА_1
        {
            get { return _тумблерБма1; }
            set
            {
                _тумблерБма1 = value;
            }
        }

        public static bool ТумблерБМА_2
        {
            get { return _тумблерБма2; }
            set
            {
                _тумблерБма2 = value;
            }
        }

        public static bool ТумблерА205Base
        {
            get { return _тумблерА205Base; }
            set
            {
                _тумблерА205Base = value;
            }
        }

        public static bool ТумблерА20512
        {
            get { return _тумблерА20512; }
            set
            {
                _тумблерА20512 = value;
                NKN_1Parameters.ДистанционноеВключение = ТумблерА205Base && value;
                NKN_1Parameters.Питание220Включено = NKN_1Parameters.ДистанционноеВключение;
                NKN_1Parameters.ResetParameters();
                A205M_1Parameters.ResetParameters();

                NKN_2Parameters.ДистанционноеВключение = ТумблерА205Base && !value;
                NKN_2Parameters.Питание220Включено = NKN_2Parameters.ДистанционноеВключение;
                NKN_2Parameters.ResetParameters();
                A205M_2Parameters.ResetParameters();
            }
        }

        public static bool ТумблерА30412
        {
            get { return _тумблерА30412; }
            set
            {
                _тумблерА30412 = value;
                OnParameterChanged();
                A304Parameters.ResetParameters();
            }
        }

        public static bool ТумблерАФСС
        {
            get { return _тумблерАфсс; }
            set
            {
                _тумблерАфсс = value;
            }
        }

        public static bool ТумблерА1
        {
            get { return _тумблерА1; }
            set
            {
                _тумблерА1 = value;
            }
        }

        public static bool ТумблерА403
        {
            get { return _тумблерА403; }
            set
            {
                _тумблерА403 = value;
                //A403_1Parameters.ResetParameters();
            }
        }

        public static bool ТумблерК1_1
        {
            get { return _тумблерК11; }
            set
            {
                _тумблерК11 = value;
                PU_K1_1Parameters.ResetParameters();
            }
        }

        public static bool ТумблерК1_2
        {
            get { return _тумблерК12; }
            set
            {
                _тумблерК12 = value;
            }
        }

        public static bool ТумблерБ1_1
        {
            get { return _тумблерБ11; }
            set
            {
                _тумблерБ11 = value;
            }
        }

        public static bool ТумблерБ1_2
        {
            get { return _тумблерБ12; }
            set
            {
                _тумблерБ12 = value;
            }
        }

        public static bool ТумблерБ2_1
        {
            get { return _тумблерБ21; }
            set
            {
                _тумблерБ21 = value;
            }
        }

        public static bool ТумблерБ2_2
        {
            get { return _тумблерБ22; }
            set
            {
                _тумблерБ22 = value;
            }
        }

        public static bool ТумблерБ3_1
        {
            get { return _тумблерБ31; }
            set
            {
                _тумблерБ31 = value;
            }
        }

        public static bool ТумблерБ3_2
        {
            get { return _тумблерБ32; }
            set
            {
                _тумблерБ32 = value;
            }
        }

        public static bool ТумблерДАБ_5
        {
            get { return _тумблерДаб5; }
            set
            {
                _тумблерДаб5 = value;
            }
        }

        public static bool ТумблерР_Н
        {
            get { return _тумблерРН; }
            set
            {
                _тумблерРН = value;
            }
        }

        #endregion

        #region Тумблеры правая часть

        private static bool _тумблерА503Б;
        private static int _тумблерФаза = 0;
        private static int _тумблерУров1 = 0;
        private static int _тумблерУров2 = 0;
        private static int _тумблер5Мгц = 0;
        private static bool _тумблерАнтЭкв;
        private static bool _тумблерТлфТлгПрм;
        private static bool _тумблерТлфТлгПрд;


        public static bool ТумблерА503Б
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
        public static int ТумблерФаза
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
        public static int ТумблерУров1
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
        public static int ТумблерУров2
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
        public static int Тумблер5Мгц
        {
            get { return _тумблер5Мгц; }
            set
            {
                _тумблер5Мгц = value;
                if (НеполноеВключение)
                    switch (value)
                    {
                        case -1:
                            N15LocalParameters.локТумблер5Мгц = true;
                            break;
                        case 1:
                            N15LocalParameters.локТумблер5Мгц = false;
                            break;
                    }
                //OnParameterChanged();
            }
        }

        public static bool ТумблерАнтЭкв
        {
            get { return _тумблерАнтЭкв; }
            set
            {
                _тумблерАнтЭкв = value;
                N16Parameters.ResetParameters();
            }
        }

        public static bool ТумблерТлфТлгПрм
        {
            get { return _тумблерТлфТлгПрм; }
            set
            {
                _тумблерТлфТлгПрм = value;
                OnParameterChanged();
            }
        }

        public static bool ТумблерТлфТлгПрд
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

        public static bool ЛампочкаЦ300МВкл1 { get { return C300M_1Parameters.Включен; } }
        public static bool ЛампочкаЦ300МВкл2 { get { return C300M_2Parameters.Включен; } }
        public static bool ЛампочкаЦ300МВкл3 { get { return Лампочка27В && ЛампочкаН15БП && ТумблерЦ300М3; } }
        public static bool ЛампочкаЦ300МВкл4 { get { return Лампочка27В && ЛампочкаН15БП && ТумблерЦ300М4; } }
        public static bool ЛампочкаЦ300МСигнал1 { get { return C300M_1Parameters.ЛампочкаСигнал; } }
        public static bool ЛампочкаЦ300МСигнал2 { get { return C300M_2Parameters.ЛампочкаСигнал; } }
        public static bool ЛампочкаЦ300МСигнал3 { get { return C300M_3Parameters.ЛампочкаСигнал; } }
        public static bool ЛампочкаЦ300МСигнал4 { get { return C300M_4Parameters.ЛампочкаСигнал; } }
        public static bool ЛампочкаЦ300МНеиспр1 { get; set; }
        public static bool ЛампочкаЦ300МНеиспр2 { get; set; }
        public static bool ЛампочкаЦ300МНеиспр3 { get; set; }
        public static bool ЛампочкаЦ300МНеиспр4 { get; set; }
        public static bool ЛампочкаППВВкл1 { get { return NKN_1Parameters.ПолноеВключение || (NKN_1Parameters.НеполноеВключение && NKN_1Parameters.Питание220Включено); } }
        public static bool ЛампочкаППВВкл2 { get { return NKN_2Parameters.ПолноеВключение || (NKN_2Parameters.НеполноеВключение && NKN_2Parameters.Питание220Включено); } }
        public static bool ЛампочкаППВРабота1 { get { return A205M_1Parameters.Работа; } }
        public static bool ЛампочкаППВРабота2 { get { return A205M_2Parameters.Работа; } }

        public static bool ЛампочкаА205Неиспр1
        {
            get { return A205M_1Parameters.Включен && !A205M_1Parameters.Работа; }
        }

        public static bool ЛампочкаА205Неиспр2
        {
            get
            {
                return A205M_2Parameters.Включен && !A205M_2Parameters.Работа;
            }
        }

        public static bool ЛампочкаУМ1Работа1
        {
            get { return NKN_1Parameters.ПолноеВключение && NKN_1Parameters.ДистанционноеВключение; }
        }

        public static bool ЛампочкаУМ1Работа2
        {
            get { return NKN_2Parameters.ПолноеВключение && NKN_2Parameters.ДистанционноеВключение; }
        }
        #endregion

        #region Лампочки левая часть


        public static bool ЛампочкаН12С
        {
            get { return Включен && N12SParameters.Включен; }
        }

        public static bool ЛампочкаМШУ
        {
            get { return Включен && MSHUParameters.Включен; }
        }

        public static bool ЛампочкаБМА_1
        {
            //Добавить для 1 и 2 БМА параметры включения и завязать здесь
            get { return Включен && ТумблерБМА_1; }
        }

        public static bool ЛампочкаБМА_2
        {
            get { return Включен && ТумблерБМА_2; }
        }

        public static bool Лампочка27В
        {
            get { return НеполноеВключение; }
        }

        public static bool ЛампочкаН15БП
        {
            get { return НеполноеВключение; }
        }

        public static bool ЛампочкаАФСС
        {
            get { return Включен && ЛампочкаН15БП && ТумблерАФСС && Kontur_P3Parameters.ТумблерСеть == EТумблерСеть.ВКЛ; }
        }

        public static bool ЛампочкаА1
        {
            get { return A1Parameters.Включен; }
        }

        public static bool ЛампочкаА403Вкл
        {
            get { return Включен && A403_1Parameters.Включен; }
        }

        public static bool ЛампочкаА403Неиспр
        {
            get { return false; }
        }

        public static bool ЛампочкаП220272
        {
            get { return Включен && P220_27G_2Parameters.ЛампочкаСеть; }
        }

        public static bool ЛампочкаП220273
        {
            get { return НеполноеВключение; }
        }

        public static bool ЛампочкаА306
        {
            get { return ЛампочкаМШУ; }
        }

        public static bool ЛампочкаА3041
        {
            get { return A304Parameters.Лампочка1К; }
        }

        public static bool ЛампочкаА3042
        {
            get { return A304Parameters.Лампочка2К; }
        }

        public static bool ЛампочкаБ1_1
        {
            get { return B1_1Parameters.Включен; }
        }

        public static bool ЛампочкаБ1_2
        {
            get { return B1_2Parameters.Включен; }
        }

        public static bool ЛампочкаБ2_1
        {
            get { return B2_1Parameters.Включен; }
        }

        public static bool ЛампочкаБ2_2
        {
            get { return B2_2Parameters.Включен; }
        }

        public static bool ЛампочкаБ3_1
        {
            get { return B3_1Parameters.Включен; }
        }

        public static bool ЛампочкаБ3_2
        {
            get { return B3_2Parameters.Включен; }
        }

        public static bool ЛампочкаДАБ_5
        {
            get { return Лампочка27В && ЛампочкаН15БП && ТумблерДАБ_5 && DAB_5Parameters.ТумблерПитание; }
        }

        public static bool ЛампочкаР_Н
        {
            get { return false; }
        }

        #endregion

        #region Лампочки правая часть

        public static bool ЛампочкаН16Н13_1
        {
            get { return N16Parameters.ЛампочкаН13_1; }
        }

        public static bool ЛампочкаН16Н13_2
        {
            get { return N16Parameters.ЛампочкаН13_2; }
        }

        public static bool ЛампочкаН16Н13_12
        {
            get { return N16Parameters.ЛампочкаН13_12; }
        }
        public static bool ЛампочкаН13_11Ступень { get { return N13_1Parameters.ЛампочкаАнодВключен; } }
        public static bool ЛампочкаН13_21Ступень { get { return N13_2Parameters.ЛампочкаАнодВключен; } }
        public static bool ЛампочкаН13_1ПолноеВкл { get { return N13_1Parameters.ЛампочкаАнодВключен; } }
        public static bool ЛампочкаН13_2ПолноеВкл { get { return N13_2Parameters.ЛампочкаАнодВключен; } }
        public static bool ЛампочкаН13_1Неисправность { get { return N13_1Parameters.Неисправен; } }
        public static bool ЛампочкаН13_2Неисправность { get { return N13_2Parameters.Неисправен; } }
        public static bool Лампочка5мГц2 { get { return НеполноеВключение && N15LocalParameters.локТумблер5Мгц; } }
        public static bool Лампочка5мГц3 { get { return НеполноеВключение && !N15LocalParameters.локТумблер5Мгц; } }

        public static bool ЛампочкаА503Б
        {
            get { return A503BParameters.Включен; }
        }

        public static bool ЛампочкаАнт { get { return N16Parameters.ЛампочкаАнтенна; } }
        public static bool ЛампочкаЭкв { get { return N16Parameters.ЛампочкаЭквивалент; } }

        #endregion

        #region Обновление формы

        /// <summary>
        /// Сброс параметров для блоков без дублирующих лампочек
        /// </summary>
        public static void ResetParameters()
        {        
            N16Parameters.ResetParameters();
            #region БМА


            BMBParameters.ResetParameters();
            BMA_M_1Parameters.DisposeAllTimers();
            BMA_M_1Parameters.ResetLampsValue();
            BMA_M_1Parameters.ResetParameters();
            BMA_M_2Parameters.DisposeAllTimers();
            BMA_M_2Parameters.ResetLampsValue();
            BMA_M_2Parameters.ResetParameters();

            #endregion

            #region МШУ и АФСС

            A306Parameters.ResetParameters();
            Kontur_P3Parameters.ResetToDefaultsWhenTurnOnOff();
            Kontur_P3Parameters.Refresh();

            #endregion

            #region Дискрет и Генераторы

            ResetDiscret();
            P220_27G_2Parameters.ResetParameters();
            P220_27G_3Parameters.ResetParameters();

            #endregion

            #region ДАБ_5
            DAB_5Parameters.SetDefaultParameters();
            DAB_5Parameters.ResetParameters();
            #endregion

            N12SParameters.ResetParameters();
            A304Parameters.ResetParameters();
            A403_1Parameters.ResetParameters();

            NKN_1Parameters.ResetParameters();
            NKN_2Parameters.ResetParameters();
            A205M_1Parameters.ResetParameters();
            A205M_2Parameters.ResetParameters();

            //A503BParameters.ResetParameters();

            ResetC300M();
            OnParameterChanged();
        }

        public static void ResetC300M()
        {
            C300M_1Parameters.ResetParameters();
            C300M_2Parameters.ResetParameters();
            C300M_3Parameters.ResetParameters();
            C300M_4Parameters.ResetParameters();
        }

        /// <summary>
        /// Сброс параметров для блоков с дублирующими лампочками
        /// </summary>
        public static void ResetParametersAlternative()
        {
            OnParameterChanged();
        }

        /// <summary>
        /// Отдельная перезагрузка аппаратуры Дискрет.
        /// </summary>
        public static void ResetDiscret()
        {
            A1Parameters.ResetParameters();
            B1_1Parameters.ResetParameters();
            B1_2Parameters.ResetParameters();
            B2_1Parameters.ResetParameters();
            B2_2Parameters.ResetParameters();
            B3_1Parameters.ResetParameters();
            B3_2Parameters.ResetParameters();
        }

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static event ParameterChangedHandler IndicatorChanged;

        private static void OnIndicatorChanged()
        {
            var handler = IndicatorChanged;
            if (handler != null) handler();
        }
        #endregion

        #region

        /// <summary>
        /// Уставнавливает настоящие настройки станции в соответствии с включенными тумблерами
        /// </summary>
        public static void SetCurrentParameters()
        {
            var parametersList = typeof (N15Parameters).GetProperties();
            var localParametersList = typeof (N15LocalParameters).GetProperties();

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
                    property.SetValue("1", localProperty.GetValue("1"));
                }
            }

            Н13_1 = (N15LocalParameters.локКнопкаН13_1 || N15LocalParameters.локКнопкаН13_12);
            Н13_2 = (N15LocalParameters.локКнопкаН13_2 || N15LocalParameters.локКнопкаН13_12);
        }

        /// <summary>
        /// Сбрасывает настоящие настройки станции
        /// </summary>
        public static void ResetCurrentParameters()
        {
            var parametersList = typeof (N15Parameters).GetProperties();

            foreach (var property in parametersList.Where(property => property.Name.Contains("Тумблер")
                                                                      && !property.Name.Contains("А503Б") &&
                                                                      !property.Name.Contains("Фаза")
                                                                      && !property.Name.Contains("Уров") &&
                                                                      !property.Name.Contains("5Мгц")
                                                                      && !property.Name.Contains("АнтЭкв") &&
                                                                      !property.Name.Contains("ТлфТлг")
                                                                      && !property.Name.Contains("А30412")))
            {
                property.SetValue("1", false);
            }

            Н13_1 = false;
            Н13_2 = false;
        }

        #endregion
    }
}
