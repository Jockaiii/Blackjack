using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackjack
{
    internal static class InputHandler
    {
        /// <summary>
        /// Behandlar spelarens input av mängden spelare. Och ber användaren välja antal spelare igen om svaret är nej.
        /// </summary>
        /// <returns>amountOfPlayers om inputen är godkänt, 0 om den är inkorrekt.</returns>
        public static int PlayerAmountHandler()
        {
            var amountOfPlayers = Console.ReadLine();
            char[] allowedCharacters = { '1', '2', '3', '4', '5', '6', '7' };
            char[] amountOfPlayersArray = amountOfPlayers.ToCharArray();

            if (amountOfPlayers.Length == 1 && allowedCharacters.Contains(amountOfPlayersArray[0]))
                return int.Parse(amountOfPlayers);
            return 0;
        }

        /// <summary>
        /// Behandlar spelarens input av mängden skortleckar. Och ber användaren välja antal kortleckar igen om svaret är nej.
        /// </summary>
        /// <returns>Returnerar rerult om inputen är godkänd, 0 om den är inkorrekt.</returns>
        public static int DeckAmountHandler()
        {
            var amountOfDecks = Console.ReadLine();
            Int32.TryParse(amountOfDecks, out int result);
            if (result > 0)
                return result;
            return 0;
        }

        /// <summary>
        /// Behandlar spelarens input av vad hen vill beta. och ber användaren att välja om ett bet om det är inkorrekt angivet eller om saldot är mindre än bettet.
        /// </summary>
        /// <param name="currentPlayer">Spelaren i fråga.</param>
        /// <returns>summan av betet om det är godkänt. och returnerar 0 om det inte är godkänt</returns>
        public static int BetHandler(int currentPlayer)
        {
            var bet = Console.ReadLine();
            Int32.TryParse(bet, out int result);
            if (result > 0 && result <= Player.Players[currentPlayer].PlayerBalance)
                return int.Parse(bet);
            return 0;
        }
    }
}
