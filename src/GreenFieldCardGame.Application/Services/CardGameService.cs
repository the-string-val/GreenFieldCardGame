

using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Interfaces;

namespace GreenFieldCardGame.Application.Services
{
    public class CardGameService
    {

        /// <summary>
        /// Represents the deck of cards used in the game.
        /// </summary>
        private readonly IDeck _deck;

        /// <summary>
        /// Strategy for shuffling the deck of cards.
        /// </summary>
        private readonly IShuffleStrategy _shuffleStrategy;

        /// <summary>
        /// Represents the game rules that define how the game is played.
        /// </summary>
        private readonly IGameRules _gameRules;

        /// <summary>
        /// List of players participating in the game.
        /// </summary>
        private readonly List<Player> _players;


        /// <summary>
        /// Constructor for CardGameService.
        /// </summary>
        /// <param name="shuffleStrategy"></param>
        /// <param name="deckCreationStrategy"></param>
        /// <param name="gameRules"></param>
        /// <param name="numberOfHumanPlayers"></param>

        public CardGameService(
            IShuffleStrategy shuffleStrategy,
            IDeckCreationStrategy deckCreationStrategy,
            IGameRules gameRules, 
            int numberOfHumanPlayers = 1) 
        {
            _deck = new Deck(deckCreationStrategy.CreateDeckCards());
            _shuffleStrategy = shuffleStrategy;
            _gameRules = gameRules;

            _players = new List<Player>();
            // Basic player setup - this might also be part of IGameRules.SetupGame
            for (int i = 1; i <= numberOfHumanPlayers; i++)
            {
                _players.Add(new Player($"Player {i}"));
            }
            // Add computer opponent(s) if applicable, based on gameRules.NumberOfPlayers
            for (int i = _players.Count + 1; i <= _gameRules.NumberOfPlayers; i++)
            {
                _players.Add(new Player($"Computer {i - numberOfHumanPlayers}"));
            }
        }

        public IDeck GetDeck()
        {
            return _deck;
        }

        public IReadOnlyList<Player> GetPlayers()
        {
            return _players.AsReadOnly();
        }

        public void ShuffleCurrentDeck()
        {
            _shuffleStrategy.Shuffle(_deck);
        }


        public void StartNewGame()
        {
            // Clear player hands from previous games
            foreach (var player in _players)
            {
                player.ClearHand();
            }

            
            _shuffleStrategy.Shuffle(_deck);

            // Delegate initial game setup to the specific game rules
            _gameRules.SetupGame(_deck, _players);
            Console.WriteLine($"Game '{_gameRules.GameName}' started with {_players.Count} players.");
        }

        public bool PlayTurn(Player currentPlayer)
        {
            if (_gameRules.IsGameOver(_players))
            {
                Console.WriteLine("Game is already over.");
                return false;
            }

            // Delegate turn processing to the specific game rules
            bool gameContinues = _gameRules.ProcessTurn(_deck, _players, currentPlayer);

            if (!gameContinues)
            {
                Console.WriteLine("Game has ended!");
                var winners = _gameRules.DetermineWinner(_players);
                Console.WriteLine("Winner(s): " + string.Join(", ", winners.Select(p => p.Name)));
            }
            return gameContinues;
        }

        public bool IsGameOver()
        {
            return _gameRules.IsGameOver(_players);
        }

        public IEnumerable<Player> GetGameWinners()
        {
            if (!IsGameOver())
            {
                throw new InvalidOperationException("Game is not over yet.");
            }
            return _gameRules.DetermineWinner(_players);
        }

        public object GetCurrentGameState()
        {
            return _gameRules.GetGameState();
        }
    }
}
