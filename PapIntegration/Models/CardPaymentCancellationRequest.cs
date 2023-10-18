using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class CardPaymentCancellationRequest
    {
        public string OrderId { get; set; }
        public string ClientIP { get; set; }
    }

}
