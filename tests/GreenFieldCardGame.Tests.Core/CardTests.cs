using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Enums;
using Xunit;

namespace GreenFieldCardGame.Tests.Core
{
    public class CardTests
    {
        [Fact]
        public void Card_Should_Create_With_Correct_Rank_And_Suit()
        {
            // Arrange
            var card = new Card(CardRank.Ace, Suit.Spades);

            // Assert
            Assert.Equal(CardRank.Ace, card.Rank);
            Assert.Equal(Suit.Spades, card.Suit);
        }
    }
}