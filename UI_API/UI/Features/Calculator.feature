Feature:HomePage https://www.machiningcloud.com/app/en

@BVT
Scenario: Verify the homepage.
	Given User navigates to Homepage
	When the homepge is loaded
	Then verify the title of the webpage