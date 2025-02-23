using Microsoft.Playwright;
using PlaywrightTestingWithNUnit;

public class HomePage
{
    private readonly IPage _page;
    public HomePage(IPage page)
    {
        _page = page;
    }
    public CommonActions commonActions => new(_page);
    private ILocator _txtHeading_PracticeApplications => _page.GetByText("Practice Applications and Pages For Automating and Testing");
    private ILocator _lnkHomeFormExample => _page.Locator("#htmlformtest");
    public async Task ClickHomeFormExample()
    {
        await _lnkHomeFormExample.ClickAsync();
        await CommonMethods.CaptureScreenshotAsync(_page, "Clicked on Home Form link");
    }
    public async Task ValidateHeading(){
        await Assertions.Expect(_txtHeading_PracticeApplications).ToBeVisibleAsync();
        await CommonMethods.CaptureScreenshotAsync(_page,"Validating heading");
    }
}