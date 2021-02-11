using System;
using System.Linq;
using System.Windows.Forms;
using R440O.СостоянияЭлементов.Контур_П;
using R440O.ThirdParty;

namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        public static bool ЗвуковаяСигнализация { get; set; }

        #region Лампочки
        public static bool ЛампочкаКП5Прием = false;

        public static bool ЛампочкаСбойПодписи
        {
            get
            {
                return ЛампочкаСеть && (КнопкаПодпись1 || КнопкаПодпись2 || КнопкаПодпись3);
            }
        }

        public static bool ЛампочкаНеиспр
        {
            get
            {
                return ЛампочкаСеть && (КнопкаПодпись1 || КнопкаПодпись2 || КнопкаПодпись3);
            }
        }

        private static bool _КП4Контроль;
        public static bool КП4Контроль { get { return _КП4Контроль; } set { _КП4Контроль = value; Refresh(); } }
        private static bool _КП1Контроль;
        public static bool КП1Контроль { get { return _КП1Контроль; } set { _КП1Контроль = value; Refresh(); } }
        public static bool ЛампочкаКонтроль
        {
            get
            {
                return ЛампочкаСеть && (((КнопкаКП3Канал11 || КнопкаКП3Канал12 || КнопкаКП3Канал10) && ТумблерМткПУ == EТумблерМткПУ.ПУ
                    && (ЗначениеАдресК == ЗначениеПодпись1
                        || ЗначениеАдресК == ЗначениеПодпись2
                        || ЗначениеАдресК == ЗначениеПодпись3) && КП3) || КнопкаКП1Контроль || КнопкаКП4Контроль || КП4Контроль || КП1Контроль);
            }
        }

        private static bool _ЛампочкаПередача;
        public static bool ЛампочкаПередача
        {
            get { return ЛампочкаСеть && (_ЛампочкаПередача || ЛампочкаКП3Канал10 || ЛампочкаКП3Канал11 || ЛампочкаКП3Канал12); }
        }
        public static bool ЛампочкаОтбой = false;

        public static bool ЛампочкаИнформПринята { get; set; }

        private static bool ИнформацияПринята = false;
        public static bool ЛампочкаПрием
        {
            get
            {
                return ЛампочкаСеть && ИнформацияПринята && КнопкаНаборКК;
            }
        }
        #endregion

        #region Тумблеры
        private static EТумблерМткПУ _ТумблерМткПУ = EТумблерМткПУ.ПУ;
        public static EТумблерМткПУ ТумблерМткПУ
        {
            get { return _ТумблерМткПУ; }
            set
            {
                _ТумблерМткПУ = value;
                КнопкаКП4Контроль = false;
                КнопкаКП3Канал10 = false;
                КнопкаКП3Канал11 = false;
                КнопкаКП3Канал12 = false;
                Refresh();
            }
        }
        #endregion

        #region Кнопки
        private static bool _КнопкаАдресУСС;
        public static bool КнопкаАдресУСС
        {
            get { return _КнопкаАдресУСС; }
            set
            {
                _КнопкаАдресУСС = value;
                Refresh();
            }
        }

        private static bool _КнопкаАдресК;
        public static bool КнопкаАдресК
        {
            get { return _КнопкаАдресК; }
            set
            {
                _КнопкаАдресК = value;
                Refresh();
            }
        }

        private static bool _КнопкаПодпись1;
        public static bool КнопкаПодпись1
        {
            get { return _КнопкаПодпись1; }
            set
            {
                _КнопкаПодпись1 = value;
                Refresh();
            }
        }

        private static bool _КнопкаПодпись2;
        public static bool КнопкаПодпись2
        {
            get { return _КнопкаПодпись2; }
            set
            {
                _КнопкаПодпись2 = value;
                Refresh();
            }
        }

        private static bool _КнопкаПодпись3;
        public static bool КнопкаПодпись3
        {
            get { return _КнопкаПодпись3; }
            set
            {
                _КнопкаПодпись3 = value;
                Refresh();
            }
        }
        private static IDisposable timer_Мигание = null;
        private static IDisposable timer_МиганиеКП1 = null;
        private static IDisposable timer_ЛампочкаПередача = null;
        private static bool Мигание;
        private static EПереключательПриоритет НомерКанала;
        private static bool ЗначениеКнопкиКП4Контроль;
        public static bool КнопкаВызов
        {
            set
            {
                if (timer_ЛампочкаПередача != null)
                    timer_ЛампочкаПередача.Dispose();
                timer_ЛампочкаПередача = EasyTimer.SetTimeout(() =>
                {
                    ОчищениеТаблоНаКП2();
                    if ((ЗначениеАдресК == ЗначениеПодпись1
                        || ЗначениеАдресК == ЗначениеПодпись2
                        || ЗначениеАдресК == ЗначениеПодпись3) && ТумблерМткПУ == EТумблерМткПУ.МТК)
                    {
                        if (КнопкаКП4Контроль)
                        {
                            if (timer_Мигание != null)
                            {
                                timer_Мигание.Dispose();
                                timer_Мигание = null;
                            }
                            if (timer_МиганиеКП1 != null)
                            {
                                timer_МиганиеКП1.Dispose();
                                timer_МиганиеКП1 = null;
                            }
                            timer_Мигание = EasyTimer.SetInterval(() =>
                            {
                                Мигание = !Мигание;
                                Refresh();
                            }, 300);
                            НомерКанала = ПереключательПриоритет;
                            ЗначениеКнопкиКП4Контроль = (КнопкаКП4Контроль) ? true : false;
                            ЗначениеКнопкиКП1Контроль = false;
                            ИнформацияПринята = true;
                            КнопкаНаборКК = false;
                            _ЗанятоКП4 = false;
                            ЗанятоКП4 = false;
                        }
                        else
                            if (КнопкаКП1Контроль)
                            {
                                if (timer_Мигание != null)
                                {
                                    timer_Мигание.Dispose();
                                    timer_Мигание = null;
                                }
                                if (timer_МиганиеКП1 != null)
                                {
                                    timer_МиганиеКП1.Dispose();
                                    timer_МиганиеКП1 = null;
                                }
                                timer_МиганиеКП1 = EasyTimer.SetInterval(() =>
                                {
                                    ЛампочкаКП1Канал11 = !ЛампочкаКП1Канал11;
                                    Refresh();
                                }, 300);
                                ИнформацияПринята = true;
                                ЗначениеКнопкиКП1Контроль = (КнопкаКП1Контроль) ? true : false;
                                ЗначениеКнопкиКП4Контроль = false;
                                КнопкаНаборКК = false;
                                _ЗанятоКП4 = false;
                                ЗанятоКП4 = false;
                            }
                            else
                            {
                                ЗначениеКнопкиКП4Контроль = false;
                                ЗначениеКнопкиКП1Контроль = false;
                                ИнформацияПринята = false;
                                if (timer_Мигание != null)
                                {
                                    timer_Мигание.Dispose();
                                    timer_Мигание = null;
                                }
                                if (timer_МиганиеКП1 != null)
                                {
                                    timer_МиганиеКП1.Dispose();
                                    timer_МиганиеКП1 = null;
                                }
                                if (timer_ЛампочкаПередача != null)
                                    timer_ЛампочкаПередача.Dispose();
                                _ЗанятоКП4 = false;
                                ЗанятоКП4 = false;
                            }
                    }
                    else
                    {
                        ЗначениеКнопкиКП4Контроль = false;
                        ЗначениеКнопкиКП1Контроль = false;
                        ИнформацияПринята = false;
                        if (timer_Мигание != null)
                        {
                            timer_Мигание.Dispose();
                            timer_Мигание = null;
                        }
                        if (timer_МиганиеКП1 != null)
                        {
                            timer_МиганиеКП1.Dispose();
                            timer_МиганиеКП1 = null;
                        }
                        if (timer_ЛампочкаПередача != null)
                            timer_ЛампочкаПередача.Dispose();

                    }
                    ЛампочкаКП1Канал11 = false;
                    КП3 = false;
                    ОчищениеТаблоНаКП2();
                    _ЛампочкаПередача = false;
                    ЛампочкаИнформПринята = false;
                    Refresh();
                }, 6000);
                _ЛампочкаПередача = true;
                Refresh();
            }
        }

        public static bool КнопкаОтбой { get; set; }
        public static bool КнопкаИнформ
        {
            set
            {
                НомерКанала = ПереключательПриоритет;
                ОчищениеТаблоНаКП2();
                if (timer_ЛампочкаПередача != null)
                    timer_ЛампочкаПередача.Dispose();
                if ((ЗначениеАдресК == ЗначениеПодпись1
                        || ЗначениеАдресК == ЗначениеПодпись2
                        || ЗначениеАдресК == ЗначениеПодпись3) && ТумблерМткПУ == EТумблерМткПУ.МТК)
                {
                    if (КнопкаКП4Контроль)
                        if (КнопкаКонтрольЗанятости)
                        {
                            if (timer_Мигание != null)
                            {
                                timer_Мигание.Dispose();
                                timer_Мигание = null;
                            }
                            timer_Мигание = EasyTimer.SetInterval(() =>
                            {
                                ЗанятоКП4 = !ЗанятоКП4;
                                ЗанятоИГорит = ЗанятоКП4;
                                Refresh();
                            }, 300);
                        }
                }
                timer_ЛампочкаПередача = EasyTimer.SetTimeout(() =>
                {
                    if ((ЗначениеАдресК == ЗначениеПодпись1
                        || ЗначениеАдресК == ЗначениеПодпись2
                        || ЗначениеАдресК == ЗначениеПодпись3) && ТумблерМткПУ == EТумблерМткПУ.МТК)
                    {
                        if (КнопкаКП4Контроль)
                        {
                            if (КнопкаКонтрольЗанятости)
                            {
                                ЗначениеКнопкиКП4Контроль = false;
                                ЗначениеКнопкиКП1Контроль = false;
                                ИнформацияПринята = false;
                                if (timer_Мигание != null)
                                {
                                    timer_Мигание.Dispose();
                                    timer_Мигание = null;
                                }
                                if (timer_МиганиеКП1 != null)
                                {
                                    timer_МиганиеКП1.Dispose();
                                    timer_МиганиеКП1 = null;
                                }
                                if (timer_ЛампочкаПередача != null)
                                    timer_ЛампочкаПередача.Dispose();
                                _ЗанятоКП4 = true;
                                ЗанятоИГорит = false;
                            }
                            else
                            {
                                if (timer_Мигание != null)
                                {
                                    timer_Мигание.Dispose();
                                    timer_Мигание = null;
                                }
                                if (timer_МиганиеКП1 != null)
                                {
                                    timer_МиганиеКП1.Dispose();
                                    timer_МиганиеКП1 = null;
                                }
                                timer_Мигание = EasyTimer.SetInterval(() =>
                                {
                                    Мигание = !Мигание;
                                    Refresh();
                                }, 300);
                                НомерКанала = ПереключательПриоритет;
                                ЗначениеКнопкиКП4Контроль = (КнопкаКП4Контроль) ? true : false;
                                ЗначениеКнопкиКП1Контроль = false;
                                ИнформацияПринята = true;
                                КнопкаНаборКК = false;
                                _ЗанятоКП4 = false;
                                ЗанятоКП4 = false;
                            }
                        }
                        else
                            if (КнопкаКП1Контроль)
                            {
                                if (timer_Мигание != null)
                                {
                                    timer_Мигание.Dispose();
                                    timer_Мигание = null;
                                }
                                if (timer_МиганиеКП1 != null)
                                {
                                    timer_МиганиеКП1.Dispose();
                                    timer_МиганиеКП1 = null;
                                }
                                timer_МиганиеКП1 = EasyTimer.SetInterval(() =>
                                {
                                    ЛампочкаКП1Канал11 = !ЛампочкаКП1Канал11;
                                    Refresh();
                                }, 300);
                                ИнформацияПринята = true;
                                ЗначениеКнопкиКП1Контроль = (КнопкаКП1Контроль) ? true : false;
                                ЗначениеКнопкиКП4Контроль = false;
                                КнопкаНаборКК = false;
                                _ЗанятоКП4 = false;
                                ЗанятоКП4 = false;
                            }
                            else
                            {
                                ЗначениеКнопкиКП4Контроль = false;
                                ЗначениеКнопкиКП1Контроль = false;
                                ИнформацияПринята = false;
                                if (timer_Мигание != null)
                                {
                                    timer_Мигание.Dispose();
                                    timer_Мигание = null;
                                }
                                if (timer_МиганиеКП1 != null)
                                {
                                    timer_МиганиеКП1.Dispose();
                                    timer_МиганиеКП1 = null;
                                }
                                if (timer_ЛампочкаПередача != null)
                                    timer_ЛампочкаПередача.Dispose();
                                _ЗанятоКП4 = false;
                                ЗанятоКП4 = false;
                            }
                    }
                    else
                    {
                        ЗначениеКнопкиКП4Контроль = false;
                        ЗначениеКнопкиКП1Контроль = false;
                        ИнформацияПринята = false;
                        if (timer_Мигание != null)
                        {
                            timer_Мигание.Dispose();
                            timer_Мигание = null;
                        }
                        if (timer_МиганиеКП1 != null)
                        {
                            timer_МиганиеКП1.Dispose();
                            timer_МиганиеКП1 = null;
                        }
                        if (timer_ЛампочкаПередача != null)
                            timer_ЛампочкаПередача.Dispose();
                    }
                    ЛампочкаКП1Канал11 = false;
                    КП3 = false;
                    ОчищениеТаблоНаКП2();
                    _ЛампочкаПередача = false;
                    ЛампочкаИнформПринята = false;
                    Refresh();
                }, 6000);
                _ЛампочкаПередача = true;
                Refresh();
            }
        }

        private static bool _КнопкаНаборКК;
        public static bool КнопкаНаборКК
        {
            get { return _КнопкаНаборКК; }
            set
            {
                КнопкаНаборККНажата = true;
                КнопкаНаборККОтжата = true;
                _КнопкаНаборКК = value;
                Refresh();
            }
        }

        private static bool ЗанятоИГорит;
        private static bool _ЗанятоКП4;
        private static bool ЗанятоКП4;
        private static bool _КнопкаКонтрольЗанятости;
        public static bool КнопкаКонтрольЗанятости
        {
            get { return _КнопкаКонтрольЗанятости; }
            set
            {
                _КнопкаКонтрольЗанятости = value;                
                if (!_КнопкаКонтрольЗанятости && _ЗанятоКП4)
                {                   
                        timer_Мигание = EasyTimer.SetInterval(() =>
                        {
                            ЗанятоКП4 = !ЗанятоКП4;
                            ЗанятоИГорит = ЗанятоКП4;
                            Refresh();
                        }, 300);                        
                }
                else
                    if (_КнопкаКонтрольЗанятости && _ЗанятоКП4)
                    {
                        if (timer_Мигание != null)
                        {
                            timer_Мигание.Dispose();
                            timer_Мигание = null;
                        }
                    }
                ЗанятоКП4 = !_КнопкаКонтрольЗанятости && _ЗанятоКП4;
                Refresh();
            }
        }
        public static bool КнопкаИнформКОН { get; set; }
        public static bool КнопкаИнформС { get; set; }
        #endregion

        #region Значения групп, адресов, информации
        private static string ЗначениеАдресК = "000";
        private static string ЗначениеПодпись1 = "000";
        private static string ЗначениеПодпись2 = "000";
        private static string ЗначениеПодпись3 = "000";

        private static int ИндексГруппы = -1;
        private static string ЗначениеИндексГруппы = "0";
        private static string[] ЗначениеГруппа = { "000", "000", "000", "000", "000", "000", "000", "000", "^00" };

        private static string ЗначениеИнформация = "";
        #endregion

        #region Табло
        private static string _ТаблоАдрес1 = "";
        public static string ТаблоАдрес1
        {
            get
            {
                return _ТаблоАдрес1;
            }
        }

        private static string _ТаблоАдрес2 = "";
        public static string ТаблоАдрес2
        {
            get
            {
                return _ТаблоАдрес2;
            }
        }

        private static string _ТаблоГруппа = "";
        public static string ТаблоГруппа
        {
            get
            {
                return _ТаблоГруппа;
            }
        }

        private static string _ТаблоИнформация = "";
        public static string ТаблоИнформация
        {
            get
            {
                return _ТаблоИнформация;
            }
        }
        #endregion

        public static void НажатаКнопка(int number)
        {
            if (ЛампочкаСеть)
            {
                if (_КнопкаАдресК || _КнопкаПодпись1 || _КнопкаПодпись2 || _КнопкаПодпись3)
                {
                    if (_КнопкаАдресК)
                    {
                        ДобавитьЧислоВПоследнийРегистр(number, ref ЗначениеАдресК);
                        _ТаблоАдрес2 = ЗначениеАдресК;
                    }
                    if (_КнопкаПодпись1)
                    {
                        ДобавитьЧислоВПоследнийРегистр(number, ref ЗначениеПодпись1);
                        _ТаблоАдрес2 = ЗначениеПодпись1;
                    }
                    if (_КнопкаПодпись2)
                    {
                        ДобавитьЧислоВПоследнийРегистр(number, ref ЗначениеПодпись2);
                        _ТаблоАдрес2 = ЗначениеПодпись2;
                    }
                    if (_КнопкаПодпись3)
                    {
                        ДобавитьЧислоВПоследнийРегистр(number, ref ЗначениеПодпись3);
                        _ТаблоАдрес2 = ЗначениеПодпись3;
                    }
                }
                else
                {
                    if (ИндексГруппы > -1 && ИндексГруппы < 8 && ЗначениеГруппа[ИндексГруппы] != "^00")
                    {
                        ДобавитьЧислоВПоследнийРегистр(number, ref ЗначениеГруппа[ИндексГруппы]);
                        ЗначениеИнформация = ЗначениеГруппа[ИндексГруппы];
                        _ТаблоИнформация = ЗначениеИнформация;
                    }
                }
            }
            Refresh();
        }

        public static void НажатаКнопкаКонец()
        {
            if (ЛампочкаСеть)
            {
                if (!(_КнопкаАдресК || _КнопкаПодпись1 || _КнопкаПодпись2 || _КнопкаПодпись3) && ИндексГруппы != -1)
                {
                    ЗначениеГруппа[ИндексГруппы] = "^00";
                    ЗначениеИнформация = ЗначениеГруппа[ИндексГруппы];
                    ИндексГруппы = -1;
                    Refresh();
                }
            }
        }

        public static void ПоменятьГруппу()
        {
            if (ЛампочкаСеть)
            {
                if (!(_КнопкаАдресК || _КнопкаПодпись1 || _КнопкаПодпись2 || _КнопкаПодпись3))
                {
                    ИндексГруппы++;
                    if (ИндексГруппы > 0)
                    {
                        if (ЗначениеГруппа[ИндексГруппы - 1] == "^00")
                            ИндексГруппы = 0;
                        else
                            if (ИндексГруппы > 8)
                                ИндексГруппы = 0;
                    }
                    ЗначениеИндексГруппы = Convert.ToString(ИндексГруппы + 1);
                    ЗначениеИнформация = ЗначениеГруппа[ИндексГруппы];
                    Refresh();
                }
            }
        }


        private static void ДобавитьЧислоВПоследнийРегистр(int number, ref string str)
        {
            str = Convert.ToString(str[1]) + Convert.ToString(str[2]) + Convert.ToString(number);
        }

        public static void СбросОбщий()
        {
            ЗначениеИндексГруппы = "0";
            ИндексГруппы = -1;

            ЗначениеИнформация = "";
            ЗначениеГруппа = new string[] { "000", "000", "000", "000", "000", "000", "000", "000", "^00" };

            ЗначениеКнопкиКП4Контроль = false;
            КнопкаКП4Контроль = false;
            Мигание = false;
            ЛампочкаКП1Канал11 = false;
            if (timer_Мигание != null)
            {
                timer_Мигание.Dispose();
                timer_Мигание = null;
            }
            if (timer_ЛампочкаПередача != null)
                timer_ЛампочкаПередача.Dispose();
            if (timer_МиганиеКП1 != null)
            {
                timer_МиганиеКП1.Dispose();
                timer_МиганиеКП1 = null;
            }
            _ЛампочкаПередача = false;
            ИнформацияПринята = false;
            КнопкаНаборКК = false;
            КнопкаКП3Канал10 = false;
            КнопкаКП3Канал11 = false;
            ЗначениеКнопкиКП1Контроль = false;
            ЛампочкаКП1Канал11 = false;
            КнопкаКП3Канал12 = false;
            КП3 = false;
            ЛампочкаИнформПринята = false;
            if (timer_ЛампочкаКП2Прием != null)
                timer_ЛампочкаКП2Прием.Dispose();
            _ЛампочкаКП2Прием = false;
            ОчищениеТаблоНаКП2();
            _ЗанятоКП4 = false;
            ЗанятоКП4 = false;
            ЗанятоИГорит = false;
            Refresh();
        }
    }
}
