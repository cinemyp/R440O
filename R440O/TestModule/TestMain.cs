using R440O.LearnModule;
using R440O.R440OForms.R440O;
using R440O.ThirdParty;
using System;

namespace R440O.TestModule
{
    static class TestMain
    {
        private static ModulesEnum module = ModulesEnum.nill;
        //static IntentionEnum intent = IntentionEnum.open;  Понять как можно использовать 
        public static GlobalIntentEnum globalIntent { get; set; } = GlobalIntentEnum.nill;
        
        private static int softMistakes;
        private static IDisposable timer;
        private static int timeInMinutes = 0;
        private static TestResult testResult;

        public delegate void ClosingForms();
        public static event ClosingForms close;

        public static void setIntent(ModulesEnum intention)
        {
            if (ParametersConfig.IsTesting == false)
                return;
            module = intention;
            Action();
        }
        public static ModulesEnum getIntent()
        {
            return module;
        }

        private static void Action()
        {
            //CHECK: подумать, что тут должно быть и должно ли это быть
        }
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

        public static void StartTest()
        {
            ParametersConfig.IsTesting = true;
            testResult = new TestResult();
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
                timer.Dispose();
            }
        }
        private static void FinishTest()
        {
            
            ParametersConfig.IsTesting = false;
            //TODO: сформровать результаты и отправить на сервер
            testResult.testingTime = new DateTime();
            testResult.testingTime.AddMinutes(timeInMinutes);

            TestResultForm tr = new TestResultForm(testResult);
            tr.ShowDialog();
            //Закрыть окно станции
            close?.Invoke();
            //TODO: открыть главное меню
        }
        
    }
}
