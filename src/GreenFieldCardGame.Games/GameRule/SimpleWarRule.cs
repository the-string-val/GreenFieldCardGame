

using GreenFieldCardGame.Core.Entities;
using GreenFieldCardGame.Core.Interfaces;

namespace GreenFieldCardGame.Games.GameRule
{
    /// <summary>
    /// SimpleWarRule is a concrete implementation of IGameRules
    /// Not Implemented yet, but serves as a placeholder for the rules of a simple war game.
    /// </summary>
    public class SimpleWarRule : IGameRules
    {
        public string GameName => throw new NotImplementedException();

        public int NumberOfPlayers => throw new NotImplementedException();

        public IEnumerable<Player> DetermineWinner(List<Player> players)
        {
            throw new NotImplementedException();
        }

        public object GetGameState()
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver(List<Player> players)
        {
            throw new NotImplementedException();
        }

        public bool ProcessTurn(IDeck deck, List<Player> players, Player currentPlayer)
        {
            throw new NotImplementedException();
        }

        public void SetupGame(IDeck deck, List<Player> players)
        {
            throw new NotImplementedException();
        }
    }
}
