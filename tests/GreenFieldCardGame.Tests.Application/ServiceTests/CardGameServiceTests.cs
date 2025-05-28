
using GreenFieldCardGame.Application.Services;
using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Enums;
using GreenFieldCardGame.Core.Interfaces;
using Moq;


namespace GreenFieldCardGame.Tests.Application.ServiceTests
{

    public class CardGameServiceTests
    {
        private Mock<IShuffleStrategy> _mockShuffleStrategy;
        private Mock<IDeckCreationStrategy> _mockDeckCreationStrategy;
        private Mock<IGameRules> _mockGameRules;
        private CardGameService _service;

        public CardGameServiceTests()
        {
            _mockShuffleStrategy = new Mock<IShuffleStrategy>();
            _mockDeckCreationStrategy = new Mock<IDeckCreationStrategy>();
            _mockGameRules = new Mock<IGameRules>();

             
            _mockDeckCreationStrategy.Setup(s => s.CreateDeckCards())
                                     .Returns(new List<Card> { new(CardRank.Ace, Suit.Spades) });

            _mockGameRules.Setup(r => r.NumberOfPlayers).Returns(2);

            _service = new CardGameService(
                _mockShuffleStrategy.Object,
                _mockDeckCreationStrategy.Object,
                _mockGameRules.Object,
                numberOfHumanPlayers: 1
            );
        }

        [Fact]
        public void Constructor_Should_Create_Deck_Using_DeckCreationStrategy()
        {
            // Arrange & Act
            _mockDeckCreationStrategy.Verify(s => s.CreateDeckCards(), Times.Once);

            // Asset
            Assert.NotNull(_service.GetDeck());
        }

        [Fact]
        public void StartNewGame_Should_Shuffle_Deck_And_Call_SetupGame_On_GameRules()
        {
            // Arrange
            _service.StartNewGame();

            // Act & Assert
            _mockShuffleStrategy.Verify(s => s.Shuffle(_service.GetDeck()), Times.Once);
            _mockGameRules.Verify(r => r.SetupGame(_service.GetDeck(), _service.GetPlayers().ToList()), Times.Once);
        }

        [Fact]
        public void PlayTurn_Should_Call_ProcessTurn_On_GameRules()
        {
            // Arrange
            _mockGameRules.Setup(r => r.IsGameOver(It.IsAny<List<Player>>())).Returns(false);
            _mockGameRules.Setup(r => r.ProcessTurn(
                It.IsAny<IDeck>(),
                It.IsAny<List<Player>>(),
                It.IsAny<Player>())).Returns(true);

            // Act
            var testPlayer = _service.GetPlayers().First();

            _service.PlayTurn(testPlayer);

            // Assert
            _mockGameRules.Verify(r => r.ProcessTurn(_service.GetDeck(), _service.GetPlayers().ToList(), testPlayer), Times.Once);
        }

        [Fact]
        public void PlayTurn_Should_Return_False_When_GameRules_Indicates_Game_Over()
        {
            // Arrange
            _mockGameRules.Setup(r => r.IsGameOver(It.IsAny<List<Player>>())).Returns(false);
            _mockGameRules.Setup(r => r.ProcessTurn(
                It.IsAny<IDeck>(),
                It.IsAny<List<Player>>(),
                It.IsAny<Player>())).Returns(false);

            // Act
            var testPlayer = _service.GetPlayers().First();

            bool gameContinues = _service.PlayTurn(testPlayer);

            // Assert
            Assert.False(gameContinues);
        }

        [Fact]
        public void GetCurrentGameState_Should_Delegate_To_GameRules()
        {
            //  Arrange
            var expectedState = new { Round = 5, CurrentPlayer = "Player1" };
            _mockGameRules.Setup(r => r.GetGameState()).Returns(expectedState);

            // Act
            var actualState = _service.GetCurrentGameState();

            // Assert
            Assert.Equal(expectedState, actualState);
            _mockGameRules.Verify(r => r.GetGameState(), Times.Once);
        }

    }
}
