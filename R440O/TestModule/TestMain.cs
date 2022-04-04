﻿using R440O.BaseClasses;
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
        private static List<ActionStation> checkedActions = new List<ActionStation>();
        private static int step = 0;
        private static bool isCheck = true;
        public static bool IsCheck { get { return isCheck; } }

        private static bool checking = false;
        
        public delegate void ClosingForms();
        public static event ClosingForms close;

        private static TestHelper testHelper = new TestHelper();

        public static void setIntent(ModulesEnum intention)
        {
            if (ParametersConfig.IsTesting == false)
                return;
            module = intention;
            testHelper.SetIntent(intention);
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
                action.Module == previousAction.Module))
            {
                //пользователь работает с тем параметром, который нужен, 
                //поэтому оставляем и ничего не делаем
            }
            else if (isCheck && action.IsUserAction)
            {
                //идет проверка на дефолтные значения
                //пользователь может трогать тумблеры, чтобы выставить необходимые
            }
            else if (checkedActions.Contains(action) && action.Value == 1)
            {
                //мы уже проверили блок
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Error");
                MakeSoftMistake();
            }
            if (expectedAction.Module == ModulesEnum.Check_End)
            {
                isCheck = false;
                NextStep(action);
                System.Windows.Forms.MessageBox.Show("Проверка закончена");
            }
        }

        private static void NextStep(ActionStation action)
        {
            step += 1;
            if (step >= standardActions.Count)
                return;
            previousAction = expectedAction;
            expectedAction = standardActions[step];

            checkedActions.Add(previousAction);

            setIntent(expectedAction.Module);
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

            setIntent(expectedAction.Module);
        }

        private static void CreateStandard()
        {
            standardActions = new List<ActionStation>();
            if(checking)
            {
                //Проверка
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
            }
            


            //Включение
            //Проверка напряжения
            //Подключение кабеля на стабилизаторе
            standardActions.Add(new ActionStation(ModulesEnum.PowerCabelConnect, R440OForms.PowerCabel.PowerCabelParameters.getInstance().Напряжение));
            standardActions.Add(new ActionStation(ModulesEnum.N502Power, 1));

            //Н15
            standardActions.Add(new ActionStation(ModulesEnum.N15Power, 1));

            //БМБ
            standardActions.Add(new ActionStation(ModulesEnum.BMB_Power, 1));
            //C1_67
            standardActions.Add(new ActionStation(ModulesEnum.C1_67_Power, 1));
            //Я2М-67
            standardActions.Add(new ActionStation(ModulesEnum.Wattmeter_Power, 1));



            //Проверка по малому шлейфу
            standardActions.Add(new ActionStation(ModulesEnum.N15SmallLoop, 1));
            standardActions.Add(new ActionStation(ModulesEnum.A205_Power, 1));
            standardActions.Add(new ActionStation(ModulesEnum.A304_Power, 1));
            standardActions.Add(new ActionStation(ModulesEnum.A306_Power, 1));
            standardActions.Add(new ActionStation(ModulesEnum.N15SmallLoopInside, 1));
            standardActions.Add(new ActionStation(ModulesEnum.C300_m1_Power, 1));
        }

        public static void StartTest()
        {
            CreateStandard();
            LoadStandard();
            isCheck = checking;
            ParametersConfig.IsTesting = true;
            testResult = new TestResult();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            timer = EasyTimer.SetInterval(SetTimer, 60000);
#if DEBUG
            testHelper.Show();
#endif
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
