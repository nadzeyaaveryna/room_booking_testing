Feature: Calendar

Feature to test calendar detais and actions 

Background: 
	Given I navigate to booking application 

Scenario: Check that Rooms List is Available in booking page
	Then Check that at least one room is 'present' in the list

Scenario: Check that calendar appers if click Book this room 
	When Select first room available in booking page
	Then Check that Calendar is 'not present' in a room card

	When I click ‘Book this room’ button for selected room
	Then Check that Calendar is 'present' in a room card
	
Scenario: Check that calendar disappers if click Cancel 
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	And Click on ‘Cancel’ button on room form
	Then Check that Calendar is 'not present' in a room card	

Scenario: Check that calendar necessary elements appear
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	Then Check that calendar necessary elements appear


Scenario: Check that calndar shows correct month and year when navigate the calendar
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room

	#Current month 
	Then Check that calendar shows correct month and year

	#Next month
	When Click 'Next' calendar button
	Then Check that calendar shows correct month and year

	#Current month
	When Click 'Today' calendar button
	Then Check that calendar shows correct month and year

	#Previous month
	When Click 'Back' calendar button
	Then Check that calendar shows correct month and year

	#Previous month
	When Click 'Back' calendar button
	Then Check that calendar shows correct month and year

Scenario: Check that calendar dates are correct

@Bug
Scenario: Check that days from past month visible in calendar are disabled 
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	Then Check that days from previous month are disabled

@Bug
Scenario: User should be unable to select past days
	When Select first room available in booking page
	And Retrieve selected room details
	And I click ‘Book this room’ button for selected room
	And Try to select time slot with past date
	Then Check that selected slot is 'not present' on calendar

 
Scenario: Check that selected time slot is saved on calendar when navigate Next and Back buttons
	When Select first room available in booking page
	And Retrieve selected room details
	And I click ‘Book this room’ button for selected room
	And Select '3' day stay on calendar in one of the next months

	#Next month
	When Click 'Next' calendar button
	#Go back
	When Click 'Back' calendar button
	Then Check that selected slot is 'present' on calendar


	 
Scenario: Check that selected time slot is saved on calendar when navigate Today and Next buttons
	When Select first room available in booking page
	And Retrieve selected room details
	And I click ‘Book this room’ button for selected room
	And Select '3' day stay on calendar in one of the next months

	#Next month
	When Click 'Today' calendar button
	#Go back
	When Click 'Next' calendar button
	Then Check that selected slot is 'present' on calendar


@TODO
@Ignore 
Scenario: User should be unable to select days of prevoius month that is visible in current

@TODO
@Ignore 
Scenario: User should be unable to select days of next month that is visible in current

@TODO
@Ignore 
Scenario: User should be able to see previous month slots if they are visible in current month

#Check that time slot is selected for correct days in calendar, not just present 
@TODO
@Ignore 
Scenario: Check that selected time slot shows correct booking details in calendar

@TODO
@Ignore 
@Bug
Scenario: User should be able to select time slot that spans across two months

@TODO
@Ignore 
Scenario: User should be able to select two time slots



