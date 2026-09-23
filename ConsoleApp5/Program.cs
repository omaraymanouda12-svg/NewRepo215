//Question 1
//Answer the following questions:
//a) What is the difference between a class and a struct?
//b) Why are classes more suitable than structs for large applications?

//A => Memory/Type: A class is a reference type (stored on the heap), while a struct is a value type (stored on the stack.

//Default Visibility(C++): Struct members are public by default, whereas class members are private by default.

// B => Performance & Copying: Classes use reference semantics, avoiding the heavy performance cost of copying large blocks of data that structs (value types) incur.

//Object - Oriented Features: Classes fully support inheritance, polymorphism, and complex hierarchies, which are essential for scalable, maintainable architectures.

//Question 1 ANSWER


//Question 

//a) The parent class is Shipment.   


//b) The child class is ExpressShipment.


//c) The member inherited by ExpressShipment is TrackingCode.   


//d) Inheritance is better because it avoids code duplication, promotes code reusability, and makes maintenance and updates easier.




//Question 2 ANSWER



using System;

namespace SmartDeliveryManagement
{
    public struct DeliveryAddress
    {
        public string Street { get; set; }
        public string City { get; set; }

        public DeliveryAddress(string street, string city)
        {
            Street = street;
            City = city;
        }
    }

    public class Shipment
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal DeliveryFee { get; set; }
        public DeliveryAddress Destination { get; set; }

        public virtual decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5); }
        }

        public Shipment()
        {
        }

        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            DeliveryFee = newFee;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Destination: {Destination.City}, {Destination.Street}");
        }
    }

    public class StandardShipment : Shipment
    {
        public StandardShipment() : base()
        {
        }

        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
    }

    public class ExpressShipment : Shipment
    {
        private decimal extraFee;
        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value < 0)
                    extraFee = 0;
                else
                    extraFee = value;
            }
        }

        public override decimal EstimatedCost
        {
            get { return base.EstimatedCost + ExtraFee; }
        }

        public ExpressShipment() : base()
        {
        }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"Extra Fee: {ExtraFee}");
        }
    }

    public class InternationalShipment : Shipment
    {
        private string destinationCountry;
        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    destinationCountry = "Unknown";
                else
                    destinationCountry = value;
            }
        }

        private decimal customsFee;
        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value < 0)
                    customsFee = 0;
                else
                    customsFee = value;
            }
        }

        public override decimal EstimatedCost
        {
            get { return base.EstimatedCost + CustomsFee; }
        }

        public InternationalShipment() : base()
        {
        }

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee}");
        }
    }

    public class DeliveryCenter
    {
        public string CenterName { get; set; }

        private Shipment[] shipments = new Shipment[20];
        private int shipmentCount = 0;

        public Shipment[] Shipments
        {
            get { return shipments; }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipmentCount; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                    {
                        return shipments[i];
                    }
                }
                return null;
            }
        }

        public DeliveryCenter()
        {
        }

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }

        public bool AddShipment(Shipment shipment)
        {
            if (shipmentCount < 20)
            {
                shipments[shipmentCount] = shipment;
                shipmentCount++;
                return true;
            }
            return false;
        }

        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipmentCount; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    for (int j = i; j < shipmentCount - 1; j++)
                    {
                        shipments[j] = shipments[j + 1];
                    }
                    shipments[shipmentCount - 1] = null;
                    shipmentCount--;
                    return true;
                }
            }
            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine($"--- Shipments in Delivery Center: {CenterName} ---");
            for (int i = 0; i < shipmentCount; i++)
            {
                if (shipments[i] != null)
                {
                    shipments[i].PrintShipment();
                    Console.WriteLine("--------------------------");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Delivery Center Name: ");
            string centerName = Console.ReadLine();
            DeliveryCenter center = new DeliveryCenter(centerName);

            Console.WriteLine("\n--- Enter Standard Shipment Details ---");
            StandardShipment stdShipment = new StandardShipment();
            Console.Write("Tracking Code: ");
            stdShipment.TrackingCode = Console.ReadLine();
            Console.Write("Description: ");
            stdShipment.Description = Console.ReadLine();
            Console.Write("Weight: ");
            stdShipment.Weight = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            stdShipment.DeliveryFee = decimal.Parse(Console.ReadLine());
            Console.Write("City: ");
            string stdCity = Console.ReadLine();
            Console.Write("Street: ");
            string stdStreet = Console.ReadLine();
            stdShipment.Destination = new DeliveryAddress(stdStreet, stdCity);
            center.AddShipment(stdShipment);

            Console.WriteLine("\n--- Enter Express Shipment Details ---");
            ExpressShipment expShipment = new ExpressShipment();
            Console.Write("Tracking Code: ");
            expShipment.TrackingCode = Console.ReadLine();
            Console.Write("Description: ");
            expShipment.Description = Console.ReadLine();
            Console.Write("Weight: ");
            expShipment.Weight = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            expShipment.DeliveryFee = decimal.Parse(Console.ReadLine());
            Console.Write("Extra Fee: ");
            expShipment.ExtraFee = decimal.Parse(Console.ReadLine());
            Console.Write("City: ");
            string expCity = Console.ReadLine();
            Console.Write("Street: ");
            string expStreet = Console.ReadLine();
            expShipment.Destination = new DeliveryAddress(expStreet, expCity);
            center.AddShipment(expShipment);

            Console.WriteLine("\n--- Enter International Shipment Details ---");
            InternationalShipment intShipment = new InternationalShipment();
            Console.Write("Tracking Code: ");
            intShipment.TrackingCode = Console.ReadLine();
            Console.Write("Description: ");
            intShipment.Description = Console.ReadLine();
            Console.Write("Weight: ");
            intShipment.Weight = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            intShipment.DeliveryFee = decimal.Parse(Console.ReadLine());
            Console.Write("Destination Country: ");
            intShipment.DestinationCountry = Console.ReadLine();
            Console.Write("Customs Fee: ");
            intShipment.CustomsFee = decimal.Parse(Console.ReadLine());
            Console.Write("City: ");
            string intCity = Console.ReadLine();
            Console.Write("Street: ");
            string intStreet = Console.ReadLine();
            intShipment.Destination = new DeliveryAddress(intStreet, intCity);
            center.AddShipment(intShipment);

            Console.WriteLine("\n================================");
            center.PrintAllShipments();

            Console.Write("\nEnter Tracking Code to Search: ");
            string searchCode = Console.ReadLine();
            Shipment foundShipment = center[searchCode];
            if (foundShipment != null)
            {
                Console.WriteLine("\nShipment Found Successfully!");
                foundShipment.PrintShipment();
            }
            else
            {
                Console.WriteLine("\nShipment not found!");
            }

            Console.Write("\nEnter Tracking Code of Shipment to Remove: ");
            string removeCode = Console.ReadLine();
            bool removed = center.RemoveShipment(removeCode);
            if (removed)
            {
                Console.WriteLine("\nShipment removed successfully!");
            }
            else
            {
                Console.WriteLine("\nShipment could not be found for removal.");
            }

            Console.WriteLine("\n================================");
            Console.WriteLine("Remaining Shipments:");
            center.PrintAllShipments();
        }
    }
}
//ALL ANSSWER OF QUESTIONS ARE IN THE CODE ABOVE.

