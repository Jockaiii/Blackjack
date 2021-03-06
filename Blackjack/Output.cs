using System;

namespace Blackjack
{
    public static class Output
    {
        /// <summary>
        /// Frågar användaren efter antal spelare.
        /// </summary>
        public static void OutputAmountOfPlayers()
        {
            Console.WriteLine("How many players? (1-7)");
        }

        /// <summary>
        /// Frågar användaren efter antal kortleckar.
        /// </summary>
        public static void OutputAmountOfDecks()
        {
            Console.WriteLine("How many decks?");
        }

        /// <summary>
        /// Skriver ut det senaste slumpdragna kortet.
        /// </summary>
        /// <param name="card">Kortet som skall skrivas ut. Innehåller Kortnummer och kortsuite.</param>
        /// <param name="name">Vem som drog kortet.</param>
        public static void OutputCard(Card card, string name)
        {
            Console.WriteLine("{0} Received: {1} of {2}", name, card.NumberText, card.CardSuite);
            Console.WriteLine("┌─────┐");
            Console.WriteLine("│{0,-2}   │", card.CardNumber);
            Console.WriteLine("│  {0}  │", card.SuitIcon);
            Console.WriteLine("│    {0,-1}│", card.CardNumber);
            Console.WriteLine("└─────┘");
        }

        /// <summary>
        /// Frågar användaren om hen vill dra ett till kort eller inte.
        /// </summary>
        public static void OutputContinue()
        {
            Console.WriteLine("Do you want another card? (y/n))");
        }

        /// <summary>
        /// Talar om för användaren att hen har gått över 21 och har därmed gått "bust".
        /// </summary>
        public static void OutputBust()
        {
            Console.WriteLine("You've gone bust");
        }

        /// <summary>
        ///  Skriver ut värdet av spelaren (eller husets) hand.
        /// </summary>
        /// <param name="sum">summan av handen.</param>
        public static void OutputTotal(int sum)
        {
        Console.WriteLine("Total: " + sum);
        }

        /// <summary>
        /// Skriver ut att användaren (eller huset) har fått en blackjack.
        /// </summary>
        public static void OutputBlackjack()
        {
            Console.WriteLine("BLACKJACK!!");
        }

        /// <summary>
        /// Skriver att turen avgörs som oavgjort.
        /// </summary>
        public static void OutputDraw(string playerName)
        {
            Console.WriteLine("{0} Draw", playerName);
        }

        /// <summary>
        /// Skriver ut att turen avgjorts som vinst eller förlust för spelaren.
        /// </summary>
        /// <param name="GameLogic.Winner">true om spelaren vann</param>
        /// <param name="playerName">spelaren i fråga</param>
        public static void OutputWin(string playerName)
        {
            if (GameLogic.Winner) // om winner = true vann spelaren annars vann huset.
                Console.WriteLine("{0} WINS!!!!", playerName);
            else
                Console.WriteLine("{0} Loses :(", playerName);
        }

        /// <summary>
        /// Skriver ut att programmet väntar på spelarens input.
        /// </summary>
        public static void OutputWaitForEnter()
        {
            Console.WriteLine("Press Enter to continue");
        }

        /// <summary>
        /// Utifall något gick fel med spellogiken så krashar inte programmet utan säger istället till att något har gått fel. (användes mest när spellogiken testades)
        /// </summary>
        public static void OutputSomethingGoneWrong()
        {
            Console.WriteLine("Something has gone horribly wrong :(");
        }

        /// <summary>
        /// Frågar användaren hur mycket hen vill betta.
        /// </summary>
        /// <param name="playerName">spelarens namn</param>
        public static void OutputBet(string playerName)
        {
            Console.Write("{0} Choose how much you'd like to bet: ", playerName);
        }

        /// <summary>
        /// Om PlayerHelper anser att spelaren borde stanna så skriver denna metoden ut det till spelaren.
        /// </summary>
        public static void HelperStop()
        {
            Console.WriteLine("You should probably stop");
        }

        /// <summary>
        /// Om PlayerHelper anser att spelaren borde dra ett kort till så skriver denna metoden ut det till spelaren.
        /// </summary>
        public static void HelperContinue()
        {
            Console.WriteLine("You should probably draw another card");
        }

        /// <summary>
        /// Skriver ut alla spelares PlayerBalance.
        /// </summary>
        public static void OutputPlayerBalance()
        {
            foreach (var player in Player.Players)
            {
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine("Name \t Balance");
                Console.WriteLine("{0} \t {1}", player.PlayerName, player.PlayerBalance);
            }
        }
    }
}