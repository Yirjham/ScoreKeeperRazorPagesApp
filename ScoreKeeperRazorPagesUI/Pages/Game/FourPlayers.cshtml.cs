using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<Player> Players { get; set; }


        public void OnGet()
        {
            Players = _context.Player.ToList();
            Player1 = Players[0];
            Player2 = Players[1];
            Player3 = Players[2];
            Player4 = Players[3];
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


            return RedirectToPage("/Game/FourPlayers", new { ScoreSubtotalP1 = Player1.ScoreSubtotal, ScoreSubtotalP2 = Player2.ScoreSubtotal, ScoreSubtotalP3 = Player3.ScoreSubtotal, ScoreSubtotalP4 = Player4.ScoreSubtotal });
        }
    }
}
