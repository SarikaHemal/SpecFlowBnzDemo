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
            
            clientPage.ClickOnEvedayAccountLink();
            decimal beforeEverydayBalance = clientPage.GetEverydayBalance();
            Console.WriteLine("Before Everyday balance:  "+beforeEverydayBalance);
            paymentPage= clientPage.ClickOnPayButton();
                        
        }

        [Given(@"Transfer \$(.*) from Everyday account to Bills account")]
        public void GivenTransferFromEverydayAccountToBillsAccount(string amount)
        {
            paymentPage.ClickOnToLink();
            paymentPage.SelectAmountTabFromToAccount();
            paymentPage.SearchForAccount("Bills");
            paymentPage.SelectBillLink();
            paymentPage.EnterAmountTextbox(amount);
            clientPage=paymentPage.ClickOnSubmitButton();
            
        }

        [Given(@"Transfer successful message is displayed")]
        public void GivenTransferSuccessfulMessageIsDisplayed()
        {
            Assert.IsTrue(clientPage.MessageDisplay());
            Console.Write("Transfer successful");
            Thread.Sleep(3000);
            clientPage.ClickOnCloseButton();


        }

        [Then(@"Verify the current balance of Everyday account and Bills account are correct")]
        public void ThenVerifyTheCurrentBalanceOfEverydayAccountAndBillsAccountAreCorrect()
        {
            decimal AfterEverydayBalance = clientPage.GetEverydayBalance();
            Console.WriteLine("After Transfer Everyday Balance:   " + AfterEverydayBalance);
            Assert.AreEqual(AfterEverydayBalance,2000.00);
            
            Decimal AfterBillBalance=clientPage.GetBillAccountBalance();
            Assert.AreEqual(AfterBillBalance,920.00);
            Console.WriteLine("After Transfer Bill account:   "+ AfterBillBalance);
        }
    }
}
