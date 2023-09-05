using Microsoft.EntityFrameworkCore;
using MiniWallet.Domain.Transactions;
using MiniWallet.Domain.Users;
using MiniWallet.Domain.Wallets;
using MiniWallet.Infrastructure.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Infrastructure
{
    public class MiniWalletDbContext : DbContext
    {
        public MiniWalletDbContext(DbContextOptions<MiniWalletDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
