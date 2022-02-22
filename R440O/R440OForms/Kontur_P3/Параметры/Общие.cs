﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R440O.R440OForms.Kontur_P3.Параметры
{
    partial class Kontur_P3Parameters
    {
        private static Kontur_P3Parameters instance;
        public static Kontur_P3Parameters getInstance()
        {
            if (instance == null)
                instance = new Kontur_P3Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        public void ResetToDefaultsWhenTurnOnOff()
        {
            _ТаблоГруппа = ЛампочкаСеть ? "0" : "";
            СбросОбщий();
            if (ЛампочкаСеть)
            {
                ОбновлениеТаблоАдрес2();
                ЗначениеПодпись1 = "  .";
                ЗначениеПодпись2 = "  .";
                ЗначениеПодпись3 = "  .";
                ЗначениеАдресК = "   ";
            }
            else
            {
                _ТаблоАдрес1 = "";
                _ТаблоАдрес2 = "";
                _ТаблоИнформация = "";
            }

        }

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler RefreshForm;

        public void Refresh()
        {
            if (ЛампочкаСеть)
            {
                ОбновлениеТаблоАдрес2();
                ОбновлениеТаблоГруппа();
                ОбновлениеТаблоИнформация();
            }
            if (RefreshForm != null)
            {
                RefreshForm();
            }
        }

        private void ОбновлениеТаблоАдрес2()
        {
            if (_КнопкаАдресК || _КнопкаПодпись1 || _КнопкаПодпись2 || _КнопкаПодпись3)
            {
                if (_КнопкаАдресК)
                {
                    _ТаблоАдрес2 = ЗначениеАдресК;
                }
                if (_КнопкаПодпись1)
                {
                    _ТаблоАдрес2 = ЗначениеПодпись1;
                }
                if (_КнопкаПодпись2)
                {
                    _ТаблоАдрес2 = ЗначениеПодпись2;
                }
                if (_КнопкаПодпись3)
                {
                    _ТаблоАдрес2 = ЗначениеПодпись3;
                }
            }
            else
            {
                _ТаблоАдрес2 = "";
            }
        }

        private bool КнопкаНаборККНажата;
        private bool КнопкаНаборККОтжата;
        private void ОбновлениеТаблоГруппа()
        {
            if ((_КнопкаАдресК || _КнопкаПодпись1 || _КнопкаПодпись2 || _КнопкаПодпись3))
            {
                ИндексГруппы = -1;
                ЗначениеИндексГруппы = "0";
            }
            else
                if (ЛампочкаПрием && КнопкаНаборККНажата)
            {
                ИндексГруппы = 0;
                while (ЗначениеГруппа[ИндексГруппы] != "^00")
                    ИндексГруппы++;
                ЗначениеИндексГруппы = Convert.ToString(ИндексГруппы + 1);
                КнопкаНаборККНажата = false;
                ЗначениеИнформация = "";
                ИндексГруппы = -1;
            }
            else
            {
                if (ИнформацияПринята && КнопкаНаборККОтжата && !ЛампочкаПрием)
                {
                    КнопкаНаборККОтжата = false;
                    ИндексГруппы = -1;
                    ЗначениеИндексГруппы = "0";
                    ЗначениеИнформация = "";
                }
            }
            _ТаблоГруппа = ЗначениеИндексГруппы;
        }

        private void ОбновлениеТаблоИнформация()
        {
            if (_КнопкаАдресК || _КнопкаПодпись1 || _КнопкаПодпись2 || _КнопкаПодпись3)
            {
                ЗначениеИнформация = "";
            }
            _ТаблоИнформация = ЗначениеИнформация;
        }
    }
}
