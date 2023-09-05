using MediatR;
using MiniWallet.Domain.Interfaces.Repositories;
using MiniWallet.Domain.SeedWork;
using MiniWallet.Domain.Wallets;

namespace MiniWallet.Application.Features.Wallet.Commands.CreateWallet
{
    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, CreateWalletResponse>
    {
        private readonly IRepository<Domain.Wallets.Wallet> _walletRepository;
        private readonly IRepository<Domain.Users.User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateWalletCommandHandler(IRepository<Domain.Wallets.Wallet> walletRepository, 
                                          IRepository<Domain.Users.User> userRepository, 
                                          IUnitOfWork unitOfWork)
        {
            _walletRepository = walletRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateWalletResponse> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var wallet = Domain.Wallets.Wallet.Create(user.Id, request.Name, request.Currency, request.Amount);

            await _walletRepository.AddAsync(wallet);

            await _unitOfWork.SaveChangesAsync();

            return null;
        }
    }
}
