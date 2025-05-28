
using GreenFieldCardGame.Core.Entities;

namespace GreenFieldCardGame.Core.Interfaces
{
    // Strategy Pattern: Interface for specific game rules
    // This interface defines the rules and flow of a card game, Also this interface can be used to implement different game types (e.g., Poker, Blackjack, etc.)
    
    public interface IGameRules
    {
        string GameName { get; } 
        int NumberOfPlayers { get; }

        /// <summary>
        /// Initializes the game setup with a deck and players.
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="players"></param>
        void SetupGame(IDeck deck, List<Player> players);

        /// <summary>
        /// Processes a player's turn in the game.
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="players"></param>
        /// <param name="currentPlayer"></param>
        /// <returns></returns>
        bool ProcessTurn(IDeck deck, List<Player> players, Player currentPlayer);

        /// <summary>
        /// Checks if the game is over based on the current state of players.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        bool IsGameOver(List<Player> players);

        /// <summary>
        /// Determines the winner of the game based on the current state of players.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        IEnumerable<Player> DetermineWinner(List<Player> players);

      
        /// <summary>
        /// Gets the current game state for display purposes.
        /// </summary>
        /// <returns></returns>
        object GetGameState();

    }
}
