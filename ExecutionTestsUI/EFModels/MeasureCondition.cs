using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class MeasureCondition
    {
        public MeasureCondition()
        {
            ExecutionTests = new HashSet<ExecutionTest>();
        }

        public double Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExecutionTest> ExecutionTests { get; set; }
    }
}
