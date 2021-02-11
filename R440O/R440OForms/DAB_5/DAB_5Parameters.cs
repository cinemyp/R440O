namespace R440O.Parameters
{
    using R440OForms.N15;
    using ThirdParty;
    using System;

    /// <summary>
    /// Состояния элементов блока ДАБ-5
    /// </summary>
    class DAB_5Parameters
    {
        public static bool Включен
        {
            get { return N15Parameters.ЛампочкаДАБ_5; }
        }

        private static bool _тумблерПитание;
        public static bool ТумблерПитание
        {
            get { return _тумблерПитание; }
            set
            {
                _тумблерПитание = value;
                N15Parameters.ResetParametersAlternative();
                if (ЛампочкаПитание)
                    SetDefaultParameters();
                else
                    TurnOff();
                OnParameterChanged();
            }
        }

        #region Лампочки ДАБ-5 УП
        public static bool ЛампочкаПитание
        {
            get { return Включен; }
        }

        public static bool ЛампочкаРежимМестн
        {
            get { return Включен; }
        }

        public static bool ЛампочкаОбход
        {
            get { return N15Parameters.ТумблерДАБ_5 && N15Parameters.Включен && ОбходВкл; }
        }

        public static bool ЛампочкаРежимАвтом
        {
            get { return Включен && РежимАвтом; }
        }

        public static bool ЛампочкаРежимРучн
        {
            get { return Включен && РежимРучн; }
        }

        public static bool ЛампочкаВыборПрмПрд1
        {
            get { return Включен && КомплектПрмПрд1; }
        }

        public static bool ЛампочкаВыборПрмПрд2
        {
            get { return Включен && КомплектПрмПрд2; }
        }

        public static bool ЛампочкаВыборБП1
        {
            get { return Включен && КомплектБП1; }
        }

        public static bool ЛампочкаВыборБП2
        {
            get { return Включен && КомплектБП2; }
        }

        public static bool ЛампочкаРежимРабота1К
        {
            get { return Включен && РежимРаботы1К == 1; }
        }

        public static bool ЛампочкаРежимШлейф1К
        {
            get { return Включен && РежимРаботы1К == 2; }
        }

        public static bool ЛампочкаРежимПрмПрд1К
        {
            get { return Включен && РежимРаботы1К == 3; }
        }

        public static bool ЛампочкаРежимПрм1К
        {
            get { return Включен && РежимРаботы1К == 4; }
        }

        public static bool ЛампочкаРежимРабота2К
        {
            get { return Включен && РежимРаботы2К == 1; }
        }

        public static bool ЛампочкаРежимШлейф2К
        {
            get { return Включен && РежимРаботы2К == 2; }
        }

        public static bool ЛампочкаРежимПрмПрд2К
        {
            get { return Включен && РежимРаботы2К == 3; }
        }

        public static bool ЛампочкаРежимПрм2К
        {
            get { return Включен && РежимРаботы2К == 4; }
        }
        #endregion

        #region Лампочки Комплекты
        private static bool _лампочка1КомплектПрдДаб51БиВых;
        public static bool Лампочка1КомплектПрдДаб51БиВых
        {
            get { return Включен && _лампочка1КомплектПрдДаб51БиВых; }
            set { _лампочка1КомплектПрдДаб51БиВых = value; }
        }

        private static bool _лампочка1КомплектПрдДаб51БиВх;
        public static bool Лампочка1КомплектПрдДаб51БиВх
        {
            get { return Включен && _лампочка1КомплектПрдДаб51БиВх; }
            set { _лампочка1КомплектПрдДаб51БиВх = value; }
        }

        private static bool _лампочка1КомплектПрдДаб51ВхСс;
        public static bool Лампочка1КомплектПрдДаб51ВхСс
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВхСс; }
            set { _лампочка1КомплектПрдДаб51ВхСс = value; }
        }

        private static bool _лампочка1КомплектПрдДаб51ВхКк;
        public static bool Лампочка1КомплектПрдДаб5_1ВхКк
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВхКк; }
            set { _лампочка1КомплектПрдДаб51ВхКк = value; }
        }

        private static bool _лампочка1КомплектПрдДаб51ВыхСс;
        public static bool Лампочка1КомплектПрдДаб5_1ВыхСс
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВыхСс; }
            set { _лампочка1КомплектПрдДаб51ВыхСс = value; }
        }

        private static bool _лампочка1КомплектПрдДаб51ВыхКк;
        public static bool Лампочка1КомплектПрдДаб5_1ВыхКк
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВыхКк; }
            set { _лампочка1КомплектПрдДаб51ВыхКк = value; }
        }

        private static bool _лампочка1КомплектПрдДаб51ВыхТч;
        public static bool Лампочка1КомплектПрдДаб5_1ВыхТч
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВыхТч; }
            set { _лампочка1КомплектПрдДаб51ВыхТч = value; }
        }

        private static bool _лампочка1КомплектПрдДаб5ГВкл;
        public static bool Лампочка1КомплектПрдДаб5ГВкл
        {
            get { return Включен && _лампочка1КомплектПрдДаб5ГВкл; }
            set { _лампочка1КомплектПрдДаб5ГВкл = value; }
        }

        private static bool _лампочка1КомплектПрдДаб5ГтСнх;
        public static bool Лампочка1КомплектПрдДаб5ГТСнх
        {
            get { return Включен && _лампочка1КомплектПрдДаб5ГтСнх; }
            set { _лампочка1КомплектПрдДаб5ГтСнх = value; }
        }

        private static bool _лампочка1КомплектПрдДаб5ГТакт;
        public static bool Лампочка1КомплектПрдДаб5ГТакт
        {
            get { return Включен && _лампочка1КомплектПрдДаб5ГТакт; }
            set { _лампочка1КомплектПрдДаб5ГТакт = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51БиВых;
        public static bool Лампочка1КомплектПрмДаб51БиВых
        {
            get { return Включен && _лампочка1КомплектПрмДаб51БиВых; }
            set { _лампочка1КомплектПрмДаб51БиВых = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51БиВх;
        public static bool Лампочка1КомплектПрмДаб51БиВх
        {
            get { return Включен && _лампочка1КомплектПрмДаб51БиВх; }
            set { _лампочка1КомплектПрмДаб51БиВх = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51ВхСс;
        public static bool Лампочка1КомплектПрмДаб51ВхСс
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВхСс; }
            set { _лампочка1КомплектПрмДаб51ВхСс = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51ВхКк;
        public static bool Лампочка1КомплектПрмДаб5_1ВхКк
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВхКк; }
            set { _лампочка1КомплектПрмДаб51ВхКк = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51ВыхСс;
        public static bool Лампочка1КомплектПрмДаб5_1ВыхСс
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВыхСс; }
            set { _лампочка1КомплектПрмДаб51ВыхСс = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51ВыхКк;
        public static bool Лампочка1КомплектПрмДаб5_1ВыхКк
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВыхКк; }
            set { _лампочка1КомплектПрмДаб51ВыхКк = value; }
        }

        private static bool _лампочка1КомплектПрмДаб51ВыхТч;
        public static bool Лампочка1КомплектПрмДаб5_1ВыхТч
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВыхТч; }
            set { _лампочка1КомплектПрмДаб51ВыхТч = value; }
        }

        private static bool _лампочка1КомплектПрмДаб5ГВкл;
        public static bool Лампочка1КомплектПрмДаб5ГВкл
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГВкл; }
            set { _лампочка1КомплектПрмДаб5ГВкл = value; }
        }

        private static IDisposable timer_Лампочка1КомплектПрмДаб5ГТСнх = null;
        private static bool _лампочка1КомплектПрмДаб5ГтСнх;
        public static bool Лампочка1КомплектПрмДаб5ГТСнх
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГтСнх; }
            set { _лампочка1КомплектПрмДаб5ГтСнх = value; }
        }

        private static IDisposable timer_Лампочка1КомплектПрмДаб5ГЦСнх = null;
        private static bool _лампочка1КомплектПрмДаб5ГцСнх;
        public static bool Лампочка1КомплектПрмДаб5ГЦСнх
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГцСнх; }
            set { _лампочка1КомплектПрмДаб5ГцСнх = value; }
        }

        private static bool _лампочка1КомплектПрмДаб5ГТакт;
        public static bool Лампочка1КомплектПрмДаб5ГТакт
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГТакт; }
            set { _лампочка1КомплектПрмДаб5ГТакт = value; }
        }

        private static IDisposable timer_Лампочка1КомплектПрмДаб5ГИмТлф = null;
        private static bool _лампочка1КомплектПрмДаб5ГИмТлф;
        public static bool Лампочка1КомплектПрмДаб5ГИмТлф
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГИмТлф; }
            set { _лампочка1КомплектПрмДаб5ГИмТлф = value; }
        }

        private static IDisposable timer_Лампочка1КомплектПрмДаб5ГИмСс = null;
        private static bool _лампочка1КомплектПрмДаб5ГИмСс;
        public static bool Лампочка1КомплектПрмДаб5ГИмСс
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГИмСс; }
            set { _лампочка1КомплектПрмДаб5ГИмСс = value; }
        }

        private static IDisposable timer_Лампочка1КомплектПрмДаб5ГИмКк;
        private static bool _лампочка1КомплектПрмДаб5ГИмКк;
        public static bool Лампочка1КомплектПрмДаб5ГИмКк
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГИмКк; }
            set { _лампочка1КомплектПрмДаб5ГИмКк = value; }
        }

        private static bool _Лампочка2КомплектПрдДаб51БиВых;
        public static bool Лампочка2КомплектПрдДаб51БиВых
        {
            get { return Включен && _Лампочка2КомплектПрдДаб51БиВых; }
        }

        private static bool _Лампочка2КомплектПрдДаб51БиВх;
        public static bool Лампочка2КомплектПрдДаб51БиВх
        {
            get { return Включен && _Лампочка2КомплектПрдДаб51БиВх; }
        }

        private static bool _Лампочка2КомплектПрдДаб51ВхСс;
        public static bool Лампочка2КомплектПрдДаб51ВхСс
        {
            get { return Включен && _Лампочка2КомплектПрдДаб51ВхСс; }
        }

        private static bool _Лампочка2КомплектПрдДаб5_1ВхКк;
        public static bool Лампочка2КомплектПрдДаб5_1ВхКк
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВхКк; }
        }

        private static bool _Лампочка2КомплектПрдДаб5_1ВыхСс;
        public static bool Лампочка2КомплектПрдДаб5_1ВыхСс
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВыхСс; }
        }

        private static bool _Лампочка2КомплектПрдДаб5_1ВыхКк;
        public static bool Лампочка2КомплектПрдДаб5_1ВыхКк
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВыхКк; }
        }

        private static bool _Лампочка2КомплектПрдДаб5_1ВыхТч;
        public static bool Лампочка2КомплектПрдДаб5_1ВыхТч
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВыхТч; }
        }

        private static bool _Лампочка2КомплектПрдДаб5ГВкл;
        public static bool Лампочка2КомплектПрдДаб5ГВкл
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5ГВкл; }
        }

        private static bool _Лампочка2КомплектПрдДаб5ГТСнх;
        public static bool Лампочка2КомплектПрдДаб5ГТСнх
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5ГТСнх; }
        }

        private static bool _Лампочка2КомплектПрдДаб5ГТакт;
        public static bool Лампочка2КомплектПрдДаб5ГТакт
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5ГТакт; }
        }

        private static bool _Лампочка2КомплектПрмДаб51БиВых;
        public static bool Лампочка2КомплектПрмДаб51БиВых
        {
            get { return Включен && _Лампочка2КомплектПрмДаб51БиВых; }
        }

        private static bool _Лампочка2КомплектПрмДаб51БиВх;
        public static bool Лампочка2КомплектПрмДаб51БиВх
        {
            get { return Включен && _Лампочка2КомплектПрмДаб51БиВх; }
        }

        private static bool _Лампочка2КомплектПрмДаб51ВхСс;
        public static bool Лампочка2КомплектПрмДаб51ВхСс
        {
            get { return Включен && _Лампочка2КомплектПрмДаб51ВхСс; }
        }

        private static bool _Лампочка2КомплектПрмДаб5_1ВхКк;
        public static bool Лампочка2КомплектПрмДаб5_1ВхКк
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВхКк; }
        }

        private static bool _Лампочка2КомплектПрмДаб5_1ВыхСс;
        public static bool Лампочка2КомплектПрмДаб5_1ВыхСс
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВыхСс; }
        }

        private static bool _Лампочка2КомплектПрмДаб5_1ВыхКк;
        public static bool Лампочка2КомплектПрмДаб5_1ВыхКк
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВыхКк; }
        }

        private static bool _Лампочка2КомплектПрмДаб5_1ВыхТч;
        public static bool Лампочка2КомплектПрмДаб5_1ВыхТч
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВыхТч; }
        }

        private static bool _Лампочка2КомплектПрмДаб5ГВкл;
        public static bool Лампочка2КомплектПрмДаб5ГВкл
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГВкл; }
        }

        private static IDisposable timer_Лампочка2КомплектПрмДаб5ГТСнх = null;
        private static bool _Лампочка2КомплектПрмДаб5ГТСнх;
        public static bool Лампочка2КомплектПрмДаб5ГТСнх
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГТСнх; }
        }

        private static IDisposable timer_Лампочка2КомплектПрмДаб5ГЦСнх = null;
        private static bool _Лампочка2КомплектПрмДаб5ГЦСнх;
        public static bool Лампочка2КомплектПрмДаб5ГЦСнх
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГЦСнх; }
        }

        private static bool _Лампочка2КомплектПрмДаб5ГТакт;
        public static bool Лампочка2КомплектПрмДаб5ГТакт
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГТакт; }
        }

        private static IDisposable timer_Лампочка2КомплектПрмДаб5ГИмТлф = null;
        private static bool _Лампочка2КомплектПрмДаб5ГИмТлф;
        public static bool Лампочка2КомплектПрмДаб5ГИмТлф
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГИмТлф; }
        }

        private static IDisposable timer_Лампочка2КомплектПрмДаб5ГИмСс = null;
        private static bool _Лампочка2КомплектПрмДаб5ГИмСс;
        public static bool Лампочка2КомплектПрмДаб5ГИмСс
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГИмСс; }
        }

        private static IDisposable timer_Лампочка2КомплектПрмДаб5ГИмКк = null;
        private static bool _Лампочка2КомплектПрмДаб5ГИмКк;
        public static bool Лампочка2КомплектПрмДаб5ГИмКк
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГИмКк; }
        }

        private static bool _Лампочка2КомплектИмВкл;
        public static bool Лампочка2КомплектИмВкл
        {
            get { return Включен && (ЛампочкаРежимПрмПрд1К || ЛампочкаРежимПрмПрд2К || ЛампочкаРежимПрм1К || ЛампочкаРежимПрм2К); }
        }

        private static bool _Лампочка2КомплектИмТСнх;
        public static bool Лампочка2КомплектИмТСнх
        {
            get { return Включен && _Лампочка2КомплектИмТСнх; }
        }

        private static bool _Лампочка2КомплектИмТакт;
        public static bool Лампочка2КомплектИмТакт
        {
            get { return Включен && _Лампочка2КомплектИмТакт; }
        }
        #endregion

        private static bool _режимРучн;
        private static bool _режимАвтом;
        private static bool _кнопкаОбходВкл;
        private static bool _кнопкаОбходВыкл;
        private static bool _кнопкаРежимРучн;
        private static bool _кнопкаРежимАвтом;
        private static bool _кнопкаВыборПрмПрд1;
        private static bool _кнопкаВыборПрмПрд2;
        private static bool _комплектПрмПрд1;
        private static bool _комплектПрмПрд2;
        private static bool _обходВкл;
        private static bool _кнопкаВыборБП1;
        private static bool _кнопкаВыборБП2;
        private static bool _комплектБП1;
        private static bool _комплектБП2;
        private static bool _кнопкаРежимВыкл1К;
        private static bool _кнопкаРежимРабота1К;
        private static bool _кнопкаРежимШлейф1К;
        private static bool _кнопкаРежимПроверкаПрмПрд1К;
        private static bool _кнопкаРежимПроверкаПрм1К;
        private static bool _кнопкаРежимВыкл2К;
        private static bool _кнопкаРежимРабота2К;
        private static bool _кнопкаРежимШлейф2К;
        private static bool _кнопкаРежимПроверкаПрмПрд2К;
        private static bool _кнопкаРежимПроверкаПрм2К;
        private static int _режимРаботы1К;
        private static int _режимРаботы2К;


        #region Режимы и комплекты

        public static bool ОбходВкл
        {
            get { return _обходВкл; }
            set
            {
                _обходВкл = value;
                if (_обходВкл)
                {
                    if (РежимРаботы1К < 3) РежимРаботы1К = 3;
                    if (РежимРаботы2К < 3) РежимРаботы2К = 3;
                    РежимАвтом = false;
                    РежимРучн = true;
                }
                OnParameterChanged();
            }
        }

        public static bool РежимРучн
        {
            get { return _режимРучн; }
            set
            {
                _режимРучн = value;
                if (_режимРучн) РежимАвтом = false;
                OnParameterChanged();
            }
        }

        public static bool РежимАвтом
        {
            get { return _режимАвтом; }
            set
            {
                _режимАвтом = value;
                if (_режимАвтом) РежимРучн = false;
                OnParameterChanged();
            }
        }

        public static bool КомплектПрмПрд1
        {
            get { return _комплектПрмПрд1; }
            set
            {
                _комплектПрмПрд1 = value;
                if (_комплектПрмПрд1) КомплектПрмПрд2 = false;
                OnParameterChanged();
            }
        }

        public static bool КомплектПрмПрд2
        {
            get { return _комплектПрмПрд2; }
            set
            {
                _комплектПрмПрд2 = value;
                if (_комплектПрмПрд2) КомплектПрмПрд1 = false;
                OnParameterChanged();
            }
        }

        public static bool КомплектБП1
        {
            get { return _комплектБП1; }
            set
            {
                _комплектБП1 = value;
                if (_комплектБП1) КомплектБП2 = false;
                OnParameterChanged();
            }
        }

        public static bool КомплектБП2
        {
            get { return _комплектБП2; }
            set
            {
                _комплектБП2 = value;
                if (_комплектБП2) КомплектБП1 = false;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// 0 - выкл, 1 - работа, 2 - шлейф, 3 - проверка ПрмПрд, 4 - проверка Прм
        /// </summary>
        public static int РежимРаботы1К
        {
            get { return _режимРаботы1К; }
            set
            {
                if (ОбходВкл && (value < 3 && value > 0)) return;
                _режимРаботы1К = value;
                switch (_режимРаботы1К)
                {
                    case 0:
                    {
                        ВыключитьЛампочкиВкл1Комплекта();
                        СброситьВсеТаймерыИСвязанныеСНимиЛампочки1Комплекта();
                        break;
                    }
                    case 1:
                    {
                        ВключитьЛампочкиВкл1Комплекта();
                        break;
                    }
                    case 2:
                    {
                        ВключитьЛампочкиВкл1Комплекта();
                        break;
                    }
                    case 3:
                    {
                        ВключитьЛампочкиВкл1Комплекта();

                        timer_Лампочка1КомплектПрмДаб5ГИмКк?.Dispose();
                        Лампочка1КомплектПрмДаб5ГИмКк = true;
                        timer_Лампочка1КомплектПрмДаб5ГИмКк = EasyTimer.SetTimeout(() =>
                        {
                            Лампочка1КомплектПрмДаб5ГИмКк = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГИмКк.Dispose();
                        }, 2000);

                        timer_Лампочка1КомплектПрмДаб5ГИмСс?.Dispose();
                        Лампочка1КомплектПрмДаб5ГИмСс = true;
                        timer_Лампочка1КомплектПрмДаб5ГИмСс = EasyTimer.SetTimeout(() =>
                        {
                            Лампочка1КомплектПрмДаб5ГИмСс = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГИмСс.Dispose();
                        }, 2000);

                        timer_Лампочка1КомплектПрмДаб5ГИмТлф?.Dispose();
                        Лампочка1КомплектПрмДаб5ГИмТлф = true;
                        timer_Лампочка1КомплектПрмДаб5ГИмТлф = EasyTimer.SetTimeout(() =>
                        {
                            Лампочка1КомплектПрмДаб5ГИмТлф = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГИмТлф.Dispose();
                        }, 4000);

                        timer_Лампочка1КомплектПрмДаб5ГЦСнх?.Dispose();
                        timer_Лампочка1КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                        {
                            Лампочка1КомплектПрмДаб5ГЦСнх = true;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                            {
                                Лампочка1КомплектПрмДаб5ГЦСнх = false;
                                OnParameterChanged();
                                timer_Лампочка1КомплектПрмДаб5ГЦСнх.Dispose();
                            }, 2000);
                        }, 2000);

                        timer_Лампочка1КомплектПрмДаб5ГТСнх?.Dispose();
                        Лампочка1КомплектПрмДаб5ГТСнх = true;
                        timer_Лампочка1КомплектПрмДаб5ГТСнх = EasyTimer.SetTimeout(() =>
                        {
                            Лампочка1КомплектПрмДаб5ГТСнх = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГТСнх.Dispose();
                        }, 1000);

                        break;
                    }
                    case 4:
                    {
                        ВключитьЛампочкиВкл1Комплекта();

                        timer_Лампочка1КомплектПрмДаб5ГИмКк?.Dispose();
                        _лампочка1КомплектПрмДаб5ГИмКк = true;
                        timer_Лампочка1КомплектПрмДаб5ГИмКк = EasyTimer.SetTimeout(() =>
                        {
                            _лампочка1КомплектПрмДаб5ГИмКк = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГИмКк.Dispose();
                        }, 2000);

                        timer_Лампочка1КомплектПрмДаб5ГИмСс?.Dispose();
                        _лампочка1КомплектПрмДаб5ГИмСс = true;
                        timer_Лампочка1КомплектПрмДаб5ГИмСс = EasyTimer.SetTimeout(() =>
                        {
                            _лампочка1КомплектПрмДаб5ГИмСс = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГИмСс.Dispose();
                        }, 2000);

                        timer_Лампочка1КомплектПрмДаб5ГИмТлф?.Dispose();
                        _лампочка1КомплектПрмДаб5ГИмТлф = true;
                        timer_Лампочка1КомплектПрмДаб5ГИмТлф = EasyTimer.SetTimeout(() =>
                        {
                            _лампочка1КомплектПрмДаб5ГИмТлф = false;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГИмТлф.Dispose();
                        }, 4000);

                        timer_Лампочка1КомплектПрмДаб5ГЦСнх?.Dispose();
                        timer_Лампочка1КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                        {
                            _лампочка1КомплектПрмДаб5ГцСнх = true;
                            OnParameterChanged();
                            timer_Лампочка1КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                            {
                                _лампочка1КомплектПрмДаб5ГцСнх = false;
                                OnParameterChanged();
                                timer_Лампочка1КомплектПрмДаб5ГЦСнх.Dispose();
                            }, 2000);
                        }, 2000);

                        break;
                    }
                }

                OnParameterChanged();
            }
        }


        /// <summary>
        /// 0 - выкл, 1 - работа, 2 - шлейф, 3 - проверка ПрмПрд, 4 - проверка Прм
        /// </summary>
        public static int РежимРаботы2К
        {
            get { return _режимРаботы2К; }
            set
            {
                if (ОбходВкл && (value < 3 && value > 0)) return;
                _режимРаботы2К = value;

                switch (_режимРаботы2К)
                {
                    case 0:
                        {
                            ВыключитьЛампочкиВкл2Комплекта();
                            СброситьВсеТаймерыИСвязанныеСНимиЛампочки2Комплекта();
                            break;
                        }
                    case 1:
                        {
                            ВключитьЛампочкиВкл2Комплекта();
                            break;
                        }
                    case 2:
                        {
                            ВключитьЛампочкиВкл2Комплекта();
                            break;
                        }
                    case 3:
                        {
                            ВключитьЛампочкиВкл2Комплекта();

                            if (timer_Лампочка2КомплектПрмДаб5ГИмКк != null)
                                timer_Лампочка2КомплектПрмДаб5ГИмКк.Dispose();
                            _Лампочка2КомплектПрмДаб5ГИмКк = true;
                            timer_Лампочка2КомплектПрмДаб5ГИмКк = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГИмКк = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГИмКк.Dispose();
                            }, 2000);

                            if (timer_Лампочка2КомплектПрмДаб5ГИмСс != null)
                                timer_Лампочка2КомплектПрмДаб5ГИмСс.Dispose();
                            _Лампочка2КомплектПрмДаб5ГИмСс = true;
                            timer_Лампочка2КомплектПрмДаб5ГИмСс = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГИмСс = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГИмСс.Dispose();
                            }, 2000);

                            if (timer_Лампочка2КомплектПрмДаб5ГИмТлф != null)
                                timer_Лампочка2КомплектПрмДаб5ГИмТлф.Dispose();
                            _Лампочка2КомплектПрмДаб5ГИмТлф = true;
                            timer_Лампочка2КомплектПрмДаб5ГИмТлф = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГИмТлф = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГИмТлф.Dispose();
                            }, 4000);

                            if (timer_Лампочка2КомплектПрмДаб5ГЦСнх != null)
                                timer_Лампочка2КомплектПрмДаб5ГЦСнх.Dispose();
                            timer_Лампочка2КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГЦСнх = true;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                                {
                                    _Лампочка2КомплектПрмДаб5ГЦСнх = false;
                                    OnParameterChanged();
                                    timer_Лампочка2КомплектПрмДаб5ГЦСнх.Dispose();
                                }, 2000);
                            }, 2000);

                            if (timer_Лампочка2КомплектПрмДаб5ГТСнх != null)
                                timer_Лампочка2КомплектПрмДаб5ГТСнх.Dispose();
                            _Лампочка2КомплектПрмДаб5ГТСнх = true;
                            timer_Лампочка2КомплектПрмДаб5ГТСнх = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГТСнх = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГТСнх.Dispose();
                            }, 1000);

                            break;
                        }
                    case 4:
                        {
                            ВключитьЛампочкиВкл2Комплекта();

                            if (timer_Лампочка2КомплектПрмДаб5ГИмКк != null)
                                timer_Лампочка2КомплектПрмДаб5ГИмКк.Dispose();
                            _Лампочка2КомплектПрмДаб5ГИмКк = true;
                            timer_Лампочка2КомплектПрмДаб5ГИмКк = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГИмКк = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГИмКк.Dispose();
                            }, 2000);

                            if (timer_Лампочка2КомплектПрмДаб5ГИмСс != null)
                                timer_Лампочка2КомплектПрмДаб5ГИмСс.Dispose();
                            _Лампочка2КомплектПрмДаб5ГИмСс = true;
                            timer_Лампочка2КомплектПрмДаб5ГИмСс = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГИмСс = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГИмСс.Dispose();
                            }, 2000);

                            if (timer_Лампочка2КомплектПрмДаб5ГИмТлф != null)
                                timer_Лампочка2КомплектПрмДаб5ГИмТлф.Dispose();
                            _Лампочка2КомплектПрмДаб5ГИмТлф = true;
                            timer_Лампочка2КомплектПрмДаб5ГИмТлф = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГИмТлф = false;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГИмТлф.Dispose();
                            }, 4000);

                            if (timer_Лампочка2КомплектПрмДаб5ГЦСнх != null)
                                timer_Лампочка2КомплектПрмДаб5ГЦСнх.Dispose();
                            timer_Лампочка2КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                            {
                                _Лампочка2КомплектПрмДаб5ГЦСнх = true;
                                OnParameterChanged();
                                timer_Лампочка2КомплектПрмДаб5ГЦСнх = EasyTimer.SetTimeout(() =>
                                {
                                    _Лампочка2КомплектПрмДаб5ГЦСнх = false;
                                    OnParameterChanged();
                                    timer_Лампочка2КомплектПрмДаб5ГЦСнх.Dispose();
                                }, 2000);
                            }, 2000);

                            break;
                        }
                }

                OnParameterChanged();
            }
        }

        #endregion

        #region Кнопки

        public static bool КнопкаОбходВкл
        {
            get { return _кнопкаОбходВкл; }
            set
            {
                _кнопкаОбходВкл = value;
                if (_кнопкаОбходВкл && Включен) ОбходВкл = true;
                OnParameterChanged();
            }
        }

        public static bool КнопкаОбходВыкл
        {
            get { return _кнопкаОбходВыкл; }
            set
            {
                _кнопкаОбходВыкл = value;
                if (_кнопкаОбходВыкл && Включен) ОбходВкл = false;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимРучн
        {
            get { return _кнопкаРежимРучн; }
            set
            {
                _кнопкаРежимРучн = value;
                if (_кнопкаРежимРучн) { РежимРучн = true; }
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимАвтом
        {
            get { return _кнопкаРежимАвтом; }
            set
            {
                _кнопкаРежимАвтом = value;
                if (_кнопкаРежимАвтом) { РежимАвтом = true; }
                OnParameterChanged();
            }
        }

        public static bool КнопкаВыборПрмПрд1
        {
            get { return _кнопкаВыборПрмПрд1; }
            set
            {
                _кнопкаВыборПрмПрд1 = value;
                if (_кнопкаВыборПрмПрд1)
                {
                    КомплектПрмПрд1 = true;
                }
                OnParameterChanged();
            }
        }

        public static bool КнопкаВыборПрмПрд2
        {
            get { return _кнопкаВыборПрмПрд2; }
            set
            {
                _кнопкаВыборПрмПрд2 = value;
                if (_кнопкаВыборПрмПрд2)
                {
                    КомплектПрмПрд2 = true;
                }
                OnParameterChanged();
            }
        }

        public static bool КнопкаВыборБП1
        {
            get { return _кнопкаВыборБП1; }
            set
            {
                _кнопкаВыборБП1 = value;
                if (_кнопкаВыборБП1) КомплектБП1 = true;
                OnParameterChanged();
            }
        }

        public static bool КнопкаВыборБП2
        {
            get { return _кнопкаВыборБП2; }
            set
            {
                _кнопкаВыборБП2 = value;
                if (_кнопкаВыборБП2) КомплектБП2 = true;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимВыкл1К
        {
            get { return _кнопкаРежимВыкл1К; }
            set
            {
                _кнопкаРежимВыкл1К = value;
                if (_кнопкаРежимВыкл1К) РежимРаботы1К = 0;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимРабота1К
        {
            get { return _кнопкаРежимРабота1К; }
            set
            {
                _кнопкаРежимРабота1К = value;
                if (_кнопкаРежимРабота1К) РежимРаботы1К = 1;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимШлейф1К
        {
            get { return _кнопкаРежимШлейф1К; }
            set
            {
                _кнопкаРежимШлейф1К = value;
                if (_кнопкаРежимШлейф1К) РежимРаботы1К = 2;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимПроверкаПрмПрд1К
        {
            get { return _кнопкаРежимПроверкаПрмПрд1К; }
            set
            {
                _кнопкаРежимПроверкаПрмПрд1К = value;
                if (_кнопкаРежимПроверкаПрмПрд1К) РежимРаботы1К = 3;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимПроверкаПрм1К
        {
            get { return _кнопкаРежимПроверкаПрм1К; }
            set
            {
                _кнопкаРежимПроверкаПрм1К = value;
                if (_кнопкаРежимПроверкаПрм1К) РежимРаботы1К = 4;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимВыкл2К
        {
            get { return _кнопкаРежимВыкл2К; }
            set
            {
                _кнопкаРежимВыкл2К = value;
                if (_кнопкаРежимВыкл2К) РежимРаботы2К = 0;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимРабота2К
        {
            get { return _кнопкаРежимРабота2К; }
            set
            {
                _кнопкаРежимРабота2К = value;
                if (_кнопкаРежимРабота2К) РежимРаботы2К = 1;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимШлейф2К
        {
            get { return _кнопкаРежимШлейф2К; }
            set
            {
                _кнопкаРежимШлейф2К = value;
                if (_кнопкаРежимШлейф2К) РежимРаботы2К = 2;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимПроверкаПрмПрд2К
        {
            get { return _кнопкаРежимПроверкаПрмПрд2К; }
            set
            {
                _кнопкаРежимПроверкаПрмПрд2К = value;
                if (_кнопкаРежимПроверкаПрмПрд2К) РежимРаботы2К = 3;
                OnParameterChanged();
            }
        }

        public static bool КнопкаРежимПроверкаПрм2К
        {
            get { return _кнопкаРежимПроверкаПрм2К; }
            set
            {
                _кнопкаРежимПроверкаПрм2К = value;
                if (_кнопкаРежимПроверкаПрм2К) РежимРаботы2К = 4;
                OnParameterChanged();
            }
        }

        #endregion


        #region Другие функции

        //private static void SetTimeoutForLamp(ref IDisposable timerLamp, string lampName, int timeout)
        //{
        //    timerLamp?.Dispose();
        //    var lampPropInfo = typeof (DAB_5Parameters).GetProperty(lampName);
        //    lampPropInfo.SetValue(lampPropInfo, true);

        //    timerLamp = EasyTimer.SetTimeout(() =>
        //    {
        //        lampPropInfo.SetValue(lampPropInfo, false);
        //        OnParameterChanged();
        //       // timerLamp?.Dispose();
        //    }
        //    , timeout);
        //}

        private static void ВключитьЛампочкиВкл1Комплекта()
        {
            _лампочка1КомплектПрдДаб5ГВкл = true;
            _лампочка1КомплектПрмДаб5ГВкл = true;
        }

        private static void ВключитьЛампочкиВкл2Комплекта()
        {
            _Лампочка2КомплектПрдДаб5ГВкл = true;
            _Лампочка2КомплектПрмДаб5ГВкл = true;
        }


        private static void ВыключитьЛампочкиВкл1Комплекта()
        {
            _лампочка1КомплектПрдДаб5ГВкл = false;
            _лампочка1КомплектПрмДаб5ГВкл = false;
        }

        private static void ВыключитьЛампочкиВкл2Комплекта()
        {
            _Лампочка2КомплектПрдДаб5ГВкл = false;
            _Лампочка2КомплектПрмДаб5ГВкл = false;
        }


        private static void СброситьВсеТаймерыИСвязанныеСНимиЛампочки1Комплекта()
        {
            //if (_timerЛампочка1КомплектПрмДаб5ГИмКк != null)
            //    _timerЛампочка1КомплектПрмДаб5ГИмКк.Dispose();
            _лампочка1КомплектПрмДаб5ГИмКк = false;

            if (timer_Лампочка1КомплектПрмДаб5ГИмСс != null)
                timer_Лампочка1КомплектПрмДаб5ГИмСс.Dispose();
            _лампочка1КомплектПрмДаб5ГИмСс = false;

            if (timer_Лампочка1КомплектПрмДаб5ГИмТлф != null)
                timer_Лампочка1КомплектПрмДаб5ГИмТлф.Dispose();
            _лампочка1КомплектПрмДаб5ГИмТлф = false;

            if (timer_Лампочка1КомплектПрмДаб5ГЦСнх != null)
                timer_Лампочка1КомплектПрмДаб5ГЦСнх.Dispose();
            _лампочка1КомплектПрмДаб5ГцСнх = false;

            if (timer_Лампочка1КомплектПрмДаб5ГТСнх != null)
                timer_Лампочка1КомплектПрмДаб5ГТСнх.Dispose();
            _лампочка1КомплектПрмДаб5ГтСнх = false;
        }

        private static void СброситьВсеТаймерыИСвязанныеСНимиЛампочки2Комплекта()
        {
            if (timer_Лампочка2КомплектПрмДаб5ГИмКк != null)
                timer_Лампочка2КомплектПрмДаб5ГИмКк.Dispose();
            _Лампочка2КомплектПрмДаб5ГИмКк = false;

            if (timer_Лампочка2КомплектПрмДаб5ГИмСс != null)
                timer_Лампочка2КомплектПрмДаб5ГИмСс.Dispose();
            _Лампочка2КомплектПрмДаб5ГИмСс = false;

            if (timer_Лампочка2КомплектПрмДаб5ГИмТлф != null)
                timer_Лампочка2КомплектПрмДаб5ГИмТлф.Dispose();
            _Лампочка2КомплектПрмДаб5ГИмТлф = false;

            if (timer_Лампочка2КомплектПрмДаб5ГЦСнх != null)
                timer_Лампочка2КомплектПрмДаб5ГЦСнх.Dispose();
            _Лампочка2КомплектПрмДаб5ГЦСнх = false;

            if (timer_Лампочка2КомплектПрмДаб5ГТСнх != null)
                timer_Лампочка2КомплектПрмДаб5ГТСнх.Dispose();
            _Лампочка2КомплектПрмДаб5ГТСнх = false;
        }
        #endregion

        private static void TurnOff()
        {
            ВыключитьЛампочкиВкл1Комплекта();
            ВыключитьЛампочкиВкл2Комплекта();
            СброситьВсеТаймерыИСвязанныеСНимиЛампочки1Комплекта();
            СброситьВсеТаймерыИСвязанныеСНимиЛампочки2Комплекта();
        }

        public static void SetDefaultParameters()
        {
            РежимРучн = true;
            КомплектПрмПрд1 = true;
            КомплектБП1 = true;
            РежимРаботы1К = 1;
            РежимРаботы2К = 1;
        }

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }
    }
}
