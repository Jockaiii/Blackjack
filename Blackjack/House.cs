namespace Blackjack
{
    using System.Collections.Generic;
    public static class House
    {
        public static readonly List<Card> HouseHand = new List<Card>(); // Är husets hand. Innehåller alla kort som dras till huset.
        public static int HouseSum { get; set; } = 0; // Är värdet av alla korten i husets hand.
    }
}