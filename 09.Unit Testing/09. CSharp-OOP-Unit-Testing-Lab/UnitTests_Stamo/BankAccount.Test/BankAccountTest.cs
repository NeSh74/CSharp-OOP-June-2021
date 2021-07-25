using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BankAccount.Test
{
    [TestFixture]

    public class BankAccountTest
    {
        private UnitTests.BankAccount account;

        [SetUp]

        public void InitializeBankAccount()
        {
            account = new UnitTests.BankAccount(1000);
        }

        [Test]

        public void InitializeBankAccountWithAmount()
        {
            Assert.That(account.Amount, Is.EqualTo(1000));
        }

        [Test]

        public void DepositPositiveAmount()
        {
            account.Deposit(200);
            Assert.That(account.Amount, Is.EqualTo(1200));
        }

        [Test]
        public void DepositNegativeAmount()
        {
            Assert.That(() => account.Deposit(-65), Throws.InvalidOperationException.With.Message
                .EqualTo("Deposit amount must be more than 0"));
        }
    }
}
