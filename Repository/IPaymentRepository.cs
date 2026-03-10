using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public interface IPaymentRepository
    {
        void Add(Payment payment);
        IEnumerable<Payment> GetByInvoiceId(int invoiceId);
        void Delete(int id);
    }
}