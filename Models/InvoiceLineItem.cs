using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMInvoice.Models;

public class InvoiceLineItem
{
    [Key]
    public int LineItemId { get; set; }

    // Foreign Key
    public int InvoiceId { get; set; }

    [Required]
    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Tax { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal LineTotal { get; set; }

    // Navigation Property
    public Invoice Invoice { get; set; } = null!;
}