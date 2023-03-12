using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowBnzDemo.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBnzDemo.Pages
{
    public class ClientPage
    {
        private IWebDriver driver;

        public ClientPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //Payees Tab
        private IWebElement PayeesTab => driver.WaitForElement(By.XPath("//*[@id=\"left\"]/div[1]/div/div[3]/section/div[2]/nav[1]/ul/li[3]/a/span"));

        private IWebElement EverydayAccountLink => driver.WaitForElement(By.XPath("//h3[@title='Everyday']"));
        private IWebElement EverydayBalance => driver.WaitForElement(By.XPath("//*[@id=\"account-ACC-1\"]/div[2]/span[3]"));
        private IWebElement PayButton => driver.WaitForElement(By.XPath("//button[@class='Button Button--link js-pay AccountHeader-payButton']"));
        private IWebElement CloseButton => driver.WaitForClickable(By.XPath("//span[@class='js-close-modal-button close-modal-button']"));
        //private IWebElement BillAccountBalance => driver.WaitForElement(By.XPath("//h3[@title='Bills ']"));
        private IWebElement BillAccountBalance => driver.WaitForElement(By.XPath("//*[@id=\"account-ACC-5\"]/div[2]/span[3]"));
        public void clickMenuList()
        {
            //MenuList SVG element
            IWebElement svgObject = driver.WaitForElement(By.XPath("//*[local-name()='svg' and @viewBox='0 0 30 30' and @class='Icons Icons--hamburguerMenu']"));
            Actions builder = new Actions(driver);
            builder.Click(svgObject).Build().Perform();
            Thread.Sleep(1000);

        }
        public PayeesPage selectPayeesFromMenu()
        {

            clickMenuList();
            PayeesTab.Click();
            return new PayeesPage(driver);
        }
        public void clickOnEvedayAccountLink()
        {
            EverydayAccountLink.Click();
        }
        public decimal getEverydayBalance()
        {
            decimal balance = Convert.ToDecimal(EverydayBalance.Text);
            return balance;
        }
        public PaymentPage clickOnPayButton()
        {
            PayButton.Click();
            return new PaymentPage(driver);
        }
        public void clickOnCloseButton()
        {
            CloseButton.Click();
        }
        public void clickOnBillAccountLink()
        {
            BillAccountBalance.Click();
        }

        public Decimal getBillAccountBalance()
        {
            Decimal balance =Convert.ToDecimal(BillAccountBalance.Text);
            return balance;

        }
    }
}

