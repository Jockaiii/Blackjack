using System.Collections.Generic;

namespace Blackjack
{
    public class Deck
    {
        public static List<Card> CardDeck { get; set; } = new List<Card>(); // Är alla korten från så många kortleckar som användaren valt.

        internal Deck() // lägger 3 kortleckar i CardDeck för varje gång klassen instanseras.
        {
            for (int i = 0; i < 3; i++) // Skapar nu 3 decks som default efter uppdaterade vilkor på inlämnings uppgiften.
            {
                for (int j = 0; j < Card.CardSuites.Count; j++)
                {
                    for (int k = 0; k < Card.CardNumbers.Count; k++)
                    {
                        CardDeck.Add(new Card(Card.CardSuites[j],  Card.CardNumbers[k]));
                    }
                }
            }
        }
    }
}