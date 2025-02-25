using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PlaywrightTestingWithNUnit
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [AllureNUnit]
    public class HTMLTableTest : BaseTest
    {
        private HomePage _homePage;
        private HTMLTablePage _htmlTablePage;
        [SetUp]
        public new void PageSetup()
        {
            _homePage = new HomePage(Page);
            _htmlTablePage = new HTMLTablePage(Page);
        }
        [Test]
        [AllureName("Validating All UI Elements in HTML Table")]
        public async Task ValidateAllElementsInHTMLTable()
        {
            //Navigating to Home Form page
            await _homePage.NavigateToLinkPage("HTML Table");
            //Validating UI elements
            await _htmlTablePage.ValidateAllUIElements();
        }
        [Test]
        [AllureName("Verify Table Data")]
        [TestCase("Alan","12")]
        [TestCase("Bob","23")]
        [TestCase("Aleister","33.3")]
        [TestCase("Douglas","42")]
        public async Task VerifyTableData(string name, string amount)
        {
            //Navigating to Home Form page
            await _homePage.NavigateToLinkPage("HTML Table");
            //Validating table data
            await _htmlTablePage.ValidateAmountAgainstName(name, amount);
        }
    }
}