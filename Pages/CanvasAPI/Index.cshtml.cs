using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OutcomeManagementSystem.Models.CanvasAPI;
using RestSharp;



namespace OutcomeManagementSystem.Pages.CanvasAPI
{
    public class IndexModel : PageModel
    {

        // some logic, but probably not the right way to do this 


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
