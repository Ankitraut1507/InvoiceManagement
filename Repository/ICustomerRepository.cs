using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        void Update(Customer customer);
        void Delete(int id);
    }
}