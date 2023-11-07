using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
        public class ProfileModel : PageModel
        {

                [BindProperty]
                public string email
                {
                        get; set;
                }
                private readonly WebApplication1.Data.ApplicationDbContext _context;

                public ProfileModel(WebApplication1.Data.ApplicationDbContext context)
                {
                        _context = context;
                }

                public ClientAccountVM ClientAccountVM { get; set; } = default!;
                public async Task OnGetAsync()
                {
                        string value = HttpContext.Request.Query["mail"];
                        if (string.IsNullOrEmpty(value))
                        {
                                return;
                        }
                        email = value;
                        ClientAccountRepo clientAccountRepo = new ClientAccountRepo(_context);
                        ClientAccountVM = await clientAccountRepo.getDetailsthruEmail(email);
                }

                public async Task<IActionResult> OnPostAsync()
                {
                        return Page();
                }
        }
}