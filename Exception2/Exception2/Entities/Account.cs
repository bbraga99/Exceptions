using System.Globalization;
using Exception2.Entities.Exceptions;

namespace Exception2.Entities
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account()
        {
        }
        public Account(int accountNumber, string holder, double initialBalance, double withdrawLimit)
        {
            AccountNumber = accountNumber;
            Holder = holder;
            Balance += initialBalance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double  amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if(amount > WithdrawLimit)
            {
                throw new AccountException("The amount is bigger than withdraw limit");
            }
            if(amount > Balance)
            {
                throw new AccountException("Not enought balance");
            }
            Balance -= amount;
        }

        public override string ToString()
        {
            return AccountNumber
                + ", "
                + Holder
                + ", "
                + Balance.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + WithdrawLimit.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
