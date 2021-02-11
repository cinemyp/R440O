using System;
using System.Windows.Forms;
using R440O.R440OForms.N13_1;
using R440O.R440OForms.N13_2;
using R440O.R440OForms.N15;
using R440O.R440OForms.NKN_1;
using R440O.R440OForms.NKN_2;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.N16
{
    public static class N16Parameters
    {
        public static bool Включен
        {
            get
            {
                return (N15Parameters.НеполноеВключение);
            }
        }


        private static readonly Timer Timer = new Timer();
        public static int ЗначениеМощностьВыходаRnd = new Random().Next(20, 50);


        private static int _значениеМощностьВыхода = 0;
        private static int _значениеМощностьНагрузки = 0;

        public static int ЗначениеМощностьВыхода
        {
            get { return _значениеМощностьВыхода; }
            set
            {
                if (!Timer.Enabled)
                {
                    Timer.Enabled = true;
                    Timer.Interval = 10;
                    Timer.Start();
                    Timer.Tick += timer_Tick;
                }

                _значениеМощностьВыхода = value;
            }
        }

        public static int ЗначениеМощностьНагрузки
        {
            get { return _значениеМощностьНагрузки; }
            set
            {
                if (!Timer.Enabled)
                {
                    Timer.Enabled = true;
                    Timer.Interval = 10;
                    Timer.Start();
                    Timer.Tick += timer_Tick;
                }

                _значениеМощностьНагрузки = value;
            }
        }

        private static void timer_Tick(object sender, EventArgs e)
        {
            if ((ТумблерФаза == 0 && ТумблерУровень1 == 0 && ТумблерУровень2 == 0) ||
                (Math.Abs(ЗначениеМощностьВыхода - ИндикаторМощностьВыхода) < 0.1 &&
                 Math.Abs(ЗначениеМощностьНагрузки - ИндикаторМощностьНагрузки) < 0.1) ||
                Math.Abs(ЗначениеМощностьВыхода - N15Parameters.ИндикаторМощностьВыхода) < 0.1)
            {
                Timer.Tick -= timer_Tick;
                Timer.Stop();
                Timer.Enabled = false;

                if (N13_1Parameters.Включен && N13_2Parameters.Включен)
                {
                    if (ТумблерУровень2 != 0)
                    {
                        ЗначениеМощностьВыхода = (ЗначениеМощностьВыхода == 50) ? 20 : 50;
                        ЗначениеМощностьНагрузки = (ЗначениеМощностьНагрузки == 50) ? 20 : 50;
                    }

                    if (ТумблерУровень1 != 0)
                    {
                        ЗначениеМощностьВыхода = (ЗначениеМощностьВыхода == 50) ? 20 : 50;
                        ЗначениеМощностьНагрузки = (ЗначениеМощностьНагрузки == 50) ? 20 : 50;
                    }

                    if (ТумблерФаза == 0) return;
                    ЗначениеМощностьВыхода = (ЗначениеМощностьВыхода == 20) ? 50 : 20;
                    ЗначениеМощностьНагрузки = (ЗначениеМощностьНагрузки == 50) ? 20 : 50;

                    return;
                }
                if (N13_1Parameters.Включен)
                {
                    if (ТумблерУровень1 != 0)
                        ЗначениеМощностьВыхода = (ЗначениеМощностьВыхода == 50) ? 20 : 50;
                    return;
                }
                if (N13_2Parameters.Включен)
                {
                    if (ТумблерУровень2 != 0)
                        ЗначениеМощностьВыхода = (ЗначениеМощностьВыхода == 50) ? 20 : 50;
                }
            }
            else
            {
                if (N15Parameters.КнопкаМощностьН16 && !КнопкаВкл &&
                    (N13_1Parameters.Включен || N13_2Parameters.Включен) &&     //анод включен
                    (NKN_1Parameters.ПолноеВключение && NKN_1Parameters.ДистанционноеВключение ||  //ум1 включен
                     NKN_2Parameters.ПолноеВключение && NKN_2Parameters.ДистанционноеВключение))    //ум2 включен
                {
                    if (ЗначениеМощностьВыхода - N15Parameters.ИндикаторМощностьВыхода > 0)
                        N15Parameters.ИндикаторМощностьВыхода += 0.1F;
                    else
                        N15Parameters.ИндикаторМощностьВыхода -= 0.1F;
                }
                else
                {
                    if (ЗначениеМощностьВыхода - ИндикаторМощностьВыхода > 0)
                        ИндикаторМощностьВыхода += 0.1F;
                    else
                        ИндикаторМощностьВыхода -= 0.1F;
                }

                if (ЗначениеМощностьНагрузки - ИндикаторМощностьНагрузки > 0)
                    ИндикаторМощностьНагрузки += 0.1F;

                else
                    ИндикаторМощностьНагрузки -= 0.1F;
            }
        }

        #region Тумблеры

        private static int _тумблерУровень1;
        private static int _тумблерФаза;
        private static int _тумблерУровень2;

        public static int ТумблерУровень1
        {
            get { return _тумблерУровень1; }
            set
            {
                _тумблерУровень1 = value;
                OnParameterChanged();

                if (_тумблерУровень1 == 0) return;

                if (N13_1Parameters.Включен && N13_1Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = _тумблерУровень1 == -1 ? 20 : 50;
                    ЗначениеМощностьНагрузки = _тумблерУровень1 == -1 ? 20 : 50;
                }
                else if (N13_1Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = 50;
                }
                else if (N13_2Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = ЗначениеМощностьВыходаRnd;
                }
            }
        }

        public static int ТумблерФаза
        {
            get { return _тумблерФаза; }
            set
            {
                _тумблерФаза = value;
                OnParameterChanged();

                if (_тумблерФаза == 0) return;
                if (N13_1Parameters.Включен && N13_2Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = _тумблерФаза == -1 ? 20 : 50;
                    ЗначениеМощностьНагрузки = _тумблерФаза == -1 ? 50 : 20;
                }
                else if (N13_1Parameters.Включен || N13_2Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = ЗначениеМощностьВыходаRnd;
                }
            }
        }

        public static int ТумблерУровень2
        {
            get { return _тумблерУровень2; }
            set
            {
                _тумблерУровень2 = value;
                OnParameterChanged();

                if (_тумблерУровень2 == 0) return;
                if (N13_1Parameters.Включен && N13_2Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = _тумблерУровень2 == -1 ? 20 : 50;
                    ЗначениеМощностьНагрузки = _тумблерУровень2 == -1 ? 30 : 50;
                }
                else if (N13_2Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = _тумблерУровень2 == -1 ? 20 : 50;
                }
                else if (N13_1Parameters.Включен)
                {
                    ЗначениеМощностьВыхода = ЗначениеМощностьВыходаRnd;
                }
            }
        }

        #endregion

        #region Лампочки

        public static bool ЛампочкаН13_12
        {
            get { return Включен && ЩелевойМостН13 == 3; }
        }

        public static bool ЛампочкаН13_1
        {
            get { return Включен && ЩелевойМостН13 == 1; }
        }

        public static bool ЛампочкаН13_2
        {
            get { return Включен && ЩелевойМостН13 == 2; }
        }

        public static bool ЛампочкаАнтенна
        {
            get { return Включен && КоаксиальныйПереключатель; }
        }

        public static bool ЛампочкаЭквивалент
        {
            get { return Включен && !КоаксиальныйПереключатель; }
        }

        #endregion

        #region Внутренние элементы блока

        private static int _щелевойМостН13;
        private static bool _коаксиальныйПереключатель;

        /// <summary>
        /// 1 - Н13-1 включён
        /// 2 - Н13-2 включён
        /// 3 - Н13-12 включены
        /// </summary>
        public static int ЩелевойМостН13
        {
            get { return _щелевойМостН13; }
            set
            {
                switch (ЩелевойМостН13)
                {
                    case 1:
                        switch (value)
                        {
                            case 2:
                                _щелевойМостН13 = (КнопкаН13_1)
                                    ? 1
                                    : 2;
                                break;
                            case 3:
                                _щелевойМостН13 = (КнопкаН13_1)
                                    ? 1
                                    : (КнопкаН13_2) ? 2 : 3;
                                break;
                        }
                        break;
                    case 2:
                        switch (value)
                        {
                            case 1:
                                _щелевойМостН13 = (КнопкаН13_2)
                                    ? 2
                                    : (КнопкаН13_12) ? 3 : 1;
                                break;
                            case 3:
                                _щелевойМостН13 = (КнопкаН13_2)
                                    ? 2
                                    : 3;
                                break;
                        }
                        break;
                    case 3:
                        switch (value)
                        {
                            case 1:
                                _щелевойМостН13 = (КнопкаН13_12)
                                    ? 3
                                    : 1;
                                break;
                            case 2:
                                _щелевойМостН13 = (КнопкаН13_12)
                                    ? 3
                                    : (КнопкаН13_1) ? 1 : 2;
                                break;
                        }
                        break;
                    default:
                        _щелевойМостН13 = value;
                        break;
                }
                OnParameterChanged();
                N15Parameters.ResetParametersAlternative();
            }
        }

        /// <summary>
        /// true - Антенна
        /// false - Эквивалент
        /// </summary>
        public static bool КоаксиальныйПереключатель
        {
            get { return _коаксиальныйПереключатель; }
            set
            {
                if (КоаксиальныйПереключатель != value)
                {
                    _коаксиальныйПереключатель = (КоаксиальныйПереключатель)
                        ? КнопкаАнтенна
                        : !КнопкаЭквивалент;
                }
                OnParameterChanged();
                N15Parameters.ResetParametersAlternative();
            }
        }

        #endregion

        #region Кнопки

        private static bool _кнопкаВкл;
        private static bool _кнопкаН13_12;
        private static bool _кнопкаН13_1;
        private static bool _кнопкаН13_2;
        private static bool _кнопкаАнтенна;
        private static bool _кнопкаЭквивалент;

        public static bool КнопкаВкл
        {
            get { return _кнопкаВкл; }
            set
            {
                _кнопкаВкл = value;
                if (N15Parameters.КнопкаМощностьН16) N15Parameters.ResetParametersAlternative();
                OnParameterChanged();
            }
        }

        public static bool КнопкаН13_12
        {
            get { return _кнопкаН13_12; }
            set
            {
                _кнопкаН13_12 = value;
                ЩелевойМостН13 = N15Parameters.КнопкаН13;
            }
        }

        public static bool КнопкаН13_1
        {
            get { return _кнопкаН13_1; }
            set
            {
                _кнопкаН13_1 = value;
                ЩелевойМостН13 = N15Parameters.КнопкаН13;
            }
        }

        public static bool КнопкаН13_2
        {
            get { return _кнопкаН13_2; }
            set
            {
                _кнопкаН13_2 = value;
                ЩелевойМостН13 = N15Parameters.КнопкаН13;
            }
        }

        public static bool КнопкаАнтенна
        {
            get { return _кнопкаАнтенна; }
            set
            {
                _кнопкаАнтенна = value;
                КоаксиальныйПереключатель = N15Parameters.ТумблерАнтЭкв;
            }
        }

        public static bool КнопкаЭквивалент
        {
            get { return _кнопкаЭквивалент; }
            set
            {
                _кнопкаЭквивалент = value;
                КоаксиальныйПереключатель = N15Parameters.ТумблерАнтЭкв;
            }
        }

        #endregion

        #region Индикаторы

        private static float _индикаторМощностьНагрузки = 0;
        public static float _индикаторМощностьВыхода = ЗначениеМощностьВыходаRnd;

        public static float ИндикаторМощностьНагрузки
        {
            get { return Включен && (N13_1Parameters.Включен && N13_2Parameters.Включен) ? _индикаторМощностьНагрузки : 0; }
            set
            {
                _индикаторМощностьНагрузки = value;
                OnIndicatorChanged();
            }
        }

        public static float ИндикаторМощностьВыхода
        {
            get { return (КнопкаВкл && Включен && (N13_1Parameters.Включен || N13_2Parameters.Включен)) ? _индикаторМощностьВыхода : 0; }
            set
            {
                _индикаторМощностьВыхода = value;
                OnIndicatorChanged();
            }
        }

        #endregion

        public delegate void ParameterChangedHandler();

        public static event ParameterChangedHandler ParameterChanged;

        public static void ResetParameters()
        {
            OnParameterChanged();
            N13_1Parameters.ResetParameters();
            N13_2Parameters.ResetParameters();

            //if (N15Parameters.Н13_1 && N13_1Parameters.Включен) N15Parameters.Н13_1 = false;
            //if (N15Parameters.Н13_2 && N13_2Parameters.Включен) N15Parameters.Н13_2 = false;
        }

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static event ParameterChangedHandler IndicatorChanged;

        private static void OnIndicatorChanged()
        {
            var handler = IndicatorChanged;
            if (handler != null) handler();
        }

        private static Signal ВходнойСигнал
        {
            get
            {
                return N13_1Parameters.ВыходнойСигнал ?? N13_2Parameters.ВыходнойСигнал;
            }
        }

        public static Signal ВыходнойСигнал
        {
            get
            {
                switch (ЩелевойМостН13)
                {
                    case 1:
                        return N13_1Parameters.ВыходнойСигнал;
                    case 2:
                        return N13_2Parameters.ВыходнойСигнал;
                    case 3:
                        if (N13_1Parameters.ВыходнойСигнал != null && N13_2Parameters.ВыходнойСигнал != null)
                        {
                            var сигнал = N13_1Parameters.ВыходнойСигнал;
                            сигнал.Power = 240;
                            return сигнал;
                        }
                        return N13_1Parameters.ВыходнойСигнал ?? N13_2Parameters.ВыходнойСигнал;
                }
                return null;
            }
        }
    }
}
