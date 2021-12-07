using ScoreKeeperRazorPagesUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScoreKeeperRazorPagesUI.CalculationLibrary
{
    public class Calculations
    {
        public static Player DeterminesRoundHighestScorer(Player player1, Player player2)
        {
            Player roundWinner = null;

            roundWinner = ReturnsHighestScorer(player1, player2, player1.RoundScore, player2.RoundScore);

            return roundWinner;

        }
        public static Player DeterminesRoundHighestScorer(Player player1, Player player2, Player player3)
        {
            Player tempWinner = DeterminesRoundHighestScorer(player1, player2);
            Player winner = DeterminesRoundHighestScorer(tempWinner, player3);
            return winner;
        }
        public static Player DeterminesRoundHighestScorer(Player player1, Player player2, Player player3, Player player4)
        {
            Player tempWinner = DeterminesRoundHighestScorer(player1, player2, player3);
            Player winner = DeterminesRoundHighestScorer(tempWinner, player4);
            return winner;
        }

        public static Player DeterminesWinner(Player player1, Player player2)
        {

            Player gameWinner = null;
            player1.UpdateRoundSubtotal();
            player2.UpdateRoundSubtotal();

            gameWinner = ReturnsHighestScorer(player1, player2, player1.ScoreSubtotal, player2.ScoreSubtotal);
            return gameWinner;

        }

        public static Player DeterminesWinner(Player player1, Player player2, Player player3)
        {
            Player gameWinner = DeterminesWinner(player1, player2);
            gameWinner = DeterminesWinner(gameWinner, player3);
            return gameWinner;
        }

        public static Player DeterminesWinner(Player player1, Player player2, Player player3, Player player4)
        {
            Player tempWinner = DeterminesWinner(player1, player2, player3);
            Player winner = DeterminesWinner(tempWinner, player4);
            return winner;
        }

        private static Player ReturnsHighestScorer(Player player1, Player player2, int scorePlayer1, int scorePlayer2)
        {
            Player winner = null;
            if (scorePlayer1 > scorePlayer2)
            {
                winner = player1;
            }
            else
            {
                winner = player2;
            }
            return winner;
        }

        public static bool IsThereAWinner(params int[] playersScores)
        {
            Array.Sort(playersScores);
            int maxScore = playersScores[playersScores.Length - 1];
            int secondHighestScore = playersScores[playersScores.Length - 2];

            if (maxScore != secondHighestScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Player DeterminesGameWinner(params Player[] players)
        {
            Player output = null;
            players = players.OrderByDescending(p => p.TotalScore).ToArray();

            if (players[0].TotalScore != players[1].TotalScore)
            {
                output = players[0];
            }
            return output;
        }
    }
}
