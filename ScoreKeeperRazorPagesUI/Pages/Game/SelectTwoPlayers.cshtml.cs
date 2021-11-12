using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreKeeperRazorPagesUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class SelectTwoPlayersModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public SelectTwoPlayersModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player1 { get; set; }

        [BindProperty]
        public Player Player2 { get; set; }

        public IList<Player> Players { get; set; }

        public void OnGet()
        {
            Players = _context.Player.ToList();
        }

        [BindProperty]
        public Player Player { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Game/TwoPlayers", new { Player1Name = Player1.Name, Player2Name = Player2.Name });
        }
    }
    //public class SelectTwoPlayersModel : PageModel
    //{
    //    public void OnGet()
    //    {
    //    }
    //}
}
