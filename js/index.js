const { Builder, By, Key, until } = require('selenium-webdriver');
const chrome = require('selenium-webdriver/chrome');
const path = require('path');

async function testForm() {
  // Start a new browser session
  let driver = await new Builder()
    .forBrowser('chrome')
    .setChromeOptions(new chrome.Options()) // Optional: for headless mode
    .build();

  try {
    // Navigate to the form page
    await driver.get('https://app.cloudqa.io/home/AutomationPracticeForm');

    // Fill out the form fields
    await driver.findElement(By.id('fname')).sendKeys('Pavitr'); // First Name
    await driver.findElement(By.id('lname')).sendKeys('Prabhakar'); // Last Name
    await driver.findElement(By.id('male')).click(); // Gender (Male)
    await driver.findElement(By.id('dob')).sendKeys('2000-01-01'); // Date of Birth
    await driver.findElement(By.id('mobile')).sendKeys('1234567890'); // Mobile Number
    await driver.findElement(By.id('email')).sendKeys('pp@SpiderCouncil.com'); // Email
    await driver.findElement(By.id('country')).sendKeys('India'); // Country

    // Select State from dropdown
    await driver.findElement(By.id('state')).sendKeys('India');

    // Check hobbies
    await driver.findElement(By.id('Dance')).click(); // Dance
    await driver.findElement(By.id('Reading')).click(); // Reading
    await driver.findElement(By.id('Cricket')).click(); // Reading

    // Fill in the About Yourself field
    await driver.findElement(By.name('About')).sendKeys('I love chai.');

    // Select file for the file input
    const fileInput = await driver.findElement(By.name('pic'));
    const imagePath = path.resolve('photo.jpg'); // Absolute path to the photo.png image
    await fileInput.sendKeys(imagePath);

    // Fill in username and password fields
    await driver.findElement(By.name('Username')).sendKeys('p_prabhakar');
    await driver.findElement(By.name('Password')).sendKeys('spiderSense');
    await driver
      .findElement(By.name('Confirm Password'))
      .sendKeys('spiderSense');

    // Agree to the terms & conditions
    await driver.findElement(By.id('Agree')).click();

    // Submit the form
    await driver.findElement(By.css('button[type="submit"]')).click();

    // Wait for the form submission to complete (e.g., the page redirects or a success message appears)
    await driver.wait(
      until.urlIs('https://app.cloudqa.io/home/AutomationPracticeForm'),
      5000
    ); // Wait for redirect or a success message
    console.log('Form submitted successfully!');
  } catch (err) {
    console.error('Error during form submission test:', err.message);
  } finally {
    // Quit the browser
    await driver.quit();
  }
}

// Run the test
testForm();
