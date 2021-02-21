using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class Category
    {
        public Category()
        {
            ExecutionTests = new HashSet<ExecutionTest>();
        }

        public double Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }

        public virtual ICollection<ExecutionTest> ExecutionTests { get; set; }
    }
}
