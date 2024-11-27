using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

class AutomationPracticeFormTest
{
    static void Main(string[] args)
    {
        // Setting up Chrome Driver
        IWebDriver driver = new ChromeDriver();
        
        try
        {
            // URL
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // 5 seconds timeout
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fname")));

            // form fields fill out
            driver.FindElement(By.Id("fname")).SendKeys("Pavitr"); 
            driver.FindElement(By.Id("lname")).SendKeys("Prabhakar");  
            driver.FindElement(By.Id("male")).Click();  
            driver.FindElement(By.Id("dob")).SendKeys("2000-01-01");  
            driver.FindElement(By.Id("mobile")).SendKeys("1234567890");  
            driver.FindElement(By.Id("email")).SendKeys("pp@SpiderCouncil.com");  
            driver.FindElement(By.Id("country")).SendKeys("India");  

            driver.FindElement(By.Id("state")).SendKeys("India");

            driver.FindElement(By.Id("Dance")).Click();  
            driver.FindElement(By.Id("Reading")).Click(); 
            driver.FindElement(By.Id("Cricket")).Click();  

            driver.FindElement(By.Name("About")).SendKeys("I love chai.");

            var fileInput = driver.FindElement(By.Name("pic"));
            string imagePath = Path.GetFullPath("photo.jpg");  // image path
            fileInput.SendKeys(imagePath);

            // Fill in username and password fields
            driver.FindElement(By.Name("Username")).SendKeys("p_prabhakar");
            driver.FindElement(By.Name("Password")).SendKeys("spiderSense");
            driver.FindElement(By.Name("Confirm Password")).SendKeys("spiderSense");

            driver.FindElement(By.Id("Agree")).Click();

            // Submiting the form
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Waiting
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("AutomationPracticeForm"));
            
            Console.WriteLine("Form submitted successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error during form submission test: " + e.Message);
        }
        finally
        {
            // Close the browser window after the test
            driver.Quit();
        }
    }
}
