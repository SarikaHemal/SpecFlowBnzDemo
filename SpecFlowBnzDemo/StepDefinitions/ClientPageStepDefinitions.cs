using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowBnzDemo.Pages;
using SpecFlowBnzDemo.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBnzDemo.StepDefinitions
{
    [Binding]
    public class ClientPageStepDefinitions
    {
        private IWebDriver driver;
        public ClientPageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        
        [Given(@"I Select Payees tab from Menu")]
        public void GivenISelectPayeesTabFromMenu()
        {
            ClientPage clientPage = new ClientPage(driver);
            PayeesPage payeesPage = clientPage.selectPayeesFromMenu();

        }

        [Then(@"I Navigate to Payees page")]
        public void ThenINavigateToPayeesPage()
        {
            Console.WriteLine(driver.Url);
            Assert.True(driver.Url== "https://demo.bnz.co.nz/client/payees");
            Thread.Sleep(1000);
            
        }



    }
}
