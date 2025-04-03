using System;
using System.Drawing;
using matrizesCod;

namespace MyApp
{
    internal class Program
    {
        //CODIFICANDO A MATRIZ

        static void Main(string[] args)
        {

            LettersDict lettersDict = new LettersDict();

            Console.Write("{ ");
            foreach (var letter in LettersDict.LettersValues)
            {
                Console.Write($"Letra {letter.Key}: {letter.Value}, ");
            }
            Console.Write(" }");
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            string Name = " ";

            CheckName(ref Name);
            int[,] NameMatrix = ConvertToMatriz(ref Name);

            for (int i = 0; i < NameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < NameMatrix.GetLength(1); j++)
                {
                    Console.Write(NameMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }


        }

        static int[,] ConvertToMatriz(ref string name)
        {
            double LenghtName = (double)name.Length;
            double SizeLine = default;
            int ColumnsNumber = default;

            if (LenghtName % 2 != 0)
            {
                IEnumerable<char> AddCharacter = name.Append(' ');
                name = string.Concat(AddCharacter);
                double NewLenght = (double)name.Length;
                SizeLine = NewLenght / 2;
                ColumnsNumber = (int)SizeLine;
            }
            else
            {
                SizeLine = LenghtName / 2;
                ColumnsNumber = (int)SizeLine;
            }
            IEnumerable<char> keys = LettersDict.LettersValues.Keys;
            char[] KeysInDictionary = LettersDict.LettersValues.Keys.ToArray();

            List<char> LettersInName = new List<char> { };

            foreach (var character in name)
            {
                foreach (var letter in LettersDict.LettersValues)
                {

                    if (letter.Key == character)
                    {
                        LettersInName.Add(letter.Key);
                    }
                }
            }

            int[,] NameMatrix = new int[2, ColumnsNumber];
            int IndexForName = 0;


            //criar uma matriz com o novo array
            for (int i = 0; i < NameMatrix.GetLength(0); i++)
            {

                for (int j = 0; j < NameMatrix.GetLength(1); j++)
                {
                    NameMatrix[i, j] = LettersDict.LettersValues[LettersInName[IndexForName]];
                    IndexForName++;
                }
            }

            return NameMatrix;
        }

        static void CheckName(ref string name)
        {
            List<char> Numbers = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            Console.WriteLine("Digite um Nome para ser Criptografado: ");

            while (true)
            {
                List<char> InvalidCharacters = new List<char> { };
                bool IsNumber = false;
                name = Console.ReadLine()!.ToUpper();

                if (name != "" && name != " ")
                {
                    foreach (var letter in name)
                    {
                        foreach (var number in Numbers)
                        {
                            if (letter == number)
                            {
                                InvalidCharacters.Add(letter);
                                IsNumber = true;
                            }
                        }
                    }

                    if (!IsNumber && InvalidCharacters.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Digite o Nome Novamente: ");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nome Inválido!");
                    Console.WriteLine();
                    Console.WriteLine("Digite Novamente: ");
                }
            }
        }
    }
}
