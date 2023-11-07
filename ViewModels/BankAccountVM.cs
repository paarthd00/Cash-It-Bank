namespace WebApplication1.ViewModels
{
    public class BankAccountVM
    {
        private string _AccountType;
        public string AccountType
        {
            get { return _AccountType ?? string.Empty; }
            set { _AccountType = value; }
        }

        private decimal _Balance;
        internal string accountType;

        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
    }
}
