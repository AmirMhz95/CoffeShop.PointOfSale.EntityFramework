using CoffeShop.PointOfSale.EntityFramework.Models;
using CoffeShop.PointOfSale.EntityFramework.Services;
using Spectre.Console;
using static CoffeShop.PointOfSale.EntityFramework.Enums;

namespace CoffeShop.PointOfSale.EntityFramework
{
    static internal class UserInterface
    {
        internal static void MainMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                Console.Clear();

                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                    MenuOptions.AddCategory,
                    MenuOptions.ViewlAllCategories,
                    MenuOptions.AddProduct,
                    MenuOptions.DeleteProduct,
                    MenuOptions.UpdateProduct,
                    MenuOptions.ViewProduct,
                    MenuOptions.ViewAllProduct,
                    MenuOptions.Quit
                    ));

                switch (option)
                {

                    case MenuOptions.AddCategory:
                        CategoryService.InsertCategory();
                        break;
                    case MenuOptions.ViewlAllCategories:
                        CategoryService.GetCategories();
                        break;
                    case MenuOptions.AddProduct:
                        ProductService.InsertProduct();
                        break;
                    case MenuOptions.DeleteProduct:
                        ProductService.DeleteProduct();
                        break;
                    case MenuOptions.UpdateProduct:
                        ProductService.UpdateProduct();
                        break;
                    case MenuOptions.ViewProduct:
                        ProductService.GetProduct();
                        break;
                    case MenuOptions.ViewAllProduct:
                        ProductService.GetProducts();
                        break;

                }
            }


        }

        internal static void ShowProduct(Product product)
        {
            var panel = new Panel($@"Product Id: {product.ProductId}
Name: {product.Name}
Category: {product.Category.Name}");
            panel.Header = new PanelHeader("Product Information");
            panel.Padding = new Padding(1, 1, 1, 1);

            AnsiConsole.Write(panel);


            Console.WriteLine("Enet any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static internal void ShowProductTable(List<Product> products)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Price");
            table.AddColumn("Category");

            foreach (var product in products)
            {
                table.AddRow(product.ProductId.ToString(),
                    product.Name,
                    product.Price.ToString(),
                    product.Category.Name
                    );
            }

            AnsiConsole.Write(table);


            Console.WriteLine("Enet any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static internal void ShowCategoryTable(List<Category> categories)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");

            foreach (var category in categories)
            {
                table.AddRow(category.Id.ToString(),
                    category.Name
                    );
            }

            AnsiConsole.Write(table);


            Console.WriteLine("Enet any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
