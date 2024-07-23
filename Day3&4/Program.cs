using System;
using System.Collections.Generic;

namespace PetStore
{
    class Program
    {
        static void Main(string[] args)
        {
            List<InventoryItem> inventory = new List<InventoryItem>();

            // Manually add items to the inventory
            inventory.Add(new FoodItem(1, "Dog Food", "High-quality dry dog food", 15.49m, 50, "BrandA", FoodType.Dry, "Dog"));
            inventory.Add(new AccessoryItem(2, "Cat Collar", "Cat collar with bell", 5.99m, 20, "Small", "Blue"));
            inventory.Add(new CageItem(3, "Parrot Cage", "Large parrot cage with toys", 120.00m, 5, "24x24x36", "Wire"));
            inventory.Add(new AquariumItem(4, "50-gallon Fish Tank", "50-gallon fish tank with stand", 200.00m, 3, 50, "Rectangle"));
            inventory.Add(new ToyItem(5, "Hedgehog Wheel", "Exercise wheel for hedgehogs", 12.49m, 8, "Plastic", "6 months+"));

            // Additional items can be added similarly

            DisplayMenu(inventory);
        }

        static void DisplayMenu(List<InventoryItem> inventory)
        {
            bool continueMenu = true;
            while (continueMenu)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Show all items");
                Console.WriteLine("2. Show an item's details");
                Console.WriteLine("3. Purchase an item");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllItems(inventory);
                        break;

                    case "2":
                        ShowItemDetails(inventory);
                        break;

                    case "3":
                        PurchaseItem(inventory);
                        break;

                    case "4":
                        continueMenu = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        static void ShowAllItems(List<InventoryItem> inventory)
        {
            Console.WriteLine("\nAll Items:");
            foreach (var item in inventory)
            {
                Console.WriteLine($"ID: {item.Id}, Name: {item.Name}, Type: {item.GetType().Name}");
            }
        }

        static void ShowItemDetails(List<InventoryItem> inventory)
        {
            Console.Write("Enter the item ID to view details: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = inventory.Find(i => i.Id == id);
                if (item != null)
                {
                    item.DisplayDetails();
                }
                else
                {
                    Console.WriteLine($"Item with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
            }
        }

        static void PurchaseItem(List<InventoryItem> inventory)
        {
            Console.Write("Enter the item ID to purchase: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var item = inventory.Find(i => i.Id == id);
                if (item != null)
                {
                    if (item.Quantity > 0)
                    {
                        item.Quantity--;
                        Console.WriteLine($"Purchased {item.Name}. Amount due: {item.Price:C}. Remaining quantity: {item.Quantity}");
                    }
                    else
                    {
                        Console.WriteLine("Item is out of stock.");
                    }
                }
                else
                {
                    Console.WriteLine($"Item with ID {id} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid number.");
            }
        }
    }
}
