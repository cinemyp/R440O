using System;

namespace R440O.Parameters
{
    public static class AstraParameters
    {

        #region Переключатели

        #region private
        private static int _переключательВнешнегоПитания = 1;
        private static int _переключательКонтроль = 1;
        private static int _переключательДиапазоны = 1;
        private static int _переключательВыходаРеле = 1;
        private static int _переключательТлгТлф = 1;
        private static bool _тумблерШпУп = true;
        private static int _регуляторУсиление;
        private static int _регуляторУсилениеПЧ;
        #endregion

        #region public
        /// <summary>
        /// 1: флг_рру; 2: флг_ару
        /// </summary>
        public static int ПереключательТлгТлф
        {
            get { return _переключательТлгТлф; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательТлгТлф = value;
                    OnParameterChanged();
                }
            }
        }


        /// <summary>
        /// 1: 115; 2: +12; 3:220; 4: Выкл;
        /// </summary>
        public static int ПереключательВнешнегоПитания
        {
            get { return _переключательВнешнегоПитания; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательВнешнегоПитания = value;
                    OnParameterChanged();
                }
            }
        }


        /// <summary>
        /// 1: настройка; 2: гетер; 3: +12в;
        /// </summary>
        public static int ПереключательКонтроль
        {
            get { return _переключательКонтроль; }
            set
            {
                if (value > 0 && value < 4)
                {
                    _переключательКонтроль = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1: выкл; 2: 12-150кгц; 3: 1.15мГц; 4: 2.5мгц; 5: 5мгц; 6: 10мгц; 7: 15мгц; 8: 20мгц; 9: 25мгц;
        /// </summary>
        public static int ПереключательДиапазоны
        {
            get { return _переключательДиапазоны; }
            set
            {
                if (value > 0 && value < 10)
                {
                    _переключательДиапазоны = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1: пч; 2: реле; 3: выкл;
        /// </summary>
        public static int ПереключательВыходаРеле
        {
            get { return _переключательВыходаРеле; }
            set
            {
                if (value > 0 && value < 4)
                {
                    _переключательВыходаРеле = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// Положение тумблера ШпУп. true - шп, false - уп
        /// </summary>
        public static bool ТумблерШпУп
        {
            get { return _тумблерШпУп; }
            set
            {
                _тумблерШпУп = value;
                OnParameterChanged();
            }
        }
        #endregion
        #endregion

        #region Кнопки

        private static bool _кнопка150_270;
        private static bool _кнопка270_480;
        private static bool _кнопка480_860;
        private static bool _кнопка860_1500;

        public static bool Кнопка150_270
        {
            get { return _кнопка150_270; }
            set { _кнопка150_270 = value; }
        }

        public static bool Кнопка270_480
        {
            get { return _кнопка270_480; }
            set { _кнопка270_480 = value; }
        }

        public static bool Кнопка480_860
        {
            get { return _кнопка480_860; }
            set { _кнопка480_860 = value; }
        }

        public static bool Кнопка860_1500
        {
            get { return _кнопка860_1500; }
            set { _кнопка860_1500 = value; }
        }

        #endregion

        #region Регуляторы

        public static int РегуляторЧастота { get; set; }

        public static int РегуляторУсиление
        {
            get { return _регуляторУсиление; }
            set
            {
                if (value < 120 && value > -120 && Math.Abs(value - _регуляторУсиление) <= 100)
                    _регуляторУсиление = value;
            }
        }

        public static int РегуляторУсилениеПЧ
        {
            get { return _регуляторУсилениеПЧ; }
            set
            {
                if (value < 120 && value > -120 && Math.Abs(value - _регуляторУсилениеПЧ) <= 100)
                    _регуляторУсилениеПЧ = value;
            }
        }

        #endregion

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }
    }
}
