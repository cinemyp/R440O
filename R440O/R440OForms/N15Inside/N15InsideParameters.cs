﻿using System.Collections.Generic;
using R440O.R440OForms.A205M_1;
using R440O.R440OForms.PU_K1_1;

namespace R440O.R440OForms.N15Inside
{
    using A1;
    using C300M_1;
    using N15;
    using N18_M;
    using BaseClasses;
    using ShareTypes.SignalTypes;
    using BMA_M_1;

    public class N15InsideParameters
    {
        public static ITestModule TestModuleRef { get; set; }
        #region Работа блока
        public static bool Включен
        {
            get
            {
                return N15Parameters.getInstance().Включен;
            }
        }

        /// <summary>
        /// Выходной сигнал передающего тракта, проходит если выбрана необходимая скорость. Задаёт тип модуляции сигнала.
        /// ПУЛ на Н15 должен быть включен.
        /// </summary>
        public static Signal ВыходПередающегоТракта
        {
            get
            {
                if (!Включен) return null;

                if (N15Parameters.getInstance().ТумблерТлфТлгПрд && !PU_K1_1Parameters.КулонК1Подключен)
                {    
                    if (N18_MParameters.ПереключательПРД == 2 && A1Parameters.ВыходнойСигнал != null &&
                    Signal.IsEquivalentSpeed(СкоростьПередачи, A1Parameters.ВыходнойСигнал.GroupSpeed))
                    {
                        var signal = A1Parameters.ВыходнойСигнал;
                        signal.Modulation = МодуляцияПередачи;
                        signal.GroupSpeed = СкоростьПередачи;
                        return signal;
                    }
                    if (N18_MParameters.ПереключательПРД == 3 &&
                        N18_MParameters.ПереключательПрдБма12 == 7 && BMA_M_1Parameters.СигналСБМБ != null)
                    {
                        var signal = new Signal { GroupSpeed = СкоростьПередачи, Modulation = МодуляцияПередачи };
                        signal.Elements = new List<SignalElement>()
                        {
                            new SignalElement(new[] { -1, 1.2 } )
                        };
                        signal.Elements[0].SetInformationInChanelByNumber(1, BMA_M_1Parameters.СигналСБМБ);
                        return signal;
                    }
                    return new Signal { GroupSpeed = СкоростьПередачи, Modulation = МодуляцияПередачи };
                    
                }
                return new Signal { GroupSpeed = СкоростьПередачи, Modulation = МодуляцияПередачи };
            }
        }

        /// <summary>
        /// Выходной сигнал передающего тракта, проходит если выбраны необходимая скорость и модуляция. 
        /// ПУЛ на Н15 должен быть включен.
        /// </summary>
        public static Signal ВыходПриемногоТракта
        {
            get
            {
                if (Включен &&
                    N15Parameters.getInstance().ТумблерТлфТлгПрм && C300M_1Parameters.getInstance().ПойманныйСигнал != null &&
                    Signal.IsEquivalentSpeed(C300M_1Parameters.getInstance().ПойманныйСигнал.GroupSpeed, СкоростьПриема) &&
                    C300M_1Parameters.getInstance().ПойманныйСигнал.Modulation == ТумблерПУЛ480ПРМ_1)
                    return C300M_1Parameters.getInstance().ПойманныйСигнал;
                return null;
            }
        }

        #endregion

        #region Тумблеры
        private static Модуляция _тумблерПУЛ480ПРМ_1 = Модуляция.ЧТ;
        private static Модуляция _тумблерПУЛ480ПРМ_2 = Модуляция.ЧТ;
        private static Модуляция _тумблерПУЛ48ПРД_1 = Модуляция.ОФТ;
        private static Модуляция _тумблерПУЛ48ПРД_2 = Модуляция.ОФТ;

        public static Модуляция МодуляцияПриема
        {
            get
            {
                return ТумблерПУЛ480ПРМ_1 != ТумблерПУЛ480ПРМ_2 ? Модуляция.Отсутствует : ТумблерПУЛ480ПРМ_1;
            }
        }

        public static Модуляция ТумблерПУЛ480ПРМ_1
        {
            get { return _тумблерПУЛ480ПРМ_1; }
            set
            {
                _тумблерПУЛ480ПРМ_1 = value;
                OnParameterChanged();
                N15Parameters.getInstance().ResetDiscret();
            }
        }

        public static Модуляция ТумблерПУЛ480ПРМ_2
        {
            get { return _тумблерПУЛ480ПРМ_2; }
            set
            {
                _тумблерПУЛ480ПРМ_2 = value;
                OnParameterChanged();
            }
        }

