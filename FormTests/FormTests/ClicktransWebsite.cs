using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace FormTests
{
    public class ClicktransWebsite
    {
        [Fact]
        public void FillingTheForm()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://dev-1.clicktrans.pl/register-test/courier");
                var companyName  = driver.FindElement(By.Id("user_register_company_name"));
                companyName.SendKeys("abc company");
                

                var email = driver.FindElement(By.Id("user_register_email"));
                email.SendKeys("test@gmail.com");
               
                var nameAndSurname = driver.FindElement(By.Id("user_register_name"));
                nameAndSurname.SendKeys("Magdalena Test");
                
                var country = new SelectElement(driver.FindElement(By.Id("user_register_phoneCode")));
                country.SelectByValue("49");

                var phone = driver.FindElement(By.Id("user_register_phone"));
                phone.SendKeys("123456789");
                
                var password = driver.FindElement(By.Id("user_register_plainPassword"));
                password.SendKeys("Magdalena1234");

                var agreementRegulation = driver.FindElement(By.Id("user_register_settings_agreementRegulations"));
                agreementRegulation.Click();

                var agreementPersonalData = driver.FindElement(By.Id("user_register_settings_agreementPersonalData"));
                agreementPersonalData.Click();

                var registration = driver.FindElement(By.Id("user_register_submit"));
                registration.Click();

                var currentMessage = driver.FindElement(By.CssSelector("[class='ui success message']"));

                Assert.Equal("OK - some registration logic is mocked", currentMessage.Text);
            }
        }
    }
}
