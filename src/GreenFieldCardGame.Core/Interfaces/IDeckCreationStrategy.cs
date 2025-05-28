
using GreenFieldCardGame.Core.Entities;

namespace GreenFieldCardGame.Core.Interfaces
{
    public interface IDeckCreationStrategy
    {
        IEnumerable<Card> CreateDeckCards();
    }
}
