
using GreenFieldCardGame.Core.Interfaces;

namespace GreenFieldCardGame.Core.Entities
{
    public class Deck : IDeck // Implement the new interface
    {
        private List<Card> _cards;

        public IReadOnlyList<Card> Cards => _cards.AsReadOnly();
        public int Count => _cards.Count; // Property for count

        /// <summary>
        /// Creates a deck with a custom set of initial cards.
        /// This is the primary constructor used by deck creation strategies.
        /// </summary>
        /// <param name="initialCards">The collection of cards to start the deck with.</param>
        public Deck(IEnumerable<Card> initialCards)
        {
            _cards = initialCards != null ? new List<Card>(initialCards) : new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public bool RemoveCard(Card card)
        {
            return _cards.Remove(card);
        }

    }
}
