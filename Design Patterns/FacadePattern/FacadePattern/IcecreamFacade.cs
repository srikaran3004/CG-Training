using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{
    public class IceCreamFacade
    {
        private FlavourService _flavourService;
        private ConeService _coneService;
        private PaymentService _paymentService;

        public IceCreamFacade()
        {
            _flavourService = new FlavourService();
            _coneService = new ConeService();
            _paymentService = new PaymentService();
        }

        public string GetIceCream()
        {
            Console.WriteLine("Mother is arranging the ice cream...");

            string flavour = _flavourService.GetFlavour();
            string cone = _coneService.GetCone();

            _paymentService.ProcessPayment();

            return flavour + " in a " + cone;
        }
    }
}
