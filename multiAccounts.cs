namespace ConsoleApp1
{
    class MultiAccounts
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