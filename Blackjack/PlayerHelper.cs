namespace Blackjack
{
    internal static class PlayerHelper
    {
        /// <summary>
        /// Skriver ut tips till spelaren
        /// </summary>
        /// <param name="currentPlayer">index för vilken spelaren vars tur det är</param>
        internal static void Helper(int currentPlayer)
        {
            if (Player.Players[currentPlayer].PlayerSum > 16)
                Output.HelperStop();
            else if (Player.Players[currentPlayer].PlayerSum <= 16)
                Output.HelperContinue();
        }
    }
}