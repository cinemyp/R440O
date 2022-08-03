using System.Drawing;
using ShareTypes.SignalTypes;

using System.Collections.Generic;
namespace R440O.R440OForms.N18_M
{
    using A205M_1;
    using A205M_2;
    using N15;
    using BMA_M_1;
    using BMB;
    using PU_K1_1;
    using K02M_01;

    public class N18_MParameters
    {
        private static N18_MParameters instance;
        public static N18_MParameters getInstance()
        {
            if (instance == null)
                instance = new N18_MParameters();
            return instance;
        }

        #region Лампочки

        //Лампочки
        public bool ЛампочкаК3ТЛГ1
        {
            get { return false; }
        }

        public bool ЛампочкаК3ТЛГ2
        {
            get { return false; }
        }

        public bool ЛампочкаК3ТЛГ3
        {
            get { return false; }
        }

        public bool ЛампочкаК3ТЛГ4
        {
            get { return false; }
        }

        public bool ЛампочкаСПСТест
        {
            get { return false; }
        }

        public bool ЛампочкаСПСИнформ
        {
            get { return false; }
        }

        public bool ЛампочкаПилотК1_1
        {
            get { return PU_K1_1Parameters.getInstance().КулонК1Подключен && K02M_01Parameters.getInstance().ЛампочкаПилот; }
        }

        public bool ЛампочкаПилотК1_2
        {
            get { return false; }
        }

        public bool ЛампочкаИнформК1_1
        {
            get { return PU_K1_1Parameters.getInstance().КулонК1Подключен && K02M_01Parameters.getInstance().ЛампочкаИнформ; }
        }

        public bool ЛампочкаИнформК1_2
        {
            get { return false; }
        }

        #endregion

        #region Переключатели

        #region Двухпозиционные

        private int _переключательВходБ22 = 1;
        private int _переключательВыход1РН = 1;
        private int _переключательВыход2РН = 1;
        private int _переключатель48ПрмЩв = 1;
        private int _переключательПрмСс2 = 3;
        private int _переключательПрмСс1 = 3;
        private int _переключательПрдБма12 = 6;
        private int _переключательПРД = 3;
        private int _переключательВходК121 = 1;
        private int _переключательПРМ1 = 3;


