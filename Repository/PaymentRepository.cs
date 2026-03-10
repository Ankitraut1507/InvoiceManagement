using CRMInvoice.Data;
using CRMInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMInvoice.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CRMInvoiceContext _context;

        public PaymentRepository(CRMInvoiceContext context)
        {
            _context = context;
        }

        public void Add(Payment payment)
        {
            // Check invoice exists
            var invoice = _context.Invoices.Find(payment.InvoiceId);

            if (invoice == null)
                throw new Exception("Invoice not found.");

            // Add payment
            _context.Payments.Add(payment);

            // Calculate total paid
            var totalPaid = _context.Payments
                                    .Where(p => p.InvoiceId == payment.InvoiceId)
                                    .Sum(p => p.PaymentAmount)
                            + payment.PaymentAmount;

            // Update Invoice Status
            if (totalPaid >= invoice.GrandTotal)
                invoice.Status = "Paid";
            else if (totalPaid > 0)
                invoice.Status = "Partially Paid";
            else
                invoice.Status = "Pending";

            _context.SaveChanges();
        }

        public IEnumerable<Payment> GetByInvoiceId(int invoiceId)
        {
            return _context.Payments
                           .Include(p => p.PaymentMethod)
                           .Where(p => p.InvoiceId == invoiceId)
                           .ToList();
        }

        public void Delete(int id)
        {
            var payment = _context.Payments.Find(id);

            if (payment != null)
            {
                _context.Payments.Remove(payment);
                _context.SaveChanges();
            }
        }
    }
}