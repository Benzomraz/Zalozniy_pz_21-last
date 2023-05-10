using System;

namespace pz_22
{
    public class Package
    {
        // Имя отправителя
        private string _nameDest;
        public string NameDest
        {
            get { return _nameDest; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _nameDest = value;
            }
        }

        // Имя получателя
        private string _nameSor;
        public string NameSor
        {
            get { return _nameSor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _nameSor = value;
            }
        }

        // Адрес назначения
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _address = value;
            }
        }

        // Дата отправки
        public DateTime ReceiptDate { get; set; }

        // Тип посылки
        public string Type { get; set; }

        // Вес посылки
        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value >= 0.01 && value <= 10)
                {
                    TotalWeight -= _weight;
                    TotalWeight += value;
                    _weight = value;
                }
            }
        }

        // Общий вес посылок 
        public static double TotalWeight { get; private set; }

        // Количество посылок 
        public static int PackageCount { get; private set; }

        // Конструктор без параметров со значениями по умолчанию 
        public Package()
        {
            NameDest = "Неизвестно";
            NameSor = "Неизвестно";
            Address = "Неизвестно";
            ReceiptDate = DateTime.Now;
            Type = "Неизвестно";
            Weight = 0.01;
            PackageCount++;
        }

        // Конструктор с параметрами для имени отправителя и получателя 
        public Package(string nameDest, string nameSor)
        {
            NameDest = nameDest;
            NameSor = nameSor;
            Address = "Неизвестно";
            ReceiptDate = DateTime.Now;
            Type = "Неизвестно";
            Weight = 0.01;
            PackageCount++;
        }

        // Конструктор с параметрами для всех полей класса 
        public Package(string nameDest, string nameSor, string address, DateTime receiptDate, string type, double weight)
        {
            NameDest = nameDest;
            NameSor = nameSor;
            Address = address;
            ReceiptDate = receiptDate;
            Type = type;
            Weight = weight;
            PackageCount++;
        }

        // Метод для вывода информации о посылке 
        public void GetPackageInfo()
        {
            Console.WriteLine($"Отправитель: {NameDest}");
            Console.WriteLine($"Получатель: {NameSor}");
            Console.WriteLine($"Адрес назначения: {Address}");
            Console.WriteLine($"Дата отправки: {ReceiptDate}");
            Console.WriteLine($"Тип посылки: {Type}");
            Console.WriteLine($"Вес посылки: {Weight} кг");
        }

        // Статический метод для вывода общей информации о посылках 
        public static void GetTotalInfo()
        {
            Console.WriteLine($"Общий вес посылок: {TotalWeight} кг");
            Console.WriteLine($"Количество посылок: {PackageCount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Package package1 = new Package();
            Package package2 = new Package("Иван", "Петр");
            Package package3 = new Package("Анна", "Мария", "ул. Ленина, 5", DateTime.Now, "Документы", 0.5);

            package1.GetPackageInfo();
            package2.GetPackageInfo();
            package2.GetPackageInfo();
            package3.GetPackageInfo();

            Package.GetTotalInfo();
        }
    }
}