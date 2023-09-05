using MiniWallet.Domain.SeedWork;
using MiniWallet.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Wallets
{
    public class Wallet : BaseEntity, IAggregateRoot
    {
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public Money Price { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public Wallet()
        {

        }

        public static Wallet Create(Guid userId, string name, string currency, decimal amount)
        {
            return new Wallet(userId, name, currency, amount);
        }

        public void Deposit(string currency, decimal amount, decimal depositAmount)
        {
            amount += depositAmount;
            Price = new Money(currency, amount);
        }

        public void Withdraw(string currency, decimal amount, decimal withdrawAmount)
        {
            amount -= withdrawAmount;
            Price = new Money(currency, amount);
        }

        public Wallet(Guid userId, string name, string currency, decimal amount)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(string.Format("{0} cannot be empty", nameof(name)));
            if (amount == 0)
                throw new Exception("{0} cannot be zero");
            if (string.IsNullOrEmpty(currency))
                throw new ArgumentNullException(string.Format("{0} cannot be empty", nameof(currency)));

            Id = Guid.NewGuid();
            UserId = userId;
            Name = name;
            Price = new Money(currency, amount);
            CreatedDate = DateTime.Now;
        }
    }
}
