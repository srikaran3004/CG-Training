namespace LogisticsProShipmentSystem
{
    public class Shipment
    {
        public string ShipmentCode { get; set; } = "";
        public string TransportMode { get; set; } = "";
        public double Weight { get; set; }
        public int StorageDays { get; set; }
    }

    public class ShipmentDetails : Shipment
    {
        public static bool ValidateShipmentCode(Shipment shipment)
        {
            if (shipment.ShipmentCode == null || shipment.ShipmentCode.Length != 7)
                return false;
            if (!shipment.ShipmentCode.StartsWith("GC#"))
                return false;
            string remainingPart = shipment.ShipmentCode.Substring(3);
            foreach (char c in remainingPart)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }
        public static double CalculateTotalCost(Shipment shipment)
        {
            double ratePerKg = 0;
            switch (shipment.TransportMode)
            {
                case "Sea":
                    ratePerKg = 15.00;
                    break;
                case "Air":
                    ratePerKg = 50.00;
                    break;
                case "Land":
                    ratePerKg = 25.00;
                    break;
                default:
                    ratePerKg = 0.00;
                    break;
            }
            double cost = (shipment.Weight * ratePerKg) + Math.Sqrt(shipment.StorageDays);
            return Math.Round(cost, 2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shipment shipment = new Shipment();
            Console.Write("Please Enter Shipment Code: ");
            shipment.ShipmentCode = Console.ReadLine()!;
            if (!ShipmentDetails.ValidateShipmentCode(shipment))
            {
                Console.WriteLine("Invalid Shipment Code");
                return;
            }
            Console.Write("Please Enter TransportMode: ");
            shipment.TransportMode = Console.ReadLine()!;
            Console.Write("Please Enter Shipment Weight: ");
            shipment.Weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Please Enter No.of Storage Days: ");
            shipment.StorageDays = Convert.ToInt32(Console.ReadLine());
            double total = ShipmentDetails.CalculateTotalCost(shipment);
            Console.WriteLine($"The total shipping cost is {total:F2}");
        }
    }
}