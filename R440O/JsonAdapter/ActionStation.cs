using R440O.LearnModule;
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
        public bool IsUserAction { get; set; }
        public ModulesEnum Module { get; set; }

        public ActionStation() { }

        public ActionStation(string name, int value)
        {
            Value = value;
            Name = name;
            IsUserAction = true;
        }
        public ActionStation(string name, int value, bool isUserAction)
        {
            Value = value;
            Name = name;
            IsUserAction = isUserAction;
        }

        public ActionStation(ModulesEnum module, int value = 1, bool isUserAction = true)
        {
            Value = value;
            Module = module;
            IsUserAction = isUserAction;
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
                return Module == a.Module && 
                    Name == a.Name;
            }
        }
    }
}
