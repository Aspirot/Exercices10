using Exercices10.Models;

namespace Exercices10.Service
{
    public class CustomersRepository : ICustomersRepository
    {
        private boey_webserveurContext _context;
        public CustomersRepository(boey_webserveurContext context)
        {
            _context = context;
        }
        public List<Customer2> GetCustomers()
        {
            return _context.Customer2s.ToList();
        }

        public Customer2 AddCustomer(Customer2 customer)
        {
            var cust = _context.Customer2s.Add(customer).Entity;
            _context.SaveChanges();
            return cust;
        }

        public Customer2 UpdateCustomer(Customer2 customer)
        {
            var cust = _context.Customer2s.Update(customer).Entity;
            _context.SaveChanges();
            return cust;
        }

        public Customer2 DeleteCustomer(Customer2 customer)
        {
            var cust = _context.Customer2s.Remove(customer).Entity;
            _context.SaveChanges();
            return cust;
        }

        public Customer2 GetCustomerById(int id)
        {
            return _context.Customer2s.Find(id);
        }
    }
}
