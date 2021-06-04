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
        public List<JsonResults.OutcomeArray> AccOutcome { get; set; }

        public List<JsonResults.OutcomeArray> SubOutcomeGrp { get; set; }
        public List<JsonResults.Root> Outcomes { get; set; }
        public APIFunctions subgroup = new APIFunctions();
        public DataTable dt = new DataTable();
       
        
        
        public void OnGet(int? id)
        {

        AccOutcome = subgroup.GetAccountOutcomeGroup();

            if(id != null) {
                SubOutcomeGrp = subgroup.GetAccountOutcomeSubGroup(id.Value);
                Outcomes= subgroup.GetSubGroupOutcomes(id.Value);
            }
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




        }
        
        public void OnPost()
        {
            AccOutcome = subgroup.GetAccountOutcomeGroup();

            //if (id != null)
            //{
            //    SubOutcomeGrp = subgroup.GetAccountOutcomeSubGroup(id.Value);
            //    Outcomes = subgroup.GetSubGroupOutcomes(id.Value);
            //}

            if (Delete != null)
            {
                var test = subgroup.DeleteOutcome(Delete.ID,Delete.GrpID);
            }
                if (Mod.Title != null)
            {
                JObject jObjectbodymod = new JObject();
                jObjectbodymod.Add("title", Mod.Title);
                jObjectbodymod.Add("display_name", Mod.DisplayName);
                //jObjectbodymod.Add("description", Mod.Description);
                //jObjectbodymod.Add("calculation_method", Mod.CalcType);

                var test = subgroup.PutOutcome(Mod.InputID, jObjectbodymod);
            }
            if(Input.Title != null) { 
            JObject jObjectbody = new JObject();
            jObjectbody.Add("title", Input.Title);
            jObjectbody.Add("display_name", Input.DisplayName);
            jObjectbody.Add("description", Input.Description);
            jObjectbody.Add("calculation_method", Input.CalcType);

            var test2 = subgroup.PostOutcome(Input.InputID, jObjectbody);
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
}
