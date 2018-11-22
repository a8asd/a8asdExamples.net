Feature: CheckoutBook
	so I can read books without paying for them
	As Reg
	I want to be able to borrow books
@web tests
Background:
	Given there are these members
	| Id  | name     | status |
	| reg | reginald | true   |
	| tim | timothy  | false  |
	Given these books are in the library
	| Isbn    | Title        | Available | Author |
	| valid   | Valid Book   | true      | me     |
	| invalid | Invalid Book | false     | him    |
	| clean   | clean code   | true      | uncle  |

Scenario: Reg checks out the valid book
	When reg checks out the valid book
	Then the valid book appears in reg's booklist
	And the valid book is not available


#Scenario: Reg tries to checkout an unavailable book














# Scenario: Reg tries to checkout an unavailable book
# Scenario: Tim tries to checkout book
#	Given these books are in the library
	#| Isbn    | Title        | Available | Author    |
	#| valid   | Valid Book   | true      | me        |
	#| invalid | Invalid Book | false     | him       |
	#| clean   | clean code   | true      | uncle bob |
#	And Reg is a valid member
