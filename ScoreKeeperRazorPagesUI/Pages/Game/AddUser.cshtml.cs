using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ScoreKeeperRazorPagesUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class AddUserModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public AddUserModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }
        public IList<Player> Players { get; set; }
        public void OnGet()
        {
            Players = _context.Player.ToList();
        }

        public async Task<IActionResult> OnPostStayInPageAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Players = _context.Player.ToList();

            if (Players.Contains(Player) == false)
            {
                _context.Player.Add(Player);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Game/AddUser");
        }
    }
}
