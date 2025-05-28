

using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Interfaces;

namespace GreenFieldCardGame.Infrastructure.ShuffleStrategies
{
    public class RandomShuffleStrategy: IShuffleStrategy
    {
        private static readonly Random _random = new Random(); // Static for better randomness across instances

        public void Shuffle(Deck deck)
        {
            // Get a mutable copy of the cards from the deck
            var cards = deck.Cards.ToList();

            // Fisher-Yates (Knuth) shuffle algorithm
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(0, i + 1); // Generates a random number between 0 (inclusive) and i+1 (exclusive)
                // Swap elements
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }

            // Update the deck with the shuffled cards
            deck.SetCards(cards);
        }
    }
}
