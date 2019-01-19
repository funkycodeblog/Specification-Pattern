using System.Collections.Generic;

namespace FunkyCode.Specification
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}