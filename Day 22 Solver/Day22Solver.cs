using System.Collections.Generic;
using System.Linq;

namespace Day_22_Solver
{
    public static class Day22Solver
    {
        public static int Part1Solution(string[] lines)
        {
            int toReturn = 0;
            (var playerOneHand, var playerTwoHand) = ParseInput(lines);

            var queueToCalculate = Combat(playerOneHand, playerTwoHand);
            var amount = queueToCalculate.Count;

            while (amount > 0)
            {
                toReturn += (queueToCalculate.Dequeue() * amount);
                amount--;
            }

            return toReturn;
        }

        public static int Part2Solution(string[] lines)
        {
            int toReturn = 0;
            (var playerOneHand, var playerTwoHand) = ParseInput(lines);

            RecursiveCombat(playerOneHand, playerTwoHand);
            var queueToCalculate = playerOneHand.Count > 0 ? playerOneHand : playerTwoHand;
            var amount = queueToCalculate.Count;

            while (amount > 0)
            {
                toReturn += queueToCalculate.Dequeue() * amount;
                amount--;
            }

            return toReturn;
        }

        private static (Queue<int>, Queue<int>) ParseInput(string[] lines)
        {
            var playerOneHand = new Queue<int>();
            var playerTwoHand = new Queue<int>();

            bool playerOne = true;
            for (var i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    playerOne = false;
                    i++;
                    continue;
                }

                if (playerOne)
                {
                    playerOneHand.Enqueue(int.Parse(lines[i]));
                }
                else
                {
                    playerTwoHand.Enqueue(int.Parse(lines[i]));
                }
            }

            return (playerOneHand, playerTwoHand);
        }

        private static Queue<int> Combat(Queue<int> playerOneHand, Queue<int> playerTwoHand)
        {
            while (playerOneHand.Count > 0 && playerTwoHand.Count > 0)
            {
                var playerOneCard = playerOneHand.Dequeue();
                var playerTwoCard = playerTwoHand.Dequeue();

                if (playerOneCard > playerTwoCard)
                {
                    playerOneHand.Enqueue(playerOneCard);
                    playerOneHand.Enqueue(playerTwoCard);
                }
                else
                {
                    playerTwoHand.Enqueue(playerTwoCard);
                    playerTwoHand.Enqueue(playerOneCard);
                }
            }

            var queueToCalculate = playerOneHand.Count > 0 ? playerOneHand : playerTwoHand;
            return queueToCalculate;
        }

        private static GameEnd RecursiveCombat(Queue<int> playerOneHand, Queue<int> playerTwoHand, int game = 1)
        {
            var playerOneSnapshot = new List<Queue<int>>();
            var playerTwoSnapshot = new List<Queue<int>>();

            var round = 1;

            //System.Console.WriteLine($"=== Game {game} ===");
            //System.Console.WriteLine();

            while (playerOneHand.Count > 0 && playerTwoHand.Count > 0)
            {
                if (playerOneSnapshot.Any(x => x.SequenceEqual(playerOneHand)) && playerTwoSnapshot.Any(x => x.SequenceEqual(playerTwoHand)))
                {
                    // System.Console.WriteLine("Contains snapshot");
                    return GameEnd.WinPlayerOne;
                }

                playerOneSnapshot.Add(playerOneHand.Clone());
                playerTwoSnapshot.Add(playerTwoHand.Clone());

                //System.Console.WriteLine($"-- Round {round} (Game {game}) --");
                //System.Console.WriteLine($"Player 1's deck: {playerOneHand.Print()}");
                //System.Console.WriteLine($"Player 2's deck: {playerTwoHand.Print()}");

                var playerOneCard = playerOneHand.Dequeue();
                var playerTwoCard = playerTwoHand.Dequeue();
                //System.Console.WriteLine($"Player 1 plays: {playerOneCard}");
                //System.Console.WriteLine($"Player 2 plays: {playerTwoCard}");

                if (playerOneCard > playerOneHand.Count || playerTwoCard > playerTwoHand.Count)
                {
                    if (playerOneCard > playerTwoCard)
                    {
                        //System.Console.WriteLine($"Player 1 wins round {round} of game {game}!");
                        playerOneHand.Enqueue(playerOneCard);
                        playerOneHand.Enqueue(playerTwoCard);
                    }
                    else
                    {
                        //System.Console.WriteLine($"Player 2 wins round {round} of game {game}!");
                        playerTwoHand.Enqueue(playerTwoCard);
                        playerTwoHand.Enqueue(playerOneCard);
                    }
                }
                else
                {
                    //System.Console.WriteLine("Playing a sub-game to determine the winner...");
                    //System.Console.WriteLine();
                    var result = RecursiveCombat(playerOneHand.Clone(playerOneCard), playerTwoHand.Clone(playerTwoCard), game + 1);
                    //System.Console.WriteLine($"...anyway, back to game {game}.");

                    if (result == GameEnd.WinPlayerOne)
                    {
                        //System.Console.WriteLine($"Player 1 wins round {round} of game {game}!");
                        playerOneHand.Enqueue(playerOneCard);
                        playerOneHand.Enqueue(playerTwoCard);
                    }
                    else
                    {
                        //System.Console.WriteLine($"Player 2 wins round {round} of game {game}!");
                        playerTwoHand.Enqueue(playerTwoCard);
                        playerTwoHand.Enqueue(playerOneCard);
                    }
                    //System.Console.WriteLine();
                }

                //System.Console.WriteLine();
                round++;
            }


            return playerOneHand.Count > 0 ? GameEnd.WinPlayerOne : GameEnd.WinPlayerTwo;
        }

        private static Queue<int> Clone(this Queue<int> obj, int number = 99)
        {
            var toReturn = new Queue<int>();
            var queueToList = obj.ToList();
            var amount = 0;
            for (var i = 0; i < queueToList.Count; i++)
            {
                toReturn.Enqueue(queueToList[i]);
                amount++;
                if (amount >= number)
                    break;
            }
            return toReturn;
        }

        private static string Print(this Queue<int> queue)
        {
            var toPrint = string.Empty;
            foreach (var entry in queue)
            {
                toPrint += entry + ", ";
            }
            return toPrint;
        }
    }

    public enum GameEnd
    {
        WinPlayerOne,
        WinPlayerTwo
    }
}
