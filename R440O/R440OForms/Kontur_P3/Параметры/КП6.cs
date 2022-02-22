using R440O.СостоянияЭлементов.Контур_П;

namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        #region Лампочки
        public bool ЛампочкаКП6Передача = false;
        public bool ЛампочкаКП6Сбой = false;
        public bool ЛампочкаКП6Режим3 = false;
        #endregion

        #region Тумблеры
        private EТумблерДокументирование _ТумблерДокументирование = EТумблерДокументирование.ОТКЛ;
        public EТумблерДокументирование ТумблерДокументирование
        {
            get { return _ТумблерДокументирование; }
            set
            {
                _ТумблерДокументирование = value;
                if (RefreshForm != null) RefreshForm();
            }
        }

        private EТумблерАсинхрСинхр _ТумблерАсинхрСинхр = EТумблерАсинхрСинхр.СИНХР;
        public EТумблерАсинхрСинхр ТумблерАсинхрСинхр
        {
            get { return _ТумблерАсинхрСинхр; }
            set
            {
                _ТумблерАсинхрСинхр = value;
                if (RefreshForm != null) RefreshForm();
            }
        }

        private EТумблерРежим _ТумблерРежим = EТумблерРежим.РЕЖИМ_1;
        public EТумблерРежим ТумблерРежим
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
