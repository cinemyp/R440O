using System;
using ShareTypes.OrderScheme;


namespace RetranslatorWPF
{
    public class OrderSchemePair
    {      
        public OrderSchemeClass orderScheme1;
        public OrderSchemeClass orderScheme2;

        public Station Station1;
        public Station Station2;

        public OrderSchemePair(int wave1, int wave2, int circleName,
            int circalPrivateName, int privateName1, int privateName2)
        {
            orderScheme1 = OrderSchemeFactory.GenerateOrderSchemeByWave(wave1,
                wave2, circleName, circalPrivateName, privateName1);
            orderScheme2 = OrderSchemeFactory.GenerateOrderSchemeByWave(wave2,
                wave1, circleName, circalPrivateName, privateName2);
        }

        public Tuple<Station, OrderSchemeClass> GetStationOrderScheme1()
        {
            return new Tuple<Station, OrderSchemeClass>(Station1, orderScheme1);
        }

        public Tuple<Station, OrderSchemeClass> GetStationOrderScheme2()
        {
            return new Tuple<Station, OrderSchemeClass>(Station2, orderScheme2);
        }

        public bool IsEmpty
        {
            get
            {
                return Station1 == null && Station2 == null;
            }
        }


        public bool isStation1Empty
        {
            get
            {
                return Station1 == null;
            }
        }

        public bool isStation2Empty
        {
            get
            {
                return Station2 == null;
            }
        }

        public bool IsFree
        {
            get
            {
                return Station1 == null || Station2 == null;
            }
        }

        public void AddStation(Station station)
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

        public OrderSchemeClass GetOrderSchemeByStation(Station station)
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
