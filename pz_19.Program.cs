using System;
using System.IO;
using System.Text.RegularExpressions;

namespace pz_19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            string text1 = @"1 RU161109-472905 PACK19697671 1 Ольга Каверзина +7 (918) 335-43-52 Наличные Плюс 0
09:00 - 13:00 Краснодар, красина, Дом 3/3, Кв. 76
2 RU161110-466130 PACK19651968 1 Софья назаретян +7 (918) 398-07-81 Наличные Плюс 0
09:00 - 13:00 Краснодар, Базовская, Дом д.61
3 RU161111-260536 PACK19698066 3 Виктор Кипуров +7 (918) 441-97-56 Наличные Плюс 0
09:00 - 13:00 Краснодар, Речная,Чехова , Дом 4, Кв. 52
4 RU161111-522664 PACK19697905 2 Ирина Концевик +7 (918) 045-77-00 Наличные Плюс 0
09:00 - 13:00 Краснодар, ул им Братьев Дроздовых, Дом 41, Кв. 19
5 RU161111-252357 PACK19697840 1 Ирина Концевик +7 (918) 045-77-00 Наличные Плюс 0
09:00 - 13:00 Краснодар, ул им Братьев Дроздовых, Дом 41, Кв. 19
6 RU161104-298585 PACK19514804 3 Роман +7 (938) 435-93-29 Наличные Плюс 0 09:00 - 13:00
Краснодар, фурманова, Дом 62";
            string pattern1 = @"\d\s[A-Z]+\d+-\d+\s[A-Z]+\d+\s\d\s([А-Яа-я]+\s[А-Яа-я]+)";
            MatchCollection matches1 = Regex.Matches(text1, pattern1);
            string[] result1 = new string[matches1.Count];
            for (int i = 0; i < matches1.Count; i++)
            {
                result1[i] = matches1[i].Groups[1].Value;
                Console.WriteLine(result1[i]);
            }

            // Задание 2
            string text2 = File.ReadAllText(@"connects.log");
            string ipPattern = @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})";
            string datePattern = @"\[(\d{2}\/\w{3}\/\d{4}:\d{2}:\d{2}:\d{2}\s\+\d{4})\]";
            MatchCollection ipMatches = Regex.Matches(text2, ipPattern);
            MatchCollection dateMatches = Regex.Matches(text2, datePattern);
            string[] ipAddresses = new string[ipMatches.Count];
            string[] connectionDates = new string[dateMatches.Count];
            for (int i = 0; i < ipMatches.Count; i++)
            {
                ipAddresses[i] = ipMatches[i].Groups[1].Value;
                Console.WriteLine(ipAddresses[i]);
            }
            for (int i = 0; i < dateMatches.Count; i++)
            {
                connectionDates[i] = dateMatches[i].Groups[1].Value;
                Console.WriteLine(connectionDates[i]);
            }
        }
    }
}