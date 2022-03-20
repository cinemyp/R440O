using R440O.R440OForms.K03M_01;

namespace R440O.R440OForms.K02M_01Inside
{
    internal class K02M_01InsideParameters
    {
        private static K02M_01InsideParameters instance;
        public static K02M_01InsideParameters getInstance()
        {
            if (instance == null)
                instance = new K02M_01InsideParameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        #region Событие

        public delegate void ParameterChangedHandler();
        public  event ParameterChangedHandler ParameterChanged;

        private  void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }
        public  void ResetParameters()
        {
            K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
            OnParameterChanged();
        }

        #endregion

        #region Тумблер единственный на блоке

        private  bool _тумблерБ5;
        /// <summary>
        /// П-И
        /// </summary>
        public  bool ТумблерБ5
        {
            get
            {
                return _тумблерБ5;
            }
            set
            {
                _тумблерБ5 = value;
                ResetParameters();
            }
        }

        #endregion
           
    }
}
