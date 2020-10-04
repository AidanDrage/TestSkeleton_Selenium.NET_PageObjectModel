Feature: UI Test
	As A web user 
	I Want Google to Work
	So that I am able to search the web

@GoogleHomePage
Scenario: Google Homepage Displays
	Given The User has Navigated to https://www.google.com
	Then The Google Homepage will be displayed

@GoogleResultsPage
Scenario: Search result page title
    Given The Google Homepage is Displayed
    When The User performs a search for Hello, World!
    Then The Title of the search results page will reflect the search term