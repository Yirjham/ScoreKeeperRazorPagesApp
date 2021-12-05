using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScoreKeeperRazorPagesUI.Data;
using System;
using System.Linq;

namespace ScoreKeeperRazorPagesUI.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScoreKeeperRazorPagesUIContext(
                serviceProvider.GetRequiredService<DbContextOptions<ScoreKeeperRazorPagesUIContext>>()))
            {
                if (context.Player.Any())
                {
                    return;
                }

                context.Player.AddRange(
                new Player { Name = "Ray", GamesWon = 3, GamesPlayed = 5, HighestGameScore = 198 },
                new Player { Name = "Jodi", GamesWon = 6, GamesPlayed = 9, HighestGameScore = 210 },
                new Player { Name = "Jessica", GamesWon = 2, GamesPlayed = 6, HighestGameScore = 259 },
                new Player { Name = "Jon", GamesWon = 4, GamesPlayed = 6, HighestGameScore = 198 },
                new Player { Name = "Arthur", GamesWon = 6, GamesPlayed = 7, HighestGameScore = 330 },
                new Player { Name = "Eva", GamesWon = 5, GamesPlayed = 10, HighestGameScore = 248 },
                new Player { Name = "Zoe", GamesWon = 2, GamesPlayed = 6, HighestGameScore = 218 },
                new Player { Name = "Max", GamesWon = 1, GamesPlayed = 2, HighestGameScore = 299 },
                new Player { Name = "Amy", GamesWon = 0, GamesPlayed = 1, HighestGameScore = 204 },
                new Player { Name = "Ian", GamesWon = 1, GamesPlayed = 7, HighestGameScore = 213 }
                    );
                context.SaveChanges();
            }
        }
    }
}
