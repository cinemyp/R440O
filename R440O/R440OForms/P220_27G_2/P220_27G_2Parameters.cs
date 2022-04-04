namespace R440O.R440OForms.P220_27G_2
{
    using N15;

    public class P220_27G_2Parameters
    {
        private static P220_27G_2Parameters instance;
        public static P220_27G_2Parameters getInstance()
        {
            if (instance == null)
                instance = new P220_27G_2Parameters();
            return instance;
        }
        public bool Включен
        {
            get { return N15Parameters.getInstance().Включен && ТумблерСеть; }
        }
        ////Лампочки
        public bool ЛампочкаНеиспр { get; set; }
        public bool ЛампочкаПерегр { get; set; }

        /// <summary>
        /// Лампочка сеть горит в случае включения блока Н15 и ТумблераСеть
        /// </summary>
        public bool ЛампочкаСеть
        {
            get { return Включен; }
        }

        /// <summary>
        /// Лампочка 27В горит в случае местного включения блоков, или включения хотя бы одного блока дискрета.
        /// </summary>
        public bool Лампочка27В
        {
            get
            {
                return Включен && (!ТумблерУправление ||
                                   (N15Parameters.getInstance().ТумблерА1 || N15Parameters.getInstance().ТумблерБ1_1 || N15Parameters.getInstance().ТумблерБ1_2 ||
                                    N15Parameters.getInstance().ТумблерБ2_1 || N15Parameters.getInstance().ТумблерБ2_2 || N15Parameters.getInstance().ТумблерБ3_1 ||
                                    N15Parameters.getInstance().ТумблерБ3_2));
            }
        }

        /// <summary>
        /// Определяет тип управления, выбранный на блоке. true - Дистанционное управление, false - Местное
        /// </summary>
        public bool ТумблерУправление
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
        public bool ТумблерСеть
        {
            get { return _тумблерСеть; }
            set
            {
                _тумблерСеть = value;
                OnParameterChanged();
                N15Parameters.getInstance().ResetParametersAlternative();
                N15Parameters.getInstance().ResetDiscret();
            }
        }

        private bool _тумблерУправление;
        private bool _тумблерСеть;

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        public void ResetParameters()
        {
            OnParameterChanged();
        }

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }
    }
}
