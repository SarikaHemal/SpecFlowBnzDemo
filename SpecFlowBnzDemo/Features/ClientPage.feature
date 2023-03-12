Feature: ClientPage
As user I can navigate to Payees page using the navigation menu 

@Automate
Scenario: As user I can navigate to Payees page using the navigation menu 
	Given I Select Payees tab from Menu
	Then I Navigate to Payees page
	
