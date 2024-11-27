using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

class AutomationPracticeFormTest
{
    static void Main(string[] args)
    {
        // Set up ChromeDriver (Ensure chromedriver.exe is in your PATH or specify the path directly)
        IWebDriver driver = new ChromeDriver();
        
        try
        {
            // Navigate to the form page
            driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

            // Wait for the page to load and form elements to be visible
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("fname")));

            // Fill out the form fields
            driver.FindElement(By.Id("fname")).SendKeys("Pavitr");  // First Name
            driver.FindElement(By.Id("lname")).SendKeys("Prabhakar");  // Last Name
            driver.FindElement(By.Id("male")).Click();  // Gender (Male)
            driver.FindElement(By.Id("dob")).SendKeys("2000-01-01");  // Date of Birth
            driver.FindElement(By.Id("mobile")).SendKeys("1234567890");  // Mobile Number
            driver.FindElement(By.Id("email")).SendKeys("pp@SpiderCouncil.com");  // Email
            driver.FindElement(By.Id("country")).SendKeys("India");  // Country

            // Select State from dropdown (assuming the country dropdown works similarly)
            driver.FindElement(By.Id("state")).SendKeys("India");

            // Check hobbies
            driver.FindElement(By.Id("Dance")).Click();  // Dance
            driver.FindElement(By.Id("Reading")).Click();  // Reading
            driver.FindElement(By.Id("Cricket")).Click();  // Cricket

            // Fill in the About Yourself field
            driver.FindElement(By.Name("About")).SendKeys("I love chai.");

            // Attach an image file to the form (ensure the file path is correct)
            var fileInput = driver.FindElement(By.Name("pic"));
            string imagePath = Path.GetFullPath("photo.jpg");  // Absolute path to the image file
            fileInput.SendKeys(imagePath);

            // Fill in username and password fields
            driver.FindElement(By.Name("Username")).SendKeys("p_prabhakar");
            driver.FindElement(By.Name("Password")).SendKeys("spiderSense");
            driver.FindElement(By.Name("Confirm Password")).SendKeys("spiderSense");

            // Agree to the terms & conditions
            driver.FindElement(By.Id("Agree")).Click();

            // Submit the form
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Wait for the form submission to complete (e.g., page redirection or success message)
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
