//Services/ApiService.cs
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PapIntegration.Models;

public class ApiService
{
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public ApiService(string baseUrl, string apiKey)
    {
        _baseUrl = baseUrl;
        _apiKey = apiKey;
    }

    private HttpClient CreateHttpClient()
    {
        var client = new HttpClient();
        client.BaseAddress = new System.Uri(_baseUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("ApiKey", _apiKey);

        return client;
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        using (var client = CreateHttpClient())
        {
            try
            {
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"An error occurred while calling the API: {e.Message}");
            }
        }
    }
    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        using (var client = CreateHttpClient())
        {
            try
            {
                var jsonData = JsonConvert.SerializeObject(data);
                var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(responseBody);
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"An error occurred while calling the API: {e.Message}");
            }
        }
    }

    public async Task<TResponse> CreatePaymentRecordAsync<TResponse>(PaymentRecord paymentRecord)
    {
        return await PostAsync<PaymentRecord, TResponse>("/payments", paymentRecord);
    }

    public async Task<TResponse> RefundPaymentAsync<TResponse>(RefundRequest refundRequest)
    {
        return await PostAsync<RefundRequest, TResponse>("/payments/refund", refundRequest);
    }
}