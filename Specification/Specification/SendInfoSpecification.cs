using System;
using System.Linq.Expressions;

namespace FunkyCode.Specification
{

    public class SendInfoSpecification : Specification<Customer>
    {
        public override Expression<Func<Customer, bool>> ToExpression()
        {
            return customer => customer.Accounts.Count > 10;
        }
    }

    public class SendInfoInMemorySpecification : ISpecification<Customer>
    {
        public bool IsSatisfiedBy(Customer customer)
        {
            return customer.Accounts.Count > 10;
        }
    }
   
}
