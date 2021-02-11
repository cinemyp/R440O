using System;
using System.Collections;
using System.Linq;
using R440O.R440OForms.K03M_01;

namespace R440O.R440OForms.K03M_01Inside
{
    static class K03M_01InsideParameters
    {
        #region Переключатели
        public static KulonIndexerClass Переключатели = new KulonIndexerClass();
        #endregion

        #region ТумблерИП и ВклВыкл
        private static bool _тумблерИП;
        private static bool _тумблерВклОткл;

        public static bool ТумблерИП
        {
            get
            {
                return _тумблерИП;
            }
            set
            {
                _тумблерИП = value;
                ResetParameters();
            }

        }
        public static bool ТумблерВклОткл
        {
            get
            {
                return _тумблерВклОткл;
            }
            set
            {
                _тумблерВклОткл = value;
                ResetParameters();
            }

        }

        #endregion

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
            K03M_01Parameters.ПересчитатьНайденоИлиНеНайдено();
            OnParameterChanged();
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
                K03M_01InsideParameters.ResetParameters();
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
