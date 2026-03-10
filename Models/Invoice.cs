using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMInvoice.Models;

public class Invoice
{
    [Key]
    public int InvoiceId { get; set; }

    [Required]
    public string InvoiceNumber { get; set; } = null!;

    // Foreign Keys
    public int CustomerId { get; set; }

    // Nullable if optional
    public int? QuoteId { get; set; } 
     
    // Dates
    public DateTime InvoiceDate { get; set; }

    public DateTime DueDate { get; set; }

    // Status
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

    public DateTime CreatedDate { get; set; }

    public bool IsArchived { get; set; }

    // Navigation Properties
    public Customer Customer { get; set; } = null!;

    public Quote? Quote { get; set; }

    public ICollection<InvoiceLineItem>? InvoiceLineItems { get; set; }

    public ICollection<Payment>? Payments { get; set; }
}