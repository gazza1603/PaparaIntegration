using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class RefundRequest
    {
        public string PaymentId { get; set; }
        public decimal RefundAmount { get; set; }
    }
}
