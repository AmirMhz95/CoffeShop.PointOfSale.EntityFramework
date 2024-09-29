using CoffeShop.PointOfSale.EntityFramework.Controllers;
using CoffeShop.PointOfSale.EntityFramework.Models;
using Spectre.Console;

namespace CoffeShop.PointOfSale.EntityFramework.Services
{
    internal class CategoryService
    {

        internal static void InsertCategory()
        {
            var category = new Category();
            category.Name = AnsiConsole.Ask<string>("Enter category name");

            CategoryController.AddCategory(category);
        }

        internal static void GetCategories()
        {
            var categories = CategoryController.GetCategories();
            UserInterface.ShowCategoryTable(categories);
        }

        internal static int GetCategoryOptionInput()
        {
            var categories = CategoryController.GetCategories();
            var categoriesArray = categories.Select(x => x.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Select a category")
                .AddChoices(categoriesArray)
            );
            var id = categories.Single(x => x.Name == option).Id;

            return id;

        }
    }
}
