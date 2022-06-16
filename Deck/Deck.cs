namespace Ember
{
    internal class Deck
    {
        public int deckSize;
        public List<string> cards;

        public Deck(int aDeckSize, List<string> aCards)
        {
            deckSize = aDeckSize;
            cards = aCards;
        }
    }
}
