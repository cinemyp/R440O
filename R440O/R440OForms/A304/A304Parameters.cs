using System.Security.Policy;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.A304
{
    using InternalBlocks;
    using N15;

    public static class A304Parameters
    {
        public static bool Включен
        {
            get { return N15Parameters.НеполноеВключение; }
        }

        public static bool Комплект1Включен
        {
            get
            {
                return (ТумблерУправление1 && N15Parameters.ТумблерА30412) ||
                       (!ТумблерУправление1 && Кнопка1К);
            }
        }

        public static bool Комплект2Включен
        {
            get
            {
                return (ТумблерУправление2 && !N15Parameters.ТумблерА30412) ||
                       (!ТумблерУправление2 && Кнопка2К);
            }
        }

        public static int? ВыходнаяЧастота
        {
            get
            {
                if (Комплект1Включен && ТумблерКомплект || Комплект2Включен && !ТумблерКомплект)
                    return ПереключательВыборСтвола*6250 + 378750;
                return null;
            }
        }


        #region Лампочки
        /// <summary>
        /// Параметр для лампочки. Возможные состояния: true, false
        /// </summary>
        public static bool Лампочка1К
        {
            get
            {
                return Включен &&
                    ((!ТумблерУправление1 && Кнопка1К && N15Parameters.Включен) ||
                     (ТумблерУправление1 && MSHUParameters.Включен && N15Parameters.ТумблерА30412));
            }
        }

        /// <summary>
        /// Параметр для лампочки. Возможные состояния: true, false
        /// </summary>
        public static bool Лампочка2К
        {
            get
            {
                return Включен &&
                    ((!ТумблерУправление2 && Кнопка2К && N15Parameters.Включен) ||
                     (ТумблерУправление2 && MSHUParameters.Включен && !N15Parameters.ТумблерА30412));
            }
        }
        #endregion

        #region Тумблеры

        /// <summary>
        /// Выбор способа включения. Возможные состояния: true - Дистанционное; false - Местное;
        /// </summary>
        public static bool ТумблерУправление1
        {
            get
            {
                return _тумблерУправление1;
            }

            set
            {
                _тумблерУправление1 = value;
                Кнопка1К = (MSHUParameters.Включен && Включен && !value && N15Parameters.ТумблерА30412);
                N15Parameters.ResetParametersAlternative();
            }
        }
        private static bool _тумблерУправление1;

        /// <summary>
        /// Выбор способа включения. Возможные состояния: true - Дистанционное; false - Местное;
        /// </summary>
        public static bool ТумблерУправление2
        {
            get
            {
                return _тумблерУправление2;
            }

            set
            {
                _тумблерУправление2 = value;
                Кнопка2К = (MSHUParameters.Включен && Включен && !value && !N15Parameters.ТумблерА30412);
                N15Parameters.ResetParametersAlternative();
            }
        }
        private static bool _тумблерУправление2;

        /// <summary>
        /// Выбор комплекта оборудования. Возможные состояния: true - 1; false - 2;
        /// </summary>
        /// 
        public static bool ТумблерКомплект
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
        private static bool _тумблерКомплект = true;
        #endregion

        #region Переключатели
        /// <summary>
        /// Положение переключателя выбора ствола.
        /// </summary>
        public static int ПереключательВыборСтвола
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
        private static int _переключательВыборСтвола;
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
        public static int ПереключательКонтроль
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
        private static int _переключательКонтроль;
        #endregion

        #region Кнопки

        public static bool Кнопка1К
        {
            get
            {
                return _кнопка1К;
            }

            set
            {
                if (!ТумблерУправление1 && Включен && N15Parameters.Включен) _кнопка1К = value;
                ResetParameters();

                N15Parameters.ResetParametersAlternative();
            }
        }

        private static bool _кнопка1К;

        public static bool Кнопка2К
        {
            get
            {
                return _кнопка2К;
            }

            set
            {
                if (!ТумблерУправление2 && Включен && N15Parameters.Включен) _кнопка2К = value;
                ResetParameters();

                N15Parameters.ResetParametersAlternative();
            }
        }

        private static bool _кнопка2К;

        #endregion

        public static int ИндикаторНапряжение
        {
            get
            {
                if (MSHUParameters.Включен && (Лампочка1К && ТумблерКомплект || Лампочка2К && !ТумблерКомплект))
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

        public static void ResetParameters()
        {
            OnParameterChanged();

            //Для сброса лампочек
            if (!Включен)
            {
                _кнопка1К = false;
                _кнопка2К = false;
            }
        }

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }
    }
}
