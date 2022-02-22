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
                step += 1;
                if (step >= standardActions.Count)
                    return;
                previousAction = expectedAction;
                expectedAction = standardActions[step];
            }
            else if (previousAction != null && (action.Name == expectedAction.Name || 
                previousAction.Equals(action) || 
                action.Name == previousAction.Name))
            {
                //пользователь работает с тем параметром, который нужен, 
                //поэтому оставляем и ничего не делаем
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }
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

            //Включение
            standardActions.Add(new ActionStation("КабельСеть", 1));
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
