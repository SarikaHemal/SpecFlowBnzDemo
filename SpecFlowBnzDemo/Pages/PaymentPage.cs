using MongoDB.Driver.Core.WireProtocol.Messages.Encoders;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowBnzDemo.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBnzDemo.Pages
{
    public class PaymentPage
    {
        private IWebDriver driver;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Payees Tab
        private IWebElement payeesTab => driver.WaitForElement(By.XPath("//*[@id=\"left\"]/div[1]/div/div[3]/section/div[2]/nav[1]/ul/li[3]/a/span"));

        //To account link
        private IWebElement toLink => driver.WaitForElement(By.ClassName("name-0-5-45"));
        private IWebElement fromLink => driver.WaitForElement(By.ClassName("button-0-5-31"));
        private IWebElement amountTabFromToAccount => driver.WaitForElement(By.XPath("//li[@data-testid='to-account-accounts-tab']"));
        private IWebElement amountTextbox => driver.WaitForElement(By.Name("amount"));

        private IWebElement everydayLink => driver.WaitForElement(By.ClassName("content-0-5-36"));
        private IWebElement billLink => driver.WaitForClickable(By.XPath("//p[contains(text(),'Bills ')]"));

        private IWebElement submitButton => driver.WaitForElement(By.XPath
            ("//button[@type='submit'and@data-monitoring-label='Transfer Form Submit' ]"));
        private IWebElement searchAccount => driver.WaitForElement(By.XPath
            ("//input[@placeholder='Search']"));

        public void ClickOnFromLink()
        {
            fromLink.Click();
        }
        public void ClickOnToLink()
        {
            toLink.Click();
        }
        public void SelectAmountTabFromToAccount()
        {
            driver.WaitForDisplayed(By.XPath("//li[@data-testid='to-account-accounts-tab']")).Click();
        }
        public void SelectEverydayLink()
        {
        //    SelectElement accountlist= new SelectElement(BillLink);
        //    accountlist.SelectByText("Bills");
        //    EverydayLink.Click();
        }
        public void SelectBillLink()
        {
            billLink.Click();
        }
        public void EnterAmountTextbox(string amount)
        {
            amountTextbox.EnterText(amount);
        }
        public ClientPage ClickOnSubmitButton( )
        { 
            submitButton.Click();
            return new ClientPage(driver);
        }
        public void SearchForAccount(string account)
        {
            searchAccount.EnterText(account);
            searchAccount.SendKeys(Keys.Enter);

        }

    }
}