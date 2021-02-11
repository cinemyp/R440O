namespace R440O.R440OForms.C300PM_1
{
    using C300M_1;
    using C300M_2;

    public static class C300PM_1Parameters
    {
        /// <summary>
        /// Параметр для лампочки 1 комплекта. Возможные состояния: true, false
        /// </summary>
        public static bool ЛампочкаКомплект1
        {
            get { return C300M_1Parameters.ЛампочкаПитание; }
        }

        /// <summary>
        /// Параметр для лампочки 2 комплекта. Возможные состояния: true, false
        /// </summary>
        public static bool ЛампочкаКомплект2
        {
            get { return C300M_2Parameters.ЛампочкаПитание; }
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
