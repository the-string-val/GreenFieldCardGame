

namespace GreenFieldCardGame.Core.Entities
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> Hand { get; private set; } = new List<Card>();

        /// <summary>
        /// May be need to change it to support different scoring systems in the future.
        /// </summary>
        public int Score { get; set; } 

        public Player(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Adds a card to the player's hand
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }
    }
}
