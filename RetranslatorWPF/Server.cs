using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using ShareTypes.SignalTypes;
using ShareTypes;
using System.Threading.Tasks;
using ShareTypes.OrderScheme;
using System.Net.Sockets;
using Newtonsoft.Json;


namespace RetranslatorWPF
{
    public class Server
    {
        public List<OrderSchemePair> OrderSchemePairs = new List<OrderSchemePair>();

        private HttpListener httpListener = new HttpListener();

        private Random Randomizer = new Random();

        private int CircularName;
        private int CircularPrivateName;

        public Server()
        {
            CircularName = Randomizer.Next(100, 999);
            CircularPrivateName = Randomizer.Next(100, 999);

            System.Net.IPAddress ipAdress;
            if (!HttpListener.IsSupported)
                throw new NotImplementedException();

            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            ipAdress = host
                .AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            //если установлен virtualbox, то первым адрессом может идти его адресс, т.е. вылетит ошибка
            if (ipAdress==null)
                throw new Exception("Local IP Address Not Found!");

            httpListener.Prefixes.Add("http://" + ipAdress.ToString() + ":8080/");
            httpListener.Start();
            Task.Run(() => { 
                Listening(); 
            });
        }

        private void Listening()
        {
            while (true)
            {
                HttpListenerContext context = httpListener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                if (request.HttpMethod == "POST")
                {
                    if (request.Url.AbsolutePath == "/signal")
                        SendSignal(request, response);
                }
                else if (request.HttpMethod == "GET")
                {
                    if (request.Url.AbsolutePath == "/orderscheme")
                        SendOrderScheme(request, response);
                    else if (request.Url.AbsolutePath == "/checkserver")
                        CheckServer(request, response);

                }
                else
                {
                    Error(response);
                }
            }
        }

        private void SendObject<T>(HttpListenerResponse response, T obj)
        {
            var responseString = JsonConvert.SerializeObject(obj);
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            try
            {
                using (Stream stream = response.OutputStream)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception e)
            {

            }
        }

        private T ReadObject<T>(HttpListenerRequest request)
        {
            string str = string.Empty;
            try
            {
                using (var reader = new StreamReader(request.InputStream,
                                         request.ContentEncoding))
                {
                    str = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }
            return JsonConvert.DeserializeObject<T>(str);
        }

        private void Error(HttpListenerResponse response)
        {
            response.StatusCode = (int)HttpStatusCode.OK;
            string responseString = "Some Error :( !";
            SendObject(response, responseString);
        }

        private void CheckServer(HttpListenerRequest request, HttpListenerResponse response)
        {
            response.StatusCode = (int)HttpStatusCode.OK;

            SendObject(response, Constants.ServerCheckString);
        }

        private void SendOrderScheme(HttpListenerRequest request, HttpListenerResponse response)
        {
            var orderScheme = GetOrderSheme();
            SendObject(response, orderScheme);
        }

        private void SendSignal(HttpListenerRequest request, HttpListenerResponse response)
        {                       
            ClearStantionList();
            var signalDTO = ReadObject<SendSignalDTO>(request);
            if (signalDTO != null)
            {
                UpdateSignal(signalDTO);
            }
            var broadcast = GetBroadcastSignal();
            SendObject(response, broadcast);
        }

        private OrderSchemeClass GetOrderSheme()
        {
            var stantion = new Station();
            var freePair = this.OrderSchemePairs.FirstOrDefault(s => s.IsFree);

            if (freePair == null)
            {
                var wave1 = GetRandomWave(0);
                var wave2 = GetRandomWave(wave1);
                var privateName1 = GetRandomPrivateName(0);
                var privateName2 = GetRandomPrivateName(privateName1);
                freePair = new OrderSchemePair(wave1, wave2, CircularName, CircularPrivateName,
                    privateName1, privateName2);
                this.OrderSchemePairs.Add(freePair);
            }

            freePair.AddStation(stantion);
            return freePair.GetOrderSchemeByStation(stantion);
        }

        private int GetRandomWave(int fisrtWave)
        {
            for (int i = 0; i < 10000; i++)
            {
                var wave = this.Randomizer.Next(1500, 51499);
                if (Math.Abs(fisrtWave - wave) < 100 || !this.OrderSchemePairs.Any(pair =>
                    Math.Abs(pair.orderScheme1.ПередачаУсловныйНомерВолны1 - wave) < 100 || 
                    Math.Abs(pair.orderScheme2.ПередачаУсловныйНомерВолны1 - wave) < 100))
                {
                    return wave;
                }
            }
            return -1;
        }

        private int GetRandomPrivateName(int firstPrivateName)
        {
            for (int i = 0; i < 10000; i++)
            {
                var name = this.Randomizer.Next(100, 999);
                if (firstPrivateName != name && !this.OrderSchemePairs.Any( pair => 
                    pair.orderScheme1.ИндивидуальныйПозывной == name ||
                    pair.orderScheme2.ИндивидуальныйПозывной == name))
                {
                    return name;
                }
            }
            return -1;
        }

        public void ClearStantionList()
        {
            foreach (var pair in this.OrderSchemePairs)
            {
                if (pair.Station1 != null && pair.Station1.IsExpired)
                {
                    pair.Station1 = null;
                }
                if (pair.Station2 != null && pair.Station2.IsExpired)
                {
                    pair.Station2 = null;
                }
            }
            this.OrderSchemePairs = this.OrderSchemePairs.Where(pair => !pair.IsEmpty).ToList();
        }

        private void UpdateSignal(SendSignalDTO signalDTO)
        {
            int WaveShift = 1500;
            int FrequencyShift = 2325000;
            
            var id = signalDTO.Id;
            var signal = signalDTO.Signal;
            if (signal != null)
            {
                signal.Wave -= WaveShift;
                signal.Frequency -= FrequencyShift;                           
            }
            var stantion = this.OrderSchemePairs.SelectMany(pair => new[] { pair.Station1, pair.Station2 })
                   .FirstOrDefault(s => s!=null && s.Id == id);
            if (stantion != null)
            {
                stantion.UpdateSignal(signal);
            }
        }

        private BroadcastSignal GetBroadcastSignal()
        {
            var signals = this.OrderSchemePairs.SelectMany(pair => new[] { 
                pair.Station1 == null ? null : pair.Station1.Signal, 
                 pair.Station2 == null ? null : pair.Station2.Signal })
                 .Where(s => s != null)
                 .ToList();
            return new BroadcastSignal(signals);
        }

    }
}
