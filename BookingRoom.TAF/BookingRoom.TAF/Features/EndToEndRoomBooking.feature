Feature: EndToEndRoomBooking

A short summary of the feature

@Includes_api_call
Scenario: Check Room details
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve selected room details
	Then Check that room details are correct


	@tag1
Scenario: Booking room scenario1
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And I click ‘Book this room’ button for selected room
	And Select two night three day stay on calendar in current month
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then I check that ‘Booking Successful’ modal is 'present'
	Then I check that ‘Booking Successful’ modal appears with correct dates and text