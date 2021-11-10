using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        [BindProperty]
        public Player Player1 { get; set; }

        [BindProperty]
        public Player Player2 { get; set; }

        public IList<Player> Players { get; set; }
        public void OnGet()
        {
            Players = _context.Player.ToList();
            Player1 = Players[0];
            Player2 = Players[1];
            Player1.ScoreSubtotal = ScoreSubtotalP1;
            Player2.ScoreSubtotal = ScoreSubtotalP2;

            Player1.UpdateRoundSubtotal();
            Player2.UpdateRoundSubtotal();



            //Player player1 = Players[0];
            //Player player2 = Players[1];

            //Player1 = player1;
            //Player2 = player2;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            Player1.UpdateRoundSubtotal();
            Player2.UpdateRoundSubtotal();

            return RedirectToPage("/Game/TwoPlayers", new {ScoreSubtotalP1 = Player1.ScoreSubtotal, ScoreSubtotalP2 = Player2.ScoreSubtotal});
        }
    }
}
