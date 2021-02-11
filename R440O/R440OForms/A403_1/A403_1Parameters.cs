using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using R440O.Parameters;
using R440O.R440OForms.N15;

namespace R440O.R440OForms.A403_1
{
    public class Location
    {
        public string Az; //азимут
        public string Ym; //угол места
        public string DeltaF; //доплеровское смещение
    }

    public static class A403_1Parameters
    {
        public static string AlphaP = "";
        public static string BetaP = "";
        public static string DeltaF = "";

        public static bool Включен { get { return ТумблерСеть && N15Parameters.ТумблерА403 && N15Parameters.Включен; } } 
        /// <summary>
        /// Показывает, было ли записано значение в ДисплейЗначения
        /// </summary>
        public static bool IsWritten { get; set; }

        #region Проверка введенных значений

        /// <summary>
        /// Словарь известных значений (время - данные)
        /// </summary>
        public static Dictionary<string, Location> Table = new Dictionary<string, Location>
        {
            {"+131000", new Location {Az = "+064573", Ym = "+004116", DeltaF = "-058750"} },
            {"+151000", new Location {Az = "+035441", Ym = "+027497", DeltaF = "-032500"}},
            {"+171000", new Location {Az = "+030212", Ym = "+029342", DeltaF = "-010625"}},
            {"+191000", new Location {Az = "+034475", Ym = "+027283", DeltaF = "+008750"}},
            {"+211000", new Location {Az = "+047331", Ym = "+022426", DeltaF = "+030625"}}
        };

        /// <summary>
        /// Вывод значений угла места и азимута из словаря
        /// </summary>
        public static void Calculate()
        {
            if (A403_1ЗначенияПараметров.ДисплейЗначения[0, 0] != "+265419" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[0, 1] != "+741271" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[0, 2] != "+064535" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[0, 3] != "+279105" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[0, 4] != "+077385" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[0, 5] != "+123723" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[0, 6] != "+115716" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[1, 0] != "+356285" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[1, 1] != "+048472" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[1, 2] != "+000001" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[1, 3] != "+1" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[1, 4] != "+3" ||
                A403_1ЗначенияПараметров.ДисплейЗначения[1, 5] != "+010000") return;

            var location = Table.FirstOrDefault(u => u.Key == A403_1ЗначенияПараметров.ДисплейЗначения[0, 8]);
            if (location.Key == null) return;
            AlphaP = location.Value.Az;
            BetaP = location.Value.Ym;
            DeltaF = location.Value.DeltaF;

            N12SParameters.FromA403 = true;
            N12SParameters.ПотенциометрAlphaИ = GetInt(AlphaP) / 1000 + (GetInt(AlphaP) % 1000 / 10f) / 60f;
            N12SParameters.ПотенциометрBetaИ = GetInt(BetaP) / 1000 + (GetInt(BetaP) % 1000 / 10f) / 60f;
            N12SParameters.FromA403 = false;

            return;
        }

        #endregion

        /// <summary>
        /// true - 1 комплект, false - 2 комплект
        /// </summary>
        public static bool Комплект
        {
            get { return _комплект; }
            set
            {
                if (_комплект != value)
                    Time = 0;
                _комплект = value;
            }
        }

        public static string Дисплей
        {
            get
            {
                if (ПереключательРежимРаботы != 4) return Значение;
                switch (ПереключательПроверка)
                {
                    case 3:
                        _значение = AlphaP;
                        break;
                    case 4:
                        _значение = BetaP;
                        break;
                    case 5:
                        _значение = DeltaF;
                        break;
                    case 6:
                        _значение = GradForDisplay(N12SParameters.ПотенциометрAlphaИ);
                        break;
                    case 7:
                        _значение = GradForDisplay(N12SParameters.ПотенциометрBetaИ);
                        break;
                    case 8:
                    case 9:
                    case 10:
                        _значение = "";
                        break;
                }
                return Значение;
            }
        }

        #region Private

        private static bool _тумблерСеть;
        private static bool _тумблерГотов;
        private static bool _тумблерАвтКоррекция;
        private static bool _тумблерГруппа;
        private static bool _тумблерКомплект;
        private static string _значение = "";
        private static bool _кнопкаУстВремени;
        private static bool _комплект;

        #endregion

        #region Таймер

        /// <summary>
        /// Переменная для хранения времени работы
        /// </summary>
        public static int Time { get; set; }

        /// <summary>
        /// Таймер для времени работы
        /// </summary>
        public static Timer timer = new Timer();

        /// <summary>
        /// Обработчик события тика таймера: инкремент времени
        /// </summary>
        public static void timer_Tick(object sender, EventArgs e)
        {
            if (Включен && ТумблерГотов)
            {
                Calculate();
            }

            if (КнопкиПараметры.PressedButton == -1 && ПереключательПроверка != 6)
            {
                //форматированная запись в значение для последующего отображения на дисплее
                _значение = " " + (Time / 3600 / 10) + (Time / 3600 % 10) +
                            (Time / 60 % 60 / 10) + (Time / 60 % 60 % 10) +
                            (Time % 60 / 10) + (Time % 60 % 10);
                if (Time > 86400)
                {
                    _значение = "";
                    Time = 0;
                }
                OnDisplayChanged();
            }
            Time++;
        }

        private static void SetTimer()
        {
            if (timer.Enabled && Включен) return;
            timer.Stop();
            timer.Tick -= timer_Tick;
            if (Включен) //включение
            {
                timer.Enabled = true;
                timer.Tick += timer_Tick;
                timer.Interval = 1000;
                timer.Start();
                timer_Tick(null, null);
            }
            else //отключение
            {
                ДисплейЗначения1К.ОчиститьЗначения();
                ДисплейЗначения2К.ОчиститьЗначения();
                _значение = "";
                timer.Enabled = false;
                Time = 0;
            }
        }

        #endregion

        #region Лампочки

        /// <summary>
        /// Возможные состояния: true - работает 1 комплект, false - не работает 1 комплект
        /// </summary>
        public static bool ЛампочкаКомплект1 { get { return Включен && Комплект; } }

        /// <summary>
        /// Возможные состояния: true - работает 2 комплект, false - не работает 2 комплект
        /// </summary>
        public static bool ЛампочкаКомплект2 { get { return Включен && !Комплект; } }

        #endregion

        #region Тумблеры

        public static bool ТумблерСеть
        {
            get { return _тумблерСеть; }
            set
            {
                _тумблерСеть = value;
                SetTimer();
                OnParameterChanged();
                N15Parameters.ResetParametersAlternative();
            }
        }

        public static bool ТумблерГотов
        {
            get { return _тумблерГотов; }
            set
            {
                if (Включен && _тумблерГотов == false && value)
                {
                    Calculate();
                }
                _тумблерГотов = value;
                OnParameterChanged();
            }
        }

        private static int GetInt(string s) { return s == "" ? 0 : int.Parse(s); }

