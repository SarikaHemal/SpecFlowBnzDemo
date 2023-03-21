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
        private IWebElement addButton => driver.WaitForElement(By.XPath("//button[@type='button' and @class='Button Button--sub Button--translucid js-add-payee']"));
        private IWebElement payeeNameTextbox => driver.WaitForElement(By.XPath("//input[@name='apm-name']"));
        private IWebElement bankNumber => driver.WaitForElement(By.XPath("//input[@name='apm-bank']"));
        private IWebElement branchNumber => driver.WaitForElement(By.XPath("//input[@name='apm-branch']"));
        private IWebElement accountNumber => driver.WaitForElement(By.XPath("//input[@name='apm-account']"));
        private IWebElement suffixNumber => driver.WaitForElement(By.XPath("//input[@name='apm-suffix']"));
        private IWebElement addButtonfromBankDetails => driver.WaitForElement(By.XPath("//button[@class='js-submit Button Button--primary']"));
        private IWebElement payeeRequireMessage => driver.WaitForElement(By.XPath("//p[@class='text js-tooltip-text']"));

        private IWebElement errorMessage => driver.WaitForElement(By.XPath("//div[@class='error-header']"));
        private IWebElement nameSortButton => driver.WaitForElement(By.XPath("//h3[@role='button' and @aria-label='Sort by payee name A to Z selected. Select again to reverse order.']"));
        public void ClickAddButton()
        {
            addButton.Click();
        }
        public void EnterPayeeDetails(string Name, string BankNo, string BranchNo, string AccountNo, string SuffixNo)
        {
            //PayeeNameTextbox.WaitForTextLoaded(driver);

            payeeNameTextbox.EnterText(Name);
            payeeNameTextbox.SendKeys(Keys.Enter);
            bankNumber.EnterText(BankNo);
            branchNumber.EnterText(BranchNo);
            accountNumber.EnterText(AccountNo);
            suffixNumber.EnterText(SuffixNo);
            suffixNumber.SendKeys(Keys.Enter);
            addButtonfromBankDetails.Click();
        }
        public string ValidatePayeeNameRequireMessage()
        {
            addButtonfromBankDetails.Click();
            string s1 = payeeRequireMessage.Text;
            Console.WriteLine(s1);
            return s1;
        }
        public string ValidateMandatoryField()
        {
            string s1 = errorMessage.Text;
            Console.WriteLine(s1);
            return s1;
        }
        public void ClickNameButton()
        {
            nameSortButton.Click();

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
