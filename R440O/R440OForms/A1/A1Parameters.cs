using R440O.R440OForms.P220_27G_2;
using R440O.R440OForms.P220_27G_3;
using R440O.R440OForms.N18_M;
using R440O.R440OForms.BMA_M_1;

namespace R440O.R440OForms.A1
{
    using System.Collections.Generic;
    using ShareTypes.SignalTypes;
    using N15;

    public static class A1Parameters
    {
        #region Работа блока

        public static bool Включен
        {
            get
            {
                return (P220_27G_2Parameters.Включен || P220_27G_3Parameters.Включен) &&
                       (ТумблерМуДу || !ТумблерМуДу && N15Parameters.ТумблерА1);
            }
        }

        private static void ПолучитьИнформациюБаслет(Signal сигнал)
        {
            if (N18_MParameters.ПереключательПРД == 2 && BMA_M_1Parameters.СигналСБМБ != null)
            {
                if (N18_MParameters.ПереключательПрдБма12 == 3 || N18_MParameters.ПереключательПрдБма12 == 4)
                {
                    сигнал.Elements[0].SetInformationInChanelByNumber(1,
                        BMA_M_1Parameters.СигналСБМБ); 
                }
                else if (N18_MParameters.ПереключательПрдБма12 == 1 || N18_MParameters.ПереключательПрдБма12 == 5)
                {
                    сигнал.Elements[0].SetInformationInChanelByNumber(2,
                        BMA_M_1Parameters.СигналСБМБ);
                }
                else if (N18_MParameters.ПереключательПрдБма12 == 2 || N18_MParameters.ПереключательПрдБма12 == 6)
                {
                    сигнал.Elements[0].SetInformationInChanelByNumber(3,
                        BMA_M_1Parameters.СигналСБМБ);
                }
            }
        }

        public static Signal ВыходнойСигнал
        {
            get
            {
                if (!Включен) return null;
                Signal сигнал = null;
                if (!КнопкаСкоростьГр)
                    if (КнопкаСкоростьАб_1ТЛФК)
                        сигнал = new Signal
                        {
                            GroupSpeed = 4.8,
                            Elements = new List<SignalElement>()
                            {
                                new SignalElement(new [] { -1, 2.4, 1.2, 0, 0.1, 0.1, 0.05, 0.025 })
                            },
                            Level = 50
                        };
                    else сигнал = new Signal
                    {
                        GroupSpeed = 4.8,
                        Elements = new List<SignalElement>()
                            {
                                new SignalElement(new [] { -1, 1.2, 1.2, 1.2, 0.1, 0.1, 0.05, 0.025 })
                            },
                        Level = 50
                    };
                else
                сигнал = new Signal
                {
                    GroupSpeed = 2.4,
                    Elements = new List<SignalElement>()
                            {
                                new SignalElement(new [] { -1, 0, 1.2, 0, 0.1, 0.1, 0.05, 0.025 })
                            },
                    Level = 50
                };
                ПолучитьИнформациюБаслет(сигнал);
                return сигнал;
            }
        }

        #endregion

        #region Элементы блока
        ////Лампочки
        public static bool ЛампочкаБОЧ;

        public static bool ЛампочкаФСПК
        {
            get
            {
                return Включен;
            }
        }

        public static bool ЛампочкаТКААвария;

        #region ТЛФ1
        public static bool НаличиеТЛФ1
        {
            get
            {
                return false;
            }
        }

        public static bool ЛампочкаЭП1;

        public static bool ЛампочкаПУЛ1_1
        {
            get
            {
                return Включен && !НаличиеТЛФ1;
            }
        }

        public static bool ЛампочкаПУЛ1_2
        {
            get
            {
                return Включен && НаличиеТЛФ1;
            }
        }
        #endregion

        #region ТЛФ2
        public static bool НаличиеТЛФ2
        {
            get
            {
                return false;
            }
        }

        public static bool ЛампочкаЭП2;

        public static bool ЛампочкаПУЛ2_1
        {
            get
            {
                return Включен && !НаличиеТЛФ2;
            }
        }

        public static bool ЛампочкаПУЛ2_2
        {
            get
            {
                return Включен && НаличиеТЛФ2;
            }
        }
        #endregion

        #region ТЛФ1
        public static bool НаличиеТЛФ3
        {
            get
            {
                return false;
            }
        }

        public static bool ЛампочкаЭП3;

        public static bool ЛампочкаПУЛ3_1
        {
            get
            {
                return Включен && !НаличиеТЛФ3;
            }
        }

        public static bool ЛампочкаПУЛ3_2
        {
            get
            {
                return Включен && НаличиеТЛФ3;
            }
        }
        #endregion

        public static bool ЛампочкаНеиспр;
        public static bool _лампочкаПитание;

        // Управляющие элементы
        private static bool _тумблерМуДу;
        private static bool _кнопкаСкоростьГР;
        private static bool _кнопкаСкоростьАб_1ТЛФК;


        /// <summary>
        /// Получает или задает возможные состояния: true - местное управление, false - дистанционное управление
        /// </summary>
        public static bool ТумблерМуДу
        {
            get { return _тумблерМуДу; }
            set
            {
                _тумблерМуДу = value;
                OnParameterChanged();
            }
        }

        public static bool КнопкаСкоростьГр
        {
            get { return _кнопкаСкоростьГР; }
            set
            {
                _кнопкаСкоростьГР = value;
                N15Parameters.ResetDiscret();
                N18_MParameters.ResetParameters();
                OnParameterChanged();
            }
        }

        public static bool КнопкаСкоростьАб_1ТЛФК
        {
            get { return _кнопкаСкоростьАб_1ТЛФК; }
            set
            {
                _кнопкаСкоростьАб_1ТЛФК = value;
                N15Parameters.ResetDiscret();
                N18_MParameters.ResetParameters();
                OnParameterChanged();
            }
        }

        public static bool ЛампочкаПитание
        {
            get { return Включен; }
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
