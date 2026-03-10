using CRMInvoice.Data;
using CRMInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMInvoice.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CRMInvoiceContext _context;

        public InvoiceRepository(CRMInvoiceContext context)
        {
            _context = context;
        }

        public void Add(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _context.Invoices
                           .Include(i => i.Customer)
                           .Include(i => i.Quote)
                           .ToList();
        }

        public Invoice? GetById(int id)
        {
            return _context.Invoices
                           .Include(i => i.Customer)
                           .Include(i => i.Quote)
                           .FirstOrDefault(i => i.InvoiceId == id);
        }

        public void Update(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }
        }
    }
}