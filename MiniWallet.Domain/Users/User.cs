using MiniWallet.Domain.SeedWork;

namespace MiniWallet.Domain.Users
{
    public class User : BaseEntity
    {    
        public string FirstName { get; private set; }
        public string LastName { get;  private set; }

        public static User Create(string firstName, string lastName)
        {
            return new User { FirstName = firstName,LastName = lastName, Id = Guid.NewGuid()};
        }
    }
}
