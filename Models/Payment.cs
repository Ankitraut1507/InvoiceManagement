using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMInvoice.Models;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }

    // Foreign Keys
    public int InvoiceId { get; set; }

    public int PaymentMethodId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PaymentAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime ReceivedDate { get; set; }

    // Navigation Properties
    public Invoice Invoice { get; set; } = null!;

    public PaymentMethod PaymentMethod { get; set; } = null!;
}