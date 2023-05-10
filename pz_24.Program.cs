using System;

namespace pz_24
{
    public class Package : ICloneable
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
        public virtual void GetPackageInfo()
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

        // Реализация интерфейса ICloneable
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class UndeliveredPackage : Package, ICloneable
    {
        // Причина недоставки посылки
        public string Reason { get; set; }

        // Конструктор без параметров со значениями по умолчанию 
        public UndeliveredPackage() : base()
        {
            Reason = "Неизвестно";
        }

        // Конструктор с параметрами для имени отправителя и получателя 
        public UndeliveredPackage(string nameDest, string nameSor) : base(nameDest, nameSor)
        {
            Reason = "Неизвестно";
        }

        // Конструктор с параметрами для всех полей класса 
        public UndeliveredPackage(string nameDest, string nameSor, string address, DateTime receiptDate, string type, double weight, string reason) : base(nameDest, nameSor, address, receiptDate, type, weight)
        {
            Reason = reason;
        }

        // Переопределение метода для вывода информации о посылке 
        public override void GetPackageInfo()
        {
            base.GetPackageInfo();
            Console.WriteLine($"Причина недоставки: {Reason}");
        }

        // Реализация интерфейса ICloneable
        public new object Clone()
        {
            return new UndeliveredPackage(NameDest, NameSor, Address, ReceiptDate, Type, Weight, Reason);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            UndeliveredPackage package1 = new UndeliveredPackage("Иван", "Петр", "ул. Ленина, 5", DateTime.Now, "Документы", 0.5, "Отсутствие получателя");
            UndeliveredPackage package2 = (UndeliveredPackage)package1.Clone();

            package1.GetPackageInfo();
            package2.GetPackageInfo();

            package2.Reason = "Неправильный адрес";

            package1.GetPackageInfo();
            package2.GetPackageInfo();
        }
    }
}