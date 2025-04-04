﻿using System;
using System.Drawing;
using System.Text;
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
            int[,] Matrix = ConvertNameToMatrix(ref Name);

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i,j] + " ");
                }
                Console.WriteLine(); 
            }

            Console.WriteLine();

            EncryptionMethod(ref Matrix);

            int[,] MatrizTeste = new int[,] {{2 + 2, 3 + 4}};
            



        }

        static int[,] ConvertNameToMatrix(ref string name)
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

            BuildingMatrix(ref NameMatrix, name);

            return NameMatrix; 
        }

        static void BuildingMatrix(ref int[,] nameMatrix, string name)
        {
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

            int IndexForName = 0;


            //criar uma matriz com o novo array
            for (int i = 0; i < nameMatrix.GetLength(0); i++)
            {

                for (int j = 0; j < nameMatrix.GetLength(1); j++)
                {
                    nameMatrix[i, j] = LettersDict.LettersValues[LettersInName[IndexForName]];
                    IndexForName++;
                }
            }
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


        static void EncryptionMethod(ref int[,] matrix)
        {
            int[,] EncoderMatrix = new int[,] { { 3, 1 }, { 2, 1 } };
            int[,] NewMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            int IndexLine = 0;
            int IndexColumn = 0;

            bool MultipliedLine = false;
            for (int LineEnconder = 0; LineEnconder < EncoderMatrix.GetLength(0); LineEnconder++)
            {
                for (int ColumEncoder = 0; ColumEncoder < EncoderMatrix.GetLength(1); ColumEncoder++)
                {
                    for (int LineCurrent = 0; LineCurrent < matrix.GetLength(0); LineCurrent++)
                    {
                        for (int ColumnCurrent = 0; ColumnCurrent < matrix.GetLength(1); ColumnCurrent++)
                        {

                            if (MultipliedLine == false)
                            {
                                NewMatrix[LineCurrent, ColumnCurrent] = matrix[LineCurrent, ColumnCurrent] * EncoderMatrix[LineEnconder, ColumEncoder];
                            }

                            if (MultipliedLine)
                            {
                                NewMatrix[LineCurrent, ColumnCurrent] = NewMatrix[LineCurrent, ColumnCurrent] +
                             (NewMatrix[LineCurrent, ColumnCurrent] = matrix[LineCurrent, ColumnCurrent] * EncoderMatrix[LineEnconder, ColumEncoder]);
                            }
                            
                        }
                    
                    }
            MultipliedLine = true;
                }
            }

            Console.WriteLine("Matriz nova Criptografada: ");
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(NewMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