        public static Модуляция МодуляцияПередачи
        {
            get
            {
                return ТумблерПУЛ48ПРД_1 != ТумблерПУЛ48ПРД_2 ? Модуляция.Отсутствует : ТумблерПУЛ48ПРД_1;
            }
        }

        public static Модуляция ТумблерПУЛ48ПРД_1
        {
            get { return _тумблерПУЛ48ПРД_1; }
            set
            {
                _тумблерПУЛ48ПРД_1 = value;
                OnParameterChanged();
                N15Parameters.getInstance().ResetDiscret();
            }
        }

        public static Модуляция ТумблерПУЛ48ПРД_2
        {
            get { return _тумблерПУЛ48ПРД_2; }
            set
            {
                _тумблерПУЛ48ПРД_2 = value;
                OnParameterChanged();
            }
        }
        #endregion

        #region Переключатели

        private static double СкоростьПриема
        {
            get
            {
                switch (_переключательПУЛ480ПРМ_1)
                {
                    case 1:
                        return 1.2;
                    case 2:
                        return 2.4;
                    case 3:
                        return 4.8;
                    case 4:
                        return 5.2;
                    case 5:
                        return 48;
                    case 6:
                        return 96;
                    case 7:
                        return 144;
                    case 8:
                        return 240;
                    case 9:
                        return 480;
                }
                return 0;
            }
        }

        private static int _переключательПУЛ480ПРМ_1 = 1;

        /// <summary>
        /// 1 - 1.2,
        /// 2 - 2.4,
        /// 3 - 4.8,
        /// 4 - 5.2,
        /// 5 - 48,
        /// 6 - 96,
        /// 7 - 144,
        /// 8 - 240,
        /// 9 - 480
        /// </summary>
        public static int ПереключательПУЛ480ПРМ_1
        {
            get { return _переключательПУЛ480ПРМ_1; }

            set
            {
                if (value > 0 && value < 10)
                {
                    _переключательПУЛ480ПРМ_1 = value;
                    OnParameterChanged();
                    N15Parameters.getInstance().ResetDiscret();
                }
            }
        }

        private static int _переключательПУЛ480ПРМ_2 = 1;

        /// <summary>
        /// 1 - 1.2,
        /// 2 - 2.4,
        /// 3 - 4.8,
        /// 4 - 5.2,
        /// 5 - 48,
        /// 6 - 96,
        /// 7 - 144,
        /// 8 - 240,
        /// 9 - 480
        /// </summary>
        public static int ПереключательПУЛ480ПРМ_2
        {
            get
            {
                return _переключательПУЛ480ПРМ_2;
            }

            set
            {
                if (value > 0 && value < 10)
                {
                    _переключательПУЛ480ПРМ_2 = value;
                    OnParameterChanged();
                    N15Parameters.getInstance().ResetDiscret();
                }
            }
        }

        private static double СкоростьПередачи
        {
            get
            {
                if (_переключательПУЛ48ПРД_1 != _переключательПУЛ48ПРД_2) return 0;
                switch (_переключательПУЛ48ПРД_1)
                {
                    case 1:
                        return 1.2;
                    case 2:
                        return 2.4;
                    case 3:
                        return 4.8;
                    case 4:
                        return 5.2;
                    case 5:
                        return 48; 
                }
                return 0;
            }
        }

        private static int _переключательПУЛ48ПРД_1 = 1;

        /// <summary>
        /// 1 - 1.2,
        /// 2 - 2.4,
        /// 3 - 4.8,
        /// 4 - 5.2,
        /// 5 - 48
        /// </summary>
        public static int ПереключательПУЛ48ПРД_1
        {
            get { return _переключательПУЛ48ПРД_1; }

            set
            {
                if (value > 0 && value < 6)
                {
                    _переключательПУЛ48ПРД_1 = value;
                    OnParameterChanged();
                    N15Parameters.getInstance().ResetDiscret();
                }
            }
        }

        private static int _переключательПУЛ48ПРД_2 = 1;

        /// <summary>
        /// 1 - 1.2,
        /// 2 - 2.4,
        /// 3 - 4.8,
        /// 4 - 5.2,
        /// 5 - 48
        /// </summary>
        public static int ПереключательПУЛ48ПРД_2
        {
            get { return _переключательПУЛ48ПРД_2; }

            set
            {
                if (value > 0 && value < 6)
                {
                    _переключательПУЛ48ПРД_2 = value;
                    OnParameterChanged();
                    N15Parameters.getInstance().ResetDiscret();
                }
            }
        }
        #endregion

        public delegate void TestModuleHandler(ITestModule module);
        public static event TestModuleHandler Action;
        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
            A205M_1Parameters.getInstance().ResetParameters();
            OnAction();
        }
        private static void OnAction()
        {
            Action?.Invoke(TestModuleRef);
        }
    }
}
