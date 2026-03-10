using CRMInvoice.Data;
using CRMInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMInvoice.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly CRMInvoiceContext _context;

        public QuoteRepository(CRMInvoiceContext context)
        {
            _context = context;
        }

        public void Add(Quote quote)
        {
            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public IEnumerable<Quote> GetAll()
        {
            return _context.Quotes
                           .Include(q => q.Customer)   // include customer
                           .ToList();
        }

        public Quote? GetById(int id)
        {
            return _context.Quotes
                           .Include(q => q.Customer)
                           .FirstOrDefault(q => q.QuoteId == id);
        }

        public void Update(Quote quote)
        {
            _context.Quotes.Update(quote);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var quote = _context.Quotes.Find(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                _context.SaveChanges();
            }
        }
    }
}