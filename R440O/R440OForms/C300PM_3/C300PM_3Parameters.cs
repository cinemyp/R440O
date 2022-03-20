namespace R440O.R440OForms.C300PM_3
{
    using A304;

    public class C300PM_3Parameters
    {
        private static C300PM_3Parameters instance;
        public static C300PM_3Parameters getInstance()
        {
            if (instance == null)
                instance = new C300PM_3Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        /// <summary>
        /// Параметр для лампочки 1 комплекта. Возможные состояния: true, false
        /// </summary>
        public bool ЛампочкаКомплект1
        {
            get { return A304Parameters.getInstance().Лампочка1К; }
        }

        /// <summary>
        /// Параметр для лампочки 2 комплекта. Возможные состояния: true, false
        /// </summary>
        public bool ЛампочкаКомплект2
        {
            get { return A304Parameters.getInstance().Лампочка2К; }
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
