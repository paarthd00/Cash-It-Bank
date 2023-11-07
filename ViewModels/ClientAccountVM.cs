using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewModels
{
    public class ClientAccountVM
    {
        private int _ClientID;
        public int ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }

        private int _AccountNum;
        public int AccountNum
        {
            get { return _AccountNum; }
            set { _AccountNum = value; }
        }

        public ClientVM? Client { get; internal set; }
        public BankAccountVM? BankAccount { get; internal set; }
        public string? ClientFirstName { get; internal set; }
        public string? ClientLastName { get; internal set; }
        public string? AccountType { get; internal set; }
        public string? ClientEmail { get; internal set; } = null;
        public float? Balance { get; internal set; }
    }
}






