using CardGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Models
{
    public class DeckOfCards
    {
        private List<Card> gameDeckOfCards;

        public List<Card> GetGameDeckOfCards()
        {
            if (gameDeckOfCards == null )
            {
                GenerateNewDeckOfCards();
            }
            return gameDeckOfCards;
        }

        private void SetGameDeckOfCards(List<Card> value)
        {
            gameDeckOfCards = value;
        }

        public DeckOfCards()
        {
            GenerateNewDeckOfCards();
        }

        private void GenerateNewDeckOfCards()
        {
            var gameCards = new List<Card>();
            foreach (CardSuit cardSuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue cardValue in Enum.GetValues(typeof(CardValue)))
                {
                    gameCards.Add(new Card()
                    {
                        CardValue = cardValue,
                        CardSuit = cardSuit
                    });
                }

            }
            Shuffle(gameCards);
        }

        private void Shuffle(List<Card> cards)
        {
            var random = new Random();
            SetGameDeckOfCards(cards.OrderBy(x => random.Next()).ToList());
        }
    }
}
