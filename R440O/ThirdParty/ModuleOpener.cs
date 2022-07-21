using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace R440O.ThirdParty
{
    public static class ModuleOpener
    {
        public static object GetModuleInstance(string moduleName)
        {
            Type t = Type.GetType(moduleName);
            var method = t.GetMethod("getInstance");
            object instance = method?.Invoke(null, null);

            return instance;
        }

        //private static string[] GetModulesNames()
        //{
        //    return Assembly.GetExecutingAssembly().GetTypes()
        //        .Select(t => t.FullName)
        //        .Where(module => module.StartsWith(namespacePath))
        //        .Where(module => module.Contains("Parameters"))
        //        .Where(module => module.Contains("+") == false)
        //        .OrderByDescending(module => module)
        //        .ToArray();
        //}
    }
}
