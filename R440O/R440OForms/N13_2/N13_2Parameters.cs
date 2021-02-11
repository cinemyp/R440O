using R440O.R440OForms.N15;
using R440O.R440OForms.N502B;
using R440O.R440OForms.NKN_1;
using R440O.R440OForms.NKN_2;
using R440O.R440OForms.A205M_1;
using R440O.R440OForms.A205M_2;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.N13_2
{
    class N13_2Parameters
    {
        #region Лампочки

        public static bool Включен
        {
            get { return N15Parameters.Н13_2 && N502BParameters.ТумблерН13_2; }
        }

        public static bool Неисправен
        {
            get { return N15Parameters.Н13_2 && !N502BParameters.ТумблерН13_2; }
        }
        public static bool ЛампочкаПерегрузкаИстКоллектора
        {
            get { return Неисправен; }
        }
        public static bool ЛампочкаАнодВключен
        {
            get { return Включен; }
        }


        #endregion

        #region Индикаторы

        public static float ИндикаторТокЗамедлСистемы
        {
            get { return ЛампочкаАнодВключен ? 2.5F : 0; }
        }
        public static int ИндикаторТокКоллектора
        {
            get { return ЛампочкаАнодВключен ? 170 : 0; }
        }
        #endregion

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        public static void ResetParameters()
        {
            OnParameterChanged();
        }

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        private static Signal ВходнойСигнал
        {
            get
            {
                Signal inputSignal = null;
                if (NKN_1Parameters.ДистанционноеВключение && A205M_1Parameters.ВыходнойСигнал != null)
                {
                    inputSignal = A205M_1Parameters.ВыходнойСигнал;
                }

                if (NKN_2Parameters.ДистанционноеВключение && A205M_2Parameters.ВыходнойСигнал != null)
                {
                    inputSignal = A205M_2Parameters.ВыходнойСигнал;
                }
                return inputSignal;
            }
        }

        public static Signal ВыходнойСигнал
        {
            get
            {
                if (!Включен)
                {
                    return null;
                }
                var сигнал = ВходнойСигнал;
                сигнал.Power = 130;
                return сигнал;
            }
        }
    }
}
