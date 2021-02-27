namespace Blackjack
{
    using System;
    using System.Collections.Generic;
    internal static class Blackjack
    {
        /// <summary>
        /// StartRound() ser till så att kod körs i rätt ordning för att en runda ska kunna spelas.
        /// </summary>
        public static void StartRound()
        {
            Random rnd = new Random();

            Input.CreatePlayers();
            Input.CreateDecks();

            for (int i = 0; i < Player.Players.Count; i++)
            {
                Input.ChooseBet(i);

                var continueDrawing = true;
                do
                {
                    var nextCard = rnd.Next(0, Deck.CardDeck.Count);
                    Player.Players[i].PlayerHand.Add(Deck.CardDeck[nextCard]);
                    Output.OutputCard(Deck.CardDeck[nextCard], Player.Players[i].PlayerName);
                    Deck.CardDeck.RemoveAt(nextCard);

                    if (GameLogic.PlayerChecker(i))
                    {
                        continueDrawing = false;
                    }
                    else
                    {
                        Output.OutputContinue();
                        var answer = Input.Continue().ToLower();
                        if (answer == "n" || answer == "no")
                        {
                            continueDrawing = false;
                        }
                    }

                } while (continueDrawing);
            }

            do
            {
                var houseNextCard = rnd.Next(0, Deck.CardDeck.Count);
                House.HouseHand.Add(Deck.CardDeck[houseNextCard]);
                Output.OutputCard(Deck.CardDeck[houseNextCard], "House");
                Deck.CardDeck.RemoveAt(houseNextCard);
                Output.OutputWaitForEnter();
                Console.ReadKey();

            } while (!GameLogic.HouseChecker());

            GameLogic.GameResults();
        }
    }
}