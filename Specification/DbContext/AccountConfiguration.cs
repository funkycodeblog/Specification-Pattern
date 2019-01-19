using System.Data.Entity.ModelConfiguration;

namespace FunkyCode.Specification
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration() : base()
        {
            Property(x => x.Balance).HasPrecision(10, 4);
        }

    }
}