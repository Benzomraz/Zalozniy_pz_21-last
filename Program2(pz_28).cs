
using System;
using System.Threading;

namespace ConsoleApp
{
    class Car
    {
        public int Speed { get; private set; }
        public void Accelerate()
        {
            if (Speed < 200)
                Speed++; // Увеличиваем скорость на 1 км/ч
        }
    }

    class Patrol
    {
        private bool detentionModeActivated = false;
        private bool speedWarning100 = false;
        private bool speedWarning150 = false;
        private int maxSpeedCount = 0;
        public void CheckSpeed(Car car)
        {
            if (car.Speed > 120 && !detentionModeActivated)
            {
                Console.WriteLine("Активация режима задержания!");
                detentionModeActivated = true;
            }
            else if (car.Speed == 100 && !speedWarning100)
            {
                Console.WriteLine("Предупреждение! Пожалуйста, снизьте скорость!");
                speedWarning100 = true;
            }
            else if (car.Speed == 150 && !speedWarning150)
            {
                Console.WriteLine("Предупреждение! Пожалуйста, снизьте скорость!");
                speedWarning150 = true;
            }

            if (car.Speed == 200)
                maxSpeedCount++;

            if (maxSpeedCount == 20)
            {
                Console.WriteLine("Вы оторвались от копов!");
                Environment.Exit(0);
            }
        }
    }

    class Transmission
    {
        private bool activated = false;
        public void CheckSpeed(Car car)
        {
            if ((car.Speed == 80 || car.Speed == 135) && !activated)
            {
                Console.WriteLine("Переключение передачи!");
                activated = true;
            }
            else if (activated)
            {
                for (int i = 0; i < 5; i++)
                    Console.WriteLine(car.Speed - i - 1);
                activated = false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Patrol patrol = new Patrol();
            Transmission transmission = new Transmission();

            Action accelerateAndCheckSpeed = () =>
            {
                car.Accelerate();
                patrol.CheckSpeed(car);
                transmission.CheckSpeed(car);
            };

            for (int i = 0; i < 250; i++)
            {
                accelerateAndCheckSpeed();
                Console.WriteLine($"Current speed: {car.Speed}");
                Thread.Sleep(50);
            }
        }
    }
}



