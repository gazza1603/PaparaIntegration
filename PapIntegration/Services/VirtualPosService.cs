using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PapIntegration.Models;

namespace PapIntegration.Services
{
    public class VirtualPosService
    {
        private readonly string _apiBaseUrl;
        private readonly string _apiUrl = "v1/vpos/sale";
        private readonly string _secure3DUrl = "v1/vpos/3dsecure";
        private readonly string _cancelUrl = "v1/vpos/cancel";
        private readonly string _refundlUrl = "v1/vpos/refund";
        private readonly HttpClient _httpClient;

        public VirtualPosService(string apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpClient = new HttpClient { BaseAddress = new Uri(_apiBaseUrl) };
        }

        public async Task<CardPaymentResponse> ProcessPaymentAsync(CardPaymentRequest request, string apiKey)
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _apiUrl);
            requestMessage.Headers.Add("ApiKey", apiKey);
            requestMessage.Content = httpContent;

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to process payment: {httpResponse.StatusCode}");
            }

            CardPaymentResponse response = JsonConvert.DeserializeObject<CardPaymentResponse>(jsonResponse);
            return response;
        }


        public async Task<CardPaymentResponse> Process3DSecurePaymentAsync(CardPaymentRequest3DSecure request, string apiKey)
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _secure3DUrl);
            requestMessage.Headers.Add("ApiKey", apiKey);
            requestMessage.Content = httpContent;

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to process 3D Secure payment: {httpResponse.StatusCode}");
            }

            CardPaymentResponse response = JsonConvert.DeserializeObject<CardPaymentResponse>(jsonResponse);
            return response;
        }
        public async Task<CardPaymentCancellationResponse> CancelPaymentAsync(CardPaymentCancellationRequest request, string apiKey)
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _cancelUrl);
            requestMessage.Headers.Add("ApiKey", apiKey);
            requestMessage.Content = httpContent;

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to cancel payment: {httpResponse.StatusCode}");
            }

            CardPaymentCancellationResponse response = JsonConvert.DeserializeObject<CardPaymentCancellationResponse>(jsonResponse);
            return response;
        }

        public async Task<CardPaymentRefundResponse> RefundCardPaymentAsync(CardPaymentRefundRequest request, string apiKey)
        {
            string jsonRequest = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _refundlUrl);
            requestMessage.Headers.Add("ApiKey", apiKey);
            requestMessage.Content = httpContent;

            var httpResponse = await _httpClient.SendAsync(requestMessage);

            string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to refund payment: {httpResponse.StatusCode}");
            }

            CardPaymentRefundResponse response = JsonConvert.DeserializeObject<CardPaymentRefundResponse>(jsonResponse);
            return response;


        }
    }
}
