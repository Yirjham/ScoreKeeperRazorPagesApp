using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScoreKeeperRazorPagesUI.Data;
using ScoreKeeperRazorPagesUI.Models;

namespace ScoreKeeperRazorPagesUI.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public DetailsModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

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
            return Page();
        }
    }
}
