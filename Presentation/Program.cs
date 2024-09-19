using ItemShop.Application;
using ItemShop.Domain;
using ItemShop.Infrastructure;
using ItemShop.InterfaceAdapter;

namespace ItemShop;

class Program
{
    static void Main(string[] args)
    {

        string itemDirectory = "D:\\C#\\ItemShop\\ItemShop\\Entities\\Items";
        string shipmentFilePath = "D:\\C#\\ItemShop\\ItemShop\\Entities\\Shipment\\shipment.txt";
        string wrappingFilePath = "D:\\C#\\ItemShop\\ItemShop\\Entities\\Wrapping\\wrapper.txt";
        
        IItemRepos itemRepos = new ItemRepos(itemDirectory);
        IShipmentRepos shipmentRepos = new ShipmentRepos();
        IWrappingRepos wrappingRepos = new WrappingRepos();
        
        var getItemsService = new GetItems(itemRepos);
        
        getItemsService.GetAllItems();

        var randomItem = getItemsService.PickRandomItem();

        if (randomItem != null)
        {
            Console.WriteLine($"Picked item: {randomItem._id}, {randomItem._description}, {randomItem._price}");

            Console.WriteLine("Do you want to add shipment? (y/n)");
            string input = Console.ReadLine().Trim().ToLower();

            Console.WriteLine("Do you want to add wrapping? (y/n)");
            string shipmentInput = Console.ReadLine().Trim().ToLower();

            Order order = randomItem;

            if (input == "y")
            {
                order = new Shipment(order, shipmentRepos);
            }

            if (shipmentInput == "y")
            {
                order = new Wrapping(order, wrappingRepos);
            }

            Console.WriteLine($"Final cost: {order.Cost()}");
            Console.WriteLine($"Order Description: {order.Description()}");
        }



    }
}