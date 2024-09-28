using Spectre.Console;

namespace CoffeShop.PointOfSale.EntityFramework
{
    internal class ProductService
    {
        internal static void InsertProduct()
        {
            var name = AnsiConsole.Ask<string>("Enter the product name");
            ProductController.AddProduct(name);
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
            var name = AnsiConsole.Ask<string>("Enter the new product name");
            product.Name = name;
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
            var id = products.Single(x => x.Name == option).Id;
            var product = ProductController.GetProductById(id);

            return product;

        }


    }
}
