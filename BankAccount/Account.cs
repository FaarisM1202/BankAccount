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
        private string owner;

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
        public string Owner {
            get { return owner; } 
            set 
            {
                if(value == null)
                {
                    throw new ArgumentNullException($"{nameof(Owner)} cannot be null!");
                }
                if(value.Trim() == string.Empty)
                {
                    throw new ArgumentException($"{nameof(Owner)} must have some text!");
                }

                if(IsOwnerNameValid(value))
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Owner)} can be up to 20 characters, A-Z! (Can contain spaces)");
                }
            }
        }

        /// <summary>
        /// Checks if Owner name is less than or equal to 20 characters, A-Z, white
        /// spaces are allowed.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private bool IsOwnerNameValid(string ownerName)
        {
            char[] validCharacters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                'y', 'z' };
            ownerName = ownerName.ToLower(); // only needs to compare to one casing.
            foreach(char letter in ownerName)
            {
                if(letter != ' ' && !validCharacters.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

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
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be more than 0!");
            }
            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Amount of money took from the account
        /// </summary>
        /// <param name="amt"></param>
        public double Withdraw(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amt)} must be greater than 0!");
            }
            else if (amt > Balance)
            {
                throw new ArgumentException($"{nameof(amt)} cannot be greater than balance!");
            }
            Balance -= amt;
            return Balance;
        }


    }
}
