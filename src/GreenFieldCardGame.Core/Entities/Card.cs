using GreenFieldCardGame.Core.Enums;

namespace GreenFieldCardGame.Core.Entities
{
    public class Card
    {
        public CardRank Rank { get; }
        public Suit Suit { get; }

        public Card(CardRank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}
