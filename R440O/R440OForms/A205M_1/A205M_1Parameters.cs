﻿using R440O.Parameters;
using R440O.R440OForms.K04M_01;
using R440O.R440OForms.N15Inside;
using R440O.R440OForms.PU_K1_1;
using R440O.R440OForms.K05M_01;
using R440O.InternalBlocks;

namespace R440O.R440OForms.A205M_1
{
    using BaseClasses;
    using N18_M;
    using N502B;
    using NKN_1;
    using ShareTypes.SignalTypes;

    public class A205M_1Parameters
    {
        private static A205M_1Parameters instance;
        public static A205M_1Parameters getInstance()
        {
            if (instance == null)
                instance = new A205M_1Parameters();
            return instance;
        }

        public ITestModule TestModuleRef { get; set; }

        public bool Включен
        {
            get
            {
                return NKN_1Parameters.getInstance().ПолноеВключение;
                // && K05M_01Parameters.getInstance().СтрелкаУровеньВЗакрашенномСекторе;
            }
        }

        public bool Работа
        {
            get
            {
                return Включен && ((N18_MParameters.getInstance().ПереключательВходК121 == 1) ||
                       ((N18_MParameters.getInstance().ПереключательВходК121 != 1) && PU_K1_1Parameters.getInstance().ПереключателиВыставленыВерно /*PU_K1_2Parameters.ПереключателиВыставленыВерно*/));
            }
        }



        public bool КулонК2Подключен
        {
            //get { return PU_K1_2Parameters.Включен && N18_M_H28Parameters.getInstance().АктивныйКабель == 2; }
            get { return false; }
        }

        #region Выходной Сигнал
        //----------------------------------------
        //По схеме сигнал с А205 проходит так N16 -> N13-1/N13-2 -> N16. Но это мы опускаем и идем на А503Б, так как мощность не является важным параметром
        //---------------------------------------
        public Signal ВыходнойСигнал
        {
            get
            {
                var wave = ПереключательВолнаX10000 * 10000 +
                                 ПереключательВолнаX1000 * 1000 +
                                 ПереключательВолнаX100 * 100 +
                                 ПереключательВолнаX10 * 10 +
                                 ПереключательВолнаX1;

                if (Включен && wave >= 1500 && wave <= 51499 && N15InsideParameters.getInstance().ВыходПередающегоТракта != null)
                {
                    var signal = N15InsideParameters.getInstance().ВыходПередающегоТракта;
                    signal.Level = 20;
                    signal.Wave = wave;
                    signal.Frequency = 5710000 + 10 * wave;
                    //if (Работа && (N18_MParameters.getInstance().ПереключательВходК121 != 1) && PU_K1_1Parameters.getInstance().Включен)
                    if (PU_K1_1Parameters.getInstance().КулонК1Подключен)
                    {
                        signal.KulonSignal = K05M_01Parameters.getInstance().Сигнал;
                        // сомтительно
                        signal.Frequency += K05M_01Parameters.getInstance().Сигнал.Frequency - K04M_01Parameters.getInstance().НачальнаяЧастотаПРД;
                        signal.Level = K05M_01Parameters.getInstance().Сигнал.Level;
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
                                break;
                            }
                        case 2:
                            {
                                if (signal.Modulation == Модуляция.ЧТ && signal.GroupSpeed >= 0.025 &&
                                    signal.GroupSpeed <= 5.2)
                                {
                                    return signal;
                                }
                                break;
                            }
                        case 3:
                            {
                                if (signal.Modulation == Модуляция.ОФТ && signal.GroupSpeed >= 1.2 &&
                                    signal.GroupSpeed <= 5.2)
                                {
                                    return signal;
                                }
                                break;
                            }
                        default:
                            {
                                if (signal.Modulation == Модуляция.ОФТ && signal.GroupSpeed >= 48)
                                {
                                    return signal;
                                }
                                break;
                            }
                    }
                }
                return null;
            }
        }

