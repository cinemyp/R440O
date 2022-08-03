using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using R440O.LearnModule;
using R440O.ThirdParty;

namespace R440O.JsonAdapter
{
    public static class StationAdapterJson
    {
        private static string namespacePath = "R440O.R440OForms.";
        private static string normativPath = "Normativ.json";
        private const string standardPath = "stationState.json";
        private static List<object> standard = new List<object>();

        public static void StoreStandard()
        {
            SerializeState(standard);
        }

        public static void StoreState(string paramsName)
        {
            object module = ModuleOpener.GetModuleInstance(paramsName);
            if (module == null) return;

            object dataObject = new
            {
                moduleName = module.GetType().FullName,
                moduleState = module
            };
            standard.Add(dataObject);
        }

        public static void StoreStationStateToJson()
        {
            var ns = GetModulesNames();
            object[] modules = new object[ns.Length];

            for(int i = 0; i < ns.Length; i++)
            {
                object module = ModuleOpener.GetModuleInstance(ns[i]);
                if (module == null) continue;

                StandardStep dataObject = new StandardStep
                {
                    ModuleName = module.GetType().FullName,
                    ModuleState = module
                };

                modules[i] = dataObject;
            }

            SerializeState(modules);
        }

        public static List<ActionStation> GetNormativ()
        {
            try
            {
                string str = File.ReadAllText(normativPath);
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ActionStation>>(str);

                obj.ForEach((action) => { Enum.TryParse(action.Title, out action.Module); });

                return obj;
            }
            catch(Exception e)
            {
                return DefaultStandard();
            }
        }

        public static List<StandardStep> GetStandard(string path = standardPath)
        {
            try
            {
                string str = File.ReadAllText(path);
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<StandardStep>>(str);
                
                return obj;
            }
            catch (Exception e)
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show("Error. Cannot get standard.\n" + e.Message);
#endif
                return null;
            }
        }

        private static void SerializeState(object data)
        {
            string stationState = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText("stationState.json", stationState);
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

        private static List<ActionStation> DefaultStandard()
        {
            var standardActions = new List<ActionStation>();

            standardActions.Add(new ActionStation(ModulesEnum.Check_N502B, 1, false)); //Готово
            standardActions.Add(new ActionStation(ModulesEnum.Check_N15, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_P220, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_N12S, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_A403, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_A205, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_N13_1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_N13_2, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_N16, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_A304, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_A306, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_C300M, 1, false));

            standardActions.Add(new ActionStation(ModulesEnum.Check_A1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_B1_1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_B1_2, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_B2_1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_B2_2, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_B3_1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_B3_2, 1, false));

            standardActions.Add(new ActionStation(ModulesEnum.Check_DAB5, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_RUBIN, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_KONTUR, 1, false));

            standardActions.Add(new ActionStation(ModulesEnum.Check_PU_K1_1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_K03M_01_1, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_K05M_01, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_K03M_01_2, 1, false));

            standardActions.Add(new ActionStation(ModulesEnum.Check_BMB, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_BMA, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_C1_67, 1, false));
            standardActions.Add(new ActionStation(ModulesEnum.Check_Wattmeter, 1, false));

            standardActions.Add(new ActionStation(ModulesEnum.Check_End, 1, false));




            //Включение
            //Проверка напряжения
            //Подключение кабеля на стабилизаторе
            standardActions.Add(new ActionStation(ModulesEnum.PowerCabelConnect, R440OForms.PowerCabel.PowerCabelParameters.getInstance().Напряжение));
            standardActions.Add(new ActionStation(ModulesEnum.N502Power));

            //Н15
            standardActions.Add(new ActionStation(ModulesEnum.N15Power));

            //БМБ
            standardActions.Add(new ActionStation(ModulesEnum.BMB_Power));
            //C1_67
            standardActions.Add(new ActionStation(ModulesEnum.C1_67_Power));
            //Я2М-67
            standardActions.Add(new ActionStation(ModulesEnum.Wattmeter_Power));



            //Проверка по малому шлейфу
            standardActions.Add(new ActionStation(ModulesEnum.N15SmallLoop));
            standardActions.Add(new ActionStation(ModulesEnum.A205_Power));
            standardActions.Add(new ActionStation(ModulesEnum.A304_Power));
            standardActions.Add(new ActionStation(ModulesEnum.A306_Power));
            standardActions.Add(new ActionStation(ModulesEnum.N15SmallLoopInside));
            standardActions.Add(new ActionStation(ModulesEnum.SmallLoopCheck));
            standardActions.Add(new ActionStation(ModulesEnum.BMA_Recurs));

            //Проверка БМБ по малому кольцу
            standardActions.Add(new ActionStation(ModulesEnum.BMB_SmallLoop));

            //Проверка АПН
            standardActions.Add(new ActionStation(ModulesEnum.A403));
            standardActions.Add(new ActionStation(ModulesEnum.Kontur));
            return standardActions;
        }
    }
}
