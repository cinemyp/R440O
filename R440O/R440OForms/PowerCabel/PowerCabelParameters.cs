using System;

namespace R440O.R440OForms.PowerCabel
{
    using global::R440O.BaseClasses;
    using global::R440O.JsonAdapter;
    using N502B;

    public class PowerCabelParameters
    {
        private static PowerCabelParameters instance;

        public static PowerCabelParameters getInstance()
        {
            if (instance == null)
                instance = new PowerCabelParameters();
            return instance;
        }

        public ITestModule TestModuleRef { get; set; }

        protected PowerCabelParameters()
        {
            Напряжение = 380;
            var generator = new Random();
            var zeroToOne = generator.NextDouble();
            Напряжение = zeroToOne > 0.5F ? 380 : 220;            
        }

        private bool _тумблерОсвещение;

        public bool ТумблерОсвещение
        {
            get { return _тумблерОсвещение; }
            set
            {
                _тумблерОсвещение = value;
                OnParameterChanged();
            }
        }

        private bool _кабельСеть;

        public bool КабельСеть
        {
            get { return _кабельСеть; }
            set
            {
                if (!N502BParameters.getInstance().ПереключательСеть) _кабельСеть = value;
                else СтанцияСгорела();
                
                OnParameterChanged();

                N502BParameters.getInstance().ResetParameters();
            }
        }

        public int Напряжение;

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }

        /// <summary>
        /// Вызывается, если пользователь совершил неправильные действия по обесточиванию станции.
        /// </summary>
        public event ParameterChangedHandler СтанцияСгорела;

        public void SetDefaultParameters()
        {
            ТумблерОсвещение = false;
            КабельСеть = false;
        }
    }
}
