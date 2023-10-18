using System;
using System.Collections.Generic;

namespace PapIntegration.Models
{
    public class PaymentResult
    {
        public PaymentData Data { get; set; }
        public bool Succeeded { get; set; }
        public PaymentError Error { get; set; }
    }

    public class PaymentData
    {
        public Merchant Merchant { get; set; }
        public string UserId { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentMethodDescription { get; set; }
        public string ReferenceId { get; set; }
        public string OrderDescription { get; set; }
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public int Currency { get; set; }
        public string NotificationUrl { get; set; }
        public bool NotificationDone { get; set; }
        public string RedirectUrl { get; set; }
        public string PaymentUrl { get; set; }
        public string MerchantSecretKey { get; set; }
        public string ReturningRedirectUrl { get; set; }
        public long? TurkishNationalId { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Merchant
    {
        public string LegalName { get; set; }
        public string BrandName { get; set; }
        public List<AllowedPaymentType> AllowedPaymentTypes { get; set; }
        public List<Balance> Balances { get; set; }
    }

    public class AllowedPaymentType
    {
        public int PaymentMethod { get; set; }
    }

    public class Balance
    {
        public int Currency { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal LockedBalance { get; set; }
        public decimal AvailableBalance { get; set; }
    }

    public class PaymentError
    {
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
