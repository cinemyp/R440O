using R440O.R440OForms.B3_1;
using R440O.R440OForms.B3_2;
using R440O.R440OForms.N15Inside;
using R440O.R440OForms.N18_M;

namespace R440O.R440OForms.B2_2
{
    using N15;
using ShareTypes.SignalTypes;

    static class B2_2Parameters
    {
        #region Работа блока
        public static bool Включен
        {
            get
            {
                return (N15Parameters.ЛампочкаП220272 || N15Parameters.ЛампочкаП220273) &&
                       (ТумблерМуДу || !ТумблерМуДу && N15Parameters.ТумблерБ2_2);
            }
        }

        public static Signal ВходнойСигнал
        {
            get
            {
                if (Включен && B3_2Parameters.ВыходнойСигнал1 != null && N18_MParameters.ПереключательВходБ22 == 1)
                    return B3_2Parameters.ВыходнойСигнал1;
                if (Включен && B3_1Parameters.ВыходнойСигнал2 != null && N18_MParameters.ПереключательВходБ22 == 2)
                    return B3_1Parameters.ВыходнойСигнал1;
                if (Включен &&
                    N15InsideParameters.ВыходПриемногоТракта != null &&
                    N18_MParameters.ПереключательПРМ2 == 2)
                    return N15InsideParameters.ВыходПриемногоТракта;
                return null;
            }
        }

        public static Signal ВыходнойСигнал1
        {
            get
            {
                if (ВходнойСигнал == null) return null;
                var signal = ВходнойСигнал;
                signal.SelectGroup(КнопкаБК1);
                return signal;
            }
        }

        public static Signal ВыходнойСигнал2
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

        public static bool ЛампочкаБОЧ { get; set; }

        public static bool ЛампочкаПУЛ_1 { get { return Включен && ВходнойСигнал == null; } }
        public static bool ЛампочкаПУЛ_2 { get { return Включен && !ЛампочкаПУЛ_1; } }

        public static bool ЛампочкаПрРПрС_1
        {
            get
            {
                return Включен && !ЛампочкаПрРПрС_2;
            }
        }

        public static bool ЛампочкаПрРПрС_2
        {
            get
            {
                if (Включен && ВходнойСигнал != null)
                    return (ВходнойСигнал.Synchronization &&
                            (B3_2Parameters.КолодкаОКпр1Син && N18_MParameters.ПереключательВходБ22 == 1) ||
                            (B3_1Parameters.КолодкаОКпр2Син && N18_MParameters.ПереключательВходБ22 == 2)) ||
                           (!ВходнойСигнал.Synchronization &&
                            (B3_2Parameters.КолодкаОКпр1Ас && N18_MParameters.ПереключательВходБ22 == 1) ||
                            (B3_1Parameters.КолодкаОКпр2Ас && N18_MParameters.ПереключательВходБ22 == 2));
                return false;
            }
        }

        public static bool ЛампочкаПрРПрС_Авар
        {
            get { return Включен && ЛампочкаПрРПрС_1 || (ЛампочкаПрРПрС_2 && КнопкаБК1 == 0 && КнопкаБК2 == 0); }
        }

        public static bool ЛампочкаТЛГпр { get; set; }
        public static bool ЛампочкаТКСпр2 { get; set; }
        public static bool ЛампочкаДФАПЧ21
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }
        public static bool ЛампочкаПрТС1_1
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }

        public static bool ЛампочкаПрТС1_2
        {
            get
            {
                return Включен &&
                       (ЛампочкаПрРПрС_Авар ||
                       (ЛампочкаПрРПрС_1 || ВыходнойСигнал1.SelectedGroupElements.Count == 0));
            }
        }

        public static bool ЛампочкаДФАПЧ22
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }
        public static bool ЛампочкаПрТС2_1
        {
            get { return Включен && (ЛампочкаПрРПрС_Авар || ЛампочкаПрРПрС_1); }
        }

        public static bool ЛампочкаПрТС2_2
        {
            get
            {
                return Включен && (ЛампочкаПрРПрС_Авар ||
                                   (ЛампочкаПрРПрС_1 || ВыходнойСигнал2.SelectedGroupElements.Count == 0));
            }
        }

        public static bool ЛампочкаВУП_1
        {
            get { return Включен; }
        }
        public static bool ЛампочкаВУП_Неиспр { get; set; }
        #endregion

        #region Кнопки

        private static int _кнопкаБК1;
        private static int _кнопкаБК2;
        private static bool _тумблерМуДу;

        public static int КнопкаБК1
        {
            get { return _кнопкаБК1; }
            set
            {
                _кнопкаБК1 = _кнопкаБК1 == value ? 0 : value;
                N15Parameters.ResetDiscret();
                OnParameterChanged();
            }
        }

        public static int КнопкаБК2
        {
            get { return _кнопкаБК2; }
            set
            {
                _кнопкаБК2 = _кнопкаБК2 == value ? 0 : value;
                N15Parameters.ResetDiscret();
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: Му - true, Ду - false
        /// </summary>
        public static bool ТумблерМуДу
        {
            get { return _тумблерМуДу; }
            set
            {
                _тумблерМуДу = value;
                N15Parameters.ResetDiscret();
            }
        }
        #endregion

        #region Колодки

        private static bool _колодкаТлГпр1;
        private static bool _колодкаТлГпр2;
        private static bool _колодкаТкСпр21;
        private static bool _колодкаТкСпр22;

        public static bool КолодкаТЛГпр1
        {
            get { return _колодкаТлГпр1; }
            set
            {
                if (value) _колодкаТлГпр2 = false;
                _колодкаТлГпр1 = value;
                OnParameterChanged();
            }
        }

        public static bool КолодкаТЛГпр2
        {
            get { return _колодкаТлГпр2; }
            set
            {
                if (value) _колодкаТлГпр1 = false;
                _колодкаТлГпр2 = value;
                OnParameterChanged();
            }
        }

        public static bool КолодкаТКСпр21
        {
            get { return _колодкаТкСпр21; }
            set
            {
                if (value) _колодкаТкСпр22 = false;
                _колодкаТкСпр21 = value;
                OnParameterChanged();
            }
        }

        public static bool КолодкаТКСпр22
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
