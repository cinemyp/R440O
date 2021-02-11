using R440O.R440OForms.K03M_01;

namespace R440O.R440OForms.K04M_01
{
    public static class K04M_01Parameters
    {
        public static int НачальнаяЧастотаПРМ = 65000;

        public static int НачальнаяЧастотаПРД = 70000;

        public static int ЧастотаПрм
        {
            get { return НачальнаяЧастотаПРМ + _переключательПрмМгц * 1000 + _переключательПрмКгц100 * 100; }
        }

        public static int ЧастотаПрд
        {
            get
            {
                return НачальнаяЧастотаПРД + _переключательПрдМгц * 1000 + _переключательПрдКгц100 * 100 + _переключательПрдКгц10 * 10 +
                       _переключательПрдКгц1;
            }
        }


        private static int _переключательПрдМгц;
        private static int _переключательПрдКгц100;
        private static int _переключательПрдКгц10;
        private static int _переключательПрдКгц1;
        private static int _переключательПрмМгц;
        private static int _переключательПрмКгц100;

        public static int ПереключательПрдМгц
        {
            get
            {
                return _переключательПрдМгц;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательПрдМгц = value;
                    K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }
        public static int ПереключательПрдКгц100
        {
            get
            {
                return _переключательПрдКгц100;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательПрдКгц100 = value;
                    K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

        public static int ПереключательПрдКгц10
        {
            get
            {
                return _переключательПрдКгц10;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательПрдКгц10 = value;
                    K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

        public static int ПереключательПрдКгц1
        {
            get
            {
                return _переключательПрдКгц1;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательПрдКгц1 = value;
                    K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

        public static int ПереключательПрмМгц
        {
            get
            {
                return _переключательПрмМгц;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательПрмМгц = value;
                    K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }
        public static int ПереключательПрмКгц100
        {
            get
            {
                return _переключательПрмКгц100;
            }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательПрмКгц100 = value;
                    K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

    }
}
