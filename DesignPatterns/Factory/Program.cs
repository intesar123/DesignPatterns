using System;

namespace Factory
{
    // This is a simple implementation of the Factory design pattern in C#.

    // The Factory pattern is a creational design pattern that provides an interface for creating objects in a superclass,
    // but allows subclasses to alter the type of objects that will be created.
    // It is used to encapsulate the object creation process and promote loose coupling between classes.
    // Example : Ecommerce application where different types of products (e.g., Electronics, Clothing, Books) can be created using a factory method.

    public interface IProduct
    {
        void DisplayInfo();
    }

    public class ProductA : IProduct
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is Product A.");
        }
    }

    public class ProductB : IProduct
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is Product B.");
        }
    }

    public static class ProductFactory
    {
        public static IProduct CreateProduct(string productType)
        {
            return productType switch
            {
                "A" => new ProductA(),
                "B" => new ProductB(),
                _ => throw new ArgumentException("Invalid product type")
            };
        }
    }

    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            // Create Product A
            IProduct productA = ProductFactory.CreateProduct("A");
            productA.DisplayInfo();

            // Create Product B
            IProduct productB = ProductFactory.CreateProduct("B");
            productB.DisplayInfo();
        }
    }
}
