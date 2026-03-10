using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class PaymentService
    {
        public string ProcessPayment() {
            Console.WriteLine("Processing payment...");
            return "Payment processed";
        }
    }
}
