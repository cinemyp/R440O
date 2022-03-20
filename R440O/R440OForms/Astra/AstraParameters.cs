using System;

namespace R440O.Parameters
{
    public class AstraParameters
    {
        private static AstraParameters instance;
        public static AstraParameters getInstance()
        {
            if (instance == null)
                instance = new AstraParameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        #region Переключатели

        #region private
        private int _переключательВнешнегоПитания = 1;
        private int _переключательКонтроль = 1;
        private int _переключательДиапазоны = 1;
        private int _переключательВыходаРеле = 1;
        private int _переключательТлгТлф = 1;
        private bool _тумблерШпУп = true;
        private int _регуляторУсиление;
        private int _регуляторУсилениеПЧ;
        #endregion

        #region public
        /// <summary>
        /// 1: флг_рру; 2: флг_ару
        /// </summary>
        public int ПереключательТлгТлф
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
        public int ПереключательВнешнегоПитания
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
        public int ПереключательКонтроль
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
        public int ПереключательДиапазоны
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
        public int ПереключательВыходаРеле
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
        public bool ТумблерШпУп
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

        private bool _кнопка150_270;
        private bool _кнопка270_480;
        private bool _кнопка480_860;
        private bool _кнопка860_1500;

        public bool Кнопка150_270
        {
            get { return _кнопка150_270; }
            set { _кнопка150_270 = value; }
        }

        public bool Кнопка270_480
        {
            get { return _кнопка270_480; }
            set { _кнопка270_480 = value; }
        }

        public bool Кнопка480_860
        {
            get { return _кнопка480_860; }
            set { _кнопка480_860 = value; }
        }

        public bool Кнопка860_1500
        {
            get { return _кнопка860_1500; }
            set { _кнопка860_1500 = value; }
        }

        #endregion

        #region Регуляторы

        public int РегуляторЧастота { get; set; }

        public int РегуляторУсиление
        {
            get { return _регуляторУсиление; }
            set
            {
                if (value < 120 && value > -120 && Math.Abs(value - _регуляторУсиление) <= 100)
                    _регуляторУсиление = value;
            }
        }

        public int РегуляторУсилениеПЧ
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
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }
    }
}
