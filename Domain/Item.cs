namespace ItemShop.Domain;

public class Item : Order
{
    
    public string _id { get; }
    public string _description { get; }
    public double _price { get; }

    public Item(string id, string description, double price)
    {
        _id = id;
        _description = description;
        _price = price;
    }



    public override double Cost()
    {
       return _price;
    }

    public override string Description()
    {
        return _description;
    }

 
}