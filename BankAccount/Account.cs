using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates acc with specific owner and the balance of 0
        /// </summary>
        /// <param name="owner"></param>
        public Account(string owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// The acc holder, full name
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Amount of money in the account currently
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Gets the specified amount of money to the account
        /// </summary>
        /// <param name="amt"></param>
        public double Deposit(double amt)
        {
            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Amount of money took from the account
        /// </summary>
        /// <param name="amt"></param>
        public void Withdraw(double amt)
        {
            throw new NotImplementedException();
        }


    }
}
