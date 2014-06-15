Feature: Example
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@test
Scenario:Add two numbers
	Given I last made a calculation 10 days ago
	And I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

@anothertest
Scenario:Add numbers
	Given I add together numbers
	When I press add
	Then the result should be 90 on the screen

@example
Scenario:System Users
	Given I have a number of users in a group
		| Name  | Surname |
		| Joe	| Bloggs  |
		| John  | Smith   |
	When I delete a user
	Then I have one user in the group