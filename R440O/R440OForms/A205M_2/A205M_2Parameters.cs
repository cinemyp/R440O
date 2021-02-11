using R440O.Parameters;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.K04M_01;
using R440O.R440OForms.N15Inside;
using R440O.R440OForms.PU_K1_1;

namespace R440O.R440OForms.A205M_2
{
    using BaseClasses;
    using N18_M;
    using N502B;
    using NKN_2;
    using ShareTypes.SignalTypes;

    public static class A205M_2Parameters
    {
        public static bool Включен
        {
            get
            {
                return NKN_2Parameters.ПолноеВключение;
                // && K05M_01Parameters.СтрелкаУровеньВЗакрашенномСекторе;
            }
        }

        public static bool Работа
        {
            get
            {
                return Включен && ((N18_MParameters.ПереключательВходК121 == 1) ||
                       ((N18_MParameters.ПереключательВходК121 != 1) && PU_K1_1Parameters.ПереключателиВыставленыВерно /*PU_K1_2Parameters.ПереключателиВыставленыВерно*/));
            }
        }



        public static bool КулонК2Подключен
        {
            //get { return PU_K1_2Parameters.Включен && N18_M_H28Parameters.АктивныйКабель == 2; }
            get { return false; }
        }

        #region Выходной Сигнал
        //----------------------------------------
        //По схеме сигнал с А205 проходит так N16 -> N13-1/N13-2 -> N16. Но это мы опускаем и идем на А503Б, так как мощность не является важным параметром
        //---------------------------------------
        public static Signal ВыходнойСигнал
        {
            get
            {
                var wave = ПереключательВолнаX10000 * 10000 +
                                 ПереключательВолнаX1000 * 1000 +
                                 ПереключательВолнаX100 * 100 +
                                 ПереключательВолнаX10 * 10 +
                                 ПереключательВолнаX1;

                if (Включен && wave >= 1500 && wave <= 51499 && N15InsideParameters.ВыходПередающегоТракта != null)
                {
                    var signal = N15InsideParameters.ВыходПередающегоТракта;
                    signal.Level = 20;
                    signal.Wave = wave;
                    signal.Frequency = 5710000 + 10 * wave;
                    //    switch (ПереключательВидРаботы)
                    //    {
                    //        case 1:
                    //            {
                    //                if (signal.Modulation != Модуляция.ЧТ) signal = null;
                    //            }
                    //            break;
                    //        case 2:
                    //            {
                    //                if (signal.Modulation != Модуляция.ЧТ) signal = null;
                    //            }
                    //            break;
                    //        case 3:
                    //            {
                    //                if (signal.Modulation != Модуляция.ОФТ ||
                    //                    !Signal.IsEquivalentSpeed(signal.GroupSpeed, 5.2)) signal = null;
                    //            }
                    //            break;
                    //        case 4:
                    //            {
                    //                if (signal.Modulation != Модуляция.ОФТ ||
                    //                    !Signal.IsEquivalentSpeed(signal.GroupSpeed, 48)) signal = null;
                    //            }
                    //            break;
                    //    }
                    //}
                    //else
                    //{

                    if (Работа && (N18_MParameters.ПереключательВходК121 != 1) && PU_K1_1Parameters.Включен)
                    {
                        signal.Frequency += K04M_01Parameters.ЧастотаПрд - 70000;
                    }

                    switch (ПереключательВидРаботы)
                    {
                        case 1:
                            {
                                if (signal.Modulation == Модуляция.ЧТ && signal.GroupSpeed >= 0.025 &&
                                    signal.GroupSpeed <= 48)
                                {
                                    return signal;
                                }
                            }
                            break;
                        case 2:
                            {
                                if (signal.Modulation == Модуляция.ЧТ && signal.GroupSpeed >= 0.025 &&
                                    signal.GroupSpeed <= 5.2)
                                {
                                    return signal;
                                }
                            }
                            break;
                        case 3:
                            {
                                if (signal.Modulation == Модуляция.ОФТ && signal.GroupSpeed >= 1.2 &&
                                    signal.GroupSpeed <= 5.2)
                                {
                                    return signal;
                                }
                            }
                            break;
                        default:
                            {
                                if (signal.Modulation == Модуляция.ОФТ && signal.GroupSpeed >= 48)
                                {
                                    return signal;
                                }
                            }
                            break;
                    }
                }
                return null;
            }
        }

