using MiniWallet.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Application.Features.Wallet.Queries.CurrentBalance
{
    public class GetCurrentBalanceResponse
    {
        public decimal CurrentBalance { get; set; }
    }
}
