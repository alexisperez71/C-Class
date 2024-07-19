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
            CheckForDupeAccountNumber();
        }
        

        public CdAccount(string inName, string inAddress, decimal inBalance, AccountState inAccountStatus)
        {
            MinBalance = 500;
            MinServiceFee = 8;
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
