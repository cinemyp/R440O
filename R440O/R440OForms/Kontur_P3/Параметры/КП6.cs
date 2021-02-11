using R440O.СостоянияЭлементов.Контур_П;

namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        #region Лампочки
        public static bool ЛампочкаКП6Передача = false;
        public static bool ЛампочкаКП6Сбой = false;
        public static bool ЛампочкаКП6Режим3 = false;
        #endregion

        #region Тумблеры
        private static EТумблерДокументирование _ТумблерДокументирование = EТумблерДокументирование.ОТКЛ;
        public static EТумблерДокументирование ТумблерДокументирование
        {
            get { return _ТумблерДокументирование; }
            set
            {
                _ТумблерДокументирование = value;
                if (RefreshForm != null) RefreshForm();
            }
        }

        private static EТумблерАсинхрСинхр _ТумблерАсинхрСинхр = EТумблерАсинхрСинхр.СИНХР;
        public static EТумблерАсинхрСинхр ТумблерАсинхрСинхр
        {
            get { return _ТумблерАсинхрСинхр; }
            set
            {
                _ТумблерАсинхрСинхр = value;
                if (RefreshForm != null) RefreshForm();
            }
        }

        private static EТумблерРежим _ТумблерРежим = EТумблерРежим.РЕЖИМ_1;
        public static EТумблерРежим ТумблерРежим
        {
            get { return _ТумблерРежим; }
            set
            {
                _ТумблерРежим = value;
                if (RefreshForm != null) RefreshForm();
            }
        }
        #endregion

    }
}
