Feature: Calendar

A short summary of the feature


Scenario: Check that Rooms List is Available in booking page
	Given I navigate to booking application 
	Then Check that at least one room is 'present' in the list

Scenario: Check that calendar appers if click Book this room 
	Given I navigate to booking application 
	When Select first room available in booking page
	Then Check that Calendar is 'not present' in a room card

	When I click ‘Book this room’ button for selected room
	Then Check that Calendar is 'present' in a room card
	
Scenario: Check that calendar disappers if click Cancel 
	Given I navigate to booking application 
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	And Click on ‘Cancel’ button on room form
	Then Check that Calendar is 'not present' in a room card	

Scenario: Check that calendar necessary elements appear
	Given I navigate to booking application 
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	Then Check that calendar necessary elements appear


Scenario: Check that calndar shows correct month and year when navigate the calendar
	Given I navigate to booking application 
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
	Given I navigate to booking application 
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	Then Check that days from previous month are disabled


Scenario: User should be unable to select past days
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve selected room details
	And I click ‘Book this room’ button for selected room
	And Try to select time slot with past date
	Then Check that selected slot is 'not present' on calendar



Scenario: User should be unable to select days of prevoius month that is visible in current
Scenario: User should be unable to select days of next month that is visible in current
Scenario: Check that selected time slot shows correct booking details
Scenario: Check that selected time slot is saved on calendar when navigate buttons
Scenario: User should be able to select time slot that spans across two months

	#3-30 3-18 11-21
	#2024-09-19 - 2024-09-22


