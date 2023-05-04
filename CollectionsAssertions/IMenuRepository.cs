namespace CollectionsAssertions;

public interface IMenuRepository
{
    Menu GetMenuByDay(string day);

    List<Menu> GetMenus();
}