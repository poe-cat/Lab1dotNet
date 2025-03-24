using System;
using System.IO;
using System.Text;

namespace FileStreamExamples
{
    class Zadanie3
    {
        public static void Run()
        {
            string path = @"C:\Users\User\Desktop\ININ4\plik.txt"; // <- zmień na własną ścieżkę

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    int bytesRead = fs.Read(buffer, 0, buffer.Length);

                    string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Zawartość pliku:");
                    Console.WriteLine(content);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }
    }
}

