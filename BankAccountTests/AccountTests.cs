using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new("J Doe");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        [DataRow(9999.99)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            acc.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, acc.Balance);
        }

        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA: Arrange Act Assert

            // Arrange
            double expectedReturn = 100;
            double depositAmount = 100;

            // Act
            double returnValue = acc.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange
            // Nothing to add here
            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            acc.Deposit(invalidDepositAmount));
        }


        [TestMethod]
        public void Withdraw_APositiveAmount_DecreasesBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        public void Withdraw_APositiveAmount_ReturnsUpdatedBalance(double initialDeposit, 
                                                                    double withdrawalAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);

            // Act
            double returnedBalance = acc.Withdraw(withdrawalAmount);

            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-0.1)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            double withdrawAmount = 1000;
            
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "    ");
        }

        [TestMethod]
        [DataRow("John")]
        [DataRow("John Doe")]
        [DataRow("John Doe Is Dope Bro")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Joe 3rd")]
        [DataRow("Joseph Ortizio Smiths")]
        [DataRow("$$%$#")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}