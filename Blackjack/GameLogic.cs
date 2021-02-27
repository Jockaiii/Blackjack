namespace Blackjack
{
    using System.Collections.Generic;
    public static class GameLogic
    {
        /// <summary>
        /// PlayerChecker() ser till att spelaren är eligiable att fortsätta dra kort.
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// indexering i listan Players för att hålla koll på vilken spelares tur det är.
        /// <returns>returnerar true om spelaren inte får fortsätta.</returns>
        public static bool PlayerChecker(int currentPlayer)
        {
            Player.Players[currentPlayer].PlayerSum = CardCounter(Player.Players[currentPlayer].PlayerHand);
            if (Player.Players[currentPlayer].PlayerSum > 21) // Bust
            {
                Output.OutputBust();
                return true;
            }
            else if (Player.Players[currentPlayer].PlayerSum == 21 && Player.Players[currentPlayer].PlayerHand.Count == 2) // Blackjack
            {
                Output.OutputBlackjack();
                return true;
            }
            else if (Player.Players[currentPlayer].PlayerSum == 21) // Får inte fortstätta om man redan nått 21
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// HouseChecker() ser till att huset är eligable att fortsätta dra kort.
        /// </summary>
        /// <returns>returnerar true om huset inte får fortsätta.</returns>
        public static bool HouseChecker()
        {
            House.HouseSum = CardCounter(House.HouseHand);
            if (House.HouseSum > 21) // Bust 
            {
                Output.OutputBust();
                return true;
            }
            else if (House.HouseSum > 16) // Huset stannar alltid när summan överstiger 16
            {
                return true;
            }
            else if (House.HouseSum == 21 && House.HouseHand.Count == 2) // Blackjack
            {
                Output.OutputBlackjack();
                return true;
            }
            else if (House.HouseSum == 21)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Räknar summan av korten i en "hand".
        /// </summary>
        /// <param name="Hand"></param>
        /// Tar emot en spelare eller husets hand,
        /// <returns>returnerar summan av handen.</returns>
        public static int CardCounter(List<Card> Hand) // (the legal kind?)
        {
            var sum = 0;

            foreach (var card in Hand)
            {
                if (int.TryParse(card.CardNumber, out int result))
                {
                    sum += result;
                }
                else
                {
                    if (card.CardNumber != "A") //  Knekt, Dam, Kung = 10.
                    {
                        card.CardNumber = "10";
                    }
                    else if (card.CardNumber == "A")
                    {
                        if (sum + 11 <= 21) // Om ess + tidigare kort är mindre än 21 så räknas det om 11. Annars som 1.
                            card.CardNumber = "11";
                        else
                            card.CardNumber = "1";
                    }
                    sum += int.Parse(card.CardNumber);

                    if (sum > 21)
                    {
                        var temp = sum; // Sparar summan så att den kan skrivas ut om det inte går att få ner totalen under 21
                        foreach (var card2 in Hand)
                        {
                            if (card.CardNumber == "A")
                            {
                                card.CardNumber = "1";
                                sum -= 10; // Om ett ess hittades och gjordes om till 1 så är summan nu 10 mindre.
                                if (sum < 21)
                                {
                                    CardCounter(Hand); // Om summan är under 21. Tillkalla metoden igen och börja om med ess eller essen med värdet av 1.
                                }
                            }
                        }
                    }
                }
            }
            Output.OutputTotal(sum);
            return sum;
        }

        /// <summary>
        /// bedömmer win, draw eller loss conditions och delar ut kredits därefter.
        /// </summary>
        public static void GameResults()
        {
            foreach (var player in Player.Players)
            {
                bool winner;
                if (House.HouseSum > 21 && player.PlayerSum <= 21) // Huset har gått bust men inte spelaren => spelaren vinner.
                {
                    winner = true;
                    player.PlayerBalance += player.PlayerBet;
                    Output.OutputWin(winner, player.PlayerName);
                }
                else if (player.PlayerSum > 21 && House.HouseSum <= 21) // Spelaren har gått bust men inte huset => spelaren förlorar.
                {
                    winner = false;
                    player.PlayerBalance -= player.PlayerBet;
                    Output.OutputWin(winner, player.PlayerName);
                }
                else if (player.PlayerSum > 21 && House.HouseSum > 21) // Både spelaren och huset har gått bust och rundan avgörs då som lika.
                {
                    Output.OutputDraw(player.PlayerName);
                }
                else if (player.PlayerSum == 21 && player.PlayerHand.Count == 2 && House.HouseSum != 21 && House.HouseHand.Count != 2) // Spelaren har fått blackjack och har vunnit om inte huset också har fått blackjack.
                {
                    winner = true;
                    player.PlayerBalance += player.PlayerBet;
                    Output.OutputWin(winner, player.PlayerName);
                }
                else if (House.HouseSum == 21 && House.HouseHand.Count == 2 && player.PlayerSum != 21 && player.PlayerHand.Count != 2) // Huset har fått blackjack och har vunnit om inte spelarn också har fått blackjack.
                {
                    winner = false;
                    player.PlayerBalance -= player.PlayerBet;
                    Output.OutputWin(winner, player.PlayerName);
                }
                else if (player.PlayerSum == 21 && player.PlayerHand.Count == 2 && House.HouseSum == 21 && House.HouseHand.Count == 2) // Både spelaren och huset har fått en blackjack och rundan avgörs därmed lika.
                {
                    Output.OutputDraw(player.PlayerName);
                }
                else if (player.PlayerSum > House.HouseSum && player.PlayerSum <= 21) // Spelaren har fått högre poäng än huset. (Men har inte gått över 21) och vinner därmed rundan.
                {
                    winner = true;
                    player.PlayerBalance += player.PlayerBet;
                    Output.OutputWin(winner, player.PlayerName);
                }
                else if (House.HouseSum > player.PlayerSum && House.HouseSum <= 21) // Huset har fått högre poäng än spelaren (men har inte gått över 21) och vinner därmed rundan.
                {
                    winner = false;
                    player.PlayerBalance -= player.PlayerBet;
                    Output.OutputWin(winner, player.PlayerName);
                }
                else if (player.PlayerSum == House.HouseSum) // Både huset och spelaren har fått samma poäng (och ingen har fått en blackjack) och rundan avgörs därmed lika.
                {
                    Output.OutputDraw(player.PlayerName);
                }
                else
                {
                    Output.OutputSomethingGoneWrong();
                }
            }
        }
    }
}