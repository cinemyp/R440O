namespace R440O.R440OForms.B3_1
{
    using ShareTypes.SignalTypes;
    using N15;
    using N15Inside;
    using N18_M;

    class B3_1Parameters
    {
        private static B3_1Parameters instance;
        public static B3_1Parameters getInstance()
        {
            if (instance == null)
                instance = new B3_1Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        #region Работа блока
        public bool Включен
        {
            get
            {
                return (N15Parameters.getInstance().ЛампочкаП220272 || N15Parameters.getInstance().ЛампочкаП220273) &&
                       (ТумблерМуДу || !ТумблерМуДу && N15Parameters.getInstance().ТумблерБ3_1);
            }
        }

        /// <summary>
        /// Сигнал от ПУЛ ПРМ, при условии, что выбрана правильная колодка.
        /// </summary>
        public Signal ВходнойСигнал
        {
            get
            {
                if (Включен &&
                    N15InsideParameters.getInstance().ВыходПриемногоТракта != null &&
                    N18_MParameters.getInstance().ПереключательПРМ1 == 1 &&
                    ПравильнаяКолодка(N15InsideParameters.getInstance().ВыходПриемногоТракта.GroupSpeed))
                    return N15InsideParameters.getInstance().ВыходПриемногоТракта;
                return null;
            }
        }

        /// <summary>
        /// Первый выход, выходной поток определяется колодкой УКК1.
        /// </summary>
        public Signal ВыходнойСигнал1
        {
            get
            {
                if (ВходнойСигнал == null) return null;
                var signal = ВходнойСигнал;
                signal.SelectFlow(КолодкаУКК1);
                return signal;
            }
        }

        /// <summary>
        /// Второй выход, выходной поток определяется колодкой УКК2.
        /// </summary>
        public Signal ВыходнойСигнал2
        {
            get
            {
                if (ВходнойСигнал == null) return null;
                var signal = ВходнойСигнал;
                signal.SelectFlow(КолодкаУКК2);
                return signal;
            }
        }

        /// <summary>
        /// Соответствии скорости и выбранной колодки КРПР.
        /// </summary>
        private bool ПравильнаяКолодка(double groupSpeed)
        {
            switch (КолодкаКРПР)
            {
                case 1:
                    return groupSpeed == 480;
                case 2:
                    return groupSpeed == 240;
                case 3:
                    return groupSpeed == 144;
                case 4:
                    return groupSpeed == 96;
                case 5:
                    return groupSpeed == 48;
            }
            return false;
        }

        #endregion

        #region Лампочки

        public bool ЛампочкаПУЛГ_1
        {
            get { return Включен && !ЛампочкаПУЛГ_2; }
        }

        /// <summary>
        /// Горит, если есть сигнал от ПУЛа ПРМ.
        /// </summary>
        public bool ЛампочкаПУЛГ_2
        {
            get
            {
                return Включен && N15InsideParameters.getInstance().Включен && N18_MParameters.getInstance().ПереключательПРМ1 == 1
                    && КолодкаКРПР != 5;
            }
        }

        /// <summary>
        /// Горит, если не установлена ни одна колодка.
        /// </summary>
        public bool ЛампочкаПРИавар
        {
            get
            {
                return Включен &&
                    КолодкаУКК1 == 0 &&
                    КолодкаУКК2 == 0 &&
                    !КолодкаОКпр1Ас && !КолодкаОКпр2Ас &&
                    !КолодкаОКпр1Син && !КолодкаОКпр2Син &&
                    !КолодкаТлГпр11 && !КолодкаТлГпр12 &&
                    !КолодкаТлГпр21 && !КолодкаТлГпр22 &&
                    !КолодкаТлГпр31 && !КолодкаТлГпр32;
            }
        }

        public bool ЛампочкаРС_1
        {
            get { return Включен && !ЛампочкаРС_синхр; }
        }

        /// <summary>
        /// Горит, если от ПУЛа ПРМ сигнал есть и правильно выбрана скорость.
        /// </summary>
        public bool ЛампочкаРС_синхр
        {
            get { return Включен && ВходнойСигнал != null; }
        }

        public bool ЛампочкаТЛГпр1 { get; set; }
        public bool ЛампочкаТЛГпр2 { get; set; }
        public bool ЛампочкаТЛГпр3 { get; set; }

        /// <summary>
        /// Горит, если выбранный колодкой поток отсутствует.
        /// </summary>
        public bool ЛампочкаОКпр1
        {
            get { return ЛампочкаРС_синхр && ВыходнойСигнал1.SelectedFlowElements.Count == 0; }
        }

        public bool ЛампочкаПФТК1_1 { get { return ЛампочкаРС_1; } }

        /// <summary>
        /// Горит, если выбранный поток присутствует.
        /// </summary>
        public bool ЛампочкаПФТК1_2 { get { return ЛампочкаПУЛГ_2 && !ЛампочкаОКпр1; } }

        public bool ЛампочкаОКпр2
        {
            get { return ЛампочкаРС_синхр && ВыходнойСигнал2.SelectedFlowElements.Count == 0; }
        }
        public bool ЛампочкаПФТК2_1 { get { return ЛампочкаРС_1; } }
        public bool ЛампочкаПФТК2_2 { get { return ЛампочкаПУЛГ_2 && !ЛампочкаОКпр2; } }
        public bool ЛампочкаВУПнеиспр { get; set; }

        public bool ЛампочкаВУП1
        {
            get
            {
                return Включен;
            }
        }

        #endregion

        #region Колодки

        private int _колодкаКРПР;

        /// <summary>
        /// Выбор скорости обрабатываемой блоком.
        /// </summary>
        public int КолодкаКРПР
        {
            get { return _колодкаКРПР; }
            set
            {
                if (value >= 0 && value <= 5) _колодкаКРПР = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        private int _колодкаУКК1;

        /// <summary>
        /// Выбор номера потока, который будет передаваться с первого выхода.
        /// </summary>
        public int КолодкаУКК1
        {
            get { return _колодкаУКК1; }
            set
            {
                if (value >= 0 && value <= 9) _колодкаУКК1 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        private int _колодкаУКК2;

        /// <summary>
        /// Выбор номера потока, который будет передаваться со второго выхода.
        /// </summary>
        public int КолодкаУКК2
        {
            get { return _колодкаУКК2; }
            set
            {
                if (value >= 0 && value <= 9) _колодкаУКК2 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаОКпр1Син
        {
            get { return _колодкаОКпр1Син; }
            set
            {
                if (value) _колодкаОКпр1Ас = false;
                _колодкаОКпр1Син = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаОКпр1Ас
        {
            get { return _колодкаОКпр1Ас; }
            set
            {
                if (value) _колодкаОКпр1Син = false;
                _колодкаОКпр1Ас = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаОКпр2Син
        {
            get { return _колодкаОКпр2Син; }
            set
            {
                if (value) _колодкаОКпр2Ас = false;
                _колодкаОКпр2Син = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаОКпр2Ас
        {
            get { return _колодкаОКпр2Ас; }
            set
            {
                if (value) _колодкаОКпр2Син = false;
                _колодкаОКпр2Ас = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр11
        {
            get { return _колодкаТлГпр11; }
            set
            {
                if (value) _колодкаТлГпр12 = false;
                _колодкаТлГпр11 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр12
        {
            get { return _колодкаТлГпр12; }
            set
            {
                if (value) _колодкаТлГпр11 = false;
                _колодкаТлГпр12 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр21
        {
            get { return _колодкаТлГпр21; }
            set
            {
                if (value) _колодкаТлГпр22 = false;
                _колодкаТлГпр21 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр22
        {
            get { return _колодкаТлГпр22; }
            set
            {
                if (value) _колодкаТлГпр21 = false;
                _колодкаТлГпр22 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр31
        {
            get { return _колодкаТлГпр31; }
            set
            {
                if (value) _колодкаТлГпр32 = false;
                _колодкаТлГпр31 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр32
        {
            get { return _колодкаТлГпр32; }
            set
            {
                if (value) _колодкаТлГпр31 = false;
                _колодкаТлГпр32 = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }

        private bool _тумблерМуДу;
        private bool _колодкаОКпр1Син;
        private bool _колодкаОКпр1Ас;
        private bool _колодкаОКпр2Син;
        private bool _колодкаОКпр2Ас;
        private bool _колодкаТлГпр11;
        private bool _колодкаТлГпр12;
        private bool _колодкаТлГпр21;
        private bool _колодкаТлГпр22;
        private bool _колодкаТлГпр31;
        private bool _колодкаТлГпр32;

        #endregion

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
                OnParameterChanged();
            }
        }

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
