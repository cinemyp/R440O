using R440O.JsonAdapter;
using System;

namespace R440O.R440OForms.Wattmeter
{
    public class WattmeterParameters
    {
        private static WattmeterParameters instance;
        public static WattmeterParameters getInstance()
        {
            if (instance == null)
                instance = new WattmeterParameters();
            return instance;
        }
        public delegate void TestModuleHandler(ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new ActionStation(name, value);
            Action?.Invoke(action);
        }

        public bool _тумблерСеть;

        public bool ТумблерСеть
        {
            get { return _тумблерСеть; }
            set
            {
                _тумблерСеть = value;
                OnParameterChanged();
                OnAction("ТумблерСеть", Convert.ToInt32(_тумблерСеть));
            }
        }

        /// <summary>
        /// 1 - 6
        /// </summary>
        public int ПереключательРежимРаботы
        {
            get { return _переключательРежимРаботы; }
            set
            {
                if (value >= 1 && value <= 6) _переключательРежимРаботы = value;
                OnParameterChanged();
            }
        }
        public int _переключательРежимРаботы = 1;

        /// <summary>
        /// -120 - 120
        /// </summary>
        public int РегуляторГрубо
        {
            get { return _регуляторГрубо; }
            set { if (value <= 120 && value >= -120) _регуляторГрубо = value; }
        }

        public int _регуляторГрубо = -120;

        /// <summary>
        /// -120 - 120
        /// </summary> 
        public int РегуляторТочно
        {
            get { return _регуляторТочно; }
            set { if (value <= 120 && value >= -120) _регуляторТочно = value; }
        }

        public int _регуляторТочно = -120;

        /// <summary>
        /// -120 - 120
        /// </summary>
        public int РегуляторКоррекция
        {
            get { return _регуляторКоррекция; }
            set { if (value <= 120 && value >= -120) _регуляторКоррекция = value; }
        }

        public int _регуляторКоррекция = -120;

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }
    }
}
