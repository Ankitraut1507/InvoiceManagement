using CRMInvoice.Data;
using CRMInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMInvoice.Repository
{
    public class InvoiceLineItemRepository : IInvoiceLineItemRepository
    {
        private readonly CRMInvoiceContext _context;

        public InvoiceLineItemRepository(CRMInvoiceContext context)
        {
            _context = context;
        }

        public void Add(InvoiceLineItem item)
        {
            _context.InvoiceLineItems.Add(item);

            // Update Invoice Totals
            var invoice = _context.Invoices.Find(item.InvoiceId);

            if (invoice != null)
            {
                invoice.SubTotal += item.Quantity * item.UnitPrice;
                invoice.Tax += item.Tax;
                invoice.Discount += item.Discount;
                invoice.GrandTotal = invoice.SubTotal + invoice.Tax - invoice.Discount;
            }

            _context.SaveChanges();
        }

        public IEnumerable<InvoiceLineItem> GetByInvoiceId(int invoiceId)
        {
            return _context.InvoiceLineItems
                           .Where(i => i.InvoiceId == invoiceId)
                           .ToList();
        }

        public void Delete(int id)
        {
            var item = _context.InvoiceLineItems.Find(id);

            if (item != null)
            {
                _context.InvoiceLineItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}