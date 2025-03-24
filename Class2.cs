using System;
using System.Diagnostics;
using System.IO;

namespace FileStreamExamples
{
    class Zadanie7
    {
        public static void Run()
        {
            Console.WriteLine("1. Generuj plik testowy (~300 MB)");
            Console.WriteLine("2. Kopiuj plik i zmierz czas");
            string choice = Console.ReadLine();

            string sourcePath = Path.Combine(Environment.CurrentDirectory, "test_source.bin");
            string targetPath = Path.Combine(Environment.CurrentDirectory, "test_copy.bin");

            switch (choice)
            {
                case "1":
                    GenerujPlik(sourcePath, 300);
                    break;
                case "2":
                    KopiujIZmierzCzas(sourcePath, targetPath);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }

        private static void GenerujPlik(string path, int sizeInMB)
        {
            try
            {
                Console.WriteLine($"Generowanie pliku {sizeInMB} MB...");
                byte[] buffer = new byte[1024 * 1024]; // 1 MB
                Random rng = new Random();

                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    for (int i = 0; i < sizeInMB; i++)
                    {
                        rng.NextBytes(buffer); // losowo
                        fs.Write(buffer, 0, buffer.Length);
                    }
                }

                Console.WriteLine("Plik wygenerowany.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }

        private static void KopiujIZmierzCzas(string sourcePath, string targetPath)
        {
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Plik źródłowy nie istnieje. Wygeneruj go najpierw.");
                return;
            }

            try
            {
                Stopwatch sw = Stopwatch.StartNew();

                using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                using (FileStream targetStream = new FileStream(targetPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8192]; // 8 KB
                    int bytesRead;

                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        targetStream.Write(buffer, 0, bytesRead);
                    }
                }

                sw.Stop();
                Console.WriteLine($"Czas kopiowania: {sw.ElapsedMilliseconds} ms");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }
    }
}
