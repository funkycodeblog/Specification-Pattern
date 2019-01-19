using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkyCode.Specification
{
    public static class Seed
    {
        public static void Execute(BankContext context)
        {

            var r = new Random(DateTime.Now.Millisecond);
            var p = new PersonNameGenerator();

            var customers = new List<Customer>();

            for (int i = 0; i < 100; i++)
            {
                var customer = new Customer
                {
                    Name = p.GenerateRandomFirstName(),
                    Accounts = new List<Account>()
                };

                customers.Add(customer);

                var numberOfAccounts = r.Next(5, 15);
                for (int a = 0; a < numberOfAccounts; a++)
                {
                    var account = new Account
                    {
                        Number = r.Next(100000, 999900),
                        Balance = (decimal)(r.Next(500, 5000))
                    };
                    customer.Accounts.Add(account);
                }

            }

            context.Customers.AddRange(customers);

        }
    }
}