        #endregion

        #region Private fields

        private int _переключательВолнаX10000 = 0;
        private int _переключательВолнаХ1000 = 0;
        private int _переключательВолнаХ100 = 0;
        private int _переключательВолнаХ10 = 0;
        private int _переключательВолнаХ1 = 0;
        private int _переключательКонтроль = 1;
        private int _переключательВидРаботы = 1;
        private int _переключательВходЧТ = 1;

        #endregion

        #region Работа блока

        ////Лампочки
        private bool _лампочкаНормРаб;

        public bool ЛампочкаНормРаб
        {
            get { return Работа; }
        }

        public bool ЛампочкаПерегрев { get; set; }

        private bool _тумблерКЭД;
        ////Тумблеры
        /// <summary>
        /// Получает или задает положение тумблера КЭД
        /// </summary>
        public bool ТумблерКЭД
        {
            get { return _тумблерКЭД; }
            set
            {
                _тумблерКЭД = value;
                ResetParameters();
            }
        }

        #endregion

        #region Переключатели волны

        public int ПереключательВолнаX10000
        {
            get { return _переключательВолнаX10000; }
            set
            {
                if (value > -1 && value < 6)
                {
                    _переключательВолнаX10000 = value;
                    ResetParameters();
                }
            }
        }

        public int ПереключательВолнаX1000
        {
            get { return _переключательВолнаХ1000; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ1000 = value;
                    ResetParameters();
                }
            }
        }

        public int ПереключательВолнаX100
        {
            get { return _переключательВолнаХ100; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ100 = value;
                    ResetParameters();
                }
            }
        }

        public int ПереключательВолнаX10
        {
            get { return _переключательВолнаХ10; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ10 = value;
                    ResetParameters();
                }
            }
        }

        public int ПереключательВолнаX1
        {
            get { return _переключательВолнаХ1; }
            set
            {
                if (value > -1 && value < 10)
                {
                    _переключательВолнаХ1 = value;
                    ResetParameters();
                }
            }
        }

        #endregion

        #region Контроль блока

        public int ПереключательКонтроль
        {
            get { return _переключательКонтроль; }
            set
            {
                if (value > 0 && value < 11)
                {
                    _переключательКонтроль = value;
                    ResetParameters();
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
        public int ИндикаторКонтроль
        {
            get
            {
                if ((N502BParameters.getInstance().ЛампочкаСфазировано
                     && N502BParameters.getInstance().ТумблерЭлектрооборудование
                     && N502BParameters.getInstance().ТумблерВыпрямитель27В))
                {
                    switch (_переключательКонтроль)
                    {
                        case 4:
                            return 20;
                        case 7:
                            return 30;
                        case 1:
                            return NKN_1Parameters.getInstance().ПолноеВключение ? 20 : 0;
                        case 2:
                            return NKN_1Parameters.getInstance().ПолноеВключение ? 26 : 0;
                        case 3:
                            return Включен ? 20 : 0;
                        case 5:
                        case 6:
                        case 8:
                        case 9:
                            return NKN_1Parameters.getInstance().ПолноеВключение ? 24 : 0;
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
        public int ПереключательВидРаботы
        {
            get { return _переключательВидРаботы; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательВидРаботы = value;
                    ResetParameters();
                }
            }
        }

        #endregion

        #region ПереключательВходЧТ

        public int ПереключательВходЧТ
        {
            get { return _переключательВходЧТ; }
            set
            {
                if (value > 0 && value < 4)
                {
                    _переключательВходЧТ = value;
                    ResetParameters();
                }
            }
        }

        #endregion

        public delegate void TestModuleHandler(ITestModule module);
        public event TestModuleHandler Action;
        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
            OnAction();
        }

        private void OnAction()
        {
            Action?.Invoke(TestModuleRef);
        }

        public void ResetParameters()
        {
            OnParameterChanged();
            //A503BParameters.ResetParameters();
        }
    }
}