        public static bool ТумблерАвтКоррекция
        {
            get { return _тумблерАвтКоррекция; }
            set
            {
                _тумблерАвтКоррекция = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - 1 Группа, false - 2 Группа
        /// </summary>
        public static bool ТумблерГруппа
        {
            get { return _тумблерГруппа; }
            set
            {
                _тумблерГруппа = value;
                if (Включен && КнопкиПараметры.PressedButton != -1)
                {
                    _значение = "";
                    IsWritten = false;
                }
                OnParameterChanged();
            }
        }


        /// <summary>
        /// Возможные состояния: true - 1 комплект, false - 2 комплект
        /// </summary>
        public static bool ТумблерКомплект
        {
            get { return _тумблерКомплект; }
            set
            {
                if ((value && !Комплект) || (!value && Комплект))
                    Комплект = !Комплект;

                _тумблерКомплект = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region Переключатели

        #region Переключатель проверка

        /// <summary>
        /// Положение переключателя проверки
        /// </summary>
        private static int _переключательПроверка = 1;

        /// <summary>
        /// Названия положений:
        /// 1 - 0,
        /// 2 - t,
        /// 3 - alpha P,
        /// 4 - beta P,
        /// 5 - delta F,
        /// 6 - alpha phi,
        /// 7 - beta phi,
        /// 8 - Д,
        /// 9 - Ш,
        /// 10 - К
        /// </summary>
        public static int ПереключательПроверка
        {
            get { return _переключательПроверка; }
            set
            {
                if (value > 0 && value < 11) _переключательПроверка = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательРежимРаботы

        /// <summary>
        /// Положение переключателя режима работы
        /// </summary>
        private static int _переключательРежимРаботы = 1;

        /// <summary>
        /// Названия положений:
        /// 1 - 0,
        /// 2 - РАБ1,
        /// 3 - РАБ2,
        /// 4 - ПРОГН,
        /// 5 - РИ,
        /// 6 - ПУ,
        /// 7 - УВВ,
        /// 8 - БПР,
        /// </summary>
        public static int ПереключательРежимРаботы
        {
            get { return _переключательРежимРаботы; }
            set
            {
                if (value > 0 && value < 9) _переключательРежимРаботы = value;
                OnParameterChanged();
            }
        }

        #endregion

        #endregion

        #region Кнопки

        /// <summary>
        /// Названия кнопок:
        /// 0 - Аlpha/Lambda,
        /// 1 - Epsilon/Phi,
        /// 2 - I/H,
        /// 3 - Omega/N,
        /// 4 - Lambda0/f,
        /// 5 - t0/K,
        /// 6 - T/Kbeta,
        /// 7 - tсв/Yalpha,
        /// 8 - tуст/Ybeta,
        /// </summary>
        public static A403_1Кнопки КнопкиПараметры = new A403_1Кнопки();

        public static bool КнопкаУстВремени
        {
            get { return _кнопкаУстВремени; }
            set
            {
                if (Включен && value && !ТумблерАвтКоррекция)
                {
                    var hours =
                        int.Parse(ТумблерКомплект
                            ? ДисплейЗначения1К[0, 8].Substring(1, 2)
                            : ДисплейЗначения2К[0, 8].Substring(1, 2));
                    var minutes =
                        int.Parse(ТумблерКомплект
                            ? ДисплейЗначения1К[0, 8].Substring(3, 2)
                            : ДисплейЗначения2К[0, 8].Substring(3, 2));
                    var seconds =
                        int.Parse(ТумблерКомплект
                            ? ДисплейЗначения1К[0, 8].Substring(5, 2)
                            : ДисплейЗначения2К[0, 8].Substring(5, 2));
                    Time = hours * 3600 + minutes * 60 + seconds;
                }

                _кнопкаУстВремени = value;
            }
        }

        #endregion

        #region Табло

        /// <summary>
        /// Матрица для хранения введённых значений для 1 комплекта, 1 строка соответствует значениям 1 группы переменных, а 2 для 2 группы.
        /// 0 - Аlpha/Lambda,
        /// 1 - Epsilon/Phi,
        /// 2 - I/H,
        /// 3 - Omega/N,
        /// 4 - Lambda0/f,
        /// 5 - t0/K,
        /// 6 - T/Kbeta,
        /// 7 - tсв/Yalpha,
        /// 8 - tуст/Ybeta,
        /// </summary>
        public static A403_1ЗначенияПараметров ДисплейЗначения1К = new A403_1ЗначенияПараметров();

        /// <summary>
        /// Матрица для хранения введённых значений для 2 комплекта, 1 строка соответствует значениям 1 группы переменных, а 2 для 2 группы.
        /// 0 - Аlpha/Lambda,
        /// 1 - Epsilon/Phi,
        /// 2 - I/H,
        /// 3 - Omega/N,
        /// 4 - Lambda0/f,
        /// 5 - t0/K,
        /// 6 - T/Kbeta,
        /// 7 - tсв/Yalpha,
        /// 8 - tуст/Ybeta,
        /// </summary>
        public static A403_1ЗначенияПараметров ДисплейЗначения2К = new A403_1ЗначенияПараметров();


        /// <summary>
        /// Свойство для хранения:
        /// введенного на табло значения но не сохраненного в ДисплейЗначения, а также
        /// отображения времени таймера
        /// </summary>
        public static string Значение
        {
            get { return _значение; }
            set
            {
                if (!Включен || IsWritten) return;
                if ((КнопкиПараметры.PressedButton == 3 || КнопкиПараметры.PressedButton == 4)
                    && !ТумблерГруппа && value.Length == 2)
                {
                    if (ТумблерКомплект)
                        ДисплейЗначения1К[ТумблерГруппа ? 0 : 1, КнопкиПараметры.PressedButton] = value;
                    else
                        ДисплейЗначения2К[ТумблерГруппа ? 0 : 1, КнопкиПараметры.PressedButton] = value;
                    _значение = "";
                }
                else if (value.Length == 7)
                {
                    if (ТумблерКомплект)
                        ДисплейЗначения1К[ТумблерГруппа ? 0 : 1, КнопкиПараметры.PressedButton] = value;
                    else
                        ДисплейЗначения2К[ТумблерГруппа ? 0 : 1, КнопкиПараметры.PressedButton] = value;
                    _значение = "";
                }
                else if (value.Length <= 7 && КнопкиПараметры.PressedButton != -1)
                {
                    _значение = value;
                    OnDisplayChanged();
                }
            }
        }

        /// <summary>
        /// Для преобразования значения угла в градусах в строку для отображения на дисплее
        /// </summary>
        private static string GradForDisplay(double value)
        {
            var angle = Math.Abs((int)value).ToString().PadLeft(3, '0') +
                        Math.Abs((int)(value % 1 * 60 * 10)).ToString().PadLeft(3, '0');
            return value >= 0 ? "+" + angle : "-" + angle;
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
            SetTimer();
            OnParameterChanged();
        }

        #region DisplayReset

        public delegate void DisplayChangedHandler();

        public static event DisplayChangedHandler DisplayChanged;

        private static void OnDisplayChanged()
        {
            var handler = DisplayChanged;
            if (handler != null) handler();
        }

        public static void ResetDisplay()
        {
            OnDisplayChanged();
        }

        #endregion
    }

    #region IndexerClass

    public class A403_1Кнопки
    {
        public static bool[] КнопкиПараметры = { false, false, false, false, false, false, false, false, false, false };

        public bool this[int buttonNumber]
        {
            get { return КнопкиПараметры[buttonNumber]; }
            set
            {
                for (var i = 0; i < 9; i++)
                    КнопкиПараметры[i] = false;

                if (buttonNumber != 9)
                {
                    for (var i = 0; i < 9; i++)
                        КнопкиПараметры[i] = false;
                    КнопкиПараметры[buttonNumber] = true;
                    A403_1Parameters.IsWritten = false;
                }

                A403_1Parameters.ResetParameters();
            }
        }

        public int PressedButton { get { return Array.IndexOf(КнопкиПараметры, true); } }
    }

    public class A403_1ЗначенияПараметров
    {
        public static string[,] ДисплейЗначения =
        {
            {"", "", "", "", "", "", "", "", "+000000"},
            {"", "", "", "", "", "", "", "", ""}
        };

        //public static string[,] ДисплейЗначения =
        //{
        //    {"+265419", "+741271", "+064535", "+279105", "+077385", "+123723", "+115716", "", "+000000"},
        //    {"+356285", "+048472", "+000001", "+1", "+3", "+010000", "", "", ""}
        //};

        public string this[int группа, int номерКнопки]
        {
            get { return ДисплейЗначения[группа, номерКнопки]; }
            set
            {
                //ограничения на размер хранимых значений
                if (A403_1Parameters.КнопкиПараметры.PressedButton == 8 && группа == 0
                    && value.Length == 7) //установка времени
                {
                    int hours = Int32.Parse(value.Substring(1, 2));
                    int minutes = Int32.Parse(value.Substring(3, 2));
                    int seconds = Int32.Parse(value.Substring(5, 2));
                    int time = hours * 3600 + minutes * 60 + seconds;

                    ДисплейЗначения[0, 8] = (time > 86400)
                        ? "+275135"
                        : "+" + (time / 3600 / 10) + (time / 3600 % 10) +
                          (time / 60 % 60 / 10) + (time / 60 % 60 % 10) +
                          (time % 60 / 10) + (time % 60 % 10);
                }
                else if (группа == 1 && value.Length == 2
                         && (A403_1Parameters.КнопкиПараметры.PressedButton == 3
                             || A403_1Parameters.КнопкиПараметры.PressedButton == 4))
                {
                    ДисплейЗначения[группа, номерКнопки] = value;
                }
                else if (A403_1Parameters.КнопкиПараметры.PressedButton != -1 && value.Length == 7)
                {
                    ДисплейЗначения[группа, номерКнопки] = value;
                }
                else
                {
                    return;
                }

                A403_1Parameters.Значение = "";
                A403_1Parameters.ResetDisplay();
                A403_1Parameters.IsWritten = true;
            }
        }

        public void ОчиститьЗначения()
        {
            for (var i = 0; i < 9; i++)
            {
                ДисплейЗначения[0, i] = "";
                ДисплейЗначения[1, i] = "";
            }
            ДисплейЗначения[0, 8] = "+000000";

            //временно
            ДисплейЗначения = new[,]
            {
                { "+265419", "+741271", "+064535", "+279105", "+077385", "+123723", "+115716", "", "+000000"},
                { "+356285", "+048472", "+000001", "+1", "+3", "+010000", "", "", ""}
            };
        }

        public int GetInt(int группа, int номер)
        {
            return ДисплейЗначения[группа, номер] == "" ? 0 : int.Parse(ДисплейЗначения[группа, номер]);
        }

        public int GetTime()
        {
            int hours = 0, minutes = 0, seconds = 0;
            if (ДисплейЗначения[0, 5].Length != 7) return hours * 3600 + minutes * 60 + seconds;
            hours = int.Parse(ДисплейЗначения[0, 5].Substring(1, 2));
            minutes = int.Parse(ДисплейЗначения[0, 5].Substring(3, 2));
            seconds = int.Parse(ДисплейЗначения[0, 5].Substring(5, 2));
            return hours * 3600 + minutes * 60 + seconds;
        }

        public int GetTimeYst()
        {
            int hours = 0, minutes = 0, seconds = 0;
            if (ДисплейЗначения[0, 8].Length != 7) return hours * 3600 + minutes * 60 + seconds;
            hours = int.Parse(ДисплейЗначения[0, 8].Substring(1, 2));
            minutes = int.Parse(ДисплейЗначения[0, 8].Substring(3, 2));
            seconds = int.Parse(ДисплейЗначения[0, 8].Substring(5, 2));
            return hours * 3600 + minutes * 60 + seconds;
        }

        /// <summary>
        /// возвращает значение угла введенное пользователем, в радианах
        /// </summary>
        public double GetRad(int группа, int номер)
        {
            return (GetInt(группа, номер) / 1000 + (GetInt(группа, номер) % 1000 / 10d) / 60d) * 0.0174532925199;
        }
    }

    #endregion

    #region Неудавшиеся расчеты

    //public static double AlphaP = 0;
    //public static double BetaP = 0;


    //public static void CalculateOld()
    //{
    //    //var a = 26541.9; //километры ведь?
    //    //var e = 0.741271;
    //    //var i = (64 + 53.5F / 60) * 0.0174532925199;
    //    //var omega = (279 + 10.5F / 60) * 0.0174532925199;
    //    //var fi = (48 + 47.2F / 60) * 0.0174532925199;
    //    //var H = 1;
    //    //var t0 = 12 * 3600 + 37 * 60 + 23;
    //    //var lambda = (356 + 28.5F / 60) * 0.0174532925199;
    //    //var lambda0 = (77 + 38.5F / 60) * 0.0174532925199;
    //    ////var T = 12*3600;
    //    //var T = 11 * 3600 + 57 * 60 + 16;
    //    ////Time = 15 * 3600 + 10 * 60;

    //    ////var m = 5.9736*Math.Pow(10,24);
    //    ////var m = -100d;
    //    //var alpha = 0d;
    //    //var beta = 0d;

    //    ////while ((int)alpha != 47 && (int)beta != 22)
    //    ////    for (int l = 0; l < 20; l++)
    //    ////    {
    //    //var m = 2000;

    //    //var cosE0 = (float)(0.5F * e + 0.5F * Math.Cos(omega)) /
    //    //            (0.5F + 0.5F * e * Math.Cos(omega));
    //    //var absSinE0 = Math.Sqrt(1 - cosE0 * cosE0);
    //    //var sinE0 = Math.Sin(omega) < 0 ? absSinE0 : absSinE0 * (-1);
    //    //var tgE0 = (float)sinE0 / cosE0;
    //    //var E0 = Math.Atan(tgE0);
    //    //var M0 = E0 - e * (1F / (Math.PI * 2)) * sinE0;
    //    //var pzx = Math.Sin(omega) * Math.Sin(i);
    //    //var pzy = Math.Cos(omega) * Math.Sin(i);
    //    //var S = Math.Sin(omega) * Math.Cos(i);
    //    //var C = Math.Cos(omega) * Math.Cos(i);
    //    //var Rad = a * Math.Sqrt(1 - Math.Pow(e, 2));
    //    //var f = 1 / 298.3;
    //    //var Cfi = (6376.245 / Math.Pow(10, 5)) /
    //    //          Math.Sqrt(1 - (2 * f - f * f) * Math.Pow(Math.Sin(fi), 2));
    //    //var Sfi = Cfi * Math.Pow(1 - f, 2);
    //    //var X = (Cfi + H) * Math.Cos(fi);
    //    //var Z = (Sfi + H) * Math.Sin(fi);

    //    //var Msr = (float)(Time - t0) / T + M0;
    //    //var Ek = E0; //Эксцентрическая аномалия 

    //    //for (int j = 0; j < 20; j++)
    //    //{
    //    //    double deltaEk = (0.5 * Msr + 0.5 * (1F / (Math.PI * 2) * e * Math.Sin(Ek) - 0.5 * Ek)) / (0.5 - 0.5 * e * Math.Cos(Ek));
    //    //    Ek = Ek + deltaEk;
    //    //}

    //    //var x1 = a * Math.Cos(Ek) - a * e;
    //    //var y1 = Rad * Math.Sin(Ek);
    //    ////     var m = 0.5; //а это что?
    //    //var delta = (float)(Time - t0) / m + lambda - lambda0;

    //    ////элементы матрицы поворота
    //    //var pxx = S * Math.Sin(delta) + Math.Cos(omega) * Math.Cos(delta);
    //    //var pxy = C * Math.Sin(delta) - Math.Sin(omega) * Math.Cos(delta);
    //    //var pyx = S * Math.Cos(delta) - Math.Cos(omega) * Math.Sin(delta);
    //    //var pyy = C * Math.Cos(delta) + Math.Sin(omega) * Math.Sin(delta);

    //    ////координаты ИСЗ в декартовой системе
    //    //var x = pxx * x1 + pxy * y1;
    //    //var y = pyx * x1 + pyy * y1;
    //    //var z = pzx * x1 + pzy * y1;

    //    //var ro = Math.Sqrt(Math.Pow(x - X, 2) + y * y + Math.Pow(z - Z, 2));
    //    //var d = 6375.245 * ro; //дальность (расстояние от наблюдателя до ИСЗ)
    //    //var ksi = (z - Z) * Math.Cos(fi) - (x - X) * Math.Sin(fi);
    //    //var eta = y;
    //    //var dzeta = (z - Z) * Math.Sin(fi) + (x - X) * Math.Cos(fi);
    //    //var tanAlpha = eta / ksi;
    //    //alpha = Math.Atan(tanAlpha) * 180 / Math.PI; //азимут
    //    //var tanBeta = dzeta / Math.Sqrt(ksi * ksi + eta * eta);
    //    //beta = Math.Atan(tanBeta) * 180 / Math.PI; //угол места 
    //    ////}
    //    //AlphaP = Math.Round(alpha, 3);
    //    //BetaP = Math.Round(beta, 3);
    //}


    ////public static void CalculateOldOld()
    ////{
    ////    //var a = ДисплейЗначения1К.GetInt(0, 0) / 10d;
    ////    //var e = ДисплейЗначения1К.GetInt(0, 1) / 1000000d;
    ////    //var i = ДисплейЗначения1К.GetRad(0, 2);
    ////    //var omega = ДисплейЗначения1К.GetRad(0, 3);
    ////    //var fi = ДисплейЗначения1К.GetRad(1, 1);
    ////    //var H = ДисплейЗначения1К.GetInt(1, 2);
    ////    //var t0 = ДисплейЗначения1К.GetTime(); //время в секундах
    ////    //var lambda = ДисплейЗначения1К.GetRad(1, 0);
    ////    //var lambda0 = ДисплейЗначения1К.GetRad(0, 4);
    ////    //var T = ДисплейЗначения1К.GetTime();

    ////    var a = 26541.9; //километры
    ////    var e = 0.741271;
    ////    var i = (64 + 53.5F / 60) * 0.0174532925199;
    ////    var omega = (279 + 10.5F / 60) * 0.0174532925199;
    ////    var fi = (48 + 47.2F / 60) * 0.0174532925199;
    ////    var H = 1;
    ////    var t0 = 12 * 3600 + 37 * 60 + 23;
    ////    var lambda = (356 + 28.5F / 60) * 0.0174532925199;
    ////    var lambda0 = (77 + 38.5F / 60) * 0.0174532925199;
    ////    //var T = 12*3600;
    ////    var T = 11 * 3600 + 57 * 60 + 16;
    ////    //Time = 15 * 3600 + 10 * 60;

    ////    //var m = 5.9736*Math.Pow(10,24);
    ////    //var m = -100d;
    ////    var alpha = 0d;
    ////    var beta = 0d;

    ////    //while ((int)alpha != 47 && (int)beta != 22)
    ////    //    for (int l = 0; l < 20; l++)
    ////    //    {
    ////    //        //m += 0.0001;

    ////    //        var cosE0 = (float)(0.5F * e + 0.5F * Math.Cos(omega)) /
    ////    //                    (0.5F + 0.5F * e * Math.Cos(omega));
    ////    //        var absSinE0 = Math.Sqrt(1 - cosE0 * cosE0);
    ////    //        var sinE0 = Math.Sin(omega) < 0 ? absSinE0 : absSinE0 * (-1);
    ////    //        var tgE0 = (float)sinE0 / cosE0;
    ////    //        var E0 = Math.Atan(tgE0);
    ////    //        var M0 = E0 - e * (1F / (Math.PI * 2)) * sinE0;
    ////    //        var pzx = Math.Sin(omega) * Math.Sin(i);
    ////    //        var pzy = Math.Cos(omega) * Math.Sin(i);
    ////    //        var S = Math.Sin(omega) * Math.Cos(i);
    ////    //        var C = Math.Cos(omega) * Math.Cos(i);
    ////    //        var Rad = a * Math.Sqrt(1 - Math.Pow(e, 2));
    ////    //        var f = 1 / 298.3;
    ////    //        var Cfi = (6376.245 / Math.Pow(10, 5)) /
    ////    //                  Math.Sqrt(1 - (2 * f - f * f) * Math.Pow(Math.Sin(fi), 2));
    ////    //        var Sfi = Cfi * Math.Pow(1 - f, 2);
    ////    //        var X = (Cfi + H) * Math.Cos(fi);
    ////    //        var Z = (Sfi + H) * Math.Sin(fi);

    ////    //        var Msr = (float)(Time - t0) / T + M0;
    ////    //        var Ek = E0; //Эксцентрическая аномалия 

    ////    //        for (int j = 0; j < 20; j++)
    ////    //        {
    ////    //            double deltaEk = (0.5 * Msr + 0.5 * (1F / (Math.PI * 2) * e * Math.Sin(Ek) - 0.5 * Ek)) / (0.5 - 0.5 * e * Math.Cos(Ek));
    ////    //            Ek = Ek + deltaEk;
    ////    //        }

    ////    //        var x1 = a * Math.Cos(Ek) - a * e;
    ////    //        var y1 = Rad * Math.Sin(Ek);
    ////    //        //     var m = 0.5; //а это что?
    ////    //        var delta = (float)(Time - t0) / T + lambda - lambda0;

    ////    //        //элементы матрицы поворота
    ////    //        var pxx = S * Math.Sin(delta) + Math.Cos(omega) * Math.Cos(delta);
    ////    //        var pxy = C * Math.Sin(delta) - Math.Sin(omega) * Math.Cos(delta);
    ////    //        var pyx = S * Math.Cos(delta) - Math.Cos(omega) * Math.Sin(delta);
    ////    //        var pyy = C * Math.Cos(delta) + Math.Sin(omega) * Math.Sin(delta);

    ////    //        //координаты ИСЗ в декартовой системе
    ////    //        var x = pxx * x1 + pxy * y1;
    ////    //        var y = pyx * x1 + pyy * y1;
    ////    //        var z = pzx * x1 + pzy * y1;

    ////    //        var ro = Math.Sqrt(Math.Pow(x - X, 2) + y * y + Math.Pow(z - Z, 2));
    ////    //        var d = 6375.245 * ro; //дальность (расстояние от наблюдателя до ИСЗ)
    ////    //        var ksi = (z - Z) * Math.Cos(fi) - (x - X) * Math.Sin(fi);
    ////    //        var eta = y;
    ////    //        var dzeta = (z - Z) * Math.Sin(fi) + (x - X) * Math.Cos(fi);
    ////    //        var tanAlpha = eta / ksi;
    ////    //        alpha = Math.Atan(tanAlpha) * 180 / Math.PI; //азимут
    ////    //        var tanBeta = dzeta / Math.Sqrt(ksi * ksi + eta * eta);
    ////    //        beta = Math.Atan(tanBeta) * 180 / Math.PI; //угол места 
    ////    //    }
    ////    //AlphaP = Math.Round(alpha, 3);
    ////    //BetaP = Math.Round(beta, 3);


    ////    //посчитаем третьим способом

    ////    /*
    ////    var cosE03 = (float)(0.5F * e + 0.5F * Math.Cos(omega)) /
    ////                 (0.5F + 0.5F * e * Math.Cos(omega));
    ////    var absSinE03 = Math.Sqrt(1 - cosE03 * cosE03);
    ////    var sinE03 = Math.Sin(omega) < 0 ? absSinE03 : absSinE03 * (-1);
    ////    var tgE03 = (float)sinE03 / cosE03;
    ////    var E03 = Math.Atan(tgE03);
    ////    var M03 = E03 - e * (1F / (Math.PI * 2)) * sinE03;

    ////    var k3 = 6.67408*Math.Pow(10, -11)*5.97219*Math.Pow(10, 24);
    ////    var n3 = Math.Sqrt(k3/(a*a*a*1000*1000*1000)); //а ведь а - в км?

    ////    var Msr3 = (float)(Time - t0) * n3 + M03;
    ////    var Ek3 = Msr3 + e*Math.Sin(Msr3)/(1 - e*Math.Cos(Msr3)); //Эксцентрическая аномалия 

    ////    for (int j = 0; j < 20; j++)
    ////    {
    ////        double deltaEk = (Msr3 - Ek3 + e*Math.Sin(Ek3))/(1 - e*Math.Cos(Ek3));
    ////        Ek3 = Ek3 + deltaEk;
    ////    }
    ////    */


    ////    #region 1
    ////    //double G = 6.67428E-11;
    ////    //double TWO_PI = Math.PI * 2;
    ////    //double PI2 = Math.Pow(Math.PI, 2);


    ////    //double majorAxis = a, M = 5.972E+24, mm = 2000;
    ////    //double CirculationTime = Math.Sqrt((Math.Pow(majorAxis, 3) * 4 * PI2) /
    ////    //    (G * (M + mm)));

    ////    //double meanAnomaly = TWO_PI / CirculationTime * (Time - t0);

    ////    //double tempResult = meanAnomaly;
    ////    //double numerator;
    ////    //for (int i1 = 0; i1 < 20; i1++)
    ////    //{
    ////    //    numerator = meanAnomaly + e * Math.Sin(tempResult)
    ////    //                - e * tempResult * Math.Cos(tempResult);
    ////    //    tempResult = numerator / (1 - e * Math.Cos(tempResult));
    ////    //}
    ////    //double eccentricAnomaly = tempResult;

    ////    #endregion

    ////    double G4 = 6.67428E-11;
    ////    double M4 = 5.972E+24, msatelite4 = 2000;
    ////    double k4 = G4 * (M4 + msatelite4);
    ////    double n4 = (2 * Math.PI) / T; //среднее движение

    ////    var tperig = t0; //время прохождения перигея
    ////    var tnach = t0 + 1; //начальное время

    ////    double M04 = -n4 / (tperig - tnach); //средняя аномалия
    ////    double meanAnomaly = n4 * (Time - tnach) + M04;

    ////    double excentricAnomaly = meanAnomaly + e * Math.Sin(meanAnomaly) / (1 - e * Math.Cos(meanAnomaly));

    ////    for (int j = 0; j < 20; j++)
    ////    {
    ////        double deltaE = (meanAnomaly - excentricAnomaly + e * Math.Sin(excentricAnomaly)) /
    ////                         (1 - e * Math.Cos(excentricAnomaly));
    ////        excentricAnomaly = excentricAnomaly + deltaE;
    ////    }

    ////    double sinV = (Math.Sqrt(1 - e * e) * Math.Sin(excentricAnomaly)) / (1 - e * Math.Cos(excentricAnomaly));
    ////    double cosV = (Math.Cos(excentricAnomaly) - e) / (1 - e * Math.Cos(excentricAnomaly));
    ////    double r4_1 = (a * (1 - e * e)) / (1 + e * cosV);
    ////    double r4_2 = a * (1 - e * Math.Cos(excentricAnomaly)); //r4_2 должно быть = r4_1

    ////    double sinU = Math.Sin(omega) * cosV + Math.Cos(omega) * sinV;
    ////    double cosU = Math.Cos(omega) * cosV - Math.Sin(omega) * sinV;


    ////    //это вроде бы верно
    ////    double x4 = r4_2 * (cosU * Math.Cos(lambda0) - sinU * Math.Sin(lambda0) * Math.Cos(i));
    ////    double y4 = r4_2 * (cosU * Math.Sin(lambda0) + sinU * Math.Cos(lambda0) * Math.Cos(i));
    ////    double z4 = r4_2 * sinU * Math.Sin(i);

    ////    var orbith4 = Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4) - 6366.245; //высота спутника над землей

    ////    //еще один способ расчета координат исз
    ////    double r5 = a * (1 - e * Math.Cos(excentricAnomaly));
    ////    double zita = a * (Math.Cos(excentricAnomaly) - e);
    ////    double nu = a * Math.Sqrt(1 - e * e) * Math.Sin(excentricAnomaly);
    ////    double px = Math.Cos(omega) * Math.Cos(lambda0) - Math.Sin(omega) * Math.Sin(lambda0) * Math.Cos(i);
    ////    double py = Math.Cos(omega) * Math.Sin(lambda0) + Math.Sin(omega) * Math.Cos(lambda0) * Math.Cos(i);
    ////    double pz = Math.Sin(omega) * Math.Sin(i);
    ////    double qx = -Math.Sin(omega) * Math.Cos(lambda0) - Math.Cos(omega) * Math.Sin(lambda0) * Math.Cos(i);
    ////    double qy = -Math.Sin(omega) * Math.Sin(lambda0) + Math.Cos(omega) * Math.Cos(lambda0) * Math.Cos(i);
    ////    double qz = Math.Cos(omega) * Math.Sin(i);
    ////    double ravno1 = px * px + py * py + pz * pz;
    ////    double ravno12 = qx * qx + qy * qy + qz * qz;
    ////    double ravno0 = px * qx + py * qy + pz * qz;
    ////    double x5 = px * zita + qx * nu;
    ////    double y5 = py * zita + qy * nu;
    ////    double z5 = pz * zita + qz * nu;


    ////    #region region

    ////    //посчитаем другим способом
    ////    var mu = 4 * Math.PI * Math.PI * a * a * a / (T * T);
    ////    //var n = 2*Math.PI/(T*T);
    ////    var n = Math.Sqrt(mu) / (Math.Pow(a, 3 / 2d));
    ////    //var M0 = n*(t0 - Time);

    ////    var cosE0 = (float)(0.5F * e + 0.5F * Math.Cos(omega)) /
    ////                 (0.5F + 0.5F * e * Math.Cos(omega));
    ////    var absSinE0 = Math.Sqrt(1 - cosE0 * cosE0);
    ////    var sinE0 = Math.Sin(omega) < 0 ? absSinE0 : absSinE0 * (-1);
    ////    var tgE0 = (float)sinE0 / cosE0;
    ////    var E0 = Math.Atan(tgE0);
    ////    var M0 = E0 - e * (1F / (Math.PI * 2)) * sinE0;

    ////    var Msr = (float)(Time - t0) / T + M0;
    ////    var Ek = E0; //Эксцентрическая аномалия 

    ////    for (int j = 0; j < 20; j++)
    ////    {
    ////        double deltaEk = (0.5 * Msr + 0.5 * (1F / (Math.PI * 2) * e * Math.Sin(Ek) - 0.5 * Ek)) / (0.5 - 0.5 * e * Math.Cos(Ek));
    ////        Ek = Ek + deltaEk;
    ////    }

    ////    var tanV2 = Math.Sqrt((1 + e) / (1 - e)) * Math.Tan(Ek / 2);
    ////    var V = Math.Atan(tanV2) * 2;
    ////    var r = a * (1 - e * e) / (1 + e * Math.Cos(V));
    ////    var r2 = Math.Sqrt(mu / (a * (1 - e * e))) * e * Math.Sin(V);
    ////    var omegaBig = lambda - Math.PI; //долгота нисходящего узла
    ////    var u = omega + V;
    ////    var alpha1 = Math.Cos(omegaBig) * Math.Cos(u) - Math.Sin(omegaBig) * Math.Sin(u) * Math.Cos(i);
    ////    var beta1 = Math.Sin(omegaBig) * Math.Cos(u) - Math.Cos(omegaBig) * Math.Sin(u) * Math.Cos(i);
    ////    var gamma1 = Math.Sin(u) * Math.Sin(i);
    ////    var x1 = r * alpha1;
    ////    var y1 = r * beta1;
    ////    var z1 = r * gamma1;


    ////    var orbith = Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1) - 6366.245;


    ////    //исз в сферических координатах (в радианах)
    ////    var r1 = Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);
    ////    var fi1 = Math.Acos(z1 / r1);     //широта
    ////    var lambda1 = Math.Atan(y1 / x1);     //долгота

    ////    //координаты наблюдателя (это вроде бы правильно)
    ////    var Re = 6378.245;
    ////    var Rp = 6356.853;
    ////    var R0 = (Re * Rp) / (Math.Cos(fi) * Math.Sqrt(Rp * Rp + Math.Tan(fi) * Math.Tan(fi) * Re * Re));
    ////    var X1 = R0 * Math.Sin(fi) * Math.Cos(lambda);
    ////    var Y1 = R0 * Math.Sin(fi) * Math.Sin(lambda);
    ////    var Z1 = R0 * Math.Cos(fi);


    ////    //азимут
    ////    //прямоугольные координаты спутника в сферические
    ////    double ro4 = Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4);
    ////    double cosdolgota = x4 / Math.Sqrt(x4 * x4 + y4 * y4);
    ////    var sindolgota = y4 / Math.Sqrt(x4 * x4 + y4 * y4);//для проверки
    ////    double dolgota = Math.Asin(sindolgota); //lon
    ////    double shirota = Math.Acos(z4 / Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4)); //lat

    ////    double latit = Math.Atan(z4 / ro4) * 180 / Math.PI;
    ////    double lont = Math.Atan2(y4, x4) * 180 / Math.PI;

    ////    double lon2 = 2 * Math.Atan(y4 / (x4 + Math.Sqrt(x4 * x4 + y4 * y4)));
    ////    double lon3 = y4 >= 0
    ////        ? (Math.PI / 2 - 2 * Math.Atan(x4 / (Math.Sqrt(x4 * x4 + y4 * y4) + y4)))
    ////        : (-Math.PI / 2 + 2 * Math.Atan(x4 / (Math.Sqrt(x4 * x4 + y4 * y4) - y4)));

    ////    //а теперь посчитаем широту, это не так просто
    ////    double b = a * Math.Sqrt(1 - e * e);
    ////    double tanb = z4 / Math.Sqrt(x4 * x4 + y4 * y4);
    ////    double B = Math.Atan(tanb);
    ////    double N = Math.Pow(a * a * (a * a * Math.Cos(B) * Math.Cos(B) + b * b * Math.Sin(B) * Math.Sin(B)), -1 / 2f);
    ////    double H4 = (Math.Sqrt(x4 * x4 + y4 * y4) / Math.Cos(B)) - N;

    ////    for (int i4 = 0; i4 < 5; i4++) //сходится за пару итераций
    ////    {
    ////        tanb = z4 / Math.Sqrt(x4 * x4 + y4 * y4) + (e * e * N) / (N + H);
    ////        B = Math.Atan(tanb);
    ////        N = Math.Pow(a * a * (a * a * Math.Cos(B) * Math.Cos(B) + b * b * Math.Sin(B) * Math.Sin(B)), -1 / 2f);
    ////        H4 = (Math.Sqrt(x4 * x4 + y4 * y4) / Math.Cos(B)) - N;
    ////    }
    ////    //этот способ кажется наконец то правильно посчитал


    ////    #region r


    ////    ///////////////////////////////////
    ////    //double rolat = Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4);
    ////    //double rlat = Math.Sqrt(x4 * x4 + y4 * y4);
    ////    //double f4 = 1 - Math.Sqrt(1 - e * e);
    ////    ////double b = a * (1 - f4);

    ////    //double r4 = Math.Sqrt(x4 * x4 + y4 * y4);
    ////    //double Ro4 = Math.Sqrt(x4*x4 + y4*y4 + z4*z4);
    ////    //double tanB = (z4 / r4) * (1 + (e * e / (1 - e * e)) * (b / Ro4));
    ////    //double tanFi;
    ////    //double Fii = 0;
    ////    //double BB = 0;
    ////    //for (int oo = 0; oo < 20; oo++)
    ////    //{
    ////    //    tanB = (1 - f4)*tanB;
    ////    //    tanB = (z4 +
    ////    //            ((e*e/(1 - e*e))*b*Math.Sin(Math.Atan(tanB))*Math.Sin(Math.Atan(tanB))*
    ////    //             Math.Sin(Math.Atan(tanB))))/
    ////    //           (Math.Sqrt(x4*x4 + y4*y4) -
    ////    //            e*e*a*Math.Cos(Math.Atan(tanB))*Math.Cos(Math.Atan(tanB))*Math.Cos(Math.Atan(tanB)));
    ////    //    Fii = Math.Atan(tanB)*180/Math.PI;
    ////    //    //BB = Math.Atan(tanB) * 180 / Math.PI;

    ////    //}


    ////    //double TOL = 1.04E-14;
    ////    //double A = 6378137.0;
    ////    //double E2 = 0.006694380022903416;
    ////    //double AE2 = A * E2;
    ////    ////начальная оценка широты
    ////    //double p = Math.Sqrt(x4 * x4 + y4 * y4);
    ////    //double tgla = z4 / p / (1.0 - E2);
    ////    //double latitude, longitude;
    ////    //double eht;
    ////    //for (int j = 0; j < 20; j++)
    ////    //{
    ////    //    //double tglax = tgla;
    ////    //    tgla = z4 / (p - (AE2 / Math.Sqrt(1.0 + (1.0 - E2) * tgla * tgla)));
    ////    //    //if (Math.Abs(tgla - tglax) <= TOL)
    ////    //    //{
    ////    //    latitude = Math.Atan(tgla);
    ////    //    //    double sinLat = Math.Sin(latitude);
    ////    //    //    longitude = Math.Atan2(y4, x4);
    ////    //    //    double w = Math.Sqrt(1.0 - E2*sinLat*sinLat);
    ////    //    //    double nn = A/w;
    ////    //    //    if (Math.Abs(latitude) < 0.7854) eht = p/Math.Cos(latitude) - nn;
    ////    //    //    else eht = z4/sinLat - nn + E2*nn;
    ////    //    //    break;
    ////    //    //}
    ////    //}
    ////    #endregion
    ////    //рачет азимута и угла места, вроде бы в корне неверный
    ////    double theta = lon2;
    ////    double lat = B;
    ////    double rx = x4 - X1;
    ////    double ry = y4 - Y1;
    ////    double rz = z4 - Z1;
    ////    double top_s = Math.Sin(lat) * Math.Cos(theta) * rx + Math.Sin(lat) * Math.Sin(theta) * ry - Math.Cos(lat) * rz;
    ////    double top_e = -Math.Sin(theta) * rx + Math.Cos(theta) * ry;
    ////    double top_z = Math.Cos(lat) * Math.Cos(theta) * rx + Math.Cos(lat) * Math.Sin(theta) * ry + Math.Sin(lat) * rz;
    ////    double az = Math.Atan(-top_e / top_s);
    ////    if (top_s > 0)
    ////        az += Math.PI;
    ////    if (az < 0)
    ////        az += 2 * Math.PI;
    ////    double rg = Math.Sqrt(rx * rx + ry * ry + rz * rz);
    ////    double el = Math.Asin(top_z / rg);
    ////    double azim = az * 180 / Math.PI;
    ////    double elev = el * 180 / Math.PI;


    ////    var nabl = Math.Sqrt(X1 * X1 + Y1 * Y1 + Z1 * Z1);

    ////    double eee = (z4 - Z1) * Math.Cos(fi) - (x4 - X1) * Math.Sin(fi);
    ////    double alpha4 = Math.Atan(y4 / eee) * 180 / Math.PI;


    ////    var d2 = Math.Sqrt((X1 - x1) * (X1 - x1) + (Y1 - y1) * (Y1 - y1) + (Z1 - z1) * (Z1 - z1));
    ////    //var a2 = Math.Acos((Z1 - z1) / d2) * 180 / Math.PI;
    ////    //            k = PI/180;
    ////    //a = широта места * k;
    ////    //b = долгота места * k;
    ////    //c = долгота спутника * k;
    ////    //Азимут = (PI+arctan(tan(b-c)/sin(a)))/k;


    ////    //var ro = Math.Sqrt(Math.Pow(x1 - X1, 2) + y1 * y1 + Math.Pow(z1 - Z1, 2));
    ////    //var d = 6375.245 * ro; //дальность (расстояние от наблюдателя до ИСЗ)
    ////    //var ksi = (z - Z) * Math.Cos(fi) - (x - X) * Math.Sin(fi);
    ////    //var eta = y;
    ////    //var dzeta = (z - Z) * Math.Sin(fi) + (x - X) * Math.Cos(fi);
    ////    //var tanAlpha = eta / ksi;
    ////    //alpha = Math.Atan(tanAlpha) * 180 / Math.PI; //азимут
    ////    //var tanBeta = dzeta / Math.Sqrt(ksi * ksi + eta * eta);
    ////    //beta = Math.Atan(tanBeta) * 180 / Math.PI; //угол места 


    ////    //попытка расчитать угол места
    ////    //var cosanglex = (x1*X1 + y1*Y1 + z1*Z1)/(Math.Sqrt(x1*x1 + y1*y1 + z1*z1)*Math.Sqrt(X1*X1 + Y1*Y1 + Z1*Z1));
    ////    var cosanglex = (x4 * X1 + y4 * Y1 + z4 * Z1) / (Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4)
    ////        * Math.Sqrt(X1 * X1 + Y1 * Y1 + Z1 * Z1));
    ////    var anglex = Math.Acos(cosanglex);
    ////    var m = Math.Tan(anglex) * R0;
    ////    var angley = Math.PI / 2 - anglex;
    ////    var q = Math.Sqrt(R0 * R0 + m * m);
    ////    var singamma = (Math.Sin(angley) * (r1 - q)) / d2;
    ////    var beta2 = Math.Asin(singamma) * 180 / Math.PI;

    ////    BetaP = Math.Round(beta2, 3);


    ////    //второй способ расчета координат наблюдателя
    ////    var a3 = (Math.PI + Math.Atan(Math.Tan(lambda - lambda1) / Math.Sin(fi))) * 180 / Math.PI;
    ////    AlphaP = Math.Round(a3, 3);

    ////    var f = 1 / 298.3;
    ////    var C = Math.Pow((Math.Cos(fi) * Math.Cos(fi) + (1 - f) * (1 - f) * Math.Sin(fi) * Math.Sin(fi)), -1 / 2f);
    ////    var S = (1 - f) * (1 - f) * C;


    ////    var X = (Re * C + H) * Math.Cos(fi) * Math.Cos(lambda);
    ////    var Y = (Re * C + H) * Math.Cos(fi) * Math.Sin(lambda);
    ////    var Z = (Re * S + H) * Math.Sin(fi);

    ////    var d1 = Math.Sqrt((X - x1) * (X - x1) + (Y - y1) * (Y - y1) + (Z - z1) * (Z - z1));
    ////    var al = Math.Acos((Z - z1) / d1) * 180 / Math.PI;


    ////    //var ro = Math.Sqrt(Math.Pow(x1 - X, 2) + y1 * y1 + Math.Pow(z1 - Z, 2));
    ////    //var d = 6375.245 + ro; //дальность (расстояние от наблюдателя до ИСЗ)
    ////    var ksi = (z1 - Z) * Math.Cos(fi) - (x1 - X) * Math.Sin(fi);
    ////    var eta = y1;
    ////    var dzeta = (z1 - Z) * Math.Sin(fi) + (x1 - X) * Math.Cos(fi);
    ////    var tanAlpha = eta / ksi;
    ////    alpha = Math.Atan(tanAlpha) * 180 / Math.PI; //азимут
    ////    var tanBeta = dzeta / Math.Sqrt(ksi * ksi + eta * eta);
    ////    beta = Math.Atan(tanBeta) * 180 / Math.PI; //угол места 

    ////    #endregion

    ////    var ksi1 = (z4 - Z) * Math.Cos(fi) - (x4 - X) * Math.Sin(fi);
    ////    var eta1 = y4;
    ////    var tanAlpha1 = eta1 / ksi1;
    ////    alpha = Math.Atan(tanAlpha1) * 180 / Math.PI; //азимут         
    ////}

    ////public static int t0 = 0;

    //public static double a = 26541.9; //километры
    //public static double e = 0.741271;
    //public static double i = (64 + 53.5F / 60) * 0.0174532925199;
    //public static double omega = (279 + 10.5F / 60) * 0.0174532925199;
    //public static double fi = (48 + 47.2F / 60) * 0.0174532925199;
    //public static int H = 1;
    //public static int t0 = 12 * 3600 + 37 * 60 + 23;
    ////public static int t0 = 0;
    //public static double lambda = (356 + 28.5F / 60) * 0.0174532925199;
    //public static double lambda0 = (77 + 38.5F / 60) * 0.0174532925199;
    ////public static int T = 12 * 3600;
    //public static int T = 11 * 3600 + 57 * 60 + 16;

    //public static Location CalculateUnderSatLocation(Point sat)
    //{
    //    double longit = Math.Atan2(sat.y, sat.x);  //longit = lon2 = lon3
    //    double lon2 = 2 * Math.Atan(sat.y / (sat.x + Math.Sqrt(sat.x * sat.x + sat.y * sat.y)));
    //    double lon3 = sat.y >= 0
    //        ? (Math.PI / 2 - 2 * Math.Atan(sat.x / (Math.Sqrt(sat.x * sat.x + sat.y * sat.y) + sat.y)))
    //        : (-Math.PI / 2 + 2 * Math.Atan(sat.x / (Math.Sqrt(sat.x * sat.x + sat.y * sat.y) - sat.y)));
    //    //долгота без учета суточного вращения земли

    //    //а теперь посчитаем широту, это не так просто
    //    double b = a * Math.Sqrt(1 - e * e);
    //    double tanb = sat.z / Math.Sqrt(sat.x * sat.x + sat.y * sat.y);
    //    double B = Math.Atan(tanb);
    //    double N = Math.Pow(a * a * (a * a * Math.Cos(B) * Math.Cos(B) + b * b * Math.Sin(B) * Math.Sin(B)), -1 / 2f);
    //    double H4 = (Math.Sqrt(sat.x * sat.x + sat.y * sat.y) / Math.Cos(B)) - N;

    //    for (int i4 = 0; i4 < 5; i4++) //сходится за пару итераций
    //    {
    //        tanb = sat.z / Math.Sqrt(sat.x * sat.x + sat.y * sat.y) + (e * e * N) / (N + H4);
    //        B = Math.Atan(tanb);
    //        N = Math.Pow(a * a * (a * a * Math.Cos(B) * Math.Cos(B) + b * b * Math.Sin(B) * Math.Sin(B)), -1 / 2f);
    //        H4 = (Math.Sqrt(sat.x * sat.x + sat.y * sat.y) / Math.Cos(B)) - N;
    //    }
    //    //этот способ кажется наконец то правильно посчитал

    //    return new Location() { lat = B, lon = longit };
    //}

    //public static double CalculateExcentricAnomaly2(double M04, int period)
    //{
    //    double n4 = (2 * Math.PI) / period; //среднее движение
    //    var tnach = t0 + 1; //начальное время

    //    //double M04 = -n4 / (tperig - tnach); //средняя аномалия
    //    double meanAnomaly = n4 * (Time - tnach) + M04;
    //    //double meanAnomaly23 = n4 * (Time - tnach) + meanAnomaly0;

    //    double excentricAnomaly = meanAnomaly + e * Math.Sin(meanAnomaly) / (1 - e * Math.Cos(meanAnomaly));

    //    for (int j = 0; j < 20; j++)
    //    {
    //        double deltaE = (meanAnomaly - excentricAnomaly + e * Math.Sin(excentricAnomaly)) /
    //                         (1 - e * Math.Cos(excentricAnomaly));
    //        excentricAnomaly = excentricAnomaly + deltaE;
    //    }
    //    return excentricAnomaly;
    //}

    //public static double CalculateExcentricAnomaly(int tperig, int period)
    //{
    //    double G4 = 6.67428E-11;
    //    double M4 = 5.972E+24, msatelite4 = 2000;
    //    double k4 = G4 * (M4 + msatelite4);
    //    double n4 = (2 * Math.PI) / period; //среднее движение
    //    var tnach = t0 + 1; //начальное время

    //    double M04 = -n4 / (tperig - tnach); //средняя аномалия
    //                                         //double M04 = -n4 / (tperig - tnach); //средняя аномалия
    //    double meanAnomaly = n4 * (Time - tnach) + M04;
    //    //double meanAnomaly23 = n4 * (Time - tnach) + meanAnomaly0;

    //    double excentricAnomaly = meanAnomaly + e * Math.Sin(meanAnomaly) / (1 - e * Math.Cos(meanAnomaly));

    //    for (int j = 0; j < 20; j++)
    //    {
    //        double deltaE = (meanAnomaly - excentricAnomaly + e * Math.Sin(excentricAnomaly)) /
    //                         (1 - e * Math.Cos(excentricAnomaly));
    //        excentricAnomaly = excentricAnomaly + deltaE;
    //    }
    //    return excentricAnomaly;
    //}

    //public static Point CalculateSatPoint(double excentricAnomaly)
    //{
    //    double sinV = (Math.Sqrt(1 - e * e) * Math.Sin(excentricAnomaly)) / (1 - e * Math.Cos(excentricAnomaly));
    //    double cosV = (Math.Cos(excentricAnomaly) - e) / (1 - e * Math.Cos(excentricAnomaly));
    //    double r4_1 = (a * (1 - e * e)) / (1 + e * cosV);
    //    double r4_2 = a * (1 - e * Math.Cos(excentricAnomaly)); //r4_2 должно быть = r4_1

    //    double sinU = Math.Sin(omega) * cosV + Math.Cos(omega) * sinV;
    //    double cosU = Math.Cos(omega) * cosV - Math.Sin(omega) * sinV;

    //    //это вроде бы верно - координаты исз
    //    double x4 = r4_2 * (cosU * Math.Cos(lambda0) - sinU * Math.Sin(lambda0) * Math.Cos(i));
    //    double y4 = r4_2 * (cosU * Math.Sin(lambda0) + sinU * Math.Cos(lambda0) * Math.Cos(i));
    //    double z4 = r4_2 * sinU * Math.Sin(i);

    //    var orbith4 = Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4) - 6366.245; //примерная высота спутника

    //    return new Point() { x = x4, y = y4, z = z4 };
    //}

    //public static Point CalculateSatPoint2(double excentricAnomaly)
    //{
    //    double r5 = a * (1 - e * Math.Cos(excentricAnomaly));
    //    double zita = a * (Math.Cos(excentricAnomaly) - e);
    //    double nu = a * Math.Sqrt(1 - e * e) * Math.Sin(excentricAnomaly);
    //    double px = Math.Cos(omega) * Math.Cos(lambda0) - Math.Sin(omega) * Math.Sin(lambda0) * Math.Cos(i);
    //    double py = Math.Cos(omega) * Math.Sin(lambda0) + Math.Sin(omega) * Math.Cos(lambda0) * Math.Cos(i);
    //    double pz = Math.Sin(omega) * Math.Sin(i);
    //    double qx = -Math.Sin(omega) * Math.Cos(lambda0) - Math.Cos(omega) * Math.Sin(lambda0) * Math.Cos(i);
    //    double qy = -Math.Sin(omega) * Math.Sin(lambda0) + Math.Cos(omega) * Math.Cos(lambda0) * Math.Cos(i);
    //    double qz = Math.Cos(omega) * Math.Sin(i);
    //    double ravno1 = px * px + py * py + pz * pz;
    //    double ravno12 = qx * qx + qy * qy + qz * qz;
    //    double ravno0 = px * qx + py * qy + pz * qz;
    //    double x5 = px * zita + qx * nu;
    //    double y5 = py * zita + qy * nu;
    //    double z5 = pz * zita + qz * nu;

    //    //примерная высота спутника над землей
    //    var orbith5 = Math.Sqrt(x5 * x5 + y5 * y5 + z5 * z5) - 6366.245;

    //    return new Point() { x = x5, y = y5, z = z5 };
    //}

    //public static void CalcStat()
    //{
    //    //сбор статистики с орбиты за 12 часов с интервалом в 10 минут
    //    var t01 = t0;
    //    Time = 0;
    //    //t0 = 0;
    //    List<Statistic> stat = new List<Statistic>();
    //    string toFile = "";
    //    string underSat1 = "";
    //    string underSat2 = "";
    //    for (int i = 0; i < 2 * 72; i++)
    //    {
    //        Calculate();
    //        Statistic s = new Statistic()
    //        {
    //            Azim = Math.Round(Az, 2),
    //            Ymesta = Math.Round(Ym, 2),
    //            Latitude = Math.Round(SatL.lat, 2),
    //            Longitude = Math.Round(SatL.lon, 2),
    //            Time = Time.ToString()
    //        };
    //        toFile += s.Time + " аз: " + s.Azim + " ум: " + s.Ymesta + " шир: " + s.Latitude + " дол: " +
    //                  s.Longitude + "\n";
    //        underSat1 += Lambda + "\n"; //s.Longitude + "\n";
    //        underSat2 += Fi + "\n"; //s.Latitude + "\n";
    //        Time += 600;
    //        stat.Add(s);
    //    }
    //    string fileName = "F:\\спутник" + t0 + ".txt";
    //    File.WriteAllText(fileName, toFile);
    //    File.WriteAllText("F:\\underSat1.txt", underSat1);
    //    File.WriteAllText("F:\\underSat2.txt", underSat2);
    //    MessageBox.Show("записано");
    //    t0 = t01;
    //}

    //public static double Lambda;
    //public static double Fi;

    //public static void Calculate()
    //{
    //    #region region
    //    //var a = ДисплейЗначения1К.GetInt(0, 0) / 10d;
    //    //var e = ДисплейЗначения1К.GetInt(0, 1) / 1000000d;
    //    //var i = ДисплейЗначения1К.GetRad(0, 2);
    //    //var omega = ДисплейЗначения1К.GetRad(0, 3);
    //    //var fi = ДисплейЗначения1К.GetRad(1, 1);
    //    //var H = ДисплейЗначения1К.GetInt(1, 2);
    //    //var t0 = ДисплейЗначения1К.GetTime(); //время в секундах
    //    //var lambda = ДисплейЗначения1К.GetRad(1, 0);
    //    //var lambda0 = ДисплейЗначения1К.GetRad(0, 4);
    //    //var T = ДисплейЗначения1К.GetTime();

    //    //var a = 26541.9; //километры
    //    //var e = 0.741271;
    //    //var i = (64 + 53.5F/60)*0.0174532925199;
    //    //var omega = (279 + 10.5F/60)*0.0174532925199;
    //    //var fi = (48 + 47.2F/60)*0.0174532925199;
    //    //var H = 1;
    //    ////var t0 = 12*3600 + 37*60 + 23;
    //    //var t0 = 0;
    //    //var lambda = (356 + 28.5F/60)*0.0174532925199;
    //    //var lambda0 = (77 + 38.5F/60)*0.0174532925199;
    //    //var T = 12*3600;
    //    ////var T = 11*3600 + 57*60 + 16;
    //    ////Time = 15 * 3600 + 10 * 60;


    //    //старый способ расчета аномалии
    //    //var cosE0 = (float)(0.5F * e + 0.5F * Math.Cos(omega)) /
    //    //            (0.5F + 0.5F * e * Math.Cos(omega));
    //    //var absSinE0 = Math.Sqrt(1 - cosE0 * cosE0);
    //    //var sinE0 = Math.Sin(omega) < 0 ? absSinE0 : absSinE0 * (-1);
    //    //var tgE0 = (float)sinE0 / cosE0;
    //    //var E0 = Math.Atan(tgE0);
    //    //var M0 = E0 - e * (1F / (Math.PI * 2)) * sinE0;
    //    //var Msr = (float)(Time - t0) / T + M0;
    //    //var Ek = E0; //Эксцентрическая аномалия 
    //    //for (int j = 0; j < 20; j++)
    //    //{
    //    //    double deltaEk = (0.5 * Msr + 0.5 * (1F / (Math.PI * 2) * e * Math.Sin(Ek) - 0.5 * Ek)) / (0.5 - 0.5 * e * Math.Cos(Ek));
    //    //    Ek = Ek + deltaEk;
    //    //}

    //    //2) В момент прохождения спутником восходящего узла его аргумент широты равен 0.
    //    //U = 0
    //    //v = U - w  истинная аномалия
    //    //r = a * (1 - e ^ 2) / (1 + e * Cos(v))  ' расстояние до спутника
    //    #endregion

    //    var trueAnomaly0 = -omega;
    //    var tanE0on2 = Math.Tan(trueAnomaly0) / Math.Sqrt((1 + e) / (1 - e));
    //    var excAnomaly0 = 2 * Math.Atan(tanE0on2);
    //    var meanAnomaly0 = excAnomaly0 - e * Math.Sin(excAnomaly0);
    //    double n = (2 * Math.PI) / T; //среднее движение
    //    var tperigei = (int)(t0 - meanAnomaly0 / n);

    //    var exAnomaly = CalculateExcentricAnomaly(tperigei, T);
    //    var satP1 = CalculateSatPoint(exAnomaly);
    //    var satP2 = CalculateSatPoint2(exAnomaly);
    //    var underSatLocation = CalculateUnderSatLocation(satP2);

    //    //долгота с учетом вращения неправильно выходит
    //    //var exAnomaly2 = CalculateExcentricAnomaly(tperigei, (int)(T));
    //    //var satP1_2 = CalculateSatPoint(exAnomaly2);
    //    //var satP2_2 = CalculateSatPoint2(exAnomaly2);
    //    //var underSatLocation2 = CalculateUnderSatLocation(satP2_2);

    //    //посчитаем с учетом вращения земли
    //    var underSatFinal = new Location()
    //    {
    //        lat = underSatLocation.lat,
    //        lon = underSatLocation.lon
    //    }; //- ((360.986* 0.0174533)/1440) * (Time/60f)};


    //    //еще один дурацкий способ расчета подспутниковой точки
    //    //опять этот старый ужасный способ.. гиблое дело
    //    var cosE0 = (float)(0.5F * e + 0.5F * Math.Cos(omega)) /
    //                (0.5F + 0.5F * e * Math.Cos(omega));
    //    var absSinE0 = Math.Sqrt(1 - cosE0 * cosE0);
    //    var sinE0 = Math.Sin(omega) < 0 ? absSinE0 : absSinE0 * (-1);
    //    var tgE0 = (float)sinE0 / cosE0;
    //    var E0 = Math.Atan(tgE0);
    //    var M0 = E0 - e * (1F / (Math.PI * 2)) * sinE0;
    //    var pzx = Math.Sin(omega) * Math.Sin(i);
    //    var pzy = Math.Cos(omega) * Math.Sin(i);
    //    var S1 = Math.Sin(omega) * Math.Cos(i);
    //    var C = Math.Cos(omega) * Math.Cos(i);
    //    var Rad = a * Math.Sqrt(1 - Math.Pow(e, 2));
    //    var f = 1 / 298.3;
    //    var Cfi = (6376.245 / Math.Pow(10, 5)) /
    //              Math.Sqrt(1 - (2 * f - f * f) * Math.Pow(Math.Sin(fi), 2));
    //    var Sfi = Cfi * Math.Pow(1 - f, 2);
    //    var X = (Cfi + H) * Math.Cos(fi);
    //    var Z = (Sfi + H) * Math.Sin(fi);

    //    var Msr = (float)(Time - t0) / T + M0;
    //    var Ek = E0; //Эксцентрическая аномалия 

    //    for (int j = 0; j < 20; j++)
    //    {
    //        double deltaEk = (0.5 * Msr + 0.5 * (1F / (Math.PI * 2) * e * Math.Sin(Ek) - 0.5 * Ek)) / (0.5 - 0.5 * e * Math.Cos(Ek));
    //        Ek = Ek + deltaEk;
    //    }

    //    var x1 = a * Math.Cos(Ek) - a * e;
    //    var y1 = Rad * Math.Sin(Ek);
    //    var m = 24 * 60 * 60; //а это что?
    //    var delta = (float)(Time - t0) / m + lambda - lambda0;

    //    ////элементы матрицы поворота
    //    var pxx = S1 * Math.Sin(delta) + Math.Cos(omega) * Math.Cos(delta);
    //    var pxy = C * Math.Sin(delta) - Math.Sin(omega) * Math.Cos(delta);
    //    var pyx = S1 * Math.Cos(delta) - Math.Cos(omega) * Math.Sin(delta);
    //    var pyy = C * Math.Cos(delta) + Math.Sin(omega) * Math.Sin(delta);

    //    ////координаты ИСЗ в декартовой системе
    //    var x = pxx * x1 + pxy * y1;
    //    var y = pyx * x1 + pyy * y1;
    //    var z = pzx * x1 + pzy * y1;

    //    var ro = Math.Sqrt(Math.Pow(x - X, 2) + y * y + Math.Pow(z - Z, 2));
    //    var d = 6375.245 * ro; //дальность (расстояние от наблюдателя до ИСЗ)
    //    var ksi = (z - Z) * Math.Cos(fi) - (x - X) * Math.Sin(fi);
    //    var eta = y;
    //    var dzeta = (z - Z) * Math.Sin(fi) + (x - X) * Math.Cos(fi);
    //    var tanAlpha = eta / ksi;
    //    var alpha = Math.Atan(tanAlpha) * 180 / Math.PI; //азимут
    //    var tanBeta = dzeta / Math.Sqrt(ksi * ksi + eta * eta);
    //    var beta = Math.Atan(tanBeta) * 180 / Math.PI; //угол места 
    //                                                   //}
    //    AlphaP = Math.Round(alpha, 3);
    //    BetaP = Math.Round(beta, 3);

    //    Lambda = Time;
    //    Fi = Math.Sqrt(x * x + y * y + z * z);


    //    //var K = Math.PI / 180.0;
    //    //var S2 = Math.Sin(Ek);

    //    //var C1 = Math.Cos(Ek);

    //    //var fak = Math.Sqrt(1.0 - e * e);

    //    //var phi = Math.Atan2(fak * S2, C1 - e) / K;

    //    //var trAnom =  Math.Round(phi * Math.Pow(10, 10)) / Math.Pow(10, 10);


    //    //var u = trAnom + omega; //аргумент широты
    //    //var S = Time - t0; //звездное время от эпохи прохождения начального меридиана через восходящий узел
    //    //var tanLambda = (-Math.Cos(u) * Math.Sin(S) + Math.Cos(i) * Math.Sin(u) * Math.Cos(S)) /
    //    //                (Math.Cos(u) * Math.Cos(S) + Math.Cos(i) * Math.Sin(u) * Math.Sin(S));
    //    //var sinFi = Math.Sin(i) * Math.Sin(u);
    //    //Lambda = Math.Atan(tanLambda) * 180 / Math.PI;
    //    //Fi = Math.Asin(sinFi) * 180 / Math.PI;


    //    #region старое не трогать

    //    //     double G4 = 6.67428E-11;
    //    //     double M4 = 5.972E+24, msatelite4 = 2000;
    //    //     double k4 = G4 * (M4 + msatelite4);
    //    //     double n4 = (2 * Math.PI) / T; //среднее движение

    //    //     //var tperig = tperigei;
    //    //     var tperig = t0; //время прохождения перигея (или восходящего узла?)
    //    //     var tnach = t0 + 1; //начальное время

    //    //     double M04 = -n4 / (tperig - tnach); //средняя аномалия
    //    //     //double M04 = -n4 / (tperig - tnach); //средняя аномалия
    //    //     double meanAnomaly = n4 * (Time - tnach) + M04;
    //    //     //double meanAnomaly23 = n4 * (Time - tnach) + meanAnomaly0;

    //    //     double excentricAnomaly = meanAnomaly + e*Math.Sin(meanAnomaly)/(1 - e*Math.Cos(meanAnomaly));

    //    //     for (int j = 0; j < 20; j++)
    //    //     {
    //    //         double deltaE = (meanAnomaly - excentricAnomaly + e*Math.Sin(excentricAnomaly))/
    //    //                          (1 - e*Math.Cos(excentricAnomaly));
    //    //         excentricAnomaly = excentricAnomaly + deltaE;
    //    //     }

    //    //     double sinV = (Math.Sqrt(1 - e*e)*Math.Sin(excentricAnomaly))/(1 - e*Math.Cos(excentricAnomaly));
    //    //     double cosV = (Math.Cos(excentricAnomaly) - e)/(1 - e*Math.Cos(excentricAnomaly));
    //    //     double r4_1 = (a*(1 - e*e))/(1 + e*cosV);
    //    //     double r4_2 = a*(1 - e*Math.Cos(excentricAnomaly)); //r4_2 должно быть = r4_1

    //    //     double sinU = Math.Sin(omega)*cosV + Math.Cos(omega)*sinV;
    //    //     double cosU = Math.Cos(omega)*cosV - Math.Sin(omega)*sinV;


    //    //     //это вроде бы верно - координаты исз
    //    //     //double x4 = r4_2*(cosU*Math.Cos(lambda0) - sinU*Math.Sin(lambda0)*Math.Cos(i));
    //    //     //double y4 = r4_2*(cosU*Math.Sin(lambda0) + sinU*Math.Cos(lambda0)*Math.Cos(i));
    //    //     //double z4 = r4_2*sinU*Math.Sin(i);

    //    //     //var orbith4 = Math.Sqrt(x4 * x4 + y4 * y4 + z4 * z4) - 6366.245; //высота спутника над землей // это не совсем высота, не учтено что перпендикуляр
    //    //     //к геоиду не совпадает с радиус вектором

    //    //     //еще один способ расчета координат исз
    //    //     double r5 = a*(1 - e*Math.Cos(excentricAnomaly));
    //    //     double zita = a*(Math.Cos(excentricAnomaly) - e);
    //    //     double nu = a*Math.Sqrt(1 - e*e)*Math.Sin(excentricAnomaly);
    //    //     double px = Math.Cos(omega)*Math.Cos(lambda0) - Math.Sin(omega)*Math.Sin(lambda0)*Math.Cos(i);
    //    //     double py = Math.Cos(omega)*Math.Sin(lambda0) + Math.Sin(omega)*Math.Cos(lambda0)*Math.Cos(i);
    //    //     double pz = Math.Sin(omega)*Math.Sin(i);
    //    //     double qx = -Math.Sin(omega)*Math.Cos(lambda0) - Math.Cos(omega)*Math.Sin(lambda0)*Math.Cos(i);
    //    //     double qy = -Math.Sin(omega)*Math.Sin(lambda0) + Math.Cos(omega)*Math.Cos(lambda0)*Math.Cos(i);
    //    //     double qz = Math.Cos(omega)*Math.Sin(i);
    //    //     double ravno1 = px*px + py*py + pz*pz;
    //    //     double ravno12 = qx*qx + qy*qy + qz*qz;
    //    //     double ravno0 = px*qx + py*qy + pz*qz;
    //    //     double x5 = px*zita + qx*nu;
    //    //     double y5 = py*zita + qy*nu;
    //    //     double z5 = pz*zita + qz*nu;

    //    //     //примерная высота спутника над землей
    //    //     var orbith5 = Math.Sqrt(x5 * x5 + y5 * y5 + z5 * z5) - 6366.245;


    //    //     //координаты наблюдателя (это вроде бы правильно) но нафиг не нужно
    //    //     var Re = 6378.245;
    //    //     var Rp = 6356.853;
    //    //     var R0 = (Re * Rp) / (Math.Cos(fi) * Math.Sqrt(Rp * Rp + Math.Tan(fi) * Math.Tan(fi) * Re * Re));
    //    //     var X1 = R0 * Math.Sin(fi) * Math.Cos(lambda);
    //    //     var Y1 = R0 * Math.Sin(fi) * Math.Sin(lambda);
    //    //     var Z1 = R0 * Math.Cos(fi);


    //    //     //прямоугольные координаты спутника в сферические  

    //    //     //как-то все это неправильно вроде
    //    //     //double ro4 = Math.Sqrt(x4*x4 + y4*y4 + z4*z4);
    //    //     //double cosdolgota = x4 / Math.Sqrt(x4 * x4 + y4 * y4);
    //    //     //var sindolgota = y4 / Math.Sqrt(x4 * x4 + y4 * y4);//для проверки
    //    //     //double dolgota = Math.Asin(sindolgota); //lon
    //    //     //double shirota = Math.Acos(z4/Math.Sqrt(x4*x4 + y4*y4 + z4*z4)); //lat
    //    //     //double latit = Math.Atan(z4 / ro4) * 180 / Math.PI;

    //    //     double longit = Math.Atan2(y5, x5);  //longit = lon2 = lon3
    //    //     double lon2 = 2 * Math.Atan(y5 / (x5 + Math.Sqrt(x5 * x5 + y5 * y5)));
    //    //     double lon3 = y5 >= 0
    //    //         ? (Math.PI / 2 - 2 * Math.Atan(x5 / (Math.Sqrt(x5 * x5 + y5 * y5) + y5)))
    //    //         : (-Math.PI / 2 + 2 * Math.Atan(x5 / (Math.Sqrt(x5 * x5 + y5 * y5) - y5)));
    //    //     //а вот не все так просто, земля то крутится! причем так, что по долготе спутник проходит в 2 раза меньше
    //    //     var deltalongit = longit*(T/(24f*3600));
    //    ////     longit -= deltalongit;


    //    //     //а теперь посчитаем широту, это не так просто
    //    //     double b = a * Math.Sqrt(1 - e * e);
    //    //     double tanb = z5 / Math.Sqrt(x5 * x5 + y5 * y5);
    //    //     double B = Math.Atan(tanb);
    //    //     double N =  Math.Pow(a * a * (a * a * Math.Cos(B) * Math.Cos(B) + b * b * Math.Sin(B) * Math.Sin(B)), -1 / 2f);
    //    //     double H4 = (Math.Sqrt(x5 * x5 + y5 * y5) / Math.Cos(B)) - N;

    //    //     for (int i4 = 0; i4 < 5; i4++) //сходится за пару итераций
    //    //     {
    //    //         tanb = z5 / Math.Sqrt(x5 * x5 + y5 * y5) + (e * e * N) / (N + H4);
    //    //         B = Math.Atan(tanb);
    //    //         N = Math.Pow(a * a * (a * a * Math.Cos(B) * Math.Cos(B) + b * b * Math.Sin(B) * Math.Sin(B)), -1 / 2f);
    //    //         H4 = (Math.Sqrt(x5 * x5 + y5 * y5) / Math.Cos(B)) - N;
    //    //     }
    //    //     //этот способ кажется наконец то правильно посчитал
    //    #endregion

    //    //высота спутника над землей
    //    double rad;
    //    Point underSat = LocationToPoint(
    //        new Location() { lat = underSatLocation.lat, lon = underSatLocation.lon, elv = 0 }, true, out rad);
    //    var SatElv =
    //        Math.Sqrt((satP2.x - underSat.x / 1000f) * (satP2.x - underSat.x / 1000f) +
    //                  (satP2.y - underSat.y / 1000f) * (satP2.y - underSat.y / 1000f) +
    //                  (satP2.z - underSat.z / 1000f) * (satP2.z - underSat.z / 1000f));

    //    //ну а теперь самое веселое, считаем азимут
    //    double azimuth, altitude;
    //    CalculateAz(new Location() { lat = fi, lon = lambda, elv = H },
    //        new Location() { lat = underSatFinal.lat, lon = underSatFinal.lon, elv = SatElv * 1000 }, true, out azimuth, out altitude);

    //    ExcAn = exAnomaly;
    //    //High = orbith5;
    //    Az = azimuth;
    //    Ym = altitude;
    //    SatP.x = satP2.x;
    //    SatP.y = satP2.y;
    //    SatP.z = satP2.z;
    //    SatL.lat = underSatFinal.lat * 180 / Math.PI;
    //    SatL.lon = underSatFinal.lon * 180 / Math.PI;
    //    SatL.elv = SatElv;
    //}

    //public static double ExcAn;
    //public static double High;
    //public static double Az;
    //public static double Ym;
    //public static Point SatP;
    //public static Location SatL;

    //public static double EarthRadiusInMeters(double latitudeRadians) // latitude is geodetic, i.e. that reported by GPS
    //{
    //    var a = 6378137.0;  // equatorial radius in meters
    //    var b = 6356752.3;  // polar radius in meters
    //    var cos = Math.Cos(latitudeRadians);
    //    var sin = Math.Sin(latitudeRadians);
    //    var t1 = a * a * cos;
    //    var t2 = b * b * sin;
    //    var t3 = a * cos;
    //    var t4 = b * sin;
    //    return Math.Sqrt((t1 * t1 + t2 * t2) / (t3 * t3 + t4 * t4));
    //}

    //public static double GeocentricLatitude(double lat)
    //{
    //    // Convert geodetic latitude 'lat' to a geocentric latitude 'clat'.
    //    // Geodetic latitude is the latitude as given by GPS.
    //    // Geocentric latitude is the angle measured from center of Earth between a point and the equator.
    //    var e2 = 0.00669437999014;
    //    var clat = Math.Atan((1.0 - e2) * Math.Tan(lat));
    //    return clat;
    //}

    //public static void LocationToPoint(Location l, bool oblate, out Point p)
    //{
    //    // Convert (lat, lon, elv) to (x, y, z).  lat,lon - in rad
    //    p.radius = oblate ? EarthRadiusInMeters(l.lat) : 6371009;
    //    var clat = oblate ? GeocentricLatitude(l.lat) : l.lat;

    //    var cosLon = Math.Cos(l.lon);
    //    var sinLon = Math.Sin(l.lon);
    //    var cosLat = Math.Cos(clat);
    //    var sinLat = Math.Sin(clat);
    //    p.x = p.radius * cosLon * cosLat;
    //    p.y = p.radius * sinLon * cosLat;
    //    p.z = p.radius * sinLat;

    //    // We used geocentric latitude to calculate (x,y,z) on the Earth's ellipsoid.
    //    // Now we use geodetic latitude to calculate normal vector from the surface, to correct for elevation.
    //    var cosGlat = Math.Cos(l.lat);
    //    var sinGlat = Math.Sin(l.lat);

    //    p.nx = cosGlat * cosLon;
    //    p.ny = cosGlat * sinLon;
    //    p.nz = sinGlat;

    //    p.x += l.elv * p.nx;
    //    p.y += l.elv * p.ny;
    //    p.z += l.elv * p.nz;
    //}

    //public static Point LocationToPoint(Location l, bool oblate, out double radius)
    //{
    //    // Convert (lat, lon, elv) to (x, y, z).  lat,lon - in rad
    //    radius = oblate ? EarthRadiusInMeters(l.lat) : 6371009;
    //    var clat = oblate ? GeocentricLatitude(l.lat) : l.lat;

    //    var cosLon = Math.Cos(l.lon);
    //    var sinLon = Math.Sin(l.lon);
    //    var cosLat = Math.Cos(clat);
    //    var sinLat = Math.Sin(clat);

    //    Point p = new Point();
    //    p.x = radius * cosLon * cosLat;
    //    p.y = radius * sinLon * cosLat;
    //    p.z = radius * sinLat;

    //    // We used geocentric latitude to calculate (x,y,z) on the Earth's ellipsoid.
    //    // Now we use geodetic latitude to calculate normal vector from the surface, to correct for elevation.
    //    var cosGlat = Math.Cos(l.lat);
    //    var sinGlat = Math.Sin(l.lat);

    //    var nx = cosGlat * cosLon;
    //    var ny = cosGlat * sinLon;
    //    var nz = sinGlat;

    //    p.x += l.elv * nx;
    //    p.y += l.elv * ny;
    //    p.z += l.elv * nz;

    //    return p;
    //}

    //public static void RotateGlobe(Location b, Location a, double bradius, double aradius, bool oblate, out Point p)
    //{
    //    // Get modified coordinates of 'b' by rotating the globe so that 'a' is at lat=0, lon=0.
    //    Location br = new Location() { lat = b.lat, lon = b.lon - a.lon, elv = b.elv };
    //    Point brp;
    //    LocationToPoint(br, oblate, out brp);

    //    // Rotate brp cartesian coordinates around the z-axis by a.lon degrees,
    //    // then around the y-axis by a.lat degrees.
    //    // Though we are decreasing by a.lat degrees, as seen above the y-axis,
    //    // this is a positive (counterclockwise) rotation (if B's longitude is east of A's).
    //    // However, from this point of view the x-axis is pointing left.
    //    // So we will look the other way making the x-axis pointing right, the z-axis
    //    // pointing up, and the rotation treated as negative.

    //    var alat = -a.lat;
    //    if (oblate)
    //    {
    //        alat = GeocentricLatitude(alat);
    //    }
    //    var acos = Math.Cos(alat);
    //    var asin = Math.Sin(alat);

    //    var bx = (brp.x * acos) - (brp.z * asin);
    //    var by = brp.y;
    //    var bz = (brp.x * asin) + (brp.z * acos);

    //    p = new Point
    //    {
    //        x = bx,
    //        y = @by,
    //        z = bz,
    //        radius = bradius
    //    };
    //}

    //public static double Distance(Point ap, Point bp)
    //{
    //    var dx = ap.x - bp.x;
    //    var dy = ap.y - bp.y;
    //    var dz = ap.z - bp.z;
    //    return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    //}

    //public static void NormalizeVectorDiff(Point b, Point a, out Point p)
    //{
    //    // Calculate norm(b-a), where norm divides a vector by its length to produce a unit vector.
    //    var dx = b.x - a.x;
    //    var dy = b.y - a.y;
    //    var dz = b.z - a.z;
    //    var dist2 = dx * dx + dy * dy + dz * dz;
    //    if (dist2 == 0)
    //    {
    //        throw new System.ArgumentException("Distanse can not be 0");
    //    }
    //    var dist = Math.Sqrt(dist2);
    //    p = new Point
    //    {
    //        x = dx / dist,
    //        y = dy / dist,
    //        z = dz / dist,
    //        radius = 1.0d
    //    };
    //}

    //public static void CalculateAz(Location a, Location b, bool oblate, out double azimuth, out double altitude)
    //{
    //    double bradius;
    //    Point ap = new Point();
    //    LocationToPoint(a, oblate, out ap);
    //    var bp = LocationToPoint(b, oblate, out bradius);
    //    var distKm = 0.001 * Distance(ap, bp); //в км

    //    // Let's use a trick to calculate azimuth:
    //    // Rotate the globe so that point A looks like latitude 0, longitude 0.
    //    // We keep the actual radii calculated based on the oblate geoid,
    //    // but use angles based on subtraction.
    //    // Point A will be at x=radius, y=0, z=0.
    //    // Vector difference B-A will have dz = N/S component, dy = E/W component.    
    //    Point br = new Point();
    //    double brradius;
    //    RotateGlobe(b, a, bradius, ap.radius, oblate, out br);
    //    azimuth = 0;
    //    if (br.z * br.z + br.y * br.y > 1.0e-6)
    //    {
    //        var theta = Math.Atan2(br.z, br.y) * 180.0 / Math.PI; //в градусах!
    //        azimuth = 90.0 - theta;
    //        if (azimuth < 0.0)
    //        {
    //            azimuth += 360.0;
    //        }
    //        if (azimuth > 360.0)
    //        {
    //            azimuth -= 360.0;
    //        }
    //    }

    //    Point bma = new Point();
    //    NormalizeVectorDiff(bp, ap, out bma);
    //    // Calculate altitude, which is the angle above the horizon of B as seen from A.
    //    // Almost always, B will actually be below the horizon, so the altitude will be negative.
    //    // The dot product of bma and norm = cos(zenith_angle), and zenith_angle = (90 deg) - altitude.
    //    // So altitude = 90 - acos(dotprod).
    //    altitude = 90.0 - (180.0 / Math.PI) * Math.Acos(bma.x * ap.nx + bma.y * ap.ny + bma.z * ap.nz);
    //}


    //public struct Location
    //{
    //    public double lat;
    //    public double lon;
    //    public double elv;
    //}

    //public struct Point
    //{
    //    public double x;
    //    public double y;
    //    public double z;
    //    public double radius;
    //    public double nx;
    //    public double ny;
    //    public double nz;
    //}

    //public struct Statistic
    //{
    //    private string time;

    //    public string Time
    //    {
    //        get { return time; }
    //        set
    //        {
    //            int t = int.Parse(value);
    //            string h, m, s;
    //            h = (t / 3600).ToString();
    //            m = (t / 60 % 60).ToString();
    //            s = (t % 60).ToString();
    //            time = h + ":" + m + ":" + s;
    //        }
    //    }
    //    public double Azim { get; set; }
    //    public double Ymesta { get; set; }
    //    public double Longitude { get; set; }
    //    public double Latitude { get; set; }
    //}

    #endregion

}