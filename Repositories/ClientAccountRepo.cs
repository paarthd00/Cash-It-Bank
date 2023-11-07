using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;
using WebApplication1.ViewModels;
using static WebApplication1.Data.ApplicationDbContext;

namespace WebApplication1.Repositories
{
    public class ClientAccountRepo
    {
        ApplicationDbContext _context;

        public ClientAccountRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Get all users in the database.
        public async Task<List<ClientAccountVM>> All()
        {
            var clients = await _context.ClientsAccount.Select(u => new ClientAccountVM()
            {
                ClientFirstName = (u.Client != null && u.Client.firstName != null) ? u.Client.firstName : "",
                ClientLastName = (u.Client != null && u.Client.lastName != null) ? u.Client.lastName : "",
                AccountNum = u.accountNum,
                AccountType = (u.BankAccount != null && u.BankAccount.accountType != null) ? u.BankAccount.accountType : ""
            }).ToListAsync();

            return clients;
        }

        public async Task<List<ClientAccountVM>> filterUser(string filter)
        {
            var clients = await _context.ClientsAccount.Select(u => new ClientAccountVM()
            {
                ClientFirstName = (u.Client != null && u.Client.firstName != null) ? u.Client.firstName : "",
                ClientLastName = (u.Client != null && u.Client.lastName != null) ? u.Client.lastName : "",
                AccountNum = u.accountNum,
                AccountType = (u.BankAccount != null && u.BankAccount.accountType != null) ? u.BankAccount.accountType : ""
            }).Where(u => u.AccountType == filter).ToListAsync();

            return clients;
        }


        public async Task<ClientAccountVM> accountDetails(int accountNum)
        {
            var client = await _context.ClientsAccount.Select(u => new ClientAccountVM()
            {
                ClientEmail = (u.Client != null && u.Client.email != null) ? u.Client.email : "",
                ClientID = u.clientID,
                Balance = (u.BankAccount != null && u.BankAccount.balance != null) ? u.BankAccount.balance : 0,
                ClientFirstName = (u.Client != null && u.Client.firstName != null) ? u.Client.firstName : "",
                ClientLastName = (u.Client != null && u.Client.lastName != null) ? u.Client.lastName : "",
                AccountNum = u.accountNum,
                AccountType = (u.BankAccount != null && u.BankAccount.accountType != null) ? u.BankAccount.accountType : ""
            }).Where(u => u.AccountNum == accountNum).FirstOrDefaultAsync();

            return client;
        }

        public async Task<ClientAccountVM> getDetailsthruEmail(string email)
        {

            var client = await _context.ClientsAccount.Select(u => new ClientAccountVM()
            {
                ClientEmail = (u.Client != null && u.Client.email != null) ? u.Client.email : "",
                ClientID = u.clientID,
                Balance = (u.BankAccount != null && u.BankAccount.balance != null) ? u.BankAccount.balance : 0,
                ClientFirstName = (u.Client != null && u.Client.firstName != null) ? u.Client.firstName : "",
                ClientLastName = (u.Client != null && u.Client.lastName != null) ? u.Client.lastName : "",
                AccountNum = u.accountNum,
                AccountType = (u.BankAccount != null && u.BankAccount.accountType != null) ? u.BankAccount.accountType : ""
            }).Where(u => u.ClientEmail == email).FirstOrDefaultAsync();

            return client;
        }



        public async Task updateDetails(string firstName, string lastName, int balance, int accountNum)
        {
            var client = await _context.ClientsAccount.Where(u => u.accountNum == accountNum).FirstOrDefaultAsync();
            if (client == null)
            {
                throw new Exception($"Client with account number {accountNum} not found.");
            }

            var clientID = client.clientID;
            var clientDetails = await _context.Clients.Where(u => u.clientID == clientID).FirstOrDefaultAsync();
            if (clientDetails == null)
            {
                throw new Exception($"Client details for client with ID {clientID} not found.");
            }

            var bankAccount = await _context.BankAccounts.Where(u => u.accountNum == accountNum).FirstOrDefaultAsync();
            if (bankAccount == null)
            {
                throw new Exception($"Bank account with account number {accountNum} not found.");
            }

            if (firstName != null)
            {
                clientDetails.firstName = firstName;
            }

            if (lastName != null)
            {
                clientDetails.lastName = lastName;
            }

            bankAccount.balance = balance;
            await _context.SaveChangesAsync();
        }

    }
}
