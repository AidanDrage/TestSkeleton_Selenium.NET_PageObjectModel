Feature: API Test
	As A Tester
	I Want to interact with a REST API using RestSharp
	So That I Can Gain the Needed Skills

@REST @GoogleHomePage @GET
Scenario: Google API Get
	Given Google is Online
	When I send a GET request 
	Then The Reponse status is OK

@REST @GET
Scenario: : Reqres.in get all users
	Given ReqRes.in is Online
	When I send a request to get all users 
	Then The Reponse status is OK

@REST @GET
Scenario: : JSON Server get all posts
	Given The Node JSON Server is spun up
	When I send a request to get all posts 
	Then The Reponse status is OK