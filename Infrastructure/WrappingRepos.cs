using ItemShop.InterfaceAdapter;

namespace ItemShop.Infrastructure;

public class WrappingRepos : IWrappingRepos
{
    private string _wrappingFilePath = "D:\\C#\\ItemShop\\ItemShop\\Entities\\Wrapping\\wrapper.txt";
    
    public double WrappingPrice()
    {
        try
        {
            using (StreamReader sr = new StreamReader(_wrappingFilePath))
            {
                string line = sr.ReadLine();

                if (double.TryParse(line, out double wrappingPrice))
                {
                    return wrappingPrice;
                }
                else
                {
                    throw new FormatException("Wrapping price format is invalid");
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Wrapping file not found: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Wrapping price format is invalid: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured while reading the wrapping file: {ex.Message}");
        }

        return 0;
    }
}