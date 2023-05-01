namespace CollectionsAssertions;

public class TestMenuRepository : IMenuRepository
{
    private readonly List<Menu> _menus;

    public TestMenuRepository()
    {
        _menus = new List<Menu>()
        {
            new Menu("Monday", new List<string> { "Spaghetti Bolognese", "Caesar Salad", "Garlic Bread" }),
            new Menu("Tuesday", new List<string>{"Beef Stroganoff", "Greek Salad", "Rice Pilaf"}),
            new Menu("Wednesday", new List<string>{"Roast Chicken", "Coleslaw", "Mashed Potatoes"}),
            new Menu("Thursday", new List<string>{"Fish and Chips", "Garden Salad", "Tartar Sauce"}),
            new Menu("Friday", new List<string>{"Beef Burritos", "Salsa", "Guacamole"})
        };
    }

    public void AddMenu(Menu menu)
    {
        _menus.Add(menu);
    }

    public Menu GetMenuByDay(string day)
    {
        return _menus.FirstOrDefault(menu => menu.Day == day);
    }

    public List<Menu> GetMenus()
    {
        return _menus;
    }
}