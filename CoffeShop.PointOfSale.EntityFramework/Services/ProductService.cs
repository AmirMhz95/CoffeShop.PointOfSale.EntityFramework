using CoffeShop.PointOfSale.EntityFramework.Controllers;
using CoffeShop.PointOfSale.EntityFramework.Models;
using Spectre.Console;

namespace CoffeShop.PointOfSale.EntityFramework.Services
{
    internal class ProductService
    {
        internal static void InsertProduct()
        {
            var product = new Product();
            product.Name = AnsiConsole.Ask<string>("Enter the product name");
            product.Price = AnsiConsole.Ask<decimal>("Enter the product price");
            product.CategoryID = CategoryService.GetCategoryOptionInput();

            ProductController.AddProduct(product);
        }


        internal static void DeleteProduct()
        {
            var product = GetProdcutOptionInput();
            ProductController.DeleteProduct(product);
        }

        internal static void GetProducts()
        {
            var products = ProductController.GetProducts();
            UserInterface.ShowProductTable(products);
        }

        internal static void GetProduct()
        {
            var product = GetProdcutOptionInput();
            UserInterface.ShowProduct(product);
        }

        internal static void UpdateProduct()
        {
            var product = GetProdcutOptionInput();
            product.Name = AnsiConsole.Confirm("Do you want to update the product name")
                ? AnsiConsole.Ask<string>("Enter the new product name")
                : product.Name;

            product.Price = AnsiConsole.Confirm("Do you want to update the product price")
                ? AnsiConsole.Ask<decimal>("Enter the new product price")
                : product.Price;

            ProductController.UpdateProduct(product);
        }



        static private Product GetProdcutOptionInput()
        {
            var products = ProductController.GetProducts();
            var productsArray = products.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a product")
                .AddChoices(productsArray)
            );
            var id = products.Single(x => x.Name == option).ProductId;
            var product = ProductController.GetProductById(id);

            return product;

        }


    }
}
