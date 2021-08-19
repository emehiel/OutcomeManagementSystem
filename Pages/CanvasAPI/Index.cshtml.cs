using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using OutcomeManagementSystem.Models.CanvasAPI;
using RestSharp;
using OutcomeManagementSystem.Pages;

namespace OutcomeManagementSystem.Pages.CanvasAPI
{
    public class IndexModel : PageModel
    {

        // some logic, but probably not the right way to do this 
        [BindProperty]
        public JsonResults.OutcomeInput Input { get; set; }
        [BindProperty]
        public JsonResults.OutcomeMod Mod { get; set; }
        [BindProperty]
        public JsonResults.OutcomeDelete Delete { get; set; }
        public List<JsonResults.OutcomeGroup> AccOutcome { get; set; }

        public List<JsonResults.OutcomeGroup> OutcomeGroups { get; set; }
        public List<JsonResults.OutcomeGroup> SubOutcomeGroups { get; set; }
        public List<JsonResults.OutcomeWrapper> GroupOutcomes { get; set; }
        public List<JsonResults.OutcomeWrapper> SubGroupOutcomes { get; set; }

        public APIFunctions CanvasAPI = new APIFunctions();
        public DataTable dt = new DataTable();
        public JsonResults.Outcome SelectedOutcome { get; set; }
        public JsonResults.OutcomeGroup SelectedOutcomeGroup { get; set; }
        public List<(int?, string)> BreadCrumbs = new List<(int?, string)>();
        public IEnumerable<HierarchyNode<OutcomeGroupWrapper>> OutcomeTree { get; set; }

        public void OnGet(int? id, int? subGroupId)
        {
            AccOutcome = CanvasAPI.GetAllAccountOutcomeGroups();
            //var AccOutcomeWrapperList = new List<OutcomeGroupWrapper>();


            //foreach (var ao in AccOutcome)
            //{
            //    var ocgw = new OutcomeGroupWrapper();
            //    ocgw.OutcomeGroup = ao;
            //    ocgw.Id = ao.id;
            //    ocgw.Outcomes = CanvasAPI.GetSubGroupOutcomes(ao.outcomes_url);
            //    if (ao.parent_outcome_group != null)
            //        ocgw.ParentId = ao.parent_outcome_group.id;
            //    else
            //        ocgw.ParentId = null;
            //    AccOutcomeWrapperList.Add(ocgw);
            //}

            //OutcomeTree = AccOutcomeWrapperList.AsHierarchy(e => e.Id, e => e.ParentId);
            
            if (id == null) id = 1;
            
            SelectedOutcomeGroup = AccOutcome.Find(s => s.id == id);
            if (SelectedOutcomeGroup != null)
            {
                BreadCrumbs.Insert(0, (SelectedOutcomeGroup.id, SelectedOutcomeGroup.title));

                int? pid = id;

                while (pid != 1)
                {
                    var pNode = AccOutcome.Find(i => i.id == pid).parent_outcome_group;
                    pid = pNode.id;
                    string title = pNode.title;
                    BreadCrumbs.Insert(0, (pid, title));

                }

                OutcomeGroups = CanvasAPI.GetAccountOutcomeSubGroups(id.Value);
                GroupOutcomes = CanvasAPI.GetSubGroupOutcomes(id.Value);
            }
            else //an Outcome was Selected
            {
                var outcomeGroup = AccOutcome.Find(s => s.id == subGroupId.Value);
                BreadCrumbs.Insert(0, (outcomeGroup.id, outcomeGroup.title));

                int? pid = subGroupId;

                while (pid != 1)
                {
                    var pNode = AccOutcome.Find(i => i.id == pid).parent_outcome_group;
                    pid = pNode.id;
                    string title = pNode.title;
                    BreadCrumbs.Insert(0, (pid, title));

                }
                OutcomeGroups = CanvasAPI.GetAccountOutcomeSubGroups(subGroupId.Value);
                GroupOutcomes = CanvasAPI.GetSubGroupOutcomes(subGroupId.Value);

                SelectedOutcome = CanvasAPI.GetOutcome(id.ToString());
            }
            //}

            //if (SelectedOutcomeGroup != null)
            //    SubOutcomeGroups = CanvasAPI.GetAccountOutcomeSubGroups(SelectedOutcomeGroup.id);
            //else
            //    SubOutcomeGroups = null;
            /*
            //txtTitle.value
            //var button = _Pages_CanvasAPI_Index.getElementById('MyForm');
            //var bsButton = new bootstrap.Button(button);

            //dt.Columns.Add("0");
            //DataRow row = dt.NewRow();
            //row[0] = Respons4e[0].title;
            //dt.Rows.Add(row);


            //for (int i = 1; i < Respons4e.Count; i++)
            //{
            //    dt.Columns.Add(i.ToString());
            //    foreach (var item in subgroup.GetAccountOutcomeSubGroup(Respons4e[i - 1].id))
            //    // foreach (var item in subgroup.GetAccountOutcomeSubGroup(getID(dt.Rows[i-1][i-1].ToString())))
            //    {

            //        row = dt.NewRow();
            //        row[i] = item.title;
            //        dt.Rows.Add(row);



            //        //foreach (var item2 in subgroup.GetAccountOutcomeSubGroup(item.id))
            //        //{
            //        //    //row = dt.NewRow();
            //        //    //row[i] = item2.title;
            //        //    if (dt.Rows[i][i].ToString() == "") { 
            //        //    dt.Rows[i][i]= item2.title;
            //        //    }
            //        //    else
            //        //    {
            //        //        row = dt.NewRow();
            //        //        row[i] = item2.title;
            //        //        dt.Rows.Add(row);
            //        //    }
            //        //    }

            //    }

            //}
            */



        }

