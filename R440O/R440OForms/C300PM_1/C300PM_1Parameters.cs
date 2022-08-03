namespace R440O.R440OForms.C300PM_1
{
    using C300M_1;
    using C300M_2;

    public class C300PM_1Parameters
    {
        private static C300PM_1Parameters instance;
        public static C300PM_1Parameters getInstance()
        {
            if (instance == null)
                instance = new C300PM_1Parameters();
            return instance;
        }

        /// <summary>
        /// Параметр для лампочки 1 комплекта. Возможные состояния: true, false
        /// </summary>
        public bool ЛампочкаКомплект1
        {
            get { return C300M_1Parameters.getInstance().ЛампочкаПитание; }
        }

        /// <summary>
        /// Параметр для лампочки 2 комплекта. Возможные состояния: true, false
        /// </summary>
        public bool ЛампочкаКомплект2
        {
            get { return C300M_2Parameters.getInstance().ЛампочкаПитание; }
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
