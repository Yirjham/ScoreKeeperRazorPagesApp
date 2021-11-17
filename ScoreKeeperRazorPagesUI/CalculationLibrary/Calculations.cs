﻿using ScoreKeeperRazorPagesUI.Models;
using System;

namespace ScoreKeeperRazorPagesUI.CalculationLibrary
{
    public class Calculations
    {
        /// <summary>
        /// Determines the round highest scorer, it has 3 overloads: 2, 3 and 4 players
        /// </summary>
        /// <param name="player1">First Player</param>
        /// <param name="player2">Second Player</param>
        /// <returns>Returns a Player instance</returns>
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

        /// <summary>
        /// Determines the game winner, it has 3 overloads: 2, 3 and 4 players
        /// </summary>
        /// <param name="player1">First Player</param>
        /// <param name="player2">Second Player</param>
        /// <returns></returns>
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
        /// <summary>
        /// Takes in as many players' scores as needed and compares the top two scores
        /// </summary>
        /// <param name="playersScores">Scores go into an array that gets sorted</param>
        /// <returns>True if there is a winner or false if the top score is shared by at least two players</returns>
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

       
    }
}
