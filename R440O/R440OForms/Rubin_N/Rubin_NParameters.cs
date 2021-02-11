using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R440O.R440OForms.Rubin_N
{
    class Rubin_NParameters
    {

        #region Переключатели

        private static int _ПереключательГрупСкор = 1;
        private static int _ПереключательКонтроль = 1;
        private static int _ПереключательN5063_2кБод = 1;
        private static int _ПереключательN5063_6812кБод = 1;
        private static int _ПереключательN5063_48кБод = 1;
        private static int _ПереключательN4923_2кБод = 1;
        private static int _ПереключательN4923_6812кБод = 1;
        private static int _ПереключательN4923_48кБод = 1;
        private static int _ПереключательN4963_2кБод = 1;
        private static int _ПереключательN4963_6812кБод = 1;
        private static int _ПереключательN4963_48кБод = 1;

        /// <summary>
        /// 1: 96, 2:144, 3:240, 4:480
        /// </summary>
        public static int ПереключательГрупСкор
        {
            get { return _ПереключательГрупСкор; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _ПереключательГрупСкор = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1: откл, 2:1, 3:2, 4:3
        /// </summary>
        public static int ПереключательКонтроль
        {
            get { return _ПереключательКонтроль; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _ПереключательКонтроль = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1: 0, 2: 1, 3: 2, 4: 3
        /// </summary>
        public static int ПереключательN5063_2кБод
        {
            get { return _ПереключательN5063_2кБод; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _ПереключательN5063_2кБод = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательN5063_6812кБод
        {
            get { return _ПереключательN5063_6812кБод; }
            set
            {
                if (value > 0 && value < 19)
                {
                    _ПереключательN5063_6812кБод = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательN5063_48кБод
        {
            get { return _ПереключательN5063_48кБод; }
            set
            {
                if (value > 0 && value < 11)
                {
                    _ПереключательN5063_48кБод = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1: 0, 2: 1, 3: 2, 4: 3
        /// </summary>
        public static int ПереключательN4923_2кБод
        {
            get { return _ПереключательN4923_2кБод; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _ПереключательN4923_2кБод = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательN4923_6812кБод
        {
            get { return _ПереключательN4923_6812кБод; }
            set
            {
                if (value > 0 && value < 19)
                {
                    _ПереключательN4923_6812кБод = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательN4923_48кБод
        {
            get { return _ПереключательN4923_48кБод; }
            set
            {
                if (value > 0 && value < 11)
                {
                    _ПереключательN4923_48кБод = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 1: 0, 2: 1, 3: 2, 4: 3
        /// </summary>
        public static int ПереключательN4963_2кБод
        {
            get { return _ПереключательN4963_2кБод; }
            set
            {
                if (value > 0 && value < 5)
                {
                    _ПереключательN4963_2кБод = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательN4963_6812кБод
        {
            get { return _ПереключательN4963_6812кБод; }
            set
            {
                if (value > 0 && value < 19)
                {
                    _ПереключательN4963_6812кБод = value;
                    OnParameterChanged();
                }
            }
        }

        public static int ПереключательN4963_48кБод
        {
            get { return _ПереключательN4963_48кБод; }
            set
            {
                if (value > 0 && value < 11)
                {
                    _ПереключательN4963_48кБод = value;
                    OnParameterChanged();
                }
            }
        }
        #endregion

        #region Тумблеры
        private static bool _тумблерПолярность = true;
        private static bool _тумблерРнБас1 = true;
        private static bool _тумблерРнБас2 = true;
        private static bool _тумблерРнБас3 = true;

        /// <summary>
        /// Возможные состояния: +, -
        /// </summary>
        public static bool ТумблерПолярность
        {
            get { return _тумблерПолярность; }
            set
            {
                _тумблерПолярность = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: 4.8, 5.2
        /// </summary>
        public static bool ТумблерРнБас1
        {
            get { return _тумблерРнБас1; }
            set
            {
                _тумблерРнБас1 = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: 4.8, 5.2
        /// </summary>
        public static bool ТумблерРнБас2
        {
            get { return _тумблерРнБас2; }
            set
            {
                _тумблерРнБас2 = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: 4.8, 5.2
        /// </summary>
        public static bool ТумблерРнБас3
        {
            get { return _тумблерРнБас3; }
            set
            {
                _тумблерРнБас3 = value;
                OnParameterChanged();
            }
        }
        #endregion

        #region Лампочки
        public static bool ЛампочкаРнБпНеиспр
        {
            get { return false; }
        }

        public static bool ЛампочкаРнБпМу
        {
            get { return false; }
        }

        public static bool ЛампочкаРнБпДу
        {
            get { return false; }
        }
        public static bool ЛампочкаРнБпПР2А
        {
            get { return false; }
        }
        public static bool ЛампочкаРнБп_5В
        {
            get { return false; }
        }
        public static bool ЛампочкаРнБп_27В
        {
            get { return false; }
        }

        public static bool ЛампочкаРнКОсн1
        {
            get { return false; }
        }
        public static bool ЛампочкаРнКОсн2
        {
            get { return false; }
        }
        public static bool ЛампочкаРнКОсн3
        {
            get { return false; }
        }
        public static bool ЛампочкаРнКРезервный
        {
            get { return false; }
        }
        public static bool ЛампочкаРнКРезервированиеВкл
        {
            get { return false; }
        }
        public static bool ЛампочкаРнКРезервированиеОткл
        {
            get { return false; }
        }
        public static bool ЛампочкаРнКТранзит
        {
            get { return false; }
        }

        public static bool ЛампочкаРнЦр_1
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦр_2
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦр_3
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦр_II1
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦр_II2
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦр_II3
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦрНеисправностьТи
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦрНеисправность48кГц
        {
            get { return false; }
        }
        public static bool ЛампочкаРнЦрНеисправностьЧтСи
        {
            get { return false; }
        }

        public static bool ЛампочкаРнБас1СрывСинхр
        {
            get { return false; }
        }

        public static bool ЛампочкаРнБас2СрывСинхр
        {
            get { return false; }
        }

        public static bool ЛампочкаРнБас3СрывСинхр
        {
            get { return false; }
        }
        #endregion

        public static bool КнопкаОткл = false;
        public static bool КнопкаВкл = false;

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        public static void OnParameterChanged()
        {
            if (ParameterChanged != null) ParameterChanged();
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }

    }
}
