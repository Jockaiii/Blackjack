namespace Blackjack
{
    using System.Collections.Generic;
    internal class Deck
    {
        public static List<Card> CardDeck { get; set; } = new List<Card>(); // Är alla korten från så många kortleckar som användaren valt.

        public Deck() // lägger in en kortleck i CardDeck för varje gång klassen instanseras.
        {
            for (int j = 0; j < CardSuites.Count; j++)
            {
                for (int k = 0; k < CardNumbers.Count; k++)
                {
                    CardDeck.Add(new Card(CardSuites[j],  CardNumbers[k]));
                }
            }
        }

        private readonly List<string> CardNumbers = new List<string>() // är alla kortnummer i en kortleck.
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "J", "Q", "K", "A"
        };

        private readonly List<string> CardSuites = new List<string>() // är alla kortsuites i en kortleck.
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };
    }
}