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
    internal class MultiAccounts
    {
        private static List<Account> _accountDb = new List<Account>();
        public bool StoreAccount(Account bankAccount)
        {
            _accountDb.Add(bankAccount);
            return true;
        }

        public Account FindAccount(string accountName)
        {
            for (int i = 0; i < _accountDb.Count; ++i)
            {
                if (_accountDb.ElementAt(i).GetName() == accountName)
                {
                    return _accountDb.ElementAt(i);
                }
                
            }
            return null;
        }

        public static int GetDbSize()
        {
            return _accountDb.Count;
        }

        public static Account GetAccountAtIndex(int position)
        {
            if (position < _accountDb.Count)
            {
                return _accountDb.ElementAt(position);
            }

            return null;
        }
    }
}