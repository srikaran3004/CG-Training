using System;
using System.Collections.Generic;
using System.Text;

namespace FacadePattern
{ 
    public class FlavourService
    {
        public string GetFlavour() {
            Console.WriteLine("Getting a flavour...");
            return "Flavour";
        }
    }
}
