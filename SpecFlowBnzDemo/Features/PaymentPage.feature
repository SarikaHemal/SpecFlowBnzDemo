Feature: PaymentPage

Payment Functionality 

@tag1
Scenario: Navigate to Payment page and transfer payment successfully
	Given I Navigate to Payments page 
	And Transfer $500 from Everyday account to Bills account 
	And Transfer successful message is displayed 
	Then Verify the current balance of Everyday account and Bills account are correct


