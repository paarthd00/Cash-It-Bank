using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
        [Authorize(Roles = "Admin")]
        public class AccountsModel : PageModel
        {

                [BindProperty]
                public string selectedValue
                {
                        get; set;
                }
                private readonly WebApplication1.Data.ApplicationDbContext _context;

                public AccountsModel(WebApplication1.Data.ApplicationDbContext context)
                {
                        _context = context;
                }

                public IList<ClientAccountVM> ClientAccountVM { get; set; } = default!;
                public async Task OnGetAsync()
                {
                        string paramValue = HttpContext.Request.Query["selectedValue"].ToString();
                        Console.WriteLine(paramValue);
                        if (!string.IsNullOrEmpty(paramValue))
                        {
                                selectedValue = paramValue;
                        }
                        await LoadClientAccounts();
                }

                public async Task<IActionResult> OnPostAsync()
                {
                        await LoadClientAccounts();
                        return Page();
                }

                private async Task LoadClientAccounts()
                {
                        ClientAccountRepo clientAccountRepo = new ClientAccountRepo(_context);
                        if (string.IsNullOrEmpty(selectedValue) || selectedValue == "All")
                        {
                                Console.WriteLine(selectedValue);
                                ClientAccountVM = await clientAccountRepo.All();
                        }
                        else
                        {
                                ClientAccountVM = await clientAccountRepo.filterUser(selectedValue);
                        }
                }
        }
}