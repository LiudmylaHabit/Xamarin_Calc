Feature: CalculatorTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

	As a user 
	I want to add two numbers 
	In order to know their sum
	
	As a user
	I want to subtract two numbers
	In order to know their difference
	
	As a user 
	I want to multiply two numbers 
	In order to know their product
	
	As a user 
	I want to divide two numbers 
	In order to know their quotient
	
	As a user 
	I want to see an error message if I misspelled a number input  
	In order to correct it

	As a user 
	I want to see an error message if I misspelled an operation sign 
	In order to understand what my mistake was

	As a user 
	I want to see an error if I divide a number by zero 
	So that the space-time continuum won’t collapse if I press the “Calculate” button
	
	As a user 
	I want a calculator to have a “Clear” button, so that I don't have to clear all fields myself

	Background: 
	Given calculator app is initialized

@substract
Scenario Outline: Substract two numbers
	When The <first> number typed at the calculator
	When I tap on substract button
	When The <second> number typed at the calculator
	Then I see <first> and <second> numbers separated by substract operand
	When I tap on equal button
	Then I see the <result> of operation at the input field
	Examples: 
	| first | second | result | 
	| 6     | 3      | 3      |
	| 5     | 7      | -2     |
	| 4.5   | 2      | 2.5    |
	| 8     | 1.9    | 6.1    |
	| 0     | 5      | -5     |

@division
Scenario Outline: Division two numbers
	When The <first> number typed at the calculator
	When I tap on division button
	When The <second> number typed at the calculator
	Then I see <first> and <second> numbers separated by division operand
	When I tap on equal button
	Then I see the <result> of operation at the input field
	Examples: 
	| first | second | result            |
	| 10    | 5      | 2                 |
	| 9     | 6      | 1.5               |
	| 2     | 3      | 0.666666666666667 |
	| 0     | 15     | 0                 |
	| 5     | 2.5    | 2                 |

	@negative
Scenario: Correct reacrion on division on zero
	When The 45 number typed at the calculator
	When I tap on division button
	When The 0 number typed at the calculator
	Then I see 45 and 0 numbers separated by division operand	
	When I tap on equal button
	Then I see informational error message

