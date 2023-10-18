using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class CardPaymentResponse
    {
        public string TransactionId { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal FinalAmount { get; set; }
        public string Currency { get; set; }
        public int? Installment { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public ErrorDetails Error { get; set; }

        public class ErrorDetails
        {
            public string Message { get; set; }
            public int Code { get; set; }
        }
    }
}

