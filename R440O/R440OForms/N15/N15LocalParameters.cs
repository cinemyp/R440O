﻿using R440O.BaseClasses;

namespace R440O.R440OForms.N15
{
    public class N15LocalParameters
    {
        private static N15LocalParameters instance;
        public static N15LocalParameters getInstance()
        {
            if (instance == null)
                instance = new N15LocalParameters();
            return instance;
        }
        public ITestModule TestModuleRef { get; set; }

        public delegate void TestModuleHandler(ITestModule module);
        public  event TestModuleHandler Action;
        public delegate void ParameterChangedHandler();
        public  event ParameterChangedHandler ParameterChanged;

        private  void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
            OnAction();
        }

        private  void OnAction()
        {
            Action?.Invoke(TestModuleRef);
        }

        #region Тумблеры левая часть
        private  bool _локТумблерЦ300М1;
        private  bool _локТумблерЦ300М2;
        private  bool _локТумблерЦ300М3;
        private  bool _локТумблерЦ300М4;
        private  bool _локТумблерН12С;
        private  bool _локТумблерМшу;
        private  bool _локТумблерБМА1;
        private  bool _локТумблерБМА2;
        private  bool _локТумблерА205Base; //чтобы при записи локальных параметров в него не записывалось значение _локТумблерА20512
        private  bool _локТумблерА20512;
        private  bool _локТумблерА403;
        private  bool _локТумблерАФСС;
        private  bool _локТумблерА1;
        private  bool _локТумблерК1_1;
        private  bool _локТумблерК1_2;
        private  bool _локТумблерБ1_1;
        private  bool _локТумблерБ1_2;
        private  bool _локТумблерБ2_1;
        private  bool _локТумблерБ2_2;
        private  bool _локТумблерБ3_1;
        private  bool _локТумблерБ3_2;
        private  bool _локТумблерДАБ_5;
        private  bool _локТумблерР_Н;

        public  bool локТумблерЦ300М1
        {
            get { return _локТумблерЦ300М1; }
            set { _локТумблерЦ300М1 = value;OnParameterChanged();  }
        }

        public  bool локТумблерЦ300М2
        {
            get { return _локТумблерЦ300М2; }
            set { _локТумблерЦ300М2 = value;OnParameterChanged(); }
        }

        public  bool локТумблерЦ300М3
        {
            get { return _локТумблерЦ300М3; }
            set { _локТумблерЦ300М3 = value;OnParameterChanged(); }
        }

        public  bool локТумблерЦ300М4
        {
            get { return _локТумблерЦ300М4; }
            set { _локТумблерЦ300М4 = value;OnParameterChanged(); }
        }

        public  bool локТумблерН12С
        {
            get { return _локТумблерН12С; }
            set { _локТумблерН12С = value;OnParameterChanged(); }
        }

        public  bool локТумблерМШУ
        {
            get { return _локТумблерМшу; }
            set { _локТумблерМшу = value;OnParameterChanged(); }
        }

