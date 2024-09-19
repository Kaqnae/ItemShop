using ItemShop.InterfaceAdapter;

namespace ItemShop.Infrastructure;

public class ShipmentRepos : IShipmentRepos
{

    private string _shipmentFilePath = "D:\\C#\\ItemShop\\ItemShop\\Entities\\Shipment\\shipment.txt";
    
    public double ShipmentPrice()
    {
        try
        {
            using (StreamReader streamReader = new StreamReader(_shipmentFilePath))
            {
                string line = streamReader.ReadLine();

                if (double.TryParse(line, out double shipmentPrice))
                {
                    return shipmentPrice;
                }
                else
                {
                    throw new FormatException("Shipment Price format is invalid");
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Shipment file not found: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error parsing shipment price: {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occured while reading the shipment file: {ex.Message}");
        }

        return 0;
    }
}