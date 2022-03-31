using _123Pay.Entities;

namespace _123Pay.Models;

public class NewPaymentRequest
{
    public string Merchant { get; set; } = "";
    public string AccountNo { get; set; } = "";
    public string AccountName { get; set; } = "";
    public string OtherDetails { get; set; } = "";
    public decimal Amount { get; set; }

    public Payment ToEntity()
    {
        return new Payment
        {
            Merchant = Merchant,
            AccountNo = AccountNo,
            AccountName = AccountName,
            OtherDetails = OtherDetails,
            Amount = Amount
        };
    }
}
