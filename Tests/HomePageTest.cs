using Microsoft.Playwright;

namespace PlaywrightTestingWithNUnit.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HomePageTest : BaseTest
{
    private HomePage _homePage;
    [SetUp]
    public new void PageSetup(){
        _homePage = new HomePage(Page);
    }
    [Test]
    public async Task HasTitle()
    {
        // Expect title is matching ot the expected title. 
        await Expect(Page).ToHaveTitleAsync("Web Testing and Automation Practice Application Pages");
    }
    [Test]
    public async Task AssertHeading()
    {
        // Expects page have heading with matching text
        await Expect(_homePage.txtHeading_PracticeApplications).ToBeVisibleAsync();
    } 
}