        public  bool локТумблерБМА_1
        {
            get { return _локТумблерБМА1; }
            set { _локТумблерБМА1 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБМА_2
        {
            get { return _локТумблерБМА2; }
            set { _локТумблерБМА2 = value;OnParameterChanged(); }
        }

        public  bool локТумблерА205Base
        {
            get { return _локТумблерА205Base; }
            set { _локТумблерА205Base = value;OnParameterChanged(); }
        }

        public  bool локТумблерА20512
        {
            get { return _локТумблерА20512; }
            set { _локТумблерА20512 = value;OnParameterChanged(); }
        }

        public  bool локТумблерАФСС
        {
            get { return _локТумблерАФСС; }
            set { _локТумблерАФСС = value;OnParameterChanged(); }
        }

        public  bool локТумблерА1
        {
            get { return _локТумблерА1; }
            set { _локТумблерА1 = value;OnParameterChanged(); }
        }

        public  bool локТумблерА403
        {
            get { return _локТумблерА403; }
            set { _локТумблерА403 = value;OnParameterChanged(); }
        }

        public  bool локТумблерК1_1
        {
            get { return _локТумблерК1_1; }
            set { _локТумблерК1_1 = value;OnParameterChanged(); }
        }

        public  bool локТумблерК1_2
        {
            get { return _локТумблерК1_2; }
            set { _локТумблерК1_2 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБ1_1
        {
            get { return _локТумблерБ1_1; }
            set { _локТумблерБ1_1 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБ1_2
        {
            get { return _локТумблерБ1_2; }
            set { _локТумблерБ1_2 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБ2_1
        {
            get { return _локТумблерБ2_1; }
            set { _локТумблерБ2_1 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБ2_2
        {
            get { return _локТумблерБ2_2; }
            set { _локТумблерБ2_2 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБ3_1
        {
            get { return _локТумблерБ3_1; }
            set { _локТумблерБ3_1 = value;OnParameterChanged(); }
        }

        public  bool локТумблерБ3_2
        {
            get { return _локТумблерБ3_2; }
            set { _локТумблерБ3_2 = value;OnParameterChanged(); }
        }

        public  bool локТумблерДАБ_5
        {
            get { return _локТумблерДАБ_5; }
            set { _локТумблерДАБ_5 = value;OnParameterChanged(); }
        }

        public  bool локТумблерР_Н
        {
            get { return _локТумблерР_Н; }
            set { _локТумблерР_Н = value;OnParameterChanged(); }
        }
        #endregion

        #region Кнопки и Тумблеры правая часть (Значения в памяти блока)
        private  bool _локТумблер5Мгц;
        private  bool _локТумблерАнтЭкв;
        private  int _локКнопкаН13;
        private  bool _локКнопкаН13_1;
        private  bool _локКнопкаН13_2;
        private  bool _локКнопкаН13_12;

        /// <summary>
        /// Значение, хранимое в памяти блока для тумблера 5Мгц
        /// true - 2, false - 3
        /// </summary>
        public  bool локТумблер5Мгц
        {
            get { return _локТумблер5Мгц; }
            set { _локТумблер5Мгц = value;OnParameterChanged(); }
        }

        /// <summary>
        /// Значение, хранимое в памяти блока для тумблера Антенна/Эквивалент
        /// true - Антенна, false - Эквивалент
        /// </summary>
        public  bool локТумблерАнтЭкв
        {
            get { return _локТумблерАнтЭкв; }
            set
            {
                _локТумблерАнтЭкв = value;
                N15Parameters.getInstance().ТумблерАнтЭкв = value;OnParameterChanged();
            }
        }

        public  bool локКнопкаН13_1
        {
            get { return _локКнопкаН13_1; }
            set
            {
                _локКнопкаН13_1 = value;
                if (value) N15Parameters.getInstance().КнопкаН13 = 1;OnParameterChanged();
            }
        }

        public  bool локКнопкаН13_2
        {
            get { return _локКнопкаН13_2; }
            set
            {
                _локКнопкаН13_2 = value;
                if (value) N15Parameters.getInstance().КнопкаН13 = 2;OnParameterChanged();
            }
        }

        public  bool локКнопкаН13_12
        {
            get { return _локКнопкаН13_12; }
            set
            {
                _локКнопкаН13_12 = value;
                if (value) N15Parameters.getInstance().КнопкаН13 = 3;OnParameterChanged();
            }
        }
        #endregion
        public  void SetDefaultParameters()
        {
            _локТумблерЦ300М1 = false;
            _локТумблерЦ300М2 = false;
            _локТумблерЦ300М3 = false;
            _локТумблерЦ300М4 = false;
            _локТумблерН12С = false;
            _локТумблерМшу = false;
            _локТумблерБМА1 = false;
            _локТумблерБМА2 = false;
            _локТумблерА205Base = false; //чтобы при записи локальных параметров в него не записывалось значение _локТумблерА20512
            _локТумблерА20512 = false;
            _локТумблерА403 = false;
            _локТумблерАФСС = false;
            _локТумблерА1 = false;
            _локТумблерК1_1 = false;
            _локТумблерК1_2 = false;
            _локТумблерБ1_1 = false;
            _локТумблерБ1_2 = false;
            _локТумблерБ2_1 = false;
            _локТумблерБ2_2 = false;
            _локТумблерБ3_1 = false;
            _локТумблерБ3_2 = false;
            _локТумблерДАБ_5 = false;
            _локТумблерР_Н = false;

            _локТумблер5Мгц = false;
            _локТумблерАнтЭкв = false;
            _локКнопкаН13 = 0;
            _локКнопкаН13_1 = false;
            _локКнопкаН13_2 = false;
            _локКнопкаН13_1 = false;

            
        }
    }
}
