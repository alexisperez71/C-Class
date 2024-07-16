namespace ConsoleApp1;

class CheckingAccount : Account
{

	public override void GenAccountNumber()
	{
		Random randomGen = new Random();
		const string alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		for (int i = 1; i < accountNumberLength; i++)
		{
			_accountNumber += alphaNumeric.ElementAt(randomGen.Next(alphaNumeric.Length));
		}

		_accountNumber += "C";
		
	}

	public CheckingAccount(string inName, string inAddress, decimal inBalance, AccountState inAccountStatus)
	{
		SetName(inName);
		SetAddress(inAddress);
		SetBalance(inBalance);
		SetAccountState(inAccountStatus);
		_serviceFee = 5;
		MinBalance = 10;
		MinServiceFee = 5;
		GenAccountNumber();
	}
}