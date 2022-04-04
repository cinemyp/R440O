namespace R440O.R440OForms.B2_1
{
    using B3_1;
    using N15Inside;
    using N18_M;
    using N15;
    using ShareTypes.SignalTypes;

    class B2_1Parameters
    {
        private static B2_1Parameters instance;
        public static B2_1Parameters getInstance()
        {
            if (instance == null)
                instance = new B2_1Parameters();
            return instance;
        }

        #region Работа блока
        public bool Включен
        {
            get
            {
                return (N15Parameters.getInstance().ЛампочкаП220272 || N15Parameters.getInstance().ЛампочкаП220273) &&
                       (ТумблерМуДу || !ТумблерМуДу && N15Parameters.getInstance().ТумблерБ2_1);
            }
        }

        /// <summary>
        /// Сигнал от ПУЛ ПРМ или от Б3.
        /// </summary>
        public Signal ВходнойСигнал
        {
            get
            {
                if (Включен && B3_1Parameters.getInstance().ВыходнойСигнал1 != null)
                    return B3_1Parameters.getInstance().ВыходнойСигнал1;
                if (Включен &&
                    N15InsideParameters.getInstance().ВыходПриемногоТракта != null &&
                    N18_MParameters.getInstance().ПереключательПРМ1 == 2)
                    return N15InsideParameters.getInstance().ВыходПриемногоТракта;
                return null;
            }
        }

        /// <summary>
        /// Первый выход блока, номер группы определяется кнопкой БК1.
        /// </summary>
        public Signal ВыходнойСигнал1
        {
            get
            {
                if (ВходнойСигнал == null) return null;
                var signal = ВходнойСигнал;
                signal.SelectGroup(КнопкаБК1);
                return signal;
            }
        }

        /// <summary>
        /// Второй выход блока, номер группы определяется кнопкой БК1.
        /// </summary>
        public Signal ВыходнойСигнал2
        {
            get
            {
                if (ВходнойСигнал == null) return null;
                var signal = ВходнойСигнал;
                signal.SelectGroup(КнопкаБК2);
                return signal;
            }
        }

        #endregion

        #region Лампочки

        public bool ЛампочкаБОЧ { get; set; }

        public bool ЛампочкаПУЛ_1 { get { return Включен && ВходнойСигнал == null; } }
        public bool ЛампочкаПУЛ_2 { get { return Включен && !ЛампочкаПУЛ_1; } }

        /// <summary>
        /// Горит, если НЕ правильно выбран режим синхронизации на Б3.
        /// </summary>
        public bool ЛампочкаПрРПрС_1
        {
            get
            {
                return Включен && !ЛампочкаПрРПрС_2;
            }
        }

        /// <summary>
        /// Горит, если правильно выбран режим синхронизации на Б3.
        /// </summary>
        public bool ЛампочкаПрРПрС_2
        {
            get
            {
                if (Включен && ВходнойСигнал != null)
                    return (ВходнойСигнал.Synchronization && B3_1Parameters.getInstance().КолодкаОКпр1Син) ||
                           (!ВходнойСигнал.Synchronization && B3_1Parameters.getInstance().КолодкаОКпр1Ас);
                return false;
            }
        }

        /// <summary>
        /// Не правильная синхронизация или кнопки отжаты.
        /// </summary>
        public bool ЛампочкаПрРПрС_Авар
        {
            get { return Включен && ЛампочкаПрРПрС_1 || (ЛампочкаПрРПрС_2 && КнопкаБК1 == 0 && КнопкаБК2 == 0); }
        }

        public bool ЛампочкаТЛГпр { get; set; }
        public bool ЛампочкаТКСпр2 { get; set; }
        public bool ЛампочкаДФАПЧ21
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }
        public bool ЛампочкаПрТС1_1
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }

        /// <summary>
        /// Авария группы, если группа отсутствует.
        /// </summary>
        public bool ЛампочкаПрТС1_2
        {
            get
            {
                return Включен &&
                       (ЛампочкаПрРПрС_Авар ||
                       (ЛампочкаПрРПрС_1 || ВыходнойСигнал1.SelectedGroupElements.Count == 0));
            }
        }

        public bool ЛампочкаДФАПЧ22
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }
        public bool ЛампочкаПрТС2_1
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }

        public bool ЛампочкаПрТС2_2
        {
            get
            {
                return Включен && (ЛампочкаПрРПрС_Авар ||
                                   (ЛампочкаПрРПрС_1 || ВыходнойСигнал2.SelectedGroupElements.Count == 0));
            }
        }

        public bool ЛампочкаВУП_1
        {
            get { return Включен; }
        }
        public bool ЛампочкаВУП_Неиспр { get; set; }
        #endregion

        #region Кнопки

        private int _кнопкаБК1;
        private int _кнопкаБК2;
        private bool _тумблерМуДу;

        public int КнопкаБК1
        {
            get { return _кнопкаБК1; }
            set
            {
                _кнопкаБК1 = _кнопкаБК1 == value ? 0 : value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public int КнопкаБК2
        {
            get { return _кнопкаБК2; }
            set
            {
                _кнопкаБК2 = _кнопкаБК2 == value ? 0 : value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: Му - true, Ду - false
        /// </summary>
        public bool ТумблерМуДу
        {
            get { return _тумблерМуДу; }
            set
            {
                _тумблерМуДу = value;
                N15Parameters.getInstance().ResetDiscret();
            }
        }
        #endregion

        #region Колодки

        private bool _колодкаТлГпр1;
        private bool _колодкаТлГпр2;
        private bool _колодкаТкСпр21;
        private bool _колодкаТкСпр22;

        public bool КолодкаТЛГпр1
        {
            get { return _колодкаТлГпр1; }
            set
            {
                if (value) _колодкаТлГпр2 = false;
                _колодкаТлГпр1 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТЛГпр2
        {
            get { return _колодкаТлГпр2; }
            set
            {
                if (value) _колодкаТлГпр1 = false;
                _колодкаТлГпр2 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТКСпр21
        {
            get { return _колодкаТкСпр21; }
            set
            {
                if (value) _колодкаТкСпр22 = false;
                _колодкаТкСпр21 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТКСпр22
        {
            get { return _колодкаТкСпр22; }
            set
            {
                if (value) _колодкаТкСпр21 = false;
                _колодкаТкСпр22 = value;
                OnParameterChanged();
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
