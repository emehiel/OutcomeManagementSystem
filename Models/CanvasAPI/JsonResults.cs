using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem.Models.CanvasAPI
{
    public class JsonResults
    {
        
        public class ParentOutcomeGroup
        {
            public int id { get; set; }
            public string title { get; set; }
            public string vendor_guid { get; set; }
            public string url { get; set; }
            public string subgroups_url { get; set; }
            public string outcomes_url { get; set; }
            public bool can_edit { get; set; }
        }

        public class OutcomeGroup
        {
            public int id { get; set; }
            public string title { get; set; }
            public string vendor_guid { get; set; }
            public string url { get; set; }
            public string subgroups_url { get; set; }
            public string outcomes_url { get; set; }
            public bool can_edit { get; set; }
            public string import_url { get; set; }
            public int context_id { get; set; }
            public string context_type { get; set; }
            public string description { get; set; }
            public ParentOutcomeGroup parent_outcome_group { get; set; }
        }


        public class Outcome
        {
            public int id { get; set; }
            public int context_id { get; set; }
            public string ContextType { get; set; }
            public object vendor_guid { get; set; }
            public string display_name { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string calculation_method { get; set; }
            public string url { get; set; }
            public bool can_edit { get; set; }
            public bool has_updateable_rubrics { get; set; }
        }

        public class OutcomeWrapper
        {
            public int Context_id { get; set; }
            public string contex_type { get; set; }
            public bool quiz_lti { get; set; }
            public string url { get; set; }
            public ParentOutcomeGroup outcome_group { get; set; }
            public Outcome outcome { get; set; }
            public bool can_unlink { get; set; }
            public bool assessed { get; set; }
        }

        public class OutcomeInput
        {
            public string Title { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public string CalcType { get; set; }
            public int InputID { get; set; }
        }
        public class OutcomeMod
        {
            public string Title { get; set; }
            public string DisplayName { get; set; }
            public string Description { get; set; }
            public string CalcType { get; set; }
            public int InputID { get; set; }
        }
        public class OutcomeDelete
        {

            public int ID { get; set; }
            public int GrpID { get; set; }
        }

        public class OutcomeResultWrapper
        {
            public List<OutcomeResult> OutcomeResults { get; set; }
        }
        public class OutcomeResult
        {
            public int id { get; set; }
            public double score { get; set; }
            public bool mastery { get; set; }
            public double possible { get; set; }
            public bool hide_points { get; set; }
            public bool hidden { get; set; }
            public string submitted_or_assessed_at { get; set; }
            public Links links { get; set; }
            
        }
        public class Links
        {
            public int user { get; set; }
            public int learning_outcome { get; set; }
            public string alignment { get; set; }
            public string assignment { get; set; }
        }

    }
    }


