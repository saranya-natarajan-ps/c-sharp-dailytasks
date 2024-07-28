using System;
using System.Data.SqlClient;
using System.IO;

namespace Dealership
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=Dealership;User Id=sa;Password=Password@123;";
            DatabaseHelper db = new DatabaseHelper(connectionString);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1 - List all available cars");
                Console.WriteLine("2 - List available cars with less than a specific odometer reading");
                Console.WriteLine("3 - List available cars with a specific make and model");
                Console.WriteLine("4 - List available cars between a specific price range");
                Console.WriteLine("5 - Sell a car");
                Console.WriteLine("6 - Change a car’s price");
                Console.WriteLine("7 - Delete a car from inventory");
                Console.WriteLine("8 - Quit");
                Console.Write("Select an option: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        db.ListAllAvailableCars();
                        break;
                    case 2:
                        Console.Write("Enter max odometer reading: ");
                        int maxOdometer = int.Parse(Console.ReadLine());
                        db.ListCarsByOdometer(maxOdometer);
                        break;
                    case 3:
                        Console.Write("Enter make: ");
                        string make = Console.ReadLine();
                        Console.Write("Enter model: ");
                        string model = Console.ReadLine();
                        db.ListCarsByMakeAndModel(make, model);
                        break;
                    case 4:
                        Console.Write("Enter minimum price: ");
                        decimal minPrice = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter maximum price: ");
                        decimal maxPrice = decimal.Parse(Console.ReadLine());
                        db.ListCarsByPriceRange(minPrice, maxPrice);
                        break;
                    case 5:
                        Console.Write("Enter inventory number of the car to sell: ");
                        string inventoryNumber = Console.ReadLine();
                        db.SellCar(inventoryNumber);
                        break;
                    case 6:
                        Console.Write("Enter inventory number of the car to change price: ");
                        inventoryNumber = Console.ReadLine();
                        Console.Write("Enter new price: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        db.ChangeCarPrice(inventoryNumber, newPrice);
                        break;
                    case 7:
                        Console.Write("Enter inventory number of the car to delete: ");
                        inventoryNumber = Console.ReadLine();
                        db.DeleteCar(inventoryNumber);
                        break;
                    case 8:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ListAllAvailableCars()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["inventory_number"]}, {reader["make"]} {reader["model"]}, {reader["year"]}, {reader["price"]}");
                }
            }
        }

        public void ListCarsByOdometer(int maxOdometer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available' AND odometer_reading <= @maxOdometer";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maxOdometer", maxOdometer);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["inventory_number"]}, {reader["make"]} {reader["model"]}, {reader["year"]}, {reader["price"]}");
                }
            }
        }

        public void ListCarsByMakeAndModel(string make, string model)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available' AND make = @make AND model = @model";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@make", make);
                cmd.Parameters.AddWithValue("@model", model);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["inventory_number"]}, {reader["make"]} {reader["model"]}, {reader["year"]}, {reader["price"]}");
                }
            }
        }

        public void ListCarsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Cars WHERE status = 'available' AND price BETWEEN @minPrice AND @maxPrice";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@minPrice", minPrice);
                cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["inventory_number"]}, {reader["make"]} {reader["model"]}, {reader["year"]}, {reader["price"]}");
                }
            }
        }

        public void SellCar(string inventoryNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string carQuery = "SELECT * FROM Cars WHERE inventory_number = @inventoryNumber";
                SqlCommand carCmd = new SqlCommand(carQuery, conn);
                carCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                SqlDataReader reader = carCmd.ExecuteReader();

                if (reader.Read())
                {
                    string carDetails = $"{reader["make"]} {reader["model"]}, {reader["year"]}, {reader["price"]}";
                    Console.WriteLine($"Car details: {carDetails}");
                    reader.Close();

                    Console.Write("Enter customer name: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter customer phone: ");
                    string customerPhone = Console.ReadLine();
                    Console.Write("Enter payment method: ");
                    string paymentMethod = Console.ReadLine();
                    Console.Write("Enter payment amount: ");
                    decimal paymentAmount = decimal.Parse(Console.ReadLine());

                    string salesQuery = "INSERT INTO Sales (inventory_number, sales_date, customer_name, customer_phone, payment_method, payment_amount) " +
                                        "VALUES (@inventoryNumber, @salesDate, @customerName, @customerPhone, @paymentMethod, @paymentAmount)";
                    SqlCommand salesCmd = new SqlCommand(salesQuery, conn);
                    salesCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                    salesCmd.Parameters.AddWithValue("@salesDate", DateTime.Now);
                    salesCmd.Parameters.AddWithValue("@customerName", customerName);
                    salesCmd.Parameters.AddWithValue("@customerPhone", customerPhone);
                    salesCmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                    salesCmd.Parameters.AddWithValue("@paymentAmount", paymentAmount);
                    salesCmd.ExecuteNonQuery();

                    string updateCarStatus = "UPDATE Cars SET status = 'sold' WHERE inventory_number = @inventoryNumber";
                    SqlCommand updateCarCmd = new SqlCommand(updateCarStatus, conn);
                    updateCarCmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                    updateCarCmd.ExecuteNonQuery();

                    Console.WriteLine("Car sold successfully!");

                    // Create receipt file
                    string receiptFile = $"{inventoryNumber}_receipt.txt";
                    using (StreamWriter sw = new StreamWriter(receiptFile))
                    {
                        sw.WriteLine("Receipt");
                        sw.WriteLine("-----------");
                        sw.WriteLine($"Car: {carDetails}");
                        sw.WriteLine($"Customer: {customerName}");
                        sw.WriteLine($"Phone: {customerPhone}");
                        sw.WriteLine($"Payment Method: {paymentMethod}");
                        sw.WriteLine($"Amount Paid: {paymentAmount}");
                        sw.WriteLine($"Date: {DateTime.Now}");
                    }
                    Console.WriteLine($"Receipt generated: {receiptFile}");
                }
                else
                {
                    Console.WriteLine("Car not found.");
                }
            }
        }

        public void ChangeCarPrice(string inventoryNumber, decimal newPrice)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "UPDATE Cars SET price = @newPrice WHERE inventory_number = @inventoryNumber AND status = 'available'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@newPrice", newPrice);
                cmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Car price updated successfully!");
                }
                else
                {
                    Console.WriteLine("Car not found or already sold.");
                }
            }
        }

        // Delete a car from inventory
        public void DeleteCar(string inventoryNumber)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Cars WHERE inventory_number = @inventoryNumber AND status = 'available'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@inventoryNumber", inventoryNumber);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Car deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Car not found or already sold.");
                }
            }
        }
    }
}
