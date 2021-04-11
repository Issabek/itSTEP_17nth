using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace itSTEP_17nth
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Player> players = new List<Player> {
            // new Player("P1"),
            // new Player("P2")
            //};
            //Game newGame = new Game(players);

            task6(@"/Users/sensei.rin/Desktop/itstep.txt");
        }

        private static void task6(string path)
        {
                string text = System.IO.File.ReadAllText(path);
                string[] temp = text.Split(' ');
                Dictionary<string, int> textDict = new Dictionary<string, int>();
                foreach (string item in temp)
                {
                    var t = Regex.Replace(item, @"[^\w]*", String.Empty);
                    if (t.Length < 1)
                        continue;
                    if (textDict.ContainsKey(t))
                        textDict[t] += 1;
                    else
                    {
                        textDict.Add(t, 1);
                    }
                }

                foreach (var item in textDict)
                {
                    Console.WriteLine(item.Key + " ----- " + item.Value);
                }
                Console.WriteLine("Всего слов: {0} ; Уникальных : {1}", textDict.Values.Sum(), textDict.Keys.Count());
            }
    }
}
