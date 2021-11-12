using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreKeeperRazorPagesUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class SelectGameModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public SelectGameModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

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

        }
        public IActionResult OnPostTwoPlayers()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Game/TwoPlayers", new {Player1Name = Player1.Name, Player2Name = Player2.Name} );

        }

        public IActionResult OnPostThreePlayers()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Game/ThreePlayers", new { Player1Name = Player1.Name, Player2Name = Player2.Name, Player3Name = Player3.Name });
        }

        public IActionResult OnPostFourPlayers()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Game/FourPlayers", new { Player1Name = Player1.Name, Player2Name = Player2.Name, Player3Name = Player3.Name, Player4Name = Player4.Name });
        }
    }
}
