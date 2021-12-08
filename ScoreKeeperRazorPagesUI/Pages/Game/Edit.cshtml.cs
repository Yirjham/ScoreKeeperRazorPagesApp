using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScoreKeeperRazorPagesUI.Data;
using ScoreKeeperRazorPagesUI.Models;

namespace ScoreKeeperRazorPagesUI.Pages.Game
{
    public class EditModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public EditModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }


        //public int HighestScore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Player.FirstOrDefaultAsync(m => m.ID == id);

            if (Player == null)
            {
                return NotFound();
            }

            Response.Cookies.Append("Player.HighestGameScore", Player.HighestGameScore.ToString());
            Response.Cookies.Append("Player.GamesWon", Player.GamesWon.ToString());
            Response.Cookies.Append("Player.GamesPlayed", Player.GamesPlayed.ToString());

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Player.HighestGameScore = Convert.ToInt32(Request.Cookies["Player.HighestGameScore"]); 
            Player.GamesWon = Convert.ToInt32(Request.Cookies["Player.GamesWon"]); 
            Player.GamesPlayed = Convert.ToInt32(Request.Cookies["Player.GamesPlayed"]); 

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Scoreboard");
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.ID == id);
        }
    }
}
