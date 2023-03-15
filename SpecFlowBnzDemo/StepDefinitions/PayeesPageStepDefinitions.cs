using AventStack.ExtentReports.Gherkin.Model;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowBnzDemo.Extension;
using SpecFlowBnzDemo.Pages;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowBnzDemo.StepDefinitions
{
    [Binding]
    public class PayeesPageStepDefinitions: Steps
    {
        private IWebDriver driver;
        ClientPage clientPage;
        PayeesPage payeesPage;
        public PayeesPageStepDefinitions(IWebDriver driver)
        {
             this.driver = driver;
             clientPage=new ClientPage(driver);
             payeesPage = new PayeesPage(driver);
        }
        [Given(@"I am in Payees Page")]
        public void GivenIAmInPayeesPage()
        {
            Given(@"I Select Payees tab from Menu");
        }

        [Given(@"I click on Add button")]
        public void GivenIClickOnAddButton()
        {
            payeesPage.ClickAddButton();
        }

        [Given(@"I enter payee details")]
        public void GivenIEnterPayeeDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            payeesPage.EnterPayeeDetails(data.Name,Convert.ToString(data.BankNo),Convert.
            ToString(data.BranchNo),Convert.ToString(data.AccountNo),Convert.ToString(data.SuffixNo));
         
        }
                
        [Then(@"‘Payee added’ message is displayed, and payee ""([^""]*)"" is added in the list of payees")]
        public void ThenPayeeAddedMessageIsDisplayedAndPayeeIsAddedInTheListOfPayees(string payee)
        {
            Thread.Sleep(3000);
            string ToastMessage = driver.WaitForElement(By.XPath("//span[@class='message' and @role='alert']")).Text;
            Console.WriteLine(ToastMessage);
            Assert.That(ToastMessage == "Payee added");
            Assert.That(driver.WaitForElement(By.XPath("//span[@class='js-payee-name' and text()='" + payee + "']")).Text==payee);
        }
        [Given(@"I Do not enter payee details and click Add button")]
        public void GivenIDoNotEnterPayeeDetailsAndClickAddButton()
        {
            
        }

        [Given(@"I get Validate errors message")]
        public void GivenIGetValidateErrorsMessage()
        {
            string msg = payeesPage.ValidatePayeeNameRequireMessage();                  
            Assert.AreEqual("Payee Name is a required field. Please complete to continue.",msg);
            string errorMsg = payeesPage.ValidateMandatoryField();
            Assert.AreEqual("A problem was found. Please correct the field highlighted below.", errorMsg);
            
        }

        [Given(@"Verify list sorted accending order by default")]
        public void GivenVerifyListSortedAccendingOrderByDefault()
        {
            String s1=payeesPage.VarifyListSorted();
            Assert.AreEqual(s1, "Sorting Success");
        }

        [Given(@"I click name header")]
        public void GivenIClickNameHeader()
        {
            PayeesPage payeesPage = new PayeesPage(driver);
            payeesPage.ClickNameButton();
           
        }

        [Then(@"List sorted descending order")]
        public void ThenListSortedDescendingOrder()
        {
            PayeesPage payeesPage = new PayeesPage(driver);
            String s1 = payeesPage.VarifyListSorted();
            Assert.AreEqual(s1, "Sorting Success");
        }



    }
}
