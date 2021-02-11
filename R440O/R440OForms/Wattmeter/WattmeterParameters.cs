namespace R440O.R440OForms.Wattmeter
{
    public static class WattmeterParameters
    {
        public static bool _тумблерСеть;

        public static bool ТумблерСеть
        {
            get { return _тумблерСеть; }
            set
            {
                _тумблерСеть = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// 1 - 6
        /// </summary>
        public static int ПереключательРежимРаботы
        {
            get { return _переключательРежимРаботы; }
            set
            {
                if (value >= 1 && value <= 6) _переключательРежимРаботы = value;
                OnParameterChanged();
            }
        }
        public static int _переключательРежимРаботы = 1;

        /// <summary>
        /// -120 - 120
        /// </summary>
        public static int РегуляторГрубо
        {
            get { return _регуляторГрубо; }
            set { if (value <= 120 && value >= -120) _регуляторГрубо = value; }
        }

        public static int _регуляторГрубо = -120;

        /// <summary>
        /// -120 - 120
        /// </summary> 
        public static int РегуляторТочно
        {
            get { return _регуляторТочно; }
            set { if (value <= 120 && value >= -120) _регуляторТочно = value; }
        }

        public static int _регуляторТочно = -120;

        /// <summary>
        /// -120 - 120
        /// </summary>
        public static int РегуляторКоррекция
        {
            get { return _регуляторКоррекция; }
            set { if (value <= 120 && value >= -120) _регуляторКоррекция = value; }
        }

        public static int _регуляторКоррекция = -120;

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }
    }
}
