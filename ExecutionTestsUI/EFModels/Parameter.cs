using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class Parameter
    {
        public Parameter()
        {
            ExecutionTests = new HashSet<ExecutionTest>();
        }

        public double Id { get; set; }
        public string Name { get; set; }
        public double? UnitId { get; set; }
        public double? DecimalPlaces { get; set; }
        public string Comment { get; set; }
        public double? WithPicture { get; set; }
        public string ParameterType { get; set; }
        public double? SelectionSetId { get; set; }

        public virtual SelectionSet SelectionSet { get; set; }
        public virtual ICollection<ExecutionTest> ExecutionTests { get; set; }
    }
}
