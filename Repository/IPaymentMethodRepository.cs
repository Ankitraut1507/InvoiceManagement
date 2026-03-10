using CRMInvoice.Models;

namespace CRMInvoice.Repository
{
    public interface IPaymentMethodRepository
    {
        void Add(PaymentMethod method);
        IEnumerable<PaymentMethod> GetAll();
        PaymentMethod? GetById(int id);
        void Update(PaymentMethod method);
        void Delete(int id);
    }
}