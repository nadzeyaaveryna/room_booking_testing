Feature: BookingRoom

Feature to test booking personal detais form 

@Bug
Scenario Outline: Validate First Name field on incorrect input
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'First Name' as '<FirstName>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| FirstName  |
	|            |
	| 2111211112 |
	| ~#%        |
	| #          |
	| lowercase  |
	| Two Words  |
	| Jiný       |
	| 他の言語    |


Scenario Outline: Validate First Name field length error handling 
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'First Name' with length as '<FirstName>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| FirstName  |
	|   1        |
	|   2        |
	|   19       |

Scenario Outline: Validate First Name field length acceptance
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'First Name' with length as '<FirstName>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'not present'
	And I check that ‘Booking Successful’ modal is 'present'
Examples:
	| FirstName  |
	|   3        |
	|   18       |

@Bug
Scenario Outline: Validate Last Name field on incorrect input
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'Last Name' as '<LastName>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| LastName  |
	|            |
	| 2111211112 |
	| ~#%        |
	| #          |
	| lowercase  |
	| Two Words  |
	| Jiný       |
	| 他の言語    |

Scenario Outline: Validate Last Name field length error handling 
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'First Name' with length as '<LastName>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| LastName   |
	|   1        |
	|   2        |
	|   19       |

Scenario Outline: Validate Last Name field length acceptance
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'First Name' with length as '<LastName>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'not present'
	And I check that ‘Booking Successful’ modal is 'present'
Examples:
	| LastName   |
	|   3        |
	|   18       |


	@Bug
Scenario Outline: Validate Email field on incorrect input
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'Email' as '<Email>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| Email  |
	|            |
	| ~#%        |
	| @test.com  |
	| test       |
	| test@      |
	| test@test  |
	| test@test. |
	| .com       |


	#TODO Refactor the limitation 11-21, but in test 1 and 13, as @test.com = 9 symbols
	@Bug
Scenario Outline: Validate Email field length error handling 
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'Email' with length as '<Email>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| Email |
	| 1     | 
	| 13    |



	#TODO Refactor the limitation 11-21, but in test 1 and 13, as @test.com = 9 symbols
Scenario Outline: Validate Email field length acceptance
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'Email' with length as '<Email>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'not present'
	And I check that ‘Booking Successful’ modal is 'present'
Examples:
	| LastName   |
	|   3        |
	|  12        |



		@Bug
Scenario Outline: Validate Phone field on incorrect input
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'Phone' as '<Phone>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| Phone	                 |
	|                        |
	| ~#% 542323344423       |
	| testtesttesttest       |



Scenario Outline: Validate Phone field length error handling 
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And Prepare user details with 'Phone' with length as '<Phone>'
	And I click ‘Book this room’ button for selected room
	And Select '2' day stay on calendar in starting from '2' months ahead
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then Check that error message is 'present'
	And I check that ‘Booking Successful’ modal is 'not present'
Examples:
	| Phone |
	| 10    | 
	| 22    |

@TODO
@Ignore
Scenario: Validate Phone field length acceptance
