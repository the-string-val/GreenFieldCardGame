
using GreenFieldCardGame.Application.Factories;
using GreenFieldCardGame.Application.Services;
using GreenFieldCardGame.Core.Interfaces;
using GreenFieldCardGame.Games.GameRule;
using GreenFieldCardGame.Infrastructure.ShuffleStrategies;



namespace GreenFieldCardGame.Application.Factories
{
    public class GameFactory
    {
        /// <summary>
        /// Creates a CardGameService based on the specified game type and number of human players.
        /// </summary>
        /// <param name="gameType"></param>
        /// <param name="numberOfHumanPlayers"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static CardGameService CreateGameService(string gameType, int numberOfHumanPlayers = 1)
        {
            IShuffleStrategy shuffleStrategy = new RandomShuffleStrategy();
            IDeckCreationStrategy deckCreationStrategy;
            IGameRules gameRules;

            switch (gameType.ToLowerInvariant())
            {
                case "standardwar":
                    deckCreationStrategy = new StandardDeckCreationStrategy();
                    gameRules = new SimpleWarRule(); 
                    break;
               
                default:
                    throw new ArgumentException($"Unknown game type: {gameType}");
            }

            return new CardGameService(shuffleStrategy, deckCreationStrategy, gameRules, numberOfHumanPlayers);
        }
    }
}
