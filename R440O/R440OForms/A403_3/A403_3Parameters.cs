using R440O.R440OForms.A403_1;

namespace R440O.R440OForms.A403_3
{
    class A403_3Parameters
    {
        private static bool _тумблерКомплект;

        public static bool Включен
        {
            get { return A403_1Parameters.Включен; }
        }

        ////Тумблеры
        /// <summary>
        /// Определяет номер комплекта, выбранный на блоке.
        /// true - 1 комплект; false - 2 комплект
        /// </summary>
        public static bool ТублерКомплект
        {
            get { return _тумблерКомплект; }
            set
            {
                if (Включен)
                    A403_1Parameters.Комплект = !A403_1Parameters.Комплект;
                _тумблерКомплект = value;

                OnParameterChanged();
                A403_1Parameters.ResetParameters();
            }
        }

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
