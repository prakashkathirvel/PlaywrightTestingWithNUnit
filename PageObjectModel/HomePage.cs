using System;
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
    private ILocator _lnkHTMLTableExample => _page.GetByRole(AriaRole.Link, new() { Name = "Table Test Page", Exact = true });
    //Method to click link 
    public async Task NavigateToLinkPage(string linkName)
    {
        switch(linkName.ToLower())
        {
            case "home form":
                await _lnkHomeFormExample.ClickAsync();
                break;
            case "html table":
                await _lnkHTMLTableExample.ClickAsync();
                break;
        }
        
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, $"Navigating to Link Page : {linkName} ......");
    }
    public async Task ValidateHeading(){
        await Assertions.Expect(_txtHeading_PracticeApplications).ToBeVisibleAsync();
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page,"Validating heading ......");
    }
    public async Task ValidateAllUIElements(){
        var softAssertions = new List<Task>
        {
            Assertions.Expect(_txtHeading_PracticeApplications).ToBeVisibleAsync(),
            Assertions.Expect(_lnkHomeFormExample).ToBeVisibleAsync(),
            Assertions.Expect(_lnkHTMLTableExample).ToBeVisibleAsync(),
        };
        await Task.WhenAll(softAssertions);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Asserting UI Elements in Home Page .......");
    }
}