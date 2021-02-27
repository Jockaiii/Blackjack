namespace Blackjack
{
    using System;
    internal static class Program
    {
        private static void Main()
        {
            Blackjack.StartRound();

            foreach (var player in Player.Players)
            {
                Console.WriteLine(player.PlayerName + "\t" + player.PlayerBalance);
            }
        }
    }
}
// TODO
// Lägg till DatorHjälpare
// Fixa Testcases (och allting som tillhör).
// Lägg till olika bord med olika bet limits och bet minumums
// Lägg till split och double down.