using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreKeeperRazorPagesUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class SelectThreePlayersModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public SelectThreePlayersModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player1 { get; set; }

        [BindProperty]
        public Player Player2 { get; set; }

        [BindProperty]
        public Player Player3 { get; set; }

        public IList<Player> Players { get; set; }

        public void OnGet()
        {
            Players = _context.Player.ToList();
        }

        public IActionResult OnPost()
        {
            if (Player1 != null && (Player1.Name == Player2.Name || Player1.Name == Player3.Name || Player2.Name == Player3.Name))
            {
                ModelState.AddModelError("Player1.Name", "You need to select different players to proceed");
                Players = _context.Player.ToList();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Game/ThreePlayers", new { Player1Name = Player1.Name, Player2Name = Player2.Name, Player3Name = Player3.Name });
        }
    }
}
