using System;

class AddressDecypher
{
    static void Main()
    {
        // Define the encoded address
        string encodedAddress = "Betty Smallwood|3329 Duchess|Erath, Texas";

        // Split the encoded address using the pipe character
        string[] fields = encodedAddress.Split('|');

        // Check if the fields are properly split into 3 parts
        if (fields.Length != 3)
        {
            Console.WriteLine("The encoded address format is incorrect.");
            return;
        }

        // Extract the name, address, and city-state
        string name = fields[0];
        string address = fields[1];
        string cityState = fields[2];

        // Split the city and state using the comma
        string[] cityStateFields = cityState.Split(',');

        // Check if the city-state is properly split into 2 parts
        if (cityStateFields.Length != 2)
        {
            Console.WriteLine("The city-state format is incorrect.");
            return;
        }

        string city = cityStateFields[0].Trim();
        string state = cityStateFields[1].Trim();

        // Display the individual fields
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Address: {address}");
        Console.WriteLine($"City: {city}");
        Console.WriteLine($"State: {state}");
    }
}
