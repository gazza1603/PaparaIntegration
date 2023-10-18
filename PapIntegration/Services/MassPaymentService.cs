//Please note not complete due to change of scope
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PapIntegration.Models.MassPayment;

namespace PapIntegration.Services
{
    public class MassPaymentService
    {
        private readonly string _apiBaseUrl;
        private readonly string _emailPaymentUrl = "masspayment/email";
        private readonly string _phonePaymentUrl = "masspayment/phone";
        private readonly string _accountPaymentUrl = "masspayment/account";
        private readonly HttpClient _httpClient;

        public MassPaymentService(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient { BaseAddress = new Uri(_apiBaseUrl) };
        }

        public async Task<PayoutResponse> SendMoneyByEmailAsync(EmailPayoutRequest request, string apiKey)
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _emailPaymentUrl);
            requestMessage.Headers.Add("ApiKey", apiKey);
            requestMessage.Content = httpContent;

            Console.WriteLine("HTTP Request:");
            Console.WriteLine(requestMessage.ToString());

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            string jsonResponse = await httpResponse.Content.ReadAsStringAsync();
            Console.WriteLine("API Response (Email Payment):");
            Console.WriteLine(jsonResponse);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to send money via email: {httpResponse.StatusCode}");
            }

            PayoutResponse response = JsonConvert.DeserializeObject<PayoutResponse>(jsonResponse);
            return response;
        }

    }
}
