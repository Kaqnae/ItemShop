using ItemShop.Domain;
using ItemShop.InterfaceAdapter;

namespace ItemShop.Application;

public class GetItems
{
    private IItemRepos _itemRepos;
    private List<Item> items;
    private Item randomItem;


    public GetItems(IItemRepos itemRepos)
    {
        _itemRepos = itemRepos;
    }

    public void GetAllItems()
    {
        items = _itemRepos.ShowAllItems();

        if (items.Count == 0)
        {
            Console.WriteLine("No items found");
            return;
        }


        foreach (Item item in items)
        {
            Console.WriteLine(item._id + "" + item._description + " " + item._price);
        }
    }

    public Item PickRandomItem()
    {

        if (items == null || items.Count == 0)
        {
            Console.WriteLine("No items found");
            return null;
        }

        Random random = new Random();
        randomItem = items[random.Next(items.Count)];

        Console.WriteLine(randomItem._id + "" + randomItem._description + " " + randomItem._price);
        
        return randomItem;
    }



}