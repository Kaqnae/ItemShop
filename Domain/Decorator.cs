namespace ItemShop.Domain;

public abstract class Decorator : Order
{
    protected Order _order;

    protected Decorator(Order order)
    {
        this._order = order;
    }


}