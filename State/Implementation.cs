using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace State
{

    public abstract class BankAccountState
    {
        public BankAccount BankAccount { get; protected set; } = null!;

        public decimal Balance { get; protected set; }
        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }

    public class RegularState : BankAccountState
    {

        public RegularState(BankAccount bankAccount, decimal balance)
        {
            BankAccount = bankAccount;
            Balance = balance;
        }
        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount}");
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from balance {Balance}");
            Balance -= amount;
            if (Balance < 0)
            {
                BankAccount.bankAccountState = new OverdrawnState(BankAccount, Balance);
            }
        }
    }

    public class GoldState : BankAccountState
    {

        public GoldState(decimal balance ,BankAccount bankAccount)
        {
            Balance = balance;
            BankAccount = bankAccount;
        }
        public override void Deposit(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, depositing {amount} +10% bonus: {amount /10}");
            Balance += amount + (amount / 10);
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, withdrawing {amount} from {Balance}");
            Balance -= amount;
            if(Balance < 1000 && Balance >= 0)
            {
                BankAccount.bankAccountState = new RegularState(BankAccount,Balance);
            }else if(Balance < 0){
                BankAccount.bankAccountState = new OverdrawnState(BankAccount, Balance);

            }
        }
    }

    public class OverdrawnState : BankAccountState
    {

        public OverdrawnState(BankAccount bankAccount, decimal balance)
        {
            BankAccount = bankAccount;
            Balance = balance;
        }
        public override void Deposit(decimal amount)
        {
            Balance += amount;

            if (Balance >= 0)
            {
                BankAccount.bankAccountState = new RegularState(BankAccount, Balance);
            }
            Console.WriteLine($"In {GetType()}, depositing {amount}");
        }

        public override void Withdraw(decimal amount)
        {
            Console.WriteLine($"In {GetType()}, cannot {amount} from balance {Balance}");
        }
    }
    public class BankAccount
    {
        public BankAccountState bankAccountState { get; set; }

        public decimal Balance { get { return bankAccountState.Balance; } }

        public BankAccount()
        {
            bankAccountState = new RegularState(this,0);
        }

        public void Deposit(decimal amount)
        {
            bankAccountState.Deposit(amount);
        }

        public void Withdraw(decimal amount)
        {
            bankAccountState.Withdraw(amount);
        }
    }
}
