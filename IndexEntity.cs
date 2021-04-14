using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutcomeManagementSystem
{
    public class IndexEntity
    {
        public int Index { get; set; }
        public int TotalEntities { get; set; }

        public IndexEntity(int index, int totalEtities)
        {
            Index = index;
            TotalEntities = totalEtities;
        }

        public bool HasPrevious
        {
            get
            {
                return (Index > 1);
            }
        }

        public bool HasNext
        {
            get
            {
                return (Index < TotalEntities);
            }
        }
    }
}
