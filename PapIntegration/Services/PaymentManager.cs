//For handling refund
using System;
using System.Threading.Tasks;
using PapIntegration.Models;

public class PaymentManager
{
    private readonly ApiService _apiService;

    public PaymentManager(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task HandleRefundAsync(string paymentId, decimal amount)
    {
        var refundRequest = new RefundRequest
        {
            PaymentId = paymentId,
            RefundAmount = amount
        };

        var refundResponse = await _apiService.RefundPaymentAsync<RefundResult>(refundRequest);

        if (refundResponse?.Succeeded == true)
        {
            Console.WriteLine($"Refund successful! Refunded amount: {(refundResponse.RefundData?.RefundAmount != null ? refundResponse.RefundData.RefundAmount.ToString() : "Not Available")}");
        }
        else
        {
            Console.WriteLine($"Refund failed! Error: {refundResponse?.RefundError?.Message ?? "Unknown Error"}");
        }
    }
}
