using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTestingWithNUnit
{
    public class CommonActions{
        private readonly IPage _page;
        public CommonActions(IPage page){
            _page = page;
        }
        //Method to assert title of the webpage
        public async Task AssertTitleAsync(string expectedTitle)
        {
            var actualTitle = await _page.TitleAsync();
            if (actualTitle != expectedTitle)
            {
                throw new Exception($"Title assertion failed. Expected: {expectedTitle}, Actual: {actualTitle}");
            }
            await CommonMethods.CaptureScreenshotAsync(_page, "Asserting Title");
        }
        //Method to assert URL of the webpage
        public async Task AssertURLAsync(string expectedURL){
            var actualURL = _page.Url;
            if(actualURL != expectedURL){
                throw new Exception ($"URL assertion failed. Expected: {expectedURL}, Actual: {actualURL}");
            }
            await CommonMethods.CaptureScreenshotAsync(_page,"Asserting URL");
        }
    }
}