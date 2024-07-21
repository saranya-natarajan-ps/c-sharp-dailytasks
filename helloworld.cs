using System;

namespace HelloWorldApplication {
   class HelloWorld {
      static void Main(string[] args) {
         /* my first program in C# */
         Console.WriteLine("Hello, Please enter your name:");
         string name;
         name = Console.ReadLine();
         Console.WriteLine("Hello " + name + "!");
      }
   }
}