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
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            string Name = " ";

            CheckName(ref Name);
            ConvertToMatriz(ref Name); 
             
        }

        static void ConvertToMatriz(ref string name)
        {
            double LenghtName = (double)name.Length;
            double SizeLine = default; 
            int EachLine = default; 
            

            Console.WriteLine($"{LenghtName:F2}");
            
            if (LenghtName % 2 != 0)
            {
                SizeLine = LenghtName / 2; 
                EachLine = (int)SizeLine + 1;
            }
            else
            {
                SizeLine = LenghtName / 2;
                EachLine = (int)SizeLine;
            }
            Console.WriteLine(EachLine);
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
