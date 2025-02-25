using Microsoft.Playwright;

namespace PlaywrightTestingWithNUnit
{
    public class HTMLTablePage
    {
        private IPage _page;
        public HTMLTablePage(IPage page)
        {
            _page = page;
        }
        public CommonActions commonActions => new(_page);
        private ILocator _lblHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "HTML TABLE Tag" });
        private ILocator _lblCopyText => _page.GetByText("An example of an HTML Table");
        private ILocator _lblTableInfo => _page.GetByText("This table has information");
        private ILocator _tblHTMLTable => _page.GetByRole(AriaRole.Table, new() { Name = "This table has information" });
        //Method to validate all UI elements
        public async Task ValidateAllUIElements(){
            var softAssertions = new List<Task>
        {
            Assertions.Expect(_lblHeading).ToBeVisibleAsync(),
            Assertions.Expect(_lblCopyText).ToBeVisibleAsync(),
            Assertions.Expect(_lblTableInfo).ToBeVisibleAsync(),
        };    
        await Task.WhenAll(softAssertions);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Asserting UI Elements in HTML Table .......");
        }
        //Method to validate amount agaist name in HTML table
        public async Task ValidateAmountAgainstName(string name, string amount){
            var rows = _tblHTMLTable.Locator("tr");
            int rowCount = await rows.CountAsync();
            bool flag = false;
            for (int i = 1; i < rowCount; i++)
            {
                var row = rows.Nth(i);
                var cellName = await row.Locator("td").Nth(0).InnerTextAsync();
                var cellAmount = await row.Locator("td").Nth(1).InnerTextAsync();

                if (cellName.Equals(name, StringComparison.OrdinalIgnoreCase) && cellAmount.Equals(amount, StringComparison.OrdinalIgnoreCase))
                {
                    flag = true;
                    await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, $"Name: {name} and Amount: {amount} found in the table");
                }
            }
            Assert.True(flag);
        }
    }
}