using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreKeeperRazorPagesUI.Models;

namespace ScoreKeeperRazorPagesUI.Data
{
    public class ScoreKeeperRazorPagesUIContext : DbContext
    {
        public ScoreKeeperRazorPagesUIContext (DbContextOptions<ScoreKeeperRazorPagesUIContext> options)
            : base(options)
        {
        }

        public DbSet<ScoreKeeperRazorPagesUI.Models.Player> Player { get; set; }
    }
}
