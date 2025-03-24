using System;
using System.IO;

namespace FileStreamExamples
{
    class Zadanie4
    {
        public static void Run()
        {
            string path = @"C:\Users\User\Desktop\ININ4\plik.txt";

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string reversed = Reverse(line);
                        Console.WriteLine(reversed);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }

        private static string Reverse(string s)
        {
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
    }
}

