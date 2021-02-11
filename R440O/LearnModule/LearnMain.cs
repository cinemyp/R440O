using R440O.R440OForms.A205M_1;
using R440O.R440OForms.N15;
using R440O.R440OForms.N15Inside;
using R440O.R440OForms.N502B;
using R440O.R440OForms.R440O;
using R440O.R440OForms.VoltageStabilizer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace R440O.LearnModule
{
    static class LearnMain
    {
        public static bool isMainWindow = true;
        static ModulesEnum module = ModulesEnum.openN502BtoPower;
        static IntentionEnum intent = IntentionEnum.open;
        public static GlobalIntentEnum globalIntent { get; set; } = GlobalIntentEnum.nill;
        static String helpText { get; set; }
        static List<HighLightModule> modules = new List<HighLightModule>();
        static TextHelperForm textHelper;
        static R440OForm mainForm;
        static public Form form { get; set; }
        static Control curButton { get; set; }
        public static void setIntent(ModulesEnum intention)
        {
            module = intention;
            Action();
        }

        public static ModulesEnum getIntent()
        {    
            return module;
        }


        public static void setHelpForms(R440OForm r440OForm,TextHelperForm textHelperForm)
        {
            mainForm = r440OForm;
            textHelper = textHelperForm;
        }

        public static void StartHighLight()
        {
            foreach (HighLightModule module in modules)
                module.HighLighting();
        }

        public static void StopHighLight()
        {
            foreach (HighLightModule module in modules)
            {
                module.StopHighLight();
            }
            modules.Clear();
           
        }

        private static void Output(bool isHighLight)
        {
            if (isHighLight)
            {
                StartHighLight();
            }
            textHelper.helpTextBox.Text = helpText;
        }

       

        public static void Action()
        {
            if (modules != null) StopHighLight();

            List<Control> controls = new List<Control>();
            bool isHighlighting = false;
            bool isDialog = false;
            switch (module)
            {
            #region Описания шагов при обучения
                case ModulesEnum.openN502BtoCheck:
                    helpText = "Выберите блок питания (N502B)";              
                    controls.Add(mainForm.R440OButtonN502B);
                    isHighlighting = true;
                    break;

                case ModulesEnum.openN502BtoPower:
                    helpText = "Выберите блок питания (N502B)";
                    controls.Add(mainForm.R440OButtonN502B);
                    isHighlighting = true;
                    break;
                  
                case ModulesEnum.N502Check:
                    helpText = "1) Включите напряжение (тумблер слева) " + Environment.NewLine +
                                "2) Переключите фазировку на 1-2-3 или 2-1-3 " + Environment.NewLine +
                                "3) Посмотрите, сколько напряжения показывает на вольтметре" + Environment.NewLine +
                                "4) Выключите напряжение (тумблер слева) " + Environment.NewLine + 
                                "5) Переходите в блок стабилизатора напряжения (Ниже этого блока)";
                    controls.Add(((N502BForm)form).ПереключательСеть);
                    controls.Add(((N502BForm)form).ПереключательФазировка);
                    controls.Add(((N502BForm)form).ИндикаторНапряжение);
                    isHighlighting = true;
                    break;

                case ModulesEnum.N502Power:
                    helpText = "1) Включите напряжение (тумблер слева) " + Environment.NewLine +
                                "2) Переключите фазировку на 1-2-3 или 2-1-3 " + Environment.NewLine +
                                "3) Включите нагрузки (кнопка вверху)" + Environment.NewLine +
                                "4) Если индикатор фазировки не загорелся, переключите фазировазировку на другую (1-2-3 -> 2-1-3 и наоборот) " + Environment.NewLine +
                                "5) Включите тумблеры электрооборудования, выпрямителя и блоков Н13, Н13_2, Н15" + Environment.NewLine;
                    controls.Add(((N502BForm)form).ПереключательСеть);
                    controls.Add(((N502BForm)form).ПереключательФазировка);
                    controls.Add(((N502BForm)form).КнопкаВклНагрузки);
                    controls.Add(((N502BForm)form).ТумблерН13_1);
                    controls.Add(((N502BForm)form).ТумблерН13_2);
                    controls.Add(((N502BForm)form).ТумблерН15);
                    controls.Add(((N502BForm)form).ТумблерЭлектрооборудование);
                    controls.Add(((N502BForm)form).ТумблерВыпрямитель27В);
                    isHighlighting = true;
                    break;

                case ModulesEnum.VoltageStabilizerSetUp:

                    helpText = "Подключите канал напряжения, которое было показано на вольтметре";
                    controls.Add(((VoltageStabilizerForm)form).КабельВход1);
                    controls.Add(((VoltageStabilizerForm)form).КабельВход2);
                    isHighlighting = true;
                    break;



                case ModulesEnum.openPowerCabeltoPower:
                    helpText = "Выберите блок кабеля";
                    controls.Add(mainForm.R440OButtonPowerCabel);
                    isHighlighting = true;
                    break;

      
                case ModulesEnum.PowerCabelConnect:
                    helpText = "Включите кабель питания (по центру)";
                    break;


                case ModulesEnum.openVoltageStabilizer:
                    helpText = "Выберите блок стабилизатора напряжения";
                    controls.Add(mainForm.R440OButtonVoltageStabilizer);
                    isHighlighting = true;
                    break;

                case ModulesEnum.openN15:
                case ModulesEnum.H15Inside_open:
                    helpText = "Выберите блок Н15";
                    controls.Add(mainForm.R440OButtonN15);
                    isHighlighting = true;
                    break;


                case ModulesEnum.H15Inside_open_from_H15:
                    helpText = "Снимите крышку с блока";
                    N15Form N15 = ((N15Form)form);
                    controls.Add(N15.OpenInsideButtonLeft);
                    controls.Add(N15.OpenInsideButtonRight);
                    isHighlighting = true;
                    break;

                case ModulesEnum.N15Power:
                    helpText = "1) Включите тумблеры 1,2,3,4 (ц300м) МШУ,БМА1,БМА2,А205,А503б в том же порядке, после включения каждого нажимайте кнопку СТАНЦИЯ ВКЛ: " + Environment.NewLine +
                        "2) Поставить переключатель антенна-эквивалент в позицию эквивалент. Нажать СТАНЦИЯ ВКЛ" + Environment.NewLine +
                        "3) Включить А403,АФСС" + Environment.NewLine +
                        "4) Поставить переключатель ТЛФ-ТЛГ в позицию ТЛФ. Нажать СТАНЦИЯ ВКЛ";
                    N15 = ((N15Form)form); 
                    controls.Add(N15.КнопкаСтанцияВкл);
                    controls.Add(N15.ТумблерБМА_1);
                    controls.Add(N15.ТумблерБМА_2);
                    controls.Add(N15.ТумблерМШУ);
                    controls.Add(N15.ТумблерА205Base);
                    controls.Add(N15.ТумблерА503Б);
                    controls.Add(N15.ТумблерА403);
                    controls.Add(N15.ТумблерТлфТлгПрд);
                    controls.Add(N15.ТумблерТлфТлгПрм);
                    controls.Add(N15.ТумблерАФСС);
                    controls.Add(N15.ТумблерАнтЭкв);
                    controls.Add(N15.ТумблерЦ300М1);
                    controls.Add(N15.ТумблерЦ300М2);
                    controls.Add(N15.ТумблерЦ300М3);
                    controls.Add(N15.ТумблерЦ300М4);
                    isHighlighting = true;
                    break;

                case ModulesEnum.H15Inside_power:
                    helpText = "Выставить на пулах 480 и 48:" + Environment.NewLine +
                        "1) Переключатели ОФТ1-ЧТ1 поставить в положение ОФТ1" + Environment.NewLine +
                        "2) Выставить скорость на регуляторах скорость 4.8";
                    N15InsideForm n15inside = ((N15InsideForm)form);
                    controls.Add(n15inside.ПереключательПУЛ480ПРМ_1);
                    controls.Add(n15inside.ПереключательПУЛ480ПРМ_2);
                    controls.Add(n15inside.ПереключательПУЛ48ПРД_1);
                    controls.Add(n15inside.ПереключательПУЛ48ПРД_2);
                    controls.Add(n15inside.ТумблерПУЛ480ПРМ_1);
                    controls.Add(n15inside.ТумблерПУЛ480ПРМ_2);
                    controls.Add(n15inside.ТумблерПУЛ48ПРД_1);
                    controls.Add(n15inside.ТумблерПУЛ48ПРД_2);
                    isHighlighting = true;
                    break;

                case ModulesEnum.chooseLearnType:
                    isDialog = true;
                    Form formDialog = new LearnTypeSelector();
                    formDialog.ShowDialog();
                    break;

                case ModulesEnum.A205_m1_Open:
                    helpText = "Выберите блок A205-м1";
                    controls.Add(mainForm.R440OButtonA205M_1);
                    isHighlighting = true;
                    break;

                case ModulesEnum.A205_m1_Power:
                    //int wave = new Random().Next(1500, 51499);
                    int wave = 41529; 
                    helpText = "Выставите волну (" + wave + " номер передающей волны)" + Environment.NewLine +
                        "Тип работы: ОФТ-2.4-5.2" + Environment.NewLine +
                        "Вход: ЧТ-1";
                    A205M_1Form A205 = ((A205M_1Form)form);
                    controls = new List<Control>();
                    controls.Add(A205.ПереключательВолнаX1);
                    controls.Add(A205.ПереключательВолнаX10);
                    controls.Add(A205.ПереключательВолнаX100);
                    controls.Add(A205.ПереключательВолнаX1000);
                    controls.Add(A205.ПереключательВолнаX10000);
                    controls.Add(A205.ПереключательВидРаботы);
                    controls.Add(A205.ПереключательВходЧТ);
                    isHighlighting = true;
                    break;

                case ModulesEnum.C300_m1_Open:
                    helpText = "Выберите блок Ц300-м1";
                    controls.Add(mainForm.R440OButtonC300M_1);
                    isHighlighting = true;
                    break;  

                default: break;
            #endregion
            }
            if (!isDialog)
            {
                if(isHighlighting)
                    foreach (Control control in controls)
                    {
                        modules.Add(new HighLightModule(control));
                    }
                Output(isHighlighting);
            }
           
        }
    }


}



