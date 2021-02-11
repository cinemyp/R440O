using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R440O
{

    /// <summary>
    /// Методы расширения для  PropertyInfo.
    /// Класс нужен для работы станции под .NET 4.0 framework.
    /// </summary>

    public static class PropertyInfoExtensions
    {
        public static object GetValue(this System.Reflection.PropertyInfo prop, object obj)
        {
            return prop.GetValue(obj, null);
        }

        public static void SetValue(this System.Reflection.PropertyInfo prop, object obj, object newValue)
        {
            prop.SetValue(obj, newValue, null);
        }
    }
}
