namespace CollectionsAssertions;

public interface IMenuRepository
{
    void AddMenu(Menu menu);
    Menu GetMenuByDay(string day);

    List<Menu> GetMenus();
}