namespace CollectionsAssertions;

public class MenuService
{
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public List<Menu> GetMenus()
    {
        return _menuRepository.GetMenus();
    }
}