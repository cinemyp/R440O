namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        #region Кнопки
        private bool ЗначениеКнопкиКП1Контроль;
        private bool _КнопкаКП1Контроль;
        public bool КнопкаКП1Контроль
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
        public bool ЛампочкаКонтрольПодписи
        {
            get
            {
                return ЛампочкаСеть && (КнопкаПодпись1 || КнопкаПодпись2 || КнопкаПодпись3);
            }
        }
        public bool ЛампочкаКП1Канал10
        {
            get
            {
                return ЛампочкаСеть && ЗначениеКнопкиКП1Контроль;
            }
        }
        public bool ЛампочкаКП1Канал11 = false;
        #endregion
    }
}
