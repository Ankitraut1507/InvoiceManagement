using CRMInvoice.Data;
using CRMInvoice.Models;
using CRMInvoice.Repository;

using var context = new CRMInvoiceContext();

//Customer
ICustomerRepository repo = new CustomerRepository(context);

//Quotation
IQuoteRepository quoteRepo = new QuoteRepository(context);

//Invoice
IInvoiceRepository invoiceRepo = new InvoiceRepository(context);

//InvoiceLineTime
IInvoiceLineItemRepository lineRepo = new InvoiceLineItemRepository(context);

//Payment
IPaymentRepository paymentRepo = new PaymentRepository(context);

//PaymentMethod
IPaymentMethodRepository methodRepo = new PaymentMethodRepository(context);

while (true)
{
    Console.WriteLine("\n===== CUSTOMER MENU =====");
    Console.WriteLine("1. Add Customer");
    Console.WriteLine("2. View All Customers");
    Console.WriteLine("3. Update Customer");
    Console.WriteLine("4. Delete Customer");
    Console.WriteLine("5. Exit");
    Console.WriteLine("6. Add Quote");
    Console.WriteLine("7. View All Quotes");
    Console.WriteLine("8. Add Invoice");
    Console.WriteLine("9. View All Invoices");
    Console.WriteLine("10. Update Invoice");
    Console.WriteLine("11. Delete Invoice");
    Console.WriteLine("12. Add Invoice Line Item");
    Console.WriteLine("13. View Line Items By Invoice");
    Console.WriteLine("14. Add Payment");
    Console.WriteLine("15. View Payments By Invoice");
    Console.WriteLine("16. Add Payment Method");
    Console.WriteLine("17. View Payment Methods");
    Console.Write("Select Option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Customer customer = new Customer();

            Console.Write("Enter Name: ");
            customer.CustomerName = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            customer.Phone = Console.ReadLine();

            Console.Write("Enter Address: ");
            customer.Address = Console.ReadLine();

            Console.Write("Enter GST Number: ");
            customer.GSTNumber = Console.ReadLine()!;

            customer.CreatedDate = DateTime.Now;
            customer.IsActive = true;

            try
            {
                repo.Add(customer);
                Console.WriteLine("Customer added successfully!");
            }
            catch
            {
                Console.WriteLine("Error: Possible duplicate Email or GSTNumber.");
            }

            break;

        case "2":
            var customers = repo.GetAll();

            foreach (var c in customers)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"ID: {c.CustomerId}");
                Console.WriteLine($"Name: {c.CustomerName}");
                Console.WriteLine($"Email: {c.Email}");
                Console.WriteLine($"GST: {c.GSTNumber}");
            }
            break;

        case "3":
            Console.Write("Enter Customer ID to update: ");

            if (!int.TryParse(Console.ReadLine(), out int updateId))
            {
                Console.WriteLine("Invalid ID format!");
                break;
            }

            var existingCustomer = repo.GetById(updateId);

            if (existingCustomer != null)
            {
                Console.Write("Enter New Name: ");
                existingCustomer.CustomerName = Console.ReadLine()!;

                Console.Write("Enter New Email: ");
                existingCustomer.Email = Console.ReadLine();

                Console.Write("Enter New Phone: ");
                existingCustomer.Phone = Console.ReadLine();

                Console.Write("Enter New Address: ");
                existingCustomer.Address = Console.ReadLine();

                Console.Write("Enter New GST Number: ");
                existingCustomer.GSTNumber = Console.ReadLine()!;

                try
                {
                    repo.Update(existingCustomer);
                    Console.WriteLine("Customer updated successfully!");
                }
                catch
                {
                    Console.WriteLine("Error: Possible duplicate Email or GSTNumber.");
                }
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }

            break;

        case "4":
            Console.Write("Enter Customer ID to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int deleteId))
            {
                Console.WriteLine("Invalid ID format!");
                break;
            }

            repo.Delete(deleteId);
            Console.WriteLine("Customer deleted (if existed).");
            break;

        case "5":
            return;

        case "6":

            Console.Write("Enter Customer ID: ");
            int custId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Quote Number: ");
            string quoteNumber = Console.ReadLine()!;

            Quote quote = new Quote()
            {
                CustomerId = custId,
                QuoteNumber = quoteNumber,
                QuoteDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(15),
                Status = "Pending",
                SubTotal = 10000,
                Tax = 1800,
                Discount = 500,
                GrandTotal = 11300
            };

            try
            {
                quoteRepo.Add(quote);
                Console.WriteLine("Quote added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding quote: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
            break;

        case "7":

            var quotes = quoteRepo.GetAll();

            foreach (var q in quotes)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Quote ID: {q.QuoteId}");
                Console.WriteLine($"Quote Number: {q.QuoteNumber}");
                Console.WriteLine($"Quote Date:{q.QuoteDate.ToString()}");
                Console.WriteLine($"Customer: {q.Customer.CustomerName}");
                Console.WriteLine($"Grand Total: {q.GrandTotal}");
            }

            break;

        case "8":

            Console.Write("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Quote ID (or press Enter to skip): ");
            string? quoteInput = Console.ReadLine();

            int? quoteId = string.IsNullOrWhiteSpace(quoteInput)
                ? null
                : int.Parse(quoteInput);

            Console.Write("Enter Invoice Number: ");
            string invoiceNumber = Console.ReadLine()!;

            Invoice invoice = new Invoice()
            {
                CustomerId = customerId,
                QuoteId = quoteId,
                InvoiceNumber = invoiceNumber,
                InvoiceDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Status = "Pending",
                SubTotal = 10000,
                Tax = 1800,
                Discount = 500,
                GrandTotal = 11300,
                CreatedDate = DateTime.Now,
                IsArchived = false
            };

            invoiceRepo.Add(invoice);

            Console.WriteLine("Invoice created successfully!");
            break;

        case "9":

            var invoices = invoiceRepo.GetAll();

            foreach (var i in invoices)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Invoice ID: {i.InvoiceId}");
                Console.WriteLine($"Invoice No: {i.InvoiceNumber}");
                Console.WriteLine($"Customer: {i.Customer.CustomerName}");
                Console.WriteLine($"Quote ID: {i.QuoteId}");
                Console.WriteLine($"Grand Total: {i.GrandTotal}");
            }

            break;

        case "10":

            Console.Write("Enter Invoice ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int invoiceUpdateId))
            {
                Console.WriteLine("Invalid ID format!");
                break;
            }

            var existingInvoice = invoiceRepo.GetById(invoiceUpdateId);

            if (existingInvoice != null)
            {
                Console.Write("Enter New Invoice Number (or press Enter to keep current): ");
                var newInvoiceNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newInvoiceNumber))
                {
                    existingInvoice.InvoiceNumber = newInvoiceNumber;
                }

                Console.Write("Enter New Status (or press Enter to keep current): ");
                var newStatus = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newStatus))
                {
                    existingInvoice.Status = newStatus;
                }

                Console.Write("Enter New Due Date (YYYY-MM-DD) or press Enter to keep current: ");
                var newDueDate = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDueDate) && DateTime.TryParse(newDueDate, out DateTime dueDate))
                {
                    existingInvoice.DueDate = dueDate;
                }

                try
                {
                    invoiceRepo.Update(existingInvoice);
                    Console.WriteLine("Invoice updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating invoice: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invoice not found!");
            }

            break;

        case "11":

            Console.Write("Enter Invoice ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int invoiceDeleteId))
            {
                Console.WriteLine("Invalid ID format!");
                break;
            }

            try
            {
                invoiceRepo.Delete(invoiceDeleteId);
                Console.WriteLine("Invoice deleted (if existed).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting invoice: {ex.Message}");
            }

            break;

        case "12":

            Console.Write("Enter Invoice ID: ");
            if (!int.TryParse(Console.ReadLine(), out int invoiceId))
            {
                Console.WriteLine("Invalid Invoice ID.");
                break;
            }

            Console.Write("Enter Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Enter Quantity: ");
            decimal quantity = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Unit Price: ");
            decimal unitPrice = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Discount: ");
            decimal discount = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Tax: ");
            decimal tax = decimal.Parse(Console.ReadLine()!);

            decimal lineTotal = (quantity * unitPrice) + tax - discount;

            InvoiceLineItem item = new InvoiceLineItem()
            {
                InvoiceId = invoiceId,
                Description = description,
                Quantity = quantity,
                UnitPrice = unitPrice,
                Discount = discount,
                Tax = tax,
                LineTotal = lineTotal
            };

            lineRepo.Add(item);

            Console.WriteLine("Line item added successfully!");
            break;

        case "13":

            Console.Write("Enter Invoice ID: ");
            int invId = int.Parse(Console.ReadLine()!);

            var items = lineRepo.GetByInvoiceId(invId);

            foreach (var i in items)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine($"Item ID: {i.LineItemId}");
                Console.WriteLine($"Description: {i.Description}");
                Console.WriteLine($"Quantity: {i.Quantity}");
                Console.WriteLine($"Unit Price: {i.UnitPrice}");
                Console.WriteLine($"Line Total: {i.LineTotal}");
            }

            break;

        case "14":

            Console.Write("Enter Invoice ID: ");
            if (!int.TryParse(Console.ReadLine(), out int paymentInvoiceId))
            {
                Console.WriteLine("Invalid Invoice ID.");
                break;
            }

            Console.Write("Enter Payment Method ID: ");
            int methodId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Payment Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine()!);

            Console.Write("Enter Reference Number: ");
            string reference = Console.ReadLine()!;

            Payment payment = new Payment()
            {
                InvoiceId = paymentInvoiceId,
                PaymentMethodId = methodId,
                PaymentAmount = amount,
                PaymentDate = DateTime.Now,
                ReceivedDate = DateTime.Now,
                ReferenceNumber = reference
            };

            try
            {
                paymentRepo.Add(payment);
                Console.WriteLine("Payment added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;

        case "15":

            Console.Write("Enter Invoice ID: ");
            int paymentInvId = int.Parse(Console.ReadLine()!);

            var payments = paymentRepo.GetByInvoiceId(paymentInvId);

            foreach (var p in payments)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Payment ID: {p.PaymentId}");
                Console.WriteLine($"Amount: {p.PaymentAmount}");
                Console.WriteLine($"Method: {p.PaymentMethod.MethodName}");
                Console.WriteLine($"Date: {p.PaymentDate}");
            }

            break;

        case "16":

            Console.Write("Enter Method Name: ");
            string methodName = Console.ReadLine()!;

            PaymentMethod method = new PaymentMethod()
            {
                MethodName = methodName,
                IsActive = true
            };

            methodRepo.Add(method);

            Console.WriteLine("Payment Method added successfully!");
            break;

        case "17":

            var methods = methodRepo.GetAll();

            foreach (var m in methods)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"ID: {m.MethodId}");
                Console.WriteLine($"Name: {m.MethodName}");
                Console.WriteLine($"Active: {m.IsActive}");
            }

            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}
