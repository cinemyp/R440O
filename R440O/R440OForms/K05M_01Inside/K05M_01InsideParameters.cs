using R440O.R440OForms.K03M_01;
using System.Collections;
using System.Linq;

namespace R440O.R440OForms.K05M_01Inside
{
    static class K05M_01InsideParameters
    {
        #region событие
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

        #region Переключатели

        public static KulonIndexerClass Переключатель = new KulonIndexerClass();

        #endregion

        #region Тумблеры B4, B7

        private static bool _ТумблерВ4;
        private static bool _ТумблерВ7;

        /// <summary>
        /// Вкл/выкл кода Баркера
        /// </summary>
        public static bool ТумблерВ4
        {
            get { return _ТумблерВ4; }
            set
            {
                _ТумблерВ4 = value;
                ResetParameters();
            }
        }

        /// <summary>
        /// Переключение сигналавы выход блока
        /// </summary>
        public static bool ТумблерВ7
        {
            get { return _ТумблерВ7; }
            set
            {
                _ТумблерВ7 = value;
                ResetParameters();
                K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
            }
        }

        #endregion

    }
    public class KulonIndexerClass
    {
        private int[] myArray = new int[31];
        public int this[int index]
        {
            get
            {
                return myArray[index];
            }
            set
            {
                if ((index >= 1 && index <= 3) || (index >= 5 && index <= 9))
                {
                    if (value >= 0 && value <= 7) 
                        myArray[index] = value;
                }
                else
                {
                    if (value >= 0 && value <= 1) myArray[index] = value;
                }
                K05M_01InsideParameters.ResetParameters();
                K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
            }
        }

        public int[] GetArray()
        {
            return myArray;
        }

        public int[] Синхропоследовательность1
        {
            get
            {
                return myArray.Take(9).ToArray();
            }
        }

        public int[] Синхропоследовательность2
        {
            get
            {
                return myArray.Skip(9).Take(20).ToArray();
            }
        }
    }

}
