using System.Security.Policy;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.A304
{
    using global::R440O.BaseClasses;
    using InternalBlocks;
    using N15;

    public class A304Parameters
    {
        private static A304Parameters instance;
        public static A304Parameters getInstance()
        {
            if (instance == null)
                instance = new A304Parameters();
            return instance;
        }

        public bool Включен
        {
            get { return N15Parameters.getInstance().НеполноеВключение; }
        }

        public bool Комплект1Включен
        {
            get
            {
                return (ТумблерУправление1 && N15Parameters.getInstance().ТумблерА30412) ||
                       (!ТумблерУправление1 && Кнопка1К);
            }
        }

        public bool Комплект2Включен
        {
            get
            {
                return (ТумблерУправление2 && !N15Parameters.getInstance().ТумблерА30412) ||
                       (!ТумблерУправление2 && Кнопка2К);
            }
        }

        public int? ВыходнаяЧастота
        {
            get
            {
                if (Комплект1Включен && ТумблерКомплект || Комплект2Включен && !ТумблерКомплект)
                    return ПереключательВыборСтвола * 6250 + 378750;
                return null;
            }
        }


        #region Лампочки
        /// <summary>
        /// Параметр для лампочки. Возможные состояния: true, false
        /// </summary>
        public bool Лампочка1К
        {
            get
            {
                return Включен &&
                    ((!ТумблерУправление1 && Кнопка1К && N15Parameters.getInstance().Включен) ||
                     (ТумблерУправление1 && MSHUParameters.getInstance().Включен && N15Parameters.getInstance().ТумблерА30412));
            }
        }

        /// <summary>
        /// Параметр для лампочки. Возможные состояния: true, false
        /// </summary>
        public bool Лампочка2К
        {
            get
            {
                return Включен &&
                    ((!ТумблерУправление2 && Кнопка2К && N15Parameters.getInstance().Включен) ||
                     (ТумблерУправление2 && MSHUParameters.getInstance().Включен && !N15Parameters.getInstance().ТумблерА30412));
            }
        }
        #endregion

        #region Тумблеры

        /// <summary>
        /// Выбор способа включения. Возможные состояния: true - Дистанционное; false - Местное;
        /// </summary>
        public bool ТумблерУправление1
        {
            get
            {
                return _тумблерУправление1;
            }

            set
            {
                _тумблерУправление1 = value;
                Кнопка1К = (MSHUParameters.getInstance().Включен && Включен && !value && N15Parameters.getInstance().ТумблерА30412);
                N15Parameters.getInstance().ResetParametersAlternative();
            }
        }
        private bool _тумблерУправление1;

        /// <summary>
        /// Выбор способа включения. Возможные состояния: true - Дистанционное; false - Местное;
        /// </summary>
        public bool ТумблерУправление2
        {
            get
            {
                return _тумблерУправление2;
            }

            set
            {
                _тумблерУправление2 = value;
                Кнопка2К = (MSHUParameters.getInstance().Включен && Включен && !value && !N15Parameters.getInstance().ТумблерА30412);
                N15Parameters.getInstance().ResetParametersAlternative();
            }
        }
        private bool _тумблерУправление2;

        /// <summary>
        /// Выбор комплекта оборудования. Возможные состояния: true - 1; false - 2;
        /// </summary>
        /// 
        public bool ТумблерКомплект
        {
            get
            {
                return _тумблерКомплект;
            }

            set
            {
                _тумблерКомплект = value;
                ResetParameters();
            }
        }
        private bool _тумблерКомплект = true;
        #endregion

        #region Переключатели
        /// <summary>
        /// Положение переключателя выбора ствола.
        /// </summary>
        public int ПереключательВыборСтвола
        {
            get
            {
                return _переключательВыборСтвола;
            }

            set
            {
                if (value >= 1 && value <= 10)
                {
                    _переключательВыборСтвола = value;
                    ResetParameters();
                }
            }
        }
        private int _переключательВыборСтвола;
        /// <summary>
        /// Положение переключателя контроля
        /// 0 - ОГ,
        /// 1 - СЧ3,
        /// 2 - ГН2,
        /// 3 - -27В,
        /// 4 - +5В,
        /// 5 - +12.6В,
        /// 6 - +27В,
        /// 7 - -5В,
        /// 8 - -12.6В.
        /// </summary>
        public int ПереключательКонтроль
        {
            get
            {
                return _переключательКонтроль;
            }

            set
            {
                if (value >= 0 && value < 9)
                {
                    _переключательКонтроль = value;
                    ResetParameters();
                }
            }
        }
        private int _переключательКонтроль;
        #endregion

        #region Кнопки

        public bool Кнопка1К
        {
            get
            {
                return _кнопка1К;
            }

            set
            {
                if (!ТумблерУправление1 && Включен && N15Parameters.getInstance().Включен) _кнопка1К = value;
                ResetParameters();

                N15Parameters.getInstance().ResetParametersAlternative();
            }
        }

        private bool _кнопка1К;

        public bool Кнопка2К
        {
            get
            {
                return _кнопка2К;
            }

            set
            {
                if (!ТумблерУправление2 && Включен && N15Parameters.getInstance().Включен) _кнопка2К = value;
                ResetParameters();

                N15Parameters.getInstance().ResetParametersAlternative();
            }
        }

        private bool _кнопка2К;

        #endregion

        public int ИндикаторНапряжение
        {
            get
            {
                if (MSHUParameters.getInstance().Включен && (Лампочка1К && ТумблерКомплект || Лампочка2К && !ТумблерКомплект))
                    switch (ПереключательКонтроль)
                    {
                        case 0:
                            return -35;
                        case 1:
                            return 30;
                        case 2:
                            return 30;
                        case 3:
                            return -35;
                        case 4:
                            return 30;
                        case 5:
                            return 30;
                        case 6:
                            return 30;
                        case 7:
                            return -35;
                        case 8:
                            return -35;
                    }
                else
                {
                    switch (ПереключательКонтроль)
                    {
                        case 0:
                            return -35;
                        case 6:
                            return 27;
                        default:
                            return 0;
                    }
                }
                return 0;
            }
        }

        public void ResetParameters()
        {
            OnParameterChanged();

            //Для сброса лампочек
            if (!Включен)
            {
                _кнопка1К = false;
                _кнопка2К = false;
            }
        }

        public void SetDefaultParameters()
        {
            ResetParameters();
            _тумблерУправление1 = false;
            _тумблерУправление1 = false;
            _тумблерУправление2 = false;
            _тумблерКомплект = false;
            _переключательВыборСтвола = 0;
            _переключательКонтроль = 0;

        }
        
        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }
    }
}
