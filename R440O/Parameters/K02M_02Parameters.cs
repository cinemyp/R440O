namespace R440O.Parameters
{
    internal class K02M_02Parameters
    {
        ////Лампочки
        public static bool K02M_02ЛампочкаКаналыОбнаруженияЛ;
        public static bool K02M_02ЛампочкаКаналыОбнаруженияЦ;
        public static bool K02M_02ЛампочкаКаналыОбнаруженияП;
        public static bool K02M_02ЛампочкаПоискСигналов;
        public static bool K02M_02ЛампочкаПилот;
        public static bool K02M_02ЛампочкаИнформ;
        
        #region Переключатели
        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _K02M_02ПереключательСкорость = 1;

        public static int K02M_02ПереключательСкорость
        {
            get
            {
                return _K02M_02ПереключательСкорость;
            }

            set
            {
                if (value > 0 && value < 4)
                {
                    _K02M_02ПереключательСкорость = value;
                }
            }
        }

        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _K02M_02ПереключательВклОткл = 1;

        public static int K02M_02ПереключательВклОткл
        {
            get
            {
                return _K02M_02ПереключательВклОткл;
            }

            set
            {
                if (value > 0 && value < 3)
                {
                    _K02M_02ПереключательВклОткл = value;
                }
            }
        }

        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _K02M_02ПереключательНапряжение1К = 1;

        public static int K02M_02ПереключательНапряжение1К
        {
            get
            {
                return _K02M_02ПереключательНапряжение1К;
            }

            set
            {
                if (value > 0 && value < 5)
                {
                    _K02M_02ПереключательНапряжение1К = value;
                }
            }
        }

        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _K02M_02ПереключательНапряжение2К = 1;

        public static int K02M_02ПереключательНапряжение2К
        {
            get
            {
                return _K02M_02ПереключательНапряжение2К;
            }

            set
            {
                if (value > 0 && value < 4)
                {
                    _K02M_02ПереключательНапряжение2К = value;
                }
            }
        }  
        #endregion
    }
}
