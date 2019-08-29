using System;

namespace PayEx.Client.Models.Vipps.PaymentAPI.Request
{
    internal static class PaymentRequestExtensions
    {
        internal static void SetRequiredMerchantInfo(this PaymentRequest payment, PayExOptions options)
        {
            payment.PayeeInfo.PayeeId = options.MerchantId;
            payment.PayeeInfo.PayeeName = options.MerchantName;
            payment.Urls.CallbackUrl = options.CallBackUrl?.ToString();
            payment.Urls.CancelUrl = options.StatusInUrl ? IncludeStatusInUrl(options.CancelPageUrl, "status=cancel") : options.CancelPageUrl.ToString();
            payment.Urls.CompleteUrl = options.StatusInUrl ? IncludeStatusInUrl(options.CompletePageUrl, "status=complete") : options.CompletePageUrl.ToString();
            payment.Urls.LogoUrl = options.LogoUrl?.ToString();
            payment.Urls.TermsOfServiceUrl = options.TermsOfServiceUrl?.ToString();
        }

        private static string IncludeStatusInUrl(Uri url, string additionalQueryParameters)
        {
            if (string.IsNullOrEmpty(url.Query))
                return new Uri($"{url}?{additionalQueryParameters}").ToString();

            return new Uri($"{url}&{additionalQueryParameters}").ToString();
        }
    }
}