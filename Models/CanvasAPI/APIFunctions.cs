﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace OutcomeManagementSystem.Models.CanvasAPI
{
    public class APIFunctions
    {

        const string token = "15279~OG82FJYfmMcWrcQqBEfMum3M38WSUUl470yUSDU0m5NvbQO7suvnM6HUTfHYXyMN";
        //const string token = "15279~QelpTxI5yIH9FUTaksgYdERBm83qsYJR5bbAYGGmdVEBF8i3VMSOarre6Ctfggjw";
        const string domain = "calpoly.instructure.com";
        public string domaininfo = $"https://canvas.calpoly.edu";

        public JsonResults.Outcome GetOutcome(string outcomeID)
        {

            string url = domaininfo + $"/api/v1/outcomes/" + outcomeID + "?access_token=" + token;
            var restClient = new RestClient(url);
            restClient.ThrowOnAnyError = true;
            restClient.ThrowOnDeserializationError = true;
            var request = new RestRequest(Method.GET);

            try
            {
                var test = restClient.Execute<JsonResults.Outcome>(request);
                return test.Data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //return restClient.Execute(request);
        }

        public IRestResponse GetOutcomeGroup(string outcomegroupID)
        {

            string url = domaininfo + $"/api/v1/accounts/1/outcome_groups/" + outcomegroupID + "?access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);

            return restClient.Execute(request);
        }
        public IRestResponse PutOutcome(int outcomeID, JObject Jbody)
        {

            //string url = domaininfo + $"/outcomes/953?access_token={token}";
            string url = domaininfo + $"/api/v1/outcomes/" + outcomeID + "?access_token=" + token;

            //JObject jObjectbody = new JObject();
            //jObjectbody.Add("outcome_id", 12345);
            //jObjectbody.Add("title", "Test Outcome");
            //jObjectbody.Add("description", "<p>This is a test to see if I can add an outcome via API</p>");


            var restClient = new RestClient(url);
            var request = new RestRequest(Method.PUT);
            request.AddParameter("application/json", Jbody, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return restClient.Execute(request);
        }
        public IRestResponse PostOutcome(int outcomegroupID, JObject Jbody)
        {

            string domaininfo = $"https://canvas.calpoly.edu/api/v1";


            string url = domaininfo + $"/api/v1/accounts/1/outcome_groups/" + outcomegroupID + "/outcomes?access_token=" + token;

            //JObject jObjectbody = new JObject();
            ////jObjectbody.Add("outcome_id", 12345);
            ////jObjectbody.Add("title", "Test Outcome");
            //jObjectbody.Add("description", "<p>This is a test to see if I can add an outcome via API</p>");


            var restClient = new RestClient(url);
            var request = new RestRequest(Method.POST);
            
            request.AddParameter("application/json", Jbody, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            return restClient.Execute(request);
        }
        public IRestResponse DeleteOutcome(int outcomeID, int outcomegroupID)
        {
            
            string url = domaininfo + $"/api/v1/accounts/1/outcome_groups/" +outcomegroupID+"/outcomes/" + outcomeID + "?access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.DELETE);

            return restClient.Execute(request);
        }
        public IRestResponse DeleteCourseOutcomeGroup(string courseID, string outcomegroupID)
        {

            string url = domaininfo + $"/api/v1/courses/" + courseID + "/outcome_groups/" + outcomegroupID + "?access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.DELETE);

            return restClient.Execute(request);
        }

        public List<JsonResults.OutcomeGroup> GetAccountOutcomeSubGroups(int outcomegroupID)
        {

            string url = domaininfo + $"/api/v1/accounts/1/outcome_groups/" + outcomegroupID + "/subgroups?include=items&per_page=20;access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);

            var test = restClient.Execute<List<JsonResults.OutcomeGroup>>(request);
            return test.Data;
        }
        public List<JsonResults.OutcomeGroup> GetAllAccountOutcomeGroups()
        {

            string url = domaininfo + $"/api/v1/accounts/1/outcome_groups?include=items&per_page=100;access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var test = restClient.Execute<List<JsonResults.OutcomeGroup>>(request);
            return test.Data;
        }

        public List<JsonResults.OutcomeWrapper> GetSubGroupOutcomes(int outcomegroupID)
        {

            string url = domaininfo + $"/api/v1/accounts/1/outcome_groups/" + outcomegroupID + "/outcomes?include=items&per_page=20;access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);

            var test = restClient.Execute<List<JsonResults.OutcomeWrapper>>(request);
            return test.Data;
        }

        public List<JsonResults.OutcomeWrapper> GetSubGroupOutcomes(string outcomes_url)
        {
            string url = domaininfo + outcomes_url + "?include=items&per_page=20;access_token=" + token;
            //string url = domaininfo + $"/api/v1/accounts/1/outcome_groups/" + outcomegroupID + "/outcomes?include=items&per_page=20;access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);

            var test = restClient.Execute<List<JsonResults.OutcomeWrapper>>(request);
            return test.Data;
        }
        public IRestResponse GetCourseOutcomeGroup(string courseID)
        {

            string url = domaininfo + $"/api/v1/courses/" + courseID + "/outcome_groups?access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);

            return restClient.Execute(request);
        }

        //public IRestResponse CanvasGetOutcomeGroup(string outcomegroupID)
        //{

        //    string url = domaininfo + $"/accounts/1/outcome_groups/" + outcomegroupID + "?access_token=" + token;
        //    var restClient = new RestClient(url);
        //    var request = new RestRequest(Method.GET);

        //    return restClient.Execute(request);
        //}
    }
}
