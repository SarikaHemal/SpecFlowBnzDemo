Feature: PaymentPage

Payment Functionality 

@tag1
Scenario: Navigate to Payment page and transfer payment successfully
	Given I Navigate to Payments page 
	And Transfer $500 from Everyday account to Bills account 
	And Transfer successful message is displayed 
	Then Verify the current balance of Everyday account and Bills account are correct


#TC5: Navigate to Payments page 
#1. Navigate to Payments page 
#2. Transfer $500 from Everyday account to Bills account 
#3. Transfer successful message is displayed 
#4. Verify the current balance of Everyday account and Bills account are correct