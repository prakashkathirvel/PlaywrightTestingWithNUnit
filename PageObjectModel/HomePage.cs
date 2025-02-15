using Microsoft.Playwright;

public class HomePage
{
    private readonly IPage _page;
    public HomePage(IPage page)
    {
        _page = page;
    }
    public ILocator txtHeading_PracticeApplications => _page.GetByText("Practice Applications and Pages For Automating and Testing");

}