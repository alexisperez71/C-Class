namespace ConsoleApp1
{
    class CdAccount : Account
    {
        public override void GenAccountNumber()
        {
            Random randomGen = new Random();
            const string alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 1; i < AccountNumberLength; i++)
            {
                _accountNumber += alphaNumeric.ElementAt(randomGen.Next(alphaNumeric.Length));
            }

            _accountNumber += "D";
		
        }

        public CdAccount(string inName, string inAddress, decimal inBalance, AccountState inAccountStatus)
        {
            MinBalance = 500;
            MinServiceFee = 8;
            SetName(inName);
            SetAddress(inAddress);
            SetBalance(inBalance);
            SetAccountState(inAccountStatus);
            GenAccountNumber();
            SetAccountType(AccountType.Cd);
        }
    }
}
