using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace PlaywrightTestingWithNUnit.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[AllureNUnit]
public class HTMLFormTest: BaseTest{
private HomePage _homePage;
private HTMLFormPage _htmlFormPage;
    [SetUp]
    public new void PageSetup(){
        _homePage = new HomePage(Page);
        _htmlFormPage = new HTMLFormPage(Page);
    }
    [Test]
    [AllureName("Verify URL")]
    public async Task VerifyURL(){
        AllureApi.Step("Clicking Home form example link");
        await _homePage.ClickHomeFormExample();
        AllureApi.Step("Asserting URL");
        await _homePage.commonActions.AssertURLAsync("https://testpages.eviltester.com/styled/basic-html-form-test.html");
    }
    
    [Test]
    [AllureName("Validate All Elements in HTML Form")]
    public async Task ValidateAllElementsInHTMLForm(){
        AllureApi.Step("Clicking Home form example link");
        await _homePage.ClickHomeFormExample();
        AllureApi.Step("Validating all ui elements");
        await _htmlFormPage.ValidateAllUIElements();
    }
    
    [Test]
    [AllureName("Submit form in HTML Form")]
    [TestCase("testUser","testPassword","This is a test comment","Utils/test.txt")]
    public async Task SubmitFormInHTMLForm(string username,string password,string comments,string filePath){
        AllureApi.Step("Clicking Home form example link");
        await _homePage.ClickHomeFormExample();
        AllureApi.Step("Entering username");
        await _htmlFormPage.EnterUsername(username);
        AllureApi.Step("Entering password");
        await _htmlFormPage.EnterPasword(password);
        AllureApi.Step("Entering Comments");
        await _htmlFormPage.EnterComments(comments);
        AllureApi.Step("Uploading file");
        await _htmlFormPage.UploadFile(filePath);
        //selecting first checkbox
        AllureApi.Step("Selecting Checkbox 1");
        await _htmlFormPage.SelectCheckBox("Checkbox 1");
        //selecting second radiobutton
        AllureApi.Step("Selecting Radio Button 2");
        await _htmlFormPage.SelectRadioButton("Radio Button 2");
        List<string> selectedValues = new List<string> {"Selection Item 1", "Selection Item 2"};
        //selecting first value from listbox
        AllureApi.Step("Selecting Multiple values from listbox");
        await _htmlFormPage.SelectMultipleValuesFromListbox(selectedValues.ToArray());
        //Selecting dropdown with dropdown 2 as value
        AllureApi.Step("Selecting value from dropdown");
        await _htmlFormPage.SelectValueFromDropDown("Drop Down Item 2");
        //Clicking continue button
        AllureApi.Step("Clicking Continue button");
        await _htmlFormPage.ClickContinue();
    }

}