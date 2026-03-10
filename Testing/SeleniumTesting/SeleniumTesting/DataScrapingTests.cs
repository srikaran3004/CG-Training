using OpenQA.Selenium;

namespace SeleniumTesting;

[TestFixture]
[Description("Demonstrates Selenium web scraping from HTML tables and dynamic content")]
public class DataScrapingTests : TestBase
{
    [SetUp]
    public void ScrapingSetUp()
    {
        Login();
        Driver.FindElement(By.Id("nav-products")).Click();
        Wait.Until(d => d.Url.Contains("/Products"));
    }

    [Test]
    public void ScrapeProductTable_ShouldReturn10Products()
    {
        var rows = Driver.FindElements(By.CssSelector("#product-table tbody tr"));
        Assert.That(rows, Has.Count.EqualTo(10));
    }

    [Test]
    public void ScrapeProductNames_ShouldContainExpectedProducts()
    {
        var nameElements = Driver.FindElements(By.CssSelector("#product-table tbody tr td:nth-child(2)"));
        var productNames = nameElements.Select(e => e.Text).ToList();

        Assert.Multiple(() =>
        {
            Assert.That(productNames, Does.Contain("Laptop Pro 15"));
            Assert.That(productNames, Does.Contain("Wireless Mouse"));
            Assert.That(productNames, Does.Contain("Standing Desk"));
        });
    }

    [Test]
    public void ScrapeProductPrices_ShouldBeValidNumbers()
    {
        var priceElements = Driver.FindElements(By.CssSelector("#product-table tbody tr td:nth-child(4)"));

        foreach (var priceElement in priceElements)
        {
            var priceText = priceElement.Text.Replace("$", "").Replace(",", "").Trim();
            Assert.That(decimal.TryParse(priceText, out var price), Is.True,
                $"Price '{priceElement.Text}' is not a valid number");
            Assert.That(price, Is.GreaterThan(0));
        }
    }

    [Test]
    public void ScrapeFullProductData_ShouldExtractAllColumns()
    {
        var rows = Driver.FindElements(By.CssSelector("#product-table tbody tr"));
        var products = new List<Dictionary<string, string>>();

        foreach (var row in rows)
        {
            var cells = row.FindElements(By.TagName("td"));
            products.Add(new Dictionary<string, string>
            {
                ["Id"] = cells[0].Text,
                ["Name"] = cells[1].Text,
                ["Category"] = cells[2].Text,
                ["Price"] = cells[3].Text,
                ["Stock"] = cells[4].Text,
                ["Rating"] = cells[5].Text
            });
        }

        Assert.That(products, Has.Count.EqualTo(10));

        var laptop = products.First(p => p["Name"] == "Laptop Pro 15");
        Assert.Multiple(() =>
        {
            Assert.That(laptop["Category"], Is.EqualTo("Electronics"));
            Assert.That(laptop["Price"], Does.Contain("1,299.99"));
        });

        TestContext.WriteLine("=== Scraped Product Data ===");
        foreach (var product in products)
        {
            TestContext.WriteLine($"  {product["Id"]} | {product["Name"]} | {product["Category"]} | {product["Price"]} | Stock: {product["Stock"]}");
        }
    }

    [Test]
    public void CountProductsByCategory_ShouldGroupCorrectly()
    {
        var categoryElements = Driver.FindElements(By.CssSelector("#product-table tbody tr td:nth-child(3)"));
        var categories = categoryElements.Select(e => e.Text).ToList();

        var grouped = categories.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        Assert.Multiple(() =>
        {
            Assert.That(grouped["Electronics"], Is.EqualTo(6));
            Assert.That(grouped["Furniture"], Is.EqualTo(2));
            Assert.That(grouped["Accessories"], Is.EqualTo(1));
            Assert.That(grouped["Stationery"], Is.EqualTo(1));
        });
    }

    [Test]
    public void SearchProducts_ShouldFilterResults()
    {
        var searchBox = Driver.FindElement(By.Id("product-search"));
        searchBox.SendKeys("Laptop");

        Wait.Until(d =>
        {
            var visibleRows = d.FindElements(By.CssSelector("#product-table tbody tr"))
                .Where(r => r.Displayed).ToList();
            return visibleRows.Count < 10;
        });

        var visibleRows = Driver.FindElements(By.CssSelector("#product-table tbody tr"))
            .Where(r => r.Displayed).ToList();

        Assert.That(visibleRows, Has.Count.EqualTo(1));
        Assert.That(visibleRows[0].Text, Does.Contain("Laptop Pro 15"));
    }

    [Test]
    public void ClearSearch_ShouldShowAllProducts()
    {
        var searchBox = Driver.FindElement(By.Id("product-search"));
        searchBox.SendKeys("Laptop");

        Wait.Until(d =>
            d.FindElements(By.CssSelector("#product-table tbody tr"))
                .Count(r => r.Displayed) < 10);

        searchBox.Clear();

        Wait.Until(d =>
            d.FindElements(By.CssSelector("#product-table tbody tr"))
                .Count(r => r.Displayed) == 10);

        var allRows = Driver.FindElements(By.CssSelector("#product-table tbody tr"))
            .Where(r => r.Displayed).ToList();
        Assert.That(allRows, Has.Count.EqualTo(10));
    }

    [Test]
    public void ScrapeDashboardStats_ShouldReturnValidNumbers()
    {
        Driver.FindElement(By.Id("nav-dashboard")).Click();
        Wait.Until(d => d.Url.Contains("/Dashboard"));

        var products = Driver.FindElement(By.Id("stat-products")).Text;
        var users = Driver.FindElement(By.Id("stat-users")).Text;
        var orders = Driver.FindElement(By.Id("stat-orders")).Text;

        Assert.Multiple(() =>
        {
            Assert.That(int.Parse(products), Is.EqualTo(10));
            Assert.That(int.Parse(users), Is.EqualTo(2));
            Assert.That(int.Parse(orders), Is.EqualTo(5));
        });
    }
}
