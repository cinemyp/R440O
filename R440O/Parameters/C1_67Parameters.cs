using R440O.JsonAdapter;
using System;

namespace R440O.Parameters
{
    internal class C1_67Parameters
    {
        private static C1_67Parameters instance;
        public static C1_67Parameters getInstance()
        {
            if (instance == null)
                instance = new C1_67Parameters();
            return instance;
        }

        #region ПереключательУсиление

        /// <summary>
        /// Положение переключателя усиление
        /// </summary>
        private int _C1_67ПереключательУсиление = 1;

        public int C1_67ПереключательУсиление
        {
            get { return _C1_67ПереключательУсиление; }
            set { if (value > -1 && value < 14) _C1_67ПереключательУсиление = value; }
        }

        /// <summary>
        /// Названия положений переключателя усиление
        /// </summary>
        private string[] C1_67ПоложенияПереключательУсиление =
        {
            "20",
            "10",
            "5",
            "2",
            "1",
            "0.5",
            "0.2",
            "0.1",
            "0.05",
            "0.02",
            "0.01",
            "0.005"
        };

        #endregion

        #region ПереключательДлительность

        /// <summary>
        /// Положение переключателя длительность
        /// </summary>
        private int _C1_67ПереключательДлительность = 1;

        public int C1_67ПереключательДлительность
        {
            get { return _C1_67ПереключательДлительность; }
            set { if (value > 0 && value < 19) _C1_67ПереключательДлительность = value; }
        }

        /// <summary>
        /// Названия положений переключателя длительность
        /// </summary>
        private string[] C1_67ПоложенияПереключательДлительность =
        {
            "50",
            "20",
            "10",
            "5",
            "2",
            "1",
            "0.5",
            "0.2",
            "0.1",
            "50",
            "20",
            "10",
            "5",
            "2",
            "1",
            "0.5",
            "0.2",
            "0.1",
        };

        #endregion

        #region ПереключательВыборПриемника

        private int _C1_67_N19ПереключательВыборПриемника = 1;

        public int C1_67_N19ПереключательВыборПриемника
        {
            get { return _C1_67_N19ПереключательВыборПриемника; }
            set { if (value > 0 && value < 6) _C1_67_N19ПереключательВыборПриемника = value; }
        }

        #endregion

        public int C1_67ПереключательУсилительУ = 1;
        public int C1_67ПереключательСинхронизация1 = 1;
        public int C1_67ПереключательСинхронизация2 = 1;

        #region Вращатели
        private int _c1_67РегуляторЯркость;
        private int _c1_67РегуляторФокус;
        private int _c1_67РегуляторШкала;
        private int _c1_67РегуляторГрубо;
        private int _c1_67РегуляторПлавно;
        private int _c1_67РегуляторСтаб;
        private int _c1_67РегуляторУсиление;
        private int _c1_67РегуляторСинхронизация;
        private int _c1_67РегуляторУровень;
        private int _c1_67РегуляторКоррекция;


        public int C1_67РегуляторЯркость
        {
            get { return _c1_67РегуляторЯркость; }
            set { if (value > -120 && value < 120) _c1_67РегуляторЯркость = value; }
        }

        public int C1_67РегуляторФокус
        {
            get { return _c1_67РегуляторФокус; }
            set { if (value > -120 && value < 120) _c1_67РегуляторФокус = value; }
        }
        public int C1_67РегуляторШкала
        {
            get { return _c1_67РегуляторШкала; }
            set { if (value > -120 && value < 120) _c1_67РегуляторШкала = value; }
        }
        public int C1_67РегуляторГрубо
        {
            get { return _c1_67РегуляторГрубо; }
            set { if (value > -120 && value < 120) _c1_67РегуляторГрубо = value; }
        }
        public int C1_67РегуляторПлавно
        {
            get { return _c1_67РегуляторПлавно; }
            set { if (value > -120 && value < 120) _c1_67РегуляторПлавно = value; }
        }
        public int C1_67РегуляторСтаб
        {
            get { return _c1_67РегуляторСтаб; }
            set { if (value > -120 && value < 120) _c1_67РегуляторСтаб = value; }
        }
        public int C1_67РегуляторУсиление
        {
            get { return _c1_67РегуляторУсиление; }
            set { if (value > -120 && value < 120) _c1_67РегуляторУсиление = value; }
        }
        public int C1_67РегуляторСинхронизация
        {
            get { return _c1_67РегуляторСинхронизация; }
            set { if (value > -120 && value < 120) _c1_67РегуляторСинхронизация = value; }
        }
        public int C1_67РегуляторУровень
        {
            get { return _c1_67РегуляторУровень; }
            set { if (value > -120 && value < 120) _c1_67РегуляторУровень = value; }
        }
        public int C1_67РегуляторКоррекция
        {
            get { return _c1_67РегуляторКоррекция; }
            set { if (value > -120 && value < 120) _c1_67РегуляторКоррекция = value; }
        }
        #endregion

        public bool C1_67_N19ТумблерВклВыкл = false;
        public string C1_67_N19Тумблер200_20 = "20";
        public string C1_67ТумблерX1X02 = "X02";
        private bool _C1_67ТумблерСеть = false;
        public bool C1_67ТумблерСеть
        {
            get { return _C1_67ТумблерСеть; }
            set { _C1_67ТумблерСеть = value;
            }
        }
        public bool C1_67Тумблер2kHz = false;
    }
}
