using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerStats> PlayerStats { get; set; }
    }
}
