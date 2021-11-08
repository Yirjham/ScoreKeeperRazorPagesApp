using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Models
{
    public class PlayerStats
    {
        public int ID { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int HighestGameScore { get; set; }
        public int PlayerID { get; set; }
        public Player Player { get; set; }
    }
}
