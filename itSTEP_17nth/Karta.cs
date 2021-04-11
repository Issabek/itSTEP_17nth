using System;
namespace itSTEP_17nth
{
    public enum Mast
    {
        Chervi=1,
        Bubni=2,
        Trefi=3,
        Piki=4
    }
    public enum Rang
    {
        Shest=6,
        Sem=7,
        Vosem=8,
        Devyat=9,
        Desyat=10,
        Jack=11,
        Queen=12,
        King=13,
        Ace=14
    }

    public class Karta
    {
        public Mast mast { get; set; }
        public Rang rang { get; set; }
        public Karta(Mast mastt, Rang rangg)
        {
            this.mast = mastt;
            this.rang = rangg;

        }
        public Karta()
        {

        }
        public static bool operator>(Karta obj1, Karta obj2)
        {
            return obj1.rang > obj2.rang ? true : false;
        }
        public static bool operator<(Karta obj1, Karta obj2)
        {
            return obj1.rang < obj2.rang ? true : false;
        }
    }

}
