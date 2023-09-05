using MiniWallet.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Transactions
{
    public class WalletTransaction : BaseEntity
    {
        public Guid WalletId { get; private set; }
        public decimal Amount { get; private set; }

        public static WalletTransaction Create(Guid walletId, decimal amount)
        {
            return new WalletTransaction
            {
                WalletId = walletId,
                Amount = amount,
                Id = Guid.NewGuid()
            };
        }
    }
}
