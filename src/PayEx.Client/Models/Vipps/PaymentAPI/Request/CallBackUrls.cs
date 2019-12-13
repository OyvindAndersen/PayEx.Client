using System.Collections.Generic;

namespace PayEx.Client.Models.Vipps.PaymentAPI.Request
{
    public class CallBackUrls
    {
        /// <summary>
        /// Web page to redirect the customer on completed
        /// </summary>
        public string CompleteUrl { get; set; }

        /// <summary>
        /// Web page to redirect the customer on cancel
        /// </summary>
        public string CancelUrl { get; set; }

        /// <summary>
        /// API callback endpoint. Called on Vipps app payment sequence finished.
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// Optional url to logo on the payment page
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Optional terms of service to be provided as a link on the payment page
        /// </summary>
        public string TermsOfServiceUrl { get; set; }

        public List<string> HostUrls { get; set; }
    }
}