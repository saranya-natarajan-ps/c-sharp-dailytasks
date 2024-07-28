using System;

namespace Delegate_Logger
{
    // Define a delegate type that can reference any method with one string parameter and void return type
    delegate void LoggingOperation(string message);

    class Logger
    {
        // Method to log an info message
        public void Info(string message)
        {
            Console.WriteLine("[INFO] " + message);
        }

        // Method to log a warning message
        public void Warning(string message)
        {
            Console.WriteLine("[WARNING] " + message);
        }

        // Method to log an error message
        public void Error(string message)
        {
            Console.WriteLine("[ERROR] " + message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            // Create delegate instances and use them to call the log methods
            LoggingOperation logOp;

            // Info operation
            logOp = new LoggingOperation(logger.Info);
            logOp("This is an informational message.");

            // Warning operation
            logOp = new LoggingOperation(logger.Warning);
            logOp("This is a warning message.");

            // Error operation
            logOp = new LoggingOperation(logger.Error);
            logOp("This is an error message.");

            // Anonymous method for alert operation
            logOp = delegate (string message)
            {
                Console.WriteLine("[ALERT] " + message);
            };
            logOp("This is an alert message.");
        }
    }
}