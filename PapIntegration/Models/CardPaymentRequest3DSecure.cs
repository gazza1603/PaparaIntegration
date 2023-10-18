using System;
using System.Collections.Generic;
using System.Text;

namespace PapIntegration.Models
{
    public class CardPaymentRequest3DSecure
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal FinalAmount { get; set; }
        public string Currency { get; set; }
        public int? Installment { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }
        public string ExpireMonth { get; set; }
        public string Cvv { get; set; }
        public string CardHolderName { get; set; }
        public string CustomerId { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerCity { get; set; }
        public string ClientIP { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerIdentityNumber { get; set; }
        public string CallbackUrl { get; set; }
    }
}
