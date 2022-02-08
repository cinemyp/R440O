using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R440O.JsonAdapter
{
    public class ActionStation
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public ActionStation() { }

        public ActionStation(string name, int value)
        {
            Value = value;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ActionStation a = (ActionStation)obj;
                return Value == a.Value && 
                    Name == a.Name;
            }
        }
    }
}
