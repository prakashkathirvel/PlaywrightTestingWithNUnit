using Microsoft.Playwright.NUnit;

public class BaseTest : PageTest
{
    [SetUp]
    public async Task Setup(){
        var url = Environment.GetEnvironmentVariable("URL");
        await Page.GotoAsync(url!);
    }
}