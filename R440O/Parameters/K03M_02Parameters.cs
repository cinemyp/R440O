namespace R440O.Parameters
{
    internal class K03M_02Parameters
    {
        ////Лампочки
        public static bool K03M_02Лампочка0;
        public static bool K03M_02Лампочка1;
        public static bool K03M_02Лампочка2;
        public static bool K03M_02Лампочка4;
        public static bool K03M_02Лампочка8;
        public static bool K03M_02Лампочка16;
        public static bool K03M_02Лампочка32;

        ////Переключатели
        public static bool K03M_02Переключатель0;
        public static bool K03M_02Переключатель1;
        public static bool K03M_02Переключатель2;
        public static bool K03M_02Переключатель4;
        public static bool K03M_02Переключатель8;
        public static bool K03M_02Переключатель16;
        public static bool K03M_02Переключатель32;
        public static bool K03M_02ПереключательНепрОднокр;
        public static bool K03M_02ПереключательАвтРучн;

        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _K03M_02ПереключательНапряжение = 1;

        public static int K03M_02ПереключательНапряжение
        {
            get
            {
                return _K03M_02ПереключательНапряжение;
            }

            set
            {
                if (value > 0 && value < 5)
                {
                    _K03M_02ПереключательНапряжение = value;
                }
            }
        }
    }
}
