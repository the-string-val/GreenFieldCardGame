
using GreenFieldCardGame.Core.Entities;

namespace GreenFieldCardGame.Core.Interfaces
{
    public interface IDeck
    {
        /// <summary>
        /// Read-only access to the cards in the deck
        /// </summary>
        IReadOnlyList<Card> Cards { get; }

        /// <summary>
        /// Property for count instead of method
        /// </summary>
        int Count { get; } 

        /// <summary>
        /// Add Card to Deck
        /// </summary>
        /// <param name="card"></param>
        void AddCard(Card card);

        /// <summary>
        /// Remove card from deck
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        bool RemoveCard(Card card);

    }
}
