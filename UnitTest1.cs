using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Selenium
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://feedbackradar-dev.azurewebsites.net/beheer/");

            InputByClass((ChromeDriver)driver, "class", "sc-fzoYkl jRkIgn", "login");
            InputByClass((ChromeDriver)driver, "class", "sc-fzoYkl jRkIgp", "password);
            GetElement((ChromeDriver)driver, "button", "class", "sc-oTbqq cHPZj").Click();

            Thread.Sleep(2000);

            bool dashboardElement = true;

            try
            {
                GetElement((ChromeDriver)driver, "span", "class", "sc-oTzgz nnuJi");
            }
            catch (Exception)
            {
                dashboardElement = false;
            }

            Assert.True(dashboardElement);
        }

        [Test]
        public void NavigateToTranslations()
        {
            LoginFeedBackRadar();
            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://feedbackradar-dev.azurewebsites.net/beheer/settings/translations");
            GetElement((ChromeDriver)driver, "button", "class", "sc-pReKu ioeGjB").Click();

            Thread.Sleep(500);

            string entryUrl = "https://feedbackradar-dev.azurewebsites.net/beheer/settings/translations/add";
            Assert.That(driver.Url, Is.EqualTo(entryUrl), "Url is not correct");
        }

        [Test]
        public void AddTranslations()
        {
            LoginFeedBackRadar();
            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://feedbackradar-dev.azurewebsites.net/beheer/settings/translations/add");

            GetElement((ChromeDriver)driver, "input", "name", "code").SendKeys("popup_test13");
            GetElement((ChromeDriver)driver, "input", "name", "valueDefault").SendKeys("sende inn");
            GetElement((ChromeDriver)driver, "input", "name", "valueEn").SendKeys("submit");

            Thread.Sleep(500);

            string element = "";

            try
            {
                GetElement((ChromeDriver)driver, "button", "type", "submit").Click();
                var popup = GetElement((ChromeDriver)driver, "button", "class", "MuiButtonBase-root MuiButton-root MuiButton-text MuiButton-colorInherit");
                Thread.Sleep(500);
                popup.Click();
                element = GetElement((ChromeDriver)driver, "p", "class", "MuiTypography-root MuiDialogContentText-root MuiTypography-body1 MuiTypography-colorTextSecondary").Text;

                var popup2 = ((ChromeDriver)driver, "button", "class", "MuiButtonBase-root MuiButton-root MuiButton-text MuiButton-colorInherit");
                Thread.Sleep(500);
                popup.Click();
            }
            catch (Exception)
            {

            }

            Assert.That(element, Is.EqualTo("Keyword has been added"), "Url is not correct");
        }

        [TearDown]
        public void QuitDriver()
        {
            //ubija przeglądarkę i drivera jako proces
            driver.Quit(); 
        }

        private void LoginFeedBackRadar()
        {
            driver.Navigate().GoToUrl("https://feedbackradar-dev.azurewebsites.net/beheer/");

            InputByClass((ChromeDriver)driver, "class", "sc-fzoYkl jRkIgn", "login");
            InputByClass((ChromeDriver)driver, "class", "sc-fzoYkl jRkIgp", "password");
            GetElement((ChromeDriver)driver, "button", "class", "sc-oTbqq cHPZj").Click();
            Thread.Sleep(500);
        }

        private void InputByClass(ChromeDriver driver,string cssSelector, string selectorValue, string value)
        {
            driver.FindElement(By.CssSelector("input[" + cssSelector + "='" + selectorValue + "']")).SendKeys(value);
            Thread.Sleep(1000);
        }

        private IWebElement GetElement(ChromeDriver driver, string elementName, string AttributeNme, string value)
        {
            //css = element_name[< attribute_name >= '<value>']
           return driver.FindElement(By.CssSelector( elementName + "[" + AttributeNme + "='" + value + "']"));
           Thread.Sleep(1000);
        }
    }
}
