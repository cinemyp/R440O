using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R440O.R440OForms.BMA_M_1;

namespace R440O.R440OForms.TLF_TCH
{
    class TLF_TCHParametrs
    {
        private static TLF_TCHParametrs instance;
        public static TLF_TCHParametrs getInstance()
        {
            if (instance == null)
                instance = new TLF_TCHParametrs();
            return instance;
        }

        public List<int> НомераСоединений = new List<int>();

        public bool БМА1ПередачаКаналТЧ
        {
            get
            {
                int n = НомераСоединений.FindIndex(x => x == 1);
                return (n != -1);
            }
        }

        public bool БМА1ПриемКаналТЧ
        {
            get
            {
                int n = НомераСоединений.FindIndex(x => x == 2);
                return (n != -1);
            }
        }


        public void Соеденить(int номер)
        {
            int n = НомераСоединений.FindIndex(x => x == номер);
            if (n == -1)
                НомераСоединений.Add(номер);
            else
                НомераСоединений.Remove(номер);
            OnParameterChanged();
        }

        public delegate void ParameterChangedHandler();

        public event ParameterChangedHandler ParameterChanged;

        /// <summary>
        /// Вызов события, что значения параметров данной формы изменились.
        /// </summary>
        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
            BMA_M_1Parameters.getInstance().ResetParameters();
        }
    }

}
