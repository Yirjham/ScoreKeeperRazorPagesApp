﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext _context;

        public IndexModel(ScoreKeeperRazorPagesUI.Data.ScoreKeeperRazorPagesUIContext context)
        {
            _context = context;
        }

        public PlayerStats PlayerStats { get; set; }
        public IList<Player> Players { get;set; }

        public async Task OnGetAsync()
        {
            Players = await _context.Player.Include(p => p.PlayerStats).ToListAsync();
           
        }
    }
}
