
using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Enums;

namespace GreenFieldCardGame.Tests.Core
{
    public class PlayerTests
    {
        [Fact]
        public void Player_Should_Be_Created_With_Correct_Name()
        {
            // Arrange
            string playerName = "Alice";

            // Act
            var player = new Player(playerName);

            // Assert
            Assert.Equal(playerName, player.Name);
            Assert.NotNull(player.Hand);
            Assert.Empty(player.Hand);
            Assert.Equal(0, player.Score);
        }

        [Fact]
        public void AddCardToHand_Should_Add_Card_To_Hand()
        {
            // Arrange
            var player = new Player("Bob");
            var card = new Card(CardRank.Ace, Suit.Spades);

            // Act
            player.AddCardToHand(card);

            // Assert
            Assert.Single(player.Hand);
            Assert.Contains(card, player.Hand);
        }

        [Fact]
        public void ClearHand_Should_Remove_All_Cards_From_Hand()
        {
            // Arrange
            var player = new Player("Charlie");
            player.AddCardToHand(new Card(CardRank.Two, Suit.Clubs));
            player.AddCardToHand(new Card(CardRank.King, Suit.Diamonds));

            // Act
            player.ClearHand();

            // Assert
            Assert.Empty(player.Hand);
        }

        [Fact]
        public void Score_Property_Should_Be_Settable()
        {
            // Arrange
            var player = new Player("David");
            int initialScore = player.Score;

            // Act
            player.Score = 100;

            // Assert
            Assert.NotEqual(initialScore, player.Score);
            Assert.Equal(100, player.Score);
        }
    }
}
