using MediatR;
using MiniWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Application.Features.Wallet.Queries.CurrentBalance
{
    public class GetCurrentBalanceQuery : IRequest<ActionResponse<GetCurrentBalanceResponse>>
    {
        public Guid WalletId { get; set; }
        public Guid UserId { get; set; }
    }
}
