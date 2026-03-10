using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public interface IQuoteRepository
    {
        void Add(Quote quote);
        IEnumerable<Quote> GetAll();
        Quote? GetById(int id);
        void Update(Quote quote);
        void Delete(int id);
    }
}