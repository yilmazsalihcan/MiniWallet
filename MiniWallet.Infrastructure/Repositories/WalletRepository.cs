using MiniWallet.Domain.Interfaces.Repositories;
using MiniWallet.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Infrastructure.Repositories
{
    public class WalletRepository
    {
        public Task AddAsync(Wallet entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Wallet entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wallet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Wallet entity)
        {
            throw new NotImplementedException();
        }
    }
}
