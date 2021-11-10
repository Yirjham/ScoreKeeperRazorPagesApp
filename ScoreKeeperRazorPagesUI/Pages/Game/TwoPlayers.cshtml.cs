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
        public Player Player1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public Player Player2 { get; set; }
        public IList<Player> Players { get; set; }
        public void OnGet()
        {


            Players = _context.Player.ToList();
            Player1 = Players[0];
            Player2 = Players[1];

            if (Player1.ScoreSubtotal == null)
            {
                Player1.ScoreSubtotal = 0;
            }

            if (Player2.ScoreSubtotal == null)
            {
                Player2.ScoreSubtotal = 0;
            }

            //Player player1 = Players[0];
            //Player player2 = Players[1];

            //Player1 = player1;
            //Player2 = player2;
        }

        //public IActionResult OnPost()
        //{
        //    if (ModelState.IsValid == false)
        //    {
        //        return Page();
        //    }

        //    Player1.ScoreSubtotal = Player1.ScoreSubtotal + Player1.RoundScore;
        //    Player2.ScoreSubtotal = Player2.ScoreSubtotal + Player2.RoundScore;


        //}
    }
}
