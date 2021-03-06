using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blackjack.Tests
{
    [TestClass()]
    public class GameLogicTests
    {
        public GameLogicTests() // Sätter IsTesting till true så att inte input förväntas av användaren. Och därmed kan testerna köras.
        {
            Blackjack.IsTesting = true;
        }

        [TestMethod()]
        public void PlayerCheckerTest()
        {
            Blackjack.StartRound();
            Assert.IsTrue(GameLogic.PlayerChecker(0)); // PlayerSum i unit testing kommer alltid bli 21 eller bust så om playercheck fungerar så ska den returnera true
                                                       // (eftersom spelaren aldrig kan välja att stoppa under testerna.)
            Player.Players[0].PlayerHand.Clear(); // ser till att PlayerSum är under 21 så PlayerChecker bör returnera false
            Assert.IsFalse(GameLogic.PlayerChecker(0)); // Räknar om korten i handen (vilka nu är inga) och returnerar false om spelaren får fortsätta dra kort
        }

        [TestMethod()]
        public void HouseCheckerTest()
        {
            Blackjack.StartRound();
            Assert.IsTrue(GameLogic.HouseChecker()); // HouseChecker följer samma logik som PlayerChecker bara att den stannar automatisk när Summan gör över 16: Men returnerar alltid true i testet om den fungerar.

            House.HouseHand.Clear(); // HouseChecker Bör returnera false om summan är under 16 (vilket den blir om jag tar bort alla korten i handen).
            Assert.IsFalse(GameLogic.HouseChecker());
        }

        [TestMethod()]
        public void CardCounterTest() // Testar så att alla korten räknas som de skall. och eventuella undantag (ess).
        {
            Blackjack.StartRound();
            House.HouseHand.Clear();

            House.HouseHand.Add(new Card ("Hearts", "2")); // sum =2 (kollar så att 2-9 räknas som sitt värde)
            House.HouseHand.Add(new Card ("Hearts", "J")); // sum = 12 (kollar så att knäkt, dam och kung räknas som 10)
            House.HouseHand.Add(new Card ("Hearts", "A")); // sum = 13 (eftersom ess ska räknas som 1 om summan går över 21 annars räknas det som 11) = 13
            Assert.AreEqual(GameLogic.CardCounter(House.HouseHand), 13);

            House.HouseHand.Clear();
            House.HouseHand.Add(new Card("Hearts", "A")); // Kollar så att ess vanligtvis räknas som 11
            Assert.AreEqual(GameLogic.CardCounter(House.HouseHand), 11);
        }

        [TestMethod()]
        public void GameResultsTest() // Testar alla win, draw och lose scenarios med fokus på House. Eftersom scenariosen är identiska för spelare också.
        {
            Blackjack.StartRound();

            Player.Players[0].PlayerHand.Clear(); // Tar bort alla korten i händerna. (så att blackjack går att garanteras i testet)
            Player.Players[1].PlayerHand.Clear();
            House.HouseHand.Clear();

            Player.Players[0].PlayerSum = 25; // Bust
            Player.Players[1].PlayerSum = 22; // Bust
            House.HouseSum = 2; // sum = 2
            GameLogic.GameResults();
            Assert.IsFalse(GameLogic.Winner); // Huset borde vinna

            Player.Players[0].PlayerSum = 25; // Bust
            Player.Players[1].PlayerSum = 26; // Bust
            House.HouseSum = 27; // Bust
            GameLogic.GameResults();
            Assert.IsTrue(GameLogic.Draw); // Draw borde bli true

            House.HouseHand.Add(new Card("Hearts", "A"));
            House.HouseHand.Add(new Card("Hearts", "K")); // housesum = 21 (blackjack)
            Player.Players[0].PlayerSum = 21; // sum = 21 (utan blackjack)
            House.HouseSum = GameLogic.CardCounter(House.HouseHand);
            GameLogic.GameResults();
            Assert.IsFalse(GameLogic.Winner); // Huset borde vinna

            Player.Players[0].PlayerSum = 19; // sum = 19
            House.HouseSum = 20; // sum = 20
            GameLogic.GameResults();
            Assert.IsFalse(GameLogic.Winner); // Huset borde vinna

            Player.Players[0].PlayerSum = 16; // sum = 16
            Player.Players[1].PlayerSum = 16; // sum = 16
            House.HouseSum = 16; // sum = 16
            GameLogic.GameResults();
            Assert.IsTrue(GameLogic.Draw); // Borde bli en draw
        }
    }
}