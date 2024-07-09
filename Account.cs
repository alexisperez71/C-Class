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

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;

namespace ConsoleApp1
{
    class Account : IAccount
    {
        public enum AccountState
        {
            New,
            Active,
            UnderAudit,
            Frozen,
            Closed

        }

        private string _name;
        private string _address;
        private int _accountNumber;
        private decimal _balance;
        private AccountState _state;
        private const int MinBalance = 100;

        private int _SomeNum;

        public string GetName()
        {
            return _name;
        }

        public bool SetName(string inName)
        {   
            if (string.IsNullOrEmpty(inName) || int.TryParse(inName, out _SomeNum))
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

        public bool SetAccountNumber(int inAccountNumber)
        {
            if (inAccountNumber < 0)
            {
                return false;
            }
            else
            {
                _accountNumber = inAccountNumber;
                return true;
            }

        }

        public int GetAccountNumber()
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
    }
}    
