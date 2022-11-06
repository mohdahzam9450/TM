using TechTalk.SpecFlow;
using UI_API.UI.Hooks;
using UI_API.Pages;
using TechTalk.SpecFlow;

namespace UI_API.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private DriverHelper _driverHelper;
        HomePage homePage;

        public CalculatorStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);

        }

        [Given(@"User navigates to Homepage")]
        public void GivenUserNavigatesToHomepage()
        {
            _driverHelper.Driver.Navigate().GoToUrl("https://www.machiningcloud.com/app/en");

        }

        [When(@"the homepge is loaded")]
        public void WhenTheHomepgeIsLoaded()
        {
            homePage.CheckHPLoad();
        }

        [Then(@"verify the title of the webpage")]
        public void ThenVerifyTheTitleOfTheWebpage()
        {
            homePage.VerifyPageTitle();
        }
    }
}
