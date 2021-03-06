namespace Blackjack
{
    using System.Collections.Generic;
    public class Player
    {
        public static List<Player> Players { get; set; } = new List<Player>(); // Innehåller alla spelare. och deras properties.
        public List<Card> PlayerHand { get; set; } = new List<Card>(); // Är spelarens hand. Innehåller korten som dras till spelaren.
        public string PlayerName { get; set; } = "Anonym"; // namnet på spelaren.
        public int PlayerBalance { get; set; } = 100; // Spelarens kredit på kontot att använda för betting.
        public int PlayerSum { get; set; } = 0; // är totala värdet av korten i spelarens hand.
        public int PlayerBet { get; set; } = 0; // Vad spelaren väljer att beta inför rundan.
        internal Player(int playerIndex) // sätter ett index som namn för varje spelare.
        {
            PlayerName = "player" + playerIndex;
        }
    }
}