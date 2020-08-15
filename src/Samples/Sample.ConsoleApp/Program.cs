using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using PayEx.Client;
using PayEx.Client.Models.Vipps.PaymentAPI.Common;
using PayEx.Client.Models.Vipps.PaymentAPI.Request;

namespace Sample.ConsoleApp
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var payExOptions = new PayExOptions
            {
                
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com/psp/creditcard/payments/"),
                Token = "c274f82a89b3853e8dfdd842996caa19268b6989a0ea130298ed02ecd6880c36",
                MerchantId = "d3f5327c-d735-44fb-b8aa-7fb4170a36b6",
                MerchantName = "Hurtigruten",
                //CallBackUrl = new Uri("https://yourdomain.com/callbacks"),
                //CancelPageUrl = new Uri("https://yourdomain.com/cancel"),
                //CompletePageUrl = new Uri("https://yourdomain.com/complete")
            };

            IOptions<PayExOptions> options = new OptionsWrapper<PayExOptions>(payExOptions);

            IHttpClientFactory httpClientFactory = new HttpClientCreator(options.Value);

            ISelectClient clientSelector = new DummySelector();


            IConfigureOptions<PayExOptions> optionsConfigurator = new ConfigureOptions<PayExOptions>(Conf(payExOptions));
            var configureOptionses = new []{ optionsConfigurator };
            IPostConfigureOptions<PayExOptions> postoptionsConfigurator = new PostConfigureOptions<PayExOptions>(Constants.THECLIENTNAME,Conf(payExOptions));
            var postConfigureOptionses = new []{ postoptionsConfigurator};
            
            IOptionsSnapshot<PayExOptions> optionsSnap = new OptionsManager<PayExOptions>(new OptionsFactory<PayExOptions>(configureOptionses,postConfigureOptionses));
            var payExClient = new PayExClient(httpClientFactory, optionsSnap, clientSelector);

            var id = "7a378390-c198-4ab2-cfbb-08d8378632ec";
            var payment = payExClient.GetPayment(id).GetAwaiter().GetResult();
            var paid = payExClient.GetPaidPayment(id).GetAwaiter().GetResult();
            //var prices = new Price
            //{
            //    Amount = 10000,
            //    VatAmount = 2500,
            //    Type = PriceTypes.Vipps
            //};
            //var paymentRequest = new PaymentRequest("Console.Sample/1.0.0", "Some productname", "order123", "123456", prices);
            //var res = payExClient.PostVippsPayment(paymentRequest).GetAwaiter().GetResult();
            //Console.WriteLine($"Payment created with id : {res.Payment.Id}");
        }

        private static Action<PayExOptions> Conf(PayExOptions payExOptions)
        {
            return o =>
            {
                o.ApiBaseUrl = payExOptions.ApiBaseUrl;
                o.Token = payExOptions.Token;
                o.MerchantId = payExOptions.MerchantId;
                o.MerchantName = payExOptions.MerchantName;
                o.CallBackUrl = payExOptions.CallBackUrl;
                o.CancelPageUrl = payExOptions.CancelPageUrl;
                o.CompletePageUrl = payExOptions.CompletePageUrl;
            };
        }
    }

    internal class DummySelector : ISelectClient
    {
        public string Select()
        {
            return Constants.THECLIENTNAME;
        }
    }

    internal class HttpClientCreator : IHttpClientFactory
    {
        private readonly PayExOptions _payExOptions;

        public HttpClientCreator(PayExOptions payExOptions)
        {
            _payExOptions = payExOptions;
        }
        public HttpClient CreateClient(string name)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_payExOptions.Token}");
            httpClient.BaseAddress = _payExOptions.ApiBaseUrl;
            return httpClient;
        }
    }

    public static class Constants
    {
        public const string THECLIENTNAME = "something";
    }
}
