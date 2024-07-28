using System;
using System.Data.SqlClient;

namespace NorthwindGrocery_ConsoleApp
{
    class Program
    {
        static string connectionString = "Server=localhost;Database=demo;User Id=sa;Password=Password@123;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - List all categories");
                Console.WriteLine("2 - List products in a specific category");
                Console.WriteLine("3 - List products in a price range");
                Console.WriteLine("4 - List all suppliers");
                Console.WriteLine("5 - List products from a specific supplier");
                Console.WriteLine("6 - Quit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ListAllCategories();
                        break;
                    case 2:
                        ListProductsInCategory();
                        break;
                    case 3:
                        ListProductsInPriceRange();
                        break;
                    case 4:
                        ListAllSuppliers();
                        break;
                    case 5:
                        ListProductsFromSupplier();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void ListAllCategories()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT CategoryID, CategoryName FROM Categories";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Categories:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CategoryID"]}: {reader["CategoryName"]}");
                }
                reader.Close();
            }
        }

        static void ListProductsInCategory()
        {
            Console.Write("Enter the category name: ");
            string categoryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT p.ProductID, p.ProductName, p.UnitPrice FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID WHERE c.CategoryName = @CategoryName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"Products in category {categoryName}:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"]}: {reader["ProductName"]} - {reader["UnitPrice"]:C}");
                }
                reader.Close();
            }
        }

        static void ListProductsInPriceRange()
        {
            Console.Write("Enter the minimum price: ");
            decimal minPrice = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the maximum price: ");
            decimal maxPrice = decimal.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ProductID, ProductName, UnitPrice FROM Products WHERE UnitPrice BETWEEN @MinPrice AND @MaxPrice";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MinPrice", minPrice);
                command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"Products priced between {minPrice:C} and {maxPrice:C}:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"]}: {reader["ProductName"]} - {reader["UnitPrice"]:C}");
                }
                reader.Close();
            }
        }

        static void ListAllSuppliers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT SupplierID, CompanyName FROM Suppliers";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Suppliers:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["SupplierID"]}: {reader["CompanyName"]}");
                }
                reader.Close();
            }
        }

        static void ListProductsFromSupplier()
        {
            Console.Write("Enter the supplier ID: ");
            int supplierID = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT p.ProductID, p.ProductName, p.UnitPrice FROM Products p JOIN Suppliers s ON p.SupplierID = s.SupplierID WHERE s.SupplierID = @SupplierID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SupplierID", supplierID);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine($"Products from supplier {supplierID}:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ProductID"]}: {reader["ProductName"]} - {reader["UnitPrice"]:C}");
                }
                reader.Close();
            }
        }
    }
}
