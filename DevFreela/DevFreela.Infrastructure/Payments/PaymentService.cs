using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        private IMessageBusService _messageBus;
        private const string QUEUE_NAME = "Payments";

        public PaymentService(IMessageBusService messageBus)
        {
            _messageBus = messageBus;
        }


        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBus.Publish(QUEUE_NAME, paymentInfoBytes);
        }




        //var url = $"{_paymentBaseUrl}/api/payments";
        //var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);
        //var paymentInfoContent = new StringContent(
        //        paymentInfoJson,
        //        Encoding.UTF8,
        //        "application/json"
        //    );

        //var httpClient = _httpClientFactory.CreateClient("Payments");

        //var response = await httpClient.PostAsync(url, paymentInfoContent);

        //return response.IsSuccessStatusCode;
    }
}
