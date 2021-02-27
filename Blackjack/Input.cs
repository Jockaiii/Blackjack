namespace Blackjack
{
    using System;
    internal static class Input
    {
        /// <summary>
        /// CreatePlayers() tar emot input av användaren och tilkallar metdon som skapar spelare "amountOfPlayers" gånger.
        /// </summary>
        public static void CreatePlayers()
        {
            int amountOfPlayers;
            do
            {
                Output.OutputAmountOfPlayers();
                amountOfPlayers = InputHandler.PlayerAmountHandler();
            } while (amountOfPlayers == 0);

            for (int i = 0; i < amountOfPlayers; i++)
            {
                Player player = new Player(i + 1);
                Player.Players.Add(player);
            }
        }

        /// <summary>
        /// CreateDecks() tar emot input av användaren och tillkallar metoden som skapar kortleckar "amountOfDecks" gånger därefter.
        /// </summary>
        public static void CreateDecks()
        {
            int amountOfDecks;
            do
            {
                Output.OutputAmountOfDecks();
                amountOfDecks = InputHandler.DeckAmountHandler();
            } while (amountOfDecks == 0);

            for (int i = 0; i < amountOfDecks; i++)
            {
                _ = new Deck();
            }
        }

        /// <summary>
        /// ChooseBet() tar emot input av användaren och sätter spelarens PlayerBet till betet om det går igenom InputHandlern()
        /// </summary>
        /// <param name="currentPlayer"></param>
        public static void ChooseBet(int currentPlayer)
        {
            int bet;
            do
            {
                Output.OutputBet(Player.Players[currentPlayer].PlayerName);
                bet = InputHandler.BetHandler(currentPlayer);
            } while (bet == 0);
            Player.Players[currentPlayer].PlayerBet = bet;
        }

        /// <summary>
        /// Väntar på ett knapptryck av användaren för att fortsätta kompilera programmet.
        /// </summary>
        /// <returns>returneras att användaren har tryckt ner en knapp.</returns>
        public static string Continue()
        {
            return Console.ReadLine();
        }
    }
}