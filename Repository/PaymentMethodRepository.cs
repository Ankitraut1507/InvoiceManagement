using CRMInvoice.Data;
using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly CRMInvoiceContext _context;

        public PaymentMethodRepository(CRMInvoiceContext context)
        {
            _context = context;
        }

        public void Add(PaymentMethod method)
        {
            _context.PaymentMethods.Add(method);
            _context.SaveChanges();
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _context.PaymentMethods.ToList();
        }

        public PaymentMethod? GetById(int id)
        {
            return _context.PaymentMethods.Find(id);
        }

        public void Update(PaymentMethod method)
        {
            _context.PaymentMethods.Update(method);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var method = _context.PaymentMethods.Find(id);

            if (method != null)
            {
                _context.PaymentMethods.Remove(method);
                _context.SaveChanges();
            }
        }
    }
}