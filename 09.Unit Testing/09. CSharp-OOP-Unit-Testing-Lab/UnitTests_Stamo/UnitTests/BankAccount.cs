using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UnitTests
{
    public class BankAccount
    {
        private decimal amount;

        public decimal Amount
        {
            get
            {
                return amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Amount can't be negative");
                }

                amount = value;
            }
        }

        public BankAccount(decimal amount)
        {
            Amount = amount;
        }

        public void Deposit(decimal depositAmount)
        {
            if (depositAmount <= 0)
            {
                throw new InvalidOperationException("Deposit amount must be more than 0");
            }

            Amount += depositAmount;
        }

        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount <= 0)
            {
                throw new InvalidOperationException("Withdraw amount must be more than 0");
            }

            Amount -= withdrawAmount;
        }
    }
}
