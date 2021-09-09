using System;
using System.Collections.Generic;
using System.Linq;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BracketsChecker("()[{}]()"));
            Console.ReadKey();
        }
        static bool BracketsChecker(string brackets)
        {
            Dictionary<string, string> OpenAndClosed = new Dictionary<string, string>()
            {
                {"{", "}" },
                {"(", ")" },
                {"[", "]" },
            };
            Stack<string> OpenBrackets = new Stack<string>();
            foreach (char bracket in brackets)
            {
                if (OpenAndClosed.Keys.ToList().Contains(bracket.ToString())) // Проверка на открытую скобку
                    OpenBrackets.Push(bracket.ToString()); //Если условие выполняется - добавляем в список с отркытыми скобками
                else if (OpenBrackets.Count > 0 && bracket.ToString() == OpenAndClosed[OpenBrackets.Peek()]) //Проверка на то, является ли следующая скобка закрывающей для последней открывающей
                    OpenBrackets.Pop(); //Если условие выполняется - убираем с верха стека скобку
                else
                {
                    return false; //Если ни одно из условий не выполнено - занчит скобочная последовательность неверна
                }
            }
            if (OpenBrackets.Count > 0) // Проверка на то, остались ли открытые скобки
                return false;
            return true;
        }
    }
}
