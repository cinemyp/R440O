namespace R440O.Parameters
{
    internal class K02M_02InsideParameters
    {
        private static K02M_02InsideParameters instance;
        public static K02M_02InsideParameters getInstance()
        {
            if (instance == null)
                instance = new K02M_02InsideParameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        ////Лампочки
        public bool _K02M_02InsideТумблерБ5;
        public bool K02M_02InsideТумблерБ5
        {
            get
            {
                return _K02M_02InsideТумблерБ5; 
            }
            set
            {
                _K02M_02InsideТумблерБ5 = value;

            }
        }
    }
}
