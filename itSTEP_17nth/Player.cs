using System;
using System.Linq;
using System.Collections.Generic;

namespace itSTEP_17nth
{
    public class Player
    {
        public Stack<Karta> koloda = new Stack<Karta>();
        public string Name { get; set; }
        public Karta Turn()
        {
            return koloda.Pop();
        }
        public void GetCards(Stack<Karta> kartas)
        {
            int size = kartas.Count + koloda.Count;
            Karta[] templ = new Karta[size];
            kartas.CopyTo(templ, 0);
            koloda.CopyTo(templ, kartas.Count);
            koloda = new Stack<Karta>(templ);

        }
        public Player()
        {
        }
        public Player(string Name)
        {
            this.Name = Name;
        }
    }
}
