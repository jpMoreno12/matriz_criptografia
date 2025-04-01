using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrizesCod
{
    public class LettersDict
    {
        public static Dictionary<char, int> LettersValues { get; }

        private static void GetLettters()
        {
            int CounterLetters = 1;
            for (char i = 'A'; i < 'Z'; i++)
            {
                LettersValues.Add(i, CounterLetters);
                CounterLetters++;
            }
        }

        public static void CallsDicitionary()
        {
            GetLettters();
        }

    }
}
