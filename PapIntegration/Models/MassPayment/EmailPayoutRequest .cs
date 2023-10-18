using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models.MassPayment
{
    public class EmailPayoutRequest
    {
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public string MassPaymentId { get; set; }
        public long TurkishNationalId { get; set; }
        public int Currency { get; set; }
    }
}

