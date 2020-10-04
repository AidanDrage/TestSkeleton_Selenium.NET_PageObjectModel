Feature: Wikipedia
    As A web user 
	I Want wikipedia to Work
	So that I am able to access information

@WikipediaHomePage
Scenario: Wikipedia Homepage Displays
	Given The User has Navigated to https://www.wikipedia.org/
	Then The Wikipedia Homepage will be displayed