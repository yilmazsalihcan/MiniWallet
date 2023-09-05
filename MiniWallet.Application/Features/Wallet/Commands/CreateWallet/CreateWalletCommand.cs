using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Application.Features.Wallet.Commands.CreateWallet
{
    public class CreateWalletCommand : IRequest<CreateWalletResponse>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
