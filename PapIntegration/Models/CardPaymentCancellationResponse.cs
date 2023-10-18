using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class CardPaymentCancellationResponse
    {
        public bool Success { get; set; }
        public string Description { get; set; }
        public ErrorDetails Error { get; set; }

        public class ErrorDetails
        {
            public string Message { get; set; }
            public int Code { get; set; }
        }
    }

}
