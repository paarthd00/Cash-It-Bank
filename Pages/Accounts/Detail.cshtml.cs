using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
        [Authorize(Roles = "Admin")]
        public class DetailModel : PageModel
        {

                [BindProperty]
                public int accountNum
                {
                        get; set;
                }
                private readonly WebApplication1.Data.ApplicationDbContext _context;

                public DetailModel(WebApplication1.Data.ApplicationDbContext context)
                {
                        _context = context;
                }

                public ClientAccountVM ClientAccountVM { get; set; } = default!;
                public async Task OnGetAsync()
                {
                        string value = HttpContext.Request.Query["accountnum"];
                        if (string.IsNullOrEmpty(value))
                        {
                                return;
                        }
                        accountNum = int.Parse(value);
                        ClientAccountRepo clientAccountRepo = new ClientAccountRepo(_context);
                        ClientAccountVM = await clientAccountRepo.accountDetails(accountNum);
                }

                public async Task<IActionResult> OnPostAsync()
                {
                        return Page();
                }


        }
}