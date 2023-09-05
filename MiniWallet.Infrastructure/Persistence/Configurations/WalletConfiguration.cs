using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniWallet.Domain.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Infrastructure.Persistence.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            //builder.OwnsOne(x => x.Price).Property(p => p.Currency).HasColumnName("Currency");
            //builder.OwnsOne(x => x.Price).Property(p => p.Amount).HasColumnName("Amount");

            builder.HasKey(x => x.Id);


            builder.OwnsOne(x => x.Price, rb =>
            {
                rb.Property(vo => vo.Currency).HasColumnName("Currency");
                rb.Property(vo => vo.Amount).HasColumnName("Amount");
            });
        }
    }
}
