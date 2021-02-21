using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class SelectionSet
    {
        public SelectionSet()
        {
            Parameters = new HashSet<Parameter>();
            SelectionSetOptionItems = new HashSet<SelectionSetOptionItem>();
        }

        public double Id { get; set; }
        public string SetName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Parameter> Parameters { get; set; }
        public virtual ICollection<SelectionSetOptionItem> SelectionSetOptionItems { get; set; }
    }
}
