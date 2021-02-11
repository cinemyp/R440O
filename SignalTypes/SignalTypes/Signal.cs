using System;
using System.Collections.Generic;
using System.Linq;
namespace ShareTypes.SignalTypes
{
    /// <summary>
    /// Параметры передаваемого сигнала.
    /// </summary>
    public class Signal
    {
        public Signal()
        {
            SelectedFlow = 9;
            SelectedGroup = 9;
        }

        /// <summary>
        /// Мощность сигнала
        /// </summary>
        public int Power;

        /// <summary>
        /// Частота сигнала
        /// </summary>
        public int Frequency = -1;

        /// <summary> 
        /// Номинальная частота волны, КГц.
        /// </summary>
        public int Wave = -1;

        /// <summary>
        /// Тип модуляции. ОФТ, ЧТ.
        /// </summary>
        public Модуляция Modulation;

        /// <summary>
        /// Групповая скорость передачи сигнала.
        /// </summary>
        public double GroupSpeed = -1;

        /// <summary>
        /// Уровень мощности передачи сигнала.
        /// </summary>
        public double Level = -1;

        /// <summary>
        /// Тип режима работы.
        /// True - синхронный режим работы, false - асинхронный режим работы.
        /// </summary>
        public bool Synchronization;

        /// <summary>
        /// Список всех элементов информационного сигнала.
        /// </summary>
        public List<SignalElement> Elements = new List<SignalElement>();

        /// <summary>
        /// Элементы информационного сигнала, содержащиеся в потоке, выбранном по заданным аппаратурой условиям. Уровень Б3.
        /// </summary>
        public List<SignalElement> SelectedFlowElements
        {
            get
            {
                var selectedElements = Elements.Where(elem => elem.Flow == SelectedFlow).ToList();
                return selectedElements;
            }
        }

        /// <summary>
        /// Элементы информационного сигнала, содержащиеся в потоке и группе, выбранных по заданным аппаратурой условиям. Уровень Б2.
        /// </summary>
        public List<SignalElement> SelectedGroupElements
        {
            get
            {
                var selectedElements = Elements.Where(elem => (elem.Flow == SelectedFlow && elem.Group == SelectedGroup)).ToList();
                return selectedElements;
            }
        }

        /// <summary>
        /// Текущий выбранный поток.
        /// </summary>
        public int SelectedFlow { get; private set; }

        /// <summary>
        /// Текущая выбранная группа.
        /// </summary>
        public int SelectedGroup { get; private set; }

        /// <summary>
        /// Выбрать информационный поток, если его номер соответствует настройкам аппаратуры. Уровень Б3.
        /// </summary>
        /// <param name="flow">Номер потока.</param>
        public void SelectFlow(int flow)
        {
            SelectedFlow = flow;
        }

        /// <summary>
        /// Выбрать информационную группу, если её номер соответствует настройкам аппаратуры. Уровень Б2.
        /// </summary>
        /// <param name="group">Номер группы.</param>
        public void SelectGroup(int group)
        {
            SelectedGroup = group;
        }

        /// <summary>
        /// Скорость передачи в определённом информационном канале. Уровень Б1.
        /// </summary>
        /// <param name="chanelNumber">Номер канала.</param>
        public double SpeedOfChanel(int chanelNumber)
        {
            if (Elements == null)
                return -1;
            var element = Elements.FirstOrDefault(elem => elem.Flow == SelectedFlow &&
                                                          elem.Group == SelectedGroup);
            if (element == null)
                return -1;
            return element.Chanels[chanelNumber].Speed;
        }

        /// <summary>
        /// Наличие информации в определённом информационном канале. Уровень Б1.
        /// </summary>
        /// <param name="chanelNumber">Номер канала.</param>
        public bool InformationOfChanel(int chanelNumber)
        {
            if (Elements == null)
                return false;
            var element = Elements.FirstOrDefault(elem => elem.Flow == SelectedFlow &&
                                                          elem.Group == SelectedGroup);
            if (element == null)
                return false;
            return element.Chanels[chanelNumber].Information;
        }

        /// <summary>
        /// Информация в определённом информационном канале. Уровень Б1.
        /// </summary>
        /// <param name="chanelNumber">Номер канала.</param>
        public string InformationStringOfChanel(int chanelNumber)
        {
            if (Elements == null)
                return null;
            var element = Elements.FirstOrDefault(elem => elem.Flow == SelectedFlow &&
                                                          elem.Group == SelectedGroup);
            if (element == null)
                return null;
            return element.Chanels[chanelNumber].InformationString;
        }

        /// <summary>
        /// Проверка, соответствуют ли друг другу скорости передачи информации.
        /// Условия выбраны таким образом, чтобы 4.8 и 5.2 соответствовали другу другу.
        /// </summary>
        /// <returns>Возвращает true, если скорости соответствуют</returns>
        public static bool IsEquivalentSpeed(double inputSpeed, double outputSpeed)
        {
            return Math.Abs(inputSpeed - outputSpeed) <= 0.5;
        }

        /// <summary>
        /// Возвращает инф. канал в соотвествии с номером группы, номером потока, номером канала
        /// </summary>
        /// <param name="chanelNumber"></param>
        /// <returns></returns>
        public Chanel ChanelbyNumber(int chanelNumber)
        {
            if (Elements == null)
                return null;
            var element = Elements.FirstOrDefault(elem => elem.Flow == SelectedFlow &&
                                                          elem.Group == SelectedGroup);
            return element.Chanels[chanelNumber];
        }

        /// <summary>
        /// Сигнал с кулона
        /// </summary>
        public KulonSignal KulonSignal
        {
            get;
            set;
        }

        public Signal Clone()
        {
            return new Signal
            {
                Elements = this.Elements.Select( e => e.Clone()).ToList(),
                Frequency = this.Frequency,
                KulonSignal = this.KulonSignal != null ? this.KulonSignal.Clone() : null,
                GroupSpeed = this.GroupSpeed,
                Level = this.Level,
                Modulation = this.Modulation,
                Wave = this.Wave,
                Synchronization = this.Synchronization
            };
        }
    }
}