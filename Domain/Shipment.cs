using ItemShop.Infrastructure;
using ItemShop.InterfaceAdapter;

namespace ItemShop.Domain;

public class Shipment : Decorator
{
    
    private IShipmentRepos _shipmentRepos;
    
    public Shipment(Order order, IShipmentRepos shipmentRepos) : base(order)
    {
        _shipmentRepos = shipmentRepos;
    }

    public override double Cost()
    {
        double shipmentPrice = _shipmentRepos.ShipmentPrice();

        return _order.Cost() + shipmentPrice;
    }

    public override string Description()
    {
        

        return _order.Description() + ", With Shipping";
    }
}