namespace Zalozniy_pz_21
{
    public class Package
    {
        // Имя отправителя
        public string nameDest { get; set; }
        // Имя получателя
        public string nameSor { get; set; }
        // Адрес назначения
        public string address { get; set; }
        // Дата отправки
        public DateTime receiptDate { get; set; }
        // Тип посылки
        public string type { get; set; }

        // Конструктор без параметров со значениями по умолчанию
        public Package()
        {
            nameDest = "Неизвестно";
            nameSor = "Неизвестно";
            address = "Неизвестно";
            receiptDate = DateTime.Now;
            type = "Неизвестно";
        }

        // Конструктор с параметрами для имени отправителя и получателя
        public Package(string nameDest, string nameSor)
        {
            this.nameDest = nameDest;
            this.nameSor = nameSor;
            address = "Неизвестно";
            receiptDate = DateTime.Now;
            type = "Неизвестно";
        }

        // Конструктор с параметрами для всех полей класса
        public Package(string nameDest, string nameSor, string address, DateTime receiptDate, string type)
        {
            this.nameDest = nameDest;
            this.nameSor = nameSor;
            this.address = address;
            this.receiptDate = receiptDate;
            this.type = type;
        }

        public void GetPackageInfo()
        {
            Console.WriteLine($"Отправитель: {nameDest}");
            Console.WriteLine($"Получатель: {nameSor}");
            Console.WriteLine($"Адрес назначения: {address}");
            Console.WriteLine($"Дата отправки: {receiptDate}");
            Console.WriteLine($"Тип посылки: {type}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Package package1 = new Package();
            Package package2 = new Package("Иван", "Петр");
            Package package3 = new Package("Анна", "Мария", "ул. Ленина, 5", DateTime.Now, "Документы");
            Package package4 = new Package("Сергей", "Николай", "пр. Мира, 10", DateTime.Now.AddDays(1), "Посылка");

            package1.GetPackageInfo();
            package2.GetPackageInfo();
            package3.GetPackageInfo();
            package4.GetPackageInfo();
        }
    }
}