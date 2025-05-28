

using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Enums;
using GreenFieldCardGame.Core.Interfaces;

namespace GreenFieldCardGame.Application.Factories
{
    /// <summary>
    /// StandardDeckCreationStrategy is a concrete implementation of IDeckCreationStrategy
    /// Added StandarddeckCreationStrategy, In Future can implement different Strategies  
    /// </summary>
    public class StandardDeckCreationStrategy : IDeckCreationStrategy
    {
        public List<Card> CreateDeckCards()
        {
            var cards = new List<Card>();
            foreach (Suit suit in System.Enum.GetValues(typeof(Suit)))
            {
                foreach (CardRank rank in System.Enum.GetValues(typeof(CardRank)))
                {
                    cards.Add(new Card(rank, suit));
                }
            }
            return cards;
        }
    }
}
