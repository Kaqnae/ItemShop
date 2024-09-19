using ItemShop.Domain;
using ItemShop.InterfaceAdapter;

namespace ItemShop.Infrastructure;

public class ItemRepos : IItemRepos
{

    private string _path;

    public ItemRepos(string path)
    {
        _path = path;
    }
    

    public List<Item> ShowAllItems()
    {
        var items = new List<Item>();

        try
        {
            var textFiles = Directory.EnumerateFiles(_path, "*.txt");

            foreach (var textFile in textFiles)
            {
                using (StreamReader reader = new StreamReader(textFile))
                {
                    string line = reader.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] lineArr = line.Split(',');

                        if (lineArr.Length == 3)
                        {
                            items.Add(new Item(lineArr[0], lineArr[1], double.Parse(lineArr[2])));
                        }
                        else
                        {
                            Console.WriteLine($"Invalid format in file: {textFile}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Empty or invalid file: {textFile}");
                    }
                }
            }
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Directory not found: {ex.Message}");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File not found: {ex.Message}");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
        return items;
    }
}