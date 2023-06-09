﻿using OpenQA.Selenium;
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
        private IWebElement payeesTab => driver.WaitForElement(By.XPath("//*[@id=\"left\"]/div[1]/div/div[3]/section/div[2]/nav[1]/ul/li[3]/a/span"));

        private IWebElement everydayAccountLink => driver.WaitForElement(By.XPath("//h3[@title='Everyday']"));
        private IWebElement everydayBalance => driver.WaitForElement(By.XPath("//*[@id=\"account-ACC-1\"]/div[2]/span[3]"));
        private IWebElement payButton => driver.WaitForElement(By.XPath("//button[@class='Button Button--link js-pay AccountHeader-payButton']"));
        private IWebElement closeButton => driver.WaitForElement(By.XPath("//span[@class='js-close-modal-button close-modal-button']"));
        //private IWebElement BillAccountBalance => driver.WaitForElement(By.XPath("//h3[@title='Bills ']"));
        private IWebElement billAccountBalance => driver.WaitForElement(By.XPath("//*[@id=\"account-ACC-5\"]/div[2]/span[3]"));

        private IWebElement messsageaTransferSuccess => driver.WaitForElement(By.XPath("//div[@class='u-screenReaderOnly js-screenreader-message-announcer']"));

        public void ClickMenuList()
        {
            //MenuList SVG element
            IWebElement svgObject = driver.WaitForElement(By.XPath("//*[local-name()='svg' and @viewBox='0 0 30 30' and @class='Icons Icons--hamburguerMenu']"));
            Actions builder = new Actions(driver);
            builder.Click(svgObject).Build().Perform();
            Thread.Sleep(1000);

        }
        public PayeesPage SelectPayeesFromMenu()
        {

            ClickMenuList();
            payeesTab.Click();
            return new PayeesPage(driver);
        }
        public void ClickOnEvedayAccountLink()
        {
            everydayAccountLink.Click();
        }
        public decimal GetEverydayBalance()
        {
            decimal balance = Convert.ToDecimal(everydayBalance.Text);
            return balance;
        }
        public PaymentPage ClickOnPayButton()
        {
            payButton.Click();
            return new PaymentPage(driver);
        }
        public void ClickOnCloseButton()
        {
            closeButton.Click();
        }
        public void ClickOnBillAccountLink()
        {
            billAccountBalance.Click();
        }

        public Decimal GetBillAccountBalance()
        {
            Decimal balance =Convert.ToDecimal(billAccountBalance.Text);
            return balance;

        }
        public Boolean MessageDisplay()
        {
            return messsageaTransferSuccess.Displayed;
        }

    }
}

