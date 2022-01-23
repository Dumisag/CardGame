using System;

namespace CardGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("*********************");
			Console.WriteLine("Welcome to the card game");


			while (true)
			{
				Console.WriteLine("0 - Exit");
				Console.WriteLine("1 - Play");

				var answer = Console.ReadLine();

				switch (answer)
				{
					case "0":
						return;
					case "1":
						var  deckOfCards = GameLogic.CreateNewDeckOfCards();
						var dealerCards = GameLogic.CreateDealerHand();
						var playerCards = GameLogic.CreatePlayerHand();
						GameLogic.HitCard(dealerCards, deckOfCards.GetGameDeckOfCards());
						GameLogic.HitCard(dealerCards, deckOfCards.GetGameDeckOfCards());
						GameLogic.HitCard(playerCards, deckOfCards.GetGameDeckOfCards());
						GameLogic.HitCard(playerCards, deckOfCards.GetGameDeckOfCards());
						int dealerHandSum = GameLogic.EvaluateHandCardSum(dealerCards);
						int playerHandSum = GameLogic.EvaluateHandCardSum(playerCards);
						Console.WriteLine("Your cards are:");
						foreach (var card in playerCards)
						{
							Console.Write($"{card.ToString()}. ");
						}
						Console.WriteLine($"Your total is: {playerHandSum}");
						Console.WriteLine($"Dealer's first card: {dealerCards[0].ToString()}");

						if (dealerHandSum == 21 && playerHandSum != 21)
						{
							Console.WriteLine($"Sorry, dealer won, got {dealerHandSum}. Dealer's hand:");
							foreach (var card in dealerCards)
							{
								Console.Write($"{card}. ");
							}
							Console.WriteLine($"You, on the other hand, got {playerHandSum}:");
							foreach (var card in playerCards)
							{
								Console.Write($"{card}. ");
							}
							break;
						}
						if (playerHandSum < 21 && dealerHandSum < 21)
						{
							while (answer != "0")
							{
								Console.WriteLine($"Hit or stay? h/s");
								string ans = Console.ReadLine().ToLower();
								switch (ans)
								{
									case "h":
										GameLogic.HitCard(playerCards, deckOfCards.GetGameDeckOfCards());
										GameLogic.HitCard(dealerCards, deckOfCards.GetGameDeckOfCards());

										Console.WriteLine($"Your card: {playerCards[playerCards.Count - 1 ]}, sum: {GameLogic.EvaluateHandCardSum(playerCards)}");
										Console.WriteLine($"Dealer's card: {dealerCards[dealerHandSum -1 ]}");
										if (GameLogic.EvaluateHandCardSum(dealerCards) == 21 && GameLogic.EvaluateHandCardSum(playerCards) != 21)
										{
											Console.WriteLine($"Sorry, dealer won, got {GameLogic.EvaluateHandCardSum(dealerCards)}. Dealer's hand:");
											foreach (var card in dealerCards)
											{
												Console.Write($"{card}. ");
											}
											Console.WriteLine($"You, on the other hand, got {GameLogic.EvaluateHandCardSum(playerCards)}:");
											foreach (var card in playerCards)
											{
												Console.Write($"{card}. ");
											}
											answer = "0";
											break;

										}
										else if (GameLogic.EvaluateHandCardSum(dealerCards) < 21 && GameLogic.EvaluateHandCardSum(playerCards) > 21)
										{
											Console.WriteLine($"Sorry, dealer won, got {GameLogic.EvaluateHandCardSum(dealerCards)}. Dealer's hand:");
											foreach (var card in dealerCards)
											{
												Console.Write($"{card}. ");
											}
											Console.WriteLine($"You, on the other hand, got {GameLogic.EvaluateHandCardSum(playerCards)}:");
											foreach (var card in playerCards)
											{
												Console.Write($"{card}. ");
											}
											answer = "0";
											break;
										}
										else if (GameLogic.EvaluateHandCardSum(dealerCards) > 21 && GameLogic.EvaluateHandCardSum(playerCards) < 21)
										{
											Console.WriteLine($"Dealer Bust. You: {GameLogic.EvaluateHandCardSum(playerCards)}, Dealer: {GameLogic.EvaluateHandCardSum(dealerCards)}");
											answer = "0";
											break;

										}
										else if (GameLogic.EvaluateHandCardSum(dealerCards) < 21 && GameLogic.EvaluateHandCardSum(playerCards) > 21)
										{
											Console.WriteLine($"Sorry, dealer won, got {GameLogic.EvaluateHandCardSum(dealerCards)}. Dealer's hand:");
											foreach (var card in dealerCards)
											{
												Console.Write($"{card}. ");
											}
											Console.WriteLine($"You, on the other hand, got {GameLogic.EvaluateHandCardSum(playerCards)}:");
											foreach (var card in playerCards)
											{
												Console.Write($"{card}. ");
											}
											answer = "0";
											break;
										}
										else if (GameLogic.EvaluateHandCardSum(dealerCards) > 21 && GameLogic.EvaluateHandCardSum(playerCards) > 21)
										{
											Console.WriteLine($"Sorry, you are both losers!! Dealer: {GameLogic.EvaluateHandCardSum(dealerCards)}. Dealer's hand:");
											foreach (var card in dealerCards)
											{
												Console.Write($"{card}. ");
											}
											Console.WriteLine($"You: {GameLogic.EvaluateHandCardSum(playerCards)}:");
											foreach (var card in playerCards)
											{
												Console.Write($"{card}. ");
											}
											answer = "0";
											break;
										}

										break;
									case "s":
										GameLogic.Stay(playerCards, dealerCards);
										if (GameLogic.CheckWinner(playerCards, dealerCards))
										{
											answer = "0";
											break;
										}
										else
										{
											answer = "0";
											break;
										}
									default:
										break;
								}
							}

						}
						else if (GameLogic.EvaluateHandCardSum(dealerCards) == 21 && GameLogic.EvaluateHandCardSum(playerCards) != 21)
						{
							Console.WriteLine($"Sorry, dealer won, got {GameLogic.EvaluateHandCardSum(dealerCards)}. Dealer's hand:");
							foreach (var card in dealerCards)
							{
								Console.Write($"{card}. ");
							}
							Console.WriteLine($"You, on the other hand, got {GameLogic.EvaluateHandCardSum(playerCards)}:");
							foreach (var card in playerCards)
							{
								Console.Write($"{card}. ");
							}
							break;
						}
						{

						}
						break;
					default:
						Console.WriteLine("Sorry, not a valid option!");
						break;
				}

			}
		}
    }
}
