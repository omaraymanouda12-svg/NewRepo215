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