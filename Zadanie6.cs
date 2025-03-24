using System;
using System.IO;

namespace FileStreamExamples
{
    class Zadanie6
    {
        public static void Run()
        {
            Console.Write("Podaj ścieżkę pliku źródłowego: ");
            string sourcePath = Console.ReadLine();

            Console.Write("Podaj ścieżkę pliku docelowego: ");
            string targetPath = Console.ReadLine();

            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Plik źródłowy nie istnieje.");
                return;
            }

            try
            {
                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream targetStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;

                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        targetStream.Write(buffer, 0, bytesRead);
                    }
                }

                Console.WriteLine("Plik został skopiowany.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }
    }
}
