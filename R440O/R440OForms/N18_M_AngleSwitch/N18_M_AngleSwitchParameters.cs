using R440O.R440OForms.K01M_01;

namespace R440O.R440OForms.N18_M_AngleSwitch
{
    public static class N18_M_AngleSwitchParameters
    {
        public static int _гнездоПРМ1 = 0;
        public static int _гнездоПРМ2 = 0;
        public static int _гнездоПРМ3 = 0;
        public static int _гнездоПРМ4 = 0;
        public static int _гнездоК11 = 0;
        public static int _гнездоК12 = 0;

        private static void СброситьК1()
        {
            _гнездоПРМ1 = _гнездоПРМ1 == 1 ? 0 : _гнездоПРМ1;
            _гнездоПРМ2 = _гнездоПРМ2 == 1 ? 0 : _гнездоПРМ2;
            _гнездоПРМ3 = _гнездоПРМ3 == 1 ? 0 : _гнездоПРМ3;
            _гнездоПРМ4 = _гнездоПРМ4 == 1 ? 0 : _гнездоПРМ4;
            _гнездоК11 = _гнездоК11 == 1 ? 0 : _гнездоК11;
            _гнездоК12 = _гнездоК12 == 1 ? 0 : _гнездоК12;
        }

        private static void СброситьК2()
        {
            _гнездоПРМ1 = _гнездоПРМ1 == 2 ? 0 : _гнездоПРМ1;
            _гнездоПРМ2 = _гнездоПРМ2 == 2 ? 0 : _гнездоПРМ2;
            _гнездоПРМ3 = _гнездоПРМ3 == 2 ? 0 : _гнездоПРМ3;
            _гнездоПРМ4 = _гнездоПРМ4 == 2 ? 0 : _гнездоПРМ4;
            _гнездоК11 = _гнездоК11 == 2 ? 0 : _гнездоК11;
            _гнездоК12 = _гнездоК12 == 2 ? 0 : _гнездоК12;
        }

        public static int ГнездоПРМ1
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

        public static int ГнездоПРМ2
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
        public static int ГнездоПРМ3
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
        public static int ГнездоПРМ4
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
        public static int ГнездоК11
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
        public static int ГнездоК12
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

        #endregion
    }
}
