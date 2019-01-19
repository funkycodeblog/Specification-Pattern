using Metaproject.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FunkyCode.Specification
{






    class Program
    {
        static void Main(string[] args)
        {
            
            var sendInfoSpecification = new SendInfoSpecification();

            using (var context = new BankContext())
            {
                // (...)

                var customers = context
                    .Customers
                    .Include("Accounts")
                    .Where(c => c.Accounts.Count >= 13)
                    .ToList();

                List<Customer> customersClone = new List<Customer>();
                foreach (var customer in customers)
                {
                    Customer iCustomer = new Customer();
                    PropertyMapper.Instance.MapProperties(customer, iCustomer);
                    iCustomer.Accounts = new List<Account>();
                    PropertyMapper.Instance.MapProperties(customer.Accounts.ToList(), iCustomer.Accounts);
                    customersClone.Add(iCustomer);

                }

                PropertyMapper.Instance.MapProperties(customers, customersClone);

                NotifyCustomers(customersClone);

                var customersToBecomePremium = context.Customers
                    .Where(c => _sendInfoSpecification.IsSatisfiedBy(c))
                    .ToList();

                var singleUserToCheck = context.Customers.Find(101);
                OnInit(singleUserToCheck);

               // var singleUserToCheck = context.Customers.Find(103);
                var isToSendInfo = sendInfoSpecification.IsSatisfiedBy(singleUserToCheck);
            }

        }

        static SendInfoSpecification _sendInfoSpecification = new SendInfoSpecification();

        public static void OnInit(Customer customer)
        {
            // (...)

            if (_sendInfoSpecification.IsSatisfiedBy(customer))
                ConvertToPremiumCustomer(customer);

            // (...)
        }


        public void OnInit2(Customer customer)
        {
            // (...)

            if (customer.Accounts.Count >= 10)
                ConvertToPremiumCustomer(customer);

            // (...)
        }

        public static void NotifyCustomers(List<Customer> customers)
        {
            // (...)
            

        }


        public static void Start()
        {
            using (var context = new BankContext())
            {

                var customersToBecomePremium = context.Customers
                    .Where(_sendInfoSpecification.ToExpression())
                    .ToList();

                Notify(customersToBecomePremium);
            }
        }

        private static void Notify(List<Customer> customersToBecomePremium)
        {
            throw new NotImplementedException();
        }

        private static void ConvertToPremiumCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

    
    }


}
