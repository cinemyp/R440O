using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShareTypes.OrderScheme
{
    public class OrderSchemeClass
    {
        public string УникальныйИдентификаторСтанции { get; set; }

        public int ПередачаУсловныйНомерВолны1 { get; set; }
        public int ПередачаУсловныйНомерВолны2 { get; set; }
        public int ПередачаУсловныйНомерВолны3 { get; set; }

        public int ПередачаПроверкаНаСебяУсловныйНомерВолныА5031{ get; set; }
        public int ПередачаПроверкаНаСебяУсловныйНомерСтволаА5031{ get; set; }

        public int ПередачаПроверкаНаСебяУсловныйНомерВолныА5032{ get; set; }
        public int ПередачаПроверкаНаСебяУсловныйНомерСтволаА5032{ get; set; }

        public int ПередачаПроверкаНаСебяУсловныйНомерВолныА5033{ get; set; }
        public int ПередачаПроверкаНаСебяУсловныйНомерСтволаА5033{ get; set; }
        
        public double ПриемВидМодуляцииСкорость1{ get; set; }

        public int ПриемНомерПотока1{ get; set; }
        public int ПриемНомерПотока2{ get; set; }

        public int ПриемНомерГруппы1{ get; set; }
        public int ПриемНомерГруппы2{ get; set; }

            
        /// <summary>
        /// От 1 до 3 канала.
        /// </summary>
        public int ПриемНомерКаналаТЛФ{ get; set; }

        /// <summary>
        /// От 4 до 5 канала.
        /// </summary>
        public int ПриемНомерКаналаТЛГ{ get; set; }

        public int ПриемУсловныйНомерВолны1{ get; set; }
        public int ПриемУсловныйНомерСтвола1{ get; set; }

        public int ЦиркулярныйПозывной { get; set; }
        public int ЦиркулярноИндивидуальныйПозывной { get; set; }
        public int ИндивидуальныйПозывной { get; set; }
    }
}
