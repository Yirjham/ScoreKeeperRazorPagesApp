using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Models
{
    public class PlayerStats
    {
        public int ID { get; set; }
        public int GamesPlayed { get; set; } = 0;
        public int GamesWon { get; set; } = 0;
        public int HighestGameScore { get; set; } = 0;
        public int PlayerID { get; set; }
        public Player Player { get; set; }
    }
}
