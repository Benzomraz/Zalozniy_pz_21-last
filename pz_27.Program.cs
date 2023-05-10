using System;
using System.Linq;

namespace pz_27
{
    public struct Worker
    {
        public string Name;
        public string Pos;
        public int Year;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Worker[] tabl = new Worker[10];

            for (int i = 0; i < tabl.Length; i++)
            {
                Console.WriteLine("Введите фамилию и инициалы работника:");
                tabl[i].Name = Console.ReadLine();

                Console.WriteLine("Введите название занимаемой должности:");
                tabl[i].Pos = Console.ReadLine();

                Console.WriteLine("Введите год поступления на работу:");
                tabl[i].Year = int.Parse(Console.ReadLine());
            }

            Array.Sort(tabl, (x, y) => string.Compare(x.Name, y.Name));

            Console.WriteLine("Введите минимальный стаж работы:");
            int minExperience = int.Parse(Console.ReadLine());

            var experiencedWorkers = tabl.Where(w => DateTime.Now.Year - w.Year > minExperience);

            if (experiencedWorkers.Any())
            {
                Console.WriteLine("Работники со стажем работы более {0} лет:", minExperience);
                foreach (var worker in experiencedWorkers)
                {
                    Console.WriteLine(worker.Name);
                }
            }
            else
            {
                Console.WriteLine("Нет работников со стажем работы более {0} лет.", minExperience);
            }
        }
    }
}