Feature: EndToEndRoomBooking

Featrure that provides testing of E2E scenarios


Scenario: Check Room details
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve selected room details
	Then Check that room details are correct


@Bug
@E2E
#TODO test to validate time slot on calndar
Scenario: User should be able to book the room
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And I click ‘Book this room’ button for selected room
	And Select '3' day stay on calendar in current month
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then I check that ‘Booking Successful’ modal is 'present'
	Then I check that ‘Booking Successful’ modal appears with correct dates and text

@E2E
Scenario: User should not be able to Book the already booked dates
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And I click ‘Book this room’ button for selected room
	And Select '3' day stay on calendar in one of the next months
	And Input personal details into form
	And Click on ‘Book’ button on room form
	And Close ‘Booking Successful’ modal

	And I click ‘Book this room’ button for selected room
	And Select '3' day stay on calendar in one of the next months
	And Input personal details into form
	And Click on ‘Book’ button on room form
	Then I check that ‘Booking Successful’ modal is 'not present'
	Then Check that error message is 'present'


@E2E
#TODO test to validate time slot on calndar
Scenario: User should be able to cancel booking process
	Given I navigate to booking application 
	When Select first room available in booking page
	And Retrieve booked slots for room
	And I click ‘Book this room’ button for selected room
	And Select '3' day stay on calendar in one of the next months
	And Input personal details into form
	And Click on ‘Cancel’ button on room form
	Then Check that Calendar is 'not present' in a room card

	When I click ‘Book this room’ button for selected room
	Then Check that personal details are not filled in