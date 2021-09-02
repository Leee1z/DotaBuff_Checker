using System;
using System.Linq;
using HtmlAgilityPack;

namespace scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool RUN = true;
            Console.WriteLine("Dota Buff Cheaker v 1.0");
            Console.WriteLine("Author: Le1z");
            while (RUN)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Введите id пользователя: ");
                var id = Console.ReadLine();

                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load($"https://ru.dotabuff.com/players/{id}");

                bool Check = true;
                var Status = doc.DocumentNode.SelectNodes("//h2[@id='status']");

                if (Status is not null) Check = Status.Any(x => x.InnerText == "Not found");

                if (Check)
                {
                    var Rank = doc.DocumentNode.SelectSingleNode("//div[@class='rank-tier-wrapper']");
                    var Name = doc.DocumentNode.SelectSingleNode("//div[@class='header-content-title']");
                    var LastGame = doc.DocumentNode.SelectSingleNode("//div[@class='header-content-secondary']");

                    Console.WriteLine(" ");
                    Console.WriteLine($"Ник: {Name.LastChild.FirstChild.InnerText}");
                    Console.WriteLine(Rank.Attributes[2].Value);
                    Console.WriteLine($"Последняя игра: {LastGame.FirstChild.FirstChild.InnerText}");
                    
                } else
                {
                    Console.WriteLine("Вы ввели не верный id!");
                    continue;
                }
            }
        }
    }
}
