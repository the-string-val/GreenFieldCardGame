using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Enums;
using GreenFieldCardGame.Core.Interfaces;

namespace GreenFieldCardGame.Tests.Core
{
    public class DeckTests
    {
        // Now testing the concrete Deck class implementing IDeck

        [Fact]
        public void Deck_Constructor_Should_Create_Deck_With_Provided_Cards()
        {
            // Arrange
            var initialCards = new List<Card>
            {
                new Card(CardRank.Ace, Suit.Spades),
                new Card(CardRank.Two, Suit.Hearts)
            };

            // Act
            IDeck deck = new Deck(initialCards); // Instantiating concrete Deck, referencing as IDeck

            // Assert
            Assert.NotNull(deck);
            Assert.Equal(2, deck.Count); // Using property
            Assert.Contains(initialCards[0], deck.Cards);
            Assert.Contains(initialCards[1], deck.Cards);
        }

        [Fact]
        public void Deck_AddCard_Should_Increase_Count()
        {
            // Arrange
            IDeck deck = new Deck(new List<Card>()); // Start with an empty deck
            var newCard = new Card(CardRank.Jack, Suit.Diamonds);
            var initialCount = deck.Count;

            // Act
            deck.AddCard(newCard);

            // Assert
            Assert.Equal(initialCount + 1, deck.Count);
            Assert.Contains(newCard, deck.Cards);
        }

        [Fact]
        public void Deck_RemoveCard_Should_Decrease_Count_When_Card_Exists()
        {
            // Arrange
            var cardToRemove = new Card(CardRank.Queen, Suit.Clubs);
            var initialCards = new List<Card> { cardToRemove, new Card(CardRank.King, Suit.Clubs) };
            IDeck deck = new Deck(initialCards);
            var initialCount = deck.Count;

            // Act
            bool removed = deck.RemoveCard(cardToRemove);

            // Assert
            Assert.True(removed);
            Assert.Equal(initialCount - 1, deck.Count);
            Assert.DoesNotContain(cardToRemove, deck.Cards);
        }

        [Fact]
        public void Deck_RemoveCard_Should_Return_False_When_Card_Does_Not_Exist()
        {
            // Arrange
            IDeck deck = new Deck(new List<Card> { new Card(CardRank.King, Suit.Clubs) });
            var nonExistentCard = new Card(CardRank.Ace, Suit.Spades);
            var initialCount = deck.Count;

            // Act
            bool removed = deck.RemoveCard(nonExistentCard);

            // Assert
            Assert.False(removed);
            Assert.Equal(initialCount, deck.Count);
        }

    }
}
