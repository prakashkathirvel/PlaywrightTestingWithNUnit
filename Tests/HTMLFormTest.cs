using Allure.NUnit;
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
    public async Task VerifyURL(){
        await _homePage.ClickHomeFormExample();
        _homePage.commonActions.AssertURLAsync("https://testpages.eviltester.com/styled/basic-html-form-test.html");
    }
    
    [Test]
    public async Task ValidateAllElementsInHTMLForm(){
        await _homePage.ClickHomeFormExample();
        await _htmlFormPage.ValidateAllUIElements();
    }
    
    [Test]
    [TestCase("Utils/test.txt")]
    public async Task SubmitFormInHTMLForm(string filePath){
        await _homePage.ClickHomeFormExample();
        await _htmlFormPage.EnterUsername("testUser");
        await _htmlFormPage.EnterPasword("testPassword");
        await _htmlFormPage.EnterComments("This is a test comment");
        await _htmlFormPage.UploadFile(filePath);
        //selecting first checkbox
        await _htmlFormPage.SelectCheckBox("Checkbox 1");
        //selecting second radiobutton
        await _htmlFormPage.SelectRadioButton("Radio Button 2");
        List<string> selectedValues = new List<string> {"Selection Item 1", "Selection Item 2"};
        //selecting first value from listbox
        await _htmlFormPage.SelectMultipleValuesFromListbox(selectedValues.ToArray());
        //Selecting dropdown with dropdown 2 as value
        await _htmlFormPage.SelectValueFromDropDown("Drop Down Item 2");
        await _htmlFormPage.ClickContinue();
    }

}