        /// <summary>
        /// 1 - б3-2,
        /// 2 - б3-1,
        /// </summary>
        public int ПереключательВходБ22
        {
            get { return _переключательВходБ22; }
            set
            {
                if (value > 0 && value < 3) _переключательВходБ22 = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - б1-1,
        /// 2 - даб-5
        /// </summary>
        public int ПереключательВыход1РН
        {
            get { return _переключательВыход1РН; }
            set
            {
                if (value > 0 && value < 3) _переключательВыход1РН = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - б1-2,
        /// 2 - даб-5
        /// </summary>
        public int ПереключательВыход2РН
        {
            get { return _переключательВыход2РН; }
            set
            {
                if (value > 0 && value < 3) _переключательВыход2РН = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - б2,
        /// 2 - даб-5
        /// </summary>
        public int Переключатель48ПрмЩв
        {
            get { return _переключатель48ПрмЩв; }
            set
            {
                if (value > 0 && value < 3) _переключатель48ПрмЩв = value;
                OnParameterChanged();
            }
        }

        #endregion

        /// <summary>
        /// 1 - прм-2,
        /// 2 - б3-2,
        /// 3 - б2-2,
        /// 4 - б1-2,
        /// 5 - даб-5
        /// </summary>
        public int ПереключательПрмСс2
        {
            get { return _переключательПрмСс2; }
            set
            {
                if (value > 0 && value < 6) _переключательПрмСс2 = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - прм-1,
        /// 2 - б3-1,
        /// 3 - б2-1,
        /// 4 - б1-1,
        /// 5 - даб-5
        /// </summary>
        public int ПереключательПрмСс1
        {
            get { return _переключательПрмСс1; }
            set
            {
                if (value > 0 && value < 6) _переключательПрмСс1 = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - тлф-1/2,
        /// 2 - тлф-2/3,
        /// 3 - тлф-3/1,
        /// 4 - тлф-1/3,
        /// 5 - тлф-2/1,
        /// 6 - тлф-3/2,
        /// 7 - мод1,
        /// 8 - мод2,
        /// 9 - к1-2-1
        /// </summary>
        public int ПереключательПрдБма12
        {
            get { return _переключательПрдБма12; }
            set
            {
                if (value > 0 && value < 10) _переключательПрдБма12 = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - даб-5,
        /// 2 - а1,
        /// 3 - бма,
        /// 4 - тлг,
        /// 5 - сс
        /// </summary>
        public int ПереключательПРД
        {
            get { return _переключательПРД; }
            set
            {
                if (value > 0 && value < 6) _переключательПРД = value;
                N15Parameters.getInstance().ResetDiscret();
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1 - откл,
        /// 2 - бма-1,
        /// 3 - бма-2,
        /// 4 - щв
        /// </summary>
        public int ПереключательВходК121
        {
            get { return _переключательВходК121; }
            set
            {
                if (value > 0 && value < 5) _переключательВходК121 = value;
                OnParameterChanged();
                A205M_1Parameters.getInstance().ResetParameters();
                A205M_2Parameters.ResetParameters();
                N15Parameters.getInstance().ResetParameters();
            }
        }


        /// <summary>
        /// 1 - б3-1,
        /// 2 - б2-1,
        /// 3 - даб-5,
        /// 4 - б1-1,
        /// 5 - р-н
        /// </summary>
        public int ПереключательПРМ1
        {
            get { return _переключательПРМ1; }
            set
            {
                if (value > 0 && value < 6) _переключательПРМ1 = value;
                OnParameterChanged();
            }
        }

        private int _переключательПРМ2 = 3;

        /// <summary>
        /// 1 - б3-2,
        /// 2 - б2-2,
        /// 3 - даб-5,
        /// 4 - б1-2,
        /// р-н
        /// </summary>
        public int ПереключательПРМ2
        {
            get { return _переключательПРМ2; }
            set
            {
                if (value > 0 && value < 6) _переключательПРМ2 = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region Тумблеры

        private bool _тумблерДАБ5 = false;
        private bool _тумблерКАУ_ПРМ = false;
        private bool _тумблерПРД_СС = false;
        private bool _тумблерТЛФ_ПРМ = false;

        public bool ТумблерДАБ5
        {
            get { return _тумблерДАБ5; }
            set
            {
                _тумблерДАБ5 = value;
                OnParameterChanged();
            }
        }

        public bool ТумблерКАУ_ПРМ
        {
            get { return _тумблерКАУ_ПРМ; }
            set
            {
                _тумблерКАУ_ПРМ = value;
                OnParameterChanged();
            }
        }

        public bool ТумблерПРД_СС
        {
            get { return _тумблерПРД_СС; }
            set
            {
                _тумблерПРД_СС = value;
                OnParameterChanged();
            }
        }

        public bool ТумблерТЛФ_ПРМ
        {
            get { return _тумблерТЛФ_ПРМ; }
            set
            {
                _тумблерТЛФ_ПРМ = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region Гнезда

        private System.Random rand = new System.Random();

        // Соедененые входы
        public int[] Соединения = new int[77];

        public Color[] Цвет_соеденения = new Color[77];

        public int номер_первого_гнезда = -1;

        public void Соеденить(int номер_гнезда)
        {
            if (номер_первого_гнезда == -1)
            {
                if (Соединения[номер_гнезда] == 0)
                {
                    номер_первого_гнезда = номер_гнезда;
                }
                else
                {
                    Соединения[Соединения[номер_гнезда]] = 0;
                    Соединения[номер_гнезда] = 0;
                }
            }
            else
            {
                if (номер_первого_гнезда != номер_гнезда && Соединения[номер_гнезда] == 0)
                {
                    Соединения[номер_первого_гнезда] = номер_гнезда;
                    Соединения[номер_гнезда] = номер_первого_гнезда;

                    Цвет_соеденения[номер_первого_гнезда] = Color.FromArgb(255, rand.Next(127), 128 + rand.Next(127), rand.Next(127));
                    Цвет_соеденения[номер_гнезда] = Цвет_соеденения[номер_первого_гнезда];
                    номер_первого_гнезда = -1;
                }
                else
                {
                    номер_первого_гнезда = -1;
                }
            }
            OnParameterChanged();
        }

        #region Может потом пригодится

        //private  string _получить_название_гнезда(int n)
        //{
        //    string название = string.Empty ;
        //    if (n < 1)
        //        return название;
        //    string[] тлф =   
        //    { 
        //        "Б1-1" ,
        //        "ЩВ1" ,
        //        "Б1-2" ,
        //        "ЩВ2" ,
        //        "Б1-1" ,
        //        "ЩВ3" , 
        //        "Б1-2" , 
        //        "БМА1" , 
        //        "ЩВ1" ,
        //        "БМА2" , 
        //        "К1-2" , 
        //        "БМА1" , 
        //        "ЩВ1" , 
        //        "К1-2"
        //    };
        //    string[] тлг =
        //    {
        //        "Б1-1" , "ЩВ1" , "Б1-2" ,   "ЩВ2" , "Б1-1"
        //    };

        //    if (n < 28)
        //    {

        //        if (n < 20)
        //        {
        //            название += "1кан ";
        //            название += "Коммутация ПРМ режимов ";
        //            if (n < 15)
        //            {
        //                название += "ТЛФ ";
        //                название += тлф[n - 1];
        //            }
        //            else
        //            {
        //                название += "ТЛГ ";
        //                название += тлф[n - 15];
        //            }
        //        }
        //        else
        //        {
        //            название += "КОНТРОЛЬ ПРМ ";
        //            if (n < 22)
        //            {
        //                название += "ТЛФ ";
        //                название += n - 19;
        //            }
        //            else
        //            {
        //                if (n < 26)
        //                {
        //                    название += "ТЛГ ";
        //                    название += n - 21;
        //                }
        //                else
        //                {
        //                    название += "СПС ";
        //                    название += n - 25;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (n < 51)
        //        {

        //            if (n < 45)
        //            {
        //                название += "2кан ";
        //                название += "Коммутация ПРМ режимов ";
        //                if (n < 40)
        //                {
        //                    название += "ТЛФ ";
        //                    название += тлф[n - 28];
        //                }
        //                else
        //                {
        //                    название += "ТЛГ ";
        //                    название += тлф[n - 40];
        //                }
        //            }
        //            else
        //            {
        //                название += "КОНТРОЛЬ ПРД ";
        //                switch (n)
        //                {
        //                    case 45:
        //                        {
        //                            название += "ВОЗБ ТЛФ";
        //                            break;
        //                        }
        //                    case 46:
        //                        {
        //                            название += "ВОЗБ ТЛГ";
        //                            break;
        //                        }
        //                    case 47:
        //                        {
        //                            название += "А1 ТЛГ 1";
        //                            break;
        //                        }
        //                    case 48:
        //                        {
        //                            название += "А1 ТЛГ 2";
        //                            break;
        //                        }
        //                    case 49:
        //                        {
        //                            название += "СПС 1";
        //                            break;
        //                        }
        //                    case 50:
        //                        {
        //                            название += "СПС 2";
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (n < 63)
        //            {
        //                if (n < 40)
        //                {
        //                    название += "ТЛФ ";
        //                    название += тлф[n - 51];
        //                }
        //                else
        //                {
        //                    название += "ТЛФ ";
        //                    название += тлф[n - 51];
        //                }
        //            }
        //        }
        //    }
        //    return название;
        //}


        //public  bool Проверить_комутацию(string гнездо1, string гнездо2)
        //{
        //    string s1, s2;
        //    for (int i = 1; i < 76; i++)
        //    {
        //        s1 = _получить_название_гнезда(i);
        //        s2 =  _получить_название_гнезда(Соединения[i]);
        //        if (s1 == гнездо1 &&
        //             s2 == гнездо2)
        //            return true;
        //    }
        //    return false;
        //}

        #endregion

        public bool Проверить_комутацию(int a, int b)
        {
            return Соединения[a] == b;
        }

        public bool Проверить_комутацию(ГнездаН18 a, ГнездаН18 b)
        {
            return Проверить_комутацию((int)a, (int)b);
        }

        #endregion

        public delegate void ParameterChangedHandler();

        public event ParameterChangedHandler ParameterChanged;

        /// <summary>
        /// Вызов события, что значения параметров данной формы изменились.
        /// </summary>
        private void OnParameterChanged()
        {
            N15Parameters.getInstance().ResetDiscret();
            //BMA_M_1Parameters.getInstance().ResetParameters();
            BMBParameters.getInstance().ResetParameters();
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }
    }


    public enum ГнездаН18
    {
        КоммутацияПрм_Канал1_Б11 = 1,
        КоммутацияПрм_Канал2_Б11 = 28,
        КоммутацияПрм_Канал3_Б11 = 51,
        КоммутацияПрм_Канал1_БМА1 = 8,
        КоммутацияПрм_Канал1_БМА2 = 10,
        КоммутацияПрм_Канал1_К12 = 11,
        Контроль_Прм_Тлф1 = 20

        // TODO: добавить гнезда в этот енум по мере необходимости.
    }
}
