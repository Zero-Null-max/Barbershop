using System.Collections.Concurrent;
using System.Timers;

namespace Barbershop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double[] durations = new double[100];
            int itemsCount = 0;
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
                            double startTime = ReadDouble("Введіть початковий час (год): ", 0.25, 0.5);
                            double endTime = ReadDouble("Введіть кінцевий час (год): ", 1, 4);
                            double step = ReadDouble("Введіть крок (год): ", 0.1, 1);
                            ShowCostTable(startTime, endTime, step);
                            Pause();
                            break;
                        }
                    case "3":
                        {
                            ShowWorkload();
                            Pause();
                            break;
                        }
                    case "4":
                        {
                            double newValue = ReadDouble("Введіть тривалість стрижки (год): ", 0.25, 4);
                            AddValue(durations, ref itemsCount, newValue);
                            Console.WriteLine($"{itemsCount}");
                            Pause();
                            break;
                        }
                    case "5":
                        {
                            ShowDurations(durations, itemsCount);
                            Pause();
                            break;
                        }
                    case "6":
                        {
                            if(FindMaxDurations(durations, itemsCount, out double maxTime, out int maxNumber))
                            {
                                Console.WriteLine($"Найдовша стрижка: №{maxNumber} - {maxTime:F2} год");
                            }
                            else
                            {
                                Console.WriteLine("Записів поки немає!");
                            }
                            Pause();
                            break;
                        }
                    case "7":
                        {
                            int singlePrice = 500; 
                            int[] pricesList = { 500, 700 }; 

                            Console.WriteLine($"int ДО методу: {singlePrice}"); 
                            TryChangeInt(singlePrice); 
                            Console.WriteLine($"int ПІСЛЯ методу: {singlePrice}"); 

                            Console.WriteLine($"\nМасив[0] ДО методу: {pricesList[0]}"); 
                            ChangeArrayElement(pricesList); 
                            Console.WriteLine($"Масив[0] ПІСЛЯ методу: {pricesList[0]}"); 
                            Pause();
                            break;
                        }
                    case "8":
                        {
                            ShowDurations(durations, itemsCount); 
                            int number = ReadInt("Введіть номер запису для видалення ", 0, 100); 
                            RemoveAt(durations, ref itemsCount, number - 1); 
                            Pause(); 
                            break;
                        }
                    case "9":
                        {
                            if (itemsCount == 0) 
                            {
                                Console.WriteLine("Записів поки немає!"); 
                            }
                            else
                            {
                                Statistics(durations, itemsCount, out double sum, out double average); 
                                FindMaxDurations(durations, itemsCount, out double maxTime, out int maxNumber); 
                                Console.WriteLine($"Усього записів: {itemsCount}"); 
                                Console.WriteLine($"Загальний час: {sum:F2} год"); 
                                Console.WriteLine($"Середній час: {average:F2} год"); 
                                Console.WriteLine($"Найдовша стрижка: №{maxNumber} ({maxTime:F2} год)"); 
                            }
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
            Console.WriteLine("4. Додати тривалість");
            Console.WriteLine("5. Показати список тривалостей");
            Console.WriteLine("6. Найдовша стрижка");
            Console.WriteLine("7. Дослід: int проти масиву");
            Console.WriteLine("8. Видалити тривалість за номером"); 
            Console.WriteLine("9. Показати статистику"); 


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
                double price = CalculateCost(time);
                Console.WriteLine($"{time,10:F2}  {price,15:F2}");
            }
        }

        static double CalculateCost(double hours)
        {
            return
            hours * 500 + 100; // час * 500 + 100 (100 - ціна за миття голови)
        }

        static void ShowWorkload()
        {
            int mastersСount = ReadInt("Введіть кількість майстрів ", 1, 10);
            int daysСount = ReadInt("Введіть кількість днів ", 1, 7);
            int grandTotal = 0;
            Console.Write("\n");
            Console.Write("         ");
            for (int day = 1; day <= daysСount; day++)
            {
                Console.Write($"{day,8}");
            }
            Console.WriteLine($"{"Підсумок!",10}");
            for (int master = 1; master <= mastersСount; master++)
            {
                int rowSum = 0;
                Console.Write($" {master,8}");
                for (int day = 1; day <= daysСount; day++)
                {
                    int clients = master + day * 2;
                    rowSum += clients;
                    grandTotal += clients;
                    Console.Write($"{clients,8}");

                }
                Console.Write($"{rowSum,10}");
                Console.WriteLine("");
            }
            Console.Write($"{"Підсумок",8}");
            for (int days = 1; days <= daysСount; days++)
            {
                int colSum = 0;
                for (int masters = 1; masters <= mastersСount; masters++)
                {
                    int clients = masters + days * 2;
                    colSum += clients;
                }
                Console.Write($"{colSum,8}");
            }
            Console.Write($"{grandTotal,10}");
            Console.WriteLine();
        }

        static double ReadDouble(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write($"{prompt}(від {min} до {max}): ");
                bool success = double.TryParse( Console.ReadLine(), out double number);
                if (!success)
                {
                    Console.WriteLine("Помилка: це не число!");
                }
                else if(number < min || number > max )
                {
                    Console.WriteLine($"Помилка: число має бути від {min} до {max}");
                }
                else
                {
                    return number;
                }
            }
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write($"{prompt}(від {min} до {max}): ");
                bool success = int.TryParse(Console.ReadLine(), out int number);
                if (!success)
                {
                    Console.WriteLine("Помилка: це не число!");
                }
                else if (number < min || number > max)
                {
                    Console.WriteLine($"Помилка: число має бути від {min} до {max}");
                }
                else
                {
                    return number;
                }
            }
        }

        static void AddValue(double[] durations, ref int itemsCount, double newValue)
        {
            if (itemsCount >= durations.Length)
            {
                Console.WriteLine("Місць немає!");
                return;
            }
            else
            {
                durations[itemsCount] = newValue;
                itemsCount += 1;
            }
        }

        static void ShowDurations(double[] durations, int itemsCount)
        {          
            if(itemsCount == 0)
            {
                Console.WriteLine("Записів поки немає!");
                return;
            }
            Console.WriteLine(" \n   " +
               "  №: " +
               "  Тривалість (год): ");
            for (int i = 0; i < itemsCount; i++)
            {
                Console.WriteLine($" {i + 1, 5}        {durations[i], 5:F2}");
            }
        }

        static bool FindMaxDurations(double[] durations, int itemsCount, out double maxTime, out int maxNumber)
        {
            if(itemsCount == 0)
            {
                maxTime = 0;
                maxNumber = 0;
                return false;
            }

            maxTime = durations[0];
            maxNumber = 1;

            for(int i = 0; i < itemsCount; i++)
            {
                if (durations[i] > maxTime)
                {
                    maxTime = durations[i];
                    maxNumber = i + 1;
                }
            }

            return true;
        }

        static void TryChangeInt(int price)
        {
            price = price + 100; 
            Console.WriteLine($"Усередині TryChangeInt: {price}"); 
        }

        static void ChangeArrayElement(int[] prices)
        {
            prices[0] = prices[0] + 100; 
            Console.WriteLine($"Усередині ChangeArrayElement: {prices[0]}"); 
        }

        static void RemoveAt(double[] durations, ref int itemsCount, int index)
        {
            if (index < 0 || index >= itemsCount) 
            {
                Console.WriteLine("Неправильний номер запису!"); 
                return; 
            }

            for (int i = index; i < itemsCount - 1; i++) 
            {
                durations[i] = durations[i + 1]; 
            }

            itemsCount--; 
            Console.WriteLine("Запис видалено!"); 
        }

        static void Statistics(double[] durations, int itemsCount, out double sum, out double average)
        {
            sum = 0; 

            for (int i = 0; i < itemsCount; i++) 
            {
                sum += durations[i]; 
            }

            average = itemsCount > 0 ? sum / itemsCount : 0; 
        }


        static void Pause()
        {
            Console.ReadKey(true);
        }
    }
} 