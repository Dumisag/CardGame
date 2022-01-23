using CardGame.Enums;
using CardGame.Models;
using System;
using System.Collections.Generic;

namespace CardGame
{
    public static class GameLogic
    {
        public static DeckOfCards CreateNewDeckOfCards()
        {
            var deck = new DeckOfCards();
            return deck;
        }

        public static List<Card> CreatePlayerHand()
        {
            PlayerHand userHand = new PlayerHand();
            return userHand.PlayersHand;
        }

        public static List<Card> CreateDealerHand()
        {
            PlayerHand dealerHand = new PlayerHand();
            return dealerHand.PlayersHand;
        }

        public static void Stay(List<Card> player, List<Card> dealer)
        {
            int sumPlayer = EvaluateHandCardSum(player);
            int sumDealer = EvaluateHandCardSum(dealer);

            if (sumPlayer > 21 && sumDealer <= 21)
            {
                Console.WriteLine($"Player lost. Player hand: {sumPlayer}. Dealer: {sumDealer}");
            }
            else if (sumPlayer < sumDealer && sumDealer <= 21)
            {
                Console.WriteLine($"Player lost. Your hand: {sumPlayer}. Dealer: {sumDealer}");

            }
            else if (sumDealer > 21 && sumPlayer <= 21)
            {
                Console.WriteLine($"Player Won. Your hand: {sumPlayer}. Dealer: {sumDealer}");

            }
            else if (sumPlayer > 21)
            {
                Console.WriteLine($"Player lost.Your hand: { sumPlayer}. Dealer: { sumDealer}");

            }
            else
            {
                Console.WriteLine($"Player won Your hand: {sumPlayer}. Dealer: {sumDealer}");
            }
        }

        /// <summary>
        /// Hit's another card
        /// </summary>
        /// <param name="handOfCards">The hand which is dealt a card</param>
        /// <param name="deckOfCards">The para which stores the deck</param>
        public static Card HitCard(List<Card> handOfCards, List<Card> deckOfCards)
        {
            if (handOfCards != null)
            {
                handOfCards.Add(deckOfCards[0]);
                deckOfCards.Remove(deckOfCards[0]);
            }
            return deckOfCards[0];
        }

        /// <summary>
        /// Sums the value of a hand
        /// </summary>
        /// <param name="l">The list which sum will be calculated for (hand)</param>
        /// <returns>Returns the int sum of the cards in a hand</returns>
        public static int EvaluateHandCardSum(List<Card> hand)
        {
            int sum = 0;
            foreach (var item in hand)
            {

                switch (item.CardValue)
                {
                    case CardValue.Two:
                        sum += (int)CardValue.Two;
                        break;
                    case CardValue.Three:
                        sum += ((int)CardValue.Three);
                        break;
                    case CardValue.Four:
                        sum += ((int)CardValue.Four);
                        break;
                    case CardValue.Five:
                        sum += ((int)CardValue.Five);
                        break;
                    case CardValue.Six:
                        sum += ((int)CardValue.Six);
                        break;
                    case CardValue.Seven:
                        sum += ((int)CardValue.Seven);
                        break;
                    case CardValue.Eight:
                        sum += ((int)CardValue.Eight);
                        break;
                    case CardValue.Nine:
                        sum += ((int)CardValue.Nine);
                        break;
                    case CardValue.Ten:                
                    case CardValue.Jack:
                    case CardValue.Queen:
                    case CardValue.King:
                        sum += ((int)CardValue.Ten);
                        break;

                    case CardValue.Ace:
                        if( sum + 11 <= 21)
                        {
                            sum += 11;
                        }
                        else
                        {
                            sum += 1;
                        }
                        break;
                    default:
                        break;
                }

            }
            return sum;
        }
        /// <summary>
        /// Checks if player won
        /// </summary>
        /// <param name="player">The list which stores player's cards</param>
        /// <param name="dealer">The list which stores dealer's cards</param>
        /// <returns></returns>
        public static bool CheckWinner(List<Card> player, List<Card> dealer)
        {
            int sumPlayer = EvaluateHandCardSum(player);
            int sumDealer = EvaluateHandCardSum(dealer);

            bool playerWon = false;
            if (sumPlayer > 21 && sumDealer <= 21)
            {
                playerWon = false;
            }
            else if (sumPlayer < sumDealer && sumDealer <= 21)
            {
                playerWon = false;

            }
            else if (sumDealer > 21 && sumPlayer <= 21)
            {
                playerWon = true;

            }
            else
            {
                playerWon = true;

            }
            return playerWon;
        }
    }
}
