using MediatR;
using MiniWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Application.Features.Wallet.Commands.WithdrawWallet
{
    public class WithdrawWalletCommand: IRequest<ActionResponse<WithdrawWalletResponse>>
    {
        public Guid WalletId { get; set; }
        public decimal Amount { get; set; }
    }
}
