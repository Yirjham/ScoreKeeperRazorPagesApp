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

        [BindProperty]
        public Player Player { get; set; }

        public IList<Player> Players { get; set; }

        public void OnGet()
        {
            Players = _context.Player.ToList();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Game/ThreePlayers", new { Player1Name = Player1.Name, Player2Name = Player2.Name, Player3Name = Player3.Name });
        }

        public async Task<IActionResult> OnPostStayInPageAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Game/SelectThreePlayers");
        }
    }
}