        public void OnPost()
        {
            AccOutcome = CanvasAPI.GetAllAccountOutcomeGroups();

            //if (id != null)
            //{
            //    SubOutcomeGrp = subgroup.GetAccountOutcomeSubGroup(id.Value);
            //    Outcomes = subgroup.GetSubGroupOutcomes(id.Value);
            //}

            if (Delete != null)
            {
                var test = CanvasAPI.DeleteOutcome(Delete.ID, Delete.GrpID);
            }
            if (Mod.Title != null)
            {
                JObject jObjectbodymod = new JObject();
                jObjectbodymod.Add("title", Mod.Title);
                jObjectbodymod.Add("display_name", Mod.DisplayName);
                //jObjectbodymod.Add("description", Mod.Description);
                //jObjectbodymod.Add("calculation_method", Mod.CalcType);

                var test = CanvasAPI.PutOutcome(Mod.InputID, jObjectbodymod);
            }
            if (Input.Title != null)
            {
                JObject jObjectbody = new JObject();
                jObjectbody.Add("title", Input.Title);
                jObjectbody.Add("display_name", Input.DisplayName);
                jObjectbody.Add("description", Input.Description);
                jObjectbody.Add("calculation_method", Input.CalcType);

                var test2 = CanvasAPI.PostOutcome(Input.InputID, jObjectbody);
            }


        }

        //public int getID(string title)
        //{
        //    foreach (var item in Respons4e)
        //    {
        //        if (item.title == title)
        //        {
        //            return item.id;
        //        }
        //    }


        //    return 0;
        //}

    }
    public class OutcomeGroupWrapper
    {
        public int? ParentId { get; set; }
        public int Id { get; set; }
        public JsonResults.OutcomeGroup OutcomeGroup { get; set; }
        public List<JsonResults.OutcomeWrapper> Outcomes { get; set; }

    }
    public class OutcomeGroupNode
    {
        public JsonResults.OutcomeGroup OutcomeGroup { get; set; }
        public List<JsonResults.OutcomeWrapper> Outcomes { get; set; }
        public IEnumerable<OutcomeGroupNode> ChildNodes { get; set; }
        public int Depth { get; set; }
        public JsonResults.OutcomeGroup Parent { get; set; }
    }

}
