namespace Blackjack
{
    internal static class Program
    {
        private static void Main()
        {
            Blackjack.StartRound();
        }
    }
}
// TODO
// Fixa snyggare och lättläsligare output
// Lägg till olika bord med olika bet limits och bet minumums (instanser av Blackjack)
// Lägg till split och double down.
// Varje spelare får beta och varsitt kort först och sedan får man dra resten?
// Spara data så att inte varje runda är samma. (finns ingen mening och ha betting och antal spelare egentligen om man inte lagrar det)