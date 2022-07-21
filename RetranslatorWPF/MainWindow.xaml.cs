using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using ShareTypes.OrderScheme;

namespace RetranslatorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Server server;
        private DispatcherTimer dispatcherTimer;
        
        public MainWindow()
        {
            InitializeComponent();
            server = new Server();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private string getStationString(Station station, OrderSchemeClass orderScheme)
        {
            if (station == null)
            {
                return "Пусто";
            }
            var content = orderScheme.ИндивидуальныйПозывной.ToString();
            content += "\n";
            if(station.Signal == null)
            {
                return content + "Сигнала нет";
            }
            content += "Номер волны: " + station.Signal.Wave.ToString();
            content += "\n";
            content += "Мощность: " + station.Signal.Power.ToString();
            content += "\n";
            content += "Модуляция: " + station.Signal.Modulation.ToString();
            content += "\n";
            content += "Скорость: " + station.Signal.GroupSpeed.ToString();
            content += "\n";
            content += "Частота: " + station.Signal.Frequency.ToString();
            return content;
        }

        private string getStationChanelString(Station station, OrderSchemeClass orderScheme)
        {
            if (station == null)
            {
                return "Пусто";
            }
            var content = orderScheme.ИндивидуальныйПозывной.ToString();
            content += "\n";
            if (station.Signal == null)
            {
                return content + "Сигнала нет";
            }
            for(var i = 0; i < station.Signal.Elements[0].Chanels.Count; i++)
            {

                content += "Канал " + i+ ": " + station.Signal.InformationStringOfChanel(i);
                content += "\n";
            }
            return content;
        }

        private string getConnectionCondition(OrderSchemePair pair)
        {
            return "Подключение активно";
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            const string privateNameColumn = "PrivateName";
            const string stationWaveColumn = "Wave";
            const string stationPowerColumn = "Power";
            const string stationModulationColumn = "Modulation";
            const string stationGroupSpeedColumn = "GroupSpeed";

            server.ClearStantionList();

            var pairs = server.OrderSchemePairs;
            list.Items.Clear();

            //add only new pairs
            foreach (OrderSchemePair pair in pairs)
            {
                if (pair.IsEmpty)
                    continue;
                DrawPair(pair);
            }
        }

        private void DrawPair(OrderSchemePair pair)
        {
            var panelHeight = 150;
            var stationFontSize = 10;
            var stationWidth = 100;
            StackPanel sp = new StackPanel() { Height = panelHeight, Orientation = Orientation.Horizontal, Margin = new Thickness(10) };
            sp.SetValue(WidthProperty, list.Width);
            list.Items.Add(sp);
            Button station1 = new Button() { Content = getStationString(pair.Station1, pair.orderScheme1), FontSize = stationFontSize, Width = stationWidth };
            TextBlock station1Chanel = new TextBlock() { Text = getStationChanelString(pair.Station1, pair.orderScheme1), FontSize = stationFontSize, Width = stationWidth };
            sp.Children.Add(station1Chanel);
            sp.Children.Add(station1);
            Brush br = Brushes.DarkGray;

            Label connectConditionLabel = new Label() {  HorizontalAlignment = HorizontalAlignment.Center };
            if (pair.Station1 != null && pair.Station1.Signal != null && pair.Station2 != null && pair.Station2.Signal != null)
            {
                connectConditionLabel.Content = getConnectionCondition(pair);
                br = Brushes.LightGreen;
            }
            else connectConditionLabel.Content = "Соединение отсутствует";


            Line line = new Line() { X1 = 0, X2 = 160, Y1 = 20, Y2 = 20, Width = 160, StrokeThickness = 10, Stroke = br, StrokeDashArray = { 0.5, 0.5 }, StrokeDashOffset = 1, StrokeMiterLimit = 1, StrokeDashCap = PenLineCap.Triangle };

            StackPanel spToConnection = new StackPanel() { Height = panelHeight, Orientation = Orientation.Vertical };

            spToConnection.Children.Add(connectConditionLabel);
            spToConnection.Children.Add(line);

            sp.Children.Add(spToConnection);

            string station2Content = "Пусто";
            if (!pair.isStation2Empty)
            {
                station2Content = pair.orderScheme2.ИндивидуальныйПозывной.ToString();
            }
            Button station2 = new Button() { Content = getStationString(pair.Station2, pair.orderScheme2), FontSize = stationFontSize, Width = stationWidth };
            TextBlock station2Chanel = new TextBlock() { Text = getStationChanelString(pair.Station2, pair.orderScheme2), FontSize = stationFontSize, Width = stationWidth };
            sp.Children.Add(station2);
            sp.Children.Add(station2Chanel);



        }
    }
}
