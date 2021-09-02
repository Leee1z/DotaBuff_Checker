using System;
using System.Linq;
using HtmlAgilityPack;

namespace scrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dota Buff Cheaker v 1.0");
            Console.WriteLine("Author: Le1z");
            while (true)
            {
                Console.WriteLine("\nВведите id пользователя: ");
                var id = Console.ReadLine();

                var web = new HtmlWeb();
                var doc = web.Load($"https://ru.dotabuff.com/players/{id}");
                
                var status = doc.DocumentNode.SelectNodes("//h2[@id='status']");
                var check = status?.Any(x => x.InnerText == "Not found") ?? true;
                
                if (check)
                {
                    var rank = doc.DocumentNode.SelectSingleNode("//div[@class='rank-tier-wrapper']");
                    var name = doc.DocumentNode.SelectSingleNode("//div[@class='header-content-title']");
                    var lastGame = doc.DocumentNode.SelectSingleNode("//div[@class='header-content-secondary']");

                    Console.WriteLine($"\nНик: {name.LastChild.FirstChild.InnerText}");
                    Console.WriteLine(rank.Attributes[2].Value);
                    Console.WriteLine($"Последняя игра: {lastGame.FirstChild.FirstChild.InnerText}");
                    continue;
                }
                Console.WriteLine("Вы ввели не верный id!");
            }
        }
    }
}
