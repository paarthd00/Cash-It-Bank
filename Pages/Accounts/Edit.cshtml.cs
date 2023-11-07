using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
        [Authorize(Roles = "Admin")]
        public class EditModel : PageModel
        {
                [BindProperty]
                public int accountNum
                {
                        get; set;
                }
                [BindProperty]
                public int balance
                {
                        get; set;
                }
                [BindProperty]
                public string firstName
                {
                        get; set;
                }
                [BindProperty]
                public string lastName
                {
                        get; set;
                }

                private readonly WebApplication1.Data.ApplicationDbContext _context;

                public EditModel(WebApplication1.Data.ApplicationDbContext context)
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
                        ClientAccountVM = await clientAccountRepo.accountDetails(int.Parse(value));
                        firstName = ClientAccountVM.ClientFirstName;
                        lastName = ClientAccountVM.ClientLastName;
                        balance = (int)ClientAccountVM.Balance;
                }

                public async Task<IActionResult> OnPostAsync()
                {
                        ClientAccountRepo clientAccountRepo = new ClientAccountRepo(_context);

                        await clientAccountRepo.updateDetails(firstName, lastName, balance, accountNum);

                        return RedirectToPage("./Detail", new { accountnum = accountNum.ToString() });

                }

        }
}