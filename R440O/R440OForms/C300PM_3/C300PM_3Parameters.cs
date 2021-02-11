namespace R440O.R440OForms.C300PM_3
{
    using A304;

    public static class C300PM_3Parameters
    {
        /// <summary>
        /// Параметр для лампочки 1 комплекта. Возможные состояния: true, false
        /// </summary>
        public static bool ЛампочкаКомплект1
        {
            get { return A304Parameters.Лампочка1К; }
        }

        /// <summary>
        /// Параметр для лампочки 2 комплекта. Возможные состояния: true, false
        /// </summary>
        public static bool ЛампочкаКомплект2
        {
            get { return A304Parameters.Лампочка2К; }
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
