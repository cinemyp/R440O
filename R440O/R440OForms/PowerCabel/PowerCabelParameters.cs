using System;

namespace R440O.R440OForms.PowerCabel
{
    using global::R440O.BaseClasses;
    using N502B;

    public static class PowerCabelParameters
    {
        public static ITestModule TestModuleRef { get; set; }

        static PowerCabelParameters()
        {
            Напряжение = 380;
            var generator = new Random();
            var zeroToOne = generator.NextDouble();
            Напряжение = zeroToOne > 0.5F ? 380 : 220;            
        }

        private static bool _тумблерОсвещение;

        public static bool ТумблерОсвещение
        {
            get { return _тумблерОсвещение; }
            set
            {
                _тумблерОсвещение = value;
                OnParameterChanged();
            }
        }

        private static bool _кабельСеть;

        public static bool КабельСеть
        {
            get { return _кабельСеть; }
            set
            {
                if (!N502BParameters.ПереключательСеть) _кабельСеть = value;
                else СтанцияСгорела();
                
                OnParameterChanged();

                N502BParameters.ResetParameters();
            }
        }

        public static int Напряжение;
        public delegate void TestModuleHandler(ITestModule module);
        public static event TestModuleHandler Action;
        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
            OnAction();
        }

        private static void OnAction()
        {
            Action?.Invoke(TestModuleRef);
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }

        /// <summary>
        /// Вызывается, если пользователь совершил неправильные действия по обесточиванию станции.
        /// </summary>
        public static event ParameterChangedHandler СтанцияСгорела;

        public static void SetDefaultParameters()
        {
            ТумблерОсвещение = false;
            КабельСеть = false;
        }
    }
}
