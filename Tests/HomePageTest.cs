using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PlaywrightTestingWithNUnit.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class HomePageTest : BaseTest
{
    private HomePage _homePage;
    [SetUp]
    public new void PageSetup(){
        _homePage = new HomePage(Page);
    }
    [Test]
    [AllureName("Verify Title")]
    public async Task HasTitle()
    {
        AllureApi.Step("Verify Title");
        // Expect title is matching ot the expected title. 
        await _homePage.commonActions.AssertTitleAsync("Web Testing and Automation Practice Application Pages");
    }
    [Test]
    [AllureName("Verify Heading")]
    public async Task AssertHeading()
    {
        AllureApi.Step("Verify Heading");
        // Expects page have heading with matching text
        await _homePage.ValidateHeading();
    } 
}