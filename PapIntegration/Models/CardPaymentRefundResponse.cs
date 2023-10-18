using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class CardPaymentRefundResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public decimal RefundedAmount { get; set; }
        public string RefundTransactionId { get; set; }
        public ErrorDetails Error { get; set; }
        public class ErrorDetails
        {
            public string Message { get; set; }
            public int Code { get; set; }
        }
    }
}
