using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapIntegration.Models
{
    public class RefundResult
    {
        public class Error
        {
            public string Message { get; set; }
            public int Code { get; set; }
        }

        public class Data
        {
            public string PaymentId { get; set; }
            public decimal RefundAmount { get; set; }
            public string StatusDescription { get; set; }
        }

        public bool Succeeded { get; set; }
        public Data RefundData { get; set; }
        public Error RefundError { get; set; }
    }
}
