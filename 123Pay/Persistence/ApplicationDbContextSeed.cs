using _123Pay.Entities;
using _123Pay.Enums;

namespace _123Pay.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        if(!context.Payments.Any())
        {
            await context.Payments.AddRangeAsync(new List<Payment>
            {
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 1",
                    AccountNo = "000001",
                    OtherDetails = "This is a sample data.",
                    Amount = 100,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant B",
                    AccountName = "Account 2",
                    AccountNo = "000002",
                    OtherDetails = "This is a sample data.",
                    Amount = 300,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant C",
                    AccountName = "Account 1",
                    AccountNo = "000001",
                    OtherDetails = "This is a sample data.",
                    Amount = 800,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant B",
                    AccountName = "Account 3",
                    AccountNo = "000003",
                    OtherDetails = "This is a sample data.",
                    Amount = 300,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 2",
                    AccountNo = "000002",
                    OtherDetails = "This is a sample data.",
                    Amount = 100,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 4",
                    AccountNo = "000004",
                    OtherDetails = "This is a sample data.",
                    Amount = 600,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant C",
                    AccountName = "Account 5",
                    AccountNo = "000005",
                    OtherDetails = "This is a sample data.",
                    Amount = 1000,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 2",
                    AccountNo = "000002",
                    OtherDetails = "This is a sample data.",
                    Amount = 500,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant B",
                    AccountName = "Account 6",
                    AccountNo = "000006",
                    OtherDetails = "This is a sample data.",
                    Amount = 2000,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant D",
                    AccountName = "Account 1",
                    AccountNo = "000001",
                    OtherDetails = "This is a sample data.",
                    Amount = 4000,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 1",
                    AccountNo = "000001",
                    OtherDetails = "This is a sample data.",
                    Amount = 400,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant B",
                    AccountName = "Account 2",
                    AccountNo = "000002",
                    OtherDetails = "This is a sample data.",
                    Amount = 300,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant C",
                    AccountName = "Account 1",
                    AccountNo = "000001",
                    OtherDetails = "This is a sample data.",
                    Amount = 100,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant B",
                    AccountName = "Account 3",
                    AccountNo = "000003",
                    OtherDetails = "This is a sample data.",
                    Amount = 200,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 2",
                    AccountNo = "000002",
                    OtherDetails = "This is a sample data.",
                    Amount = 100,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 4",
                    AccountNo = "000004",
                    OtherDetails = "This is a sample data.",
                    Amount = 600,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant C",
                    AccountName = "Account 5",
                    AccountNo = "000005",
                    OtherDetails = "This is a sample data.",
                    Amount = 850,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant A",
                    AccountName = "Account 2",
                    AccountNo = "000002",
                    OtherDetails = "This is a sample data.",
                    Amount = 500,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant B",
                    AccountName = "Account 6",
                    AccountNo = "000006",
                    OtherDetails = "This is a sample data.",
                    Amount = 800,
                    Status = PaymentStatus.Pending
                },
                new Payment
                {
                    Merchant = "Merchant D",
                    AccountName = "Account 1",
                    AccountNo = "000001",
                    OtherDetails = "This is a sample data.",
                    Amount = 300,
                    Status = PaymentStatus.Pending
                }
            });

            await context.SaveChangesAsync();
        }
    }
}
