using System;
using System.Collections.Generic;
using System.IO;

namespace PetStore
{
    // Base class for inventory items
    abstract class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public InventoryItem(int id, string name, string description, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public abstract void DisplayDetails();
    }

    // Derived classes for specific item types
    class FoodItem : InventoryItem
    {
        public string Brand { get; set; }
        public FoodType FoodType { get; set; }
        public string AnimalType { get; set; }

        public FoodItem(int id, string name, string description, decimal price, int quantity, string brand, FoodType foodType, string animalType)
            : base(id, name, description, price, quantity)
        {
            Brand = brand;
            FoodType = foodType;
            AnimalType = animalType;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}, Brand: {Brand}, Food Type: {FoodType}, Animal Type: {AnimalType}");
        }
    }

    class AccessoryItem : InventoryItem
    {
        public string Size { get; set; }
        public string Color { get; set; }

        public AccessoryItem(int id, string name, string description, decimal price, int quantity, string size, string color)
            : base(id, name, description, price, quantity)
        {
            Size = size;
            Color = color;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}, Size: {Size}, Color: {Color}");
        }
    }

    class CageItem : InventoryItem
    {
        public string Dimensions { get; set; }
        public string Material { get; set; }

        public CageItem(int id, string name, string description, decimal price, int quantity, string dimensions, string material)
            : base(id, name, description, price, quantity)
        {
            Dimensions = dimensions;
            Material = material;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}, Dimensions: {Dimensions}, Material: {Material}");
        }
    }

    class AquariumItem : InventoryItem
    {
        public int Capacity { get; set; }
        public string Shape { get; set; }

        public AquariumItem(int id, string name, string description, decimal price, int quantity, int capacity, string shape)
            : base(id, name, description, price, quantity)
        {
            Capacity = capacity;
            Shape = shape;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}, Capacity: {Capacity}, Shape: {Shape}");
        }
    }

    class ToyItem : InventoryItem
    {
        public string Material { get; set; }
        public string RecommendedAge { get; set; }

        public ToyItem(int id, string name, string description, decimal price, int quantity, string material, string recommendedAge)
            : base(id, name, description, price, quantity)
        {
            Material = material;
            RecommendedAge = recommendedAge;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Description: {Description}, Price: {Price:C}, Quantity: {Quantity}, Material: {Material}, Recommended Age: {RecommendedAge}");
        }
    }

    // Enum for food types
    enum FoodType
    {
        Dry,
        Wet
    }
}
