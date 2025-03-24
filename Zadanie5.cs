using System;
using System.IO;

namespace FileStreamExamples
{
    class Zadanie5
    {
        public static void Run()
        {
            string path = @"C:\Users\User\Desktop\ININ4\plik.bin";

            Console.WriteLine("Wybierz opcję:");
            Console.WriteLine("1. Zapisz dane");
            Console.WriteLine("2. Odczytaj dane");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ZapiszDane(path);
                    break;
                case "2":
                    OdczytajDane(path);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }
        }

        private static void ZapiszDane(string path)
        {
            Console.Write("Imię: ");
            string imie = Console.ReadLine();

            Console.Write("Wiek: ");
            if (!int.TryParse(Console.ReadLine(), out int wiek))
            {
                Console.WriteLine("Nieprawidłowy wiek.");
                return;
            }

            Console.Write("Adres: ");
            string adres = Console.ReadLine();

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    writer.Write(imie);
                    writer.Write(wiek);
                    writer.Write(adres);
                }
                Console.WriteLine("Dane zapisane.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }

        private static void OdczytajDane(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Plik nie istnieje.");
                return;
            }

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                    string imie = reader.ReadString();
                    int wiek = reader.ReadInt32();
                    string adres = reader.ReadString();

                    Console.WriteLine("Dane z pliku:");
                    Console.WriteLine($"Imię: {imie}");
                    Console.WriteLine($"Wiek: {wiek}");
                    Console.WriteLine($"Adres: {adres}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Błąd I/O: {ex.Message}");
            }
        }
    }
}
