namespace R440O.Parameters
{
    internal class K04M_02Parameters
    {
        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _K04M_02ПереключательПрдМгц;
        private static int _K04M_02ПереключательПрдКгц100;
        private static int _K04M_02ПереключательПрдКгц10;
        private static int _K04M_02ПереключательПрдКгц1;
        private static int _K04M_02ПереключательПрмМгц;
        private static int _K04M_02ПереключательПрмКгц100;

        public static int K04M_02ПереключательПрдМгц
        {
            get
            {
                return _K04M_02ПереключательПрдМгц;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _K04M_02ПереключательПрдМгц = value;
                }
            }
        }
        public static int K04M_02ПереключательПрдКгц100
        {
            get
            {
                return _K04M_02ПереключательПрдКгц100;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _K04M_02ПереключательПрдКгц100 = value;
                }
            }
        }

        public static int K04M_02ПереключательПрдКгц10
        {
            get
            {
                return _K04M_02ПереключательПрдКгц10;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _K04M_02ПереключательПрдКгц10 = value;
                }
            }
        }

        public static int K04M_02ПереключательПрдКгц1
        {
            get
            {
                return _K04M_02ПереключательПрдКгц1;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _K04M_02ПереключательПрдКгц1 = value;
                }
            }
        }

        public static int K04M_02ПереключательПрмМгц
        {
            get
            {
                return _K04M_02ПереключательПрмМгц;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _K04M_02ПереключательПрмМгц = value;
                }
            }
        }
        public static int K04M_02ПереключательПрмКгц100
        {
            get
            {
                return _K04M_02ПереключательПрмКгц100;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _K04M_02ПереключательПрмКгц100 = value;
                }
            }
        }

    }
}
