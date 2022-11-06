using UI_API.API.Deserializer;
using UI_API.API.Helper.Request;
using UI_API.API.Helper.ResponseData;
using UI_API.API.Modal.JsonModal;
using UI_API.API.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FluentAssertions;

namespace UI_API.API.Steps
{
    [Binding]
    public class FAQAPISteps
    {
        private string requestUrl;
        private RestResponse restResponse;
        private FAQ faq;

        [Given(@"User have the baseUri as ""(.*)""")]
        public void GivenUserHaveTheBaseUriWithIdAs(string requestUri)
        {
            requestUrl = requestUri;
        }
        
        [When(@"User send the get request")]
        public void WhenUserSendTheGetRequest()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Accept", "application/json");
            restResponse = HttpClientHelper.PerformGetRequest(requestUrl, dict);
        }
        
        [Then(@"User get status code as (.*)")]
        public void ThenUserGetTheFAQDetailsWithStatusCodeAs(int statusCode, Table table)
        {
            Assert.AreEqual(restResponse.StatusCode, statusCode);
            //getEmployeeById = ResponseDataHelper.DeserializeJsonResponse<GetEmployeeByIdRoot>(restResponse.ResponseData);
            var faq = JsonConvert.DeserializeObject<List<FAQ>>(restResponse.ResponseData);
            var qaList = table.CreateSet<QA>();
            var qaData = qaList.ToList();
            Assert.AreEqual(faq[0].sectionNameEnglish, qaData[0].questionEnglish);
            //Assert.AreEqual(getEmployeeById.data.employee_name, employeeData[0].employee_name);
            //Assert.IsTrue(getEmployeeById.data.employee_age.Equals(employeeData[0].employee_age));
            //Assert.AreEqual(getEmployeeById.data.employee_salary, employeeData[0].employee_salary);
            //Assert.AreEqual(getEmployeeById.data.profile_image, employeeData[0].profile_image);
        }

        [Then(@"User get the JSON response")]
        public void ThenUserGetTheJSONResponse()
        {

        }

        [Then(@"User get the response which should include (.*) List data")]
        public void ThenUserGetTheResponseWhichShouldIncludeListData(int count)
        {
            var faq = JsonConvert.DeserializeObject<List<FAQ>>(restResponse.ResponseData);
            faq.Count.Equals(count);
        }

        [Then(@"each user should display the field (.*)")]
        public void ThenEachUserShouldDisplayTheFieldQuestionsAnswers(string qA)
        {
            var faq = JsonConvert.DeserializeObject<List<FAQ>>(restResponse.ResponseData);

            Assert.That(faq, Is.Not.Empty);
            foreach (var user in faq)
            {
                var outcome = user.GetType().GetProperty(qA);
                Assert.That(outcome, Is.All.Not.Null);
            }
        }



    }
}
