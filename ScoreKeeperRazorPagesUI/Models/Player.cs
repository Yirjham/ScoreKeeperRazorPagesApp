using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Models
{
    public class Player
    {
        public Player()
        {

        }
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int GamesPlayed { get; set; } = 0;
        public int GamesWon { get; set; } = 0;
        public int HighestGameScore { get; set; } = 0;

        [NotMapped]
        public int RoundScore { get; set; } = 0;
        [NotMapped]
        public int ScoreSubtotal { get; set; } = 0;
        [NotMapped]
        public int TotalScore { get; set; }

        public void UpdateRoundSubtotal()
        {
            ScoreSubtotal = ScoreSubtotal + RoundScore;
            RoundScore = 0;
        }
        public void UpdateFinalScore()
        {
            UpdateRoundSubtotal();
            TotalScore = ScoreSubtotal;
        }
    }
}
