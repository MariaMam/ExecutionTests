using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class SelectionSetOptionItem
    {
        public SelectionSetOptionItem()
        {
            ExecutionTests = new HashSet<ExecutionTest>();
        }

        public double Id { get; set; }
        public double? SelectionSetId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double? ItemValue { get; set; }
        public double? IsDefault { get; set; }
        public double? IsFailed { get; set; }

        public virtual SelectionSet SelectionSet { get; set; }
        public virtual ICollection<ExecutionTest> ExecutionTests { get; set; }
    }
}
