using PetStore.Model;
using PetStore.Utils;
using System.Text.Json;

namespace PetStore.BusinessLogic
{
    public static class ProductLogic
    {
        public static List<Product> Products = new List<Product>();

        #region Public

        public static void PrintProducts()
        {
            Console.WriteLine("***********************************");
            foreach (var product in Products)
            {
                PrintProduct(product);
            }
            Console.WriteLine("***********************************");
        }
        public static void GetProductByName()
        {
            string productName;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Get products by name");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("Please enter the product name");

                productName = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(productName))
                {
                    productName = "";
                    continue;
                }
                var results = Products
                    .Select(product => new
                    {
                        Product = product,
                        ScoreName = SemanticSearch.CalculateScore(product.Name, productName, SemanticAlgorithm.Ratio),
                        ScoreDescription = SemanticSearch.CalculateScore(product.Description, productName, SemanticAlgorithm.Ratio)
                    }).Where(x => x.ScoreName > 60 || x.ScoreDescription > 60)
                    .OrderByDescending(result => result.ScoreName).ThenBy(result => result.ScoreDescription)
                    .ToList();

                if (results.Count <= 0)
                    Console.WriteLine("No items match your search. Please try again.");
                else
                {
                    Console.WriteLine("The items that match your search.");
                    PrintProducts(results.Select(x => x.Product).ToList());
                }

            } while (productName != "0");
        }

        public static void AddProductMenu()
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
                        Console.WriteLine("***********************************");
                        PrintProduct(catFood);
                        Console.WriteLine("***********************************");
                        break;
                    case "2":
                        var dogLeash = AddProduct(new DogLeash());
                        Products.Add(dogLeash);
                        Console.WriteLine("***********************************");
                        PrintProduct(dogLeash);
                        Console.WriteLine("***********************************");
                        break;
                }
            } while (productInput != "0");
        }

        #endregion

        #region Private

        static Product AddProduct(Product product)
        {

            product.Name = Utilities.GetValidString(product is CatFood ? "Enter Cat Food Name:" : "Enter Dog Leash Name:");

            product.Price = Utilities.GetValidDecimal(product is CatFood ? "Enter Cat Food Price:" : "Enter Dog Leash Price:");

            product.Description = Utilities.GetValidString(product is CatFood ? "Enter Cat Food Description:" : "Enter Dog Leash Description:"); ;

            product.Quantity = Utilities.GetValidInt(product is CatFood ? "Enter Cat Food Quantity:" : "Enter Dog Leash Quantity:");

            if (product is CatFood food)
                AddDetail(food);
            else
                if (product is DogLeash leash)
                AddDetail(leash);

            return product;
        }

        static DogLeash AddDetail(DogLeash dogLeash)
        {
            dogLeash.LengthInches = Utilities.GetValidInt("Enter Dog Leash Length in Inches:");

            dogLeash.Material = Utilities.GetValidString("Enter Dog Leash Material:");

            return dogLeash;
        }

        static CatFood AddDetail(CatFood catFood)
        {
            catFood.WeightPounds = Utilities.GetValidDecimal("Enter Cat Food Weight in Pounds:"); ;

            catFood.KittenFood = Utilities.GetValidBool("Is it Kitten Food? (true/false):");

            return catFood;
        }

        static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("***********************************");
            foreach (var product in products)
            {
                PrintProduct(product);
            }
            Console.WriteLine("***********************************");
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

        #endregion

    }
}
