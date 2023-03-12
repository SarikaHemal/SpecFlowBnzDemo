Feature: PayeesPage

Payees Page Functionality 

@Automate
Scenario: Verify you can add new payee in the Payees page 
	Given I am in Payees Page
	And I click on Add button
	And I enter payee details 
	| Name | BankNo | BranchNo | AccountNo | SuffixNo |
	| Test | 12   | 1234     | 1234567 |10    |
	Then ‘Payee added’ message is displayed, and payee "Test" is added in the list of payees

@Automate
Scenario: Verify payee name is a required field 
	Given I am in Payees Page
	And I click on Add button
	And I Do not enter payee details and click Add button
	And I get Validate errors message
	And I enter payee details 
	| Name | BankNo | BranchNo | AccountNo | SuffixNo |
	| TestAuto | 12   | 1234     | 1234567 |10    |
	Then ‘Payee added’ message is displayed, and payee "TestAuto" is added in the list of payees

Scenario: Verify that payees can be sorted by name
	Given I am in Payees Page
	And I click on Add button
	And I enter payee details 
	| Name | BankNo | BranchNo | AccountNo | SuffixNo |
	| Test | 12   | 1234     | 1234567 |10    |
	And Verify list sorted accending order by default
	And I click name header
	Then List sorted descending order