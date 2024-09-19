using ItemShop.Domain;

namespace ItemShop.InterfaceAdapter;

public interface IItemRepos
{
    List<Item> ShowAllItems();
}