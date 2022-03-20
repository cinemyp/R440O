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
        private static DAB_5Parameters instance;
        public static DAB_5Parameters getInstance()
        {
            if (instance == null)
                instance = new DAB_5Parameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        public bool Включен
        {
            get { return N15Parameters.getInstance().ЛампочкаДАБ_5; }
        }

        private bool _тумблерПитание;
        public bool ТумблерПитание
        {
            get { return _тумблерПитание; }
            set
            {
                _тумблерПитание = value;
                N15Parameters.getInstance().ResetParametersAlternative();
                if (ЛампочкаПитание)
                    SetDefaultParameters();
                else
                    TurnOff();
                OnParameterChanged();
            }
        }

        #region Лампочки ДАБ-5 УП
        public bool ЛампочкаПитание
        {
            get { return Включен; }
        }

        public bool ЛампочкаРежимМестн
        {
            get { return Включен; }
        }

        public bool ЛампочкаОбход
        {
            get { return N15Parameters.getInstance().ТумблерДАБ_5 && N15Parameters.getInstance().Включен && ОбходВкл; }
        }

        public bool ЛампочкаРежимАвтом
        {
            get { return Включен && РежимАвтом; }
        }

        public bool ЛампочкаРежимРучн
        {
            get { return Включен && РежимРучн; }
        }

        public bool ЛампочкаВыборПрмПрд1
        {
            get { return Включен && КомплектПрмПрд1; }
        }

        public bool ЛампочкаВыборПрмПрд2
        {
            get { return Включен && КомплектПрмПрд2; }
        }

        public bool ЛампочкаВыборБП1
        {
            get { return Включен && КомплектБП1; }
        }

        public bool ЛампочкаВыборБП2
        {
            get { return Включен && КомплектБП2; }
        }

        public bool ЛампочкаРежимРабота1К
        {
            get { return Включен && РежимРаботы1К == 1; }
        }

        public bool ЛампочкаРежимШлейф1К
        {
            get { return Включен && РежимРаботы1К == 2; }
        }

        public bool ЛампочкаРежимПрмПрд1К
        {
            get { return Включен && РежимРаботы1К == 3; }
        }

        public bool ЛампочкаРежимПрм1К
        {
            get { return Включен && РежимРаботы1К == 4; }
        }

        public bool ЛампочкаРежимРабота2К
        {
            get { return Включен && РежимРаботы2К == 1; }
        }

        public bool ЛампочкаРежимШлейф2К
        {
            get { return Включен && РежимРаботы2К == 2; }
        }

        public bool ЛампочкаРежимПрмПрд2К
        {
            get { return Включен && РежимРаботы2К == 3; }
        }

        public bool ЛампочкаРежимПрм2К
        {
            get { return Включен && РежимРаботы2К == 4; }
        }
        #endregion

        #region Лампочки Комплекты
        private bool _лампочка1КомплектПрдДаб51БиВых;
        public bool Лампочка1КомплектПрдДаб51БиВых
        {
            get { return Включен && _лампочка1КомплектПрдДаб51БиВых; }
            set { _лампочка1КомплектПрдДаб51БиВых = value; }
        }

        private bool _лампочка1КомплектПрдДаб51БиВх;
        public bool Лампочка1КомплектПрдДаб51БиВх
        {
            get { return Включен && _лампочка1КомплектПрдДаб51БиВх; }
            set { _лампочка1КомплектПрдДаб51БиВх = value; }
        }

        private bool _лампочка1КомплектПрдДаб51ВхСс;
        public bool Лампочка1КомплектПрдДаб51ВхСс
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВхСс; }
            set { _лампочка1КомплектПрдДаб51ВхСс = value; }
        }

        private bool _лампочка1КомплектПрдДаб51ВхКк;
        public bool Лампочка1КомплектПрдДаб5_1ВхКк
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВхКк; }
            set { _лампочка1КомплектПрдДаб51ВхКк = value; }
        }

        private bool _лампочка1КомплектПрдДаб51ВыхСс;
        public bool Лампочка1КомплектПрдДаб5_1ВыхСс
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВыхСс; }
            set { _лампочка1КомплектПрдДаб51ВыхСс = value; }
        }

        private bool _лампочка1КомплектПрдДаб51ВыхКк;
        public bool Лампочка1КомплектПрдДаб5_1ВыхКк
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВыхКк; }
            set { _лампочка1КомплектПрдДаб51ВыхКк = value; }
        }

        private bool _лампочка1КомплектПрдДаб51ВыхТч;
        public bool Лампочка1КомплектПрдДаб5_1ВыхТч
        {
            get { return Включен && _лампочка1КомплектПрдДаб51ВыхТч; }
            set { _лампочка1КомплектПрдДаб51ВыхТч = value; }
        }

        private bool _лампочка1КомплектПрдДаб5ГВкл;
        public bool Лампочка1КомплектПрдДаб5ГВкл
        {
            get { return Включен && _лампочка1КомплектПрдДаб5ГВкл; }
            set { _лампочка1КомплектПрдДаб5ГВкл = value; }
        }

        private bool _лампочка1КомплектПрдДаб5ГтСнх;
        public bool Лампочка1КомплектПрдДаб5ГТСнх
        {
            get { return Включен && _лампочка1КомплектПрдДаб5ГтСнх; }
            set { _лампочка1КомплектПрдДаб5ГтСнх = value; }
        }

        private bool _лампочка1КомплектПрдДаб5ГТакт;
        public bool Лампочка1КомплектПрдДаб5ГТакт
        {
            get { return Включен && _лампочка1КомплектПрдДаб5ГТакт; }
            set { _лампочка1КомплектПрдДаб5ГТакт = value; }
        }

        private bool _лампочка1КомплектПрмДаб51БиВых;
        public bool Лампочка1КомплектПрмДаб51БиВых
        {
            get { return Включен && _лампочка1КомплектПрмДаб51БиВых; }
            set { _лампочка1КомплектПрмДаб51БиВых = value; }
        }

        private bool _лампочка1КомплектПрмДаб51БиВх;
        public bool Лампочка1КомплектПрмДаб51БиВх
        {
            get { return Включен && _лампочка1КомплектПрмДаб51БиВх; }
            set { _лампочка1КомплектПрмДаб51БиВх = value; }
        }

        private bool _лампочка1КомплектПрмДаб51ВхСс;
        public bool Лампочка1КомплектПрмДаб51ВхСс
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВхСс; }
            set { _лампочка1КомплектПрмДаб51ВхСс = value; }
        }

        private bool _лампочка1КомплектПрмДаб51ВхКк;
        public bool Лампочка1КомплектПрмДаб5_1ВхКк
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВхКк; }
            set { _лампочка1КомплектПрмДаб51ВхКк = value; }
        }

        private bool _лампочка1КомплектПрмДаб51ВыхСс;
        public bool Лампочка1КомплектПрмДаб5_1ВыхСс
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВыхСс; }
            set { _лампочка1КомплектПрмДаб51ВыхСс = value; }
        }

        private bool _лампочка1КомплектПрмДаб51ВыхКк;
        public bool Лампочка1КомплектПрмДаб5_1ВыхКк
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВыхКк; }
            set { _лампочка1КомплектПрмДаб51ВыхКк = value; }
        }

        private bool _лампочка1КомплектПрмДаб51ВыхТч;
        public bool Лампочка1КомплектПрмДаб5_1ВыхТч
        {
            get { return Включен && _лампочка1КомплектПрмДаб51ВыхТч; }
            set { _лампочка1КомплектПрмДаб51ВыхТч = value; }
        }

        private bool _лампочка1КомплектПрмДаб5ГВкл;
        public bool Лампочка1КомплектПрмДаб5ГВкл
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГВкл; }
            set { _лампочка1КомплектПрмДаб5ГВкл = value; }
        }

        private IDisposable timer_Лампочка1КомплектПрмДаб5ГТСнх = null;
        private bool _лампочка1КомплектПрмДаб5ГтСнх;
        public bool Лампочка1КомплектПрмДаб5ГТСнх
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГтСнх; }
            set { _лампочка1КомплектПрмДаб5ГтСнх = value; }
        }

        private IDisposable timer_Лампочка1КомплектПрмДаб5ГЦСнх = null;
        private bool _лампочка1КомплектПрмДаб5ГцСнх;
        public bool Лампочка1КомплектПрмДаб5ГЦСнх
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГцСнх; }
            set { _лампочка1КомплектПрмДаб5ГцСнх = value; }
        }

        private bool _лампочка1КомплектПрмДаб5ГТакт;
        public bool Лампочка1КомплектПрмДаб5ГТакт
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГТакт; }
            set { _лампочка1КомплектПрмДаб5ГТакт = value; }
        }

        private IDisposable timer_Лампочка1КомплектПрмДаб5ГИмТлф = null;
        private bool _лампочка1КомплектПрмДаб5ГИмТлф;
        public bool Лампочка1КомплектПрмДаб5ГИмТлф
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГИмТлф; }
            set { _лампочка1КомплектПрмДаб5ГИмТлф = value; }
        }

        private IDisposable timer_Лампочка1КомплектПрмДаб5ГИмСс = null;
        private bool _лампочка1КомплектПрмДаб5ГИмСс;
        public bool Лампочка1КомплектПрмДаб5ГИмСс
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГИмСс; }
            set { _лампочка1КомплектПрмДаб5ГИмСс = value; }
        }

        private IDisposable timer_Лампочка1КомплектПрмДаб5ГИмКк;
        private bool _лампочка1КомплектПрмДаб5ГИмКк;
        public bool Лампочка1КомплектПрмДаб5ГИмКк
        {
            get { return Включен && _лампочка1КомплектПрмДаб5ГИмКк; }
            set { _лампочка1КомплектПрмДаб5ГИмКк = value; }
        }

        private bool _Лампочка2КомплектПрдДаб51БиВых;
        public bool Лампочка2КомплектПрдДаб51БиВых
        {
            get { return Включен && _Лампочка2КомплектПрдДаб51БиВых; }
        }

        private bool _Лампочка2КомплектПрдДаб51БиВх;
        public bool Лампочка2КомплектПрдДаб51БиВх
        {
            get { return Включен && _Лампочка2КомплектПрдДаб51БиВх; }
        }

        private bool _Лампочка2КомплектПрдДаб51ВхСс;
        public bool Лампочка2КомплектПрдДаб51ВхСс
        {
            get { return Включен && _Лампочка2КомплектПрдДаб51ВхСс; }
        }

        private bool _Лампочка2КомплектПрдДаб5_1ВхКк;
        public bool Лампочка2КомплектПрдДаб5_1ВхКк
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВхКк; }
        }

        private bool _Лампочка2КомплектПрдДаб5_1ВыхСс;
        public bool Лампочка2КомплектПрдДаб5_1ВыхСс
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВыхСс; }
        }

        private bool _Лампочка2КомплектПрдДаб5_1ВыхКк;
        public bool Лампочка2КомплектПрдДаб5_1ВыхКк
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВыхКк; }
        }

        private bool _Лампочка2КомплектПрдДаб5_1ВыхТч;
        public bool Лампочка2КомплектПрдДаб5_1ВыхТч
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5_1ВыхТч; }
        }

        private bool _Лампочка2КомплектПрдДаб5ГВкл;
        public bool Лампочка2КомплектПрдДаб5ГВкл
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5ГВкл; }
        }

        private bool _Лампочка2КомплектПрдДаб5ГТСнх;
        public bool Лампочка2КомплектПрдДаб5ГТСнх
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5ГТСнх; }
        }

        private bool _Лампочка2КомплектПрдДаб5ГТакт;
        public bool Лампочка2КомплектПрдДаб5ГТакт
        {
            get { return Включен && _Лампочка2КомплектПрдДаб5ГТакт; }
        }

        private bool _Лампочка2КомплектПрмДаб51БиВых;
        public bool Лампочка2КомплектПрмДаб51БиВых
        {
            get { return Включен && _Лампочка2КомплектПрмДаб51БиВых; }
        }

        private bool _Лампочка2КомплектПрмДаб51БиВх;
        public bool Лампочка2КомплектПрмДаб51БиВх
        {
            get { return Включен && _Лампочка2КомплектПрмДаб51БиВх; }
        }

        private bool _Лампочка2КомплектПрмДаб51ВхСс;
        public bool Лампочка2КомплектПрмДаб51ВхСс
        {
            get { return Включен && _Лампочка2КомплектПрмДаб51ВхСс; }
        }

        private bool _Лампочка2КомплектПрмДаб5_1ВхКк;
        public bool Лампочка2КомплектПрмДаб5_1ВхКк
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВхКк; }
        }

        private bool _Лампочка2КомплектПрмДаб5_1ВыхСс;
        public bool Лампочка2КомплектПрмДаб5_1ВыхСс
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВыхСс; }
        }

        private bool _Лампочка2КомплектПрмДаб5_1ВыхКк;
        public bool Лампочка2КомплектПрмДаб5_1ВыхКк
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВыхКк; }
        }

        private bool _Лампочка2КомплектПрмДаб5_1ВыхТч;
        public bool Лампочка2КомплектПрмДаб5_1ВыхТч
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5_1ВыхТч; }
        }

        private bool _Лампочка2КомплектПрмДаб5ГВкл;
        public bool Лампочка2КомплектПрмДаб5ГВкл
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГВкл; }
        }

        private IDisposable timer_Лампочка2КомплектПрмДаб5ГТСнх = null;
        private bool _Лампочка2КомплектПрмДаб5ГТСнх;
        public bool Лампочка2КомплектПрмДаб5ГТСнх
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГТСнх; }
        }

        private IDisposable timer_Лампочка2КомплектПрмДаб5ГЦСнх = null;
        private bool _Лампочка2КомплектПрмДаб5ГЦСнх;
        public bool Лампочка2КомплектПрмДаб5ГЦСнх
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГЦСнх; }
        }

        private bool _Лампочка2КомплектПрмДаб5ГТакт;
        public bool Лампочка2КомплектПрмДаб5ГТакт
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГТакт; }
        }

        private IDisposable timer_Лампочка2КомплектПрмДаб5ГИмТлф = null;
        private bool _Лампочка2КомплектПрмДаб5ГИмТлф;
        public bool Лампочка2КомплектПрмДаб5ГИмТлф
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГИмТлф; }
        }

        private IDisposable timer_Лампочка2КомплектПрмДаб5ГИмСс = null;
        private bool _Лампочка2КомплектПрмДаб5ГИмСс;
        public bool Лампочка2КомплектПрмДаб5ГИмСс
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГИмСс; }
        }

        private IDisposable timer_Лампочка2КомплектПрмДаб5ГИмКк = null;
        private bool _Лампочка2КомплектПрмДаб5ГИмКк;
        public bool Лампочка2КомплектПрмДаб5ГИмКк
        {
            get { return Включен && _Лампочка2КомплектПрмДаб5ГИмКк; }
        }

        private bool _Лампочка2КомплектИмВкл;
        public bool Лампочка2КомплектИмВкл
        {
            get { return Включен && (ЛампочкаРежимПрмПрд1К || ЛампочкаРежимПрмПрд2К || ЛампочкаРежимПрм1К || ЛампочкаРежимПрм2К); }
        }

        private bool _Лампочка2КомплектИмТСнх;
        public bool Лампочка2КомплектИмТСнх
        {
            get { return Включен && _Лампочка2КомплектИмТСнх; }
        }

        private bool _Лампочка2КомплектИмТакт;
        public bool Лампочка2КомплектИмТакт
        {
            get { return Включен && _Лампочка2КомплектИмТакт; }
        }
        #endregion

        private bool _режимРучн;
        private bool _режимАвтом;
        private bool _кнопкаОбходВкл;
        private bool _кнопкаОбходВыкл;
        private bool _кнопкаРежимРучн;
        private bool _кнопкаРежимАвтом;
        private bool _кнопкаВыборПрмПрд1;
        private bool _кнопкаВыборПрмПрд2;
        private bool _комплектПрмПрд1;
        private bool _комплектПрмПрд2;
        private bool _обходВкл;
        private bool _кнопкаВыборБП1;
        private bool _кнопкаВыборБП2;
        private bool _комплектБП1;
        private bool _комплектБП2;
        private bool _кнопкаРежимВыкл1К;
        private bool _кнопкаРежимРабота1К;
        private bool _кнопкаРежимШлейф1К;
        private bool _кнопкаРежимПроверкаПрмПрд1К;
        private bool _кнопкаРежимПроверкаПрм1К;
        private bool _кнопкаРежимВыкл2К;
        private bool _кнопкаРежимРабота2К;
        private bool _кнопкаРежимШлейф2К;
        private bool _кнопкаРежимПроверкаПрмПрд2К;
        private bool _кнопкаРежимПроверкаПрм2К;
        private int _режимРаботы1К;
        private int _режимРаботы2К;


        #region Режимы и комплекты

        public bool ОбходВкл
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

        public bool РежимРучн
        {
            get { return _режимРучн; }
            set
            {
                _режимРучн = value;
                if (_режимРучн) РежимАвтом = false;
                OnParameterChanged();
            }
        }

        public bool РежимАвтом
        {
            get { return _режимАвтом; }
            set
            {
                _режимАвтом = value;
                if (_режимАвтом) РежимРучн = false;
                OnParameterChanged();
            }
        }

        public bool КомплектПрмПрд1
        {
            get { return _комплектПрмПрд1; }
            set
            {
                _комплектПрмПрд1 = value;
                if (_комплектПрмПрд1) КомплектПрмПрд2 = false;
                OnParameterChanged();
            }
        }

        public bool КомплектПрмПрд2
        {
            get { return _комплектПрмПрд2; }
            set
            {
                _комплектПрмПрд2 = value;
                if (_комплектПрмПрд2) КомплектПрмПрд1 = false;
                OnParameterChanged();
            }
        }

        public bool КомплектБП1
        {
            get { return _комплектБП1; }
            set
            {
                _комплектБП1 = value;
                if (_комплектБП1) КомплектБП2 = false;
                OnParameterChanged();
            }
        }

        public bool КомплектБП2
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
        public int РежимРаботы1К
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
        public int РежимРаботы2К
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

        public bool КнопкаОбходВкл
        {
            get { return _кнопкаОбходВкл; }
            set
            {
                _кнопкаОбходВкл = value;
                if (_кнопкаОбходВкл && Включен) ОбходВкл = true;
                OnParameterChanged();
            }
        }

        public bool КнопкаОбходВыкл
        {
            get { return _кнопкаОбходВыкл; }
            set
            {
                _кнопкаОбходВыкл = value;
                if (_кнопкаОбходВыкл && Включен) ОбходВкл = false;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимРучн
        {
            get { return _кнопкаРежимРучн; }
            set
            {
                _кнопкаРежимРучн = value;
                if (_кнопкаРежимРучн) { РежимРучн = true; }
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимАвтом
        {
            get { return _кнопкаРежимАвтом; }
            set
            {
                _кнопкаРежимАвтом = value;
                if (_кнопкаРежимАвтом) { РежимАвтом = true; }
                OnParameterChanged();
            }
        }

        public bool КнопкаВыборПрмПрд1
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

        public bool КнопкаВыборПрмПрд2
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

        public bool КнопкаВыборБП1
        {
            get { return _кнопкаВыборБП1; }
            set
            {
                _кнопкаВыборБП1 = value;
                if (_кнопкаВыборБП1) КомплектБП1 = true;
                OnParameterChanged();
            }
        }

        public bool КнопкаВыборБП2
        {
            get { return _кнопкаВыборБП2; }
            set
            {
                _кнопкаВыборБП2 = value;
                if (_кнопкаВыборБП2) КомплектБП2 = true;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимВыкл1К
        {
            get { return _кнопкаРежимВыкл1К; }
            set
            {
                _кнопкаРежимВыкл1К = value;
                if (_кнопкаРежимВыкл1К) РежимРаботы1К = 0;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимРабота1К
        {
            get { return _кнопкаРежимРабота1К; }
            set
            {
                _кнопкаРежимРабота1К = value;
                if (_кнопкаРежимРабота1К) РежимРаботы1К = 1;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимШлейф1К
        {
            get { return _кнопкаРежимШлейф1К; }
            set
            {
                _кнопкаРежимШлейф1К = value;
                if (_кнопкаРежимШлейф1К) РежимРаботы1К = 2;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимПроверкаПрмПрд1К
        {
            get { return _кнопкаРежимПроверкаПрмПрд1К; }
            set
            {
                _кнопкаРежимПроверкаПрмПрд1К = value;
                if (_кнопкаРежимПроверкаПрмПрд1К) РежимРаботы1К = 3;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимПроверкаПрм1К
        {
            get { return _кнопкаРежимПроверкаПрм1К; }
            set
            {
                _кнопкаРежимПроверкаПрм1К = value;
                if (_кнопкаРежимПроверкаПрм1К) РежимРаботы1К = 4;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимВыкл2К
        {
            get { return _кнопкаРежимВыкл2К; }
            set
            {
                _кнопкаРежимВыкл2К = value;
                if (_кнопкаРежимВыкл2К) РежимРаботы2К = 0;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимРабота2К
        {
            get { return _кнопкаРежимРабота2К; }
            set
            {
                _кнопкаРежимРабота2К = value;
                if (_кнопкаРежимРабота2К) РежимРаботы2К = 1;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимШлейф2К
        {
            get { return _кнопкаРежимШлейф2К; }
            set
            {
                _кнопкаРежимШлейф2К = value;
                if (_кнопкаРежимШлейф2К) РежимРаботы2К = 2;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимПроверкаПрмПрд2К
        {
            get { return _кнопкаРежимПроверкаПрмПрд2К; }
            set
            {
                _кнопкаРежимПроверкаПрмПрд2К = value;
                if (_кнопкаРежимПроверкаПрмПрд2К) РежимРаботы2К = 3;
                OnParameterChanged();
            }
        }

        public bool КнопкаРежимПроверкаПрм2К
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

        //private  void SetTimeoutForLamp(ref IDisposable timerLamp, string lampName, int timeout)
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

        private void ВключитьЛампочкиВкл1Комплекта()
        {
            _лампочка1КомплектПрдДаб5ГВкл = true;
            _лампочка1КомплектПрмДаб5ГВкл = true;
        }

        private void ВключитьЛампочкиВкл2Комплекта()
        {
            _Лампочка2КомплектПрдДаб5ГВкл = true;
            _Лампочка2КомплектПрмДаб5ГВкл = true;
        }


        private void ВыключитьЛампочкиВкл1Комплекта()
        {
            _лампочка1КомплектПрдДаб5ГВкл = false;
            _лампочка1КомплектПрмДаб5ГВкл = false;
        }

        private void ВыключитьЛампочкиВкл2Комплекта()
        {
            _Лампочка2КомплектПрдДаб5ГВкл = false;
            _Лампочка2КомплектПрмДаб5ГВкл = false;
        }


        private void СброситьВсеТаймерыИСвязанныеСНимиЛампочки1Комплекта()
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

        private void СброситьВсеТаймерыИСвязанныеСНимиЛампочки2Комплекта()
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

        private void TurnOff()
        {
            ВыключитьЛампочкиВкл1Комплекта();
            ВыключитьЛампочкиВкл2Комплекта();
            СброситьВсеТаймерыИСвязанныеСНимиЛампочки1Комплекта();
            СброситьВсеТаймерыИСвязанныеСНимиЛампочки2Комплекта();
        }

        public void SetDefaultParameters()
        {
            РежимРучн = true;
            КомплектПрмПрд1 = true;
            КомплектБП1 = true;
            РежимРаботы1К = 1;
            РежимРаботы2К = 1;
        }

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }
    }
}
