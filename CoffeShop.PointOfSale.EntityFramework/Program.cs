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
        MenuOptions.DeleteProduct,
        MenuOptions.UpdateProduct,
        MenuOptions.ViewProduct,
        MenuOptions.ViewAllProduct,
        MenuOptions.Quit
        ));

    switch (option)
    {
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




enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProduct,
    Quit
}