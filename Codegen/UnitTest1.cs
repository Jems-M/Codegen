using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace Codegen
{
    [TestFixture]
    public class UnitTest1 : Microsoft.Playwright.NUnit.PageTest
    {
        [Test]
        public async Task MyTest()
        {
            var context = await Browser.NewContextAsync(new() { RecordVideoDir = "C:\\Users\\james\\source\\repos\\Codegen\\Codegen\\Videos\\wideo.mp4" });
            var Page = await context.NewPageAsync();
            await Page.GotoAsync("https://localhost:44391/Product/Index");
            await Page.ScreenshotAsync(new() { Path = "C:\\Users\\james\\source\\repos\\Codegen\\Codegen\\Screenshots\\pretest.png" });

            await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
            await Page.GetByLabel("product name").ClickAsync();
            await Page.GetByLabel("product name").FillAsync("Pears");
            await Page.GetByLabel("product name").PressAsync("Tab");
            await Page.GetByLabel("Price").FillAsync("1.80");
            await Page.GetByLabel("Price").PressAsync("Tab");
            await Page.GetByLabel("description").FillAsync("pear-shaped");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
            await Page.Locator("p").Filter(new() { HasText = "Create New" }).ClickAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
            await Page.GetByRole(AriaRole.Heading, new() { Name = "Product" }).ClickAsync();

            await Page.ScreenshotAsync(new() { Path = "C:\\Users\\james\\source\\repos\\Codegen\\Codegen\\Screenshots\\posttest.png" });
            await context.CloseAsync();
        }
    }
}