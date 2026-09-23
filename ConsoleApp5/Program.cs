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

public struct DeliveryAddress
{
    private string street;
    private string city;

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }
}


public class Shipment
{
    private string trackingCode;
    private DeliveryAddress address;

    public string TrackingCode
    {
        get { return trackingCode; }
        set { trackingCode = value; }
    }

    public DeliveryAddress Address
    {
        get { return address; }
        set { address = value; }
    }
}


public class DeliveryCenter
{
    private string centerName;
    private DeliveryAddress location;

    public string CenterName
    {
        get { return centerName; }
        set { centerName = value; }
    }

    public DeliveryAddress Location
    {
        get { return location; }
        set { location = value; }
    }
}



//Question 3 ANSWER




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

       
        public decimal EstimatedCost
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

      
        public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight}");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Destination: {Destination.City}, {Destination.Street}");
        }
    }

   
    public class DeliveryCenter
    {
        public string CenterName { get; set; }
        public DeliveryAddress Location { get; set; }

        public DeliveryCenter()
        {
        }

        public DeliveryCenter(string centerName, DeliveryAddress location)
        {
            CenterName = centerName;
            Location = location;
        }

        public void PrintCenter()
        {
            Console.WriteLine($"Center Name: {CenterName}");
            Console.WriteLine($"Location: {Location.City}, {Location.Street}");
        }
    }
}

//Question 4 ANSWER
