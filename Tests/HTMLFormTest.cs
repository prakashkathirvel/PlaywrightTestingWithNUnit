using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;

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
        //Clicking Home form example link
        await _homePage.NavigateToLinkPage("Home Form");
        //Asserting URL
        await _homePage.commonActions.AssertURLAsync("https://testpages.eviltester.com/styled/basic-html-form-test.html");
    }
    
    [Test]
    [AllureName("Validate All Elements in HTML Form")]
    public async Task ValidateAllElementsInHTMLForm(){
       //clicking Home form example link
        await _homePage.NavigateToLinkPage("Home Form");
        //Validating all UI elements
        await _htmlFormPage.ValidateAllUIElements();
    }
    
    [Test]
    [AllureName("Submit form in HTML Form")]
    [TestCase("testUser","testPassword","This is a test comment","Utils/test.txt")]
    public async Task SubmitFormInHTMLForm(string username,string password,string comments,string filePath){
        //Clicking Home form example link
        await _homePage.NavigateToLinkPage("Home Form");
        //Entering Username
        await _htmlFormPage.EnterUsername(username);
        //Entering password
        await _htmlFormPage.EnterPasword(password);
        //Entering Comments
        await _htmlFormPage.EnterComments(comments);
        //Uploding filepath
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
        //Clicking continue button
        await _htmlFormPage.ClickContinue();
    }

}