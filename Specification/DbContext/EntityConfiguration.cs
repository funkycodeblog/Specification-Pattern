using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FunkyCode.Specification
{

    public class EntityConfiguration<T> : EntityTypeConfiguration<T> where T : Entity
    {
        public EntityConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}