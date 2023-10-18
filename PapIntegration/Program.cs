//Exampl usage
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapIntegration.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace PapIntegration
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Load configuration from config.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");
            var configuration = builder.Build();

            // Extract values from config.json
            var baseUrl = configuration["ApiBase"];
            var apiKey = configuration["ApiKey"];
            //Console.WriteLine(baseUrl);

            // initialize the service
            var apiService = new ApiService(baseUrl, apiKey);
            Console.WriteLine(apiService);
            // Create a test payment record
            var paymentRecord = new PaymentRecord
            {
                Amount = 99.99m,
                ReferenceId = "TestReference123",
                OrderDescription = "Test Payment",
                NotificationUrl = "https://www.papara.com/notification",
                FailNotificationUrl = "https://wwww.papara.com/fail-notification",
                RedirectUrl = "https://www.papara.com/userredirect",
                TurkishNationalId = 12345678901,
                Currency = 0
            };

            // Send the payment request
            var response = await apiService.CreatePaymentRecordAsync<PaymentResult>(paymentRecord);
            string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(jsonResponse);
            if (response.Succeeded)
            {
                Console.WriteLine($"Payment succeeded! Transaction ID: {response.Data.Id}");
                Console.WriteLine("pass");
            }
            else
            {
                Console.WriteLine($"Payment failed! Error: {response.Error.Message}");
                Console.WriteLine("failed");
            }
        }
    }
}
