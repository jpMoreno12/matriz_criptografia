using System;
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

            for (int i = 0; i < EncoderMatrix.GetLength(0); i++) // linhas da EncoderMatrix
            {
                
                for (int j = 0; j < matrix.GetLength(1); j++) // colunas da matrix
                {
                    int sum = 0;
                    for (int k = 0; k < matrix.GetLength(0); k++) // linhas da matrix (ou colunas da Encoder)
                    {
                        sum += EncoderMatrix[i, k] * matrix[k, j];
                    }
                    NewMatrix[i, j] = sum;
                }
            }


            Console.WriteLine("Matriz Criptografada: "); 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(NewMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Deseja Desriptografar a Matriz? S. sim / N. nao");
                Console.WriteLine("OBS: Digite apenas S ou N...");

                char ConfirmCharacter = char.Parse(Console.ReadLine()!.ToUpper());

                if (ConfirmCharacter == 'S')
                {
                     
                    int[,] DecryptedMatrix = new int[NewMatrix.GetLength(0), NewMatrix.GetLength(1)];
                    int[,] MatrixDecrypt = DecryptMatrix(NewMatrix, DecryptedMatrix);

                    if (MatrixDecrypt.GetLength(0) == matrix.GetLength(0) || MatrixDecrypt.GetLength(1) == matrix.GetLength(1))
                    {
                        Console.WriteLine("Matriz Criptografada");
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                            {
                                Console.Write(NewMatrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                        Console.WriteLine("Matriz nova Descriptografada, Resultado de Criptografada x Decodificadora ");
                        for (int i = 0; i < DecryptedMatrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < DecryptedMatrix.GetLength(1); j++)
                            {
                                Console.Write(DecryptedMatrix[i, j] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                }
                else if (ConfirmCharacter == 'N')
                {
                    Console.WriteLine("Programa Finalizado!");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Caracter é Inválido. Tenta Novamente:");
                    Console.WriteLine();
                }

            }
        }

        static int[,] DecryptMatrix(int[,] Encrypted, int [,]DecryptedMatrix  )
        {
            Console.WriteLine();
            TextAnimation();

            int[,] MatrixForDecrypt = new int[,]{{1, -1}, {-2, 3}}; //esta matriz é a Matriz Inversa da Matriz que criptografa  

            for (int i = 0; i < MatrixForDecrypt.GetLength(0); i++) 
            {
                
                for (int j = 0; j < Encrypted.GetLength(1); j++) 
                {
                    int sum = 0;
                    for (int k = 0; k < Encrypted.GetLength(0); k++) 
                    {
                        sum += MatrixForDecrypt[i, k] * Encrypted[k, j];
                    }
                    DecryptedMatrix[i, j] = sum;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Matriz Decodificadora ");
            for (int i = 0; i < MatrixForDecrypt.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixForDecrypt.GetLength(1); j++)
                {
                    Console.Write(MatrixForDecrypt[i, j] + " ");
                }
                Console.WriteLine();
            }

            return DecryptedMatrix;
        }


        static void TextAnimation()
        {
            int num = 0;
            int pointer = 0;
            List<char> Pointers = ['.'];

            while (num <= 2)
            {
                Console.Clear();
                pointer += 1;

                Console.Write($"Descriptografando{string.Join("", Pointers)}");
                Pointers.Add('.');
                num += 1;
                Thread.Sleep(1000);
            }
            Console.Clear();
        }

    }
}
