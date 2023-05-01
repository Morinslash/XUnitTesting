namespace CollectionsAssertions;

public class Menu
{
    public string Day { get; set; }
    public List<string> Items { get; set; }

    public Menu(string day, List<string> items)
    {
        Day = day;
        Items = items;
    }
}