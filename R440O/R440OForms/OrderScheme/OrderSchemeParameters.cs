namespace R440O.R440OForms.OrderScheme
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using ShareTypes.OrderScheme;
    using ThirdParty;

    public static class OrderSchemeParameters
    {
        public static OrderSchemeClass СхемаПриказ { get; private set; }
              
        public static void SetOrderScheme(bool isTesting = false)
        {
            if (HttpHelper.СерверНайден)
            {
                try
                {
                    Task.Run(async () =>
                    {
                        СхемаПриказ = await HttpHelper.ПолучитьСхемуПриказ();
                    }).Wait();
                    if (СхемаПриказ != null)
                    {
                        return;
                    }
                }
                catch (Exception e)
                {

                }
            }
            СхемаПриказ = OrderSchemeFactory.CreateOrderScheme(isTesting);
        }
    }
}

/*        
      /// <summary>
      /// Проверка должна ли по данному каналу передаваться информация.
      /// </summary>
      /// <param name="chanel">Номер канала, по которому должна идти информация.</param>
      public static bool IsInf(int chanel)
      {
          return ПриемНомерКаналаТЛФ == chanel;
      }

      /// <summary>
      /// Сигнал коресспондента, согласно схеме приказ.
      /// </summary>
      public static Signal СигналКорреспондента
      {
          get
          {
              var signal = new Signal
              {
                  Elements = new List<SignalElement>
                  {
                      new SignalElement(ПриемНомерПотока1, ПриемНомерГруппы1, 
                          new []{new Chanel(-1, IsInf(0)), new Chanel(1.2, IsInf(1)), new Chanel(1.2, IsInf(2)), new Chanel(1.2, IsInf(3)), 
                              new Chanel(0.05, IsInf(4)), new Chanel(0.05, IsInf(5)), new Chanel(0.025, IsInf(6))})
                  },
                  GroupSpeed = ПриемВидМодуляцииСкорость1,
                  Level = 50,
                  Modulation = Модуляция.ОФТ,
                  Wave = ПриемУсловныйНомерВолны1
              };
              return signal;
          } 
      }

      private static bool _generate;
  }
 * 
  */
