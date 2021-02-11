using System;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.BMB;
using R440O.R440OForms.N18_M;
using ShareTypes.SignalTypes;
using R440O.R440OForms.PU_K1_1;

namespace R440O.R440OForms.K02M_01
{
    public static class K02M_01Parameters
    {
        private static bool Питание
        {
            get { return PU_K1_1Parameters.Включен; }
        }

        #region Лампочки

        public static KulonSignal Сигнал
        {
            get 
            {
                return K03M_01Parameters.НайденныйСигнал;
            }
        }

        public static bool ЛампочкаКаналыОбнаруженияЛ
        {
            get
            {
                return Питание && (K03M_01Parameters.СтатусПоиска == 2 &&
                      K03M_01Parameters.ВременнаяПозицияПоиска <= -100 &&
                      K03M_01Parameters.ВременнаяПозицияПоиска > -200);
            }
        }

        public static bool ЛампочкаКаналыОбнаруженияЦ
        {
            get
            {
                return Питание && (K03M_01Parameters.СтатусПоиска == 2 &&
                        Math.Abs(K03M_01Parameters.ВременнаяПозицияПоиска) < 100);
            }
        }

        public static bool ЛампочкаКаналыОбнаруженияП
        {
            get
            {
                return Питание &&  (K03M_01Parameters.СтатусПоиска == 2 &&
                    K03M_01Parameters.ВременнаяПозицияПоиска >= 100 &&
                    K03M_01Parameters.ВременнаяПозицияПоиска < 200);
            }
        }

        public static bool ЛампочкаПоискСигналов
        {
            get { return Питание && (K03M_01Parameters.СтатусПоиска == 1 || K03M_01Parameters.СтатусПоиска == 3); }
        }

        public static bool ЛампочкаПилот
        {
            get { return Питание && K03M_01Parameters.СтатусПоиска == 2; }
        }

        public static bool ЛампочкаИнформ
        {
            get { return Питание && K03M_01Parameters.СтатусПоиска == 2; }
        }

        #endregion

        #region Переключатели

        private static int _переключательСкорость = 1;
        private static int _переключательВклОткл = 1;
        private static int _переключательНапряжение1К = 1;
        private static int _переключательНапряжение2К = 1;

        public static int ПереключательСкорость
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

        public static int ПереключательВклОткл
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

        public static int ПереключательНапряжение1К
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

        public static int ПереключательНапряжение2К
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
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ResetParameters()
        {
            if (N18_MParameters.ПереключательВходК121 == 1 || N18_MParameters.ПереключательВходК121 == 2)
            {
                //BMBParameters.ResetParameters();
                N18_MParameters.ResetParameters();
            }
            OnParameterChanged();
        }

        #endregion

        #region Кнопки

        public static void КнопкаНачатьПоиск_MouseDown()
        {
            K03M_01Parameters.НачатьПоискСНачала();
        }

        public static void КнопкаНачатьПоиск_MouseUp()
        {
        }

        #endregion
    }
}
