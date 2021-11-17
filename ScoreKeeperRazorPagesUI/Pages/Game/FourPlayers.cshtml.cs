using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreKeeperRazorPagesUI.CalculationLibrary;
using ScoreKeeperRazorPagesUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class FourPlayersModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public FourPlayersModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int ScoreSubtotalP1 { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ScoreSubtotalP2 { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ScoreSubtotalP3 { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ScoreSubtotalP4 { get; set; }

        [BindProperty]
        public Player Player1 { get; set; }

        [BindProperty]
        public Player Player2 { get; set; }

        [BindProperty]
        public Player Player3 { get; set; }

        [BindProperty]
        public Player Player4 { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Player1Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Player2Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Player3Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Player4Name { get; set; }

        public IList<Player> Players { get; set; }


        public void OnGet()
        {
            Players = _context.Player.ToList();
            Player1 = Players.Where(x => x.Name == Player1Name).FirstOrDefault();
            Player2 = Players.Where(x => x.Name == Player2Name).FirstOrDefault();
            Player3 = Players.Where(x => x.Name == Player3Name).FirstOrDefault();
            Player4 = Players.Where(x => x.Name == Player4Name).FirstOrDefault();

            Player1.ScoreSubtotal = ScoreSubtotalP1;
            Player2.ScoreSubtotal = ScoreSubtotalP2;
            Player3.ScoreSubtotal = ScoreSubtotalP3;
            Player4.ScoreSubtotal = ScoreSubtotalP4;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            Player1.UpdateRoundSubtotal();
            Player2.UpdateRoundSubtotal();
            Player3.UpdateRoundSubtotal();
            Player4.UpdateRoundSubtotal();


            return RedirectToPage("/Game/FourPlayers", new { ScoreSubtotalP1 = Player1.ScoreSubtotal, ScoreSubtotalP2 = Player2.ScoreSubtotal, ScoreSubtotalP3 = Player3.ScoreSubtotal, ScoreSubtotalP4 = Player4.ScoreSubtotal, Player1Name = Player1.Name, Player2Name = Player2.Name, Player3Name = Player3.Name, Player4Name = Player4.Name });
        }

        public IActionResult OnPostWinner()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            Player1.UpdateFinalScore();
            Player2.UpdateFinalScore();
            Player3.UpdateFinalScore();
            Player4.UpdateFinalScore();

            int p1TotalScoreTemp = Player1.TotalScore;
            int p2TotalScoreTemp = Player2.TotalScore;
            int p3TotalScoreTemp = Player3.TotalScore;
            int p4TotalScoreTemp = Player4.TotalScore;

            Player1 = _context.Player.Where(p => p.Name == Player1.Name).FirstOrDefault();
            Player2 = _context.Player.Where(p => p.Name == Player2.Name).FirstOrDefault();
            Player3 = _context.Player.Where(p => p.Name == Player3.Name).FirstOrDefault();
            Player4 = _context.Player.Where(p => p.Name == Player4.Name).FirstOrDefault();

            Player1.TotalScore = p1TotalScoreTemp;
            Player2.TotalScore = p2TotalScoreTemp;
            Player3.TotalScore = p3TotalScoreTemp;
            Player4.TotalScore = p4TotalScoreTemp;

            Player1.GamesPlayed++;
            Player2.GamesPlayed++;
            Player3.GamesPlayed++;
            Player4.GamesPlayed++;

            Player GameWinner = null;
            if (Calculations.IsThereAWinner(Player1.TotalScore, Player2.TotalScore, Player3.TotalScore, Player4.TotalScore) == true)
            {
                GameWinner = Calculations.DeterminesWinner(Player1, Player2, Player3, Player4);
            }

            if (GameWinner.TotalScore == Player1.TotalScore)
            {
                Player1.GamesWon++;
            }
            else if (GameWinner.TotalScore == Player2.TotalScore)
            {
                Player2.GamesWon++;
            }
            else if (GameWinner.TotalScore == Player3.TotalScore)
            {
                Player3.GamesWon++;
            }
            else
            {
                Player4.GamesWon++;
            }

            if (Player1.HighestGameScore < Player1.TotalScore)
            {
                Player1.HighestGameScore = Player1.TotalScore;
            }

            if (Player2.HighestGameScore < Player2.TotalScore)
            {
                Player2.HighestGameScore = Player2.TotalScore;
            }

            if (Player3.HighestGameScore < Player3.TotalScore)
            {
                Player3.HighestGameScore = Player3.TotalScore;
            }

            if (Player4.HighestGameScore < Player4.TotalScore)
            {
                Player4.HighestGameScore = Player4.TotalScore;
            }

            _context.SaveChanges();
            return RedirectToPage("/Game/Scoreboard");
        }
    }
}
