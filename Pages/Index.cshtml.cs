using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string filterValue { get; set; }

        public string userName { get; set; }
        private readonly WebApplication1.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ClientAccountVM> ClientAccountVM { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // userName = 
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Accounts/Index", new { selectedValue = filterValue });
        }

    }
}
