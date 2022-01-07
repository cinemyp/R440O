using R440O.R440OForms.PowerCabel;

namespace R440O.R440OForms.VoltageStabilizer
{
    using global::R440O.BaseClasses;
    using global::R440O.R440OForms.N502B;

    public static class VoltageStabilizerParameters
    {
        public static ITestModule TestModuleRef { get; set; }
        #region Лампочки

        public static bool ЛампочкаСеть
        {
            get
            {
                return N502BParameters.ПереключательСеть &&
                           N502BParameters.ЛампочкаСеть
                             && КабельПодключенПравильно;
            }
        }
        public static bool ЛампочкаАвария
        {
            get
            {
                return N502BParameters.ПереключательСеть &&
                           N502BParameters.ЛампочкаСеть
                             && !КабельПодключенПравильно;
            }
        }
        #endregion

        #region Контроль Напряжения
        private static int _переключательКонтрольНапр = 1;
        /// <summary>
        /// Положение переключателя Контроль напряжения
        /// </summary>
        public static int ПереключательКонтрольНапр
        {
            get { return _переключательКонтрольНапр; }

            set
            {
                if (value > 0 && value < 13) _переключательКонтрольНапр = value;
                OnParameterChanged();
            }
        }

        public static int ИндикаторНапряжение
        {
            get
            {
                if (!ЛампочкаСеть) return 0;
                switch (_переключательКонтрольНапр)
                {
                    case 1:
                    case 2:
                    case 3:
                        return 220;
                    case 4:
                    case 5:
                    case 6:
                        return 220;
                    case 7:
                    case 8:
                    case 9:
                        return КабельВход == 220 ? 0 : 380;
                    case 10:
                    case 11:
                    case 12:
                        return 127;
                }
                return 0;
            }
        }

        #endregion

        #region Текущее напряжение

        ////Кабель
        /// <summary>
        /// Возможные состояния: 220, 380, 0
        /// </summary>
        private static int _кабельВход;

        public static int КабельВход
        {
            get { return _кабельВход; }

            set
            {
                if (N502BParameters.ЛампочкаСеть && N502BParameters.ПереключательСеть && ОператорСтанцииПораженТоком != null)
                {
                    ОператорСтанцииПораженТоком();
                }
                else _кабельВход = value;

                OnParameterChanged();
                N502BParameters.ResetParameters();
            }
        }

        /// <summary>
        /// Условие определяющее, подключён ли кабель питания к нужному входу.
        /// </summary>
        public static bool КабельПодключенПравильно
        {
            get { return _кабельВход == PowerCabelParameters.getInstance().Напряжение; }
        }

        #endregion

        #region Обновление переменных и формы
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
        public static event ParameterChangedHandler ОператорСтанцииПораженТоком;

        #endregion

        public static void SetDefaultParameters()
        {
            КабельВход = 0;
            ПереключательКонтрольНапр = 1;

        }
    }
}
