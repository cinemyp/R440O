namespace R440O.Parameters
{
    internal class K05M_02Parameters
    {
        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _k05M_02ПереключательПередачаКонтроль;
        private static int _k05M_02ПереключательОслабление;
        private static int _k05M_02ПереключательРодРаботы;
        private static int _k05M_02ПереключательКанал1;
        private static int _k05M_02ПереключательКанал2;

        public static int K05M_02ПереключательПередачаКонтроль
        {
            get
            {
                return _k05M_02ПереключательПередачаКонтроль;
            }

            set
            {
                if (value >= 0 && value <= 3)
                {
                    _k05M_02ПереключательПередачаКонтроль = value;
                }
            }
        }
        public static int K05M_02ПереключательОслабление
        {
            get
            {
                return _k05M_02ПереключательОслабление;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _k05M_02ПереключательОслабление = value;
                }
            }
        }
        public static int K05M_02ПереключательРодРаботы
        {
            get
            {
                return _k05M_02ПереключательРодРаботы;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _k05M_02ПереключательРодРаботы = value;
                }
            }
        }
        public static int K05M_02ПереключательКанал1
        {
            get
            {
                return _k05M_02ПереключательКанал1;
            }

            set
            {
                if (value >= 0 && value <= 3)
                {
                    _k05M_02ПереключательКанал1 = value;
                }
            }
        }
        public static int K05M_02ПереключательКанал2
        {
            get
            {
                return _k05M_02ПереключательКанал2;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _k05M_02ПереключательКанал2 = value;
                }
            }
        }
    }
}
