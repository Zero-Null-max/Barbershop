using System.Collections.Concurrent;

namespace Barbershop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool running = true;
            while (running)
            {
                Console.Clear(); // Очищає все перед новим рядком
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            ShowAbout();
                            Pause();
                            break;
                        }
                    case "2":
                        {
                            double startTime = 0.5;
                            double endTime = 2.5;
                            double step = 0.25;
                            ShowCostTable(startTime, endTime, step);
                            Pause();
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Введіть кількість майстрів: ");
                            bool validMasters = int.TryParse(Console.ReadLine(), out int mastersCount);
                            Console.Write("Введіть кількість днів: ");
                            bool validDays = int.TryParse(Console.ReadLine(), out int daysCount);
                             if (!validMasters || !validDays || mastersCount <= 0 || daysCount <= 0)
                            {
                                Console.WriteLine("Введіть додатнє число!");
                                Console.ReadKey(true);
                                break;
                            }
                            int grandTotal = 0;
                            Console.Write("\n");
                            Console.Write("         ");
                            for (int day = 1; day <= daysCount; day++)
                            {
                                Console.Write($"{day, 8}");
                            }
                            Console.WriteLine($"{"Підсумок!", 10}");
                            for (int master = 1; master <= mastersCount; master++)
                            {
                                int rowSum = 0;
                                Console.Write($" {master, 8}");
                                for(int day = 1; day <= daysCount; day++)
                                {
                                    int clients = master + day * 2;
                                    rowSum += clients;
                                    grandTotal += clients;
                                    Console.Write($"{clients, 8}");

                                }
                                Console.Write($"{rowSum, 10}");
                                Console.WriteLine("");
                            }
                            Console.Write($"{"Підсумок", 8}");
                            for (int days = 1; days <= daysCount; days++)
                            {
                                int colSum = 0;
                                for(int masters = 1; masters <= mastersCount; masters++)
                                {
                                    int clients = masters + days * 2;
                                    colSum += clients;
                                }
                                Console.Write($"{colSum, 8}");
                            }
                            Console.Write($"{grandTotal, 10}");
                            Console.WriteLine();
                            Pause();
                            break;
                        }
                    case "0":
                        {
                            Console.WriteLine("До побачення!");
                            running = false;
                            break;
                        }
                    default:
                        {
                            Console.Write("Такої опції не існує.Введіть ще раз: ");
                            Pause();
                            break;
                        }
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== БАРБЕРШОП ===");
            Console.WriteLine("1. Довідка (про програму) ");
            Console.WriteLine("2. Розрахунок вартості послуги від часу");
            Console.WriteLine("3. Зведена таблиця завантаженості");
            Console.WriteLine("0. Вихід ");
            Console.Write("Оберіть опцію: ");
        }

        static void ShowAbout()
        {
            Console.WriteLine("Тема 19: Барбершоп. Зберігаю сутності: int номер запису, string клієнт, " +
    "\nstring майстер, int код, DateTime дата й час, int тривалість у хвилинах, double ціна, " +
    "bool чи виконано.");
        }

        static void ShowCostTable(double start, double end, double step)
        {
            Console.WriteLine(" \n   " +
                                "  Час (год):" +
                              "    Вартість (грн):");
            for (double time = start; time <= end + 1e-9; time += step) // 1e-9 заберу і подивлюсь
            {
                double price = time * 500 + 100; // час * 500 + 100 (100 - ціна за миття голови)
                Console.WriteLine($"{time,10:F2}  {price,15:F2}");
            }
        }
        static void Pause()
        {
            Console.ReadKey(true);
        }
    }
} 