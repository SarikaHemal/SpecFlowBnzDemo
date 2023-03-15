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
        ClientPage clientPage;
        PaymentPage paymentPage;
        //PayeesPage payeesPage = default!;
        public PaymentPageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            clientPage = new ClientPage(driver);
            paymentPage = new PaymentPage(driver);
        }
        [Given(@"I Navigate to Payments page")]
        public void GivenINavigateToPaymentsPage()
        {
            
            clientPage.clickOnEvedayAccountLink();
            decimal beforeEverydayBalance = clientPage.getEverydayBalance();
            Console.WriteLine("Before Everyday balance:  "+beforeEverydayBalance);
            paymentPage= clientPage.clickOnPayButton();
                        
        }

        [Given(@"Transfer \$(.*) from Everyday account to Bills account")]
        public void GivenTransferFromEverydayAccountToBillsAccount(string amount)
        {
            paymentPage.clickOnToLink();
            paymentPage.selectAmountTabFromToAccount();
            paymentPage.searchForAccount("Bills");
            paymentPage.selectBillLink();
            paymentPage.enterAmountTextbox(amount);
            clientPage=paymentPage.clickOnSubmitButton();
            
        }

        [Given(@"Transfer successful message is displayed")]
        public void GivenTransferSuccessfulMessageIsDisplayed()
        {
            Assert.IsTrue(clientPage.messageDisplay());
            Console.Write("Transfer successful");
            Thread.Sleep(2000);
            clientPage.clickOnCloseButton();


        }

        [Then(@"Verify the current balance of Everyday account and Bills account are correct")]
        public void ThenVerifyTheCurrentBalanceOfEverydayAccountAndBillsAccountAreCorrect()
        {
            decimal AfterEverydayBalance = clientPage.getEverydayBalance();
            Console.WriteLine("After Transfer Everyday Balance:   " + AfterEverydayBalance);
            Assert.AreEqual(AfterEverydayBalance,2000.00);
            
            Decimal AfterBillBalance=clientPage.getBillAccountBalance();
            Assert.AreEqual(AfterBillBalance,920.00);
            Console.WriteLine("After Transfer Bill account:   "+ AfterBillBalance);
        }
    }
}
