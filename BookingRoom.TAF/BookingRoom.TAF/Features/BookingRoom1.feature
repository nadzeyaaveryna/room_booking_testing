Feature: BookingRoom1

A short summary of the feature


Scenario: Rooms List is Available in booking page
	Given I navigate to booking application 
	Then Check that at least one room is 'present' in the list


Scenario: Validate Room details
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And I click ‘Book this room’ button for selected room

@tag1
Scenario: Booking room scenario1
	Given I navigate to booking application 
	When Select first room available in booking page
	And I click ‘Book this room’ button for selected room
	And Select two night three day stay on calendar in current month
	#And Input personal details into form
	#And Click on ‘Book this room’ button
	#Then I check that ‘Book Successful’ dialog appears with correct booking date