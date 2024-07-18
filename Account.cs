// Name: Alexis Perez
// CS3260 Section X02
// Project: Lab_02
// Date: 09/02/2018 12:44:44 PM
// Purpose: Creating a bank program
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// -----------------------------------------------------------------------



namespace ConsoleApp1
{
    abstract class Account : IAccount
    {
        public enum AccountState
        {
            New,
            Active,
            UnderAudit,
            Frozen,
            Closed
        }

        public enum AccountType
        {
            Null,
            Checking,
            Savings,
            Cd
        }

        private string _name;
        private string _address;
        protected string _accountNumber;
        private decimal _balance;
        private AccountState _state;
        protected int MinBalance;
        protected int _serviceFee = 0;
        protected int MinServiceFee = 0;
        protected const int AccountNumberLength = 8;
        private AccountType _accountType = AccountType.Null; 

        public string GetName()
        {
            return _name;
        }

        public bool SetName(string inName)
        {
            if (string.IsNullOrEmpty(inName) || int.TryParse(inName, out _))
            {
                return false;
            }

            _name = inName;
            return true;
        }

        public string GetAddress()
        {
            return _address;
        }

        public bool SetAddress(string inAddress)
        {
            if (string.IsNullOrEmpty(inAddress))
            {
                return false;
            }

            _address = inAddress;
            return true;
        }

        public void PayInFunds(decimal amount)
        {
            _balance += amount;
        }

        public bool WithdrawFunds(decimal amount)
        {
            if ((_balance - amount) < 0 || amount < 0)
            {
                return false;
            }

            _balance -= amount;
            return true;

        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public bool SetBalance(decimal inBalance)
        {
            if (inBalance < MinBalance)
            {
                return false;
            }

            _balance += inBalance;
            return true;
        }

        public virtual void GenAccountNumber()
        {
            Random randomGen = new Random();
            const string alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 0; i < AccountNumberLength; i++)
            {
                _accountNumber += randomGen.Next(alphaNumeric.Length);
            }
        }
        public string GetAccountNumber()
        {
            return _accountNumber;
        }

        public AccountState GetAccountState()
        {
            return _state;
        }

        public void SetAccountState(AccountState inState)
        {
            _state = inState;
        }

        public bool SetServiceFee(int inServiceFee)
        {
            if (inServiceFee >= MinServiceFee)
            {
                _serviceFee = inServiceFee;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetServiceFee()
        {
            return _serviceFee;
        }

        public bool SetAccountType(AccountType accountType)
        {
            _accountType = accountType;
            return true;
        }

        public AccountType GetAccountType()
        {
            return _accountType;
        }

    }
}

