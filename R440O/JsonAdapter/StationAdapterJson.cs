using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using R440O.R440OForms;

namespace R440O.JsonAdapter
{
    public static class StationAdapterJson
    {
        private static string namespacePath = "R440O.R440OForms.";
        private static string normativPath = "Normativ.json";
        public static void StoreStationStateToJson()
        {
            var ns = GetModulesNames();
            object[] modules = new object[ns.Length];

            for(int i = 0; i < ns.Length; i++)
            {
                object module = GetModuleInstance(ns[i]);
                if (module == null) continue;

                object dataObject = new
                {
                    moduleName = module.GetType().FullName,
                    moduleState = module
                };

                modules[i] = dataObject;
            }

            SerializeState(modules);
        }
        public static List<ActionStation> GetNormativ()
        {
            string str = File.ReadAllText(normativPath);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ActionStation>>(str);
            return obj;
        }
        private static void SerializeState(object data)
        {
            string stationState = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText("stationState.json", stationState);
        }

        private static object GetModuleInstance(string moduleName)
        {
            Type t = Type.GetType(moduleName);
            var method = t.GetMethod("getInstance");
            object instance = method?.Invoke(null, null);

            return instance;
        }

        private static string[] GetModulesNames()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Select(t => t.FullName)
                .Where(module => module.StartsWith(namespacePath))
                .Where(module => module.Contains("Parameters"))
                .Where(module => module.Contains("+") == false)
                .OrderByDescending(module => module)
                .ToArray();
        }
    }
}
