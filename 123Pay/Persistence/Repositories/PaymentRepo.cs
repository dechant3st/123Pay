using _123Pay.Entities;
using _123Pay.Enums;
using _123Pay.Extensions;
using _123Pay.Models;
using Microsoft.EntityFrameworkCore;

namespace _123Pay.Persistence.Repositories;

public class PaymentRepo : IPaymentRepo
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _host;

    public PaymentRepo(ApplicationDbContext context, IWebHostEnvironment host)
    {
        _context = context;
        _host = host;
    }

    public async Task<Payment> Find(Guid referenceNo)
    {
        return await _context.Payments
            .Where(x => x.ReferenceNo == referenceNo)
            .FirstAsync();
    }

    public async Task Add(Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    public async Task Done(Guid referenceNo, IFormFile attachment)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(x => x.ReferenceNo == referenceNo);
        if(payment == null)
        {
            throw new Exception(message: "Record does not exist");
        }

        if(attachment == null)
        {
            throw new Exception(message: "Attachment is required");
        }

        var filePath = Path.Combine(_host.WebRootPath, "uploads",
            string.Format("{0}.{1}", Path.GetRandomFileName().Replace(".", string.Empty), attachment.FileName.Split('.')[1]));

        using (var stream = File.Create(filePath))
        {
            await attachment.CopyToAsync(stream);
        }

        payment.AttachmentPath = filePath;
        payment.Status = PaymentStatus.Done;
        await _context.SaveChangesAsync();
    }

    public async Task Fail(Guid referenceNo, IFormFile? attachment)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(x => x.ReferenceNo == referenceNo);
        if (payment == null)
        {
            throw new Exception(message: "Record does not exist");
        }

        if (attachment != null)
        {
            var filePath = Path.Combine(_host.WebRootPath, "uploads",
                string.Format("{0}.{1}", Path.GetRandomFileName().Replace(".", string.Empty), attachment.FileName.Split('.')[1]));

            using (var stream = File.Create(filePath))
            {
                await attachment.CopyToAsync(stream);
            }

            payment.AttachmentPath = filePath;
        }

        payment.Status = PaymentStatus.Failed;
        await _context.SaveChangesAsync();
    }

    public async Task Process(Guid referenceNo)
    {
        var payment = await _context.Payments.FirstOrDefaultAsync(x => x.ReferenceNo == referenceNo);
        if (payment == null)
        {
            throw new Exception(message: "Record does not exist");
        }

        payment.Status = PaymentStatus.Processing;
        await _context.SaveChangesAsync();
    }

    public async Task<PaginatedList<Payment>> List(int pageNumber = 1, int pageSize = 10)
    {
        return await _context.Payments
            .PaginatedListAsync(pageNumber, pageSize);
    }
}
