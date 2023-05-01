namespace CollectionsAssertions;

public class TestingCollections
{
    [Fact]
    public void CollectionContainsObject()
    {
        IMenuRepository testMenuRepository = new TestMenuRepository();
        MenuService menuService = new MenuService(testMenuRepository);

        var expectedMenu = testMenuRepository.GetMenuByDay("Friday");

        List<Menu> menus = menuService.GetMenus();

        Assert.Contains(expectedMenu, menus);
    }

    [Fact]
    public void CollectionContainsObject_Predicate()
    {
        IMenuRepository testMenuRepository = new TestMenuRepository();
        MenuService menuService = new MenuService(testMenuRepository);

        List<Menu> menus = menuService.GetMenus();

        Assert.Contains(menus, menu => menu.Day.Equals("Wednesday"));
    }

    [Fact]
    public void CollectionContainsObject_All()
    {
        IMenuRepository testMenuRepository = new TestMenuRepository();
        MenuService menuService = new MenuService(testMenuRepository);

        List<Menu> menus = menuService.GetMenus();

        Assert.All(menus,
            menu => Assert.True(menu.Items.Count == 3)
        );
    }
    
    [Fact]
    public void CollectionContainsObject_CollectionInOrder()
    {
        IMenuRepository testMenuRepository = new TestMenuRepository();
        MenuService menuService = new MenuService(testMenuRepository);

        List<Menu> menus = menuService.GetMenus();

        Assert.Collection(menus,
            menu => Assert.Equal("Monday", menu.Day),
            menu => Assert.Equal("Tuesday", menu.Day),
            menu => Assert.Equal("Wednesday", menu.Day),
            menu => Assert.Equal("Thursday", menu.Day),
            menu => Assert.Equal("Friday", menu.Day)
        );
    } 
    
    [Fact]
    public void CollectionContainsObject_CollectionInAnyOrder()
    {
        IMenuRepository testMenuRepository = new TestMenuRepository();
        MenuService menuService = new MenuService(testMenuRepository);

        List<Menu> menus = menuService.GetMenus();

        Assert.Collection(menus,
            menu => Assert.Contains("Monday", menu.Day),
            menu => Assert.Contains("Tuesday", menu.Day),
            menu => Assert.Contains("Wednesday", menu.Day),
            menu => Assert.Contains("Thursday", menu.Day),
            menu => Assert.Contains("Friday", menu.Day)
        );
    } 
}