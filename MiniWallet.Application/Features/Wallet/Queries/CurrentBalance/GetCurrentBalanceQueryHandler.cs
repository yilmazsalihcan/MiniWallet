using MediatR;
using MiniWallet.Application.Features.Wallet.Commands.WithdrawWallet;
using MiniWallet.Application.Models;
using MiniWallet.Domain.Interfaces.Repositories;

namespace MiniWallet.Application.Features.Wallet.Queries.CurrentBalance
{
    public class GetCurrentBalanceQueryHandler : IRequestHandler<GetCurrentBalanceQuery, ActionResponse<GetCurrentBalanceResponse>>
    {
        private readonly IRepository<Domain.Wallets.Wallet> _walletRepository;
        private readonly IRepository<Domain.Transactions.WalletTransaction> _walletTransactionRepository;
        public GetCurrentBalanceQueryHandler(IRepository<Domain.Transactions.WalletTransaction> walletTransactionRepository, IRepository<Domain.Wallets.Wallet> walletRepository)
        {
            _walletTransactionRepository = walletTransactionRepository;
            _walletRepository = walletRepository;
        }
        public async Task<ActionResponse<GetCurrentBalanceResponse>> Handle(GetCurrentBalanceQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.FirstOrDefaultAsync(x => x.UserId == request.UserId && x.Id == request.WalletId);
            if (wallet is null)
                return ActionResponse<GetCurrentBalanceResponse>.Fail(string.Format("Wallet not found for id {0}", request.WalletId.ToString()), 500);

            var currentBalance = (await _walletTransactionRepository.GetAsync(x => x.WalletId == request.WalletId)).Sum(y => y.Amount);

            return ActionResponse<GetCurrentBalanceResponse>.Success(new GetCurrentBalanceResponse {CurrentBalance = currentBalance }, 200);

        }
    }
}
