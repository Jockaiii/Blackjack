using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass()]
    public class BlackjackTests
    {
        public BlackjackTests() // Sätter IsTesting till true så att inte input förväntas av användaren. Och därmed kan testerna köras.
        {
            Blackjack.IsTesting = true;
        }

        [TestMethod()]
        public void StartRoundTest()
        {
            Blackjack.StartRound();
            Assert.IsTrue(Player.Players.Count > 1); // Kollar ifall mer än 1 spelare skapas
            Assert.IsTrue(Player.Players[0].PlayerHand.Count > 0); // Kollar ifall kort finns i spelarens hand
            Assert.IsTrue(House.HouseHand.Count > 0); // Kollar ifall kort finns i husets hand

            foreach (var card in Deck.CardDeck)
            {
                if (Player.Players[0].PlayerHand.Contains(card)) // Kollar ifall spelarens kort finns kvar i kortlecken.
                    Assert.Fail();
                else if (Player.Players[1].PlayerHand.Contains(card))
                    Assert.Fail();
                else if (House.HouseHand.Contains(card)) // Kollar ifall husets kort finns kvar i kortlecken
                    Assert.Fail();
            }

            if (House.HouseSum < 16) // Kollar så att huset inte stannar innan 16
                Assert.Fail();
        }
    }
}