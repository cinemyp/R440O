using R440O.R440OForms.A403_1;

namespace R440O.R440OForms.A403_3
{
    class A403_3Parameters
    {
        private static A403_3Parameters instance;
        public static A403_3Parameters getInstance()
        {
            if (instance == null)
                instance = new A403_3Parameters();
            return instance;
        }

        private bool _тумблерКомплект;

        public bool Включен
        {
            get { return A403_1Parameters.getInstance().Включен; }
        }

        ////Тумблеры
        /// <summary>
        /// Определяет номер комплекта, выбранный на блоке.
        /// true - 1 комплект; false - 2 комплект
        /// </summary>
        public bool ТублерКомплект
        {
            get { return _тумблерКомплект; }
            set
            {
                if (Включен)
                    A403_1Parameters.getInstance().Комплект = !A403_1Parameters.getInstance().Комплект;
                _тумблерКомплект = value;

                OnParameterChanged();
                A403_1Parameters.getInstance().ResetParameters();
            }
        }

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
