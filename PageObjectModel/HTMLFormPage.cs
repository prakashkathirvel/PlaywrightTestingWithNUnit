using System;
using Microsoft.Playwright;
using PlaywrightTestingWithNUnit;

public class HTMLFormPage{
    private readonly IPage _page;
    public HTMLFormPage(IPage page)
    {
        _page = page;
    }
    public CommonActions commonActions => new(_page);
    private ILocator _lblHeading_BasicHTMLForm => _page.GetByRole(AriaRole.Heading, new() { Name = "Basic HTML Form Example" });
    private ILocator _txtUsername => _page.Locator("input[name=\"username\"]");
    private ILocator _txtPassword => _page.Locator("input[name=\"password\"]");
    private ILocator _txtAreaComments => _page.GetByText("Comments...");
    private ILocator _btnUploadFile => _page.Locator("input[name=\"filename\"]");
    private ILocator _chkCheckBox => _page.GetByRole(AriaRole.Checkbox);
    private ILocator _rdoRadioButton => _page.GetByRole(AriaRole.Radio);
    private ILocator _listboxMultipleSelectedValues => _page.GetByRole(AriaRole.Listbox);
    private ILocator _ddlbDropDown => _page.GetByRole(AriaRole.Combobox);
    private ILocator _btnCancel => _page.GetByRole(AriaRole.Button, new() { Name = "cancel" });
    private ILocator _btnContinue => _page.GetByRole(AriaRole.Button, new() { Name = "submit" });

    //Method to validate all UI elements
    public async Task ValidateAllUIElements(){
        var softAssertions = new List<Task>
        {
            Assertions.Expect(_lblHeading_BasicHTMLForm).ToBeVisibleAsync(),
            Assertions.Expect(_txtUsername).ToBeVisibleAsync(),
            Assertions.Expect(_txtPassword).ToBeVisibleAsync(),
            Assertions.Expect(_txtAreaComments).ToBeVisibleAsync(),
            Assertions.Expect(_btnUploadFile).ToBeVisibleAsync(),
            Assertions.Expect(_btnContinue).ToBeVisibleAsync(),
            Assertions.Expect(_btnCancel).ToBeVisibleAsync(),
            Assertions.Expect(_ddlbDropDown).ToBeVisibleAsync(),
            Assertions.Expect(_listboxMultipleSelectedValues).ToBeVisibleAsync(),
            Assertions.Expect(_chkCheckBox).ToHaveCountAsync(3),
            Assertions.Expect(_rdoRadioButton).ToHaveCountAsync(3)
        };
        await Task.WhenAll(softAssertions);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Asserting UI Elements in HTML Form .......");
    }

    public async Task EnterUsername(string username){
        await _txtUsername.FillAsync(username);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Entering Username ......");
    }
    public async Task EnterPasword(string password){
        await _txtPassword.FillAsync(password);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Entering Password ......");
    }
    public async Task EnterComments(string comments){
        await _txtAreaComments.FillAsync(comments);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Entering Comments ......");
    }
    public async Task UploadFile(string filePath){
        await _btnUploadFile.SetInputFilesAsync(filePath);
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Uploading File ......");
    }
    public async Task SelectCheckBox(string checkBoxName){

        if(checkBoxName.ToLower().Equals("checkbox 1"))
            await _chkCheckBox.First.CheckAsync();
        else if(checkBoxName.ToLower().Equals("checkbox 2"))
            await _chkCheckBox.Nth(1).CheckAsync();
        else if(checkBoxName.ToLower().Equals("checkbox 3"))
            await _chkCheckBox.Nth(2).CheckAsync();
            
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, $"Selecting Checkbox :{checkBoxName} ......");
    }
    public async Task SelectRadioButton(string radioButtonName){
        if(radioButtonName.ToLower().Equals("radio 1"))
            await _rdoRadioButton.First.CheckAsync();
        else if(radioButtonName.ToLower().Equals("radio 2"))
            await _rdoRadioButton.Nth(1).CheckAsync();
        else if(radioButtonName.ToLower().Equals("radio 3"))
            await _rdoRadioButton.Nth(2).CheckAsync();
        
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, $"Selecting Radio Button :{radioButtonName} ......");
    }
    public async Task SelectMultipleValuesFromListbox(string[] values){
        foreach(var value in values){
            await _listboxMultipleSelectedValues.SelectOptionAsync(new SelectOptionValue { Label = value });
        }
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Selecting Multiple Values from Listbox ......");
    }
    public async Task SelectValueFromDropDown(string value){
        await _ddlbDropDown.SelectOptionAsync(new SelectOptionValue { Label = value });
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Selecting Value from Dropdown ......");
    }
    public async Task ClickContinue(){
        await _btnContinue.ClickAsync();
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Clicking Continue Button ......");
    }
    public async Task ClickCancel(){
        await _btnCancel.ClickAsync();
        await CommonMethods.AddStepWithScreenshot_AllureAsync(_page, "Clicking Cancel Button ......");
    }
}