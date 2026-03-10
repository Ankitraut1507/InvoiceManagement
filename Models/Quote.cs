using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMInvoice.Models;

public class Quote
{
    [Key]
    public int QuoteId { get; set; }

    [Required]
    public string QuoteNumber { get; set; } = null!;

    // Foreign Key
    public int CustomerId { get; set; }

    // Dates
    public DateTime QuoteDate { get; set; }

    public DateTime ExpiryDate { get; set; }

    public string? Status { get; set; }

    // Amount Details
    [Column(TypeName = "decimal(18,2)")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Tax { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal GrandTotal { get; set; }

    // Navigation Properties
    public Customer Customer { get; set; } = null!;

    public ICollection<Invoice>? Invoices { get; set; }
}