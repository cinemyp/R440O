using R440O.R440OForms.A205M_1;
using R440O.R440OForms.A205M_2;
using R440O.R440OForms.N18_M;

namespace R440O.R440OForms.N18_M_H28
{
    public static class N18_M_H28Parameters
    {
        public static int _активныйКабель = 0;

        public static bool ПодюклченК11 { get { return _активныйКабель == 1;  } }

        /// <summary>
        /// Кабель воткнутый в верхнюю панель.
        /// 0 - Отключено, 1 - К11, 2 - K12.
        /// </summary>
        public static int АктивныйКабель
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
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ResetParameters()
        {
            N18_MParameters.ResetParameters();
            A205M_1Parameters.ResetParameters();
            A205M_2Parameters.ResetParameters();
            OnParameterChanged();
        }

        #endregion
    }
}
