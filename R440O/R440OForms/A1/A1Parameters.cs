using R440O.R440OForms.P220_27G_2;
using R440O.R440OForms.P220_27G_3;
using R440O.R440OForms.N18_M;
using R440O.R440OForms.BMA_M_1;

namespace R440O.R440OForms.A1
{
    using System.Collections.Generic;
    using ShareTypes.SignalTypes;
    using N15;
    using global::R440O.JsonAdapter;

    public class A1Parameters
    {
        private static A1Parameters instance;
        public static A1Parameters getInstance()
        {
            if (instance == null)
                instance = new A1Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new ActionStation(name, value);
            Action?.Invoke(action);
        }
        #region Работа блока

        public bool Включен
        {
            get
            {
                return (P220_27G_2Parameters.getInstance().Включен || P220_27G_3Parameters.getInstance().Включен) &&
                       (ТумблерМуДу || !ТумблерМуДу && N15Parameters.getInstance().ТумблерА1);
            }
        }

        private void ПолучитьИнформациюБаслет(Signal сигнал)
        {
            if (N18_MParameters.getInstance().ПереключательПРД == 2 && BMA_M_1Parameters.getInstance().СигналСБМБ != null)
            {
                if (N18_MParameters.getInstance().ПереключательПрдБма12 == 3 || N18_MParameters.getInstance().ПереключательПрдБма12 == 4)
                {
                    сигнал.Elements[0].SetInformationInChanelByNumber(1,
                        BMA_M_1Parameters.getInstance().СигналСБМБ);
                }
                else if (N18_MParameters.getInstance().ПереключательПрдБма12 == 1 || N18_MParameters.getInstance().ПереключательПрдБма12 == 5)
                {
                    сигнал.Elements[0].SetInformationInChanelByNumber(2,
                        BMA_M_1Parameters.getInstance().СигналСБМБ);
                }
                else if (N18_MParameters.getInstance().ПереключательПрдБма12 == 2 || N18_MParameters.getInstance().ПереключательПрдБма12 == 6)
                {
                    сигнал.Elements[0].SetInformationInChanelByNumber(3,
                        BMA_M_1Parameters.getInstance().СигналСБМБ);
                }
            }
        }

        public Signal ВыходнойСигнал
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
        public bool ЛампочкаБОЧ;

        public bool ЛампочкаФСПК
        {
            get
            {
                return Включен;
            }
        }

        public bool ЛампочкаТКААвария;

        #region ТЛФ1
        public bool НаличиеТЛФ1
        {
            get
            {
                return false;
            }
        }

        public bool ЛампочкаЭП1;

        public bool ЛампочкаПУЛ1_1
        {
            get
            {
                return Включен && !НаличиеТЛФ1;
            }
        }

        public bool ЛампочкаПУЛ1_2
        {
            get
            {
                return Включен && НаличиеТЛФ1;
            }
        }
        #endregion

        #region ТЛФ2
        public bool НаличиеТЛФ2
        {
            get
            {
                return false;
            }
        }

        public bool ЛампочкаЭП2;

        public bool ЛампочкаПУЛ2_1
        {
            get
            {
                return Включен && !НаличиеТЛФ2;
            }
        }

        public bool ЛампочкаПУЛ2_2
        {
            get
            {
                return Включен && НаличиеТЛФ2;
            }
        }
        #endregion

        #region ТЛФ1
        public bool НаличиеТЛФ3
        {
            get
            {
                return false;
            }
        }

        public bool ЛампочкаЭП3;

        public bool ЛампочкаПУЛ3_1
        {
            get
            {
                return Включен && !НаличиеТЛФ3;
            }
        }

        public bool ЛампочкаПУЛ3_2
        {
            get
            {
                return Включен && НаличиеТЛФ3;
            }
        }
        #endregion

        public bool ЛампочкаНеиспр;
        public bool _лампочкаПитание;

        // Управляющие элементы
        private bool _тумблерМуДу;
        private bool _кнопкаСкоростьГР;
        private bool _кнопкаСкоростьАб_1ТЛФК;


        /// <summary>
        /// Получает или задает возможные состояния: true - местное управление, false - дистанционное управление
        /// </summary>
        public bool ТумблерМуДу
        {
            get { return _тумблерМуДу; }
            set
            {
                _тумблерМуДу = value;
                OnParameterChanged();
            }
        }

        public bool КнопкаСкоростьГр
        {
            get { return _кнопкаСкоростьГР; }
            set
            {
                _кнопкаСкоростьГР = value;
                N15Parameters.getInstance().ResetDiscret();
                N18_MParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        public bool КнопкаСкоростьАб_1ТЛФК
        {
            get { return _кнопкаСкоростьАб_1ТЛФК; }
            set
            {
                _кнопкаСкоростьАб_1ТЛФК = value;
                N15Parameters.getInstance().ResetDiscret();
                N18_MParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        public bool ЛампочкаПитание
        {
            get { return Включен; }
        }

        #endregion

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;


        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }
    }
}
