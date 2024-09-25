using CoffeShop.PointOfSale.EntityFramework;
using Spectre.Console;


var isAppRunning = true;
while (isAppRunning)
{


    var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
        .Title("What do you want to do?")
        .AddChoices(
        MenuOptions.AddProduct,
        MenuOptions.DisplayProduct,
        MenuOptions.UpdateProduct,
        MenuOptions.ViewProduct,
        MenuOptions.ViewAllProduct,
        MenuOptions.Quit
        ));

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductController.AddProduct();
            break;
        case MenuOptions.DisplayProduct:
            ProductController.DisplayProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductController.GetProductById();
            break;
        case MenuOptions.ViewAllProduct:
            ProductController.GetProducts();
            break;

    }
}




enum MenuOptions
{
    AddProduct,
    DisplayProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProduct,
    Quit
}