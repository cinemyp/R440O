using R440O.R440OForms.A205M_1;
using R440O.R440OForms.A205M_2;
using R440O.R440OForms.N18_M;

namespace R440O.R440OForms.N18_M_H28
{
    public class N18_M_H28Parameters
    {
        private static N18_M_H28Parameters instance;
        public static N18_M_H28Parameters getInstance()
        {
            if (instance == null)
                instance = new N18_M_H28Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        public int _активныйКабель = 0;

        public bool ПодюклченК11 { get { return _активныйКабель == 1; } }

        /// <summary>
        /// Кабель воткнутый в верхнюю панель.
        /// 0 - Отключено, 1 - К11, 2 - K12.
        /// </summary>
        public int АктивныйКабель
        {
            get { return _активныйКабель; }
            set
            {
                _активныйКабель = value;
                ResetParameters();
            }
        }

        #region Cобытие

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            N18_MParameters.getInstance().ResetParameters();
            A205M_1Parameters.getInstance().ResetParameters();
            A205M_2Parameters.ResetParameters();
            OnParameterChanged();
        }

        #endregion
    }
}
