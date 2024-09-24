using PetStore.BusinessLogic;

namespace PetStore
{
    internal class Program
    {
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
                Console.WriteLine("3. Get Product by Name");
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
                        ProductLogic.AddProductMenu();
                        break;

                    case "2":
                        ProductLogic.PrintProducts();
                        break;

                    case "3":
                        ProductLogic.GetProductByName();
                        break;
                }

            } while (userInput != "0");
        }

       

    }
}