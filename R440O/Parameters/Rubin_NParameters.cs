using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R440O.Parameters
{
    class Rubin_NParameters
    {

        #region Переключатели
        #region Rubin_NПереключательГрупСкор
        /// <summary>
        /// Положение переключателя Rubin_NПереключательГрупСкор
        /// </summary>
        private static int _Rubin_NПереключательГрупСкор = 1;

        public static int Rubin_NПереключательГрупСкор
        {
            get { return _Rubin_NПереключательГрупСкор; }
            set
            {
                if (value > 0 && value < 5) _Rubin_NПереключательГрупСкор = value;
            }
        }

        /// <summary>
        /// Названия положений переключателя Rubin_NПереключательГрупСкор
        /// </summary>
        private static string[] Rubin_NПоложенияПереключательГрупСкор = {
            "96",
            "144",
            "240",
            "480"
        };
        #endregion

        #region Rubin_NПереключательКонтроль
        /// <summary>
        /// Положение переключателя Rubin_NПереключательКонтроль
        /// </summary>
        private static int _Rubin_NПереключательКонтроль = 1;

        public static int Rubin_NПереключательКонтроль
        {
            get { return _Rubin_NПереключательКонтроль; }
            set
            {
                if (value > 0 && value < 5) _Rubin_NПереключательКонтроль = value;
            }
        }

        /// <summary>
        /// Названия положений переключателя Rubin_NПереключательКонтроль
        /// </summary>
        private static string[] Rubin_NПоложенияПереключательКонтроль = {
            "откл",
            "1",
            "2",
            "3"
        };
        #endregion

        #region Rubin_NПереключательN5063_2кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN5063_2кБод
        /// </summary>
        private static int _Rubin_NПереключательN5063_2кБод = 1;

        public static int Rubin_NПереключательN5063_2кБод
        {
            get { return _Rubin_NПереключательN5063_2кБод; }
            set
            {
                if (value > 0 && value < 5) _Rubin_NПереключательN5063_2кБод = value;
            }
        }

        /// <summary>
        /// Названия положений переключателя Rubin_NПереключательN5063_2кБод
        /// </summary>
        private static string[] Rubin_NПоложенияПереключательN5063_2кБод = {
            "0",
            "1",
            "2",
            "3"
        };
        #endregion

        #region Rubin_NПереключательN5063_6812кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN5063_6812кБод
        /// </summary>
        private static int _Rubin_NПереключательN5063_6812кБод = 1;

        public static int Rubin_NПереключательN5063_6812кБод
        {
            get { return _Rubin_NПереключательN5063_6812кБод; }
            set
            {
                if (value > 0 && value < 19) _Rubin_NПереключательN5063_6812кБод = value;
            }
        }


        #endregion

        #region Rubin_NПереключательN5063_48кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN5063_48кБод
        /// </summary>
        private static int _Rubin_NПереключательN5063_48кБод = 1;

        public static int Rubin_NПереключательN5063_48кБод
        {
            get { return _Rubin_NПереключательN5063_48кБод; }
            set
            {
                if (value > 0 && value < 11) _Rubin_NПереключательN5063_48кБод = value;
            }
        }
        #endregion

        #region Rubin_NПереключательN4923_2кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN4923_2кБод
        /// </summary>
        private static int _Rubin_NПереключательN4923_2кБод = 1;

        public static int Rubin_NПереключательN4923_2кБод
        {
            get { return _Rubin_NПереключательN4923_2кБод; }
            set
            {
                if (value > 0 && value < 5) _Rubin_NПереключательN4923_2кБод = value;
            }
        }

        /// <summary>
        /// Названия положений переключателя Rubin_NПереключательN4923_2кБод
        /// </summary>
        private static string[] Rubin_NПоложенияПереключательN4923_2кБод = {
            "0",
            "1",
            "2",
            "3"
        };
        #endregion

        #region Rubin_NПереключательN4923_6812кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN4923_6812кБод
        /// </summary>
        private static int _Rubin_NПереключательN4923_6812кБод = 1;

        public static int Rubin_NПереключательN4923_6812кБод
        {
            get { return _Rubin_NПереключательN4923_6812кБод; }
            set
            {
                if (value > 0 && value < 19) _Rubin_NПереключательN4923_6812кБод = value;
            }
        }


        #endregion

        #region Rubin_NПереключательN4923_48кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN4923_48кБод
        /// </summary>
        private static int _Rubin_NПереключательN4923_48кБод = 1;

        public static int Rubin_NПереключательN4923_48кБод
        {
            get { return _Rubin_NПереключательN4923_48кБод; }
            set
            {
                if (value > 0 && value < 11) _Rubin_NПереключательN4923_48кБод = value;
            }
        }
        #endregion

        #region Rubin_NПереключательN4963_2кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN4963_2кБод
        /// </summary>
        private static int _Rubin_NПереключательN4963_2кБод = 1;

        public static int Rubin_NПереключательN4963_2кБод
        {
            get { return _Rubin_NПереключательN4963_2кБод; }
            set
            {
                if (value > 0 && value < 5) _Rubin_NПереключательN4963_2кБод = value;
            }
        }

        /// <summary>
        /// Названия положений переключателя Rubin_NПереключательN4963_2кБод
        /// </summary>
        private static string[] Rubin_NПоложенияПереключательN4963_2кБод = {
            "0",
            "1",
            "2",
            "3"
        };
        #endregion

        #region Rubin_NПереключательN4963_6812кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN4963_6812кБод
        /// </summary>
        private static int _Rubin_NПереключательN4963_6812кБод = 1;

        public static int Rubin_NПереключательN4963_6812кБод
        {
            get { return _Rubin_NПереключательN4963_6812кБод; }
            set
            {
                if (value > 0 && value < 19) _Rubin_NПереключательN4963_6812кБод = value;
            }
        }


        #endregion

        #region Rubin_NПереключательN4963_48кБод
        /// <summary>
        /// Положение переключателя Rubin_NПереключательN4963_48кБод
        /// </summary>
        private static int _Rubin_NПереключательN4963_48кБод = 1;

        public static int Rubin_NПереключательN4963_48кБод
        {
            get { return _Rubin_NПереключательN4963_48кБод; }
            set
            {
                if (value > 0 && value < 11) _Rubin_NПереключательN4963_48кБод = value;
            }
        }
        #endregion
        #endregion

        #region Тумблеры
        /// <summary>
        /// Возможные состояния: +, -
        /// </summary>
        public static bool ТумблерПолярность
        {
            get { return _тумблерПолярность; }
            set { _тумблерПолярность = value; }
        }

        private static bool _тумблерПолярность = true;
        private static bool _тумблерРнБас1 = true;
        private static bool _тумблерРнБас2 = true;
        private static bool _тумблерРнБас3 = true;

        /// <summary>
        /// Возможные состояния: 4.8, 5.2
        /// </summary>
        public static bool ТумблерРнБас1
        {
            get { return _тумблерРнБас1; }
            set { _тумблерРнБас1 = value; }
        }

        /// <summary>
        /// Возможные состояния: 4.8, 5.2
        /// </summary>
        public static bool ТумблерРнБас2
        {
            get { return _тумблерРнБас2; }
            set { _тумблерРнБас2 = value; }
        }

        /// <summary>
        /// Возможные состояния: 4.8, 5.2
        /// </summary>
        public static bool ТумблерРнБас3
        {
            get { return _тумблерРнБас3; }
            set { _тумблерРнБас3 = value; }
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

        public static bool Rubin_NКнопкаОткл = false;
        public static bool Rubin_NКнопкаВкл = false;

    }
}
