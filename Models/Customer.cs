using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CRMInvoice.Models;


public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    public string CustomerName { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    public string? Address { get; set; }
   
    public string? GSTNumber { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    // Navigation Property
    public ICollection<Invoice>? Invoices { get; set; }
    public ICollection<Quote>? Quotes { get; set; }
}