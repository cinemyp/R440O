using R440O.R440OForms.N15;
using R440O.СостоянияЭлементов.Контур_П;

namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        #region Лампочки
        public static bool ЛампочкаСеть
        {
            get
            {
                return N15Parameters.ЛампочкаАФСС;
            }
        }
        #endregion

        #region Тумблеры
        private static EТумблерСеть _ТумблерСеть = EТумблерСеть.ОТКЛ;
        public static EТумблерСеть ТумблерСеть
        {
            get { return _ТумблерСеть; }
            set
            {
                _ТумблерСеть = value;
                N15Parameters.ResetParameters();
                ResetToDefaultsWhenTurnOnOff();
                Refresh();
            }
        }
        #endregion

        #region Индикатор Сеть
        public static float ИндикаторСеть
        {
            get
            {
                if (ЛампочкаСеть && ПереключательКонтроль != EПереключательКонтроль.ОТКЛ)
                    return -5;
                else
                    return -20;
            }
        }
        #endregion

        #region ПереключательКонтроль
        /// <summary>
        /// Положение переключателя Приоритет
        /// </summary>
        private static EПереключательКонтроль _ПереключательКонтроль = EПереключательКонтроль.ОТКЛ;
        public static EПереключательКонтроль ПереключательКонтроль
        {
            get { return _ПереключательКонтроль; }
            set
            {
                if (value >= EПереключательКонтроль.ОТКЛ
                    && value <= EПереключательКонтроль._p9B_резерв)
                {
                    _ПереключательКонтроль = value;
                }
                if (RefreshForm != null) RefreshForm();
            }
        }
        #endregion
    }
}
