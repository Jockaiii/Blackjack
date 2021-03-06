using System;

namespace Blackjack
{
    public static class Blackjack
    {
        public static bool IsTesting { get; set; }  =  false; // Snodd av Marcus Medina :). Ser till att input bara hämtas när programmet kompileras som vanligt (inte i unit tests)

        /// <summary>
        /// StartRound() ser till så att kod körs i rätt ordning för att en runda ska kunna spelas.
        /// </summary>
        public static void StartRound()
        {
            if (!IsTesting)
            {
                Input.CreatePlayers();
                //Input.CreateDecks(); borttagen pga uppdaterade krav på inlämningen.
            }
            else
            {
                Player.Players.Clear(); // Rensar tidigare spelare från andra tester.
                Player player = new Player(1); // skapar en spelare automatisk för att kunna testa metoden i unit tests.
                Player player2 = new Player(2);
                Player.Players.Add(player);
                Player.Players.Add(player2);
            }

            _ = new Deck(); // Skapar 3 kortleckar som standard.
            PlayerHandler(); // Alla spelare hanteras
            HouseHandler(); // Huset hanteras
            GameLogic.GameResults(); // Ger spelresultat för rundan.
        }

        /// <summary>
        /// Hanterar allting som har med att dra kort till spelare. Betting och datorhjälpare.
        /// </summary>
        internal static void PlayerHandler()
        {
            Random rnd = new Random();
            for (int i = 0; i < Player.Players.Count; i++)
            {
                if (!IsTesting)
                    Input.ChooseBet(i);

                var continueDrawing = true;
                do
                {
                    var nextCard = rnd.Next(0, Deck.CardDeck.Count);
                    Player.Players[i].PlayerHand.Add(Deck.CardDeck[nextCard]);
                    Output.OutputCard(Deck.CardDeck[nextCard], Player.Players[i].PlayerName);
                    Deck.CardDeck.RemoveAt(nextCard);

                    if (GameLogic.PlayerChecker(i))
                        continueDrawing = false;
                    else if (!IsTesting)
                    {
                        PlayerHelper.Helper(i);
                        Output.OutputContinue();
                        var answer = Input.Continue().ToLower();
                        if (answer == "n" || answer == "no")
                            continueDrawing = false;
                    }

                } while (continueDrawing);
            }
        }

        /// <summary>
        /// Hanterar allting som har med att dra kort till huset.
        /// </summary>
        internal static void HouseHandler()
        {
            Random rnd = new Random();
            do
            {
                var houseNextCard = rnd.Next(0, Deck.CardDeck.Count);
                House.HouseHand.Add(Deck.CardDeck[houseNextCard]);
                Output.OutputCard(Deck.CardDeck[houseNextCard], "House");
                Deck.CardDeck.RemoveAt(houseNextCard);
                if (!IsTesting)
                    Input.Continue();
            } while (!GameLogic.HouseChecker());
        }
    }
}