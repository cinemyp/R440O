using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R440O.TestModule
{
    public enum Result { Failed = 2, Passed, Well, Great }
    public class TestResult
    {
        //фио, взвод, курс, группа ?
        private int mark;
        public Result result { get { return (Result)mark; } }
        public DateTime testingTime { get; set; }

        public TestResult() { mark = 5; }
        //TODO: разобрать с мелкими ошибками, как их учитывать
        public bool MinusPoint(int points = 1) //возвращает true, если оценка меньше 3 - закончил тестирование. иначе - false, снизили оценку и продолжаем тест
        {
            mark-=points;
            if (mark < 3)
                return true;
            return false;
        }
        

    }
}
