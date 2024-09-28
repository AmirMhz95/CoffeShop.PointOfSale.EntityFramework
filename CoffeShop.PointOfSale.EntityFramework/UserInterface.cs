using Spectre.Console;

namespace CoffeShop.PointOfSale.EntityFramework
{
    static internal class UserInterface
    {
        internal static void ShowProduct(Product product)
        {
            var panel = new Panel($@"Product Id: {product.Id}
Name: {product.Name}");
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

            foreach (var product in products)
            {
                table.AddRow(product.Id.ToString(), product.Name);
            }

            AnsiConsole.Write(table);


            Console.WriteLine("Enet any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
