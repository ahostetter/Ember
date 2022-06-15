namespace Ember
{
    internal class Deck
    {
        public int deckSize;
        public string[] cards;

        public Deck(int aDeckSize, string[] aCards)
        {
            deckSize = aDeckSize;
            cards = aCards;
        }
    }
}