        #endregion

        #region Private fields

        private static int _переключательВолнаX10000 = 0;
        private static int _переключательВолнаХ1000 = 0;
        private static int _переключательВолнаХ100 = 0;
        private static int _переключательВолнаХ10 = 0;
        private static int _переключательВолнаХ1 = 0;
        private static int _переключательКонтроль = 1;
        private static int _переключательВидРаботы = 1;
        private static int _переключательВходЧТ = 1;

        #endregion

        #region Работа блока

        ////Лампочки
        private static bool _лампочкаНормРаб;

        public static bool ЛампочкаНормРаб
        {
            get { return Работа; }
        }

        public static bool ЛампочкаПерегрев { get; set; }

        private static bool _тумблерКЭД;
        ////Тумблеры
        /// <summary>
        /// Получает или задает положение тумблера КЭД
        /// </summary>
        public static bool ТумблерКЭД
        {
            get { return _тумблерКЭД; }
            set
            {
                _тумблерКЭД = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region Переключатели волны

        public static int ПереключательВолнаX10000
        {
            get { return _переключательВолнаX10000; }
            set
            {
                if (value > -1 && value < 6)
                {
                    _переключательВолнаX10000 = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательВолнаX1000
        {
            get { return _переключательВолнаХ1000; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ1000 = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательВолнаX100
        {
            get { return _переключательВолнаХ100; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ100 = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательВолнаX10
        {
            get { return _переключательВолнаХ10; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ10 = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательВолнаX1
        {
            get { return _переключательВолнаХ1; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ1 = value;
                    OnParameterChanged();
                }
            }
        }

        #endregion

        #region Контроль блока

        public static int ПереключательКонтроль
        {
            get { return _переключательКонтроль; }
            set
            {
                if (value > 0 && value < 11)
                {
                    _переключательКонтроль = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1 - ППВ,
        /// 2 - ГИ1,
        /// 3 - Д,
        /// 4 - ОГ,
        /// 5 - СЧ1,
        /// 6 - СЧ2,
        /// 7 - НП,
        /// 8 - ВЫХ-85,
        /// 9 - ЧТ-ВТ,
        /// 10 - ВБВ
        /// </summary>
        public static int ИндикаторКонтроль
        {
            get
            {
                if ((N502BParameters.ЛампочкаСфазировано
                     && N502BParameters.ТумблерЭлектрооборудование
                     && N502BParameters.ТумблерВыпрямитель27В))
                {
                    switch (_переключательКонтроль)
                    {
                        case 4:
                            return 20;
                        case 7:
                            return 30;
                        case 1:
                            return NKN_2Parameters.ПолноеВключение ? 20 : 0;
                        case 2:
                            return NKN_2Parameters.ПолноеВключение ? 26 : 0;
                        case 3:
                            return Включен ? 20 : 0;
                        case 5:
                        case 6:
                        case 8:
                        case 9:
                            return NKN_2Parameters.ПолноеВключение ? 24 : 0;
                        case 10:
                            return Включен ? 24 : 0;
                    }
                }
                return 0;
            }
        }

        #endregion

        #region ПереключательВидРаботы

        /// <summary>
        /// 1 - ЧТ-200,
        /// 2 - ЧТ-20,
        /// 3 - ОФТ2,4-5,2,
        /// 4 - ОФТ48
        /// </summary>
        public static int ПереключательВидРаботы
        {
            get { return _переключательВидРаботы; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательВидРаботы = value;
                    OnParameterChanged();
                }
            }
        }

        #endregion

        #region ПереключательВходЧТ

        public static int ПереключательВходЧТ
        {
            get { return _переключательВходЧТ; }
            set
            {
                if (value > 0 && value < 4)
                {
                    _переключательВходЧТ = value;
                    OnParameterChanged();
                }
            }
        }

        #endregion

        public delegate void ParameterChangedHandler();

        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }
    }
}
