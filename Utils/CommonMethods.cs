using Allure.Net.Commons;
using Microsoft.Playwright;


namespace PlaywrightTestingWithNUnit
{
    public static class CommonMethods{
        //Method to capture screenshot in allure report 
        public static async Task CaptureScreenshotAsync(IPage page, string screenshotTitle){
            var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), $"{screenshotTitle}.png");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath,FullPage = true, Type = ScreenshotType.Png });
            AllureApi.AddAttachment(screenshotTitle, "image/png", screenshotPath);
        }
        //Method to add test parameter to allure report
        public static void AddTestParameter_Allure(string key, string value){
            AllureApi.AddTestParameter(key,value);
        }
    }
}