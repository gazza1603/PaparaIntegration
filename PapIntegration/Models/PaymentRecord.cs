using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class PaymentRecord
    {
        public decimal Amount { get; set; }
        public string ReferenceId { get; set; }
        public string OrderDescription { get; set; }
        public string NotificationUrl { get; set; }
        public string FailNotificationUrl { get; set; }
        public string RedirectUrl { get; set; }
        public long? TurkishNationalId { get; set; }
        public int? Currency { get; set; }
    }
}
