using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.RegularExpressions;

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

        public JsonResults.OutcomeResultWrapper GetOutcomeResults(int courseID)
        {

            string url = domaininfo + $"/api/v1/courses/" + courseID + "/outcome_results?page=1&per_page=100&access_token=" + token;
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);

            var test = restClient.Execute<JsonResults.OutcomeResultWrapper>(request);
            var data = test.Data;
            int i = 2;
            while (test.Data.OutcomeResults.Count != 0)
            {
                url = domaininfo + $"/api/v1/courses/" + courseID + "/outcome_results?page=" + i.ToString() + "&per_page=100&access_token=" + token;
                restClient.BaseUrl = new Uri(url);
                test = restClient.Execute<JsonResults.OutcomeResultWrapper>(request);
                data.OutcomeResults.AddRange(test.Data.OutcomeResults);
                i++;
            }
            var linkHeader = test.Headers.First(h => h.Name == "Link").Value.ToString();

            var links = LinkHeader.LinksFromHeader(linkHeader);

            return data;// test.Data;
        }
        //public IRestResponse CanvasGetOutcomeGroup(string outcomegroupID)
        //{

        //    string url = domaininfo + $"/accounts/1/outcome_groups/" + outcomegroupID + "?access_token=" + token;
        //    var restClient = new RestClient(url);
        //    var request = new RestRequest(Method.GET);

        //    return restClient.Execute(request);
        //}
    }

    public class LinkHeader
    {
        public string FirstLink { get; set; }
        public string PrevLink { get; set; }
        public string NextLink { get; set; }
        public string LastLink { get; set; }

        public static LinkHeader LinksFromHeader(string linkHeaderStr)
        {
            LinkHeader linkHeader = null;

            if (!string.IsNullOrWhiteSpace(linkHeaderStr))
            {
                string[] linkStrings = linkHeaderStr.Split(',');

                if (linkStrings != null && linkStrings.Any())
                {
                    linkHeader = new LinkHeader();

                    foreach (string linkString in linkStrings)
                    {
                        var relMatch = Regex.Match(linkString, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                        var linkMatch = Regex.Match(linkString, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                        if (relMatch.Success && linkMatch.Success)
                        {
                            string rel = relMatch.Value.ToUpper();
                            string link = linkMatch.Value;

                            switch (rel)
                            {
                                case "FIRST":
                                    linkHeader.FirstLink = link;
                                    break;
                                case "PREV":
                                    linkHeader.PrevLink = link;
                                    break;
                                case "NEXT":
                                    linkHeader.NextLink = link;
                                    break;
                                case "LAST":
                                    linkHeader.LastLink = link;
                                    break;
                            }
                        }
                    }
                }
            }

            return linkHeader;
        }
    }
}
