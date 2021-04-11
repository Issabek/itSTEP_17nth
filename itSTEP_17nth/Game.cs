using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
namespace itSTEP_17nth
{ 
    public static class helpa
    {
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }
        public static T Pop<T>(this IList<T> list)
        {
            var temp = list[list.Count - 1];
            list.Remove(temp);
            return temp;
        }
    }
    public class Game
    {
        Random rnd = new Random();

        public List<Player> Players = new List<Player>();
        public List<Karta> Koloda = new List<Karta>();
        private void Shuffle()
        {
            for(int i = 0; i < 17; i++)
            {
                Koloda.Swap(rnd.Next(36), rnd.Next(36));
            }
        }

        public Game(List<Player> players)
        {
            Players = players;
            CreateKoloda();
            Shuffle();
            Razdacha();
            GameProcess();
        }
        public void GameProcess()
        {
            int maxKarta = 0;
            while (!Players.Any(p => p.koloda.Count == 36)) {
                Stack<Karta> turn = new Stack<Karta>();
                for(int i = 0; i < Players.Count; i++)
                {
                    if (i == 1 && Players[i].koloda.Peek() > turn.Peek())
                        maxKarta = i;
                    else
                        maxKarta = 0;
                    if (Players[i].koloda.Peek() > Players[maxKarta].koloda.Peek())
                        maxKarta = i;
                    Console.WriteLine("Ходит игрок {0} картой: {1} {2}",Players[i].Name,Players[i].koloda.Peek().mast, Players[i].koloda.Peek().rang);
                    Thread.Sleep(1000);
                    turn.Push(Players[i].koloda.Pop());
                }
                Players[maxKarta].GetCards(turn);
                maxKarta = 0;
            }
            Console.WriteLine("Победил игрок {0}!!!",Players.Where(p=>p.koloda.Count==36).First().Name);
        }
        private void Razdacha()
        {
            int num = Koloda.Count / Players.Count;
            for(int i = 0; i < num; i++)
            {
                foreach(Player player in Players)
                {
                    player.koloda.Push(Koloda.Pop());
                }
            }
            var s =Players[0].koloda.Distinct();
        }
        private void CreateKoloda()
        {
            int counter = 0;
            while(true)
            {
                if (counter == 36)
                    break;
                Karta karta = new Karta((Mast)rnd.Next(1, 5), (Rang)rnd.Next(6, 15));
                if (Koloda.Any(k=>k.mast==karta.mast && k.rang==karta.rang))
                    continue;
                else
                {
                    Koloda.Add(karta);
                    counter++;
                }
            }
        }
    }
}
