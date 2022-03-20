﻿using R440O.R440OForms.K01M_01;

namespace R440O.R440OForms.N18_M_AngleSwitch
{
    public class N18_M_AngleSwitchParameters
    {
        private static N18_M_AngleSwitchParameters instance;
        public static N18_M_AngleSwitchParameters getInstance()
        {
            if (instance == null)
                instance = new N18_M_AngleSwitchParameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        public int _гнездоПРМ1 = 0;
        public int _гнездоПРМ2 = 0;
        public int _гнездоПРМ3 = 0;
        public int _гнездоПРМ4 = 0;
        public int _гнездоК11 = 0;
        public int _гнездоК12 = 0;

        private void СброситьК1()
        {
            _гнездоПРМ1 = _гнездоПРМ1 == 1 ? 0 : _гнездоПРМ1;
            _гнездоПРМ2 = _гнездоПРМ2 == 1 ? 0 : _гнездоПРМ2;
            _гнездоПРМ3 = _гнездоПРМ3 == 1 ? 0 : _гнездоПРМ3;
            _гнездоПРМ4 = _гнездоПРМ4 == 1 ? 0 : _гнездоПРМ4;
            _гнездоК11 = _гнездоК11 == 1 ? 0 : _гнездоК11;
            _гнездоК12 = _гнездоК12 == 1 ? 0 : _гнездоК12;
        }

        private void СброситьК2()
        {
            _гнездоПРМ1 = _гнездоПРМ1 == 2 ? 0 : _гнездоПРМ1;
            _гнездоПРМ2 = _гнездоПРМ2 == 2 ? 0 : _гнездоПРМ2;
            _гнездоПРМ3 = _гнездоПРМ3 == 2 ? 0 : _гнездоПРМ3;
            _гнездоПРМ4 = _гнездоПРМ4 == 2 ? 0 : _гнездоПРМ4;
            _гнездоК11 = _гнездоК11 == 2 ? 0 : _гнездоК11;
            _гнездоК12 = _гнездоК12 == 2 ? 0 : _гнездоК12;
        }

        public int ГнездоПРМ1
        {
            get { return _гнездоПРМ1; }
            set
            {
                if (value == 1)
                    СброситьК1();
                else if (value == 2)
                    СброситьК2();
                _гнездоПРМ1 = value;
                ResetParameters();
            }
        }

        public int ГнездоПРМ2
        {
            get { return _гнездоПРМ2; }
            set
            {
                if (value == 1)
                    СброситьК1();
                else if (value == 2)
                    СброситьК2();
                _гнездоПРМ2 = value;
                ResetParameters();
            }
        }
        public int ГнездоПРМ3
        {
            get { return _гнездоПРМ3; }
            set
            {
                if (value == 1)
                    СброситьК1();
                else if (value == 2)
                    СброситьК2();
                _гнездоПРМ3 = value;
                ResetParameters();
            }
        }
        public int ГнездоПРМ4
        {
            get { return _гнездоПРМ4; }
            set
            {
                if (value == 1)
                    СброситьК1();
                else if (value == 2)
                    СброситьК2();
                _гнездоПРМ4 = value;
                ResetParameters();
            }
        }
        public int ГнездоК11
        {
            get { return _гнездоК11; }
            set
            {
                if (value == 1)
                    СброситьК1();
                else if (value == 2)
                    СброситьК2();
                _гнездоК11 = value;
                ResetParameters();
            }
        }
        public int ГнездоК12
        {
            get { return _гнездоК12; }
            set
            {
                if (value == 1)
                    СброситьК1();
                else if (value == 2)
                    СброситьК2();
                _гнездоК12 = value;
                ResetParameters();
            }
        }

        #region Cобытие

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

        #endregion
    }
}
