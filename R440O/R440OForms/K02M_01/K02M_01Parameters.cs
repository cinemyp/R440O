using System;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.BMB;
using R440O.R440OForms.N18_M;
using ShareTypes.SignalTypes;
using R440O.R440OForms.PU_K1_1;

namespace R440O.R440OForms.K02M_01
{
    public class K02M_01Parameters
    {
        private static K02M_01Parameters instance;
        public static K02M_01Parameters getInstance()
        {
            if (instance == null)
                instance = new K02M_01Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        private bool Питание
        {
            get { return PU_K1_1Parameters.getInstance().Включен; }
        }

        #region Лампочки

        public KulonSignal Сигнал
        {
            get
            {
                return K03M_01Parameters.getInstance().НайденныйСигнал;
            }
        }

        public bool ЛампочкаКаналыОбнаруженияЛ
        {
            get
            {
                return Питание && (K03M_01Parameters.getInstance().СтатусПоиска == 2 &&
                      K03M_01Parameters.getInstance().ВременнаяПозицияПоиска <= -100 &&
                      K03M_01Parameters.getInstance().ВременнаяПозицияПоиска > -200);
            }
        }

        public bool ЛампочкаКаналыОбнаруженияЦ
        {
            get
            {
                return Питание && (K03M_01Parameters.getInstance().СтатусПоиска == 2 &&
                        Math.Abs(K03M_01Parameters.getInstance().ВременнаяПозицияПоиска) < 100);
            }
        }

        public bool ЛампочкаКаналыОбнаруженияП
        {
            get
            {
                return Питание && (K03M_01Parameters.getInstance().СтатусПоиска == 2 &&
                    K03M_01Parameters.getInstance().ВременнаяПозицияПоиска >= 100 &&
                    K03M_01Parameters.getInstance().ВременнаяПозицияПоиска < 200);
            }
        }

        public bool ЛампочкаПоискСигналов
        {
            get { return Питание && (K03M_01Parameters.getInstance().СтатусПоиска == 1 || K03M_01Parameters.getInstance().СтатусПоиска == 3); }
        }

        public bool ЛампочкаПилот
        {
            get { return Питание && K03M_01Parameters.getInstance().СтатусПоиска == 2; }
        }

        public bool ЛампочкаИнформ
        {
            get { return Питание && K03M_01Parameters.getInstance().СтатусПоиска == 2; }
        }

        #endregion

        #region Переключатели

        private int _переключательСкорость = 1;
        private int _переключательВклОткл = 1;
        private int _переключательНапряжение1К = 1;
        private int _переключательНапряжение2К = 1;

        public int ПереключательСкорость
        {
            get { return _переключательСкорость; }

            set
            {
                if (value > 0 && value < 4)
                {
                    _переключательСкорость = value;
                    OnParameterChanged();
                }
            }
        }

        public int ПереключательВклОткл
        {
            get { return _переключательВклОткл; }

            set
            {
                if (value > 0 && value < 3)
                {
                    _переключательВклОткл = value;
                    OnParameterChanged();
                }
            }
        }

        public int ПереключательНапряжение1К
        {
            get { return _переключательНапряжение1К; }

            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательНапряжение1К = value;
                    OnParameterChanged();
                }
            }
        }

        public int ПереключательНапряжение2К
        {
            get { return _переключательНапряжение2К; }

            set
            {
                if (value > 0 && value < 4)
                {
                    _переключательНапряжение2К = value;
                    OnParameterChanged();
                }
            }
        }

        #endregion

        #region событие

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            if (N18_MParameters.getInstance().ПереключательВходК121 == 1 || N18_MParameters.getInstance().ПереключательВходК121 == 2)
            {
                //BMBParameters.getInstance().ResetParameters();
                N18_MParameters.getInstance().ResetParameters();
            }
            OnParameterChanged();
        }

        #endregion

        #region Кнопки

        public void КнопкаНачатьПоиск_MouseDown()
        {
            K03M_01Parameters.getInstance().НачатьПоискСНачала();
        }

        public void КнопкаНачатьПоиск_MouseUp()
        {
        }

        #endregion
    }
}
