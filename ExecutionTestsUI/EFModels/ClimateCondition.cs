using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class ClimateCondition
    {
        public ClimateCondition()
        {
            ExecutionTests = new HashSet<ExecutionTest>();
        }

        public double Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExecutionTest> ExecutionTests { get; set; }
    }
}
