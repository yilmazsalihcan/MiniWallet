using MediatR;
using MiniWallet.Application.Features.Wallet.Commands.DepositWallet;
using MiniWallet.Application.Models;
using MiniWallet.Domain.Interfaces.Repositories;
using MiniWallet.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Application.Features.Wallet.Commands.WithdrawWallet
{
    public class WithdrawWalletCommandHandler : IRequestHandler<WithdrawWalletCommand, ActionResponse<WithdrawWalletResponse>>
    {
        private readonly IRepository<Domain.Wallets.Wallet> _walletRepository;
        private readonly IRepository<Domain.Transactions.WalletTransaction> _walletTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WithdrawWalletCommandHandler(IRepository<Domain.Wallets.Wallet> walletRepository, IUnitOfWork unitOfWork, IRepository<Domain.Transactions.WalletTransaction> walletTransactionRepository)
        {
            _walletRepository = walletRepository ?? throw new ArgumentException(nameof(walletRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(unitOfWork));
            _walletTransactionRepository = walletTransactionRepository;
        }
        public async Task<ActionResponse<WithdrawWalletResponse>> Handle(WithdrawWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetByIdAsync(request.WalletId);
            if (wallet is null)
                return ActionResponse<WithdrawWalletResponse>.Fail(string.Format("Wallet not found for id {0}", request.WalletId.ToString()), 500);
           

            await _walletTransactionRepository.AddAsync(Domain.Transactions.WalletTransaction.Create(request.WalletId, (-1) * request.Amount));

            await _unitOfWork.SaveChangesAsync();

            return ActionResponse<WithdrawWalletResponse>.Success("Success", 200);
        }
    }
}
