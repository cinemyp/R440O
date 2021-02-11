using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareTypes.OrderScheme;

namespace Retranslator
{
    public class OrderSchemePair
    {      
        public OrderSchemeClass orderScheme1;
        public OrderSchemeClass orderScheme2;

        public Stantion Station1;
        public Stantion Station2;

        public OrderSchemePair(int wave1, int wave2, int circleName,
            int circalPrivateName, int privateName1, int privateName2)
        {
            orderScheme1 = OrderSchemeFactory.GenerateOrderSchemeByWave(wave1,
                wave2, circleName, circalPrivateName, privateName1);
            orderScheme2 = OrderSchemeFactory.GenerateOrderSchemeByWave(wave2,
                wave1, circleName, circalPrivateName, privateName2);
        }

        public Tuple<Stantion, OrderSchemeClass> GetStationOrderScheme1()
        {
            return new Tuple<Stantion, OrderSchemeClass>(Station1, orderScheme1);
        }

        public Tuple<Stantion, OrderSchemeClass> GetStationOrderScheme2()
        {
            return new Tuple<Stantion, OrderSchemeClass>(Station2, orderScheme2);
        }

        public bool IsEmpty
        {
            get
            {
                return Station1 == null && Station2 == null;
            }
        }

        public bool IsFree
        {
            get
            {
                return Station1 == null || Station2 == null;
            }
        }

        public void AddStation(Stantion station)
        {
            if (Station1 == null)
            {
                Station1 = station;
                this.orderScheme1.УникальныйИдентификаторСтанции = station.Id;
            }
            else
            {
                Station2 = station;
                this.orderScheme2.УникальныйИдентификаторСтанции = station.Id;
            }
        }

        public OrderSchemeClass GetOrderSchemeByStation(Stantion station)
        {
            if (this.Station1.Id == station.Id)
            {
                return orderScheme1;
            }
            if (this.Station2.Id == station.Id)
            {
                return orderScheme2;
            }
            throw new Exception("No this station in this pair!");
        }
    }
}
