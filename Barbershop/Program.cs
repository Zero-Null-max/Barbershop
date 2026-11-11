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

                Console.WriteLine("=== БАРБЕРШОП ===");
                Console.WriteLine("1. Довідка (про програму) ");
                Console.WriteLine("2. Розрахунок вартості послуги від часу");
                Console.WriteLine("0. Вихід ");
                Console.Write("Оберіть опцію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Тема 19: Барбершоп. Зберігаю сутності: int номер запису, string клієнт, " +
                                "\nstring майстер, int код, DateTime дата й час, int тривалість у хвилинах, double ціна, " +
                                "bool чи виконано.");
                            Console.ReadKey(true);
                            break;
                        }
                    case "2":
                        {
                            double startTime = 0.5;
                            double endTime = 2.5;
                            double step = 0.25;
                            Console.WriteLine("      Час (год):" +
                              "    Вартість (грн):");
                            for (double time = startTime; time <= endTime +1e-9; time += step) // 1e-9 заберу і подивлюсь
                            {
                                double price = time * 500 + 100; // час * 500 + 100 (100 - ціна за миття голови)
                                Console.WriteLine($"{time,10:F2}  {price,15:F2}");
                            }
                            Console.ReadKey(true);
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
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}
