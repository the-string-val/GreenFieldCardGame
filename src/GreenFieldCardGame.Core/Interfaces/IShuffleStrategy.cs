

namespace GreenFieldCardGame.Core.Interfaces
{
    /// <summary>
    /// Interface for shuffle strategies used in the card game.
    /// Strategy Design Pattern: Defines the contract for shuffling
    /// </summary>
    public interface IShuffleStrategy
    {
        void Shuffle(IDeck deck);
    }
}
