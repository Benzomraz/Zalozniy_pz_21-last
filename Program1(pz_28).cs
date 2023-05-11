
using System;
using System.Threading;

namespace ConsoleApp
{
    class Otshiot
    {
        // Определение делегата для события OnSchiot
        public delegate void CounterEventHandler(int count);
        public event CounterEventHandler OnSchiot;

        public void Schiot()
        {
            // Генерация последовательности чисел от 1 до 1000
            for (int i = 1; i <= 1000; i++)
            {
                // Вызов события OnSchiot с текущим значением счетчика
                OnSchiot?.Invoke(i);

                // Задержка на 0,1 секунды
                Thread.Sleep(45);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта
            Otshiot counter = new Otshiot();

            // Добавление обработчика события OnSchiot для вывода каждого значения отсчета на экран
            counter.OnSchiot += count =>
            {
                Console.WriteLine(count);
            };

            // Добавление обработчика события OnSchiot
            counter.OnSchiot += count =>
            {
                // Проверка значения счетчика и вывод сообщения при достижении значения 200
                if (count == 200)
                {
                    Console.WriteLine("Вы дошли до 200!");
                }
            };

            // Добавление обработчика события OnSchiot
            counter.OnSchiot += count =>
            {
                // Проверка значения счетчика и вывод сообщения при достижении значения 800
                if (count == 800)
                {
                    Console.WriteLine("Вы дошли до 800!");
                }
            };

            // Запуск метода Schiot
            counter.Schiot();
        }
    }
}