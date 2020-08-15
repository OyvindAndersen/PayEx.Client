namespace PayEx.Client.Models.Vipps.PaymentAPI.Response
{
    using System;

    public class PaidResponse
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public Guid PayeeReference { get; set; }
        public int Amount { get; set; }
        public PaidTransactionResponse Transaction { get; set; }
        public PaidDetailResponse Detail { get; set; }

    }
}