using System;

namespace FileStreamExamples
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Wybierz zadanie: 3, 4, 5, 6, 7");
            string input = Console.ReadLine();

            switch (input)
            {
                case "3":
                    Zadanie3.Run();
                    break;
                case "4":
                    Zadanie4.Run();
                    break;
                case "5":
                    Zadanie5.Run();
                    break;
                case "6":
                    Zadanie6.Run();
                    break;
                case "7":
                    Zadanie7.Run();
                    break;

                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }
}
