using ItemShop.Infrastructure;
using ItemShop.InterfaceAdapter;

namespace ItemShop.Domain;

public class Wrapping : Decorator
{
    
    private IWrappingRepos _wrappingRepos;
    
    
    public Wrapping(Order order, IWrappingRepos wrappingRepos) : base(order)
    {
        _wrappingRepos = wrappingRepos;
    }

    public override double Cost()
    {

        double wrappingPrice = _wrappingRepos.WrappingPrice();

        return _order.Cost() + wrappingPrice;
    }

    public override string Description()
    {
        return _order.Description() + ", With wrapping";
    }
}