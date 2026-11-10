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
