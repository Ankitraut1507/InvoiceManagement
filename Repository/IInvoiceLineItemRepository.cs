using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public interface IInvoiceLineItemRepository
    {
        void Add(InvoiceLineItem item);
        IEnumerable<InvoiceLineItem> GetByInvoiceId(int invoiceId);
        void Delete(int id);
    }
}