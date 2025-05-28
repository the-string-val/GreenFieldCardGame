
using GreenFieldCardGame.Core.Entities;

namespace GreenFieldCardGame.Core.Interfaces
{
    public interface IDeckCreationStrategy
    {
        List<Card> CreateDeckCards();
    }
}
