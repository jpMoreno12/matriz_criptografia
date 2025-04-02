using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matrizesCod
{
    public class LettersDict
    {
        public static Dictionary<char, int> LettersValues { get; } = new Dictionary<char, int>() { };

        private static void GetLettters()
        {
            int CounterLetters = 1;
            for (char i = 'A'; i <= 'Z'; i++)
            {
                LettersValues.Add(i, CounterLetters);
                CounterLetters++;
            }
            LettersValues.Add('.', 27);
            LettersValues.Add('!', 28);
            LettersValues.Add('#', 29);
            LettersValues.Add(' ', 30);
        }

        protected void CallsToDict()
        {
            GetLettters();
        }

        public LettersDict()
        {
            this.CallsToDict();
        }
    }
}
