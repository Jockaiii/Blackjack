namespace Blackjack
{
    using System.Collections.Generic;
    public class Card
    {
        public string CardNumber { get; set; } = string.Empty; // är värdet/siffran/nummret av ett kort.
        public string CardSuite { get; set; } = string.Empty; // är suiten av ett kort.
        public string SuitIcon { get; set; } = string.Empty; // är suiten av kortet i form av en ikon för att skrivas ut i output.
        public string NumberText { get; set; } = string.Empty; // är numret av kortet i form av text för att skrivas ut i output.
        public Card(string cardSuite, string cardNumber) // Skapar ett nytt kort varje gång klassen instanseras.
        {
            CardNumber = cardNumber;
            CardSuite = cardSuite;
            SuitIcon = SuitIcons[CardSuite];
            NumberText = NumberTexts[CardNumber];
        }

        private static readonly Dictionary<string, string> SuitIcons = new Dictionary<string, string>() // Ikoner för suites.
        {
            { "Hearts", "♥" },
            { "Diamonds", "♦" },
            { "Clubs", "♣" },
            { "Spades", "♠" }
        };

        private static readonly Dictionary<string, string> NumberTexts = new Dictionary<string, string>() // Text för nummer.
        {
            { "2", "Two" },
            { "3", "Three" },
            { "4", "Four" },
            { "5", "Five" },
            { "6", "Six" },
            { "7", "Seven" },
            { "8", "Eight" },
            { "9", "Nine" },
            { "10", "Ten" },
            { "J", "Jack" },
            { "Q", "Queen" },
            { "K", "King" },
            { "A", "Ace" }
        };
    }
}