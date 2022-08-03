using R440O.R440OForms.K03M_01;

namespace R440O.R440OForms.K04M_01
{
    public class K04M_01Parameters
    {
        private static K04M_01Parameters instance;
        public static K04M_01Parameters getInstance()
        {
            if (instance == null)
                instance = new K04M_01Parameters();
            return instance;
        }

        public int НачальнаяЧастотаПРМ = 65000;

        public int НачальнаяЧастотаПРД = 70000;

        public int ЧастотаПрм
        {
            get { return НачальнаяЧастотаПРМ + _переключательПрмМгц * 1000 + _переключательПрмКгц100 * 100; }
        }

        public int ЧастотаПрд
        {
            get
            {
                return НачальнаяЧастотаПРД + _переключательПрдМгц * 1000 + _переключательПрдКгц100 * 100 + _переключательПрдКгц10 * 10 +
                       _переключательПрдКгц1;
            }
        }


        private int _переключательПрдМгц;
        private int _переключательПрдКгц100;
        private int _переключательПрдКгц10;
        private int _переключательПрдКгц1;
        private int _переключательПрмМгц;
        private int _переключательПрмКгц100;

        public int ПереключательПрдМгц
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
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }
        public int ПереключательПрдКгц100
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
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

        public int ПереключательПрдКгц10
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
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

        public int ПереключательПрдКгц1
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
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

        public int ПереключательПрмМгц
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
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }
        public int ПереключательПрмКгц100
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
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                }
            }
        }

    }
}
