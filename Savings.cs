namespace ConsoleApp1
{
    class SavingsAccount : Account
    {
        public override void GenAccountNumber()
        {
            var randomGen = new Random();
            const string alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 1; i < AccountNumberLength; i++)
            {
                _accountNumber += alphaNumeric.ElementAt(randomGen.Next(alphaNumeric.Length));
            }

            _accountNumber += "S";
            CheckForDupeAccountNumber();
        }
        
        public SavingsAccount(string inName, string inAddress, decimal inBalance, AccountState inAccountStatus)
        {
            MinBalance = 100;
            MinServiceFee = 0;
            SetName(inName);
            SetAddress(inAddress);
            SetBalance(inBalance);
            SetAccountState(inAccountStatus);
            SetServiceFee(MinServiceFee);
            GenAccountNumber();
            SetAccountType(AccountType.Cd);
        }
    }
}

