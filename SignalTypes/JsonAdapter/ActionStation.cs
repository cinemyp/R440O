using System;

namespace ShareTypes.JsonAdapter
{
    public class ActionStation
    {
        public int Value { get; set; }
        public bool IsUserAction { get; set; }
        [NonSerialized]
        public ModulesEnum Module;
        public string Title { get; set; }

        public ActionStation() { }

        public ActionStation(ModulesEnum module, int value = 1, bool isUserAction = true)
        {
            Value = value;
            Module = module;
            IsUserAction = isUserAction;
            Title = module.ToString();
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
                return Module == a.Module && Value == a.Value;
            }
        }
    }
}
