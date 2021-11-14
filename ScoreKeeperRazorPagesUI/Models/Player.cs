﻿using System;
using System.Collections.Generic;
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
        public Player(string name)
        {
            Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public int RoundScore { get; set; } = 0;
        [NotMapped]
        public int ScoreSubtotal { get; set; } = 0;
        [NotMapped]
        public int TotalScore { get; private set; }
        [InverseProperty("Category")]
        public ICollection<PlayerStats> PlayerStats { get; set; }

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
