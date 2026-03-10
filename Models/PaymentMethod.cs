using System.ComponentModel.DataAnnotations;

namespace CRMInvoice.Models;

public class PaymentMethod
{
    [Key]
    public int MethodId { get; set; }

    [Required]
    public string MethodName { get; set; } = null!;

    public bool IsActive { get; set; }

    // Navigation Property
    public ICollection<Payment>? Payments { get; set; }
}