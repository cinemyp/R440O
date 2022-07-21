using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R440O.JsonAdapter
{
    public class StandardStep
    {
        public string ModuleName { get; set; }
        public object ModuleState { get; set; }

        public StandardStep() { }

        public StandardStep(string moduleName, object moduleState)
        {
            ModuleName = moduleName;
            ModuleState = moduleState;
        }
    }
}
