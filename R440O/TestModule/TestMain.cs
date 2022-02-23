using R440O.BaseClasses;
using R440O.JsonAdapter;
using R440O.LearnModule;
using R440O.R440OForms.N502B;
using R440O.R440OForms.R440O;
using R440O.ThirdParty;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace R440O.TestModule
{
    static class TestMain
    {
        private static ModulesEnum module = ModulesEnum.nill;
        //static IntentionEnum intent = IntentionEnum.open;  Понять как можно использовать 
        public static GlobalIntentEnum globalIntent { get; set; } = GlobalIntentEnum.Normativ95;
        
        private static int softMistakes;
        private static IDisposable timer;
        private static int timeInMinutes = 0;
        private static Stopwatch stopwatch;
        private static TestResult testResult;

        private static ActionStation expectedAction;
        private static ActionStation previousAction;
        private static List<ActionStation> standardActions;
        private static int step = 0;
        private static bool isCheck = false;

        private static string checkEndName = "ПроверкаЗакончена";

        public delegate void ClosingForms();
        public static event ClosingForms close;

        public static void setIntent(ModulesEnum intention)
        {
            if (ParametersConfig.IsTesting == false)
                return;
            module = intention;
        }
        public static ModulesEnum getIntent()
        {
            return module;
        }

        public static void Action(ActionStation action)
        {
            if (expectedAction.Equals(action))
            {
                NextStep(action);
            }
            else if (previousAction != null && (previousAction.Equals(action) || 
                action.Name == previousAction.Name))
            {
                //пользователь работает с тем параметром, который нужен, 
                //поэтому оставляем и ничего не делаем
            }
            else if (isCheck && action.IsUserAction)
            {
                //идет проверка на дефолтные значения
                //пользователь может трогать тумблеры, чтобы выставить необходимые
            }
            else if (action.Name == checkEndName)
            {
                isCheck = false;
                NextStep(action);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }
        }

        private static void NextStep(ActionStation action)
        {
            step += 1;
            if (step >= standardActions.Count)
                return;
            previousAction = expectedAction;
            expectedAction = standardActions[step];
        }

        #region Сделать ошибку
        
        public static void MakeBlunderMistake()
        {
            if (ParametersConfig.IsTesting == false)
                return;
            //blunderMistakes++;
            //TODO: сказать, ты лох тупой, завершить тестирование и послать нахуй
            testResult.MinusPoint(3);
            FinishTest();
        }

        public static void MakeSoftMistake()
        {
            if (ParametersConfig.IsTesting == false)
                return;
            //TODO: прибавляем не грубую ошибку (студент совершил некорректное действие)
            if (testResult.MinusPoint() == true) //true - провалил, завершаем тест, иначе продолжаем
                FinishTest();
            softMistakes++;
        }
        #endregion

        private static void LoadStandard()
        {
            expectedAction = standardActions[0];
        }

        private static void CreateStandard()
        {
            standardActions = new List<ActionStation>();

            //Проверка
            standardActions.Add(new ActionStation("Н502Б", 1, false)); //Готово
            standardActions.Add(new ActionStation("Н15АБ", 1, false));
            standardActions.Add(new ActionStation("П220/27-Г", 1, false));
            standardActions.Add(new ActionStation("Н12С", 1, false));
            standardActions.Add(new ActionStation("А403-1", 1, false));
            standardActions.Add(new ActionStation("А205М-1", 1, false));
            standardActions.Add(new ActionStation("Н13-1", 1, false));
            standardActions.Add(new ActionStation("Н13-2", 1, false));
            standardActions.Add(new ActionStation("Н16", 1, false));
            standardActions.Add(new ActionStation("А304", 1, false));
            standardActions.Add(new ActionStation("А306", 1, false));
            standardActions.Add(new ActionStation("Ц300М-1", 1, false));
            standardActions.Add(new ActionStation("А1", 1, false));
            standardActions.Add(new ActionStation("Б1", 1, false));
            standardActions.Add(new ActionStation("Б2", 1, false));
            standardActions.Add(new ActionStation("Б3", 1, false));
            standardActions.Add(new ActionStation("ДАБ5", 1, false));
            standardActions.Add(new ActionStation("РУБИН-Н", 1, false));
            standardActions.Add(new ActionStation("КОНТУР-П2", 1, false));
            standardActions.Add(new ActionStation("К1М", 1, false));
            standardActions.Add(new ActionStation("БМБ", 1, false));
            standardActions.Add(new ActionStation("БМА", 1, false));
            standardActions.Add(new ActionStation("С1-67", 1, false));
            standardActions.Add(new ActionStation("Я2М-66", 1, false));
            standardActions.Add(new ActionStation("ПроверкаЗакончена", 1, false));


            //Включение
            standardActions.Add(new ActionStation("КабельСеть", 1, true));
            //Проверка напряжения
            //standardActions.Add(new ActionStation("ПереключательФазировка", 2));
            //standardActions.Add(new ActionStation("ПереключательСеть", 1));
            //standardActions.Add(new ActionStation("ПереключательСеть", 0));
            //standardActions.Add(new ActionStation("ПереключательФазировка", 1));
            //Подключение кабеля на стабилизаторе
            standardActions.Add(new ActionStation("КабельВход", R440OForms.PowerCabel.PowerCabelParameters.getInstance().Напряжение));
            //standardActions.Add(new ActionStation("ПереключательФазировка", N502BParameters.getInstance().Фазировка));
            //standardActions.Add(new ActionStation("ПереключательСеть", 1));
            standardActions.Add(new ActionStation("Нагрузка", 1));

            //Н15
            standardActions.Add(new ActionStation("локТумблерМШУ", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            standardActions.Add(new ActionStation("локКнопкаН13_1", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));

            standardActions.Add(new ActionStation("локТумблерЦ300М1", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            standardActions.Add(new ActionStation("локТумблерЦ300М2", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            standardActions.Add(new ActionStation("локТумблерЦ300М3", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            standardActions.Add(new ActionStation("локТумблерЦ300М4", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            
            standardActions.Add(new ActionStation("локТумблерН12С", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            standardActions.Add(new ActionStation("локТумблерБМА_1", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            standardActions.Add(new ActionStation("локТумблерБМА_2", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));
            
            standardActions.Add(new ActionStation("локТумблерАФСС", 1));
            standardActions.Add(new ActionStation("локТумблерА1", 1));
            standardActions.Add(new ActionStation("локТумблерА403", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));

            standardActions.Add(new ActionStation("локТумблерК1_1", 1));
            standardActions.Add(new ActionStation("локТумблерК1_2", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));

            standardActions.Add(new ActionStation("локТумблерБ1_1", 1));
            standardActions.Add(new ActionStation("локТумблерБ2_1", 1));
            standardActions.Add(new ActionStation("локТумблерБ3_1", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));

            standardActions.Add(new ActionStation("локТумблерБ1_2", 1));
            standardActions.Add(new ActionStation("локТумблерБ2_2", 1));
            standardActions.Add(new ActionStation("локТумблерБ3_2", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));

            standardActions.Add(new ActionStation("локТумблерДАБ_5", 1));
            standardActions.Add(new ActionStation("локТумблерР_Н", 1));
            standardActions.Add(new ActionStation("КнопкаСтанцияВкл", 1));

            //БМБ
            standardActions.Add(new ActionStation("КнопкаПитание", 1));
            //C1_67
            standardActions.Add(new ActionStation("C1_67ТумблерСеть", 1));
            //Я2М-67
            standardActions.Add(new ActionStation("ТумблерСеть", 1));

        }

        public static void StartTest()
        {
            CreateStandard();
            LoadStandard();
            isCheck = true;
            ParametersConfig.IsTesting = true;
            testResult = new TestResult();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            timer = EasyTimer.SetInterval(SetTimer, 60000);
        }

        private static void SetTimer()
        {
            timeInMinutes++;
            if (timeInMinutes >= 18 && timeInMinutes < 20) //решил тест за 19 минут - оценка 4
            {
                //уменьшаем оценку на балл
                testResult.MinusPoint();
            }
            if(timeInMinutes >= 20)
            {
                //уменьшаем оценку на балл
                testResult.MinusPoint();
                FinishTest();
            }
        }
        private static void FinishTest()
        {
            ParametersConfig.IsTesting = false;
            stopwatch.Stop();
            timer.Dispose();
            testResult.testingTime = new DateTime().AddMilliseconds(stopwatch.ElapsedMilliseconds);

            //TODO: сформровать результаты и отправить на сервер
            TestResultForm tr = new TestResultForm(testResult);
            tr.ShowDialog();
            //Закрыть окно станции
            close?.Invoke();
            //TODO: открыть главное меню
        }
        
        public static void CheckTest()
        {
            if(R440OForms.C300M_1.C300M_1Parameters.getInstance().СигналПойман)
            {
                FinishTest();
            }
        }

    }
}
