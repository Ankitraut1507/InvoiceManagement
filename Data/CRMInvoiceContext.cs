using CRMInvoice.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMInvoice.Data;

public class CRMInvoiceContext : DbContext
{

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Quote> Quotes { get; set; } = null!;
    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Server=DESKTOP-IC8IR0V\SQLEXPRESS;
              Database=CRMDB;
              User Id=appuser;
              Password=App@1234;
              Encrypt=True;
              TrustServerCertificate=True;
              MultipleActiveResultSets=True;");
    }
}