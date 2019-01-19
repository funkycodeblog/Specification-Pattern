using System.Data.Entity.ModelConfiguration;

namespace FunkyCode.Specification
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration() : base()
        {
            Property(x => x.Name).HasMaxLength(50);

            HasMany(x => x.Accounts)
                .WithRequired(x => x.Customer)
                .HasForeignKey(x => x.CustomerId)
                .WillCascadeOnDelete();
        }
    }
}