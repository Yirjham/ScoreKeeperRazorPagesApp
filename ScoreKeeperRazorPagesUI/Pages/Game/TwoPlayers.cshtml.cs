using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScoreKeeperRazorPagesUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class TwoPlayersModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public TwoPlayersModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ScoreSubtotalP1 { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ScoreSubtotalP2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Player1Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Player2Name { get; set; }

        [BindProperty]
        public Player Player1 { get; set; }

        [BindProperty]
        public Player Player2 { get; set; }
       
        public IList<Player> Players { get; set; }
        public void OnGet()
        {
            Players = _context.Player.ToList();
            Player1 = Players.Where(x => x.Name == Player1Name).FirstOrDefault();
            Player2 = Players.Where(x => x.Name == Player2Name).FirstOrDefault();

            Player1.ScoreSubtotal = ScoreSubtotalP1;
            Player2.ScoreSubtotal = ScoreSubtotalP2;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            Player1.UpdateRoundSubtotal();
            Player2.UpdateRoundSubtotal();

            return RedirectToPage("/Game/TwoPlayers", new {ScoreSubtotalP1 = Player1.ScoreSubtotal, ScoreSubtotalP2 = Player2.ScoreSubtotal, Player1Name = Player1.Name, Player2Name = Player2.Name });
        }

        public IActionResult OnPostWinner()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            Player1.UpdateFinalScore();
            Player2.UpdateFinalScore();

            int p1TotalScoreTemp = Player1.TotalScore;
            int p2TotalScoreTemp = Player2.TotalScore;

            Player1 =_context.Player.Where(p => p.Name == Player1.Name).FirstOrDefault();
            Player2 =_context.Player.Where(p => p.Name == Player2.Name).FirstOrDefault();

            Player1.TotalScore = p1TotalScoreTemp;
            Player2.TotalScore = p2TotalScoreTemp;

            Player1.GamesPlayed++;
            Player2.GamesPlayed++;

            if (Player1.TotalScore > Player2.TotalScore)
            {
                Player1.GamesWon++;
            }
            else if (Player1.TotalScore < Player2.TotalScore)
            {
                Player2.GamesWon++;
            }

            if (Player1.HighestGameScore < Player1.TotalScore)
            {
                Player1.HighestGameScore = Player1.TotalScore;
            }

            if (Player2.HighestGameScore < Player2.TotalScore)
            {
                Player2.HighestGameScore = Player2.TotalScore;
            }

            _context.SaveChanges();
            return RedirectToPage("/Game/Scoreboard");
        }
    }
}
