Feature: FAQAPI
	Simple calculator for adding two numbers

@mytag
Scenario: Verify the status code as 200 for FAQ Get API Request
	Given User have the baseUri as "https://6363640a66f75177ea433657.mockapi.io/api/ahzam/testautomation"
	When User send the get request
	Then User get status code as 200
	| questionEnglish |
	| Using a public computer | 


Scenario: Verify the JSON response for FAQ Get API Request
	Given User have the baseUri as "https://6363640a66f75177ea433657.mockapi.io/api/ahzam/testautomation"
	When User send the get request
	Then User get the JSON response

Scenario: Verify the response should include 10 List data for FAQ Get API Request
	Given User have the baseUri as "https://6363640a66f75177ea433657.mockapi.io/api/ahzam/testautomation"
	When User send the get request
	Then User get the response which should include 10 List data
	And each user should display the field questionsAnswers