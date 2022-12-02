using System;

using State;

Console.Title = "State";

BankAccount bankAccount = new BankAccount();
bankAccount.Deposit(1001);
bankAccount.Withdraw(101);
bankAccount.Withdraw(100);

