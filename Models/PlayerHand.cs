using System.Collections.Generic;

namespace CardGame.Models
{
    public class PlayerHand
    {

        public List<Card> PlayersHand { get; set; }

        public int HandSum { get; set; }

        public PlayerHand()
        {
            PlayersHand = new List<Card>();
            HandSum = 0;
        }
    }
}
