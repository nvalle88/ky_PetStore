using System;
using System.ComponentModel;
using System.Text.Json;
using PetStore.Model;

namespace PetStore
{
    internal class Program
    {
        public static List<Product> Products = new List<Product>();

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Pet Store!");
            string userInput;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("2. List of product");
                Console.WriteLine("0. Exit");

                userInput = Console.ReadLine()!;

                if (userInput == null)
                {
                    userInput = "";
                    continue;
                }

                switch (userInput)
                {
                    case "1":
                        AddProductMenu();
                        break;

                    case "2":
                        PrintProducts();
                        break;
                }

            } while (userInput != "0");
        }

        static void AddProductMenu()
        {
            string productInput;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What type of product would you like to add?");
                Console.WriteLine("1. Add Cat Food");
                Console.WriteLine("2. Add Dog Leash");
                Console.WriteLine("0. Return to main menu");

                productInput = Console.ReadLine()!;

                if (productInput == null)
                {
                    productInput = "";
                    continue;
                }

                switch (productInput)
                {
                    case "1":
                        var catFood = AddProduct(new CatFood());
                        Products.Add(catFood);
                        PrintProduct(catFood);
                        string catFoodJson = JsonSerializer.Serialize(catFood);
                        Console.WriteLine(catFoodJson);
                        break;
                    case "2":
                        var dogLeash = AddProduct(new DogLeash());
                        Products.Add(dogLeash);
                        PrintProduct(dogLeash);
                        string dogLeashJson = JsonSerializer.Serialize(dogLeash);
                        Console.WriteLine(dogLeashJson);
                        break;
                }
            } while (productInput != "0");
        }


        static Product AddProduct(Product product)
        {

            Console.WriteLine(product is CatFood ? "Enter Cat Food Name:" : "Enter Dog Leash Name:");
            product.Name = Console.ReadLine()!;

            Console.WriteLine(product is CatFood ? "Enter Cat Food Price:" : "Enter Dog Leash Price:");
            product.Price = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine(product is CatFood ? "Enter Cat Food Description:" : "Enter Dog Leash Description:");
            product.Description = Console.ReadLine();

            Console.WriteLine(product is CatFood ? "Enter Cat Food Quantity:" : "Enter Dog Leash Quantity:");
            product.Quantity = int.Parse(Console.ReadLine()!);

            if (product is CatFood food)
                AddDetail(food);
            else
                if (product is DogLeash leash)
                AddDetail(leash);

            return product;
        }

        static DogLeash AddDetail(DogLeash dogLeash)
        {
            Console.WriteLine("Enter Dog Leash Length in Inches:");
            dogLeash.LengthInches = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter Dog Leash Material:");
            dogLeash.Material = Console.ReadLine();

            return dogLeash;
        }

        static CatFood AddDetail(CatFood catFood)
        {
            Console.WriteLine("Enter Cat Food Weight in Pounds:");
            catFood.WeightPounds = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Is it Kitten Food? (true/false):");
            catFood.KittenFood = bool.Parse(Console.ReadLine()!);

            return catFood;
        }

        static void PrintProducts()
        {
            foreach (var product in Products)
                PrintProduct(product);
        }
        static void PrintProduct(Product product)
        {
            Console.WriteLine($"----------------");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: {product.Price}");

            if (product is CatFood catFood)
            {
                Console.WriteLine("Type: Cat Food");
                Console.WriteLine($"Weight in Pounds: {catFood.WeightPounds}");
                Console.WriteLine($"Kitten Food: {catFood.KittenFood}");
            }
            else if (product is DogLeash dogLeash)
            {
                Console.WriteLine("Type: Dog Leash");
                Console.WriteLine($"Length in Inches: {dogLeash.LengthInches}");
                Console.WriteLine($"Material: {dogLeash.Material}");
            }
            Console.WriteLine($"----------------");
        }

    }
}