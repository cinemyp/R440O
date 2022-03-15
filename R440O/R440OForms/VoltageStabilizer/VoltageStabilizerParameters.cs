using R440O.R440OForms.PowerCabel;

namespace R440O.R440OForms.VoltageStabilizer
{
    using global::R440O.BaseClasses;
    using global::R440O.JsonAdapter;
    using global::R440O.R440OForms.N502B;

    public class VoltageStabilizerParameters
    {
        private static VoltageStabilizerParameters instance;
        public static VoltageStabilizerParameters getInstance()
        {
            if (instance == null)
                instance = new VoltageStabilizerParameters();
            return instance;
        }
        public static ITestModule TestModuleRef { get; set; }
        #region Лампочки

        public bool ЛампочкаСеть
        {
            get
            {
                return N502BParameters.getInstance().ПереключательСеть &&
                           N502BParameters.getInstance().ЛампочкаСеть
                             && КабельПодключенПравильно;
            }
        }
        public bool ЛампочкаАвария
        {
            get
            {
                return N502BParameters.getInstance().ПереключательСеть &&
                           N502BParameters.getInstance().ЛампочкаСеть
                             && !КабельПодключенПравильно;
            }
        }
        #endregion

        #region Контроль Напряжения
        private int _переключательКонтрольНапр = 1;
        /// <summary>
        /// Положение переключателя Контроль напряжения
        /// </summary>
        public int ПереключательКонтрольНапр
        {
            get { return _переключательКонтрольНапр; }

            set
            {
                if (value > 0 && value < 13) _переключательКонтрольНапр = value;
                OnParameterChanged();
            }
        }

        public int ИндикаторНапряжение
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
        private int _кабельВход;

        public int КабельВход
        {
            get { return _кабельВход; }

            set
            {
                if (N502BParameters.getInstance().ЛампочкаСеть && N502BParameters.getInstance().ПереключательСеть && ОператорСтанцииПораженТоком != null)
                {
                    ОператорСтанцииПораженТоком();
                }
                else _кабельВход = value;

                OnParameterChanged();
                N502BParameters.getInstance().ResetParameters();
            }
        }

        /// <summary>
        /// Условие определяющее, подключён ли кабель питания к нужному входу.
        /// </summary>
        public bool КабельПодключенПравильно
        {
            get { return _кабельВход == PowerCabelParameters.getInstance().Напряжение; }
        }

        #endregion

        #region Обновление переменных и формы
        public delegate void TestModuleHandler(ActionStation action);
        public event TestModuleHandler Action;
        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }

        private void OnAction(string name, int value)
        {
            var action = new ActionStation(name, value);
            Action?.Invoke(action);
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }

        /// <summary>
        /// Вызывается, если пользователь совершил неправильные действия по обесточиванию станции.
        /// </summary>
        public event ParameterChangedHandler ОператорСтанцииПораженТоком;

        #endregion

        public void SetDefaultParameters()
        {
            КабельВход = 0;
            ПереключательКонтрольНапр = 1;

        }
    }
}
