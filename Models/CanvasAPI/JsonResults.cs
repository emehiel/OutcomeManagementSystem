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

        public class OutcomeArray
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
            public string context_type { get; set; }
            public object vendor_guid { get; set; }
            public string display_name { get; set; }
            public string title { get; set; }
            public string url { get; set; }
            public bool can_edit { get; set; }
            public bool has_updateable_rubrics { get; set; }
        }

        public class Root
        {
            public int context_id { get; set; }
            public string context_type { get; set; }
            public bool quiz_lti { get; set; }
            public string url { get; set; }
            public ParentOutcomeGroup outcome_group { get; set; }
            public Outcome outcome { get; set; }
            public bool can_unlink { get; set; }
            public bool assessed { get; set; }
        }

    }

}
