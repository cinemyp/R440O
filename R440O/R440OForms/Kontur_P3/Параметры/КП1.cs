namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        #region Кнопки
        private static bool ЗначениеКнопкиКП1Контроль;
        private static bool _КнопкаКП1Контроль;
        public static bool КнопкаКП1Контроль
        {
            get { return _КнопкаКП1Контроль; }
            set
            {
                if (!ЛампочкаПередача)
                    _КнопкаКП1Контроль = value;
                if (_КнопкаКП1Контроль)
                    КнопкаКП4Контроль = false;
                Refresh();
            }
        }
        #endregion

        #region Лампочки
        public static bool ЛампочкаКонтрольПодписи
        {
            get
            {
                return ЛампочкаСеть && (КнопкаПодпись1 || КнопкаПодпись2 || КнопкаПодпись3);
            }
        }
        public static bool ЛампочкаКП1Канал10
        {
            get
            {
                return ЛампочкаСеть && ЗначениеКнопкиКП1Контроль;
            }
        }
        public static bool ЛампочкаКП1Канал11 = false;
        #endregion
    }
}
