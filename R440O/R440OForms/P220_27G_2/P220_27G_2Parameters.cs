namespace R440O.R440OForms.P220_27G_2
{
    using N15;

    public static class P220_27G_2Parameters
    {
        public static bool Включен
        {
            get { return N15Parameters.Включен && ТумблерСеть; }
        }
        ////Лампочки
        public static bool ЛампочкаНеиспр { get; set; }
        public static bool ЛампочкаПерегр { get; set; }

        /// <summary>
        /// Лампочка сеть горит в случае включения блока Н15 и ТумблераСеть
        /// </summary>
        public static bool ЛампочкаСеть
        {
            get { return Включен; }
        }

        /// <summary>
        /// Лампочка 27В горит в случае местного включения блоков, или включения хотя бы одного блока дискрета.
        /// </summary>
        public static bool Лампочка27В
        {
            get
            {
                return Включен && (!ТумблерУправление ||
                                   (N15Parameters.ТумблерА1 || N15Parameters.ТумблерБ1_1 || N15Parameters.ТумблерБ1_2 ||
                                    N15Parameters.ТумблерБ2_1 || N15Parameters.ТумблерБ2_2 || N15Parameters.ТумблерБ3_1 ||
                                    N15Parameters.ТумблерБ3_2));
            }
        }

        /// <summary>
        /// Определяет тип управления, выбранный на блоке. true - Дистанционное управление, false - Местное
        /// </summary>
        public static bool ТумблерУправление
        {
            get { return _тумблерУправление; }
            set
            {
                _тумблерУправление = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// true - вкл, false - выкл
        /// </summary>
        public static bool ТумблерСеть
        {
            get { return _тумблерСеть; }
            set
            {
                _тумблерСеть = value;
                OnParameterChanged();
                N15Parameters.ResetParametersAlternative();
                N15Parameters.ResetDiscret();
            }
        }

        private static bool _тумблерУправление;
        private static bool _тумблерСеть;

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        public static void ResetParameters()
        {
            OnParameterChanged();
        }

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }
    }
}
