using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SpecFlowBnzDemo.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpecFlowBnzDemo.Pages
{
    public class PayeesPage
    {
        private IWebDriver driver;

        public PayeesPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //add buutton
        private IWebElement AddButton => driver.WaitForElement(By.XPath("//button[@type='button' and @class='Button Button--sub Button--translucid js-add-payee']"));
        private IWebElement PayeeNameTextbox => driver.WaitForElement(By.XPath("//input[@name='apm-name']"));
        private IWebElement BankNumber => driver.WaitForElement(By.XPath("//input[@name='apm-bank']"));
        private IWebElement BranchNumber => driver.WaitForElement(By.XPath("//input[@name='apm-branch']"));
        private IWebElement AccountNumber => driver.WaitForElement(By.XPath("//input[@name='apm-account']"));
        private IWebElement SuffixNumber => driver.WaitForElement(By.XPath("//input[@name='apm-suffix']"));
        private IWebElement AddButtonfromBankDetails => driver.WaitForElement(By.XPath("//button[@class='js-submit Button Button--primary']"));
        private IWebElement PayeeRequireMessage => driver.WaitForElement(By.XPath("//p[@class='text js-tooltip-text']"));

        private IWebElement ErrorMessage => driver.WaitForElement(By.XPath("//div[@class='error-header']"));
        private IWebElement NameSortButton => driver.WaitForElement(By.XPath("//h3[@role='button' and @aria-label='Sort by payee name A to Z selected. Select again to reverse order.']"));
        public void ClickAddButton()
        {
            AddButton.Click();
        }
        public void EnterPayeeDetails(string Name, string BankNo, string BranchNo, string AccountNo, string SuffixNo)
        {
            //PayeeNameTextbox.WaitForTextLoaded(driver);

            PayeeNameTextbox.EnterText(Name);
            PayeeNameTextbox.SendKeys(Keys.Enter);
            BankNumber.EnterText(BankNo);
            BranchNumber.EnterText(BranchNo);
            AccountNumber.EnterText(AccountNo);
            SuffixNumber.EnterText(SuffixNo);
            SuffixNumber.SendKeys(Keys.Enter);
            AddButtonfromBankDetails.Click();
        }
        public string ValidatePayeeNameRequireMessage()
        {
            AddButtonfromBankDetails.Click();
            string s1 = PayeeRequireMessage.Text;
            Console.WriteLine(s1);
            return s1;
        }
        public string ValidateMandatoryField()
        {
            string s1 = ErrorMessage.Text;
            Console.WriteLine(s1);
            return s1;
        }
        public void ClickNameButton()
        {
            NameSortButton.Click();

        }
        public string VarifyListSorted()
        {

            IList<IWebElement> list = driver.FindElements(By.XPath("//Ul[@class='List List--border']"));
            for (int i = 0; i < list.Count; i++)
            {
                if (list[0].Text == "Auckland Council")
                {
                    break;

                }
                if (list[0].Text == "VODAFONE NZ LTD (MOBILE)")
                {
                    break;
                }
                Console.WriteLine(list[i].Text);

            }
            return "Sorting Success";

        }
    }  
}
