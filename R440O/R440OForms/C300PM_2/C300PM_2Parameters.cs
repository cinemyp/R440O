namespace R440O.R440OForms.C300PM_2
{
    using C300M_3;
    using C300M_4;

    public class C300PM_2Parameters
    {
        private static C300PM_2Parameters instance;
        public static C300PM_2Parameters getInstance()
        {
            if (instance == null)
                instance = new C300PM_2Parameters();
            return instance;
        }

        /// <summary>
        /// Параметр для лампочки 1 комплекта. Возможные состояния: true, false
        /// </summary>
        public bool ЛампочкаКомплект1
        {
            get { return C300M_3Parameters.getInstance().ЛампочкаПитание; }
        }

        /// <summary>
        /// Параметр для лампочки 2 комплекта. Возможные состояния: true, false
        /// </summary>
        public bool ЛампочкаКомплект2
        {
            get { return C300M_4Parameters.getInstance().ЛампочкаПитание; }
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
