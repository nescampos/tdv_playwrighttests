using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasWebTestPlaywrightInTitleAndAButtonWithLinkToContactForm()
    {
        await Page.GotoAsync("https://localhost:7108/");
        await Expect(Page).ToHaveTitleAsync(new Regex("WebTestPlaywright"));
        var formButton = Page.Locator("text=Open Contact Form");
        await formButton.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*Home/Form"));
    }

    [Test]
    public async Task FormEnteringANameWithLessThanThreeCharactersExpectingThanksPage()
    {
        await Page.GotoAsync("https://localhost:7108/Home/Form");
        await Page.Locator("#Form_FirstName").FillAsync("Néstor");
        await Page.Locator("#Form_LastName").FillAsync("Campos");
        await Page.Locator("#Form_EmailAddress").FillAsync("nestor@gmail.com");
        await Page.Locator("#Form_BirthDate").FillAsync("1989-03-16");
        await Page.Locator("input.btn").ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*Home/Success"));
    }

    [Test]
    public async Task FormEnteringALastNameWithLessThanThreeCharactersExpectingThanksPage()
    {
        await Page.GotoAsync("https://localhost:7108/Home/Form");
        await Page.Locator("#Form_FirstName").FillAsync("Néstor");
        await Page.Locator("#Form_LastName").FillAsync("Campos");
        await Page.Locator("#Form_EmailAddress").FillAsync("nestor@gmail.com");
        await Page.Locator("#Form_BirthDate").FillAsync("1989-03-16");
        await Page.Locator("input.btn").ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*Home/Success"));
    }

    [Test]
    public async Task FormEnteringAnEmailWithLessThanThreeCharactersExpectingThanksPage()
    {
        await Page.GotoAsync("https://localhost:7108/Home/Form");
        await Page.Locator("#Form_FirstName").FillAsync("Néstor");
        await Page.Locator("#Form_LastName").FillAsync("Campos");
        await Page.Locator("#Form_EmailAddress").FillAsync("nestor@gmail.com");
        await Page.Locator("#Form_BirthDate").FillAsync("1989-03-16");
        await Page.Locator("input.btn").ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*Home/Success"));
    }

    [Test]
    public async Task FormEnteringAValidDateWithLessThanThreeCharactersExpectingThanksPage()
    {
        await Page.GotoAsync("https://localhost:7108/Home/Form");
        await Page.Locator("#Form_FirstName").FillAsync("Néstor");
        await Page.Locator("#Form_LastName").FillAsync("Campos");
        await Page.Locator("#Form_EmailAddress").FillAsync("nestor@gmail.com");
        await Page.Locator("#Form_BirthDate").FillAsync("2020-03-16");
        await Page.Locator("input.btn").ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*Home/Success"));
    }
}