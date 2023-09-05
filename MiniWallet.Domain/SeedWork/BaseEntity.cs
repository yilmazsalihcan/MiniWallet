using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.SeedWork
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
