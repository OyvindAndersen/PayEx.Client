namespace PayEx.Client.Models.Vipps.PaymentAPI.Response
{
    public class PaidResponseContainer
    {
        public string Payment { get; set; }
        public PaidResponse Paid { get; set; }
    }
}