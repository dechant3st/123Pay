using _123Pay.Entities;
using _123Pay.Models;

namespace _123Pay.Persistence.Repositories;

public interface IPaymentRepo
{
    Task Add(Payment payment);
    Task Process(Guid referenceNo);
    Task Done(Guid referenceNo, IFormFile attachment);
    Task Fail(Guid referenceNo, IFormFile? attachment);
    Task<PaginatedList<Payment>> List(int pageNumber, int pageSize);
}
