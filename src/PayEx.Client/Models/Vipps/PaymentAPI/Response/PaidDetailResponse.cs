namespace PayEx.Client.Models.Vipps.PaymentAPI.Response
{
    using System;

    public class PaidDetailResponse
    {
        public string CardBrand { get; set; }
        public string MaskedPan { get; set; }
        public string CardType { get; set; }
        public string CountryCode { get; set; }
        public string IssuerAuthorizationApprovalCode { get; set; }
        public string AcquirerTransactionType { get; set; }
        public string AcquirerStan { get; set; }
        public string AcquirerTerminalId { get; set; }
        public string AcquirerTransactionTime { get; set; }
        public Guid NonPaymentToken { get; set; }
    }
}