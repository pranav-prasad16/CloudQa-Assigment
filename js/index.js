const { Builder, By, Key, until } = require('selenium-webdriver');
const chrome = require('selenium-webdriver/chrome');
const path = require('path');

async function testForm() {
  // driver setup
  let driver = await new Builder()
    .forBrowser('chrome')
    .setChromeOptions(new chrome.Options())
    .build();

  try {
    //URL
    await driver.get('https://app.cloudqa.io/home/AutomationPracticeForm');

    // Filling form fields
    await driver.findElement(By.id('fname')).sendKeys('Pavitr');
    await driver.findElement(By.id('lname')).sendKeys('Prabhakar');
    await driver.findElement(By.id('male')).click();
    await driver.findElement(By.id('dob')).sendKeys('2000-01-01');
    await driver.findElement(By.id('mobile')).sendKeys('1234567890');
    await driver.findElement(By.id('email')).sendKeys('pp@SpiderCouncil.com');
    await driver.findElement(By.id('country')).sendKeys('India');

    await driver.findElement(By.id('state')).sendKeys('India');

    await driver.findElement(By.id('Dance')).click();
    await driver.findElement(By.id('Reading')).click();
    await driver.findElement(By.id('Cricket')).click();

    await driver.findElement(By.name('About')).sendKeys('I love chai.');

    const fileInput = await driver.findElement(By.name('pic'));
    const imagePath = path.resolve('photo.jpg'); //photo path
    await fileInput.sendKeys(imagePath);

    // Fill in again
    await driver.findElement(By.name('Username')).sendKeys('p_prabhakar');
    await driver.findElement(By.name('Password')).sendKeys('spiderSense');
    await driver
      .findElement(By.name('Confirm Password'))
      .sendKeys('spiderSense');

    await driver.findElement(By.id('Agree')).click();

    // Submiting
    await driver.findElement(By.css('button[type="submit"]')).click();

    // Waiting
    await driver.wait(
      until.urlIs('https://app.cloudqa.io/home/AutomationPracticeForm'),
      5000
    ); // still waiting
    console.log('Form submitted successfully!');
  } catch (err) {
    console.error('Error during form submission test:', err.message);
  } finally {
    // Quit the browser
    await driver.quit();
  }
}

// Running
testForm();
