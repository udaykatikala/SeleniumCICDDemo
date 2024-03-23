using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCourse.Config;

namespace SeleniumCourse.Drivers;

public class DriverWait
{

    private readonly Driver _driverFixture;
    private readonly TestSettings _testSettings;
    private readonly Lazy<WebDriverWait> _webDriverWait;

    public DriverWait(Driver driverFixture, TestSettings testSettings)
    {
        _driverFixture = driverFixture;
        _testSettings = testSettings;
        _webDriverWait = new Lazy<WebDriverWait>(GetWaitDriver);
    }

    public IWebElement FindElement(By elementLocator)
    {
        return _webDriverWait.Value.Until(_ => _driverFixture.driver.FindElement(elementLocator));
    }

    public IEnumerable<IWebElement> FindElements(By elementLocator)
    {
        return _webDriverWait.Value.Until(_ => _driverFixture.driver.FindElements(elementLocator));
    }

    private WebDriverWait GetWaitDriver()
    {
        return new(_driverFixture.driver, timeout: TimeSpan.FromSeconds(_testSettings.timeoutInterval ?? 30))
        {
            PollingInterval = TimeSpan.FromSeconds(_testSettings.timeoutInterval ?? 1)
        };
    }
}