using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public interface IInvoiceRepository
    {
        void Add(Invoice invoice);
        IEnumerable<Invoice> GetAll();
        Invoice? GetById(int id);
        void Update(Invoice invoice);
        void Delete(int id);
    }
}