#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab4_Schmid_Galecki.Data;
using lab4_Schmid_Galecki.Models;

namespace lab4_Schmid_Galecki.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly lab4_Schmid_Galecki.Data.lab4_Schmid_GaleckiContext _context;

        public IndexModel(lab4_Schmid_Galecki.Data.lab4_Schmid_GaleckiContext context)
        {
            _context = context;
        }

        public string TitleSort { get; set; }
        public string DateSort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public IList<Game> Game { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //Game = await _context.Game.ToListAsync();
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";
            CurrentFilter = searchString;

            IQueryable<Game> GameIQ = from g in _context.Game
                                       select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                GameIQ = GameIQ.Where(g => g.Title.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "title_desc":
                    GameIQ = GameIQ.OrderByDescending(g => g.Title);
                    break;
                case "Date":
                    GameIQ = GameIQ.OrderBy(g => g.RelaseDate);
                    break;
                case "date_desc":
                    GameIQ = GameIQ.OrderByDescending(g => g.RelaseDate);
                    break;
                case "Price":
                    GameIQ = GameIQ.OrderBy(g => g.Price);
                    break;
                case "price_desc":
                    GameIQ = GameIQ.OrderByDescending(g => g.Price);
                    break;
                default:
                    GameIQ = GameIQ.OrderBy(s => s.Title);
                    break;
            }
            Game = await GameIQ.AsNoTracking().ToListAsync();

        }
    }
}
