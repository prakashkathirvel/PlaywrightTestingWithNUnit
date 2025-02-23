using Microsoft.Playwright.NUnit;

public class BaseTest : PageTest
{
    [SetUp]
    public async Task Setup(){
        var url = Environment.GetEnvironmentVariable("URL");
        //Starting Tracing
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
        //Launch URL
        await Page.GotoAsync(url!);
    }
    [TearDown]
    public async Task TearDown()
    {
        //Stopping Tracing
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
                TestContext.CurrentContext.WorkDirectory,
                "playwright-traces",
                $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
            )
        });
    }
    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await Browser.CloseAsync();
    }
}