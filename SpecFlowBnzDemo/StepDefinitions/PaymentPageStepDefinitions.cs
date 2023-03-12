using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowBnzDemo.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBnzDemo.StepDefinitions
{
    [Binding]
    public class PaymentPageStepDefinitions : Steps
    {
        private IWebDriver driver;
        public PaymentPageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"I Navigate to Payments page")]
        public void GivenINavigateToPaymentsPage()
        {
            ClientPage clientPage = new ClientPage(driver);
            clientPage.clickOnEvedayAccountLink();
            decimal beforeEverydayBalance = clientPage.getEverydayBalance();
            Console.WriteLine("Before Everyday balance:  "+beforeEverydayBalance);
            //clientPage.clickOnCloseButton();
            //clientPage.clickOnBillAccountLink();
            //decimal beforeBillBalance=clientPage.getBillAccountBalance();
            //Console.WriteLine("Before Bills balance:  " + beforeBillBalance);
            PaymentPage paymentPage= clientPage.clickOnPayButton();
                        
        }

        [Given(@"Transfer \$(.*) from Everyday account to Bills account")]
        public void GivenTransferFromEverydayAccountToBillsAccount(string amount)
        {
            PaymentPage paymentPage = new PaymentPage(driver);
            paymentPage.clickOnToLink();
            paymentPage.selectAmountTabFromToAccount();
            paymentPage.searchForAccount("Bills");
            paymentPage.selectBillLink();
            paymentPage.enterAmountTextbox(amount);
            ClientPage clientPage=paymentPage.clickOnSubmitButton();
            Thread.Sleep(2000);
            clientPage.clickOnCloseButton();

        }

        [Given(@"Transfer successful message is displayed")]
        public void GivenTransferSuccessfulMessageIsDisplayed()
        {
            
        }

        [Then(@"Verify the current balance of Everyday account and Bills account are correct")]
        public void ThenVerifyTheCurrentBalanceOfEverydayAccountAndBillsAccountAreCorrect()
        {
            ClientPage clientPage = new ClientPage(driver);
            decimal AfterEverydayBalance = clientPage.getEverydayBalance();
            Console.WriteLine("After Transfer Everyday Balance:   " + AfterEverydayBalance);
            Assert.AreEqual(AfterEverydayBalance,2000.00);
            
            Decimal AfterBillBalance=clientPage.getBillAccountBalance();
            Assert.AreEqual(AfterBillBalance,920.00);
            Console.WriteLine("After Transfer Bill account:   "+ AfterBillBalance);
        }
    }
}
