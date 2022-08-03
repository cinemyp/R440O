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
        private static N13_2Parameters instance;
        public static N13_2Parameters getInstance()
        {
            if (instance == null)
                instance = new N13_2Parameters();
            return instance;
        }

        #region Лампочки

        public bool Включен
        {
            get { return N15Parameters.getInstance().Н13_2 && N502BParameters.getInstance().ТумблерН13_2; }
        }

        public bool Неисправен
        {
            get { return N15Parameters.getInstance().Н13_2 && !N502BParameters.getInstance().ТумблерН13_2; }
        }
        public bool ЛампочкаПерегрузкаИстКоллектора
        {
            get { return Неисправен; }
        }
        public bool ЛампочкаАнодВключен
        {
            get { return Включен; }
        }


        #endregion

        #region Индикаторы

        public float ИндикаторТокЗамедлСистемы
        {
            get { return ЛампочкаАнодВключен ? 2.5F : 0; }
        }
        public int ИндикаторТокКоллектора
        {
            get { return ЛампочкаАнодВключен ? 170 : 0; }
        }
        #endregion

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        public void ResetParameters()
        {
            OnParameterChanged();
        }

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        private Signal ВходнойСигнал
        {
            get
            {
                Signal inputSignal = null;
                if (NKN_1Parameters.getInstance().ДистанционноеВключение && A205M_1Parameters.getInstance().ВыходнойСигнал != null)
                {
                    inputSignal = A205M_1Parameters.getInstance().ВыходнойСигнал;
                }

                if (NKN_2Parameters.getInstance().ДистанционноеВключение && A205M_2Parameters.ВыходнойСигнал != null)
                {
                    inputSignal = A205M_2Parameters.ВыходнойСигнал;
                }
                return inputSignal;
            }
        }

        public Signal ВыходнойСигнал
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
